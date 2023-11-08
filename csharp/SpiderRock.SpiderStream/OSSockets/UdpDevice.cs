using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SpiderRock.SpiderStream.Diagnostics;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream.OSSockets;

internal sealed class UdpDevice<TFrameHandler> : IDisposable, IEquatable<UdpDevice<TFrameHandler>>
    where TFrameHandler : IFrameHandler
{
    public IPAddress IFAddress { get; }
    public int Handle { get; private set; }

    private readonly object channelsLock = new();
    private volatile UdpChannel<TFrameHandler>[] channels = Array.Empty<UdpChannel<TFrameHandler>>();
    private readonly CancellationTokenSource lifetime;
    private static int handleGenerator;
    private readonly TFrameHandler frameHandler;
    private readonly int receiveBufferSize;
    private readonly ThreadPriority priority;

    private Thread receiveWorkerThread;

    private ReadLoopState readLoopState;
    private int readLoopCount;
    private int readErrorCount;
    private int spinSleep0;
    private int spinYieldAttempt;
    private int spinYieldSwitch;
    private long readSpinCount;

    internal UdpDevice(IPAddress addr, TFrameHandler frameHandler, int receiveBufferSize, ThreadPriority priority)
    {
        IFAddress = addr ?? throw new ArgumentNullException(nameof(addr));

        this.frameHandler = frameHandler ?? throw new ArgumentNullException(nameof(frameHandler));
        this.receiveBufferSize = receiveBufferSize;
        this.priority = priority;

        lifetime = new CancellationTokenSource();
    }

    public bool Equals(UdpDevice<TFrameHandler> other) => Handle == (other?.Handle ?? -1);

    public override bool Equals(object obj) => obj is UdpDevice<TFrameHandler> other && Equals(other);

    public override int GetHashCode() => Handle;

    ~UdpDevice()
    {
        Close();
    }

    public bool IsOpen => Handle > 0;

    public void Open()
    {
        if (IsOpen)
        {
            return;
        }

        Handle = Interlocked.Increment(ref handleGenerator);

        SRTrace.Aggregate += ReadWorkerState;
    }

    public void Close()
    {
        if (!IsOpen)
        {
            return;
        }

        if (!lifetime.IsCancellationRequested)
        {
            lifetime.Cancel();
        }

        if (receiveWorkerThread is not null)
        {
            if (!receiveWorkerThread.Join(100))
            {
                SRTrace.Net.UDP.Sockets.TraceWarning($"UdpDevice[{Handle}]: ReadWorker did not exit within 100ms");
            }
            receiveWorkerThread = null;
        }

        Handle = 0;

        SRTrace.Aggregate -= ReadWorkerState;
    }

    public void Join(IPEndPoint groupEndPoint, Channel channel)
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

            var udpChannel = new UdpChannel<TFrameHandler>(
                this,
                groupEndPoint,
                channel,
                receiveBufferSize,
                frameHandler);

            udpChannel.Join();

            channels = channels.Union(new[] { udpChannel }).ToArray();
        }

        if (receiveWorkerThread != null) return;

        receiveWorkerThread = new Thread(ReadWorker) { IsBackground = true, Priority = priority };
        receiveWorkerThread.Start();
    }

    private void ReadWorker()
    {
        try
        {
            SRTrace.Net.UDP.Sockets.TraceDebug($"UdpDevice [{Handle}]: ReadWorker running");

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

                        if (readErrorCount > 0 && readErrorCount <= 5 || readErrorCount % 100 == 0)
                        {
                            SRTrace.Net.UDP.Sockets.TraceError(e, $"UdpDevice [{Handle}]: ReadWorker exception");
                        }
                    }
                }
            }

            SRTrace.Net.UDP.Sockets.TraceDebug($"UdpDevice [{Handle}]: ReadWorker done");
        }
        catch (TaskCanceledException)
        {
            SRTrace.Net.UDP.Sockets.TraceDebug($"UdpDevice [{Handle}]: ReadWorker done");
        }
        catch (Exception e)
        {
            SRTrace.Net.UDP.Sockets.TraceError(e, $"UdpDevice [{Handle}]: ReadWorker failed");
        }
    }

    private void ReadWorkerState(double elapsed)
    {
        try
        {
            SRTrace.Net.UDP.Sockets.TraceData(
                TraceEventType.Verbose, 0,
                string.Format(
                    "UdpDevice [{0}]: ReadWorker state={1,14}, loopCount={2,12:N0}, spinCount={3,12:N0}, yieldAttempt={4,12:N0}, yieldSwitch={5,12:N0}, sleep0={6,12:N0}, errorCount={7,12:N0}, threadState={8,12}, isAlive={9,6}, priority={10,12} (MBUS/{11})",
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
                    receiveWorkerThread != null ? receiveWorkerThread.Priority.ToString() : string.Empty,
                    IFAddress));

            readLoopCount = 0;
            readSpinCount = 0;

            spinSleep0 = 0;
            spinYieldSwitch = 0;
            spinYieldAttempt = 0;
        }
        catch (Exception e)
        {
            SRTrace.Net.UDP.Sockets.TraceError(e, $"UdpDevice [{Handle}]: ReadWorker state logger failure");
        }
    }

    public void Dispose()
    {
        Close();
        GC.SuppressFinalize(this);
    }
}
