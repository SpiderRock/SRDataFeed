using System.Collections.Generic;
using System.Net;
using SpiderRock.DataFeed.FrameHandling;

namespace SpiderRock.DataFeed.Proto.UDP
{
    internal class UdpManager
    {
        private readonly string ifaddr;
        private readonly List<UdpReceiver> listeners = new List<UdpReceiver>();       

        public UdpManager(string ifaddr)
        {
            this.ifaddr = ifaddr;
        }

        public void AddListener(IPEndPoint endPoint, FrameHandler frameHandler)
        {
            listeners.Add(new UdpReceiver(endPoint, ifaddr, frameHandler));
        }
    }
}