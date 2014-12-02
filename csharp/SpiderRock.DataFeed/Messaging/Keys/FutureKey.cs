// --------------------------------------------------------------------------------
//  SRMsgCore.Key.FutureKey.cs
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
    public class FutureKey : IComparable<FutureKey>, IEquatable<FutureKey>, IEquatable<FutureKeyLayout>
    {
        public static readonly int NowIndex = DateTime.Today.Year * 10000 + DateTime.Today.Month * 100 + DateTime.Today.Day;

        private static SpinLock spinLock = new SpinLock();
        private static readonly Dictionary<FutureKeyLayout, FutureKey> KeyCache = new Dictionary<FutureKeyLayout, FutureKey>();

        public static readonly FutureKey Empty = new FutureKey(new FutureKeyLayout());

        internal static readonly string EmptyTab = Empty.TabRecord;
        internal static readonly string EmptyStr = Empty.StringKey;

        private FutureKeyLayout key;
        private string ccode, stringKey, tabRecord, expiration;
       
        private FutureKey(FutureKeyLayout keyLayout)
        {
            key = keyLayout;
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
            get { return (byte) key.TickerSrc; }
        }

        public string CCode
        {
            get { return ccode ?? (ccode = key.CCode.ToString()); }
        }             

        public int Year
        {
            get { return key.Year; }
        }

        public int Month
        {
            get { return key.Month; }
        }

        public int Day
        {
            get { return key.Day; }
        }

        public RootKey RootKey
        {
            get { return RootKey.GetCreateRootKey(new RootKeyLayout(key.AssetType, key.TickerSrc, key.CCode)); }
        }

        public DateTime Date
        {
            get { return new DateTime(key.Year, key.Month, key.Day); }
        }

        /// <summary>
        /// Returns value is equivalent to comp1 and comp2 or creates a new value, caches it, and returns it.
        /// </summary>
        /// <param name="value">Existing value.</param>
        /// <param name="comp">The value that is compared to <see cref="value"/>.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FutureKey CreateOrReuse(FutureKey value, FutureKeyLayout comp)
        {
            return (value != null && value.key == comp) ? value : GetCreateFutureKey(comp);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FutureKey GetCreateFutureKey(FutureKeyLayout key)
        {
            if (key.IsEmpty) return Empty;

            FutureKey cacheKey;
            if (KeyCache.TryGetValue(key, out cacheKey)) return cacheKey;

            bool lockTaken = false;
            spinLock.Enter(ref lockTaken);

            if (!lockTaken)
            {
                SRTrace.KeyErrors.TraceError("GetCreateFutureKey: SpinLock Miss");
            }

            try
            {
                if (!KeyCache.TryGetValue(key, out cacheKey))
                {
                    KeyCache[key] = cacheKey = new FutureKey(key);

                    if (!cacheKey.IsValid)
                    {
                        SRTrace.KeyErrors.TraceError("GetCreateFutureKey: Invalid: {0}, trace={1}",
                                  cacheKey.StringKey, Environment.StackTrace);
                    }
                }

                return cacheKey;
            }
            catch
            {
                SRTrace.KeyErrors.TraceError("GetCreateFutureKey: Cache Exception");
            }
            finally
            {
                if (lockTaken) spinLock.Exit(false);
            }

            return Empty;
        }

        public static FutureKey GetCreateFutureKey(string futureKeyStr)
        {
            if (futureKeyStr == null)
            {
                SRTrace.KeyErrors.TraceError("GetCreateFutureKey: futureKeyStr Null");

                return Empty; 
            }

            string[] tokens = futureKeyStr.Split('-');

            if (tokens.Length != 6)
            {
                SRTrace.KeyErrors.TraceError("GetCreateFutureKey: futureKeyStr: [{0}]", futureKeyStr);

                return Empty;             
            }

            int yr, mn, dy;

            int.TryParse(tokens[3], out yr);
            int.TryParse(tokens[4], out mn);
            int.TryParse(tokens[5], out dy);           

            return GetCreateFutureKey(tokens[2], tokens[1], tokens[0], yr, mn, dy);
        }

        public static FutureKey GetCreateFutureKey(string assetType, string tickerSrc, string root, int year, int month, int day)
        {
            AssetType at;
            Enum.TryParse(assetType, out at);            

            TickerSrc ts;
            Enum.TryParse(tickerSrc, out ts);
            
            return GetCreateFutureKey(at, ts, root, year, month, day);
        }

        public static FutureKey GetCreateFutureKey(AssetType assetType, TickerSrc tickerSrc, string root, int year, int month, int day)
        {
            return GetCreateFutureKey(new FutureKeyLayout(assetType, tickerSrc, root, year, month, day));
        }

        public bool IsValid
        {
            get
            {                  
                if (string.IsNullOrEmpty(CCode)) return false;

                int yr = Year;
                int mn = Month;
                int dy = Day;
             
                if (yr < 1901 || yr > 2150) return false;
                if (mn < 1 || mn > 12) return false;
                if (dy < 1 || dy > 31) return false;              

                return true;
            }
        }

        public int ExpIndex
        {
            get { return Year * 10000 + Month * 100 + Day; }
        }

        public string Expiration
        {
            get
            {
                return expiration ?? (expiration = string.Format("{0:D4}-{1:D2}-{2:D2}", Year, Month, Day));
            }
        }

        public bool IsExpired
        {
            get
            {
                return (ExpIndex < NowIndex);
            }
        }

        public string StringKey
        {
            get
            {
                return stringKey ?? (stringKey = String.Format("{0}-{1}-{2}-{3:D4}-{4:D2}-{5:D2}", CCode, TickerSrc, AssetType, Year, Month, Day));
            }
        }

        public string TabRecord
        {
            get
            {
                return tabRecord ?? (tabRecord = String.Format("{0}\t{1}\t{2}\t{3:D4}\t{4:D2}\t{5:D2}", CCode, TickerSrc, AssetType, Year, Month, Day));
            }
        }

        public static string TabHeader
        {
            get
            {
                return "fkey_rt\tfkey_ts\tfkey_at\tfkey_yr\tfkey_mn\tfkey_dy";
            }
        }

        public int CompareTo(FutureKey other)
        {
            if (other == null) return 1;
            return key.CompareTo(other.key);
        }

        #region relational operator overloads

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(FutureKey x, FutureKey y)
        {
            return x.key.CCode < y.key.CCode;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(FutureKey x, FutureKey y)
        {
            return x.key.CCode > y.key.CCode;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(FutureKey x, FutureKey y)
        {
            return x.key.CCode <= y.key.CCode;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(FutureKey x, FutureKey y)
        {
            return x.key.CCode >= y.key.CCode;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(FutureKey x, RootLayout y)
        {
            return x.key.CCode < y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(FutureKey x, RootLayout y)
        {
            return x.key.CCode > y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(FutureKey x, RootLayout y)
        {
            return x.key.CCode <= y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(FutureKey x, RootLayout y)
        {
            return x.key.CCode >= y;
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(FutureKey other)
        {
            return key.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(FutureKeyLayout other)
        {
            return key.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return StringKey;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator FutureKeyLayout(FutureKey v)
        {
            return v.key;
        }
    }

} // namespace


