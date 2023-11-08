using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.SpiderStream.Mbus.Layouts;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
internal struct DateKeyLayout : IEquatable<DateKeyLayout>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(DateKeyLayout other)
    {
        return _value == other._value;
    }

    public long Value { get { return _value; } }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object obj)
    {
        return obj is DateKeyLayout && Equals((DateKeyLayout)obj);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(DateKeyLayout x, DateKeyLayout y) => x._value < y._value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(DateKeyLayout x, DateKeyLayout y) => x._value <= y._value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(DateKeyLayout x, DateKeyLayout y) => x._value > y._value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(DateKeyLayout x, DateKeyLayout y) => x._value >= y._value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(DateKeyLayout left, DateKeyLayout right) => left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(DateKeyLayout left, DateKeyLayout right) => !left.Equals(right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator DateTime(DateKeyLayout value)
    {
        return new DateTime(value._value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator DateTimeLayout(DateKeyLayout value)
    {
        return new DateTimeLayout(value._value);
    }

    private readonly long _value;

    public DateKeyLayout(long data)
    {
        _value = data;
    }

    public bool IsEmpty { get { return _value == 0; } }
}
