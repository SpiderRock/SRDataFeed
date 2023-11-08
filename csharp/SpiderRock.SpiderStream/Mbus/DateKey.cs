using System;
using System.Collections.Generic;
using System.Threading;
using SpiderRock.SpiderStream.Diagnostics;
using SpiderRock.SpiderStream.Mbus.Layouts;

namespace SpiderRock.SpiderStream.Mbus;

public class DateKey : IEquatable<DateKey>, IKeyLayoutEquatable<DateKeyLayout>
{
    public static readonly DateKey Empty = new(new DateKeyLayout(0));

    private static readonly Dictionary<DateKeyLayout, DateKey> KeyCache = new();
    private static SpinLock keyCacheLock = new();

    internal readonly DateKeyLayout Layout;

    private readonly string dttmString;
    private readonly DateTime dttm;

    public DateTime DateTime => dttm;

    private DateKey(DateKeyLayout layout)
    {
        Layout = layout;
        dttm = new DateTime(Layout.Value);
        dttmString = $"{dttm.Year:D4}-{dttm.Month:D2}-{dttm.Day:D2}";
    }

    internal static DateKey GetCreateDateKey(DateKeyLayout key)
    {
        if (KeyCache.TryGetValue(key, out var cacheKey)) return cacheKey;

        var lockTaken = false;

        try
        {
            keyCacheLock.Enter(ref lockTaken);

            if (!KeyCache.TryGetValue(key, out cacheKey))
            {
                KeyCache[key] = cacheKey = new DateKey(key);
            }

            return cacheKey;
        }
        catch (Exception e)
        {
            SRTrace.KeyErrors.TraceError(e, "GetCreateDateKey: Cache Exception");
        }
        finally
        {
            if (lockTaken)
            {
                keyCacheLock.Exit(false);
            }
            else
            {
                SRTrace.KeyErrors.TraceError("GetCreateDateKey: SpinLock Miss");
            }
        }

        return Empty;
    }

    public static bool operator <(DateKey x, DateKey y) => x.Layout < y.Layout;

    public static bool operator <=(DateKey x, DateKey y) => x.Layout <= y.Layout;

    public static bool operator >(DateKey x, DateKey y) => x.Layout > y.Layout;

    public static bool operator >=(DateKey x, DateKey y) => x.Layout >= y.Layout;

    public static bool operator ==(DateKey x, DateKey y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
        return x.Layout.Equals(y.Layout);
    }

    public static bool operator !=(DateKey x, DateKey y) => !(x == y);

    public override bool Equals(object b)
    {
        var bb = b as DateKey;
        return bb != null && Layout == bb.Layout;
    }

    public bool Equals(DateKey b) => Layout == b.Layout;

    public override int GetHashCode() => Layout.GetHashCode();

    bool IKeyLayoutEquatable<DateKeyLayout>.Equals(ref DateKeyLayout other) => Layout.Equals(other);

    public override string ToString() => dttmString;
}
