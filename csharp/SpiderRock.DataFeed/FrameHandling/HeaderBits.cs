using System;

namespace SpiderRock.DataFeed.FrameHandling
{
    [Flags]
    public enum HeaderBits : byte
    {
        None = 0,
        FromCache = 2,
    }
}