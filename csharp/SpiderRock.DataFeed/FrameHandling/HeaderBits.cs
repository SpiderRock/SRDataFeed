using System;

namespace SpiderRock.DataFeed.FrameHandling
{
    [Flags]
    internal enum HeaderBits : byte
    {
        None = 0,
        IsDeleted = 1,
        FromCache = 2,
    }
}