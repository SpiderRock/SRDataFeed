// --------------------------------------------------------------------------------
//  SRMsgCore.Key.OptionKey.cs
//  
//  Copyright 2011, SpiderRock Technology
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;

namespace SpiderRock.DataFeed.Messaging.Keys
{
    public class OptionKey : IComparable<OptionKey>, IEquatable<OptionKeyLayout>
    {
        private static SpinLock spinLock = new SpinLock();  

        private static readonly Dictionary<OptionKeyLayout, OptionKey> KeyCache =
            new Dictionary<OptionKeyLayout, OptionKey>();       

        public static readonly OptionKey Empty = new OptionKey(new OptionKeyLayout());

        private static RootLayout _minRoot;
        private static RootLayout _maxRoot = new RootLayout("ZZZZZZ");

        internal static readonly string EmptyTab = Empty.TabRecord;
        internal static readonly string EmptyStr = Empty.StringKey;

        private OptionKeyLayout key;        

        private string root, stringKey, osiKey, tabRecord, tabRecordCP, expiration;

        private RootKey rootKey;
        private StockKey stockKey;
        private FutureKey futureKey;
    
        private OptionKey(OptionKeyLayout key)
        {
            this.key = key;
        }

        public YesNo OurStripe { get; set; }

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

        public string Root 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return root ?? (root = key.Root.ToString()); }
        }

        public RootLayout RootLayout
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return key.Root; }
        }

        public CallPut CallPut
        {
            get { return key.CallPut; }
        }
       
        public char CallPutChar
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return key.CallPut == CallPut.Call ? 'C' : 'P'; }
        }

        public int StrikeInt
        {
            get { return key.StrikeInt; }
        }

        public double Strike
        {
            get { return key.Strike; }
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

        public OptionKeyLayout CPPairKey
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            get
            {
                unchecked
                {
                    OptionKeyLayout copy = key;
                    copy.CallPut = CallPut.Call;
                    return copy;
                }
            }
        }

        public OptionKeyLayout ExpirationKey
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                unchecked
                {
                    OptionKeyLayout copy = key;
                    copy.Strike = 0;
                    copy.CallPut = CallPut.Call;
                    return copy;
                }
            }
        }

        public RootKey RootKey
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            get 
            {
                return rootKey ?? (rootKey = RootKey.GetCreateRootKey(new RootKeyLayout(key.AssetType, key.TickerSrc, key.Root)));
            }
        }

        public StockKey StockKey
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return stockKey ?? (stockKey = StockKey.GetCreateStockKey(new StockKeyLayout(key.AssetType, key.TickerSrc, new TickerLayout(key.Root))));
            }
        }

        public FutureKey FutureKey
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return futureKey ?? (futureKey = FutureKey.GetCreateFutureKey(new FutureKeyLayout(key.AssetType, key.TickerSrc, key.Root, key.Year, key.Month, key.Day)));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OptionKey GetCreateOptionKey(OptionKeyLayout key)
        {
            if (key.IsEmpty) return Empty;

            OptionKey cacheKey;
            if (KeyCache.TryGetValue(key, out cacheKey)) return cacheKey;

            bool lockTaken = false;           

            try
            {
                spinLock.Enter(ref lockTaken);

                if (!lockTaken)
                {
                    SRTrace.KeyErrors.TraceError("GetCreateOptionKey: SpinLock Miss");
                }

                if (!KeyCache.TryGetValue(key, out cacheKey))
                {
                    KeyCache[key] = cacheKey = new OptionKey(key);

                    if (!cacheKey.IsValid)
                    {
                        SRTrace.KeyErrors.TraceError("GetCreateOptionKey: Invalid: {0}",
                                  cacheKey.StringKey);
                    }
                }

                return cacheKey;
            }
            catch
            {
                SRTrace.KeyErrors.TraceError("GetCreateOptionKey: Cache Exception");
            }
            finally
            {
                if (lockTaken) spinLock.Exit(false);
            }

            return Empty;
        }

        /// <summary>
        /// Returns value is equivalent to comp1 and comp2 or creates a new value, caches it, and returns it.
        /// </summary>
        /// <param name="value">Existing value.</param>
        /// <param name="comp">The value that is compared to value.</param>
        /// <returns>
        /// <see cref="value"/> argument if it isn't null and is equal to <see cref="comp"/>.
        /// Otherwise, a key corresponding to <see cref="comp"/> is returned.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OptionKey CreateOrReuse(OptionKey value, OptionKeyLayout comp)
        {
            return (value != null && value.key == comp) ? value : GetCreateOptionKey(comp);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OptionKey GetCreateOptionKey(string optionKeyStr)
        {
            if (optionKeyStr == null)
            {
                SRTrace.KeyErrors.TraceError("GetCreateOptionKey: optionKeyStr Null");

                return Empty;            
            }

            string[] tokens = optionKeyStr.Split('-');

            if (tokens.Length != 8)
            {
                SRTrace.KeyErrors.TraceError("GetCreateOptionKey: optionKeyStr: [{0}]", optionKeyStr);

                return Empty;             
            }

            int yr, mn, dy, xx;

            int.TryParse(tokens[3], out yr);
            int.TryParse(tokens[4], out mn);
            int.TryParse(tokens[5], out dy);
            int.TryParse(tokens[6], out xx);           

            return GetCreateOptionKey(tokens[2], tokens[1], tokens[0], yr, mn, dy, xx, tokens[7]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OptionKey GetCreateOptionKey(string assetType, string tickerSrc, string root, int year, int month, int day, int strike, string cp)
        {
            AssetType at;
            Enum.TryParse(assetType, out at);            

            TickerSrc ts;
            Enum.TryParse(tickerSrc, out ts);

            CallPut callput = cp == "C" ? CallPut.Call : CallPut.Put;            

            return GetCreateOptionKey(at, ts, root, year, month, day, 0.001 * strike, callput);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OptionKey GetCreateOptionKey(AssetType assetType, TickerSrc tickerSrc, string root, int year,
                                                   int month, int day, double strike, CallPut callput)
        {
            return GetCreateOptionKey(new OptionKeyLayout(assetType, tickerSrc, root, year, month, day, strike, callput));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OptionKey GetCreateOptionKey(RootKeyLayout rkey, int year, int month, int day, double strike, CallPut callput)
        {           
            return GetCreateOptionKey(new OptionKeyLayout(rkey.AssetType, rkey.TickerSrc, rkey.Root, year, month, day, strike, callput));
        }

        public bool IsValid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return key.IsValid; }
        }

        public int ExpIndex
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return key.ExpIndex; }
        }

        public string Expiration
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return expiration ?? (expiration = string.Format("{0:D4}-{1:D2}-{2:D2}", Year, Month, Day));
            }
        }

        public bool IsExpired
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return key.IsExpired; }
        }

        public string OSIKey
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return osiKey ?? (osiKey = String.Format("{0}{1:D2}{2:D2}{3:D2}{4}{5:00000}{6:000}", Root.PadRight(6), Year % 100, Month, Day, CallPutChar, StrikeInt / 1000, StrikeInt % 1000));
            }
        }

        public string StringKey
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return stringKey ?? (stringKey = String.Format("{0}-{1}-{2}-{3:D4}-{4:D2}-{5:D2}-{6}-{7}", Root, TickerSrc, AssetType, Year, Month, Day, StrikeInt, CallPutChar));
            }
        }

        public static string TabHeader
        {
            get
            {
                return "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp";
            }
        }

        public string TabRecord
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return tabRecord ?? (tabRecord = String.Format("{0}\t{1}\t{2}\t{3:D4}\t{4:D2}\t{5:D2}\t{6}\t{7}", Root, TickerSrc, AssetType, Year, Month, Day, StrikeInt, CallPutChar));
            }
        }

        public static string TabHeaderCP
        {
            get
            {
                return "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx";
            }
        }

        public string TabRecordCP
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return tabRecordCP ?? (tabRecordCP = String.Format("{0}\t{1}\t{2}\t{3:D4}\t{4:D2}\t{5:D2}\t{6}", Root, TickerSrc, AssetType, Year, Month, Day, StrikeInt));
            }
        }

        public static RootLayout MinRoot
        {
            get { return _minRoot; }
        }

        public static RootLayout MaxRoot
        {
            get { return _maxRoot; }
        }

        public static void SetRootBounds(string min, string max)
        {
            _minRoot = new RootLayout(min);
            _maxRoot = new RootLayout(max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClearRootBounds()
        {
            _minRoot = new RootLayout();
            _maxRoot = new RootLayout("ZZZZZZ");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(OptionKey other)
        {
            if (other == null) return 1;
            return key.CompareTo(other.key);
        }

        #region relational operator overloads

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(OptionKey x, OptionKey y)
        {
            return x.key.Root < y.key.Root;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(OptionKey x, OptionKey y)
        {
            return x.key.Root > y.key.Root;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(OptionKey x, OptionKey y)
        {
            return x.key.Root <= y.key.Root;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(OptionKey x, OptionKey y)
        {
            return x.key.Root >= y.key.Root;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(OptionKey x, RootLayout y)
        {
            return x.key.Root < y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(OptionKey x, RootLayout y)
        {
            return x.key.Root > y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(OptionKey x, RootLayout y)
        {
            return x.key.Root <= y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(OptionKey x, RootLayout y)
        {
            return x.key.Root >= y;
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(OptionKeyLayout other)
        {
            return key.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return StringKey;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator OptionKeyLayout(OptionKey v)
        {
            return v.key;
        }
    }
    // ReSharper restore InconsistentNaming

} // namespace


