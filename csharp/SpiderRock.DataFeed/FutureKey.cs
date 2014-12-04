using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.DataFeed.Diagnostics;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed
{
    public class FutureKey : IComparable<FutureKey>, IEquatable<FutureKey>, IKeyLayoutEquatable<FutureKeyLayout>
    {
        public static readonly int NowIndex = DateTime.Today.Year*10000 + DateTime.Today.Month*100 + DateTime.Today.Day;

        private static SpinLock keyCacheLock = new SpinLock();
        private static readonly Dictionary<FutureKeyLayout, FutureKey> KeyCache = new Dictionary<FutureKeyLayout, FutureKey>();

        public static readonly FutureKey Empty = new FutureKey(new FutureKeyLayout());

        internal readonly FutureKeyLayout Layout;
        private string ccode;
        private string expiration;
        private string stringKey, tabRecord;

        private FutureKey(FutureKeyLayout layout)
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
            get { return ccode ?? (ccode = Layout.CCode.ToString()); }
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

        public RootKey RootKey
        {
            get { return RootKey.GetCreateRootKey(new RootKeyLayout(Layout.AssetType, Layout.TickerSrc, Layout.CCode)); }
        }

        public DateTime Date
        {
            get { return new DateTime(Layout.Year, Layout.Month, Layout.Day); }
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

        public int CompareTo(FutureKey other)
        {
            if (other == null) return 1;
            return Layout.CompareTo(other.Layout);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(FutureKey other)
        {
            return other != null && Layout.Equals(other.Layout);
        }

        bool IKeyLayoutEquatable<FutureKeyLayout>.Equals(ref FutureKeyLayout other)
        {
            return Layout.Equals(other);
        }

        #region relational operator overloads

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(FutureKey x, FutureKey y)
        {
            return x.Layout.CCode < y.Layout.CCode;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(FutureKey x, FutureKey y)
        {
            return x.Layout.CCode > y.Layout.CCode;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(FutureKey x, FutureKey y)
        {
            return x.Layout.CCode <= y.Layout.CCode;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(FutureKey x, FutureKey y)
        {
            return x.Layout.CCode >= y.Layout.CCode;
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static FutureKey GetCreateFutureKey(FutureKeyLayout key)
        {
            if (key.IsEmpty) return Empty;

            FutureKey cacheKey;
            if (KeyCache.TryGetValue(key, out cacheKey)) return cacheKey;

            bool lockTaken = false;

            try
            {
                keyCacheLock.Enter(ref lockTaken);

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
            catch (Exception e)
            {
                SRTrace.KeyErrors.TraceError(e, "GetCreateFutureKey: Cache Exception");
            }
            finally
            {
                if (lockTaken)
                {
                    keyCacheLock.Exit(false);
                }
                else
                {
                    SRTrace.KeyErrors.TraceError("GetCreateFutureKey: SpinLock Miss");
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