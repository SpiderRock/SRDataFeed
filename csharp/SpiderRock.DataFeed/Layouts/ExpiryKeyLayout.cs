using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Layouts
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct ExpiryKeyLayout : IEquatable<ExpiryKeyLayout>, IComparable<ExpiryKeyLayout>
    {
        public readonly AssetType AssetType;
        public readonly TickerSrc TickerSrc;
        public readonly TickerLayout Ticker;
        private readonly byte year;
        public readonly byte Month;
        public readonly byte Day;

        public ExpiryKeyLayout(AssetType assetType, TickerSrc tickerSrc, TickerLayout ccode, int year, int month, int day)
        {
            unchecked
            {
                AssetType = assetType;
                TickerSrc = tickerSrc;
                Ticker = ccode;
                this.year = (byte) (year - 1900);
                Month = (byte) month;
                Day = (byte) day;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ExpiryKeyLayout other)
        {
            return Ticker.Equals(other.Ticker) &&
                   Month == other.Month &&
                   Day == other.Day &&
                   year == other.year &&
                   AssetType == other.AssetType &&
                   TickerSrc == other.TickerSrc;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(ExpiryKeyLayout other)
        {
            int order = (byte) AssetType - (byte) other.AssetType;
            if (order != 0) return order;

            order = (byte) TickerSrc - (byte) other.TickerSrc;
            if (order != 0) return order;

            order = Ticker.CompareTo(other.Ticker);
            if (order != 0) return order;

            order = year - other.year;
            if (order != 0) return order;

            order = Month - other.Month;
            if (order != 0) return order;

            return Day - other.Day;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ExpiryKeyLayout && Equals((ExpiryKeyLayout) obj);
        }

        public override int GetHashCode()
        {
            return unchecked((Ticker.GetHashCode() * 397) ^ ((year << 24) | (Month << 17) | (Day << 9) | ((byte) AssetType << 5) | (byte) TickerSrc));
        }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return AssetType == 0 && TickerSrc == 0; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(ExpiryKeyLayout left, ExpiryKeyLayout right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ExpiryKeyLayout left, ExpiryKeyLayout right)
        {
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator TickerKeyLayout(ExpiryKeyLayout fkeyLayout)
        {
            return new TickerKeyLayout(fkeyLayout.AssetType, fkeyLayout.TickerSrc, fkeyLayout.Ticker);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator TickerLayout(ExpiryKeyLayout fkeyLayout)
        {
            return fkeyLayout.Ticker;
        }

        public int Year { get { return unchecked(year + 1900); } }
    }
}