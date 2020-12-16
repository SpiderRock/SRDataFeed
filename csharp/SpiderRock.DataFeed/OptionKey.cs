using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed
{
    public class OptionKey : IComparable<OptionKey>, IEquatable<OptionKey>, IKeyLayoutEquatable<OptionKeyLayout>
    {
        // ReSharper disable ImpureMethodCallOnReadonlyValueField

        private static SpinLock keyCacheLock = new SpinLock();

        private static readonly Dictionary<OptionKeyLayout, OptionKey> KeyCache =
            new Dictionary<OptionKeyLayout, OptionKey>();

        public static readonly OptionKey Empty = new OptionKey(new OptionKeyLayout());

        internal readonly OptionKeyLayout Layout;
        private string expiration;

        private string osiKey;

        private string root;
        private string stringKey;
        private string tabRecord, tabRecordCP;

        private OptionKey(OptionKeyLayout layout)
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

        public int TickerSrcInt
        {
            get { return (int) Layout.TickerSrc; }
        }

        public string Root
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return root ?? (root = Layout.Ticker.ToString()); }
        }

        public CallPut CallPut
        {
            get { return Layout.CallPut; }
        }

        public char CallPutChar
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return Layout.CallPut == CallPut.Call ? 'C' : 'P';
            }
        }

        public double Strike
        {
            get { return Layout.Strike; }
        }

        public int Year
        {
            get { return Layout.Year; }
        }

        public int Month
        {
            get { return Layout.Month; }
        }

        public int Day
        {
            get { return Layout.Day; }
        }

        //public RootKey RootKey
        //{
        //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        //    get
        //    {
        //        return rootKey ?? (rootKey = RootKey.GetCreateRootKey(Layout));
        //    }
        //}

        public bool IsValid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Layout.IsEmpty || Layout.Ticker.IsEmpty) return false;

                int yr = Year;
                int mn = Month;
                int dy = Day;

                CallPut cp = CallPut;

                if (yr < 1901 || yr > 2150) return false;
                if (mn < 1 || mn > 12) return false;
                if (dy < 1 || dy > 31) return false;

                return cp == CallPut.Call || cp == CallPut.Put;
            }
        }

        //public int ExpIndex
        //{
        //    [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return Layout.ExpIndex; }
        //}

        public string Expiration
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return expiration ?? (expiration = string.Format("{0:D4}-{1:D2}-{2:D2}", Year, Month, Day));
            }
        }

        //public bool IsExpired
        //{
        //    [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return Layout.IsExpired; }
        //}

        public string OSIKey
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                int strikeInt = (int) (Strike * 1000D + 0.5);

                return osiKey ??
                       (osiKey =
                           string.Format("{0}{1:D2}{2:D2}{3:D2}{4}{5:00000}{6:000}", Root.PadRight(6), Year%100, Month,
                               Day, CallPutChar, strikeInt / 1000, strikeInt % 1000));
            }
        }

        public string StringKey
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return stringKey ??
                       (stringKey =
                           string.Format("{0}-{1}-{2}-{3:D4}-{4:D2}-{5:D2}-{6}-{7}", Root, TickerSrc, AssetType, Year,
                               Month, Day, Strike, CallPutChar));
            }
        }

        public static string TabHeader
        {
            get { return "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp"; }
        }

        public string TabRecord
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                int strikeInt = (int)(Strike * 1000D + 0.5);

                return tabRecord ?? (tabRecord = string.Format("{0}\t{1}\t{2}\t{3:D4}\t{4:D2}\t{5:D2}\t{6}\t{7}", Root, TickerSrc, AssetType, Year, Month, Day, strikeInt, CallPutChar));
            }
        }

        public static string TabHeaderCP
        {
            get { return "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx"; }
        }

        public string TabRecordCP
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                int strikeInt = (int)(Strike * 1000D + 0.5);

                return tabRecordCP ?? (tabRecordCP = string.Format("{0}\t{1}\t{2}\t{3:D4}\t{4:D2}\t{5:D2}\t{6}", Root, TickerSrc, AssetType, Year, Month, Day, strikeInt));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(OptionKey other)
        {
            if (other == null) return 1;
            return Layout.CompareTo(other.Layout);
        }

        public bool Equals(OptionKey other)
        {
            return other != null && Layout.Equals(other.Layout);
        }

        bool IKeyLayoutEquatable<OptionKeyLayout>.Equals(ref OptionKeyLayout other)
        {
            return Layout.Equals(other);
        }

        #region relational operator overloads

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(OptionKey x, OptionKey y)
        {
            return x.Layout.Ticker < y.Layout.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(OptionKey x, OptionKey y)
        {
            return x.Layout.Ticker > y.Layout.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(OptionKey x, OptionKey y)
        {
            return x.Layout.Ticker <= y.Layout.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(OptionKey x, OptionKey y)
        {
            return x.Layout.Ticker >= y.Layout.Ticker;
        }

        #endregion

        public override int GetHashCode()
        {
            return Layout.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static OptionKey GetCreateOptionKey(OptionKeyLayout key)
        {
            if (key.IsEmpty) return Empty;

            OptionKey cacheKey;
            if (KeyCache.TryGetValue(key, out cacheKey)) return cacheKey;

            bool lockTaken = false;

            try
            {
                keyCacheLock.Enter(ref lockTaken);

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
            catch (Exception e)
            {
                SRTrace.KeyErrors.TraceError(e, "GetCreateOptionKey: Cache Exception");
            }
            finally
            {
                if (lockTaken)
                {
                    keyCacheLock.Exit(false);
                }
                else
                {
                    SRTrace.KeyErrors.TraceError("GetCreateOptionKey: SpinLock Miss");
                }
            }

            return Empty;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ExpiryKey(OptionKey key)
        {
            return ExpiryKey.GetCreateExpiryKey((ExpiryKeyLayout)key.Layout);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return StringKey;
        }
    }
}
