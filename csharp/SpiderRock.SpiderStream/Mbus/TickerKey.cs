using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using SpiderRock.SpiderStream.Diagnostics;
using SpiderRock.SpiderStream.Mbus.Layouts;

namespace SpiderRock.SpiderStream.Mbus;

public sealed class TickerKey : IComparable<TickerKey>, IEquatable<TickerKey>, IKeyLayoutEquatable<TickerKeyLayout>
{
    private static SpinLock keyCacheLock = new();
    private static readonly Dictionary<TickerKeyLayout, TickerKey> KeyCache = new();

    public static readonly TickerKey Empty = new(new TickerKeyLayout());

    internal readonly TickerKeyLayout Layout;
    private readonly bool is4Letter;
    private readonly string ticker;

    private string stringKey, tabRecord;

    private TickerKey(TickerKeyLayout layout)
    {
        Layout = layout;

        ticker = layout.Ticker.ToString();
        is4Letter = ticker.Length > 3;
    }

    public AssetType AssetType => Layout.AssetType;

    public TickerSrc TickerSrc => Layout.TickerSrc;

    public int TickerSrcInt => (int)Layout.TickerSrc;

    public string Ticker => ticker;

    public bool IsValid => TickerSrc != TickerSrc.None && AssetType != AssetType.None && !Layout.Ticker.IsEmpty;

    public bool Is4Letter => is4Letter;

    public string StringKey => stringKey ??= $"{Ticker}-{TickerSrc}-{AssetType}";

    public string TabRecord => tabRecord ??= $"{Ticker}\t{TickerSrc}\t{AssetType}";

    public static string TabHeader => "skey_tk\tskey_ts\tskey_at";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(TickerKey b) => Layout.CompareTo(b.Layout);

    public override int GetHashCode() => Layout.GetHashCode();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(TickerKey other) => other != null && Layout.Equals(other.Layout);

    bool IKeyLayoutEquatable<TickerKeyLayout>.Equals(ref TickerKeyLayout other) => Layout.Equals(other);

    #region relational operator overloads

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(TickerKey x, TickerKey y) => x.Layout.Ticker < y.Layout.Ticker;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(TickerKey x, TickerKey y) => x.Layout.Ticker > y.Layout.Ticker;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(TickerKey x, TickerKey y) => x.Layout.Ticker <= y.Layout.Ticker;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(TickerKey x, TickerKey y) => x.Layout.Ticker >= y.Layout.Ticker;

    #endregion

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static TickerKey GetCreateTickerKey(TickerKeyLayout key)
    {
        if (key.IsEmpty) return Empty;

        if (KeyCache.TryGetValue(key, out var cacheKey)) return cacheKey;

        var lockTaken = false;

        try
        {
            keyCacheLock.Enter(ref lockTaken);

            if (!KeyCache.TryGetValue(key, out cacheKey))
            {
                KeyCache[key] = cacheKey = new TickerKey(key);
            }

            return cacheKey;
        }
        catch (Exception e)
        {
            SRTrace.KeyErrors.TraceError(e, "GetCreateTickerKey: Cache Exception");
        }
        finally
        {
            if (lockTaken)
            {
                keyCacheLock.Exit(false);
            }
            else
            {
                SRTrace.KeyErrors.TraceError("GetCreateTickerKey: SpinLock Miss");
            }
        }

        return Empty;
    }

    public override string ToString() => StringKey;

    public override bool Equals(object obj) => obj is TickerKey other && Equals(other);

    public static bool operator ==(TickerKey left, TickerKey right) => left?.Equals(right) ?? right is null;

    public static bool operator !=(TickerKey left, TickerKey right) => !(left == right);
}
