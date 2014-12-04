using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Layouts
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct StockKeyLayout : IEquatable<StockKeyLayout>, IComparable<StockKeyLayout>
    {
        public StockKeyLayout(AssetType assetType, TickerSrc tickerSrc, TickerLayout ticker)
        {
            this.assetType = assetType;
            this.tickerSrc = tickerSrc;
            this.ticker = ticker;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(StockKeyLayout other)
        {
            return ticker == other.ticker &&
                   assetType == other.assetType && 
                   tickerSrc == other.tickerSrc;
        }

        public unsafe int CompareTo(StockKeyLayout other)
        {
            fixed (StockKeyLayout* pfself = &this)
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
            return obj is StockKeyLayout && Equals((StockKeyLayout) obj);
        }

        public override unsafe int GetHashCode()
        {
            unchecked
            {
                fixed (StockKeyLayout* pself = &this)
                {
                    var pint = (int*) pself;
                    int hashCode = *pint;
                    hashCode = (hashCode*397) ^ *(pint + 1);
                    hashCode = (hashCode*397) ^ *(pint + 2);
                    hashCode = (hashCode*397) ^ *(pint + 3);
                    return hashCode;
                }
            }
        }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return assetType == 0 && tickerSrc == 0; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(StockKeyLayout left, StockKeyLayout right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(StockKeyLayout left, StockKeyLayout right)
        {
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(StockKeyLayout x, TickerLayout y)
        {
            return x.Ticker.CompareTo(y) < 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(StockKeyLayout x, TickerLayout y)
        {
            return x.Ticker.CompareTo(y) > 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(StockKeyLayout x, TickerLayout y)
        {
            return x.Ticker.CompareTo(y) <= 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(StockKeyLayout x, TickerLayout y)
        {
            return x.Ticker.CompareTo(y) >= 0;
        }

        // ReSharper disable FieldCanBeMadeReadOnly.Local
        private AssetType assetType;
        private TickerSrc tickerSrc;
        private TickerLayout ticker;
        // ReSharper restore FieldCanBeMadeReadOnly.Local

        public AssetType AssetType
        {
            get { return assetType; }
        }

        public TickerSrc TickerSrc
        {
            get { return tickerSrc; }
        }

        public TickerLayout Ticker
        {
            get { return ticker; }
        }
    }
}