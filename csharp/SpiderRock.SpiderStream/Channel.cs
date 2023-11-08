using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using SpiderRock.SpiderStream.Diagnostics;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream;

public sealed partial class Channel
{
    readonly CompactArray16<MessageTypeStatistics> messageTypeStatistics = new();
    readonly List<MessageTypeStatistics> messageTypeStatisticsList = new();

    internal Channel(ChannelType channelType, string channelAddr, string sourceAddr)
    {
        Name = channelAddr ?? throw new ArgumentNullException(nameof(channelAddr));
        Type = channelType;
        Address = channelAddr;
        SourceAddress = sourceAddr ?? throw new ArgumentNullException(nameof(sourceAddr));
    }

    ~Channel()
    {
        Close();
    }

    internal event EventHandler Closed;
    internal event EventHandler SequenceNumberGapsDetected;

    internal IEnumerable<MessageTypeStatistics> EnumerateMessageTypeStatistics() => messageTypeStatisticsList;

    internal long Gaps => messageTypeStatisticsList.Sum(s => s.Incremental.Gaps);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private MessageTypeStatistics GetMessageTypeStatistics(MessageType messageType)
    {
        try
        {
            return messageTypeStatistics[messageType] ?? throw null;
        }
        catch
        {
            MessageTypeStatistics stats = new(messageType);

            messageTypeStatistics[messageType] = stats;

            messageTypeStatisticsList.Add(stats);

            return stats;
        }
    }

    internal void FlushStatistics()
    {
        foreach (var s in messageTypeStatisticsList)
        {
            s.Flush();
        }
    }

    public ChannelType Type { get; }
    public string Name { get; }
    public string SourceAddress { get; }
    public string Address { get; }

    public long Errors { get; internal set; }
    public long Large { get; internal set; }
    public IPEndPoint RemoteEp { get; internal set; }
    public long Frames { get; internal set; }
    public long Bytes { get; internal set; }
    public long MaxAsyncTimeTicks { get; internal set; }
    public long MaxHandlerTimeTicks { get; internal set; }
    public long Messages { get; internal set; }
    public long SumAsyncTimeTicks { get; internal set; }
    public long SumHandlerTimeTicks { get; internal set; }

    internal long LastBytes { get; set; }
    internal long LastErrors { get; set; }
    internal long LastMessages { get; set; }
    internal long LastLarge { get; set; }
    internal long LastFrames { get; set; }
    internal double LastSumAsyncTimeTicks { get; set; }
    internal double LastSumHandlerTimeTicks { get; set; }
    internal string LastError { get; set; }
    internal Exception LastException { get; set; }

    public override string ToString() => $"{Name} [{Type}]";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void IncrementTimeCounters(long asyncElapsedTicks, long handlerElapsedTicks, bool isLarge, bool errFlag = false)
    {
        Frames += 1;

        if (errFlag) Errors += 1;
        if (isLarge) Large += 1;

        MaxAsyncTimeTicks = Math.Max(MaxAsyncTimeTicks, asyncElapsedTicks);
        MaxHandlerTimeTicks = Math.Max(MaxHandlerTimeTicks, handlerElapsedTicks);

        SumAsyncTimeTicks += asyncElapsedTicks;
        SumHandlerTimeTicks += handlerElapsedTicks;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void IncrementMsgCount(MessageType msgtype, int msglen)
    {
        Bytes += msglen;
        Messages += 1;

        _ = GetMessageTypeStatistics(msgtype)
            .IncrementCount()
            .AddBytes(msglen);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal long IncrementGapCount(MessageType msgtype)
    {
        try
        {
            SequenceNumberGapsDetected?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception e)
        {
            SRTrace.Net.SeqNumber.TraceError(e, $"Invoking {nameof(SequenceNumberGapsDetected)}");
        }

        return GetMessageTypeStatistics(msgtype).IncrementGaps();
    }

    internal void Close()
    {
        Closed?.Invoke(this, EventArgs.Empty);
    }

    internal class MessageTypeStatistics
    {
        (long Count, long Bytes, long Gaps) current;
        (long Count, long Bytes, long Gaps) last;

        public MessageTypeStatistics(MessageType messageType)
        {
            this.MessageType = messageType;
        }

        public MessageType MessageType { get; }

        public (long Count, long Bytes, long Gaps) Incremental { get; private set; }

        public (long Count, long Bytes, long Gaps) Total { get; private set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MessageTypeStatistics IncrementCount()
        {
            current.Count++;
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MessageTypeStatistics AddBytes(int bytes)
        {
            current.Bytes += bytes;
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long IncrementGaps() => ++current.Gaps - last.Gaps;

        public void Flush()
        {
            Total = current;

            Incremental = (
                Count: Total.Count - last.Count,
                Bytes: Total.Bytes - last.Bytes,
                Gaps: Total.Gaps - last.Gaps
                );

            last = Total;
        }
    }
}
