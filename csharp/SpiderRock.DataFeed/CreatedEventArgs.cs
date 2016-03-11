using System;

namespace SpiderRock.DataFeed
{
    public class CreatedEventArgs<T> : EventArgs
    {
        public T Created { get; internal set; }
        public Channel Channel { get; internal set; }
    }
}