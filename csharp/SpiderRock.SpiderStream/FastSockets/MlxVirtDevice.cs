using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using SpiderRock.SpiderStream.Diagnostics;
using static SpiderRock.SpiderStream.FastSockets.PInvoke;

namespace SpiderRock.SpiderStream.FastSockets;

internal sealed class MlxVirtDevice<TFrameHandler>
    where TFrameHandler : IFrameHandler
{
    public IPAddress IFAddress { get; }

    private readonly object syncRoot = new();
    private readonly string label;
    private string toString;
    private readonly TFrameHandler frameHandler;

    private Task receiveWorker;
    private Thread rxWorker;
    private CancellationTokenSource lifetime;
    private IntPtr hEndpoint;
    private RxWorkerThreadStats stats;

    public MlxVirtDevice(IPAddress addr, TFrameHandler frameHandler, string label = "Default")
    {
        IFAddress = addr ?? throw new ArgumentNullException(nameof(addr));
        this.frameHandler = frameHandler ?? throw new ArgumentNullException(nameof(frameHandler));
        this.label = label;

        toString = $"{nameof(MlxVirtDevice<TFrameHandler>)}[{label}/{IFAddress}]";
    }

    ~MlxVirtDevice()
    {
        Close();
    }

    public uint RingBufferSize { get; set; } = 1024;

    public bool RunRingBufferThreadWithTimeCriticalPriority { get; set; } = true;

    public MlxVirtDevice<TFrameHandler> Open()
    {
        lock (syncRoot)
        {
            if (IsOpen)
            {
                return this;
            }

            IN_ADDR addr = new(IFAddress);

            var openFlags = fsock_open_flags.FSOCK_UDP | fsock_open_flags.FSOCK_ENABLE_TIMESTAMPING;
            var rc = fsock_open(in addr, openFlags, out hEndpoint);

            if (rc != fsock_return_codes.SUCCESS)
            {
                throw fsock_error(nameof(fsock_open), rc, this, $"flags: {openFlags}");
            }

            fsock_ringbuf_t attrib = new()
            {
                flags = fsock_ring_buf_flags.FSOCK_SET_RINGBUF_SIZE | fsock_ring_buf_flags.FSOCK_SET_RINGBUF_THREAD_PRIORITY,
                ring_buf_size = RingBufferSize,
                rx_thread_priority = RunRingBufferThreadWithTimeCriticalPriority ? fsock_thread_priority.FSOCK_THREAD_PRIORITY_TIME_CRITICAL : fsock_thread_priority.FSOCK_THREAD_PRIORITY_NORMAL,
                rx_thread_core_exclusive = 0
            };

            rc = fsock_set_ep_attribute(hEndpoint, fsock_ep_attribute_t.FSOCK_RINGBUF_SIZE, in attrib, Unsafe.SizeOf<fsock_ringbuf_t>());
            if (rc != fsock_return_codes.SUCCESS)
            {
                SRTrace.Net.UDP.FastSockets.TraceWarning($"{ToString()}: Unable to set libfsock ring buffer size to {attrib.ring_buf_size} MB [known_issue={(fsock_known_issues)rc}, optlen={Unsafe.SizeOf<fsock_ringbuf_t>()}]");
            }
            else
            {
                SRTrace.Net.UDP.FastSockets.TraceInfo($"{ToString()}: Set libfsock ring buffer size to {attrib.ring_buf_size} MB");
            }

            lifetime = new CancellationTokenSource();

            receiveWorker = Task.Factory.StartNew(() => RxWorker(lifetime.Token), TaskCreationOptions.LongRunning);

            toString = $"{nameof(MlxVirtDevice<TFrameHandler>)}[{label}/{IFAddress}/0x{hEndpoint:X16}]";
        }

        return this;
    }

    public void Close()
    {
        lock (syncRoot)
        {
            if (!IsOpen)
            {
                return;
            }

            toString = $"{nameof(MlxVirtDevice<TFrameHandler>)}[{label}/{IFAddress}]";

            Interlocked.Exchange(ref lifetime, null)?.Cancel();
            Interlocked.Exchange(ref receiveWorker, null)?.Wait(100);

            var rc = fsock_close(Interlocked.Exchange(ref hEndpoint, default));
            if (rc != fsock_return_codes.SUCCESS)
            {
                SRTrace.Net.UDP.FastSockets.TraceWarning($"{ToString()}: {nameof(fsock_close)} return error code {rc}");
            }
        }
    }

    public bool IsOpen => hEndpoint != default;

    public override string ToString() => toString;

    public unsafe void Join(IPEndPoint endPoint, ChannelContext context)
    {
        try
        {
            lock (syncRoot)
            {
                if (!IsOpen)
                {
                    throw new InvalidOperationException($"{nameof(FastSockets.MlxVirtDevice<TFrameHandler>)} must be open");
                }

                var bindFlags = fsock_bind_flags.FSOCK_BIND_REUSEADDR | fsock_bind_flags.FSOCK_BIND_NO_UNICAST;

                var rc = fsock_bind(hEndpoint, bindFlags, endPoint.Port, context, out var hChannel);

                if (rc != fsock_return_codes.SUCCESS)
                {
                    throw fsock_error(nameof(fsock_bind), rc, this, $"flags: {bindFlags}, hEndpoint: 0x{hEndpoint:X16}, hChannel: 0x{hChannel:X16}, hContext: {context:X16}");
                }

                SRTrace.Net.UDP.FastSockets.TraceInfo($"{ToString()}: bound to port {endPoint.Port} [hChannel: 0x{hChannel:X16}]");

                IP_MREQ mreq = new()
                {
                    imr_multiaddr = new(endPoint.Address),
                    imr_interface = new(IFAddress)
                };

                rc = fsock_setopt(hChannel, fsock_setopt_t.FSOCK_JOIN_MCAST, new(&mreq), sizeof(IP_MREQ));

                if (rc != fsock_return_codes.SUCCESS)
                {
                    throw fsock_error(nameof(fsock_setopt), rc, this, $"Multicast join failed [group={mreq.imr_multiaddr}, iface={mreq.imr_interface}]");
                }

                SRTrace.Net.UDP.FastSockets.TraceInfo($"{ToString()}: joined multicast group {endPoint}");
            }
        }
        catch (System.Exception e)
        {
            SRTrace.Net.UDP.FastSockets.TraceError(e, $"{ToString()}: {nameof(Join)} exception");

            throw;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    private unsafe void RxWorker(CancellationToken cancellationToken)
    {
        rxWorker = Thread.CurrentThread;
        rxWorker.Name = ToString();
        rxWorker.Priority = ThreadPriority.Highest;

        Span<byte> buffer = stackalloc byte[ushort.MaxValue];

        SRTrace.Net.UDP.FastSockets.TraceInfo($"{ToString()}: starting receive thread");

        var len = buffer.Length;
        ref var bufferRef = ref buffer[0];

        stats = new(rxWorker)
        {
            BusyWaitState = "Begin"
        };

        stats.Start();

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                stats.BusyWaitState = "NetReceive";
                stats.Loops++;

                var result = fsock_recvfrom(hEndpoint, fsock_recv_mode_t.FSOCK_RECV_NONBLOCK, ref bufferRef, len, out var info);

                if (result == fsock_return_codes.EAGAIN)
                {
                    stats.NonBlockRecvNoData++;

                    result = fsock_recvfrom(hEndpoint, fsock_recv_mode_t.FSOCK_RECV_DEFAULT, ref bufferRef, len, out info);
                }

                int messageLength = (int)info.msg_len;

                if (result == fsock_return_codes.SUCCESS && messageLength > 0)
                {
                    stats.BusyWaitState = "MessageHandler";
                    stats.Messages++;
                    stats.Bytes += messageLength;

                    var callOfDuty = Stopwatch.GetTimestamp();

                    try
                    {
                        Frame frame = new(
                            buffer[..messageLength],
                            info.timestamp,
                            info.context,
                            false);

                        if (frameHandler.TryHandle(ref frame))
                        {
                            bufferRef = ref buffer[0];
                            len = buffer.Length;
                        }
                        else
                        {
                            var unhandledBytes = frame.Payload.Length;
                            len = unchecked(buffer.Length - unhandledBytes);
                            frame.Payload.CopyTo(buffer);
                            bufferRef = ref buffer[unhandledBytes];
                        }
                    }
                    catch (System.Exception e)
                    {
                        bufferRef = ref buffer[0];
                        len = buffer.Length;

                        stats.HandlerErrors++;

                        SRTrace.Net.UDP.FastSockets.TraceError(e, $"{ToString()}: frame handling exception");
                    }

                    stats.DutyTicks += (Stopwatch.GetTimestamp() - callOfDuty);

                    continue;
                }

                if (result == fsock_return_codes.EINTR)
                {
                    break;
                }

                if (info.msg_len == 0)
                {
                    stats.ZeroLengthMessages++;

                    SRTrace.Net.UDP.FastSockets.TraceError($"{ToString()}: {nameof(fsock_recvfrom)}(): zero length msg");
                }

                if (result != fsock_return_codes.SUCCESS)
                {
                    stats.ReceiveErrors++;

                    SRTrace.Net.UDP.FastSockets.TraceError($"{ToString()}: {nameof(fsock_recvfrom)}(): error code: {result}");
                }
            }
            catch (System.Exception e)
            {
                SRTrace.Net.UDP.FastSockets.TraceError(e, $"{ToString()}: recv loop exception [state={stats.BusyWaitState}]");
            }
        }

        stats.BusyWaitState = "End";
    }

    public RxWorkerThreadStats RotateRxWorkerStatistics() => Interlocked.Exchange(ref stats, new RxWorkerThreadStats(rxWorker).Start()).Stop();
}
