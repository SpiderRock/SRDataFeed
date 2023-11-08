using System;

namespace SpiderRock.SpiderStream;

internal ref struct Frame
{
    public Frame(ReadOnlySpan<byte> payload, long netTimestamp, ChannelContext context, bool fromCache)
    {
        Payload = payload;
        NetTimestamp = netTimestamp;
        Context = context;
        FromCache = fromCache;
    }

    public ReadOnlySpan<byte> Payload { get; set; }
    public long NetTimestamp { get; init; }
    public ChannelContext Context { get; init; }
    public bool FromCache { get; init; }
}
