// --------------------------------------------------------------------------------
//  SRMsgCore.Net.Proto.UDP.cs
// --------------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using SpiderRock.DataFeed.FrameHandling;
using SpiderRock.DataFeed.Diagnostics;

namespace SpiderRock.DataFeed.Proto.UDP
{
    internal sealed class UdpReceiver
    {
        private readonly AsyncCallback asyncReceive;

        private readonly UdpClient client;
        private readonly IPEndPoint endPoint;
        private readonly ConcurrentDictionary<string, IntClass> errorSet = new ConcurrentDictionary<string, IntClass>();

        private readonly FrameHandler frameHandler;
        public Channel RecvChannel;

        private double asyncRecvTime;

        public UdpReceiver(IPEndPoint endPoint, IPAddress ifaddr, FrameHandler frameHandler, int receiveBufferSize, ChannelFactory channelFactory)
        {
            this.endPoint = endPoint;
            this.frameHandler = frameHandler;

            RecvChannel = channelFactory.GetOrCreate(ChannelType.UdpRecv, endPoint.ToString(), "any");

            try
            {
                IPAddress groupAddress = endPoint.Address;
                IPAddress localAddress = ifaddr ?? IPAddress.Any;

                var iep = new IPEndPoint(localAddress, endPoint.Port);

                SRTrace.NetUdp.TraceInformation("Initializing UdpReceiver [{0}]: binding to: {1}", endPoint.ToString(),
                    iep.ToString());

                client = new UdpClient
                {
                    Client =
                    {
                        ReceiveBufferSize = receiveBufferSize
                    }, 
                    ExclusiveAddressUse = false
                };

                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                client.Client.Bind(iep);

                SRTrace.NetUdp.TraceInformation(
                    "UdpReceiver [{0}]: joining multicast group: groupAddr={1}, [localAddr={2}]", endPoint.ToString(),
                    groupAddress, localAddress);

                client.JoinMulticastGroup(groupAddress, localAddress);

                asyncReceive = OnAsyncReceive;
                asyncRecvTime = Stopwatch.GetTimestamp();

                BeginReceive();
            }
            catch (SocketException se)
            {
                SRTrace.NetUdp.TraceInformation("UdpReceiver [{0}]: create socket exception: {1}", endPoint.ToString(),
                    se.SocketErrorCode);
                throw;
            }
            catch (Exception e)
            {
                SRTrace.NetUdp.TraceError(e, "UdpReceiver [{0}]: exception initializing receiver", endPoint.ToString());
                throw;
            }
        }

        private bool IsClosed { get; set; }
        public string LastError { get; set; }

        private void BeginReceive()
        {
            if (IsClosed) return;

            try
            {
                client.BeginReceive(asyncReceive, null);
            }
            catch (SocketException se)
            {
                SRTrace.NetUdp.TraceError("UdpReceiver [{0}] BeginReceive Exception: socket error={1}",
                    endPoint.ToString(), se.SocketErrorCode);

                Close("async begin socket errror");
            }
            catch (Exception e)
            {
                SRTrace.NetUdp.TraceError(e, "UdpReceiver [{0}]: receive exception", endPoint.ToString());

                Close("async begin exception");
            }
        }

        private void OnAsyncReceive(IAsyncResult iar)
        {
            if (IsClosed) return;

            string error = null;
            Exception exception = null;

            IPEndPoint remoteEndPoint = null;

            try
            {
                byte[] buffer = client.EndReceive(iar, ref remoteEndPoint);

                if (buffer.Length == 0)
                {
                    error = string.Format("UdpReceiver [{0}]: async recv with zero bytes [remote:{1}]", endPoint,
                        remoteEndPoint);
                }
                else
                {
                    double stTime = Stopwatch.GetTimestamp();
                    double asyncElapsed = (asyncRecvTime > 0 ? (stTime - asyncRecvTime)/Stopwatch.Frequency : 0);

                    RecvChannel.RemoteEp = remoteEndPoint;

                    int roffset = frameHandler.OnFrame(buffer, buffer.Length, RecvChannel);

                    double enTime = Stopwatch.GetTimestamp();
                    double handlerElapsed = (enTime - stTime)/Stopwatch.Frequency;

                    asyncRecvTime = enTime;

                    RecvChannel.IncrementTimeCounters(asyncElapsed, handlerElapsed, roffset > 0);

                    if (roffset < 0)
                    {
                        error = string.Format("UdpReceiver [{0}]: parse error [remote:{1}]", endPoint, remoteEndPoint);
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                // ignore
            }
            catch (SocketException se)
            {
                exception = se;
                error = string.Format("UdpReceiver [{0}]: OnAsyncReceive: {1} [remote:{2}]", endPoint,
                    se.SocketErrorCode, remoteEndPoint);
            }
            catch (Exception e)
            {
                exception = e;
                error = string.Format("UdpReceiver [{0}]: OnAsyncReceive exception [remote:{1}]", endPoint,
                    remoteEndPoint);
            }
            finally
            {
                BeginReceive();
            }

            if (error == null) return;
            // note: we only log the first 10 (identical) errors 

            IntClass vv;
            if (!errorSet.TryGetValue(error, out vv))
            {
                vv = new IntClass();
                errorSet[error] = vv;
            }

            vv.value += 1;

            if (vv.value <= 10)
            {
                if (exception != null)
                {
                    SRTrace.NetUdp.TraceError(exception, error);
                }
                else
                {
                    SRTrace.NetUdp.TraceError(error);
                }
            }
        }

        public void Close(string reason)
        {
            lock (this)
            {
                if (IsClosed) return;
                IsClosed = true;

                SRTrace.NetUdp.TraceInformation("UdpReceiver [{0}]: closing receiver ({1})", endPoint.ToString(), reason);

                try
                {
                    client.Close();
                }
                catch (ObjectDisposedException)
                {
                    // do nothing
                }
                catch (Exception e)
                {
                    SRTrace.NetUdp.TraceError(e, "UdpReceiver [{0}]: exception closing socket", endPoint.ToString());
                }
            }
        }
    }
}