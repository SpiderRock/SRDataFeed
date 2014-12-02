using System;

namespace SpiderRock.DataFeed
{
    public class UpdatedEventArgs<T> : EventArgs
    {
        public T Previous { get; internal set; }
        public T Current { get; internal set; }
    }
}