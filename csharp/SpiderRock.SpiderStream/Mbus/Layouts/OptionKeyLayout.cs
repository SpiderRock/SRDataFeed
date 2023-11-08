using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.SpiderStream.Mbus.Layouts;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal readonly struct OptionKeyLayout : IEquatable<OptionKeyLayout>, IComparable<OptionKeyLayout>
{
    public readonly AssetType AssetType;
    public readonly TickerSrc TickerSrc;
    public readonly TickerLayout Ticker;
    private readonly byte year;
    public readonly byte Month;
    public readonly byte Day;
    public readonly double Strike;
    public readonly CallPut CallPut;

    public OptionKeyLayout(AssetType assetType, TickerSrc tickerSrc, TickerLayout root, int year, int month, int day, double strike, CallPut callPut)
    {
        AssetType = assetType;
        TickerSrc = tickerSrc;
        Ticker = root;
        this.year = (byte)unchecked(year - 1900);
        Month = (byte)month;
        Day = (byte)day;
        Strike = strike;
        CallPut = callPut;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(OptionKeyLayout other)
    {
        return Ticker.Equals(other.Ticker) &&
               Strike.Equals(other.Strike) &&
               Month == other.Month &&
               Day == other.Day &&
               year == other.year &&
               AssetType == other.AssetType &&
               TickerSrc == other.TickerSrc &&
               CallPut == other.CallPut;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(OptionKeyLayout other)
    {
        unchecked
        {
            var order = (byte)AssetType - (byte)other.AssetType;
            if (order != 0) return order;

            order = (byte)TickerSrc - (byte)other.TickerSrc;
            if (order != 0) return order;

            order = Ticker.CompareTo(other.Ticker);
            if (order != 0) return order;

            order = year - other.year;
            if (order != 0) return order;

            order = Month - other.Month;
            if (order != 0) return order;

            order = Day - other.Day;
            if (order != 0) return order;

            order = Strike.CompareTo(other.Strike);
            if (order != 0) return order;

            return (byte)CallPut - (byte)other.CallPut;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object obj) => obj is OptionKeyLayout other && Equals(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Ticker.GetHashCode();

            /* year - 8 bits
             * month - 4 bits
             * day - 5 bits
             * flags - 3 bits (current 2 used)
             * AssetType - 6 bits (currently 4 used)
             * TickerSrc - 6 bits (currently 5 used)
             */

            hashCode = hashCode * 397 ^ (year << 24 | Month << 20 | Day << 15 | (byte)CallPut << 12 | (byte)AssetType << 6 | (byte)TickerSrc);
            hashCode = hashCode * 397 ^ Strike.GetHashCode();
            return hashCode;
        }
    }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return AssetType == AssetType.None && TickerSrc == TickerSrc.None; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(OptionKeyLayout left, OptionKeyLayout right) => left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(OptionKeyLayout left, OptionKeyLayout right) => !left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator ExpiryKeyLayout(OptionKeyLayout okeyLayout)
    {
        return new ExpiryKeyLayout(
            okeyLayout.AssetType,
            okeyLayout.TickerSrc,
            okeyLayout.Ticker,
            okeyLayout.Year,
            okeyLayout.Month,
            okeyLayout.Day);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator TickerKeyLayout(OptionKeyLayout okeyLayout)
    {
        return new TickerKeyLayout(okeyLayout.AssetType, okeyLayout.TickerSrc, okeyLayout.Ticker);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator TickerLayout(OptionKeyLayout okeyLayout)
    {
        return okeyLayout.Ticker;
    }

    public int Year { get { return unchecked(year + 1900); } }

    public override string ToString()
    {
        return $"{Ticker}-{TickerSrc}-{AssetType}-{Year:D4}-{Month:D2}-{Day:D2}-{Strike}-{CallPut}";
    }
}
