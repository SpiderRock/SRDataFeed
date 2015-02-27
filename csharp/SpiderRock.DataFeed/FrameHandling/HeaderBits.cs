using System;

namespace SpiderRock.DataFeed.FrameHandling
{
    [Flags]
    internal enum HeaderBits : byte
    {
        None = 0,
        FromCache = 2,
    }
}