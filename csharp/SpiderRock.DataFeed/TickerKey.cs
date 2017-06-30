using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed
{
    public class TickerKey : IComparable<TickerKey>, IEquatable<TickerKey>, IKeyLayoutEquatable<TickerKeyLayout>
    {
        private static SpinLock keyCacheLock = new SpinLock();
        private static readonly Dictionary<TickerKeyLayout, TickerKey> KeyCache = new Dictionary<TickerKeyLayout, TickerKey>();

        public static readonly TickerKey Empty = new TickerKey(new TickerKeyLayout());

        internal readonly TickerKeyLayout Layout;
        private readonly bool is4Letter;
        private readonly string ticker;

        private string stringKey, tabRecord;

        private TickerKey(TickerKeyLayout layout)
        {
            Layout = layout;

            ticker = layout.Ticker.ToString();
            is4Letter = (ticker.Length > 3);
        }

        public AssetType AssetType
        {
            get { return Layout.AssetType; }
        }

        public TickerSrc TickerSrc
        {
            get { return Layout.TickerSrc; }
        }

        public int TickerSrcInt
        {
            get { return (int) Layout.TickerSrc; }
        }

        public string Ticker
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker; }
        }

        public bool IsValid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return (TickerSrc != TickerSrc.None && AssetType != AssetType.None && !Layout.Ticker.IsEmpty); }
        }

        public bool Is4Letter
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return is4Letter; }
        }

        public string StringKey
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return stringKey ?? (stringKey = String.Format("{0}-{1}-{2}", Ticker, TickerSrc, AssetType)); }
        }

        public string TabRecord
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return tabRecord ?? (tabRecord = String.Format("{0}\t{1}\t{2}", Ticker, TickerSrc, AssetType)); }
        }

        public static string TabHeader
        {
            get { return "skey_tk\tskey_ts\tskey_at"; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(TickerKey b)
        {
            return Layout.CompareTo(b.Layout);
        }

        public override int GetHashCode()
        {
            return Layout.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(TickerKey other)
        {
            return other != null && Layout.Equals(other.Layout);
        }

        bool IKeyLayoutEquatable<TickerKeyLayout>.Equals(ref TickerKeyLayout other)
        {
            return Layout.Equals(other);
        }

        #region relational operator overloads

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(TickerKey x, TickerKey y)
        {
            return x.Layout.Ticker < y.Layout.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(TickerKey x, TickerKey y)
        {
            return x.Layout.Ticker > y.Layout.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(TickerKey x, TickerKey y)
        {
            return x.Layout.Ticker <= y.Layout.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(TickerKey x, TickerKey y)
        {
            return x.Layout.Ticker >= y.Layout.Ticker;
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TickerKey GetCreateTickerKey(TickerKeyLayout key)
        {
            if (key.IsEmpty) return Empty;

            TickerKey cacheKey;
            if (KeyCache.TryGetValue(key, out cacheKey)) return cacheKey;

            bool lockTaken = false;

            try
            {
                keyCacheLock.Enter(ref lockTaken);

                if (!KeyCache.TryGetValue(key, out cacheKey))
                {
                    KeyCache[key] = cacheKey = new TickerKey(key);

                    if (!cacheKey.IsValid)
                    {
                        SRTrace.KeyErrors.TraceError("GetCreateTickerKey: Invalid: {0}",
                            cacheKey.StringKey);
                    }
                }

                return cacheKey;
            }
            catch (Exception e)
            {
                SRTrace.KeyErrors.TraceError(e, "GetCreateTickerKey: Cache Exception");
            }
            finally
            {
                if (lockTaken)
                {
                    keyCacheLock.Exit(false);
                }
                else
                {
                    SRTrace.KeyErrors.TraceError("GetCreateTickerKey: SpinLock Miss");
                }
            }

            return Empty;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TickerKey GetCreateTickerKey(string stockKeyStr)
        {
            if (stockKeyStr == null)
            {
                SRTrace.KeyErrors.TraceError("GetCreateTickerKey: stockKeyStr Null");

                return Empty;
            }

            string[] tokens = stockKeyStr.Split('-');

            if (tokens.Length != 3)
            {
                SRTrace.KeyErrors.TraceError("GetCreateTickerKey: StockKeyStr: [{0}]", stockKeyStr);

                return Empty;
            }

            string tk = tokens[0];
            string ts = tokens[1];
            string at = tokens[2];

            return GetCreateTickerKey(at, ts, tk);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TickerKey GetCreateTickerKey(string assetType, string tickerSrc, string ticker)
        {
            AssetType at;
            Enum.TryParse(assetType, out at);

            TickerSrc ts;
            Enum.TryParse(tickerSrc, out ts);

            return GetCreateTickerKey(at, ts, ticker);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TickerKey GetCreateTickerKey(AssetType assetType, TickerSrc tickerSrc, string ticker)
        {
            return GetCreateTickerKey(new TickerKeyLayout(assetType, tickerSrc, ticker));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return StringKey;
        }
    }
}

// namespace