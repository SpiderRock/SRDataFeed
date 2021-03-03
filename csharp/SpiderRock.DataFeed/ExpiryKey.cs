using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed
{
    public class ExpiryKey : IComparable<ExpiryKey>, IEquatable<ExpiryKey>, IKeyLayoutEquatable<ExpiryKeyLayout>
    {
        public static readonly int NowIndex = DateTime.Today.Year*10000 + DateTime.Today.Month*100 + DateTime.Today.Day;

        private static SpinLock keyCacheLock = new SpinLock();
        private static readonly Dictionary<ExpiryKeyLayout, ExpiryKey> KeyCache = new Dictionary<ExpiryKeyLayout, ExpiryKey>();

        public static readonly ExpiryKey Empty = new ExpiryKey(new ExpiryKeyLayout());

        internal readonly ExpiryKeyLayout Layout;
        private string ccode;
        private string expiration;
        private string stringKey, tabRecord;

        private ExpiryKey(ExpiryKeyLayout layout)
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
            get { return (byte) Layout.TickerSrc; }
        }

        public string CCode
        {
            get { return ccode ?? (ccode = Layout.Ticker.ToString()); }
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

        public DateTime Date
        {
            get { return new DateTime(Layout.Year, Layout.Month, Layout.Day); }
        }

        public bool IsValid
        {
            get
            {
                if (Layout.IsEmpty || Layout.Ticker.IsEmpty) return false;

                int yr = Year;
                int mn = Month;
                int dy = Day;

                if (mn < 1 || mn > 12) return false;
                if (dy < 1 || dy > 31) return false;

                return true;
            }
        }

        public int ExpIndex
        {
            get { return Year*10000 + Month*100 + Day; }
        }

        public string Expiration
        {
            get { return expiration ?? (expiration = string.Format("{0:D4}-{1:D2}-{2:D2}", Year, Month, Day)); }
        }

        public bool IsExpired
        {
            get { return (ExpIndex < NowIndex); }
        }

        public string StringKey
        {
            get { return stringKey ?? (stringKey = String.Format("{0}-{1}-{2}-{3:D4}-{4:D2}-{5:D2}", CCode, TickerSrc, AssetType, Year, Month, Day)); }
        }

        public string TabRecord
        {
            get { return tabRecord ?? (tabRecord = String.Format("{0}\t{1}\t{2}\t{3:D4}\t{4:D2}\t{5:D2}", CCode, TickerSrc, AssetType, Year, Month, Day)); }
        }

        public static string TabHeader
        {
            get { return "fkey_rt\tfkey_ts\tfkey_at\tfkey_yr\tfkey_mn\tfkey_dy"; }
        }

        public int CompareTo(ExpiryKey other)
        {
            if (other == null) return 1;
            return Layout.CompareTo(other.Layout);
        }

        public override int GetHashCode()
        {
            return Layout.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ExpiryKey other)
        {
            return other != null && Layout.Equals(other.Layout);
        }

        bool IKeyLayoutEquatable<ExpiryKeyLayout>.Equals(ref ExpiryKeyLayout other)
        {
            return Layout.Equals(other);
        }

        #region relational operator overloads

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(ExpiryKey x, ExpiryKey y)
        {
            return x.Layout.Ticker < y.Layout.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(ExpiryKey x, ExpiryKey y)
        {
            return x.Layout.Ticker > y.Layout.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(ExpiryKey x, ExpiryKey y)
        {
            return x.Layout.Ticker <= y.Layout.Ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(ExpiryKey x, ExpiryKey y)
        {
            return x.Layout.Ticker >= y.Layout.Ticker;
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ExpiryKey GetCreateExpiryKey(ExpiryKeyLayout key)
        {
            if (key.IsEmpty) return Empty;

            ExpiryKey cacheKey;
            if (KeyCache.TryGetValue(key, out cacheKey)) return cacheKey;

            bool lockTaken = false;

            try
            {
                keyCacheLock.Enter(ref lockTaken);

                if (!KeyCache.TryGetValue(key, out cacheKey))
                {
                    KeyCache[key] = cacheKey = new ExpiryKey(key);
                }

                return cacheKey;
            }
            catch (Exception e)
            {
                SRTrace.KeyErrors.TraceError(e, "GetCreateExpirtyKey: Cache Exception");
            }
            finally
            {
                if (lockTaken)
                {
                    keyCacheLock.Exit(false);
                }
                else
                {
                    SRTrace.KeyErrors.TraceError("GetCreateExpirtyKey: SpinLock Miss");
                }
            }

            return Empty;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return StringKey;
        }
    }
} // namespace
