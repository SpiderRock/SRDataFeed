using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace SpiderRock.DataFeed.Messaging.Keys
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct TickerLayout :
        IEquatable<TickerLayout>,
        IEquatable<string>,
        IComparable<TickerLayout>
    {
        // ReSharper disable InconsistentNaming
        private const int MAX_LENGTH = 14;
        // ReSharper restore InconsistentNaming

        #region string caching

        private static readonly Dictionary<TickerLayout, string> StringCache =
            new Dictionary<TickerLayout, string>();

        private static SpinLock StringCacheLock;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetFromCache(TickerLayout ticker)
        {
            string value;
            if (StringCache.TryGetValue(ticker, out value)) return value;

            bool lockTaken = false;

            try
            {
                StringCacheLock.Enter(ref lockTaken);

                if (StringCache.TryGetValue(ticker, out value)) return value;

                StringCache[ticker] = value = new string((sbyte*) &ticker, 0, ticker.Length, Encoding.ASCII);
            }
            finally
            {
                if (lockTaken) StringCacheLock.Exit(false);
            }

            return value;
        }

        #endregion

        private fixed byte chars[MAX_LENGTH];

        public TickerLayout(string value)
        {
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
        }

        public int MaxLength
        {
            get { return MAX_LENGTH; }
        }

        public int Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (byte* pfchars = chars)
                {
                    if (*(pfchars + 4) == 0)
                    {
                        // 80% of all tickers have a length of 4 or 3
                        // so we optimize for these cases
                        if (*(pfchars + 3) != 0) return 4;
                        if (*(pfchars + 2) != 0) return 3;

                        if (*(pfchars + 1) != 0) return 2;
                        if (*pfchars != 0) return 1;
                        return 0;
                    }
                    if (*(pfchars + 5) == 0) return 5;
                    for (int i = 6; i < MAX_LENGTH; i++)
                    {
                        if (*(pfchars + i) == 0) return i;
                    }
                    return MAX_LENGTH;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TrimEnd()
        {
            unchecked
            {
                fixed (byte* begPtr = chars)
                {
                    byte* endPtr = begPtr + MAX_LENGTH - 1;

                    for (int i = 0; i < MAX_LENGTH; i++)
                    {
                        if (*endPtr == 32)
                        {
                            *(endPtr--) = 0;
                            continue;
                        }
                        break;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(TickerLayout other)
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                return *((long*) pfchars) == *((long*) pother) &&
                       *((long*) (pfchars + 6)) == *((long*) (pother + 6));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(string value)
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    int i = 0;
                    while (i < MAX_LENGTH)
                    {
                        byte mine = *(charsPtr + i);
                        byte theirs = (byte)*(valuePtr + i);
                        if (mine != theirs) return false;
                        if (mine == 0 || theirs == 0) break;
                        ++i;
                    }
                    return i == value.Length;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(string target)
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* targetPtr = target)
                {
                    int i = 0;
                    while (i < MAX_LENGTH)
                    {
                        var ch = (char)(*(charsPtr + i));
                        if (ch == '\0') break;
                        targetPtr[i++] = ch;
                    }
                    var targetIntPtr = (int*)targetPtr;
                    targetIntPtr[-1] = i;
                    targetPtr[i] = '\0';
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is TickerLayout && Equals((TickerLayout) obj);
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

        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable NonReadonlyFieldInGetHashCode
                fixed (byte* pfchars = chars)
                    // ReSharper restore NonReadonlyFieldInGetHashCode
                {
                    var p = (int*) pfchars;
                    // We have a total of 14 characters allocated
                    // for the symbol but in reality it would be <= 8
                    // so we are going to ignore the last 6 chars in the
                    // hash code calculation and rely on Equals().  
                    // This ought to speed up the common cases and cost a 
                    // little more for really long tickers, should they 
                    // materialize in the future
                    return ((*p)*397) ^ *(p + 1);
                }
            }
        }

        public string Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return GetFromCache(this); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                fixed (char* pfstr = value)
                fixed (TickerLayout* pself = &this)
                {
                    char* pstr = pfstr;
                    var pchars = (byte*) (pself);

                    if (value.Length >= MAX_LENGTH)
                    {
                        for (int i = 0; i < MAX_LENGTH; i++)
                        {
                            *(pchars++) = (byte) *(pstr++);
                        }
                    }
                    else
                    {
                        while (*pstr != 0)
                        {
                            *(pchars++) = (byte) *(pstr++);
                        }
                        *pchars = 0;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator TickerLayout(string value)
        {
            return string.IsNullOrEmpty(value) ? new TickerLayout() : new TickerLayout {Value = value};
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator string(TickerLayout value)
        {
            return value.Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(TickerLayout other)
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < MAX_LENGTH; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return Value;
        }
    }
}