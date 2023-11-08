using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiderRock.SpiderStream.Mbus;

internal sealed unsafe partial class Formatter
{
    public static readonly Formatter Default = new();

    private static readonly Encoder Utf8 = Encoding.UTF8.GetEncoder();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte* EncodeText1(byte* ptr, string value, string fieldName)
    {
        unchecked
        {
            var safeLength = Math.Min(255, value.Length);
            *ptr++ = (byte)safeLength;
            Utf8.Convert(value, new(ptr, safeLength), true, out var _, out var bytesUsed, out var completed);
            Debug.Assert(completed, $"{nameof(EncodeText1)}: conversion incomplete");
            Debug.Assert(bytesUsed < 255, $"{nameof(EncodeText1)}: length exceeds 255");
            return ptr + bytesUsed;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte* EncodeText2(byte* ptr, string value, string fieldName)
    {
        unchecked
        {
            var safeLength = Math.Min(10000, value.Length);
            *(ushort*)ptr = (ushort)safeLength;
            ptr += sizeof(ushort);
            Utf8.Convert(value, new(ptr, safeLength), true, out var _, out var bytesUsed, out var completed);
            Debug.Assert(completed, $"{nameof(EncodeText2)}: conversion incomplete");
            Debug.Assert(bytesUsed < 10000, $"{nameof(EncodeText2)}: length exceeds 10000");
            return ptr + bytesUsed;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string DecodeText1(ref byte* ptr, byte* max, string fieldName)
    {
        unchecked
        {
            var len = *(ptr++);
            if (len > 255) throw new IOException("Invalid length decoding " + fieldName);
            if (ptr + len > max) throw new IOException("Max exceeded decoding " + fieldName);
            return DecodeVariableLengthString(ref ptr, len);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string DecodeText2(ref byte* ptr, byte* max, string fieldName)
    {
        unchecked
        {
            var len = *(ushort*)ptr; ptr += sizeof(ushort);
            if (len > 10000) throw new IOException("Invalid length decoding " + fieldName);
            if (ptr + len > max) throw new IOException("Max exceeded decoding " + fieldName);
            return DecodeVariableLengthString(ref ptr, len);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string DecodeVariableLengthString(ref byte* ptr, int length)
    {
        if (length == 0) return string.Empty;
        var value = new string((sbyte*)ptr, 0, length, Encoding.ASCII);
        ptr += length;
        return value;
    }
}
