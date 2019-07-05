using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SpiderRock.DataFeed.FrameHandling;
using SpiderRock.DataFeed.Diagnostics;

namespace SpiderRock.DataFeed.Cache
{
    internal sealed class CacheClient : IDisposable
    {
        const string ErrorPfx = "Error: ";

        private readonly object disposeLock = new object();
        private readonly IPEndPoint endPoint;
        private readonly FrameHandler frameHandler;
        private readonly Channel recvChannel;
        private readonly Channel sendChannel;

        private Socket client;
        private CacheComplete cacheComplete;

        public unsafe CacheClient(IPEndPoint endPoint, FrameHandler frameHandler, ChannelFactory channelFactory)
        {
            this.endPoint = endPoint;

            this.frameHandler = frameHandler;
            this.frameHandler.OnMessage(MessageType.CacheComplete, HandleCacheComplete);

            sendChannel = channelFactory.GetOrCreate(ChannelType.TcpSend, "tcp.init", endPoint.ToString());
            recvChannel = channelFactory.GetOrCreate(ChannelType.TcpRecv, "tpc.init", endPoint.ToString());

            sendChannel.RemoteEp = endPoint;
            recvChannel.RemoteEp = endPoint;
        }

        ~CacheClient()
        {
            InternalDispose();
        }

        public void Dispose()
        {
            InternalDispose();
            GC.SuppressFinalize(this);
        }

        private void InternalDispose()
        {
            lock (disposeLock)
            {
                if (client == null) return;

                SRTrace.NetTcp.TraceInformation("CacheClient [{0}]: disposing", endPoint.ToString());

                try
                {
                    frameHandler.OnMessage(MessageType.CacheComplete, null);

                    sendChannel.Close();
                    recvChannel.Close();

                    if (client.Connected)
                    {
                        SRTrace.NetTcp.TraceInformation("CacheClient [{0}]: closing socket", endPoint.ToString());
                        client.Close(30);
                    }
                }
                catch (ObjectDisposedException)
                {
                }
                finally
                {
                    client = null;
                }
            }
        }

        public void Connect()
        {
            SRTrace.NetTcp.TraceInformation("{0}: initiating connection", this);

            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true
            };

            try
            {
                client.Connect(endPoint);
                client.Blocking = true;
            }
            catch (Exception e)
            {
                SRTrace.NetTcp.TraceError(e, "{0}: connection failed", this);
                throw;
            }

            SRTrace.NetTcp.TraceInformation("{0}: connection succeeded", this);
        }

        public override string ToString()
        {
            return client != null && client.LocalEndPoint != null
                ? string.Format("CacheClient [{0}] [{1}]", endPoint, client.LocalEndPoint)
                : string.Format("CacheClient [{0}]", endPoint);
        }

        public unsafe void SendRequest(MessageType[] requestList)
        {
            var msg = new GetCache
            {
                RequestID = 1,
                MsgTypeList = requestList.Select(msgtype => new GetCache.MsgTypeItem(msgtype)).ToArray(),
                header = {environment = frameHandler.SysEnvironment}
            };

            int length;
            var sendBuffer = new byte[16*1024];
            fixed (byte* sendBufferPtr = sendBuffer)
            {
                length = (int)(Formatter.Default.Encode(msg, sendBufferPtr, sendBufferPtr + sendBuffer.Length) - sendBufferPtr);
            }

            sendChannel.Frames += 1;

            long stTime = Stopwatch.GetTimestamp();

            int sent = client.Send(sendBuffer, 0, length, SocketFlags.None);

            double enTime = Stopwatch.GetTimestamp();
            double handlerElapsed = (enTime - stTime)/Stopwatch.Frequency;

            sendChannel.IncrementTimeCounters(0, handlerElapsed, false);

            if (sent != length)
            {
                throw new CacheRequestException("Cache request send error");
            }
        }

        unsafe private void HandleCacheComplete(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
        {
            cacheComplete = new CacheComplete();
            unchecked { Formatter.Default.Decode(ptr + offset, cacheComplete, ptr + maxptr); }

            if (string.IsNullOrWhiteSpace(cacheComplete.Result))
            {
                throw new CacheRequestException("Cache server did not specify a result");
            }

            if (cacheComplete.Result.StartsWith(ErrorPfx))
            {
                throw new CacheRequestException(cacheComplete.Result.Substring(ErrorPfx.Length));
            }

            SRTrace.Default.TraceDebug("{0}: {1}", this, cacheComplete.Result);
        }

        public void ReadResponse(CancellationToken cancellationToken)
        {
            SRTrace.NetTcp.TraceInformation("{0}: reading response", this);

            var rbuffer = new byte[64*1024];
            int roffset = 0;

            while (!cancellationToken.IsCancellationRequested && cacheComplete == null)
            {
                int recv = client.Receive(rbuffer, roffset, rbuffer.Length - roffset, SocketFlags.None);

                if (recv <= 0)
                {
                    SRTrace.NetTcp.TraceInformation("{0}: thread recv with zero bytes", this);

                    throw new IOException("Received zero bytes");
                }

                int rlength = roffset + recv;

                double stTime = Stopwatch.GetTimestamp();

                roffset = frameHandler.OnFrame(rbuffer, rlength, 0, recvChannel);

                double enTime = Stopwatch.GetTimestamp();
                double handlerElapsed = (enTime - stTime)/Stopwatch.Frequency;

                recvChannel.IncrementTimeCounters(0, handlerElapsed, false);

                if (roffset >= 0) continue;

                SRTrace.NetTcp.TraceError("{0}: parse error", this);

                throw new IOException("thread recv parse error");
            }

            SRTrace.NetTcp.TraceInformation("{0}: completed receiving response", this);
        }
    }
}