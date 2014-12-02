using System;

namespace SpiderRock.DataFeed
{
    public class ChangedEventArgs<T> : EventArgs
    {
        public T Changed { get; internal set; }
    }
}