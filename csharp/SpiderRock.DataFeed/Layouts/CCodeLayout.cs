using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace SpiderRock.DataFeed.Layouts
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct CCodeLayout :
        IEquatable<CCodeLayout>,
        IEquatable<string>,
        IComparable<CCodeLayout>
    {
        // ReSharper disable once InconsistentNaming
        private const int MAX_LENGTH = 11;

        #region string caching

        private static readonly Dictionary<CCodeLayout, string> StringCache =
            new Dictionary<CCodeLayout, string>(150000);

        private static SpinLock StringCacheLock;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetFromCache(CCodeLayout ccode)
        {
            string value;
            if (StringCache.TryGetValue(ccode, out value)) return value;

            bool lockTaken = false;

            try
            {
                StringCacheLock.Enter(ref lockTaken);

                if (StringCache.TryGetValue(ccode, out value)) return value;

                StringCache[ccode] = value = new string((sbyte*) &ccode, 0, ccode.Length, Encoding.ASCII);
            }
            finally
            {
                if (lockTaken) StringCacheLock.Exit(false);
            }

            return value;
        }

        #endregion

        private fixed byte chars [MAX_LENGTH];

        public CCodeLayout(string value)
        {
            Value = value;
        }

        public CCodeLayout Root
        {
            get { return this; }
        }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (byte* pfchars = chars) return *pfchars == 0;
            }
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
                unchecked
                {
                    fixed (byte* charsPtr = chars)
                    {
                        // these are tested in the order from the most to least likely base on the current distribution
                        if (charsPtr[3] == 0 && charsPtr[2] != 0) return 3;
                        if (charsPtr[2] == 0 && charsPtr[1] != 0) return 2;
                        if (charsPtr[5] == 0 && charsPtr[4] != 0) return 5;
                        if (charsPtr[4] == 0 && charsPtr[3] != 0) return 4;
                        if (charsPtr[1] == 0 && charsPtr[0] != 0) return 1;
                        if (charsPtr[0] == 0) return 0;

                        for (int i = 6; i < MAX_LENGTH; i++)
                        {
                            if (charsPtr[i] == 0)
                            {
                                return i;
                            }
                        }

                        return MAX_LENGTH;
                    }
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
        public bool Equals(CCodeLayout other)
        {
            unchecked
            {
                // ReSharper disable once NonReadonlyFieldInGetHashCode
                fixed (byte* pfchars = chars)
                {
                    var o = (byte*) &other;

                    var p1 = (long*) pfchars;
                    var o1 = (long*) o;

                    if (!(*p1).Equals(*o1)) return false;

                    var p2 = (int*) (pfchars + 7);
                    var o2 = (int*) (o + 7);

                    return (*p2).Equals(*o2);
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is CCodeLayout && Equals((CCodeLayout) obj);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(CCodeLayout left, CCodeLayout right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(CCodeLayout left, CCodeLayout right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable once NonReadonlyFieldInGetHashCode
                fixed (byte* pfchars = chars)
                {
                    byte* p1 = pfchars;
                    var p2 = (short*) (p1 + 1);
                    var p3 = (int*) (p2 + 1);
                    int* p4 = p3 + 1;

                    int hashCode = ((*p1)*397) ^ (*p2);
                    hashCode = (hashCode*397) ^ (*p3);
                    hashCode = (hashCode*397) ^ (*p4);
                    return hashCode;
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
                fixed (CCodeLayout* pself = &this)
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
        public static implicit operator CCodeLayout(string value)
        {
            return string.IsNullOrEmpty(value) ? new CCodeLayout() : new CCodeLayout {Value = value};
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator string(CCodeLayout value)
        {
            return value.Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(CCodeLayout other)
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
        public static bool operator <(CCodeLayout x, CCodeLayout y)
        {
            return x.CompareTo(y) < 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(CCodeLayout x, CCodeLayout y)
        {
            return x.CompareTo(y) > 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(CCodeLayout x, CCodeLayout y)
        {
            return x.CompareTo(y) <= 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(CCodeLayout x, CCodeLayout y)
        {
            return x.CompareTo(y) >= 0;
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
                        var theirs = (byte) *(valuePtr + i);
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
                        var ch = (char) (*(charsPtr + i));
                        if (ch == '\0') break;
                        targetPtr[i++] = ch;
                    }
                    var targetIntPtr = (int*) targetPtr;
                    targetIntPtr[-1] = i;
                    targetPtr[i] = '\0';
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return Value;
        }
    }
}