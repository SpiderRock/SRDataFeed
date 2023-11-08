using System;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream;

public interface IMessageEvents<TMessage>
{
    event EventHandler<CreatedEventArgs<TMessage>> Created;

    event EventHandler<ChangedEventArgs<TMessage>> Changed;

    MessageType Type { get; }
}
