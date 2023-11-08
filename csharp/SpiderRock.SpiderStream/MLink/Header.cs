using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream.MLink;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Header
{
    public enum Protocol : byte
    {
        Json = (byte)'J',
        Protobuf = (byte)'P',
        Binary = (byte)'B',
        Mbus = Binary
    }

    private static readonly Header Empty = CreateEmpty();

    private static Header CreateEmpty()
    {
        Header empty = new();

        empty.payload[0] = (byte)'\r';
        empty.payload[1] = (byte)'\n';

        // protocol (unset)
        empty.payload[2] = 0;

        // message type
        empty.payload[3] = (byte)'0';
        empty.payload[4] = (byte)'0';
        empty.payload[5] = (byte)'0';
        empty.payload[6] = (byte)'0';
        empty.payload[7] = (byte)'0';

        // message length
        empty.payload[8] = (byte)'0';
        empty.payload[9] = (byte)'0';
        empty.payload[10] = (byte)'0';
        empty.payload[11] = (byte)'0';
        empty.payload[12] = (byte)'0';
        empty.payload[13] = (byte)'0';

        return empty;
    }

    private fixed byte payload[14];

    public Header()
    {
        this = Empty;
        Proto = Protocol.Mbus;
    }

    public Header(Protocol proto, MessageType messageType, int messageLength)
    {
        this = Empty;
        Proto = proto;
        MessageType = messageType;
        MessageLength = (ushort)messageLength;
    }

    public Protocol Proto { get => (Protocol)payload[2]; set => payload[2] = (byte)value; }

    public ushort MessageType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get
        {
            int l = 0;
            int f = 10_000;
            for (int i = 3; i <= 7; i++)
            {
                l += (payload[i] - '0') * f;
                f /= 10;
            }
            return (ushort)l;
        }
        set
        {
            for (int i = 7; value > 0 && i >= 3; i--)
            {
                payload[i] = (byte)('0' + value % 10);
                value /= 10;
            }
        }
    }

    public ushort MessageLength
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get
        {
            int l = 0;
            int f = 100_000;
            for (int i = 8; i <= 13; i++)
            {
                l += (payload[i] - '0') * f;
                f /= 10;
            }
            return (ushort)l;
        }
        set
        {
            for (int i = 13; value > 0 && i >= 8; i--)
            {
                payload[i] = (byte)('0' + value % 10);
                value /= 10;
            }
        }
    }
}
