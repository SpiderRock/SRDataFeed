using System;

namespace SpiderRock.SpiderStream;

public interface IMessage
{
    DateTime Received { get; }

    DateTime Published { get; }

    long ReceivedNsecsSinceUnixEpoch { get; }

    long PublishedNsecsSinceUnixEpoch { get; }

    bool FromCache { get; }

    ushort Type { get; }
}
