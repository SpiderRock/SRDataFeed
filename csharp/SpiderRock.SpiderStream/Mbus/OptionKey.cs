using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.SpiderStream.Diagnostics;
using SpiderRock.SpiderStream.Mbus.Layouts;

namespace SpiderRock.SpiderStream.Mbus;

public sealed class OptionKey : IComparable<OptionKey>, IEquatable<OptionKey>, IKeyLayoutEquatable<OptionKeyLayout>
{
    private static SpinLock keyCacheLock = new();

    private static readonly Dictionary<OptionKeyLayout, OptionKey> KeyCache = new();

    public static readonly OptionKey Empty = new(new OptionKeyLayout());

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

    public AssetType AssetType => Layout.AssetType;

    public TickerSrc TickerSrc => Layout.TickerSrc;

    public int TickerSrcInt => (int)Layout.TickerSrc;

    public string Root
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => root ??= Layout.Ticker.ToString();
    }

    public CallPut CallPut => Layout.CallPut;

    public char CallPutChar
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Layout.CallPut == CallPut.Call ? 'C' : 'P';
    }

    public double Strike => Layout.Strike;

    public int Year => Layout.Year;

    public int Month => Layout.Month;

    public int Day => Layout.Day;

    public bool IsValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (Layout.IsEmpty || Layout.Ticker.IsEmpty) return false;

            var yr = Year;
            var mn = Month;
            var dy = Day;

            var cp = CallPut;

            if (mn < 1 || mn > 12) return false;
            if (dy < 1 || dy > 31) return false;

            return cp == CallPut.Call || cp == CallPut.Put || cp == CallPut.Pair;
        }
    }

    public string Expiration
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => expiration ??= $"{Year:D4}-{Month:D2}-{Day:D2}";
    }

    public string OSIKey
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => osiKey ??= $"{Root,-6}{Year % 100:D2}{Month:D2}{Day:D2}{CallPutChar}{(int)(Strike * 1000D + 0.5) / 1000:00000}{(int)(Strike * 1000D + 0.5) % 1000:000}";
    }

    public string StringKey
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => stringKey ??= $"{Root}-{TickerSrc}-{AssetType}-{Year:D4}-{Month:D2}-{Day:D2}-{Strike}-{CallPutChar}";
    }

    public static string TabHeader => "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx\tokey_cp";

    public string TabRecord => tabRecord ??= $"{Root}\t{TickerSrc}\t{AssetType}\t{Year:D4}\t{Month:D2}\t{Day:D2}\t{(int)(Strike * 1000D + 0.5)}\t{CallPutChar}";

    public static string TabHeaderCP => "okey_rt\tokey_ts\tokey_at\tokey_yr\tokey_mn\tokey_dy\tokey_xx";

    public string TabRecordCP => tabRecordCP ??= $"{Root}\t{TickerSrc}\t{AssetType}\t{Year:D4}\t{Month:D2}\t{Day:D2}\t{(int)(Strike * 1000D + 0.5)}";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(OptionKey other)
    {
        if (other == null) return 1;
        return Layout.CompareTo(other.Layout);
    }

    public bool Equals(OptionKey other) => other != null && Layout.Equals(other.Layout);

    bool IKeyLayoutEquatable<OptionKeyLayout>.Equals(ref OptionKeyLayout other) => Layout.Equals(other);

    #region relational operator overloads

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(OptionKey x, OptionKey y) => x.Layout.Ticker < y.Layout.Ticker;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(OptionKey x, OptionKey y) => x.Layout.Ticker > y.Layout.Ticker;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(OptionKey x, OptionKey y) => x.Layout.Ticker <= y.Layout.Ticker;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(OptionKey x, OptionKey y) => x.Layout.Ticker >= y.Layout.Ticker;

    #endregion

    public override int GetHashCode() => Layout.GetHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static OptionKey GetCreateOptionKey(OptionKeyLayout key)
    {
        if (key.IsEmpty) return Empty;

        if (KeyCache.TryGetValue(key, out var cacheKey)) return cacheKey;

        var lockTaken = false;

        try
        {
            keyCacheLock.Enter(ref lockTaken);

            if (!KeyCache.TryGetValue(key, out cacheKey))
            {
                KeyCache[key] = cacheKey = new(key);
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
    public static explicit operator ExpiryKey(OptionKey key) => ExpiryKey.GetCreateExpiryKey((ExpiryKeyLayout)key.Layout);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => StringKey;

    public override bool Equals(object obj) => obj is OptionKey other && Equals(other);

    public static bool operator ==(OptionKey left, OptionKey right) => left?.Equals(right) ?? right is null;

    public static bool operator !=(OptionKey left, OptionKey right) => !(left == right);
}
