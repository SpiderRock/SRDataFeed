// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2023, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.SpiderStream.Mbus;

    
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct AppNameString : IEquatable<AppNameString>, IComparable<AppNameString>, IEquatable<string>
{
    public fixed byte chars[64];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 64; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 64;
                }
            }
        }
    }
    
    public int MaxLength { get { return 64; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(AppNameString other)
    {
        fixed (AppNameString* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 16; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 64) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(AppNameString other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 64; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 64)
                    {
                        for (int i = 0; i < 64; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 63;
                
                for (int i = 0; i < 64; i++)
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
    
    public override int GetHashCode()
    {
        fixed (AppNameString* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 16; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(AppNameString value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator AppNameString(string value)
    {
        var r = new AppNameString();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString1Layout : IEquatable<FixedString1Layout>, IComparable<FixedString1Layout>, IEquatable<string>
{
    public fixed byte chars[1];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 1; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 1;
                }
            }
        }
    }
    
    public int MaxLength { get { return 1; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString1Layout other)
    {
        fixed (FixedString1Layout* pfself = &this)
        {
            /* -------------- compare as bytes ------------ */
            var pByteSelf = (byte*) pfself;
            var pByteOther = (byte*) &other;
     
            for (int i = 0; i < 1; i++)
            {
                if (*(pByteSelf++) == *(pByteOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 1) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString1Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 1; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 1)
                    {
                        for (int i = 0; i < 1; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 0;
                
                for (int i = 0; i < 1; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString1Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as bytes ------------ */
            var pByteSelf = (byte*) pfself;
     
            for (int i = 0; i < 1; i++)
            {
                hashCode = (hashCode*397) ^ *(pByteSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString1Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString1Layout(string value)
    {
        var r = new FixedString1Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString10Layout : IEquatable<FixedString10Layout>, IComparable<FixedString10Layout>, IEquatable<string>
{
    public fixed byte chars[10];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 10; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 10;
                }
            }
        }
    }
    
    public int MaxLength { get { return 10; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString10Layout other)
    {
        fixed (FixedString10Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 2; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             /* -------------- compare as bytes ------------ */
            var pByteSelf = (byte*) pIntSelf;
            var pByteOther = (byte*) pIntOther;
     
            for (int i = 0; i < 2; i++)
            {
                if (*(pByteSelf++) == *(pByteOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 10) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString10Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 10; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 10)
                    {
                        for (int i = 0; i < 10; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 9;
                
                for (int i = 0; i < 10; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString10Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 2; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }
             /* -------------- hash as bytes ------------ */
            var pByteSelf = (byte*) pIntSelf;
     
            for (int i = 0; i < 2; i++)
            {
                hashCode = (hashCode*397) ^ *(pByteSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString10Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString10Layout(string value)
    {
        var r = new FixedString10Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString12Layout : IEquatable<FixedString12Layout>, IComparable<FixedString12Layout>, IEquatable<string>
{
    public fixed byte chars[12];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 12; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 12;
                }
            }
        }
    }
    
    public int MaxLength { get { return 12; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString12Layout other)
    {
        fixed (FixedString12Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 3; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 12) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString12Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 12; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 12)
                    {
                        for (int i = 0; i < 12; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 11;
                
                for (int i = 0; i < 12; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString12Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 3; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString12Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString12Layout(string value)
    {
        var r = new FixedString12Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString16Layout : IEquatable<FixedString16Layout>, IComparable<FixedString16Layout>, IEquatable<string>
{
    public fixed byte chars[16];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 16; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 16;
                }
            }
        }
    }
    
    public int MaxLength { get { return 16; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString16Layout other)
    {
        fixed (FixedString16Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 4; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 16) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString16Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 16; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 16)
                    {
                        for (int i = 0; i < 16; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 15;
                
                for (int i = 0; i < 16; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString16Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 4; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString16Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString16Layout(string value)
    {
        var r = new FixedString16Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString2Layout : IEquatable<FixedString2Layout>, IComparable<FixedString2Layout>, IEquatable<string>
{
    public fixed byte chars[2];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 2; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 2;
                }
            }
        }
    }
    
    public int MaxLength { get { return 2; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString2Layout other)
    {
        fixed (FixedString2Layout* pfself = &this)
        {
            /* -------------- compare as bytes ------------ */
            var pByteSelf = (byte*) pfself;
            var pByteOther = (byte*) &other;
     
            for (int i = 0; i < 2; i++)
            {
                if (*(pByteSelf++) == *(pByteOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 2) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString2Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 2; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 2)
                    {
                        for (int i = 0; i < 2; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 1;
                
                for (int i = 0; i < 2; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString2Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as bytes ------------ */
            var pByteSelf = (byte*) pfself;
     
            for (int i = 0; i < 2; i++)
            {
                hashCode = (hashCode*397) ^ *(pByteSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString2Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString2Layout(string value)
    {
        var r = new FixedString2Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString20Layout : IEquatable<FixedString20Layout>, IComparable<FixedString20Layout>, IEquatable<string>
{
    public fixed byte chars[20];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 20; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 20;
                }
            }
        }
    }
    
    public int MaxLength { get { return 20; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString20Layout other)
    {
        fixed (FixedString20Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 5; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 20) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString20Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 20; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 20)
                    {
                        for (int i = 0; i < 20; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 19;
                
                for (int i = 0; i < 20; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString20Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 5; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString20Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString20Layout(string value)
    {
        var r = new FixedString20Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString24Layout : IEquatable<FixedString24Layout>, IComparable<FixedString24Layout>, IEquatable<string>
{
    public fixed byte chars[24];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 24; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 24;
                }
            }
        }
    }
    
    public int MaxLength { get { return 24; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString24Layout other)
    {
        fixed (FixedString24Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 6; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 24) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString24Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 24; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 24)
                    {
                        for (int i = 0; i < 24; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 23;
                
                for (int i = 0; i < 24; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString24Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 6; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString24Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString24Layout(string value)
    {
        var r = new FixedString24Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString28Layout : IEquatable<FixedString28Layout>, IComparable<FixedString28Layout>, IEquatable<string>
{
    public fixed byte chars[28];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 28; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 28;
                }
            }
        }
    }
    
    public int MaxLength { get { return 28; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString28Layout other)
    {
        fixed (FixedString28Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 7; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 28) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString28Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 28; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 28)
                    {
                        for (int i = 0; i < 28; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 27;
                
                for (int i = 0; i < 28; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString28Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 7; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString28Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString28Layout(string value)
    {
        var r = new FixedString28Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString3Layout : IEquatable<FixedString3Layout>, IComparable<FixedString3Layout>, IEquatable<string>
{
    public fixed byte chars[3];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 3; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 3;
                }
            }
        }
    }
    
    public int MaxLength { get { return 3; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString3Layout other)
    {
        fixed (FixedString3Layout* pfself = &this)
        {
            /* -------------- compare as bytes ------------ */
            var pByteSelf = (byte*) pfself;
            var pByteOther = (byte*) &other;
     
            for (int i = 0; i < 3; i++)
            {
                if (*(pByteSelf++) == *(pByteOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 3) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString3Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 3; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 3)
                    {
                        for (int i = 0; i < 3; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 2;
                
                for (int i = 0; i < 3; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString3Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as bytes ------------ */
            var pByteSelf = (byte*) pfself;
     
            for (int i = 0; i < 3; i++)
            {
                hashCode = (hashCode*397) ^ *(pByteSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString3Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString3Layout(string value)
    {
        var r = new FixedString3Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString32Layout : IEquatable<FixedString32Layout>, IComparable<FixedString32Layout>, IEquatable<string>
{
    public fixed byte chars[32];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 32; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 32;
                }
            }
        }
    }
    
    public int MaxLength { get { return 32; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString32Layout other)
    {
        fixed (FixedString32Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 8; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 32) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString32Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 32; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 32)
                    {
                        for (int i = 0; i < 32; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 31;
                
                for (int i = 0; i < 32; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString32Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 8; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString32Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString32Layout(string value)
    {
        var r = new FixedString32Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString4Layout : IEquatable<FixedString4Layout>, IComparable<FixedString4Layout>, IEquatable<string>
{
    public fixed byte chars[4];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 4; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 4;
                }
            }
        }
    }
    
    public int MaxLength { get { return 4; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString4Layout other)
    {
        fixed (FixedString4Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 1; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 4) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString4Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 4; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 4)
                    {
                        for (int i = 0; i < 4; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 3;
                
                for (int i = 0; i < 4; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString4Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 1; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString4Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString4Layout(string value)
    {
        var r = new FixedString4Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString40Layout : IEquatable<FixedString40Layout>, IComparable<FixedString40Layout>, IEquatable<string>
{
    public fixed byte chars[40];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 40; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 40;
                }
            }
        }
    }
    
    public int MaxLength { get { return 40; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString40Layout other)
    {
        fixed (FixedString40Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 10; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 40) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString40Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 40; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 40)
                    {
                        for (int i = 0; i < 40; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 39;
                
                for (int i = 0; i < 40; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString40Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 10; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString40Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString40Layout(string value)
    {
        var r = new FixedString40Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString5Layout : IEquatable<FixedString5Layout>, IComparable<FixedString5Layout>, IEquatable<string>
{
    public fixed byte chars[5];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 5; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 5;
                }
            }
        }
    }
    
    public int MaxLength { get { return 5; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString5Layout other)
    {
        fixed (FixedString5Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 1; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             /* -------------- compare as bytes ------------ */
            var pByteSelf = (byte*) pIntSelf;
            var pByteOther = (byte*) pIntOther;
     
            for (int i = 0; i < 1; i++)
            {
                if (*(pByteSelf++) == *(pByteOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 5) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString5Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 5; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 5)
                    {
                        for (int i = 0; i < 5; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 4;
                
                for (int i = 0; i < 5; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString5Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 1; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }
             /* -------------- hash as bytes ------------ */
            var pByteSelf = (byte*) pIntSelf;
     
            for (int i = 0; i < 1; i++)
            {
                hashCode = (hashCode*397) ^ *(pByteSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString5Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString5Layout(string value)
    {
        var r = new FixedString5Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString6Layout : IEquatable<FixedString6Layout>, IComparable<FixedString6Layout>, IEquatable<string>
{
    public fixed byte chars[6];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 6; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 6;
                }
            }
        }
    }
    
    public int MaxLength { get { return 6; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString6Layout other)
    {
        fixed (FixedString6Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 1; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             /* -------------- compare as bytes ------------ */
            var pByteSelf = (byte*) pIntSelf;
            var pByteOther = (byte*) pIntOther;
     
            for (int i = 0; i < 2; i++)
            {
                if (*(pByteSelf++) == *(pByteOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 6) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString6Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 6; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 6)
                    {
                        for (int i = 0; i < 6; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 5;
                
                for (int i = 0; i < 6; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString6Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 1; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }
             /* -------------- hash as bytes ------------ */
            var pByteSelf = (byte*) pIntSelf;
     
            for (int i = 0; i < 2; i++)
            {
                hashCode = (hashCode*397) ^ *(pByteSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString6Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString6Layout(string value)
    {
        var r = new FixedString6Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString64Layout : IEquatable<FixedString64Layout>, IComparable<FixedString64Layout>, IEquatable<string>
{
    public fixed byte chars[64];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 64; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 64;
                }
            }
        }
    }
    
    public int MaxLength { get { return 64; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString64Layout other)
    {
        fixed (FixedString64Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 16; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 64) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString64Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 64; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 64)
                    {
                        for (int i = 0; i < 64; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 63;
                
                for (int i = 0; i < 64; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString64Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 16; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString64Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString64Layout(string value)
    {
        var r = new FixedString64Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString72Layout : IEquatable<FixedString72Layout>, IComparable<FixedString72Layout>, IEquatable<string>
{
    public fixed byte chars[72];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 72; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 72;
                }
            }
        }
    }
    
    public int MaxLength { get { return 72; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString72Layout other)
    {
        fixed (FixedString72Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 18; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 72) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString72Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 72; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 72)
                    {
                        for (int i = 0; i < 72; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 71;
                
                for (int i = 0; i < 72; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString72Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 18; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString72Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString72Layout(string value)
    {
        var r = new FixedString72Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString8Layout : IEquatable<FixedString8Layout>, IComparable<FixedString8Layout>, IEquatable<string>
{
    public fixed byte chars[8];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 8; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 8;
                }
            }
        }
    }
    
    public int MaxLength { get { return 8; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString8Layout other)
    {
        fixed (FixedString8Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 2; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 8) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString8Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 8; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 8)
                    {
                        for (int i = 0; i < 8; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 7;
                
                for (int i = 0; i < 8; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString8Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 2; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString8Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString8Layout(string value)
    {
        var r = new FixedString8Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}
     
[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
internal unsafe struct FixedString80Layout : IEquatable<FixedString80Layout>, IComparable<FixedString80Layout>, IEquatable<string>
{
    public fixed byte chars[80];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return Value;
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
                    for (int i = 0; i < 80; i++) 
                    {
                        if (charsPtr[i] == 0) return i;
                    }
                    return 80;
                }
            }
        }
    }
    
    public int MaxLength { get { return 80; } }

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(FixedString80Layout other)
    {
        fixed (FixedString80Layout* pfself = &this)
        {
            /* -------------- compare as ints ------------ */
            var pIntSelf = (int*) pfself;
            var pIntOther = (int*) &other;
            for (int i = 0; i < 20; i++)
            {
                if (*(pIntSelf++) == *(pIntOther++)) continue;
                return false;
            }
             return true;

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
                while (i < 80) 
                {
                    byte mine = charsPtr[i]; 
                    byte theirs = (byte) valuePtr[i];
                    if (mine != theirs) return false;
                    if (mine == 0 || theirs == 0) break;
                    ++i;
                }
                return i == value.Length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(FixedString80Layout other)
    {
        unchecked
        {
            fixed (byte* pfchars = chars)
            {
                var pother = (byte*) &other;
                for (int i = 0; i < 80; i++)
                {
                    int result = *(pfchars + i) - *(pother + i);
                    if (result == 0) continue;
                    return result;
                }
                return 0;
            }
        }
    }

    public string Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            fixed (byte* charsPtr = chars)
            {
                int length = Length;
                return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            unchecked
            {
                fixed (byte* charsPtr = chars)
                fixed (char* valuePtr = value)
                {
                    char* pstr = valuePtr;
                    byte* pchars = charsPtr;
                    
                    if (value.Length >= 80)
                    {
                        for (int i = 0; i < 80; i++) { *(pchars++) = (byte) *(pstr++); }
                    }
                    else
                    {
                        while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
                        *pchars = 0;
                    }
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
                byte* endPtr = begPtr + 79;
                
                for (int i = 0; i < 80; i++)
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
    
    public override int GetHashCode()
    {
        fixed (FixedString80Layout* pfself = &this)
        {
            int hashCode = 37;
            /* -------------- hash as ints ------------ */
            var pIntSelf = (int*) pfself;
            for (int i = 0; i < 20; i++)
            {
                hashCode = (hashCode*397) ^ *(pIntSelf++);
            }

            return hashCode;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator string(FixedString80Layout value)
    {
        return value.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FixedString80Layout(string value)
    {
        var r = new FixedString80Layout();
        if (string.IsNullOrEmpty(value)) return r;
        r.Value = value;
        return r;
    }
}

