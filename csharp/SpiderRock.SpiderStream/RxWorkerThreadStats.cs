using System;
using System.Diagnostics;
using System.Threading;
using SpiderRock.SpiderStream.Diagnostics;

namespace SpiderRock.SpiderStream;

internal class RxWorkerThreadStats
{
    private readonly Stopwatch stopwatch = new();

    public RxWorkerThreadStats(Thread thread)
    {
        RxThread = thread ?? throw new ArgumentNullException(nameof(thread));
    }

    public Thread RxThread { get; }

    public long Messages { get; set; }

    public long Bytes { get; set; }

    public long NonBlockRecvNoData { get; set; }

    public long Loops { get; set; }

    public long ReceiveErrors { get; set; }

    public long HandlerErrors { get; set; }

    public long ZeroLengthMessages { get; set; }

    public long DutyTicks { get; set; }

    public string BusyWaitState { get; set; }

    public RxWorkerThreadStats Start()
    {
        stopwatch.Restart();
        return this;
    }

    public RxWorkerThreadStats Stop()
    {
        stopwatch.Stop();
        return this;
    }

    public override string ToString()
    {
        return $"{RxThread.Name,-100}: messages={$"{Messages:N0} ({Bytes / 1024D / 1024:N2} MB)",25:N0}, dutyCycle={(double)DutyTicks / stopwatch.ElapsedTicks,10:P2}, noData={(Loops > 0 ? (double)NonBlockRecvNoData / Loops : "--"),10:P2}, loops={Loops,12:N0}, bytes={Bytes,12:N0}, handlerErr={HandlerErrors,12:N0}, recvErr={ReceiveErrors,12:N0}, zeroLenMsgs={ZeroLengthMessages,12:N0}, thdState={RxThread.ThreadState,15}, busyWaitState={BusyWaitState,15}";
    }
}
