﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Buffers;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.IO.Pipelines;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace SampleServer
{
    public abstract partial class IISHttpContext : IDisposable
    {
        private const int MinAllocBufferSize = 2048;

        protected readonly IntPtr _pHttpContext;
        private bool _upgradeAvailable;
        private bool _wasUpgraded;

        private readonly object _onStartingSync = new object();
        private readonly object _onCompletedSync = new object();

        protected Stack<KeyValuePair<Func<object, Task>, object>> _onStarting;
        protected Stack<KeyValuePair<Func<object, Task>, object>> _onCompleted;
        protected Exception _applicationException;
        private PipeFactory _pipeFactory;

        private List<GCHandle> _pinnedHeaders;

        private GCHandle _thisHandle;
        private BufferHandle _inputHandle;
        private IISAwaitable _readOperation = new IISAwaitable();
        private IISAwaitable _writeOperation = new IISAwaitable();
        private IISAwaitable _flushOperation = new IISAwaitable();

        protected Task _readingTask;
        protected Task _writingTask;
        protected Task _flushTask;

        public IISHttpContext(PipeFactory pipeFactory, IntPtr pHttpContext)
        {
            _thisHandle = GCHandle.Alloc(this);

            _pipeFactory = pipeFactory;
            _pHttpContext = pHttpContext;

            unsafe
            {
                var pHttpRequest = NativeMethods.http_get_raw_request(pHttpContext);

                var verb = pHttpRequest->Request.Verb;
                // Make this include Invalid?
                if (verb > HttpApi.HTTP_VERB.HttpVerbUnknown && verb < HttpApi.HTTP_VERB.HttpVerbMaximum)
                {
                    Method = HttpApi.HttpVerbs[(int)verb];
                }
                else
                {
                    // TODO: Handle unknown verbs
                }

                var major = pHttpRequest->Request.Version.MajorVersion;
                var minor = pHttpRequest->Request.Version.MinorVersion;

                HttpVersion = "HTTP/" + major + "." + minor; // Is this correct?
                Scheme = pHttpRequest->Request.pSslInfo == null ? "http" : "https";

                // TODO: Read this from IIS config
                PathBase = string.Empty;
                Path = Encoding.ASCII.GetString(pHttpRequest->Request.pRawUrl, pHttpRequest->Request.RawUrlLength);
                RawTarget = Path;
                QueryString = new string(pHttpRequest->Request.CookedUrl.pQueryString, 0, pHttpRequest->Request.CookedUrl.QueryStringLength / 2);
                // TODO: Avoid using long.ToString, it's pretty slow
                ConnectionId = pHttpRequest->Request.ConnectionId.ToString(CultureInfo.InvariantCulture);

                // Copied from WebListener
                // This is the base GUID used by HTTP.SYS for generating the activity ID.
                // HTTP.SYS overwrites the first 8 bytes of the base GUID with RequestId to generate ETW activity ID.
                var guid = new Guid(0xffcb4c93, 0xa57f, 0x453c, 0xb6, 0x3f, 0x84, 0x71, 0xc, 0x79, 0x67, 0xbb);
                *((ulong*)&guid) = pHttpRequest->Request.RequestId;

                // TODO: Also make this not slow
                TraceIdentifier = guid.ToString();

                // TODO: Parse socket ADDR for local and remote end point
                // var localAddress = GetSocketAddress(pHttpRequest->Request.Address.pLocalAddress);
                // var remoteAddress = GetSocketAddress(pHttpRequest->Request.Address.pRemoteAddress);

                RequestHeaders = new RequestHeaders(pHttpRequest);
            }

            RequestBody = new IISHttpRequestBody(this);
            ResponseBody = new IISHttpResponseBody(this);

            Input = _pipeFactory.Create(new PipeOptions { ReaderScheduler = TaskRunScheduler.Default });
            Output = _pipeFactory.Create(new PipeOptions { ReaderScheduler = TaskRunScheduler.Default });

            // TODO: Only upgradable on Win8 or higher
            _upgradeAvailable = true;

            ResetFeatureCollection();
        }

        public string HttpVersion { get; set; }
        public string Scheme { get; set; }
        public string Method { get; set; }
        public string PathBase { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string RawTarget { get; set; }
        public int StatusCode { get; set; } = 200;
        public string ReasonPhrase { get; set; }
        public CancellationToken RequestAborted { get; set; }
        public bool HasResponseStarted { get; set; }
        public IPAddress RemoteIpAddress { get; set; }
        public int RemotePort { get; set; }
        public IPAddress LocalIpAddress { get; set; }
        public int LocalPort { get; set; }
        public string ConnectionId { get; set; }
        public string TraceIdentifier { get; set; }

        public Stream RequestBody { get; set; }
        public Stream ResponseBody { get; set; }

        public IPipe Input { get; set; }
        public IPipe Output { get; set; }

        public IHeaderDictionary RequestHeaders { get; set; }
        public IHeaderDictionary ResponseHeaders { get; set; } = new HeaderDictionary();

        public IISAwaitable FlushAsync(CancellationToken cancellationToken)
        {
            if (!HasResponseStarted)
            {
                unsafe
                {
                    // TODO: Don't allocate a string
                    var reasonPhrase = ReasonPhrases.GetReasonPhrase(StatusCode);
                    var reasonPhraseBytes = Encoding.UTF8.GetBytes(reasonPhrase);

                    fixed (byte* pReasonPhrase = reasonPhraseBytes)
                    {
                        // This copies data into the underying buffer
                        NativeMethods.http_set_response_status_code(_pHttpContext, (ushort)StatusCode, pReasonPhrase);
                    }

                    HttpApi.HTTP_RESPONSE_V2* pHttpResponse = NativeMethods.http_get_raw_response(_pHttpContext);

                    _pinnedHeaders = SetHttpResponseHeaders(pHttpResponse);
                }
                HasResponseStarted = true;
            }

            unsafe
            {
                var fCompletionExpected = false;
                var hr = 0;

                hr = NativeMethods.http_flush_response_bytes(_pHttpContext, IISAwaitable.FlushCallback, (IntPtr)_thisHandle, out fCompletionExpected);

                if (!fCompletionExpected)
                {
                    CompleteFlush(hr, 0);
                }
            }
            return _flushOperation;
        }

        public unsafe List<GCHandle> SetHttpResponseHeaders(HttpApi.HTTP_RESPONSE_V2* pHttpResponse)
        {
            HttpApi.HTTP_UNKNOWN_HEADER[] unknownHeaders = null;
            //HttpApi.HTTP_RESPONSE_INFO[] knownHeaderInfo = null;
            var pinnedHeaders = new List<GCHandle>();
            GCHandle gcHandle;

            if (ResponseHeaders.Count == 0)
            {
                return null;
            }
            string headerName;
            string headerValue;
            int lookup;
            var numUnknownHeaders = 0;
            var numKnownMultiHeader = 0;
            byte[] bytes = null;

            foreach (var headerPair in ResponseHeaders)
            {
                if (headerPair.Value.Count == 0)
                {
                    continue;
                }
                lookup = HttpApi.HTTP_RESPONSE_HEADER_ID.IndexOfKnownHeader(headerPair.Key);
                if (lookup == -1) // TODO handle opaque stream upgrade?
                {
                    numUnknownHeaders++;
                }
                else if (headerPair.Value.Count > 1)
                {
                    numKnownMultiHeader++;
                }
            }

            try
            {
                var pKnownHeaders = &pHttpResponse->Response_V1.Headers.KnownHeaders;
                foreach (var headerPair in ResponseHeaders)
                {
                    if (headerPair.Value.Count == 0)
                    {
                        continue;
                    }
                    headerName = headerPair.Key;
                    StringValues headerValues = headerPair.Value;
                    lookup = HttpApi.HTTP_RESPONSE_HEADER_ID.IndexOfKnownHeader(headerName);
                    if (lookup == -1)
                    {
                        if (unknownHeaders == null)
                        {
                            unknownHeaders = new HttpApi.HTTP_UNKNOWN_HEADER[numUnknownHeaders];
                            gcHandle = GCHandle.Alloc(unknownHeaders, GCHandleType.Pinned);
                            pinnedHeaders.Add(gcHandle);
                            pHttpResponse->Response_V1.Headers.pUnknownHeaders = (HttpApi.HTTP_UNKNOWN_HEADER*)gcHandle.AddrOfPinnedObject();
                            pHttpResponse->Response_V1.Headers.UnknownHeaderCount = 0; // to remove the iis header for server=...
                        }

                        for (var index = 0; index < headerValues.Count; index++)
                        {
                            bytes = HeaderEncoding.GetBytes(headerName);
                            unknownHeaders[pHttpResponse->Response_V1.Headers.UnknownHeaderCount].NameLength = (ushort)bytes.Length;
                            gcHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                            pinnedHeaders.Add(gcHandle);
                            unknownHeaders[pHttpResponse->Response_V1.Headers.UnknownHeaderCount].pName = (byte*)gcHandle.AddrOfPinnedObject();

                            headerValue = headerValues[index] ?? string.Empty;
                            bytes = HeaderEncoding.GetBytes(headerValue);
                            unknownHeaders[pHttpResponse->Response_V1.Headers.UnknownHeaderCount].RawValueLength = (ushort)bytes.Length;
                            gcHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                            pinnedHeaders.Add(gcHandle);
                            unknownHeaders[pHttpResponse->Response_V1.Headers.UnknownHeaderCount].pRawValue = (byte*)gcHandle.AddrOfPinnedObject();
                            pHttpResponse->Response_V1.Headers.UnknownHeaderCount++;
                        }
                    }
                    else if (headerPair.Value.Count == 1)
                    {
                        headerValue = headerValues[0] ?? string.Empty;
                        bytes = HeaderEncoding.GetBytes(headerValue);
                        pKnownHeaders[lookup].RawValueLength = (ushort)bytes.Length;
                        gcHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                        pinnedHeaders.Add(gcHandle);
                        pKnownHeaders[lookup].pRawValue = (byte*)gcHandle.AddrOfPinnedObject();
                    }
                    else
                    {
                        // TODO multivalue headers
                    }
                }
            }
            catch (Exception)
            {
                FreePinnedHeaders(pinnedHeaders);
                throw;
            }
            return pinnedHeaders;
        }

        private static void FreePinnedHeaders(List<GCHandle> pinnedHeaders)
        {
            if (pinnedHeaders != null)
            {
                foreach (GCHandle gcHandle in pinnedHeaders)
                {
                    if (gcHandle.IsAllocated)
                    {
                        gcHandle.Free();
                    }
                }
            }
        }

        public void Abort()
        {

        }

        public void StartReadingRequestBody()
        {
            if (_readingTask == null)
            {
                _readingTask = ProcessRequestBody();
            }
        }

        private async Task ProcessRequestBody()
        {
            try
            {
                while (true)
                {
                    // These buffers are pinned
                    var wb = Input.Writer.Alloc(MinAllocBufferSize);
                    _inputHandle = wb.Buffer.Pin();

                    try
                    {
                        int read = await ReadAsync(wb.Buffer.Length);

                        if (read == 0)
                        {
                            break;
                        }

                        wb.Advance(read);
                    }
                    finally
                    {
                        wb.Commit();
                        _inputHandle.Free();
                    }

                    var result = await wb.FlushAsync();

                    if (result.IsCompleted || result.IsCancelled)
                    {
                        break;
                    }
                }

                Input.Writer.Complete();
            }
            catch (Exception ex)
            {
                Input.Writer.Complete(ex);
            }
        }

        public void StartWritingResponseBody()
        {
            if (_writingTask == null)
            {
                _writingTask = ProcessResponseBody();
            }
        }

        private async Task ProcessResponseBody()
        {
            while (true)
            {
                ReadResult result;

                try
                {
                    result = await Output.Reader.ReadAsync();
                }
                catch
                {
                    Output.Reader.Complete();
                    return;
                }

                var buffer = result.Buffer;
                var consumed = buffer.End;

                try
                {
                    if (result.IsCancelled)
                    {
                        break;
                    }

                    if (!HasResponseStarted)
                    {
                        await FlushAsync(CancellationToken.None);
                    }

                    if (!buffer.IsEmpty)
                    {
                        await WriteAsync(buffer);
                    }
                    else if (result.IsCompleted)
                    {
                        break;
                    }
                }
                finally
                {
                    Output.Reader.Advance(consumed);
                }
            }
            Output.Reader.Complete();
        }

        private unsafe IISAwaitable WriteAsync(ReadableBuffer buffer)
        {
            var fCompletionExpected = false;
            var hr = 0;

            if (!buffer.IsSingleSpan)
            {
                // TODO: Handle mutiple buffers (in a single write)
                var copy = buffer.ToArray();
                fixed (byte* pBuffer = &copy[0])
                {
                    hr = NativeMethods.http_write_response_bytes(_pHttpContext, pBuffer, buffer.Length, IISAwaitable.WriteCallback, (IntPtr)_thisHandle, out fCompletionExpected);
                }
            }
            else
            {
                fixed (byte* pBuffer = &buffer.First.Span.DangerousGetPinnableReference())
                {
                    hr = NativeMethods.http_write_response_bytes(_pHttpContext, pBuffer, buffer.Length, IISAwaitable.WriteCallback, (IntPtr)_thisHandle, out fCompletionExpected);
                }
            }

            if (!fCompletionExpected)
            {
                CompleteWrite(hr, cbBytes: 0);
            }

            return _writeOperation;
        }

        private unsafe IISAwaitable ReadAsync(int length)
        {
            var hr = NativeMethods.http_read_request_bytes(
                                _pHttpContext,
                                (byte*)_inputHandle.PinnedPointer,
                                length,
                                IISAwaitable.ReadCallback,
                                (IntPtr)_thisHandle,
                                out var dwReceivedBytes,
                                out var fCompletionExpected);

            if (!fCompletionExpected)
            {
                CompleteRead(hr, dwReceivedBytes);
            }

            return _readOperation;
        }

        public abstract Task ProcessRequestAsync();

        public void OnStarting(Func<object, Task> callback, object state)
        {
            lock (_onStartingSync)
            {
                if (HasResponseStarted)
                {
                    throw new InvalidOperationException("Response already started");
                }

                if (_onStarting == null)
                {
                    _onStarting = new Stack<KeyValuePair<Func<object, Task>, object>>();
                }
                _onStarting.Push(new KeyValuePair<Func<object, Task>, object>(callback, state));
            }
        }

        public void OnCompleted(Func<object, Task> callback, object state)
        {
            lock (_onCompletedSync)
            {
                if (_onCompleted == null)
                {
                    _onCompleted = new Stack<KeyValuePair<Func<object, Task>, object>>();
                }
                _onCompleted.Push(new KeyValuePair<Func<object, Task>, object>(callback, state));
            }
        }

        protected async Task FireOnStarting()
        {
            Stack<KeyValuePair<Func<object, Task>, object>> onStarting = null;
            lock (_onStartingSync)
            {
                onStarting = _onStarting;
                _onStarting = null;
            }
            if (onStarting != null)
            {
                try
                {
                    foreach (var entry in onStarting)
                    {
                        await entry.Key.Invoke(entry.Value);
                    }
                }
                catch (Exception ex)
                {
                    ReportApplicationError(ex);
                }
            }
        }

        protected async Task FireOnCompleted()
        {
            Stack<KeyValuePair<Func<object, Task>, object>> onCompleted = null;
            lock (_onCompletedSync)
            {
                onCompleted = _onCompleted;
                _onCompleted = null;
            }
            if (onCompleted != null)
            {
                foreach (var entry in onCompleted)
                {
                    try
                    {
                        await entry.Key.Invoke(entry.Value);
                    }
                    catch (Exception ex)
                    {
                        ReportApplicationError(ex);
                    }
                }
            }
        }

        protected void ReportApplicationError(Exception ex)
        {
            if (_applicationException == null)
            {
                _applicationException = ex;
            }
            else if (_applicationException is AggregateException)
            {
                _applicationException = new AggregateException(_applicationException, ex).Flatten();
            }
            else
            {
                _applicationException = new AggregateException(_applicationException, ex);
            }
        }

        public void PostCompletion()
        {
            Debug.Assert(!_readOperation.HasContinuation, "Pending read async operation!");
            Debug.Assert(!_writeOperation.HasContinuation, "Pending write async operation!");

            var hr = NativeMethods.http_post_completion(_pHttpContext, 0);

            if (hr != NativeMethods.S_OK)
            {
                throw Marshal.GetExceptionForHR(hr);
            }
        }

        public void IndicateCompletion(NativeMethods.REQUEST_NOTIFICATION_STATUS notificationStatus)
        {
            NativeMethods.http_indicate_completion(_pHttpContext, notificationStatus);
        }

        internal void CompleteWrite(int hr, int cbBytes)
        {
            _writeOperation.Complete(hr, cbBytes);
        }

        internal void CompleteRead(int hr, int cbBytes)
        {
            _readOperation.Complete(hr, cbBytes);
        }

        internal void CompleteFlush(int hr, int cbBytes)
        {
            FreePinnedHeaders(_pinnedHeaders);
            _pinnedHeaders = null;

            _flushOperation.Complete(hr, cbBytes);
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _thisHandle.Free();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
    }
}