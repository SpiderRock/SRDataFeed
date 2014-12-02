using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Messaging.Keys
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct TimeSpanLayout : IEquatable<TimeSpanLayout>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(TimeSpanLayout other)
        {
            return data == other.data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            return obj is TimeSpanLayout && Equals((TimeSpanLayout) obj);
        }

        public override int GetHashCode()
        {
            return data.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(TimeSpanLayout left, TimeSpanLayout right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(TimeSpanLayout left, TimeSpanLayout right)
        {
            return !left.Equals(right);
        }

        private readonly long data;

        public TimeSpanLayout(long data)
        {
            this.data = data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator TimeSpanLayout(TimeSpan value)
        {
            return new TimeSpanLayout(value.Ticks);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator TimeSpan(TimeSpanLayout value)
        {
            return new TimeSpan(value.data);
        }
    }
}