using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Layouts
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RootKeyLayout : IEquatable<RootKeyLayout>, IComparable<RootKeyLayout>
    {
        public RootKeyLayout(AssetType assetType, TickerSrc tickerSrc, RootLayout root)
        {
            this.assetType = assetType;
            this.tickerSrc = tickerSrc;
            this.root = root;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(RootKeyLayout other)
        {
            return root == other.root &&
                   assetType == other.assetType &&
                   tickerSrc == other.tickerSrc;
        }

        public unsafe int CompareTo(RootKeyLayout other)
        {
            fixed (RootKeyLayout* pfself = &this)
            {
                return (*((long*) pfself)).CompareTo(*((long*) &other));
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is RootKeyLayout && Equals((RootKeyLayout) obj);
        }

        public override unsafe int GetHashCode()
        {
            unchecked
            {
                fixed (RootKeyLayout* pself = &this)
                {
                    var p = (int*) pself;
                    return ((*p)*397) ^ *(p + 1);
                }
            }
        }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return assetType == 0 && tickerSrc == 0; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(RootKeyLayout left, RootKeyLayout right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(RootKeyLayout left, RootKeyLayout right)
        {
            return !left.Equals(right);
        }

        // ReSharper disable FieldCanBeMadeReadOnly.Local
        private AssetType assetType;
        private TickerSrc tickerSrc;
        private RootLayout root;
        // ReSharper restore FieldCanBeMadeReadOnly.Local

        public AssetType AssetType
        {
            get { return assetType; }
        }

        public TickerSrc TickerSrc
        {
            get { return tickerSrc; }
        }

        public RootLayout Root
        {
            get { return root; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TrimEnd()
        {
            root.TrimEnd();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe explicit operator RootKeyLayout(ulong value)
        {
            var key = new RootKeyLayout();
            var pkey = (byte*) &key;
            *(pkey) = (byte) (value >> 56);
            *(pkey + 1) = (byte) (value >> 48);
            *(pkey + 2) = (byte) (value >> 40);
            *(pkey + 3) = (byte) (value >> 32);
            *(pkey + 4) = (byte) (value >> 24);
            *(pkey + 5) = (byte) (value >> 16);
            *(pkey + 6) = (byte) (value >> 8);
            *(pkey + 7) = (byte) (value);
            return key;
        }
    }
}