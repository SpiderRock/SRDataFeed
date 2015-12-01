using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SpiderRock.DataFeed.Diagnostics;
using SpiderRock.DataFeed.FrameHandling;

namespace SpiderRock.DataFeed.Proto.UDP
{
    internal sealed class UdpDevice : IDisposable, IEquatable<UdpDevice>
    {
        public IPAddress IFAddress { get; private set; }
        public int Handle { get; private set; }

        private readonly object channelsLock = new object();
        private volatile UdpChannel[] channels = new UdpChannel[0];
        private readonly CancellationTokenSource lifetime;
        private static int handleGenerator;
        private readonly FrameHandler frameHandler;
        private readonly int receiveBufferSize;
        private readonly ChannelFactory channelFactory;

        private Thread receiveWorkerThread;

        private ReadLoopState readLoopState;
        private int readLoopCount;
        private int readErrorCount;
        private int spinSleep0;
        private int spinYieldAttempt;
        private int spinYieldSwitch;
        private long readSpinCount;

        internal UdpDevice(IPAddress addr, FrameHandler frameHandler, int receiveBufferSize, ChannelFactory channelFactory)
        {
            if (addr == null) throw new ArgumentNullException("addr");
            if (frameHandler == null) throw new ArgumentNullException("frameHandler");
            if (channelFactory == null) throw new ArgumentNullException("channelFactory");

            IFAddress = addr;

            this.frameHandler = frameHandler;
            this.receiveBufferSize = receiveBufferSize;
            this.channelFactory = channelFactory;

            lifetime = new CancellationTokenSource();
        }

        public bool Equals(UdpDevice other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Handle == other.Handle;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is UdpDevice && Equals((UdpDevice) obj);
        }

        public override int GetHashCode()
        {
            return Handle;
        }

        ~UdpDevice()
        {
            Close();
        }

        public void Open()
        {
            if (Handle > 0) return;

            Handle = Interlocked.Increment(ref handleGenerator);

            SRTrace.Aggregate += ReadWorkerState;
        }

        public void Close()
        {
            if (Handle == 0 || (lifetime.IsCancellationRequested && receiveWorkerThread == null)) return;

            if (!lifetime.IsCancellationRequested)
            {
                lifetime.Cancel();
            }

            if (receiveWorkerThread != null)
            {
                if (!receiveWorkerThread.Join(100))
                {
                    SRTrace.NetUdp.TraceWarning("UdpDevice[{0}]: ReadWorker did not exit within 100ms", Handle);
                }
                receiveWorkerThread = null;
            }

            Handle = 0;

            SRTrace.Aggregate -= ReadWorkerState;
        }

        public void Join(IPEndPoint groupEndPoint)
        {
            if (Handle == 0)
            {
                throw new InvalidOperationException("UdpDevice not open");
            }

            lock (channelsLock)
            {
                if (channels.Length > 0 && channels.Any(ch => ch.Equals(groupEndPoint)))
                {
                    return;
                }

                var channel = new UdpChannel(
                    this,
                    groupEndPoint,
                    channelFactory.GetOrCreate(ChannelType.UdpRecv, groupEndPoint.ToString(), "any"),
                    receiveBufferSize,
                    frameHandler);

                channel.Join();

                channels = channels.Union(new[] {channel}).ToArray();
            }

            if (receiveWorkerThread != null) return;

            receiveWorkerThread = new Thread(ReadWorker) {IsBackground = true};
            receiveWorkerThread.Start();
        }

        private void ReadWorker()
        {
            try
            {
                SRTrace.NetUdp.TraceDebug("UdpDevice [{0}]: ReadWorker running", Handle);

                int spinMissCount = 0;
                readLoopState = ReadLoopState.LoopStarting;

                while (!lifetime.IsCancellationRequested)
                {
                    var currentChannels = channels;

                    for (int i = 0; i < currentChannels.Length; i++)
                    {
                        try
                        {
                            if (!currentChannels[i].Handle())
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

                            readLoopCount += 1;
                            readLoopState = ReadLoopState.ReadDone;
                        }
                        catch (Exception e)
                        {
                            if (lifetime.IsCancellationRequested) break;

                            readErrorCount += 1;

                            if (readErrorCount > 0 && readErrorCount <= 5 || readErrorCount%100 == 0)
                            {
                                SRTrace.NetUdp.TraceError(e, "UdpDevice [{0}]: ReadWorker exception", Handle);
                            }
                        }
                    }
                }

                SRTrace.NetUdp.TraceDebug("UdpDevice [{0}]: ReadWorker done", Handle);
            }
            catch (TaskCanceledException)
            {
                SRTrace.NetUdp.TraceDebug("UdpDevice [{0}]: ReadWorker done", Handle);
            }
            catch (Exception e)
            {
                SRTrace.NetUdp.TraceError(e, "UdpDevice [{0}]: ReadWorker failed", Handle);
            }
        }

        private void ReadWorkerState(double elapsed)
        {
            try
            {
                SRTrace.NetUdp.TraceData(
                    TraceEventType.Verbose, 0,
                    string.Format(
                        "UdpDevice [{0}]: ReadWorker state={1,14}, loopCount={2,12:N0}, spinCount={3,12:N0}, yieldAttempt={4,12:N0}, yieldSwitch={5,12:N0}, sleep0={6,12:N0}, errorCount={7,12:N0}, threadState={8,12}, isAlive={9,6} (MBUS/{10})",
                        Handle,
                        readLoopState,
                        readLoopCount,
                        readSpinCount,
                        spinYieldAttempt,
                        spinYieldSwitch,
                        spinSleep0,
                        readErrorCount,
                        receiveWorkerThread != null ? receiveWorkerThread.ThreadState : System.Threading.ThreadState.Unstarted,
                        receiveWorkerThread != null && receiveWorkerThread.IsAlive,
                        IFAddress));

                readLoopCount = 0;
                readSpinCount = 0;

                spinSleep0 = 0;
                spinYieldSwitch = 0;
                spinYieldAttempt = 0;
            }
            catch (Exception e)
            {
                SRTrace.NetUdp.TraceError(e, "UdpDevice [{0}]: ReadWorker state logger failure", Handle);
            }
        }

        public void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }
    }
}