using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Messaging
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SourceId : IEquatable<SourceId>
    {
        public static readonly SourceId MaxValue = ushort.MaxValue;
        public static readonly SourceId MinValue = ushort.MinValue;
        public static readonly SourceId Empty = 0;

        private readonly ushort value;

        public SourceId(ushort value)
        {
            this.value = value;
        }

        #region Equality members

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(SourceId other)
        {
            return value.Equals(other.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is SourceId && Equals((SourceId)obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(SourceId left, SourceId right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(SourceId left, SourceId right)
        {
            return !left.Equals(right);
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(SourceId left, SourceId right)
        {
            return left.value.CompareTo(right.value) > 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(SourceId left, SourceId right)
        {
            return left.value.CompareTo(right.value) >= 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(SourceId left, SourceId right)
        {
            return left.value.CompareTo(right.value) < 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(SourceId left, SourceId right)
        {
            return left.value.CompareTo(right.value) <= 0;
        }

        public bool IsValid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return value > 0; }
        }        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort(SourceId sourceId)
        {
            return sourceId.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short(SourceId sourceId)
        {
            return (short) sourceId.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(SourceId sourceId)
        {
            return sourceId.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SourceId(ushort value)
        {
            return new SourceId(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SourceId(int value)
        {
            return new SourceId((ushort) value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SourceId(uint value)
        {
            return new SourceId((ushort) value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SourceId(ulong value)
        {
            return new SourceId((ushort) value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SourceId(long value)
        {
            return new SourceId((ushort) value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse(string s, out SourceId result)
        {
            ushort v;
            if (ushort.TryParse(s, out v))
            {
                result = v;
                return true;
            }
            result = 0;
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }

}