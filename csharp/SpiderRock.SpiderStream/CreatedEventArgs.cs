using System;

namespace SpiderRock.SpiderStream;

public class CreatedEventArgs<T> : EventArgs
{
    public T Created { get; internal set; }
    public Channel Channel { get; internal set; }
}
