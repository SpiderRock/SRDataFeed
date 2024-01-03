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
    readonly Dictionary<EventHandler<UpdatedEventArgs<IMessage>>, EventHandler<UpdatedEventArgs<TMessage>>> updatedMap = new();

    public MessageEventsDispatcher(IMessageEvents<TMessage> messageEvents)
    {
        this.messageEvents = messageEvents;
    }

    [ThreadStatic] private static CreatedEventArgs<IMessage> createdEventArgs;
    [ThreadStatic] private static ChangedEventArgs<IMessage> changedEventArgs;
    [ThreadStatic] private static UpdatedEventArgs<IMessage> updatedEventArgs;

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

    public event EventHandler<UpdatedEventArgs<IMessage>> Updated
    {
        add
        {
            lock (updatedMap)
            {
                if (!updatedMap.TryGetValue(value, out var onUpdated))
                {
                    onUpdated = new((sender, args) =>
                    {
                        updatedEventArgs ??= new();
                        updatedEventArgs.Current = args.Current;
                        updatedEventArgs.Previous = args.Previous;
                        updatedEventArgs.Channel = args.Channel;

                        try
                        {
                            value(sender, updatedEventArgs);
                        }
                        finally
                        {
                            updatedEventArgs.Current = default;
                            updatedEventArgs.Previous = default;
                            updatedEventArgs.Channel = default;
                        }
                    });

                    updatedMap.Add(value, onUpdated);
                    messageEvents.Updated += onUpdated;
                }
            }
        }
        remove
        {
            lock (updatedMap)
            {
                if (updatedMap.TryGetValue(value, out var onUpdated))
                {
                    updatedMap.Remove(value);
                    messageEvents.Updated -= onUpdated;
                }
            }
        }
    }
}
