using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Proto.DBL.Myricom
{
    internal static class DblLibrary
    {
        public const ushort Version = 2;
        public const string LibName = "DBL.dll";

        static DblLibrary()
        {
            int initResult = dbl_init(Version);
            if (initResult == 0) return;

            throw new Exception(string.Format(
                "{0} version {1} failed to initialize with dbl_init(): error code {2}",
                LibName, Version, initResult));
        }

        // ReSharper disable InconsistentNaming

        [DllImport(LibName)]
        public static extern int dbl_init(ushort version);

        [DllImport(LibName)]
        public static extern int dbl_open(ref InetAddress address, OpenMode flags, out IntPtr device);

        [DllImport(LibName)]
        public static extern int dbl_close(IntPtr device);

        [DllImport(LibName)]
        public static extern int dbl_bind(IntPtr device, DblBind flags, int port, IntPtr context, out IntPtr channel);

        [DllImport(LibName)]
        public static extern int dbl_getaddress(IntPtr channel, out SocketAddress address);

        [DllImport(LibName)]
        public static extern int dbl_mcast_join(IntPtr channel, ref InetAddress mcast_address, IntPtr unused);

        [DllImport(LibName)]
        public static extern int dbl_mcast_leave(IntPtr channel, ref InetAddress mcast_address);

        [DllImport(LibName)]
        public static extern unsafe int dbl_recvfrom(IntPtr device, RecvMode mode, byte* buffer, int length,
            RecvInfo* info);

        [Flags]
        public enum DblBind
        {
            Default = 0,
            ReuseAddr = 2,
            DupToKernel = 4,
            NoUnicast = 8,
            Broadcast = 10
        }

        [Flags]
        public enum OpenMode
        {
            Default = 0,
            ThreadSafe = 1,
            Disabled = 2,
            HwTimestamping = 4
        }

        public enum RecvMode
        {
            Default = 0,
            NonBlock = 1,
            Block = 2,
            Peek = 3,
            PeekMsg = 4,
            NonBlockSetEvent = 5
        }

        public enum SendMode
        {
            Default = 0,
            NonBlock = 4
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct InetAddress
        {
            public uint address;

            public InetAddress(uint address)
            {
                this.address = address;
            }

            public InetAddress(IPAddress address)
                : this(BitConverter.ToUInt32(address.GetAddressBytes(), 0))
            {
            }

            public InetAddress(string address)
                : this(IPAddress.Parse(address))
            {
            }

            public override string ToString()
            {
                return new IPAddress(address).ToString();
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RecvInfo
        {
            public IntPtr channel;
            public IntPtr context;
            public IntPtr unused1;
            public SocketAddress fmAddress;
            public SocketAddress toAddress;
            public uint msgLength;
            public int unused2;
            public long timestamp;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SocketAddress
        {
            public short family;
            public byte p1, p2;
            public InetAddress address;
            public ulong zero;

            public SocketAddress(InetAddress address, int port)
            {
                family = (short) AddressFamily.InterNetwork;
                this.address = address;
                p1 = (byte) (port/256);
                p2 = (byte) (port%256);
                zero = 0;
            }

            public SocketAddress(short family, InetAddress address, int port)
            {
                this.family = family;
                p1 = (byte) (port/256);
                p2 = (byte) (port%256);
                this.address = address;
                zero = 0;
            }

            public override string ToString()
            {
                return string.Format("{0}:{1}", address, p1*256 + p2);
            }
        }
    }
}