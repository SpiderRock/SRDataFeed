using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed
{
    public class CCodeKey : IEquatable<CCodeKey>, IComparable<CCodeKey>, IKeyLayoutEquatable<CCodeKeyLayout>
    {
        // ReSharper disable ImpureMethodCallOnReadonlyValueField

        private static SpinLock keyCacheLock = new SpinLock();

        private static readonly Dictionary<CCodeKeyLayout, CCodeKey> KeyCache =
            new Dictionary<CCodeKeyLayout, CCodeKey>();

        public static readonly CCodeKey Empty = new CCodeKey(new CCodeKeyLayout());

        internal readonly CCodeKeyLayout Layout;

        private string ccode, stringKey, tabRecord;

        private CCodeKey(CCodeKeyLayout layout)
        {
            Layout = layout;
        }

        public AssetType AssetType
        {
            get { return Layout.AssetType; }
        }

        public TickerSrc TickerSrc
        {
            get { return Layout.TickerSrc; }
        }

        public string CCode
        {
            get { return ccode ?? (ccode = Layout.CCode.ToString()); }
        }

        public bool IsValid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return !Layout.IsEmpty && Layout.CCode.Length > 0;
            }
        }

        public string StringKey
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return stringKey ?? (stringKey = String.Format("{0}-{1}-{2}", CCode, TickerSrc, AssetType)); }
        }

        public string TabRecord
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return tabRecord ?? (tabRecord = String.Format("{0}\t{1}\t{2}", CCode, TickerSrc, AssetType)); }
        }

        public static string TabHeader
        {
            get { return "rkey_rt\trkey_ts\trkey_at"; }
        }

        public int CompareTo(CCodeKey other)
        {
            if (other == null) return 1;
            return Layout.CompareTo(other.Layout);
        }

        public bool Equals(CCodeKey other)
        {
            return other != null && Layout == other.Layout;
        }

        bool IKeyLayoutEquatable<CCodeKeyLayout>.Equals(ref CCodeKeyLayout other)
        {
            return Layout.Equals(other);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CCodeKey);
        }

        public override int GetHashCode()
        {
            return Layout.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static CCodeKey GetCreateCCodeKey(CCodeKeyLayout key)
        {
            if (key.IsEmpty) return Empty;

            CCodeKey cacheKey;
            if (KeyCache.TryGetValue(key, out cacheKey)) return cacheKey;

            bool lockTaken = false;

            try
            {
                keyCacheLock.Enter(ref lockTaken);

                if (!KeyCache.TryGetValue(key, out cacheKey))
                {
                    KeyCache[key] = cacheKey = new CCodeKey(key);

                    if (!cacheKey.IsValid)
                    {
                        SRTrace.KeyErrors.TraceError("GetCreateCCodeKey: Invalid: {0}",
                            cacheKey.StringKey);
                    }
                }

                return cacheKey;
            }
            catch (Exception e)
            {
                SRTrace.KeyErrors.TraceError(e, "GetCreateCCodeKey: Cache Exception");
            }
            finally
            {
                if (lockTaken)
                {
                    keyCacheLock.Exit(false);
                }
                else
                {
                    SRTrace.KeyErrors.TraceError("GetCreateCCodeKey: SpinLock Miss");
                }
            }

            return Empty;
        }

        public static CCodeKey GetCreateCCodeKey(string value)
        {
            if (value == null)
            {
                SRTrace.KeyErrors.TraceError("GetCreateCCodeKey: value Null");

                return Empty;
            }

            string[] tokens = value.Split('-');

            if (tokens.Length != 3)
            {
                SRTrace.KeyErrors.TraceError("GetCreateCCodeKey: value: [{0}]", value);

                return Empty;
            }

            return GetCreateCCodeKey(tokens[2], tokens[1], tokens[0]);
        }

        public static CCodeKey GetCreateCCodeKey(string assetType, string tickerSrc, string ccode)
        {
            AssetType at;
            Enum.TryParse(assetType, out at);

            TickerSrc ts;
            Enum.TryParse(tickerSrc, out ts);

            return GetCreateCCodeKey(at, ts, ccode);
        }

        public static CCodeKey GetCreateCCodeKey(AssetType assetType, TickerSrc tickerSrc, string ccode)
        {
            return GetCreateCCodeKey(new CCodeKeyLayout(assetType, tickerSrc, ccode));
        }

        public override string ToString()
        {
            return StringKey;
        }
    }
} // namespace