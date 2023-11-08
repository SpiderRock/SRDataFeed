using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace SpiderRock.SpiderStream.FastSockets;

[SuppressUnmanagedCodeSecurity]
internal static class PInvoke
{
    public const string LibName = "libfsock";
    public const int FSOCK_VERSION_API = 0x0013;
    public const string FSOCK_VERSION_STR = "4.000-0013-CB-12102021";

    static PInvoke()
    {
        var rc = fsock_init(FSOCK_VERSION_API);

        if (rc != fsock_return_codes.SUCCESS)
        {
            throw fsock_error(nameof(fsock_init), rc, nameof(PInvoke), $"{nameof(FSOCK_VERSION_API)}: {FSOCK_VERSION_API}, {nameof(FSOCK_VERSION_STR)}: {FSOCK_VERSION_STR}");
        }
    }

    public enum fsock_return_codes
    {
        SUCCESS = 0,
        EINTR = 4,
        EIO = 5,
        EAGAIN = 11,
        EBUSY = 16,
        EEXIST = 17,
        ENODEV = 19,
        EINVAL = 22,
        EISCONN = 106,
        ENOTCONN = 107,
        ENAVAIL = 119,
        EKEYREJECTED = 129
    }

    public enum fsock_known_issues
    {
        NO_FILTERS_AVAILABLE = 119,
        NO_LICENSE = 129
    }

    [Flags]
    public enum fsock_open_flags
    {
        FSOCK_DISABLE_THREADSAFETY = 0x1,    /* reduce locking if single threaded application */
        FSOCK_ENABLE_TIMESTAMPING = 0x2,    /* provide fully qualified nanos since epoch in receive info */
        FSOCK_UDP = 0x4,    /* ep will be of udp proto */
        FSOCK_TCP = 0x8,    /* ep will be of tcp proto */
        FSOCK_GVA = 0x10,   /* ep will be of GVA type */
        FSOCK_OPEN_COMMON_BUFFER = 0x20,   /* don't get private buffer , place no filter */
        FSOCK_OPEN_PROMISC_UDP = 0x40,   /* Will catch all UDP traffic, will place proto UDP filter, but wildcarding addresses, ports,
        This will fail IFF a filter already has been placed. Returning EBUSY */
        FSOCK_OPEN_DISABLED = 0x80,   /* only allocate endpoint */
        FSOCK_OPEN_CAPTURE = 0x100,  /* report any traffic */
        FSOCK_ENABLE_ARISTA_TIMESTAMPING = 0x200,  /* consume timestamping information appended to frame */
        FSOCK_DISABLE_KERNEL_BYPASS = 0x400,  /* use sockets as transport */
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IN_ADDR
    {
        public uint S_addr;

        public IN_ADDR(uint address)
        {
            S_addr = address;
        }

        public IN_ADDR(IPAddress address)
            : this(BitConverter.ToUInt32(address.GetAddressBytes(), 0))
        {
        }

        public IN_ADDR(string address)
            : this(IPAddress.Parse(address))
        {
        }

        public override readonly string ToString() => new IPAddress(S_addr).ToString();
    }

    [DllImport(LibName)]
    public static extern fsock_return_codes fsock_init(ushort api_version);

    [DllImport(LibName)]
    public static extern fsock_return_codes fsock_open(in IN_ADDR address, fsock_open_flags flags, out IntPtr fsock_endpt);

    [DllImport(LibName)]
    public static extern fsock_return_codes fsock_close(IntPtr fsock_endpt);

    [DllImport(LibName)]
    public static extern fsock_return_codes fsock_shutdown(IntPtr fsock_endpt);

    public enum fsock_ep_attribute_t
    {
        /* change ring buffer size, prior to binding on endpoint */
        FSOCK_RINGBUF_SIZE = 0,
        FSOCK_RECV_CALLBACK = 1,
        /* set associated buffer id -1 (any) */
        FSOCK_SET_RX_BUFFER_ANY_ID = 2,
        /* set associated buffer id -1, (any). 0 - max buffer -1 , otherwise */
        FSOCK_SET_RX_BUFFER_ID = 3,
        /* enable the allocated/ shared EP, needs fully configured EP */
        FSOCK_ENABLE_ENDPOINT_ACTIVE = 4,
        FSOCK_ENABLE_ENDPOINT_PASSIVE = 5,
        /* clear the device endpoints stats to 0*/
        FSOCK_RESET_ENDPOINT_STATS = 6, /* optval ignored */
        /* report ring buffer watermark */
        FSOCK_REPORT_RINGBUF_LEVEL = 7, /* optval = sizeof (int) */
    }

    public enum fsock_thread_priority
    {
        FSOCK_THREAD_PRIORITY_NORMAL = 0,
        FSOCK_THREAD_PRIORITY_TIME_CRITICAL = 15,
    }

    [Flags]
    public enum fsock_ring_buf_flags
    {
        FSOCK_SET_RINGBUF_SIZE = 1,
        FSOCK_SET_RINGBUF_MTU = 2,
        FSOCK_SET_RINGBUF_THREAD_AFFINITY = 4,
        FSOCK_SET_RINGBUF_THREAD_PRIORITY = 8,
        FSOCK_SET_RINGBUF_THREAD_CORE_EXCLUSIVE = 16,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct fsock_ringbuf_t
    {
        public fsock_ring_buf_flags flags;                  /* XORed parameter of which entries to follow, FSOCK_SET_RINGBUF_SIZE is mandatory , others optional */
        public uint ring_buf_size;                          /* size in MBytes (e.g val 16 == 16 MBytes) */
        public uint ring_buf_mtu;                           /* max payload per packet, eg. 512 */
        public uint rx_thread_affinity_mask;               /* allow for thread affinty (mask) */
        public fsock_thread_priority rx_thread_priority;    /* increase thread priority */
        public byte rx_thread_core_exclusive;               /* if true, attempt is made to pin other app thread to different cores and isolate specified core :: tbd. */
    }

    [DllImport(LibName)]
    public static extern fsock_return_codes fsock_set_ep_attribute(IntPtr fsock_endpt, fsock_ep_attribute_t optname, in fsock_ringbuf_t optval, int optlen);

    [Flags]
    public enum fsock_bind_flags
    {
        FSOCK_BIND_DEFAULT = 0x00,
        FSOCK_BIND_REUSEADDR = 0x01,
        FSOCK_BIND_NO_UNICAST = 0x02
    }

    [DllImport(LibName)]
    public unsafe static extern fsock_return_codes fsock_bind(IntPtr fsock_endpt, fsock_bind_flags flags, int port, IntPtr context, out IntPtr fsock_ch);

    public enum fsock_setopt_t
    {
        /*! Join MCAST , any source */
        FSOCK_JOIN_MCAST = 0,
        /*! Leave MCAST */
        FSOCK_LEAVE_MCAST = 1,
        /* Join MCAST with source */
        FSOCK_JOIN_MCAST_SOURCE = 2,
        /* Leave MCAST with source */
        FSOCK_LEAVE_MCAST_SOURCE = 3,
        /* Request TX Timestamps */
        FSOCK_SET_TX_TIMESTAMPING = 4,
        /* Request RX Timestamps */
        FSOCK_SET_RX_TIMESTAMPING = 5,
        /* set fast tx (TCP only) */
        FSOCK_SET_TX_MODE = 6,

        /* alloc gva bufs */
        FSOCK_ALLOC_GVA_BUF = 7,
        /* set rx timeout in msecs */
        FSOCK_QUEUE_GVA_BUF = 8,
        FSOCK_FREE_GVA_BUF = 9,
        FSOCK_RX_TIMEOUT = 10,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IP_MREQ
    {
        public IN_ADDR imr_multiaddr;
        public IN_ADDR imr_interface;
    }

    [DllImport(LibName)]
    public static extern fsock_return_codes fsock_setopt(IntPtr fsock_ch, fsock_setopt_t optname, IntPtr optval, int optlen);

    [StructLayout(LayoutKind.Sequential)]
    public struct fsock_recv_info
    {
        public IntPtr chan;
        public IntPtr context;
        public sockaddr_in sin_from;
        public sockaddr_in sin_to;
        public uint msg_len;
        public int frame_status;
        public long timestamp;
        public uint hw_timestamp;
        public long ext_timestamp;
        public ushort tai_offset;
        public uint free_chunks;
        public uint rx_level;
        public ushort ip_id;
    }

    public enum fsock_recv_mode_t
    {
        /*! wait until data is available */
        FSOCK_RECV_DEFAULT = 0,
        /*! receive nonblocking (EAGAIN) */
        FSOCK_RECV_NONBLOCK = 1,
        /*! Peek at message, TCP only */
        FSOCK_RECV_MSGPEEK = 2,
        /* report eth , ip, udp */
        FSOCK_RECV_REQUEST_HDR = 32,
        /* check ring buffer watermark */
        FSOCK_RECV_REPORT_WATERMARK = 64,
    }

    [DllImport(LibName)]
    public static extern unsafe fsock_return_codes fsock_recvfrom(IntPtr fsock_endpt, fsock_recv_mode_t mode, ref byte buf, int len, out fsock_recv_info info);

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct sockaddr_in
    {
        public short family;
        public byte p1, p2;
        public IN_ADDR address;
        public ulong zero;

        public sockaddr_in(IN_ADDR address, int port)
        {
            family = (short)AddressFamily.InterNetwork;
            this.address = address;
            p1 = (byte)(port / 256);
            p2 = (byte)(port % 256);
            zero = 0;
        }

        public sockaddr_in(short family, IN_ADDR address, int port)
        {
            this.family = family;
            p1 = (byte)(port / 256);
            p2 = (byte)(port % 256);
            this.address = address;
            zero = 0;
        }

        public override readonly string ToString() => $"{address}:{p1 * 256 + p2}";
    }

    public static Exception fsock_error(string exaFunction, fsock_return_codes returnCode, object offender, string details = default)
    {
        StringBuilder sb = new(1024);
        sb.Append($"{offender}:");

        if (!string.IsNullOrWhiteSpace(exaFunction))
        {
            sb.Append($" {exaFunction}");
        }

        sb.Append($" error {returnCode}");

        if (!string.IsNullOrWhiteSpace(details))
        {
            sb.Append($": {details}");
        }

        return new(sb.ToString());
    }

    public class Exception : System.Exception
    {
        public Exception(string message) : base(message)
        {
        }
    }
}
