using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Layouts
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct FutureKeyLayout : IEquatable<FutureKeyLayout>, IComparable<FutureKeyLayout>
    {
        public FutureKeyLayout(AssetType assetType, TickerSrc tickerSrc, CCodeLayout ccode, int year, int month,
            int day)
        {
            unchecked
            {
                ccodeKey = new CCodeKeyLayout(assetType, tickerSrc, ccode);
                this.year = (byte) (year - 1900);
                this.month = (byte) month;
                this.day = (byte) day;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(FutureKeyLayout other)
        {
            fixed (FutureKeyLayout* pfself = &this)
            {
                var pself = (long*) pfself;
                var pother = (long*) &other;
                return *(pself) == *(pother) && *(pself + 1) == *(pother + 1);
            }
        }

        public int CompareTo(FutureKeyLayout other)
        {
            fixed (FutureKeyLayout* pfself = &this)
            {
                var pself = (long*) pfself;
                var pother = (long*) &other;
                int result = (*pself).CompareTo(*pother);
                return result != 0 ? result : (*(pself + 1)).CompareTo(*(pother + 1));
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is FutureKeyLayout && Equals((FutureKeyLayout) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                fixed (FutureKeyLayout* pself = &this)
                {
                    var p = (int*) pself;
                    int hashCode = *p;
                    hashCode = (hashCode*397) ^ *(p + 1);
                    hashCode = (hashCode*397) ^ *(p + 2);
                    hashCode = (hashCode*397) ^ *(p + 3);
                    return hashCode;
                }
            }
        }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ccodeKey.IsEmpty; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TrimEnd()
        {
            ccodeKey.TrimEnd();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(FutureKeyLayout left, FutureKeyLayout right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(FutureKeyLayout left, FutureKeyLayout right)
        {
            return !left.Equals(right);
        }

        // ReSharper disable FieldCanBeMadeReadOnly.Local
        private CCodeKeyLayout ccodeKey;
        private byte year;
        private byte month;
        private byte day;
        // ReSharper restore FieldCanBeMadeReadOnly.Local

        public AssetType AssetType
        {
            get { return ccodeKey.AssetType; }
        }

        public TickerSrc TickerSrc
        {
            get { return ccodeKey.TickerSrc; }
        }

        public CCodeLayout CCode
        {
            get { return ccodeKey.CCode; }
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
    }
}