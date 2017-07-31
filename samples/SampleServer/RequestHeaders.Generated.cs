﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace SampleServer
{
    public partial class RequestHeaders
    {
        // Tracks if individual fields have been read from native or set directly.
        // Once read or set, their presence in the collection is marked by if their StringValues is null or not.
        private UInt32 _flag0, _flag1;

        private StringValues _Accept;
        private StringValues _AcceptCharset;
        private StringValues _AcceptEncoding;
        private StringValues _AcceptLanguage;
        private StringValues _Allow;
        private StringValues _Authorization;
        private StringValues _CacheControl;
        private StringValues _Connection;
        private StringValues _ContentEncoding;
        private StringValues _ContentLanguage;
        private StringValues _ContentLength;
        private StringValues _ContentLocation;
        private StringValues _ContentMd5;
        private StringValues _ContentRange;
        private StringValues _ContentType;
        private StringValues _Cookie;
        private StringValues _Date;
        private StringValues _Expect;
        private StringValues _Expires;
        private StringValues _From;
        private StringValues _Host;
        private StringValues _IfMatch;
        private StringValues _IfModifiedSince;
        private StringValues _IfNoneMatch;
        private StringValues _IfRange;
        private StringValues _IfUnmodifiedSince;
        private StringValues _KeepAlive;
        private StringValues _LastModified;
        private StringValues _MaxForwards;
        private StringValues _Pragma;
        private StringValues _ProxyAuthorization;
        private StringValues _Range;
        private StringValues _Referer;
        private StringValues _Te;
        private StringValues _Trailer;
        private StringValues _TransferEncoding;
        private StringValues _Translate;
        private StringValues _Upgrade;
        private StringValues _UserAgent;
        private StringValues _Via;
        private StringValues _Warning;

        internal StringValues Accept
        {
            get
            {
                if (!((_flag0 & 0x1u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Accept);
                    if (nativeValue != null)
                    {
                        _Accept = nativeValue;
                    }
                    _flag0 |= 0x1u;
                }
                return _Accept;
            }
            set
            {
                _flag0 |= 0x1u;
                _Accept = value;
            }
        }

        internal StringValues AcceptCharset
        {
            get
            {
                if (!((_flag0 & 0x2u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.AcceptCharset);
                    if (nativeValue != null)
                    {
                        _AcceptCharset = nativeValue;
                    }
                    _flag0 |= 0x2u;
                }
                return _AcceptCharset;
            }
            set
            {
                _flag0 |= 0x2u;
                _AcceptCharset = value;
            }
        }

        internal StringValues AcceptEncoding
        {
            get
            {
                if (!((_flag0 & 0x4u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.AcceptEncoding);
                    if (nativeValue != null)
                    {
                        _AcceptEncoding = nativeValue;
                    }
                    _flag0 |= 0x4u;
                }
                return _AcceptEncoding;
            }
            set
            {
                _flag0 |= 0x4u;
                _AcceptEncoding = value;
            }
        }

        internal StringValues AcceptLanguage
        {
            get
            {
                if (!((_flag0 & 0x8u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.AcceptLanguage);
                    if (nativeValue != null)
                    {
                        _AcceptLanguage = nativeValue;
                    }
                    _flag0 |= 0x8u;
                }
                return _AcceptLanguage;
            }
            set
            {
                _flag0 |= 0x8u;
                _AcceptLanguage = value;
            }
        }

        internal StringValues Allow
        {
            get
            {
                if (!((_flag0 & 0x10u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Allow);
                    if (nativeValue != null)
                    {
                        _Allow = nativeValue;
                    }
                    _flag0 |= 0x10u;
                }
                return _Allow;
            }
            set
            {
                _flag0 |= 0x10u;
                _Allow = value;
            }
        }

        internal StringValues Authorization
        {
            get
            {
                if (!((_flag0 & 0x20u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Authorization);
                    if (nativeValue != null)
                    {
                        _Authorization = nativeValue;
                    }
                    _flag0 |= 0x20u;
                }
                return _Authorization;
            }
            set
            {
                _flag0 |= 0x20u;
                _Authorization = value;
            }
        }

        internal StringValues CacheControl
        {
            get
            {
                if (!((_flag0 & 0x40u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.CacheControl);
                    if (nativeValue != null)
                    {
                        _CacheControl = nativeValue;
                    }
                    _flag0 |= 0x40u;
                }
                return _CacheControl;
            }
            set
            {
                _flag0 |= 0x40u;
                _CacheControl = value;
            }
        }

        internal StringValues Connection
        {
            get
            {
                if (!((_flag0 & 0x80u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Connection);
                    if (nativeValue != null)
                    {
                        _Connection = nativeValue;
                    }
                    _flag0 |= 0x80u;
                }
                return _Connection;
            }
            set
            {
                _flag0 |= 0x80u;
                _Connection = value;
            }
        }

        internal StringValues ContentEncoding
        {
            get
            {
                if (!((_flag0 & 0x100u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.ContentEncoding);
                    if (nativeValue != null)
                    {
                        _ContentEncoding = nativeValue;
                    }
                    _flag0 |= 0x100u;
                }
                return _ContentEncoding;
            }
            set
            {
                _flag0 |= 0x100u;
                _ContentEncoding = value;
            }
        }

        internal StringValues ContentLanguage
        {
            get
            {
                if (!((_flag0 & 0x200u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.ContentLanguage);
                    if (nativeValue != null)
                    {
                        _ContentLanguage = nativeValue;
                    }
                    _flag0 |= 0x200u;
                }
                return _ContentLanguage;
            }
            set
            {
                _flag0 |= 0x200u;
                _ContentLanguage = value;
            }
        }

        internal StringValues ContentLength
        {
            get
            {
                if (!((_flag0 & 0x400u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.ContentLength);
                    if (nativeValue != null)
                    {
                        _ContentLength = nativeValue;
                    }
                    _flag0 |= 0x400u;
                }
                return _ContentLength;
            }
            set
            {
                _flag0 |= 0x400u;
                _ContentLength = value;
            }
        }

        internal StringValues ContentLocation
        {
            get
            {
                if (!((_flag0 & 0x800u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.ContentLocation);
                    if (nativeValue != null)
                    {
                        _ContentLocation = nativeValue;
                    }
                    _flag0 |= 0x800u;
                }
                return _ContentLocation;
            }
            set
            {
                _flag0 |= 0x800u;
                _ContentLocation = value;
            }
        }

        internal StringValues ContentMd5
        {
            get
            {
                if (!((_flag0 & 0x1000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.ContentMd5);
                    if (nativeValue != null)
                    {
                        _ContentMd5 = nativeValue;
                    }
                    _flag0 |= 0x1000u;
                }
                return _ContentMd5;
            }
            set
            {
                _flag0 |= 0x1000u;
                _ContentMd5 = value;
            }
        }

        internal StringValues ContentRange
        {
            get
            {
                if (!((_flag0 & 0x2000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.ContentRange);
                    if (nativeValue != null)
                    {
                        _ContentRange = nativeValue;
                    }
                    _flag0 |= 0x2000u;
                }
                return _ContentRange;
            }
            set
            {
                _flag0 |= 0x2000u;
                _ContentRange = value;
            }
        }

        internal StringValues ContentType
        {
            get
            {
                if (!((_flag0 & 0x4000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.ContentType);
                    if (nativeValue != null)
                    {
                        _ContentType = nativeValue;
                    }
                    _flag0 |= 0x4000u;
                }
                return _ContentType;
            }
            set
            {
                _flag0 |= 0x4000u;
                _ContentType = value;
            }
        }

        internal StringValues Cookie
        {
            get
            {
                if (!((_flag0 & 0x8000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Cookie);
                    if (nativeValue != null)
                    {
                        _Cookie = nativeValue;
                    }
                    _flag0 |= 0x8000u;
                }
                return _Cookie;
            }
            set
            {
                _flag0 |= 0x8000u;
                _Cookie = value;
            }
        }

        internal StringValues Date
        {
            get
            {
                if (!((_flag0 & 0x10000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Date);
                    if (nativeValue != null)
                    {
                        _Date = nativeValue;
                    }
                    _flag0 |= 0x10000u;
                }
                return _Date;
            }
            set
            {
                _flag0 |= 0x10000u;
                _Date = value;
            }
        }

        internal StringValues Expect
        {
            get
            {
                if (!((_flag0 & 0x20000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Expect);
                    if (nativeValue != null)
                    {
                        _Expect = nativeValue;
                    }
                    _flag0 |= 0x20000u;
                }
                return _Expect;
            }
            set
            {
                _flag0 |= 0x20000u;
                _Expect = value;
            }
        }

        internal StringValues Expires
        {
            get
            {
                if (!((_flag0 & 0x40000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Expires);
                    if (nativeValue != null)
                    {
                        _Expires = nativeValue;
                    }
                    _flag0 |= 0x40000u;
                }
                return _Expires;
            }
            set
            {
                _flag0 |= 0x40000u;
                _Expires = value;
            }
        }

        internal StringValues From
        {
            get
            {
                if (!((_flag0 & 0x80000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.From);
                    if (nativeValue != null)
                    {
                        _From = nativeValue;
                    }
                    _flag0 |= 0x80000u;
                }
                return _From;
            }
            set
            {
                _flag0 |= 0x80000u;
                _From = value;
            }
        }

        internal StringValues Host
        {
            get
            {
                if (!((_flag0 & 0x100000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Host);
                    if (nativeValue != null)
                    {
                        _Host = nativeValue;
                    }
                    _flag0 |= 0x100000u;
                }
                return _Host;
            }
            set
            {
                _flag0 |= 0x100000u;
                _Host = value;
            }
        }

        internal StringValues IfMatch
        {
            get
            {
                if (!((_flag0 & 0x200000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.IfMatch);
                    if (nativeValue != null)
                    {
                        _IfMatch = nativeValue;
                    }
                    _flag0 |= 0x200000u;
                }
                return _IfMatch;
            }
            set
            {
                _flag0 |= 0x200000u;
                _IfMatch = value;
            }
        }

        internal StringValues IfModifiedSince
        {
            get
            {
                if (!((_flag0 & 0x400000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.IfModifiedSince);
                    if (nativeValue != null)
                    {
                        _IfModifiedSince = nativeValue;
                    }
                    _flag0 |= 0x400000u;
                }
                return _IfModifiedSince;
            }
            set
            {
                _flag0 |= 0x400000u;
                _IfModifiedSince = value;
            }
        }

        internal StringValues IfNoneMatch
        {
            get
            {
                if (!((_flag0 & 0x800000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.IfNoneMatch);
                    if (nativeValue != null)
                    {
                        _IfNoneMatch = nativeValue;
                    }
                    _flag0 |= 0x800000u;
                }
                return _IfNoneMatch;
            }
            set
            {
                _flag0 |= 0x800000u;
                _IfNoneMatch = value;
            }
        }

        internal StringValues IfRange
        {
            get
            {
                if (!((_flag0 & 0x1000000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.IfRange);
                    if (nativeValue != null)
                    {
                        _IfRange = nativeValue;
                    }
                    _flag0 |= 0x1000000u;
                }
                return _IfRange;
            }
            set
            {
                _flag0 |= 0x1000000u;
                _IfRange = value;
            }
        }

        internal StringValues IfUnmodifiedSince
        {
            get
            {
                if (!((_flag0 & 0x2000000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.IfUnmodifiedSince);
                    if (nativeValue != null)
                    {
                        _IfUnmodifiedSince = nativeValue;
                    }
                    _flag0 |= 0x2000000u;
                }
                return _IfUnmodifiedSince;
            }
            set
            {
                _flag0 |= 0x2000000u;
                _IfUnmodifiedSince = value;
            }
        }

        internal StringValues KeepAlive
        {
            get
            {
                if (!((_flag0 & 0x4000000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.KeepAlive);
                    if (nativeValue != null)
                    {
                        _KeepAlive = nativeValue;
                    }
                    _flag0 |= 0x4000000u;
                }
                return _KeepAlive;
            }
            set
            {
                _flag0 |= 0x4000000u;
                _KeepAlive = value;
            }
        }

        internal StringValues LastModified
        {
            get
            {
                if (!((_flag0 & 0x8000000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.LastModified);
                    if (nativeValue != null)
                    {
                        _LastModified = nativeValue;
                    }
                    _flag0 |= 0x8000000u;
                }
                return _LastModified;
            }
            set
            {
                _flag0 |= 0x8000000u;
                _LastModified = value;
            }
        }

        internal StringValues MaxForwards
        {
            get
            {
                if (!((_flag0 & 0x10000000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.MaxForwards);
                    if (nativeValue != null)
                    {
                        _MaxForwards = nativeValue;
                    }
                    _flag0 |= 0x10000000u;
                }
                return _MaxForwards;
            }
            set
            {
                _flag0 |= 0x10000000u;
                _MaxForwards = value;
            }
        }

        internal StringValues Pragma
        {
            get
            {
                if (!((_flag0 & 0x20000000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Pragma);
                    if (nativeValue != null)
                    {
                        _Pragma = nativeValue;
                    }
                    _flag0 |= 0x20000000u;
                }
                return _Pragma;
            }
            set
            {
                _flag0 |= 0x20000000u;
                _Pragma = value;
            }
        }

        internal StringValues ProxyAuthorization
        {
            get
            {
                if (!((_flag0 & 0x40000000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.ProxyAuthorization);
                    if (nativeValue != null)
                    {
                        _ProxyAuthorization = nativeValue;
                    }
                    _flag0 |= 0x40000000u;
                }
                return _ProxyAuthorization;
            }
            set
            {
                _flag0 |= 0x40000000u;
                _ProxyAuthorization = value;
            }
        }

        internal StringValues Range
        {
            get
            {
                if (!((_flag0 & 0x80000000u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Range);
                    if (nativeValue != null)
                    {
                        _Range = nativeValue;
                    }
                    _flag0 |= 0x80000000u;
                }
                return _Range;
            }
            set
            {
                _flag0 |= 0x80000000u;
                _Range = value;
            }
        }

        internal StringValues Referer
        {
            get
            {
                if (!((_flag1 & 0x1u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Referer);
                    if (nativeValue != null)
                    {
                        _Referer = nativeValue;
                    }
                    _flag1 |= 0x1u;
                }
                return _Referer;
            }
            set
            {
                _flag1 |= 0x1u;
                _Referer = value;
            }
        }

        internal StringValues Te
        {
            get
            {
                if (!((_flag1 & 0x2u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Te);
                    if (nativeValue != null)
                    {
                        _Te = nativeValue;
                    }
                    _flag1 |= 0x2u;
                }
                return _Te;
            }
            set
            {
                _flag1 |= 0x2u;
                _Te = value;
            }
        }

        internal StringValues Trailer
        {
            get
            {
                if (!((_flag1 & 0x4u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Trailer);
                    if (nativeValue != null)
                    {
                        _Trailer = nativeValue;
                    }
                    _flag1 |= 0x4u;
                }
                return _Trailer;
            }
            set
            {
                _flag1 |= 0x4u;
                _Trailer = value;
            }
        }

        internal StringValues TransferEncoding
        {
            get
            {
                if (!((_flag1 & 0x8u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.TransferEncoding);
                    if (nativeValue != null)
                    {
                        _TransferEncoding = nativeValue;
                    }
                    _flag1 |= 0x8u;
                }
                return _TransferEncoding;
            }
            set
            {
                _flag1 |= 0x8u;
                _TransferEncoding = value;
            }
        }

        internal StringValues Translate
        {
            get
            {
                if (!((_flag1 & 0x10u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Translate);
                    if (nativeValue != null)
                    {
                        _Translate = nativeValue;
                    }
                    _flag1 |= 0x10u;
                }
                return _Translate;
            }
            set
            {
                _flag1 |= 0x10u;
                _Translate = value;
            }
        }

        internal StringValues Upgrade
        {
            get
            {
                if (!((_flag1 & 0x20u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Upgrade);
                    if (nativeValue != null)
                    {
                        _Upgrade = nativeValue;
                    }
                    _flag1 |= 0x20u;
                }
                return _Upgrade;
            }
            set
            {
                _flag1 |= 0x20u;
                _Upgrade = value;
            }
        }

        internal StringValues UserAgent
        {
            get
            {
                if (!((_flag1 & 0x40u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.UserAgent);
                    if (nativeValue != null)
                    {
                        _UserAgent = nativeValue;
                    }
                    _flag1 |= 0x40u;
                }
                return _UserAgent;
            }
            set
            {
                _flag1 |= 0x40u;
                _UserAgent = value;
            }
        }

        internal StringValues Via
        {
            get
            {
                if (!((_flag1 & 0x80u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Via);
                    if (nativeValue != null)
                    {
                        _Via = nativeValue;
                    }
                    _flag1 |= 0x80u;
                }
                return _Via;
            }
            set
            {
                _flag1 |= 0x80u;
                _Via = value;
            }
        }

        internal StringValues Warning
        {
            get
            {
                if (!((_flag1 & 0x100u) != 0))
                {
                    string nativeValue = GetKnownHeader(HttpSysRequestHeader.Warning);
                    if (nativeValue != null)
                    {
                        _Warning = nativeValue;
                    }
                    _flag1 |= 0x100u;
                }
                return _Warning;
            }
            set
            {
                _flag1 |= 0x100u;
                _Warning = value;
            }
        }

        private bool PropertiesContainsKey(string key)
        {
            switch (key.Length)
            {
                case 2:
                    if (string.Equals(key, "Te", StringComparison.OrdinalIgnoreCase))
                    {
                        return Te.Count > 0;
                    }
                    break;
                case 3:
                    if (string.Equals(key, "Via", StringComparison.OrdinalIgnoreCase))
                    {
                        return Via.Count > 0;
                    }
                    break;
                case 4:
                    if (string.Equals(key, "Date", StringComparison.OrdinalIgnoreCase))
                    {
                        return Date.Count > 0;
                    }
                    if (string.Equals(key, "From", StringComparison.OrdinalIgnoreCase))
                    {
                        return From.Count > 0;
                    }
                    if (string.Equals(key, "Host", StringComparison.OrdinalIgnoreCase))
                    {
                        return Host.Count > 0;
                    }
                    break;
                case 5:
                    if (string.Equals(key, "Allow", StringComparison.OrdinalIgnoreCase))
                    {
                        return Allow.Count > 0;
                    }
                    if (string.Equals(key, "Range", StringComparison.OrdinalIgnoreCase))
                    {
                        return Range.Count > 0;
                    }
                    break;
                case 6:
                    if (string.Equals(key, "Accept", StringComparison.OrdinalIgnoreCase))
                    {
                        return Accept.Count > 0;
                    }
                    if (string.Equals(key, "Cookie", StringComparison.OrdinalIgnoreCase))
                    {
                        return Cookie.Count > 0;
                    }
                    if (string.Equals(key, "Expect", StringComparison.OrdinalIgnoreCase))
                    {
                        return Expect.Count > 0;
                    }
                    if (string.Equals(key, "Pragma", StringComparison.OrdinalIgnoreCase))
                    {
                        return Pragma.Count > 0;
                    }
                    break;
                case 7:
                    if (string.Equals(key, "Expires", StringComparison.OrdinalIgnoreCase))
                    {
                        return Expires.Count > 0;
                    }
                    if (string.Equals(key, "Referer", StringComparison.OrdinalIgnoreCase))
                    {
                        return Referer.Count > 0;
                    }
                    if (string.Equals(key, "Trailer", StringComparison.OrdinalIgnoreCase))
                    {
                        return Trailer.Count > 0;
                    }
                    if (string.Equals(key, "Upgrade", StringComparison.OrdinalIgnoreCase))
                    {
                        return Upgrade.Count > 0;
                    }
                    if (string.Equals(key, "Warning", StringComparison.OrdinalIgnoreCase))
                    {
                        return Warning.Count > 0;
                    }
                    break;
                case 8:
                    if (string.Equals(key, "If-Match", StringComparison.OrdinalIgnoreCase))
                    {
                        return IfMatch.Count > 0;
                    }
                    if (string.Equals(key, "If-Range", StringComparison.OrdinalIgnoreCase))
                    {
                        return IfRange.Count > 0;
                    }
                    break;
                case 9:
                    if (string.Equals(key, "Translate", StringComparison.OrdinalIgnoreCase))
                    {
                        return Translate.Count > 0;
                    }
                    break;
                case 10:
                    if (string.Equals(key, "Connection", StringComparison.OrdinalIgnoreCase))
                    {
                        return Connection.Count > 0;
                    }
                    if (string.Equals(key, "Keep-Alive", StringComparison.OrdinalIgnoreCase))
                    {
                        return KeepAlive.Count > 0;
                    }
                    if (string.Equals(key, "User-Agent", StringComparison.OrdinalIgnoreCase))
                    {
                        return UserAgent.Count > 0;
                    }
                    break;
                case 11:
                    if (string.Equals(key, "Content-Md5", StringComparison.OrdinalIgnoreCase))
                    {
                        return ContentMd5.Count > 0;
                    }
                    break;
                case 12:
                    if (string.Equals(key, "Content-Type", StringComparison.OrdinalIgnoreCase))
                    {
                        return ContentType.Count > 0;
                    }
                    if (string.Equals(key, "Max-Forwards", StringComparison.OrdinalIgnoreCase))
                    {
                        return MaxForwards.Count > 0;
                    }
                    break;
                case 13:
                    if (string.Equals(key, "Authorization", StringComparison.OrdinalIgnoreCase))
                    {
                        return Authorization.Count > 0;
                    }
                    if (string.Equals(key, "Cache-Control", StringComparison.OrdinalIgnoreCase))
                    {
                        return CacheControl.Count > 0;
                    }
                    if (string.Equals(key, "Content-Range", StringComparison.OrdinalIgnoreCase))
                    {
                        return ContentRange.Count > 0;
                    }
                    if (string.Equals(key, "If-None-Match", StringComparison.OrdinalIgnoreCase))
                    {
                        return IfNoneMatch.Count > 0;
                    }
                    if (string.Equals(key, "Last-Modified", StringComparison.OrdinalIgnoreCase))
                    {
                        return LastModified.Count > 0;
                    }
                    break;
                case 14:
                    if (string.Equals(key, "Accept-Charset", StringComparison.OrdinalIgnoreCase))
                    {
                        return AcceptCharset.Count > 0;
                    }
                    if (string.Equals(key, "Content-Length", StringComparison.OrdinalIgnoreCase))
                    {
                        return ContentLength.Count > 0;
                    }
                    break;
                case 15:
                    if (string.Equals(key, "Accept-Encoding", StringComparison.OrdinalIgnoreCase))
                    {
                        return AcceptEncoding.Count > 0;
                    }
                    if (string.Equals(key, "Accept-Language", StringComparison.OrdinalIgnoreCase))
                    {
                        return AcceptLanguage.Count > 0;
                    }
                    break;
                case 16:
                    if (string.Equals(key, "Content-Encoding", StringComparison.OrdinalIgnoreCase))
                    {
                        return ContentEncoding.Count > 0;
                    }
                    if (string.Equals(key, "Content-Language", StringComparison.OrdinalIgnoreCase))
                    {
                        return ContentLanguage.Count > 0;
                    }
                    if (string.Equals(key, "Content-Location", StringComparison.OrdinalIgnoreCase))
                    {
                        return ContentLocation.Count > 0;
                    }
                    break;
                case 17:
                    if (string.Equals(key, "If-Modified-Since", StringComparison.OrdinalIgnoreCase))
                    {
                        return IfModifiedSince.Count > 0;
                    }
                    if (string.Equals(key, "Transfer-Encoding", StringComparison.OrdinalIgnoreCase))
                    {
                        return TransferEncoding.Count > 0;
                    }
                    break;
                case 19:
                    if (string.Equals(key, "If-Unmodified-Since", StringComparison.OrdinalIgnoreCase))
                    {
                        return IfUnmodifiedSince.Count > 0;
                    }
                    if (string.Equals(key, "Proxy-Authorization", StringComparison.OrdinalIgnoreCase))
                    {
                        return ProxyAuthorization.Count > 0;
                    }
                    break;
            }
            return false;
        }

        private bool PropertiesTryGetValue(string key, out StringValues value)
        {
            switch (key.Length)
            {
                case 2:
                    if (string.Equals(key, "Te", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Te;
                        return value.Count > 0;
                    }
                    break;
                case 3:
                    if (string.Equals(key, "Via", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Via;
                        return value.Count > 0;
                    }
                    break;
                case 4:
                    if (string.Equals(key, "Date", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Date;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "From", StringComparison.OrdinalIgnoreCase))
                    {
                        value = From;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Host", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Host;
                        return value.Count > 0;
                    }
                    break;
                case 5:
                    if (string.Equals(key, "Allow", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Allow;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Range", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Range;
                        return value.Count > 0;
                    }
                    break;
                case 6:
                    if (string.Equals(key, "Accept", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Accept;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Cookie", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Cookie;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Expect", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Expect;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Pragma", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Pragma;
                        return value.Count > 0;
                    }
                    break;
                case 7:
                    if (string.Equals(key, "Expires", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Expires;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Referer", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Referer;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Trailer", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Trailer;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Upgrade", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Upgrade;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Warning", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Warning;
                        return value.Count > 0;
                    }
                    break;
                case 8:
                    if (string.Equals(key, "If-Match", StringComparison.OrdinalIgnoreCase))
                    {
                        value = IfMatch;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "If-Range", StringComparison.OrdinalIgnoreCase))
                    {
                        value = IfRange;
                        return value.Count > 0;
                    }
                    break;
                case 9:
                    if (string.Equals(key, "Translate", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Translate;
                        return value.Count > 0;
                    }
                    break;
                case 10:
                    if (string.Equals(key, "Connection", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Connection;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Keep-Alive", StringComparison.OrdinalIgnoreCase))
                    {
                        value = KeepAlive;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "User-Agent", StringComparison.OrdinalIgnoreCase))
                    {
                        value = UserAgent;
                        return value.Count > 0;
                    }
                    break;
                case 11:
                    if (string.Equals(key, "Content-Md5", StringComparison.OrdinalIgnoreCase))
                    {
                        value = ContentMd5;
                        return value.Count > 0;
                    }
                    break;
                case 12:
                    if (string.Equals(key, "Content-Type", StringComparison.OrdinalIgnoreCase))
                    {
                        value = ContentType;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Max-Forwards", StringComparison.OrdinalIgnoreCase))
                    {
                        value = MaxForwards;
                        return value.Count > 0;
                    }
                    break;
                case 13:
                    if (string.Equals(key, "Authorization", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Authorization;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Cache-Control", StringComparison.OrdinalIgnoreCase))
                    {
                        value = CacheControl;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Content-Range", StringComparison.OrdinalIgnoreCase))
                    {
                        value = ContentRange;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "If-None-Match", StringComparison.OrdinalIgnoreCase))
                    {
                        value = IfNoneMatch;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Last-Modified", StringComparison.OrdinalIgnoreCase))
                    {
                        value = LastModified;
                        return value.Count > 0;
                    }
                    break;
                case 14:
                    if (string.Equals(key, "Accept-Charset", StringComparison.OrdinalIgnoreCase))
                    {
                        value = AcceptCharset;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Content-Length", StringComparison.OrdinalIgnoreCase))
                    {
                        value = ContentLength;
                        return value.Count > 0;
                    }
                    break;
                case 15:
                    if (string.Equals(key, "Accept-Encoding", StringComparison.OrdinalIgnoreCase))
                    {
                        value = AcceptEncoding;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Accept-Language", StringComparison.OrdinalIgnoreCase))
                    {
                        value = AcceptLanguage;
                        return value.Count > 0;
                    }
                    break;
                case 16:
                    if (string.Equals(key, "Content-Encoding", StringComparison.OrdinalIgnoreCase))
                    {
                        value = ContentEncoding;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Content-Language", StringComparison.OrdinalIgnoreCase))
                    {
                        value = ContentLanguage;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Content-Location", StringComparison.OrdinalIgnoreCase))
                    {
                        value = ContentLocation;
                        return value.Count > 0;
                    }
                    break;
                case 17:
                    if (string.Equals(key, "If-Modified-Since", StringComparison.OrdinalIgnoreCase))
                    {
                        value = IfModifiedSince;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Transfer-Encoding", StringComparison.OrdinalIgnoreCase))
                    {
                        value = TransferEncoding;
                        return value.Count > 0;
                    }
                    break;
                case 19:
                    if (string.Equals(key, "If-Unmodified-Since", StringComparison.OrdinalIgnoreCase))
                    {
                        value = IfUnmodifiedSince;
                        return value.Count > 0;
                    }
                    if (string.Equals(key, "Proxy-Authorization", StringComparison.OrdinalIgnoreCase))
                    {
                        value = ProxyAuthorization;
                        return value.Count > 0;
                    }
                    break;
            }
            value = StringValues.Empty;
            return false;
        }

        private bool PropertiesTrySetValue(string key, StringValues value)
        {
            switch (key.Length)
            {
                case 2:
                    if (string.Equals(key, "Te", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag1 |= 0x2u;
                        Te = value;
                        return true;
                    }
                    break;
                case 3:
                    if (string.Equals(key, "Via", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag1 |= 0x80u;
                        Via = value;
                        return true;
                    }
                    break;
                case 4:
                    if (string.Equals(key, "Date", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x10000u;
                        Date = value;
                        return true;
                    }
                    if (string.Equals(key, "From", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x80000u;
                        From = value;
                        return true;
                    }
                    if (string.Equals(key, "Host", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x100000u;
                        Host = value;
                        return true;
                    }
                    break;
                case 5:
                    if (string.Equals(key, "Allow", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x10u;
                        Allow = value;
                        return true;
                    }
                    if (string.Equals(key, "Range", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x80000000u;
                        Range = value;
                        return true;
                    }
                    break;
                case 6:
                    if (string.Equals(key, "Accept", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x1u;
                        Accept = value;
                        return true;
                    }
                    if (string.Equals(key, "Cookie", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x8000u;
                        Cookie = value;
                        return true;
                    }
                    if (string.Equals(key, "Expect", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x20000u;
                        Expect = value;
                        return true;
                    }
                    if (string.Equals(key, "Pragma", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x20000000u;
                        Pragma = value;
                        return true;
                    }
                    break;
                case 7:
                    if (string.Equals(key, "Expires", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x40000u;
                        Expires = value;
                        return true;
                    }
                    if (string.Equals(key, "Referer", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag1 |= 0x1u;
                        Referer = value;
                        return true;
                    }
                    if (string.Equals(key, "Trailer", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag1 |= 0x4u;
                        Trailer = value;
                        return true;
                    }
                    if (string.Equals(key, "Upgrade", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag1 |= 0x20u;
                        Upgrade = value;
                        return true;
                    }
                    if (string.Equals(key, "Warning", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag1 |= 0x100u;
                        Warning = value;
                        return true;
                    }
                    break;
                case 8:
                    if (string.Equals(key, "If-Match", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x200000u;
                        IfMatch = value;
                        return true;
                    }
                    if (string.Equals(key, "If-Range", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x1000000u;
                        IfRange = value;
                        return true;
                    }
                    break;
                case 9:
                    if (string.Equals(key, "Translate", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag1 |= 0x10u;
                        Translate = value;
                        return true;
                    }
                    break;
                case 10:
                    if (string.Equals(key, "Connection", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x80u;
                        Connection = value;
                        return true;
                    }
                    if (string.Equals(key, "Keep-Alive", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x4000000u;
                        KeepAlive = value;
                        return true;
                    }
                    if (string.Equals(key, "User-Agent", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag1 |= 0x40u;
                        UserAgent = value;
                        return true;
                    }
                    break;
                case 11:
                    if (string.Equals(key, "Content-Md5", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x1000u;
                        ContentMd5 = value;
                        return true;
                    }
                    break;
                case 12:
                    if (string.Equals(key, "Content-Type", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x4000u;
                        ContentType = value;
                        return true;
                    }
                    if (string.Equals(key, "Max-Forwards", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x10000000u;
                        MaxForwards = value;
                        return true;
                    }
                    break;
                case 13:
                    if (string.Equals(key, "Authorization", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x20u;
                        Authorization = value;
                        return true;
                    }
                    if (string.Equals(key, "Cache-Control", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x40u;
                        CacheControl = value;
                        return true;
                    }
                    if (string.Equals(key, "Content-Range", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x2000u;
                        ContentRange = value;
                        return true;
                    }
                    if (string.Equals(key, "If-None-Match", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x800000u;
                        IfNoneMatch = value;
                        return true;
                    }
                    if (string.Equals(key, "Last-Modified", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x8000000u;
                        LastModified = value;
                        return true;
                    }
                    break;
                case 14:
                    if (string.Equals(key, "Accept-Charset", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x2u;
                        AcceptCharset = value;
                        return true;
                    }
                    if (string.Equals(key, "Content-Length", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x400u;
                        ContentLength = value;
                        return true;
                    }
                    break;
                case 15:
                    if (string.Equals(key, "Accept-Encoding", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x4u;
                        AcceptEncoding = value;
                        return true;
                    }
                    if (string.Equals(key, "Accept-Language", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x8u;
                        AcceptLanguage = value;
                        return true;
                    }
                    break;
                case 16:
                    if (string.Equals(key, "Content-Encoding", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x100u;
                        ContentEncoding = value;
                        return true;
                    }
                    if (string.Equals(key, "Content-Language", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x200u;
                        ContentLanguage = value;
                        return true;
                    }
                    if (string.Equals(key, "Content-Location", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x800u;
                        ContentLocation = value;
                        return true;
                    }
                    break;
                case 17:
                    if (string.Equals(key, "If-Modified-Since", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x400000u;
                        IfModifiedSince = value;
                        return true;
                    }
                    if (string.Equals(key, "Transfer-Encoding", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag1 |= 0x8u;
                        TransferEncoding = value;
                        return true;
                    }
                    break;
                case 19:
                    if (string.Equals(key, "If-Unmodified-Since", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x2000000u;
                        IfUnmodifiedSince = value;
                        return true;
                    }
                    if (string.Equals(key, "Proxy-Authorization", StringComparison.OrdinalIgnoreCase))
                    {
                        _flag0 |= 0x40000000u;
                        ProxyAuthorization = value;
                        return true;
                    }
                    break;
            }
            return false;
        }

        private bool PropertiesTryRemove(string key)
        {
            switch (key.Length)
            {
                case 2:
                    if (_Te.Count > 0
                        && string.Equals(key, "Te", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag1 & 0x2u) != 0);
                        Te = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 3:
                    if (_Via.Count > 0
                        && string.Equals(key, "Via", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag1 & 0x80u) != 0);
                        Via = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 4:
                    if (_Date.Count > 0
                        && string.Equals(key, "Date", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x10000u) != 0);
                        Date = StringValues.Empty;
                        return wasSet;
                    }
                    if (_From.Count > 0
                        && string.Equals(key, "From", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x80000u) != 0);
                        From = StringValues.Empty;
                        return wasSet;
                    }
                    if (_Host.Count > 0
                        && string.Equals(key, "Host", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x100000u) != 0);
                        Host = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 5:
                    if (_Allow.Count > 0
                        && string.Equals(key, "Allow", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x10u) != 0);
                        Allow = StringValues.Empty;
                        return wasSet;
                    }
                    if (_Range.Count > 0
                        && string.Equals(key, "Range", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x80000000u) != 0);
                        Range = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 6:
                    if (_Accept.Count > 0
                        && string.Equals(key, "Accept", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x1u) != 0);
                        Accept = StringValues.Empty;
                        return wasSet;
                    }
                    if (_Cookie.Count > 0
                        && string.Equals(key, "Cookie", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x8000u) != 0);
                        Cookie = StringValues.Empty;
                        return wasSet;
                    }
                    if (_Expect.Count > 0
                        && string.Equals(key, "Expect", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x20000u) != 0);
                        Expect = StringValues.Empty;
                        return wasSet;
                    }
                    if (_Pragma.Count > 0
                        && string.Equals(key, "Pragma", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x20000000u) != 0);
                        Pragma = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 7:
                    if (_Expires.Count > 0
                        && string.Equals(key, "Expires", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x40000u) != 0);
                        Expires = StringValues.Empty;
                        return wasSet;
                    }
                    if (_Referer.Count > 0
                        && string.Equals(key, "Referer", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag1 & 0x1u) != 0);
                        Referer = StringValues.Empty;
                        return wasSet;
                    }
                    if (_Trailer.Count > 0
                        && string.Equals(key, "Trailer", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag1 & 0x4u) != 0);
                        Trailer = StringValues.Empty;
                        return wasSet;
                    }
                    if (_Upgrade.Count > 0
                        && string.Equals(key, "Upgrade", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag1 & 0x20u) != 0);
                        Upgrade = StringValues.Empty;
                        return wasSet;
                    }
                    if (_Warning.Count > 0
                        && string.Equals(key, "Warning", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag1 & 0x100u) != 0);
                        Warning = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 8:
                    if (_IfMatch.Count > 0
                        && string.Equals(key, "If-Match", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x200000u) != 0);
                        IfMatch = StringValues.Empty;
                        return wasSet;
                    }
                    if (_IfRange.Count > 0
                        && string.Equals(key, "If-Range", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x1000000u) != 0);
                        IfRange = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 9:
                    if (_Translate.Count > 0
                        && string.Equals(key, "Translate", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag1 & 0x10u) != 0);
                        Translate = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 10:
                    if (_Connection.Count > 0
                        && string.Equals(key, "Connection", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x80u) != 0);
                        Connection = StringValues.Empty;
                        return wasSet;
                    }
                    if (_KeepAlive.Count > 0
                        && string.Equals(key, "Keep-Alive", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x4000000u) != 0);
                        KeepAlive = StringValues.Empty;
                        return wasSet;
                    }
                    if (_UserAgent.Count > 0
                        && string.Equals(key, "User-Agent", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag1 & 0x40u) != 0);
                        UserAgent = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 11:
                    if (_ContentMd5.Count > 0
                        && string.Equals(key, "Content-Md5", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x1000u) != 0);
                        ContentMd5 = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 12:
                    if (_ContentType.Count > 0
                        && string.Equals(key, "Content-Type", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x4000u) != 0);
                        ContentType = StringValues.Empty;
                        return wasSet;
                    }
                    if (_MaxForwards.Count > 0
                        && string.Equals(key, "Max-Forwards", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x10000000u) != 0);
                        MaxForwards = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 13:
                    if (_Authorization.Count > 0
                        && string.Equals(key, "Authorization", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x20u) != 0);
                        Authorization = StringValues.Empty;
                        return wasSet;
                    }
                    if (_CacheControl.Count > 0
                        && string.Equals(key, "Cache-Control", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x40u) != 0);
                        CacheControl = StringValues.Empty;
                        return wasSet;
                    }
                    if (_ContentRange.Count > 0
                        && string.Equals(key, "Content-Range", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x2000u) != 0);
                        ContentRange = StringValues.Empty;
                        return wasSet;
                    }
                    if (_IfNoneMatch.Count > 0
                        && string.Equals(key, "If-None-Match", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x800000u) != 0);
                        IfNoneMatch = StringValues.Empty;
                        return wasSet;
                    }
                    if (_LastModified.Count > 0
                        && string.Equals(key, "Last-Modified", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x8000000u) != 0);
                        LastModified = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 14:
                    if (_AcceptCharset.Count > 0
                        && string.Equals(key, "Accept-Charset", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x2u) != 0);
                        AcceptCharset = StringValues.Empty;
                        return wasSet;
                    }
                    if (_ContentLength.Count > 0
                        && string.Equals(key, "Content-Length", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x400u) != 0);
                        ContentLength = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 15:
                    if (_AcceptEncoding.Count > 0
                        && string.Equals(key, "Accept-Encoding", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x4u) != 0);
                        AcceptEncoding = StringValues.Empty;
                        return wasSet;
                    }
                    if (_AcceptLanguage.Count > 0
                        && string.Equals(key, "Accept-Language", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x8u) != 0);
                        AcceptLanguage = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 16:
                    if (_ContentEncoding.Count > 0
                        && string.Equals(key, "Content-Encoding", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x100u) != 0);
                        ContentEncoding = StringValues.Empty;
                        return wasSet;
                    }
                    if (_ContentLanguage.Count > 0
                        && string.Equals(key, "Content-Language", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x200u) != 0);
                        ContentLanguage = StringValues.Empty;
                        return wasSet;
                    }
                    if (_ContentLocation.Count > 0
                        && string.Equals(key, "Content-Location", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x800u) != 0);
                        ContentLocation = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 17:
                    if (_IfModifiedSince.Count > 0
                        && string.Equals(key, "If-Modified-Since", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x400000u) != 0);
                        IfModifiedSince = StringValues.Empty;
                        return wasSet;
                    }
                    if (_TransferEncoding.Count > 0
                        && string.Equals(key, "Transfer-Encoding", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag1 & 0x8u) != 0);
                        TransferEncoding = StringValues.Empty;
                        return wasSet;
                    }
                    break;
                case 19:
                    if (_IfUnmodifiedSince.Count > 0
                        && string.Equals(key, "If-Unmodified-Since", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x2000000u) != 0);
                        IfUnmodifiedSince = StringValues.Empty;
                        return wasSet;
                    }
                    if (_ProxyAuthorization.Count > 0
                        && string.Equals(key, "Proxy-Authorization", StringComparison.Ordinal))
                    {
                        bool wasSet = ((_flag0 & 0x40000000u) != 0);
                        ProxyAuthorization = StringValues.Empty;
                        return wasSet;
                    }
                    break;
            }
            return false;
        }

        private IEnumerable<string> PropertiesKeys()
        {
            if (Accept.Count > 0)
            {
                yield return "Accept";
            }
            if (AcceptCharset.Count > 0)
            {
                yield return "Accept-Charset";
            }
            if (AcceptEncoding.Count > 0)
            {
                yield return "Accept-Encoding";
            }
            if (AcceptLanguage.Count > 0)
            {
                yield return "Accept-Language";
            }
            if (Allow.Count > 0)
            {
                yield return "Allow";
            }
            if (Authorization.Count > 0)
            {
                yield return "Authorization";
            }
            if (CacheControl.Count > 0)
            {
                yield return "Cache-Control";
            }
            if (Connection.Count > 0)
            {
                yield return "Connection";
            }
            if (ContentEncoding.Count > 0)
            {
                yield return "Content-Encoding";
            }
            if (ContentLanguage.Count > 0)
            {
                yield return "Content-Language";
            }
            if (ContentLength.Count > 0)
            {
                yield return "Content-Length";
            }
            if (ContentLocation.Count > 0)
            {
                yield return "Content-Location";
            }
            if (ContentMd5.Count > 0)
            {
                yield return "Content-Md5";
            }
            if (ContentRange.Count > 0)
            {
                yield return "Content-Range";
            }
            if (ContentType.Count > 0)
            {
                yield return "Content-Type";
            }
            if (Cookie.Count > 0)
            {
                yield return "Cookie";
            }
            if (Date.Count > 0)
            {
                yield return "Date";
            }
            if (Expect.Count > 0)
            {
                yield return "Expect";
            }
            if (Expires.Count > 0)
            {
                yield return "Expires";
            }
            if (From.Count > 0)
            {
                yield return "From";
            }
            if (Host.Count > 0)
            {
                yield return "Host";
            }
            if (IfMatch.Count > 0)
            {
                yield return "If-Match";
            }
            if (IfModifiedSince.Count > 0)
            {
                yield return "If-Modified-Since";
            }
            if (IfNoneMatch.Count > 0)
            {
                yield return "If-None-Match";
            }
            if (IfRange.Count > 0)
            {
                yield return "If-Range";
            }
            if (IfUnmodifiedSince.Count > 0)
            {
                yield return "If-Unmodified-Since";
            }
            if (KeepAlive.Count > 0)
            {
                yield return "Keep-Alive";
            }
            if (LastModified.Count > 0)
            {
                yield return "Last-Modified";
            }
            if (MaxForwards.Count > 0)
            {
                yield return "Max-Forwards";
            }
            if (Pragma.Count > 0)
            {
                yield return "Pragma";
            }
            if (ProxyAuthorization.Count > 0)
            {
                yield return "Proxy-Authorization";
            }
            if (Range.Count > 0)
            {
                yield return "Range";
            }
            if (Referer.Count > 0)
            {
                yield return "Referer";
            }
            if (Te.Count > 0)
            {
                yield return "Te";
            }
            if (Trailer.Count > 0)
            {
                yield return "Trailer";
            }
            if (TransferEncoding.Count > 0)
            {
                yield return "Transfer-Encoding";
            }
            if (Translate.Count > 0)
            {
                yield return "Translate";
            }
            if (Upgrade.Count > 0)
            {
                yield return "Upgrade";
            }
            if (UserAgent.Count > 0)
            {
                yield return "User-Agent";
            }
            if (Via.Count > 0)
            {
                yield return "Via";
            }
            if (Warning.Count > 0)
            {
                yield return "Warning";
            }
        }

        private IEnumerable<StringValues> PropertiesValues()
        {
            if (Accept.Count > 0)
            {
                yield return Accept;
            }
            if (AcceptCharset.Count > 0)
            {
                yield return AcceptCharset;
            }
            if (AcceptEncoding.Count > 0)
            {
                yield return AcceptEncoding;
            }
            if (AcceptLanguage.Count > 0)
            {
                yield return AcceptLanguage;
            }
            if (Allow.Count > 0)
            {
                yield return Allow;
            }
            if (Authorization.Count > 0)
            {
                yield return Authorization;
            }
            if (CacheControl.Count > 0)
            {
                yield return CacheControl;
            }
            if (Connection.Count > 0)
            {
                yield return Connection;
            }
            if (ContentEncoding.Count > 0)
            {
                yield return ContentEncoding;
            }
            if (ContentLanguage.Count > 0)
            {
                yield return ContentLanguage;
            }
            if (ContentLength.Count > 0)
            {
                yield return ContentLength;
            }
            if (ContentLocation.Count > 0)
            {
                yield return ContentLocation;
            }
            if (ContentMd5.Count > 0)
            {
                yield return ContentMd5;
            }
            if (ContentRange.Count > 0)
            {
                yield return ContentRange;
            }
            if (ContentType.Count > 0)
            {
                yield return ContentType;
            }
            if (Cookie.Count > 0)
            {
                yield return Cookie;
            }
            if (Date.Count > 0)
            {
                yield return Date;
            }
            if (Expect.Count > 0)
            {
                yield return Expect;
            }
            if (Expires.Count > 0)
            {
                yield return Expires;
            }
            if (From.Count > 0)
            {
                yield return From;
            }
            if (Host.Count > 0)
            {
                yield return Host;
            }
            if (IfMatch.Count > 0)
            {
                yield return IfMatch;
            }
            if (IfModifiedSince.Count > 0)
            {
                yield return IfModifiedSince;
            }
            if (IfNoneMatch.Count > 0)
            {
                yield return IfNoneMatch;
            }
            if (IfRange.Count > 0)
            {
                yield return IfRange;
            }
            if (IfUnmodifiedSince.Count > 0)
            {
                yield return IfUnmodifiedSince;
            }
            if (KeepAlive.Count > 0)
            {
                yield return KeepAlive;
            }
            if (LastModified.Count > 0)
            {
                yield return LastModified;
            }
            if (MaxForwards.Count > 0)
            {
                yield return MaxForwards;
            }
            if (Pragma.Count > 0)
            {
                yield return Pragma;
            }
            if (ProxyAuthorization.Count > 0)
            {
                yield return ProxyAuthorization;
            }
            if (Range.Count > 0)
            {
                yield return Range;
            }
            if (Referer.Count > 0)
            {
                yield return Referer;
            }
            if (Te.Count > 0)
            {
                yield return Te;
            }
            if (Trailer.Count > 0)
            {
                yield return Trailer;
            }
            if (TransferEncoding.Count > 0)
            {
                yield return TransferEncoding;
            }
            if (Translate.Count > 0)
            {
                yield return Translate;
            }
            if (Upgrade.Count > 0)
            {
                yield return Upgrade;
            }
            if (UserAgent.Count > 0)
            {
                yield return UserAgent;
            }
            if (Via.Count > 0)
            {
                yield return Via;
            }
            if (Warning.Count > 0)
            {
                yield return Warning;
            }
        }

        private IEnumerable<KeyValuePair<string, StringValues>> PropertiesEnumerable()
        {
            if (Accept.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Accept", Accept);
            }
            if (AcceptCharset.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Accept-Charset", AcceptCharset);
            }
            if (AcceptEncoding.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Accept-Encoding", AcceptEncoding);
            }
            if (AcceptLanguage.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Accept-Language", AcceptLanguage);
            }
            if (Allow.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Allow", Allow);
            }
            if (Authorization.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Authorization", Authorization);
            }
            if (CacheControl.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Cache-Control", CacheControl);
            }
            if (Connection.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Connection", Connection);
            }
            if (ContentEncoding.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Content-Encoding", ContentEncoding);
            }
            if (ContentLanguage.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Content-Language", ContentLanguage);
            }
            if (ContentLength.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Content-Length", ContentLength);
            }
            if (ContentLocation.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Content-Location", ContentLocation);
            }
            if (ContentMd5.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Content-Md5", ContentMd5);
            }
            if (ContentRange.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Content-Range", ContentRange);
            }
            if (ContentType.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Content-Type", ContentType);
            }
            if (Cookie.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Cookie", Cookie);
            }
            if (Date.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Date", Date);
            }
            if (Expect.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Expect", Expect);
            }
            if (Expires.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Expires", Expires);
            }
            if (From.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("From", From);
            }
            if (Host.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Host", Host);
            }
            if (IfMatch.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("If-Match", IfMatch);
            }
            if (IfModifiedSince.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("If-Modified-Since", IfModifiedSince);
            }
            if (IfNoneMatch.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("If-None-Match", IfNoneMatch);
            }
            if (IfRange.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("If-Range", IfRange);
            }
            if (IfUnmodifiedSince.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("If-Unmodified-Since", IfUnmodifiedSince);
            }
            if (KeepAlive.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Keep-Alive", KeepAlive);
            }
            if (LastModified.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Last-Modified", LastModified);
            }
            if (MaxForwards.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Max-Forwards", MaxForwards);
            }
            if (Pragma.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Pragma", Pragma);
            }
            if (ProxyAuthorization.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Proxy-Authorization", ProxyAuthorization);
            }
            if (Range.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Range", Range);
            }
            if (Referer.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Referer", Referer);
            }
            if (Te.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Te", Te);
            }
            if (Trailer.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Trailer", Trailer);
            }
            if (TransferEncoding.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Transfer-Encoding", TransferEncoding);
            }
            if (Translate.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Translate", Translate);
            }
            if (Upgrade.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Upgrade", Upgrade);
            }
            if (UserAgent.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("User-Agent", UserAgent);
            }
            if (Via.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Via", Via);
            }
            if (Warning.Count > 0)
            {
                yield return new KeyValuePair<string, StringValues>("Warning", Warning);
            }
        }
    }
}
