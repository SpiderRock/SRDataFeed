using System;
using System.Collections.Generic;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream;

internal class MessageEventsDispatcher<TMessage> : IMessageEvents<IMessage>
    where TMessage : IMessage
{
    readonly IMessageEvents<TMessage> messageEvents;
    readonly Dictionary<EventHandler<ChangedEventArgs<IMessage>>, EventHandler<ChangedEventArgs<TMessage>>> changedMap = new();
    readonly Dictionary<EventHandler<CreatedEventArgs<IMessage>>, EventHandler<CreatedEventArgs<TMessage>>> createdMap = new();

    public MessageEventsDispatcher(IMessageEvents<TMessage> messageEvents)
    {
        this.messageEvents = messageEvents;
    }

    [ThreadStatic] private static CreatedEventArgs<IMessage> createdEventArgs;
    [ThreadStatic] private static ChangedEventArgs<IMessage> changedEventArgs;

    public MessageType Type => messageEvents.Type;

    public event EventHandler<CreatedEventArgs<IMessage>> Created
    {
        add
        {
            lock (createdMap)
            {
                if (!createdMap.TryGetValue(value, out var onCreated))
                {
                    onCreated = new((sender, args) =>
                    {
                        createdEventArgs ??= new();
                        createdEventArgs.Channel = args.Channel;
                        createdEventArgs.Created = args.Created;

                        try
                        {
                            value(sender, createdEventArgs);
                        }
                        finally
                        {
                            createdEventArgs.Channel = default;
                            createdEventArgs.Created = default;
                        }
                    });

                    createdMap.Add(value, onCreated);
                    messageEvents.Created += onCreated;
                }
            }
        }
        remove
        {
            lock (createdMap)
            {
                if (createdMap.TryGetValue(value, out var onCreated))
                {
                    createdMap.Remove(value);
                    messageEvents.Created -= onCreated;
                }
            }
        }
    }

    public event EventHandler<ChangedEventArgs<IMessage>> Changed
    {
        add
        {
            lock (changedMap)
            {
                if (!changedMap.TryGetValue(value, out var onChanged))
                {
                    onChanged = new((sender, args) =>
                    {
                        changedEventArgs ??= new();
                        changedEventArgs.Channel = args.Channel;
                        changedEventArgs.Changed = args.Changed;

                        try
                        {
                            value(sender, changedEventArgs);
                        }
                        finally
                        {
                            changedEventArgs.Channel = default;
                            changedEventArgs.Changed = default;
                        }
                    });

                    changedMap.Add(value, onChanged);
                    messageEvents.Changed += onChanged;
                }
            }
        }
        remove
        {
            lock (changedMap)
            {
                if (changedMap.TryGetValue(value, out var onChanged))
                {
                    changedMap.Remove(value);
                    messageEvents.Changed -= onChanged;
                }
            }
        }
    }
}
