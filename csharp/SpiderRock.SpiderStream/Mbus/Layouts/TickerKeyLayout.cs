using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.SpiderStream.Mbus.Layouts;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal readonly struct TickerKeyLayout : IEquatable<TickerKeyLayout>, IComparable<TickerKeyLayout>
{
    public readonly AssetType AssetType;
    public readonly TickerSrc TickerSrc;
    public readonly TickerLayout Ticker;

    public TickerKeyLayout(AssetType assetType, TickerSrc tickerSrc, TickerLayout ticker)
    {
        AssetType = assetType;
        TickerSrc = tickerSrc;
        Ticker = ticker;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(TickerKeyLayout other) =>
        Ticker == other.Ticker &&
               AssetType == other.AssetType &&
               TickerSrc == other.TickerSrc;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(TickerKeyLayout other)
    {
        var order = (byte)AssetType - (byte)other.AssetType;
        if (order != 0) return order;

        order = (byte)TickerSrc - (byte)other.TickerSrc;
        if (order != 0) return order;

        return Ticker.CompareTo(other.Ticker);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is TickerKeyLayout && Equals((TickerKeyLayout)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Ticker.GetHashCode();
            hashCode = hashCode * 397 ^ ((byte)TickerSrc << 8 | (byte)AssetType);
            return hashCode;
        }
    }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return AssetType == 0 && TickerSrc == 0; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(TickerKeyLayout left, TickerKeyLayout right) => left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(TickerKeyLayout left, TickerKeyLayout right) => !left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(TickerKeyLayout x, TickerLayout y) => x.Ticker.CompareTo(y) < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(TickerKeyLayout x, TickerLayout y) => x.Ticker.CompareTo(y) > 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(TickerKeyLayout x, TickerLayout y) => x.Ticker.CompareTo(y) <= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(TickerKeyLayout x, TickerLayout y) => x.Ticker.CompareTo(y) >= 0;
}
