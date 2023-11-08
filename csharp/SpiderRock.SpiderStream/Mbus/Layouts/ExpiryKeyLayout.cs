using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.SpiderStream.Mbus.Layouts;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal readonly struct ExpiryKeyLayout : IEquatable<ExpiryKeyLayout>, IComparable<ExpiryKeyLayout>
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
            this.year = (byte)(year - 1900);
            Month = (byte)month;
            Day = (byte)day;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(ExpiryKeyLayout other) =>
        Ticker.Equals(other.Ticker) &&
        Month == other.Month &&
        Day == other.Day &&
        year == other.year &&
        AssetType == other.AssetType &&
        TickerSrc == other.TickerSrc;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(ExpiryKeyLayout other)
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

        return Day - other.Day;
    }

    public override bool Equals(object obj) => obj is ExpiryKeyLayout other && Equals(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => unchecked(Ticker.GetHashCode() * 397 ^ (year << 24 | Month << 17 | Day << 9 | (byte)AssetType << 5 | (byte)TickerSrc));

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return AssetType == 0 && TickerSrc == 0; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ExpiryKeyLayout left, ExpiryKeyLayout right) => left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ExpiryKeyLayout left, ExpiryKeyLayout right) => !left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator TickerKeyLayout(ExpiryKeyLayout fkeyLayout) => new(fkeyLayout.AssetType, fkeyLayout.TickerSrc, fkeyLayout.Ticker);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator TickerLayout(ExpiryKeyLayout fkeyLayout) => fkeyLayout.Ticker;

    public int Year { get { return unchecked(year + 1900); } }
}
