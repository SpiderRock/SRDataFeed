using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using SpiderRock.DataFeed.Diagnostics;
using SpiderRock.DataFeed.FrameHandling;

namespace SpiderRock.DataFeed.Proto.UDP
{
    internal sealed class UdpChannel : IDisposable, IEquatable<UdpChannel>, IEquatable<IPEndPoint>
    {
        private static readonly long NanosecondsUpToUnixEpoch = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks) * 100;

        private static readonly double Frequency = Stopwatch.Frequency;
        private readonly byte[] buffer = new byte[1500];

        private readonly UdpDevice device;
        private readonly FrameHandler frameHandler;

        private readonly IPEndPoint groupEndPoint;
        private readonly IPEndPoint localEndPoint;
        private readonly int receiveBufferSize;
        private readonly IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Loopback, 0);

        private UdpClient client;
        private long handlerBegin;
        private long handlerEnd = Stopwatch.GetTimestamp();

        public UdpChannel(UdpDevice device, IPEndPoint groupEndPoint, Channel recvChannel, int receiveBufferSize,
            FrameHandler frameHandler)
        {
            if (device == null) throw new ArgumentNullException("device");
            if (groupEndPoint == null) throw new ArgumentNullException("groupEndPoint");
            if (recvChannel == null) throw new ArgumentNullException("recvChannel");
            if (frameHandler == null) throw new ArgumentNullException("frameHandler");

            this.device = device;
            this.receiveBufferSize = receiveBufferSize;
            this.frameHandler = frameHandler;
            this.groupEndPoint = groupEndPoint;

            RecvChannel = recvChannel;

            localEndPoint = new IPEndPoint(device.IFAddress, groupEndPoint.Port);
        }

        public Channel RecvChannel { get; set; }

        public long NumParseErrors { get; private set; }
        public long NumZeroLengthRecv { get; private set; }

        public void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }

        public bool Equals(IPEndPoint other)
        {
            return !ReferenceEquals(null, other) && Equals(groupEndPoint, other);
        }

        public bool Equals(UdpChannel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.groupEndPoint);
        }

        public void Join()
        {
            if (client != null) return;

            client = new UdpClient
            {
                ExclusiveAddressUse = false,
                Client =
                {
                    Blocking = false,
                    ReceiveBufferSize = receiveBufferSize
                }
            };

            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.Client.Bind(localEndPoint);
            client.JoinMulticastGroup(groupEndPoint.Address, localEndPoint.Address);

            SRTrace.NetUdp.TraceInformation(
                "UdpDevice [{0}]: joined multicast channel [groupAddr={1}, localEndPoint={2}]", device.Handle,
                groupEndPoint.Address, localEndPoint);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is UdpChannel && Equals((UdpChannel) obj);
        }

        public override int GetHashCode()
        {
            return groupEndPoint.GetHashCode();
        }

        ~UdpChannel()
        {
            Close();
        }

        public void Close()
        {
            if (client == null) return;

            try
            {
                client.DropMulticastGroup(groupEndPoint.Address);
                client.Close();
            }
            catch (Exception e)
            {
                SRTrace.NetUdp.TraceError(e, "UdpChannel.Close() failure");
            }

            SRTrace.NetUdp.TraceInformation(
                "UdpDevice [{0}]: left multicast channel [groupAddr={1}, localEndPoint={2}]", device.Handle,
                groupEndPoint.Address, localEndPoint);

            client = null;
        }

        public override string ToString()
        {
            return groupEndPoint.ToString();
        }

        public bool Handle()
        {
            if (client.Available == 0)
            {
                NumZeroLengthRecv += 1;
                return false;
            }
            EndPoint remoteEndPointRef = remoteEndPoint;
            var recvLength = client.Client.ReceiveFrom(buffer, buffer.Length, SocketFlags.None, ref remoteEndPointRef);
            RecvChannel.RemoteEp = remoteEndPoint;

            handlerBegin = Stopwatch.GetTimestamp();

            var asyncElapsed = (handlerBegin - handlerEnd)/Frequency;

            var netTimestamp = unchecked(DateTime.UtcNow.Ticks*100 - NanosecondsUpToUnixEpoch);

            var roffset = frameHandler.OnFrame(buffer, recvLength, netTimestamp, RecvChannel);

            handlerEnd = Stopwatch.GetTimestamp();

            RecvChannel.IncrementTimeCounters(asyncElapsed, (handlerEnd - handlerBegin)/Frequency, roffset > 0);

            if (roffset < 0)
            {
                NumParseErrors += 1;
            }

            return true;
        }
    }
}