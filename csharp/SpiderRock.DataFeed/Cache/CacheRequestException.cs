using System;

namespace SpiderRock.DataFeed.Cache
{
    internal class CacheRequestException : Exception
    {
        public CacheRequestException(string message) : base(message)
        {
        }
    }
}