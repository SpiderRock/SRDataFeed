using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace SpiderRock.SpiderStream.Mbus.Layouts;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
internal struct DateTimeLayout : IEquatable<DateTimeLayout>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(DateTimeLayout other)
    {
        return _data == other._data;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object obj)
    {
        return obj is DateTimeLayout && Equals((DateTimeLayout)obj);
    }

    public override int GetHashCode()
    {
        return _data.GetHashCode();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(DateTimeLayout left, DateTimeLayout right) => left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(DateTimeLayout left, DateTimeLayout right) => !left.Equals(right);

    private readonly long _data;

    public DateTimeLayout(long data)
    {
        _data = data;
    }

    public long Ticks { get { return _data; } }

    public bool IsEmpty { get { return _data == 0; } }

    public int Microseconds { get { return (int)(_data / 10L % 1000000L); } }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator DateTimeLayout(DateTime value)
    {
        return new DateTimeLayout(value.Ticks);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator DateTime(DateTimeLayout value)
    {
        return new DateTime(value._data);
    }
}

internal static class DateTimeLayoutTabRecordExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AppendInTabRecordFormat(this StringBuilder builder, DateTimeLayout value)
    {
        var dttm = (DateTime)value;
        builder.AppendFormat("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}.{6:D3}", dttm.Year, dttm.Month, dttm.Day, dttm.Hour,
                             dttm.Minute, dttm.Second, dttm.Millisecond);
    }
}