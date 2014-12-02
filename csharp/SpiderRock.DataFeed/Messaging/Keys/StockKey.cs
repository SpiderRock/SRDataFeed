// --------------------------------------------------------------------------------
//  SRMsgCore.Key.StockKey.cs
//  
//  Copyright 2013, SpiderRock Technology
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;

namespace SpiderRock.DataFeed.Messaging.Keys
{
    public class StockKey : IComparable<StockKey>, IEquatable<StockKeyLayout>
    {
        private static SpinLock spinLock = new SpinLock();

        private static readonly Dictionary<StockKeyLayout, StockKey> KeyCache =
            new Dictionary<StockKeyLayout, StockKey>();

        public static readonly StockKey Empty = new StockKey(new StockKeyLayout());

        internal static readonly string EmptyTab = Empty.TabRecord;
        internal static readonly string EmptyStr = Empty.StringKey;
        private StockKeyLayout key;

        private string stringKey, tabRecord;
        private string ticker;

        private bool is4Letter;

        private StockKey(StockKeyLayout key)
        {
            this.key = key;

            ticker = key.Ticker.ToString();
            is4Letter = (ticker.Length > 3);
        }

        public AssetType AssetType
        {
            get { return key.AssetType; }
        }

        public TickerSrc TickerSrc
        {
            get { return key.TickerSrc; }
        }

        public int TickerSrcInt
        {
            get { return (int) key.TickerSrc; }
        }

        public string Ticker
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ticker; }
        }

        public bool IsValid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return (TickerSrc != TickerSrc.None && AssetType != AssetType.None && !key.Ticker.IsEmpty); }
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
        public int CompareTo(StockKey b)
        {
            return key.CompareTo(b.key);
        }

        #region relational operator overloads

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(StockKey x, StockKey y)
        {
            return x.key.Ticker < y.key.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(StockKey x, StockKey y)
        {
            return x.key.Ticker > y.key.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(StockKey x, StockKey y)
        {
            return x.key.Ticker <= y.key.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(StockKey x, StockKey y)
        {
            return x.key.Ticker >= y.key.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(StockKey x, TickerLayout y)
        {
            return x.key.Ticker < y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(StockKey x, TickerLayout y)
        {
            return x.key.Ticker > y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(StockKey x, TickerLayout y)
        {
            return x.key.Ticker <= y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(StockKey x, TickerLayout y)
        {
            return x.key.Ticker >= y;
        }

        #endregion

        /// <summary>
        ///     Returns value is equivalent to comp1 and comp2 or creates a new value, caches it, and returns it.
        /// </summary>
        /// <param name="value">Existing value.</param>
        /// <param name="comp">The value that is compared to value.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StockKey CreateOrReuse(StockKey value, StockKeyLayout comp)
        {
            return (value != null && value.key == comp) ? value : GetCreateStockKey(comp);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StockKey GetCreateStockKey(StockKeyLayout key)
        {
            if (key.IsEmpty) return Empty;

            StockKey cacheKey;
            if (KeyCache.TryGetValue(key, out cacheKey)) return cacheKey;

            bool lockTaken = false;
            spinLock.Enter(ref lockTaken);

            if (!lockTaken)
            {
                SRTrace.KeyErrors.TraceError("GetCreateStockKey: SpinLock Miss");
            }

            try
            {
                if (!KeyCache.TryGetValue(key, out cacheKey))
                {
                    KeyCache[key] = cacheKey = new StockKey(key);

                    if (!cacheKey.IsValid)
                    {
                        SRTrace.KeyErrors.TraceError("GetCreateStockKey: Invalid: {0}",
                                  cacheKey.StringKey);
                    }
                }

                return cacheKey;
            }
            catch
            {
                SRTrace.KeyErrors.TraceError("GetCreateStockKey: Cache Exception");
            }
            finally
            {
                if (lockTaken) spinLock.Exit(false);
            }

            return Empty;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StockKey GetCreateStockKey(string stockKeyStr)
        {
            if (stockKeyStr == null)
            {
                SRTrace.KeyErrors.TraceError("GetCreateStockKey: stockKeyStr Null");

                return Empty;
            }

            string[] tokens = stockKeyStr.Split('-');

            if (tokens.Length != 3)
            {
                SRTrace.KeyErrors.TraceError("GetCreateStockKey: StockKeyStr: [{0}]", stockKeyStr);

                return Empty;
            }

            string tk = tokens[0];
            string ts = tokens[1];
            string at = tokens[2];

            return GetCreateStockKey(at, ts, tk);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StockKey GetCreateStockKey(string assetType, string tickerSrc, string ticker)
        {
            AssetType at;
            Enum.TryParse(assetType, out at);

            TickerSrc ts;
            Enum.TryParse(tickerSrc, out ts);

            return GetCreateStockKey(at, ts, ticker);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StockKey GetCreateStockKey(AssetType assetType, TickerSrc tickerSrc, string ticker)
        {
            return GetCreateStockKey(new StockKeyLayout(assetType, tickerSrc, ticker));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(StockKeyLayout other)
        {
            return key.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return StringKey;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator StockKeyLayout(StockKey v)
        {
            return v.key;
        }
    }
}

// namespace