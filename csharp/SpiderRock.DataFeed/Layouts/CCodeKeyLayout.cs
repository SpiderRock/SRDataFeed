using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Layouts
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct CCodeKeyLayout : IEquatable<CCodeKeyLayout>, IComparable<CCodeKeyLayout>
    {
        public CCodeKeyLayout(AssetType assetType, TickerSrc tickerSrc, CCodeLayout ccode)
        {
            this.assetType = assetType;
            this.tickerSrc = tickerSrc;
            this.ccode = ccode;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(CCodeKeyLayout other)
        {
            return ccode == other.ccode &&
                   assetType == other.assetType &&
                   tickerSrc == other.tickerSrc;
        }

        public unsafe int CompareTo(CCodeKeyLayout other)
        {
            fixed (CCodeKeyLayout* pfself = &this)
            {
                return (*((long*) pfself)).CompareTo(*((long*) &other));
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is CCodeKeyLayout && Equals((CCodeKeyLayout) obj);
        }

        public override unsafe int GetHashCode()
        {
            unchecked
            {
                fixed (CCodeKeyLayout* pself = &this)
                {
                    var p1 = (byte*) pself;
                    var p2 = (int*) (p1 + 1);
                    int* p3 = p2 + 1;
                    int* p4 = p3 + 1;
                    int hashCode = *p1;
                    hashCode = (hashCode*397) ^ *p2;
                    hashCode = (hashCode*397) ^ *p3;
                    hashCode = (hashCode*397) ^ *p4;
                    return hashCode;
                }
            }
        }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return assetType == 0 && tickerSrc == 0; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(CCodeKeyLayout left, CCodeKeyLayout right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(CCodeKeyLayout left, CCodeKeyLayout right)
        {
            return !left.Equals(right);
        }

        // ReSharper disable FieldCanBeMadeReadOnly.Local
        private AssetType assetType;
        private TickerSrc tickerSrc;
        private CCodeLayout ccode;
        // ReSharper restore FieldCanBeMadeReadOnly.Local

        public AssetType AssetType
        {
            get { return assetType; }
        }

        public TickerSrc TickerSrc
        {
            get { return tickerSrc; }
        }

        public CCodeLayout CCode
        {
            get { return ccode; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TrimEnd()
        {
            ccode.TrimEnd();
        }
    }
}