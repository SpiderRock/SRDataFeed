using System;

namespace SpiderRock.DataFeed.Messaging
{
    [Flags]
    internal enum HeaderBits : byte
    {
        None = 0,
        IsDeleted = 1,
        FromCache = 2,
    }
}