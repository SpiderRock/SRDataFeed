using System;
using System.Runtime.InteropServices;

namespace SpiderRock.SpiderStream.Mbus;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 28)]
internal struct Header
{
    public const int MaxMessageLength = 64000;

    public byte hdrlen;
    public ushort msglen;
    public byte keylen;

    public MessageType msgtype;
    public HeaderBits bits;

    public SourceId sourceid;

    public byte seqnum;
    public long sentts;

    public TravelLog log;

    public override readonly string ToString()
    {
        return $"MsgType={msgtype}, Flags={Convert.ToString((byte)bits, 2)}, SrcId={sourceid}, SeqNum={seqnum}, TimeSent={sentts:N0} ({new DateTime(DateTime.UnixEpoch.Ticks + sentts / 100):yyyy-MM-dd HH:mm:ss.fffffff}, MsgLen={msglen:N0}, KeyLen={keylen}, HdrLen={hdrlen}";
    }
}
