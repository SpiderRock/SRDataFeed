using System;
using System.Runtime.CompilerServices;

namespace SpiderRock.SpiderStream;

internal struct CompactArray16<T>
{
    T[][] arr;

    public CompactArray16()
    {
        arr = new T[256][];
    }

    public ref T this[ushort index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            long inx = index;
            var d1 = inx >> 8;
            var d2 = inx & 0x00ff;

            try
            {
                return ref arr[d1][d2];
            }
            catch (NullReferenceException)
            {
                arr ??= new T[256][];
                arr[d1] ??= new T[256];

                return ref arr[d1][d2];
            }
        }
    }
}
