using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.FrameHandling
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Header
    {
        public SysEnvironment environment;
        public MessageType msgtype;
        public HeaderBits bits;
        public SourceId sourceid;
        public byte seqnum;
        public long sentts;
        public ushort msglen;
        public byte keylen;

        public override string ToString()
        {
            return string.Format(
                "SysEnvironment={0}, MessageType={1}, Flags={2}, SourceId={3}, SequenceNumber={4}, TimeSent={5}, MessageLength={6}, KeyLength={7}",
                environment,
                msgtype,
                bits,
                sourceid,
                seqnum,
                sentts,
                msglen,
                keylen);
        }
    }
}