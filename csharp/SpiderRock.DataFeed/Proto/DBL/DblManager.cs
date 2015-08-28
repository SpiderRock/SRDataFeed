using System;
using System.Collections.Generic;
using System.Net;
using SpiderRock.DataFeed.FrameHandling;
using SpiderRock.DataFeed.Proto.DBL.Myricom;
using SpiderRock.DataFeed.Diagnostics;

namespace SpiderRock.DataFeed.Proto.DBL
{
    internal sealed class DblManager : IDisposable
    {
        private readonly DblDevice dblDevice;
        private readonly IPAddress ifAddr;
        private readonly ChannelFactory channelFactory;

        public DblManager(IPAddress ifAddr, string label, ChannelFactory channelFactory)
        {
            this.ifAddr = ifAddr;
            this.channelFactory = channelFactory;

            SRTrace.NetDbl.TraceInformation("DblManager [{0}]: initializing ({1})", ifAddr, label);

            try
            {
                dblDevice = new DblDevice(ifAddr, label);
                dblDevice.Open();

                SRTrace.NetDbl.TraceInformation("DblManager [{0}]: initialized (device={1}) ({2})", ifAddr,
                    dblDevice.Handle, label);
            }
            catch (Exception e)
            {
                SRTrace.NetDbl.TraceError(e);
                throw;
            }
        }

        public void Dispose()
        {
            InternalDispose();
        }

        ~DblManager()
        {
            InternalDispose();
        }

        public DblManager AddListener(IPEndPoint endPoint, FrameHandler frameHandler)
        {
            if (dblDevice == null || dblDevice.Handle == IntPtr.Zero)
            {
                SRTrace.NetDbl.TraceInformation("DblManager [{0}]: AddListener() failed; device not open", ifAddr);
                return this;
            }

            try
            {
                SRTrace.NetDbl.TraceInformation("DblAddListener [{0}]: endPoint={1,21}, isMulticast={2}", ifAddr,
                    endPoint.ToString(), true);

                var recvChannel = channelFactory.GetOrCreate(ChannelType.DblRecv, endPoint.ToString(), "any");

                string error;

                if (!dblDevice.AddListener(endPoint, true, frameHandler.OnFrame, recvChannel, out error))
                {
                    SRTrace.NetDbl.TraceError("DblAddListener [{0}]: {1} [device={2}, port={3}]", ifAddr, error,
                        dblDevice.Handle, endPoint.Port);
                    recvChannel.Close();
                }
            }
            catch (Exception e)
            {
                SRTrace.NetDbl.TraceError(e, "DblAddListener [{0}]: Exception", ifAddr);
            }

            return this;
        }

        private void InternalDispose()
        {
            dblDevice.Close();
        }
    }
}