using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.SpiderStream.Diagnostics;
using SpiderRock.SpiderStream.Mbus.Layouts;

namespace SpiderRock.SpiderStream.Mbus;

public sealed class ExpiryKey : IComparable<ExpiryKey>, IEquatable<ExpiryKey>, IKeyLayoutEquatable<ExpiryKeyLayout>
{
    public static readonly int NowIndex = DateTime.Today.Year * 10000 + DateTime.Today.Month * 100 + DateTime.Today.Day;

    private static SpinLock keyCacheLock = new();
    private static readonly Dictionary<ExpiryKeyLayout, ExpiryKey> KeyCache = new();

    public static readonly ExpiryKey Empty = new(new ExpiryKeyLayout());

    internal readonly ExpiryKeyLayout Layout;
    private string ccode;
    private string expiration;
    private string stringKey, tabRecord;

    private ExpiryKey(ExpiryKeyLayout layout)
    {
        Layout = layout;
    }

    public AssetType AssetType => Layout.AssetType;

    public TickerSrc TickerSrc => Layout.TickerSrc;

    public int TickerSrcInt => (byte)Layout.TickerSrc;

    public string CCode => ccode ??= Layout.Ticker.ToString();

    public int Year => Layout.Year;

    public int Month => Layout.Month;

    public int Day => Layout.Day;

    public DateTime Date => new(Layout.Year, Layout.Month, Layout.Day);

    public bool IsValid
    {
        get
        {
            if (Layout.IsEmpty || Layout.Ticker.IsEmpty) return false;

            var yr = Year;
            var mn = Month;
            var dy = Day;

            if (mn < 1 || mn > 12) return false;
            if (dy < 1 || dy > 31) return false;

            return true;
        }
    }

    public int ExpIndex => Year * 10000 + Month * 100 + Day;

    public string Expiration => expiration ??= $"{Year:D4}-{Month:D2}-{Day:D2}";

    public bool IsExpired => ExpIndex < NowIndex;

    public string StringKey => stringKey ??= $"{CCode}-{TickerSrc}-{AssetType}-{Year:D4}-{Month:D2}-{Day:D2}";

    public string TabRecord => tabRecord ??= $"{CCode}\t{TickerSrc}\t{AssetType}\t{Year:D4}\t{Month:D2}\t{Day:D2}";

    public static string TabHeader => "fkey_rt\tfkey_ts\tfkey_at\tfkey_yr\tfkey_mn\tfkey_dy";

    public int CompareTo(ExpiryKey other)
    {
        if (other == null) return 1;
        return Layout.CompareTo(other.Layout);
    }

    public override int GetHashCode() => Layout.GetHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(ExpiryKey other) => other != null && Layout.Equals(other.Layout);

    bool IKeyLayoutEquatable<ExpiryKeyLayout>.Equals(ref ExpiryKeyLayout other) => Layout.Equals(other);

    #region relational operator overloads

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ExpiryKey x, ExpiryKey y) => x.Layout.Ticker < y.Layout.Ticker;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ExpiryKey x, ExpiryKey y) => x.Layout.Ticker > y.Layout.Ticker;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ExpiryKey x, ExpiryKey y) => x.Layout.Ticker <= y.Layout.Ticker;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ExpiryKey x, ExpiryKey y) => x.Layout.Ticker >= y.Layout.Ticker;

    #endregion

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ExpiryKey GetCreateExpiryKey(ExpiryKeyLayout key)
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

    public override string ToString() => StringKey;

    public override bool Equals(object obj) => obj is ExpiryKey other && Equals(other);

    public static bool operator ==(ExpiryKey left, ExpiryKey right) => left?.Equals(right) ?? right is null;

    public static bool operator !=(ExpiryKey left, ExpiryKey right) => !(left == right);
}
