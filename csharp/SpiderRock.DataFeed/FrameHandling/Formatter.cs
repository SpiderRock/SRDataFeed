using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiderRock.DataFeed.FrameHandling
{
    unsafe internal sealed partial class Formatter
    {
        public static readonly Formatter Default = new Formatter();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
// ReSharper disable once UnusedMember.Local
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
// ReSharper disable once UnusedMember.Local
		private static string DecodeText2(ref byte* ptr, byte* max, string fieldName)
		{
			unchecked 
			{
				var len = *(ushort*) ptr; ptr += sizeof(ushort);
				if (len > 10000) throw new IOException("Invalid length decoding " + fieldName);
				if (ptr + len > max) throw new IOException("Max exceeded decoding " + fieldName);
				return DecodeVariableLengthString(ref ptr, len);
			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string DecodeVariableLengthString(ref byte* ptr, int length)
        {
		    if (length == 0) return string.Empty;
            var value = new string((sbyte*) ptr, 0, length, Encoding.ASCII);
		    ptr += length;
		    return value;
        }
	}
} // namespace
