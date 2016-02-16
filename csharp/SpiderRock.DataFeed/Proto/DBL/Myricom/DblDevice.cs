using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SpiderRock.DataFeed.Diagnostics;

namespace SpiderRock.DataFeed.Proto.DBL.Myricom
{
    internal sealed class DblDevice : IDisposable
    {
        public IPAddress IFAddress { get; private set; }
        public IntPtr Handle { get; private set; }

        private int readLoopCount;        
        private int readErrorCount;

        private int spinSleep0;
        private int spinYieldAttempt;
        private int spinYieldSwitch;

        private long readSpinCount;

        private readonly string source;

        private ReadLoopState readLoopState;

        private int nextChannel;
        private readonly DblChannel[] channelSet = new DblChannel[256];
        private Task receiveWorker;
        private Thread receiveWorkerThread;
        private CancellationTokenSource lifetime;

        internal DblDevice(IPAddress addr, string source)
        {
            if (addr == null) throw new ArgumentNullException("addr");
            IFAddress = addr;

            this.source = source;
        }

        ~DblDevice()
        {
            InternalDispose();
        }

        public void Open()
        {
            IntPtr device;
            var addr = new DblLibrary.InetAddress(IFAddress);
            int openResult = DblLibrary.dbl_open(ref addr, DblLibrary.OpenMode.ThreadSafe, out device);

            if (openResult != 0)
            {
                throw new DblException(string.Format("DblDevice [{0}]: dbl_open() error=[{1}]:", IFAddress, openResult));
            }

            Handle = device;

            lifetime = new CancellationTokenSource();
            receiveWorker = Task.Factory.StartNew(() => ReceiveWorker(lifetime.Token), lifetime.Token);
            WorkerMonitor(lifetime.Token);
        }

        public void Close()
        {
            if (Handle == IntPtr.Zero || IFAddress == null) return;

            if (receiveWorker != null)
            {
                lifetime.Cancel();
                receiveWorker.Wait(100);
            }

            DblLibrary.dbl_close(Handle);

            Handle = IntPtr.Zero;
            IFAddress = null;
        }

        public bool AddListener(IPEndPoint endPoint, bool isMulticast, DblReadHandler handler, object channelStats, out string error)
        {
            if (Handle == IntPtr.Zero)
            {
                error = "device not open";
                return false;
            }

            try
            {              
                lock (this)
                {
                    channelSet[nextChannel] = new DblChannel(handler, endPoint, channelStats);
                    var context = new IntPtr(nextChannel);

                    nextChannel += 1;

                    IntPtr channel;

                    int bindResult = DblLibrary.dbl_bind(Handle, DblLibrary.DblBind.ReuseAddr, endPoint.Port, context, out channel);

                    if (bindResult != 0)
                    {
                        error = string.Format("dbl_bind failed: result={0}", bindResult);
                        return false;
                    }

                    SRTrace.NetDbl.TraceInformation("DblAddListener [{0}]: dbl_bind(): succeeded [channel={1}, port={2}]", IFAddress, channel, endPoint.Port);

                    if (isMulticast)
                    {
                        try
                        {
                            uint address = BitConverter.ToUInt32(endPoint.Address.GetAddressBytes(), 0);

                            var mcastAddr = new DblLibrary.InetAddress(address);
                            int mcastResult = DblLibrary.dbl_mcast_join(channel, ref mcastAddr, IntPtr.Zero);

                            if (mcastResult != 0)
                            {
                                SRTrace.NetDbl.TraceError("DblAddListener [{0}]: dbl_mcast_join() error=[{1}] [channel={2}, addr={3}]", IFAddress, mcastResult, channel, endPoint.Address.ToString());
                            }
                            else
                            {
                                SRTrace.NetDbl.TraceInformation("DblAddListener [{0}]: dbl_mcast_join(): succeeded [channel={1}, addr={2}]", IFAddress, channel, endPoint.Address.ToString());
                            }
                        }
                        catch (Exception e)
                        {
                            SRTrace.NetDbl.TraceError(e, "DblAddListener [{0}]: mcast_join exception: channel={1}, addr={2}", IFAddress, channel, endPoint.Address.ToString());
                        }
                    }

                    error = null;
                    return true;
                }
            }
            catch (Exception e)
            {
                SRTrace.NetDbl.TraceError(e, "DblAddListener [{0}]: Exception", IFAddress);

                error = "exception";
                return false;
            }
        }
    
        unsafe private void ReceiveWorker(CancellationToken cancellationToken)
        {
            receiveWorkerThread = Thread.CurrentThread;

            var rbuffer = new byte[65536];

            SRTrace.NetDbl.TraceInformation("> DblManager [{0}]: starting receive thread", IFAddress);

            readLoopState = ReadLoopState.LoopStarting;

            int spinMissCount = 0;
            var info = new DblLibrary.RecvInfo();

            fixed (byte* rbufferPtr = rbuffer)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        readLoopState = ReadLoopState.ReadWait;

                        int result = DblLibrary.dbl_recvfrom(Handle, DblLibrary.RecvMode.NonBlock, rbufferPtr, rbuffer.Length, &info);

                        if (result == 11) // EAGAIN
                        {
                            ++readSpinCount; // one spin count is roughly 1us

                            ++spinMissCount;

                            if (spinMissCount > 200)
                            {
                                ++spinSleep0;

                                Thread.Sleep(0);
                            }
                            else if (spinMissCount > 40)
                            {
                                ++spinYieldAttempt;

                                if (Thread.Yield())
                                {
                                    ++spinYieldSwitch;
                                }
                            }

                            continue;
                        }

                        spinMissCount = 0;

                        if (result != 0)
                        {
                            readErrorCount += 1;

                            if (readErrorCount > 0 && readErrorCount <= 5 || readErrorCount%100 == 0)
                            {
                                SRTrace.NetDbl.TraceError("DblManager [{0}]: dbl_recvfrom(): error code: {1}", IFAddress, result);
                            }
                        }

                        if (info.msgLength == 0)
                        {
                            SRTrace.NetDbl.TraceError("DblManager [{0}]: dbl_recvfrom(): zero length msg", IFAddress);
                            continue;
                        }

                        readLoopCount += 1;
                        readLoopState = ReadLoopState.ReadDone;

                        int channelPos = info.context.ToInt32();

                        if (channelPos < 0 || channelPos >= channelSet.Length)
                        {
                            SRTrace.NetDbl.TraceError("DblManager [{0}]: dbl_recvfrom(): context number range", IFAddress);
                            continue;
                        }

                        DblChannel dblChannel = channelSet[channelPos];

                        if (dblChannel == null)
                        {
                            SRTrace.NetDbl.TraceError("DblManager [{0}]: dbl_recvfrom(): null channel", IFAddress);
                            continue;
                        }

                        readLoopState = ReadLoopState.EnterHandler;

                        try
                        {
                            int roffset = dblChannel.Handler(rbuffer, (int) info.msgLength, dblChannel.ChannelStats);

                            if (roffset < 0)
                            {
                                SRTrace.NetDbl.TraceError("DblManager [{0}]: parse error", info.toAddress);
                            }
                        }
                        catch (Exception e)
                        {
                            SRTrace.NetDbl.TraceError(e, "DblManager [{0}]: parse exception", info.toAddress);
                        }

                    }
                    catch (Exception e)
                    {
                        SRTrace.NetDbl.TraceError(e, "DblManager [{0}]: recv loop exception [readLoopState={1}, readLoopCount={2}]",
                                  IFAddress, readLoopState, readLoopCount);
                    }
                }
            }
        }

        private async void WorkerMonitor(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromMinutes(1), token);

                    SRTrace.NetDbl.TraceDebug(
                        "ReadWorker [{0:D2}]: state={1,14}, loopCount={2,12:N0}, spinCount={3,12:N0}, yieldAttempt={4,12:N0}, yieldSwitch={5,12:N0}, sleep0={6,12:N0}, errorCount={7,12:N0}, threadState={8,12}, isAlive={9,6} (MBUS/{10}/{11})",
                        0, readLoopState, readLoopCount, readSpinCount, spinYieldAttempt, spinYieldSwitch, spinSleep0,
                        readErrorCount,
                        receiveWorkerThread != null ? receiveWorkerThread.ThreadState : ThreadState.Unstarted,
                        receiveWorkerThread != null && receiveWorkerThread.IsAlive, IFAddress, source);

                    readLoopCount = 0;
                    readSpinCount = 0;

                    spinSleep0 = 0;
                    spinYieldSwitch = 0;
                    spinYieldAttempt = 0;
                }
            }
            catch (TaskCanceledException)
            {
            }
        }

        public void Dispose()
        {
            InternalDispose();
            GC.SuppressFinalize(this);
        }

        private void InternalDispose()
        {
            Close();
        }
    }
}
