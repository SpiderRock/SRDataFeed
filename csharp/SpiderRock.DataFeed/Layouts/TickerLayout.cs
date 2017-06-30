using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Layouts
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal unsafe struct TickerLayout : IEquatable<TickerLayout>, IComparable<TickerLayout>, IEquatable<string>
    {
        private readonly long data1;
        private readonly int data2;

        public override bool Equals(object obj)
        {
            return obj is TickerLayout && Equals((TickerLayout)obj);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return Value;
        }

        public override int GetHashCode()
        {
            int hashCode = -2128831035;
            unchecked
            {
                hashCode = hashCode * 1000193 ^ data1.GetHashCode();
                hashCode = hashCode * 1000193 ^ data2;
                return hashCode;
            }
        }

        public int Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                unchecked
                {
                    fixed (TickerLayout* selfPtr = &this)
                    {
                        byte* charsPtr = (byte*)selfPtr;
                        int s = 0, e = 12;

                        while (s < e)
                        {
                            int m = s + (e - s) / 2;

                            if (charsPtr[m] == 0)
                            {
                                e = m;
                            }
                            else
                            {
                                s = m + 1;
                            }
                        }

                        return s;
                    }
                }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (value >= 12) return;
                fixed (TickerLayout* selfPtr = &this)
                {
                    _Zero(value + (byte*)selfPtr, 12 - value);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(TickerLayout other)
        {
            unchecked
            {
                int x, y, r;
                long x64, y64;
                x64 = data1; y64 = other.data1;
                if (x64 != y64)
                {
                    x = (int)(x64 & 0x00000000000000ff); y = (int)(y64 & 0x00000000000000ff);
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                    x64 >>= 8; y64 >>= 8;
                    x = (int)(x64 & 0x00000000000000ff); y = (int)(y64 & 0x00000000000000ff);
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                    x64 >>= 8; y64 >>= 8;
                    x = (int)(x64 & 0x00000000000000ff); y = (int)(y64 & 0x00000000000000ff);
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                    x64 >>= 8; y64 >>= 8;
                    x = (int)(x64 & 0x00000000000000ff); y = (int)(y64 & 0x00000000000000ff);
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                    x64 >>= 8; y64 >>= 8;
                    x = (int)(x64 & 0x00000000000000ff); y = (int)(y64 & 0x00000000000000ff);
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                    x64 >>= 8; y64 >>= 8;
                    x = (int)(x64 & 0x00000000000000ff); y = (int)(y64 & 0x00000000000000ff);
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                    x64 >>= 8; y64 >>= 8;
                    x = (int)(x64 & 0x00000000000000ff); y = (int)(y64 & 0x00000000000000ff);
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                    x64 >>= 8; y64 >>= 8;
                    x = (int)(x64 & 0x00000000000000ff); y = (int)(y64 & 0x00000000000000ff);
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                }
                int x32 = data2, y32 = other.data2;
                if (x32 != y32)
                {
                    x = x32 & 0x000000ff; y = y32 & 0x000000ff;
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                    x32 >>= 8; y32 >>= 8;
                    x = x32 & 0x000000ff; y = y32 & 0x000000ff;
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                    x32 >>= 8; y32 >>= 8;
                    x = x32 & 0x000000ff; y = y32 & 0x000000ff;
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                    x32 >>= 8; y32 >>= 8;
                    x = x32 & 0x000000ff; y = y32 & 0x000000ff;
                    if ((r = x - y) != 0) return r;
                    if (x == 0) return 0;
                }
                return 0;
            }
        }

        public bool Equals(TickerLayout other)
        {
            if (data1 != other.data1) return false; if (data1 == 0) return true;
            return data2 == other.data2;
        }


        public int MaxLength { get { return 12; } }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return (byte)data1 == 0; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(string value)
        {
            unchecked
            {
                fixed (TickerLayout* selfPtr = &this)
                {
                    if (string.IsNullOrEmpty(value)) return *(byte*)selfPtr == 0;

                    byte* charsPtr = (byte*)selfPtr;

                    fixed (char* valuePtr = value)
                    {
                        int i = 0;
                        for (; i < 12; i++)
                        {
                            int mine = charsPtr[i];
                            int theirs = valuePtr[i];
                            if (mine != theirs) return false;
                            if (mine == 0) break;
                        }
                        return i == value.Length;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool StartsWith(string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value == string.Empty) return true;
            if (value.Length > 12) return false;

            unchecked
            {
                fixed (TickerLayout* selfPtr = &this)
                fixed (char* valuePtr = value)
                {
                    byte* charsPtr = (byte*)selfPtr;
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (charsPtr[i] != valuePtr[i]) return false;
                    }
                    return true;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TrimEnd()
        {
            unchecked
            {
                fixed (TickerLayout* selfPtr = &this)
                {
                    byte* charsPtr = (byte*)selfPtr;
                    for (int i = 11; i >= 0; i--)
                    {
                        var c = charsPtr[i];
                        if (c == 0) continue;
                        if (c == ' ')
                        {
                            charsPtr[i] = 0;
                            continue;
                        }
                        break;
                    }
                }
            }
        }

        public string Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (TickerLayout* selfPtr = &this)
                {
                    byte* charsPtr = (byte*)selfPtr;
                    if (charsPtr[0] == 0) return string.Empty;
                    if (charsPtr[11] == 0) return new string((sbyte*)selfPtr);
                    return new string((sbyte*)selfPtr, 0, 12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                unchecked
                {
                    fixed (TickerLayout* selfPtr = &this)
                    {
                        if (string.IsNullOrEmpty(value))
                        {
                            _Zero((byte*)selfPtr, 12);
                            return;
                        }

                        byte* charsPtr = (byte*)selfPtr;

                        fixed (char* valuePtr = value)
                        {
                            if (value.Length >= 12)
                            {
                                for (int i = 0; i < 12; i++)
                                {
                                    charsPtr[i] = (byte)valuePtr[i];
                                }
                            }
                            else
                            {
                                int i = 0;
                                for (; i < value.Length; i++)
                                {
                                    charsPtr[i] = (byte)valuePtr[i];
                                }
                                _Zero(charsPtr + i, 12 - value.Length);
                            }
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void _Copy(byte* dest, byte* src, int len)
        {
            switch (len)
            {
                case 12:
                    *(long*)dest = *(long*)src;
                    *(int*)(dest + 8) = *(int*)(src + 8);
                    return;
                case 1:
                    *dest = *src;
                    return;
                case 2:
                    *(short*)dest = *(short*)src;
                    return;
                case 3:
                    *(short*)dest = *(short*)src;
                    *(dest + 2) = *(src + 2);
                    return;
                case 4:
                    *(int*)dest = *(int*)src;
                    return;
                case 5:
                    *(int*)dest = *(int*)src;
                    *(dest + 4) = *(src + 4);
                    return;
                case 6:
                    *(int*)dest = *(int*)src;
                    *(short*)(dest + 4) = *(short*)(src + 4);
                    return;
                case 7:
                    *(int*)dest = *(int*)src;
                    *(short*)(dest + 4) = *(short*)(src + 4);
                    *(dest + 6) = *(src + 6);
                    return;
                case 8:
                    *(long*)dest = *(long*)src;
                    return;
                case 9:
                    *(long*)dest = *(long*)src;
                    *(dest + 8) = *(src + 8);
                    return;
                case 10:
                    *(long*)dest = *(long*)src;
                    *(short*)(dest + 8) = *(short*)(src + 8);
                    return;
                case 11:
                    *(long*)dest = *(long*)src;
                    *(short*)(dest + 8) = *(short*)(src + 8);
                    *(dest + 10) = *(src + 10);
                    return;

            }

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void _Zero(byte* dest, int len)
        {
            switch (len)
            {
                case 12:
                    *(long*)dest = 0;
                    *(int*)(dest + 8) = 0;
                    return;
                case 11:
                    *(long*)dest = 0;
                    *(short*)(dest + 8) = 0;
                    *(dest + 10) = 0;
                    return;
                case 10:
                    *(long*)dest = 0;
                    *(short*)(dest + 8) = 0;
                    return;
                case 9:
                    *(long*)dest = 0;
                    *(dest + 8) = 0;
                    return;
                case 8:
                    *(long*)dest = 0;
                    return;
                case 7:
                    *(int*)dest = 0;
                    *(short*)(dest + 4) = 0;
                    *(dest + 6) = 0;
                    return;
                case 6:
                    *(int*)dest = 0;
                    *(short*)(dest + 4) = 0;
                    return;
                case 5:
                    *(int*)dest = 0;
                    *(dest + 4) = 0;
                    return;
                case 4:
                    *(int*)dest = 0;
                    return;
                case 3:
                    *(short*)dest = 0;
                    *(dest + 2) = 0;
                    return;
                case 2:
                    *(short*)dest = 0;
                    return;
                case 1:
                    *dest = 0;
                    return;

            }

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CopyTo(void* buffer, int maxLength)
        {
            int length = maxLength >= 12 ? 12 : maxLength;

            fixed (TickerLayout* selfPtr = &this)
            {
                _Copy((byte*)buffer, (byte*)selfPtr, length);
            }

            return length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CopyFrom(void* buffer, int maxLength)
        {
            if (maxLength >= 12)
            {
                fixed (TickerLayout* selfPtr = &this)
                {
                    _Copy((byte*)selfPtr, (byte*)buffer, 12);
                }

                return 12;
            }
            else
            {
                fixed (TickerLayout* selfPtr = &this)
                {
                    _Copy((byte*)selfPtr, (byte*)buffer, maxLength);
                    _Zero(maxLength + (byte*)selfPtr, 12 - maxLength);
                }

                return maxLength;
            }
        }

        #region Overloaded operators (cast to string, cast from string, == != > < <= >=)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator string(TickerLayout value)
        {
            return value.Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator TickerLayout(string value)
        {
            return string.IsNullOrEmpty(value) ? new TickerLayout() : new TickerLayout { Value = value };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(TickerLayout left, TickerLayout right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(TickerLayout left, TickerLayout right)
        {
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(TickerLayout x, TickerLayout y)
        {
            return x.CompareTo(y) < 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(TickerLayout x, TickerLayout y)
        {
            return x.CompareTo(y) > 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(TickerLayout x, TickerLayout y)
        {
            return x.CompareTo(y) <= 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(TickerLayout x, TickerLayout y)
        {
            return x.CompareTo(y) >= 0;
        }

        #endregion
    }
}