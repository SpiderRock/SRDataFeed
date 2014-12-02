using System;

namespace SpiderRock.DataFeed.Cache
{
    public class CacheRequestException : Exception
    {
        public CacheRequestException(string message) : base(message)
        {
        }
    }
}