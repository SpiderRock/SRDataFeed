using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Messaging.Keys
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OptionKeyLayout : IEquatable<OptionKeyLayout>, IComparable<OptionKeyLayout>
    {
        public static readonly int NowIndex = DateTime.Today.Year * 10000 + DateTime.Today.Month * 100 + DateTime.Today.Day;

        public OptionKeyLayout(AssetType assetType, TickerSrc tickerSrc, RootLayout root, int year, int month,
                               int day, double strike, CallPut callPut)
        {
            unchecked
            {
                rootKey = new RootKeyLayout(assetType, tickerSrc, root);
                this.year = (byte)(year - 1900);
                this.month = (byte)month;
                this.day = (byte)day;
                this.strike = (int)(strike * 1000);
                this.callPut = callPut;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe bool Equals(OptionKeyLayout other)
        {
            fixed (OptionKeyLayout* pfself = &this)
            {
                var pself = (long*)pfself;
                var pother = (long*)&other;
                return *(pself) == *(pother) && *(pself + 1) == *(pother + 1);
            }
        }

        public unsafe int CompareTo(OptionKeyLayout other)
        {
            fixed (OptionKeyLayout* pfself = &this)
            {
                var pself = (long*)pfself;
                var pother = (long*)&other;
                int result = (*pself).CompareTo(*pother);
                return result != 0 ? result : (*(pself + 1)).CompareTo(*(pother + 1));
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is OptionKeyLayout && Equals((OptionKeyLayout)obj);
        }

        public override unsafe int GetHashCode()
        {
            unchecked
            {
                fixed (OptionKeyLayout* pself = &this)
                {
                    var p = (int*)pself;
                    int hashCode = *p;
                    hashCode = (hashCode * 397) ^ *(p + 1);
                    hashCode = (hashCode * 397) ^ *(p + 2);
                    hashCode = (hashCode * 397) ^ *(p + 3);
                    return hashCode;
                }
            }
        }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return AssetType == AssetType.None && TickerSrc == TickerSrc.None; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TrimEnd()
        {
            rootKey.TrimEnd();
        }

        public bool IsValid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (IsEmpty || Root.IsEmpty) return false;

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

        public int ExpIndex
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return unchecked(Year * 10000 + Month * 100 + Day); }
        }

        public bool IsExpired
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (ExpIndex < NowIndex); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(OptionKeyLayout left, OptionKeyLayout right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(OptionKeyLayout left, OptionKeyLayout right)
        {
            return !left.Equals(right);
        }

        // ReSharper disable FieldCanBeMadeReadOnly.Local
        private RootKeyLayout rootKey;
        private byte year;
        private byte month;
        private byte day;
        private int strike;
        private CallPut callPut;
        // ReSharper restore FieldCanBeMadeReadOnly.Local

        public AssetType AssetType
        {
            get { return rootKey.AssetType; }
        }

        public TickerSrc TickerSrc
        {
            get { return rootKey.TickerSrc; }
        }

        public RootLayout Root
        {
            get { return rootKey.Root; }
        }

        public int Year
        {
            get
            {
                unchecked
                {
                    return year + 1900;
                }
            }
        }

        public int Month
        {
            get { return month; }
        }

        public int Day
        {
            get { return day; }
        }

        public double Strike
        {
            get { return Math.Round(0.001 * strike, 3); }
            set { strike = (int) (value*1000); }
        }

        public int StrikeInt
        {
            get { return strike; }
            set { strike = value; }
        }

        public CallPut CallPut
        {
            get { return callPut; }
            set { callPut = value; }
        }
    }
}