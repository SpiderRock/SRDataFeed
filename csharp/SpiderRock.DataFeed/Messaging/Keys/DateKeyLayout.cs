using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Messaging.Keys
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    internal struct DateKeyLayout : IEquatable<DateKeyLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(DateKeyLayout other)
        {
            return value == other.value;
        }

        public long Value
        {
            get { return value; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            return obj is DateKeyLayout && Equals((DateKeyLayout) obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(DateKeyLayout x, DateKeyLayout y)
        {
            return (x.value < y.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(DateKeyLayout x, DateKeyLayout y)
        {
            return (x.value <= y.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(DateKeyLayout x, DateKeyLayout y)
        {
            return (x.value > y.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(DateKeyLayout x, DateKeyLayout y)
        {
            return (x.value >= y.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(DateKeyLayout left, DateKeyLayout right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(DateKeyLayout left, DateKeyLayout right)
        {
            return !left.Equals(right);
        }

        private readonly long value;

        public DateKeyLayout(long data)
        {
            value = data;
        }
    }
}