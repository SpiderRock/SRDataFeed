using System;
using System.Collections.Generic;
using System.Net;
using SpiderRock.DataFeed.FrameHandling;

namespace SpiderRock.DataFeed.Proto.UDP
{
    internal class UdpManager : IDisposable
    {
        public int ReceiveBufferSize { get; set; }
        private readonly IPAddress ifaddr;
        private readonly List<UdpReceiver> udpReceivers = new List<UdpReceiver>();
        private bool disposed;

        public UdpManager(IPAddress ifaddr, int receiveBufferSize)
        {
            ReceiveBufferSize = receiveBufferSize;
            this.ifaddr = ifaddr;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UdpManager()
        {
            Dispose(false);
        }

        public void AddListener(IPEndPoint endPoint, FrameHandler frameHandler)
        {
            lock (udpReceivers)
            {
                if (disposed)
                {
                    throw new ObjectDisposedException(GetType().FullName);
                }
                udpReceivers.Add(new UdpReceiver(endPoint, ifaddr, frameHandler, ReceiveBufferSize));
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (udpReceivers)
                {
                    if (disposed) return;

                    foreach (UdpReceiver udpReceiver in udpReceivers)
                    {
                        udpReceiver.Close("disposing");
                    }

                    disposed = true;
                }
            }
            disposed = true;
        }
    }
}