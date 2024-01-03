using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SpiderRock.SpiderStream.Diagnostics;
using SpiderRock.SpiderStream.Mbus;

namespace SpiderRock.SpiderStream;

internal partial class MessageCache
{
    private abstract class MessageTypeCache<TMessage, TMessagePKeyLayout> : IFrameHandler, IMessageEvents<TMessage>
        where TMessage : new()
        where TMessagePKeyLayout : unmanaged
    {
        private static readonly int SizeOfPKey = Unsafe.SizeOf<TMessagePKeyLayout>();

        public bool HasEventHandlers { get; private set; }

        [ThreadStatic] private static CreatedEventArgs<TMessage> createdEventArgs;
        [ThreadStatic] private static ChangedEventArgs<TMessage> changedEventArgs;
        [ThreadStatic] private static UpdatedEventArgs<TMessage> updatedEventArgs;

        private event EventHandler<CreatedEventArgs<TMessage>> created;
        private event EventHandler<ChangedEventArgs<TMessage>> changed;
        private event EventHandler<UpdatedEventArgs<TMessage>> updated;

        private bool AnyEventHandlers() =>
            changed.GetInvocationList().Length > 0 ||
            created.GetInvocationList().Length > 0 ||
            updated.GetInvocationList().Length > 0;

        public event EventHandler<CreatedEventArgs<TMessage>> Created
        {
            add
            {
                lock (this)
                {
                    created += value;
                    HasEventHandlers = true;
                }
            }
            remove
            {
                lock (this)
                {
                    created -= value;
                    HasEventHandlers = AnyEventHandlers();
                }
            }
        }

        public event EventHandler<ChangedEventArgs<TMessage>> Changed
        {
            add
            {
                lock (this)
                {
                    changed += value;
                    HasEventHandlers = true;
                }
            }
            remove
            {
                lock (this)
                {
                    changed -= value;
                    HasEventHandlers = AnyEventHandlers();
                }
            }
        }

        public event EventHandler<UpdatedEventArgs<TMessage>> Updated
        {
            add
            {
                lock (this)
                {
                    updated += value;
                    HasEventHandlers = true;
                }
            }
            remove
            {
                lock (this)
                {
                    updated -= value;
                    HasEventHandlers = AnyEventHandlers();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void FireCreatedEventIfSubscribed(TMessage obj, Channel channel)
        {
            var created = this.created;
            if (created is null) return;
            try
            {
                createdEventArgs ??= new();
                createdEventArgs.Created = obj;
                createdEventArgs.Channel = channel;
                created(this, createdEventArgs);
            }
            catch (Exception e)
            {
                SRTrace.Default.TraceError(e, $"{ToString()}.{nameof(FireCreatedEventIfSubscribed)} exception");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void FireChangedEventIfSubscribed(TMessage obj, Channel channel)
        {
            var changed = this.changed;
            if (changed is null) return;
            try
            {
                changedEventArgs ??= new();
                changedEventArgs.Changed = obj;
                changedEventArgs.Channel = channel;
                changed(this, changedEventArgs);
            }
            catch (Exception e)
            {
                SRTrace.Default.TraceError(e, $"{ToString()}.{nameof(FireChangedEventIfSubscribed)} exception");
            }
        }

        private readonly Dictionary<TMessagePKeyLayout, TMessage> objectsByKey = new();

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        protected abstract void UpdateFromBuffer(ReadOnlySpan<byte> buffer, TMessage target, long timestamp);

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        protected abstract void CopyTo(TMessage fromMessage, TMessage toMessage);

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        protected abstract TMessage CreateFromBuffer(ReadOnlySpan<byte> buffer, long timestamp, bool fromCache);

        public abstract MessageType Type { get; }

        [ThreadStatic] static TMessage Previous;

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public bool TryHandle(ref Frame frame)
        {
            if (!HasEventHandlers)
            {
                return false;
            }

            var buffer = frame.Payload;
            var netTimestamp = frame.NetTimestamp;
            var channel = frame.Context.Channel;

            var hdr = MemoryMarshal.AsRef<Header>(buffer);

            if (hdr.keylen != SizeOfPKey)
            {
                throw new IOException($"Unable to parse message because expected key to be {SizeOfPKey} bytes but received a key with length {hdr.keylen}");
            }

            var pkey = MemoryMarshal.AsRef<TMessagePKeyLayout>(buffer[hdr.hdrlen..]);

            if (!objectsByKey.TryGetValue(pkey, out var item))
            {
                lock (objectsByKey)
                {
                    if (!objectsByKey.TryGetValue(pkey, out item))
                    {
                        item = CreateFromBuffer(buffer, netTimestamp, frame.FromCache);

                        FireCreatedEventIfSubscribed(item, channel);
                        FireChangedEventIfSubscribed(item, channel);

                        objectsByKey[pkey] = item;

                        return true;
                    }
                }
            }

            if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache ||
                frame.FromCache)
            {
                return false;
            }

            var updated = this.updated;

            if (updated is null)
            {
                UpdateFromBuffer(buffer, item, netTimestamp);

                FireChangedEventIfSubscribed(item, channel);
            }
            else
            {
                Previous ??= new();

                CopyTo(item, Previous);

                UpdateFromBuffer(buffer, item, netTimestamp);

                FireChangedEventIfSubscribed(item, channel);

                try
                {
                    updatedEventArgs ??= new();
                    updatedEventArgs.Current = item;
                    updatedEventArgs.Previous = Previous;
                    updatedEventArgs.Channel = channel;
                    updated(this, updatedEventArgs);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, $"{ToString()}.{nameof(TryHandle)} exception invoking {nameof(Updated)} event handlers");
                }
            }

            return true;
        }

        public abstract override string ToString();
    }
}
