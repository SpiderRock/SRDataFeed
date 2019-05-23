// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using SpiderRock.DataFeed.FrameHandling;
using SpiderRock.DataFeed.Diagnostics;

namespace SpiderRock.DataFeed
{
    public sealed partial class SRDataFeedEngine
    {
        #region Container cache definitions

        private sealed class FutureBookQuoteContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<FutureBookQuote> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<FutureBookQuote> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<FutureBookQuote> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<FutureBookQuote>> Created;
            public event EventHandler<ChangedEventArgs<FutureBookQuote>> Changed;
            public event EventHandler<UpdatedEventArgs<FutureBookQuote>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<FutureBookQuote> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<FutureBookQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<FutureBookQuote> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<FutureBookQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<FutureBookQuote> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<FutureBookQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(FutureBookQuote obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<FutureBookQuote>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<FutureBookQuote> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "FutureBookQuote.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(FutureBookQuote obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<FutureBookQuote>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<FutureBookQuote> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "FutureBookQuote.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(FutureBookQuote current, FutureBookQuote previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<FutureBookQuote> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "FutureBookQuote.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<FutureBookQuote.PKeyLayout, FutureBookQuote> objectsByKey = new Dictionary<FutureBookQuote.PKeyLayout, FutureBookQuote>();
            
            [ThreadStatic] private static FutureBookQuote decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(FutureBookQuote.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(FutureBookQuote.PKeyLayout))));
                }           
                
                FutureBookQuote.PKeyLayout pkey = *(FutureBookQuote.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                FutureBookQuote item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new FutureBookQuote(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new FutureBookQuote();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class FuturePrintContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<FuturePrint> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<FuturePrint> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<FuturePrint> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<FuturePrint>> Created;
            public event EventHandler<ChangedEventArgs<FuturePrint>> Changed;
            public event EventHandler<UpdatedEventArgs<FuturePrint>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<FuturePrint> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<FuturePrint>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<FuturePrint> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<FuturePrint>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<FuturePrint> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<FuturePrint>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(FuturePrint obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<FuturePrint>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<FuturePrint> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "FuturePrint.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(FuturePrint obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<FuturePrint>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<FuturePrint> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "FuturePrint.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(FuturePrint current, FuturePrint previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<FuturePrint> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "FuturePrint.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<FuturePrint.PKeyLayout, FuturePrint> objectsByKey = new Dictionary<FuturePrint.PKeyLayout, FuturePrint>();
            
            [ThreadStatic] private static FuturePrint decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(FuturePrint.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(FuturePrint.PKeyLayout))));
                }           
                
                FuturePrint.PKeyLayout pkey = *(FuturePrint.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                FuturePrint item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new FuturePrint(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new FuturePrint();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class IndexQuoteContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<IndexQuote> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<IndexQuote> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<IndexQuote> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<IndexQuote>> Created;
            public event EventHandler<ChangedEventArgs<IndexQuote>> Changed;
            public event EventHandler<UpdatedEventArgs<IndexQuote>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<IndexQuote> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<IndexQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<IndexQuote> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<IndexQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<IndexQuote> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<IndexQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(IndexQuote obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<IndexQuote>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<IndexQuote> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "IndexQuote.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(IndexQuote obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<IndexQuote>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<IndexQuote> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "IndexQuote.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(IndexQuote current, IndexQuote previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<IndexQuote> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "IndexQuote.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<IndexQuote.PKeyLayout, IndexQuote> objectsByKey = new Dictionary<IndexQuote.PKeyLayout, IndexQuote>();
            
            [ThreadStatic] private static IndexQuote decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(IndexQuote.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(IndexQuote.PKeyLayout))));
                }           
                
                IndexQuote.PKeyLayout pkey = *(IndexQuote.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                IndexQuote item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new IndexQuote(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new IndexQuote();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class LiveSurfaceAtmContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<LiveSurfaceAtm> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<LiveSurfaceAtm> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<LiveSurfaceAtm> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<LiveSurfaceAtm>> Created;
            public event EventHandler<ChangedEventArgs<LiveSurfaceAtm>> Changed;
            public event EventHandler<UpdatedEventArgs<LiveSurfaceAtm>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<LiveSurfaceAtm> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<LiveSurfaceAtm>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<LiveSurfaceAtm> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<LiveSurfaceAtm>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<LiveSurfaceAtm> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<LiveSurfaceAtm>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(LiveSurfaceAtm obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<LiveSurfaceAtm>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<LiveSurfaceAtm> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "LiveSurfaceAtm.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(LiveSurfaceAtm obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<LiveSurfaceAtm>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<LiveSurfaceAtm> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "LiveSurfaceAtm.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(LiveSurfaceAtm current, LiveSurfaceAtm previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<LiveSurfaceAtm> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "LiveSurfaceAtm.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<LiveSurfaceAtm.PKeyLayout, LiveSurfaceAtm> objectsByKey = new Dictionary<LiveSurfaceAtm.PKeyLayout, LiveSurfaceAtm>();
            
            [ThreadStatic] private static LiveSurfaceAtm decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(LiveSurfaceAtm.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(LiveSurfaceAtm.PKeyLayout))));
                }           
                
                LiveSurfaceAtm.PKeyLayout pkey = *(LiveSurfaceAtm.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                LiveSurfaceAtm item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new LiveSurfaceAtm(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new LiveSurfaceAtm();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class OptionImpliedQuoteContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<OptionImpliedQuote> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<OptionImpliedQuote> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<OptionImpliedQuote> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<OptionImpliedQuote>> Created;
            public event EventHandler<ChangedEventArgs<OptionImpliedQuote>> Changed;
            public event EventHandler<UpdatedEventArgs<OptionImpliedQuote>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<OptionImpliedQuote> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<OptionImpliedQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<OptionImpliedQuote> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<OptionImpliedQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<OptionImpliedQuote> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<OptionImpliedQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(OptionImpliedQuote obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<OptionImpliedQuote>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<OptionImpliedQuote> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionImpliedQuote.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(OptionImpliedQuote obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<OptionImpliedQuote>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<OptionImpliedQuote> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionImpliedQuote.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(OptionImpliedQuote current, OptionImpliedQuote previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<OptionImpliedQuote> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionImpliedQuote.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<OptionImpliedQuote.PKeyLayout, OptionImpliedQuote> objectsByKey = new Dictionary<OptionImpliedQuote.PKeyLayout, OptionImpliedQuote>();
            
            [ThreadStatic] private static OptionImpliedQuote decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(OptionImpliedQuote.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(OptionImpliedQuote.PKeyLayout))));
                }           
                
                OptionImpliedQuote.PKeyLayout pkey = *(OptionImpliedQuote.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                OptionImpliedQuote item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new OptionImpliedQuote(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new OptionImpliedQuote();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class OptionNbboQuoteContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<OptionNbboQuote> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<OptionNbboQuote> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<OptionNbboQuote> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<OptionNbboQuote>> Created;
            public event EventHandler<ChangedEventArgs<OptionNbboQuote>> Changed;
            public event EventHandler<UpdatedEventArgs<OptionNbboQuote>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<OptionNbboQuote> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<OptionNbboQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<OptionNbboQuote> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<OptionNbboQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<OptionNbboQuote> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<OptionNbboQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(OptionNbboQuote obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<OptionNbboQuote>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<OptionNbboQuote> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionNbboQuote.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(OptionNbboQuote obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<OptionNbboQuote>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<OptionNbboQuote> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionNbboQuote.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(OptionNbboQuote current, OptionNbboQuote previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<OptionNbboQuote> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionNbboQuote.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<OptionNbboQuote.PKeyLayout, OptionNbboQuote> objectsByKey = new Dictionary<OptionNbboQuote.PKeyLayout, OptionNbboQuote>();
            
            [ThreadStatic] private static OptionNbboQuote decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(OptionNbboQuote.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(OptionNbboQuote.PKeyLayout))));
                }           
                
                OptionNbboQuote.PKeyLayout pkey = *(OptionNbboQuote.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                OptionNbboQuote item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new OptionNbboQuote(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new OptionNbboQuote();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class OptionPrintContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<OptionPrint> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<OptionPrint> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<OptionPrint> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<OptionPrint>> Created;
            public event EventHandler<ChangedEventArgs<OptionPrint>> Changed;
            public event EventHandler<UpdatedEventArgs<OptionPrint>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<OptionPrint> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<OptionPrint>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<OptionPrint> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<OptionPrint>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<OptionPrint> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<OptionPrint>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(OptionPrint obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<OptionPrint>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<OptionPrint> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionPrint.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(OptionPrint obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<OptionPrint>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<OptionPrint> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionPrint.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(OptionPrint current, OptionPrint previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<OptionPrint> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionPrint.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<OptionPrint.PKeyLayout, OptionPrint> objectsByKey = new Dictionary<OptionPrint.PKeyLayout, OptionPrint>();
            
            [ThreadStatic] private static OptionPrint decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(OptionPrint.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(OptionPrint.PKeyLayout))));
                }           
                
                OptionPrint.PKeyLayout pkey = *(OptionPrint.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                OptionPrint item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new OptionPrint(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new OptionPrint();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class OptionRiskFactorContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<OptionRiskFactor> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<OptionRiskFactor> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<OptionRiskFactor> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<OptionRiskFactor>> Created;
            public event EventHandler<ChangedEventArgs<OptionRiskFactor>> Changed;
            public event EventHandler<UpdatedEventArgs<OptionRiskFactor>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<OptionRiskFactor> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<OptionRiskFactor>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<OptionRiskFactor> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<OptionRiskFactor>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<OptionRiskFactor> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<OptionRiskFactor>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(OptionRiskFactor obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<OptionRiskFactor>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<OptionRiskFactor> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionRiskFactor.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(OptionRiskFactor obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<OptionRiskFactor>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<OptionRiskFactor> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionRiskFactor.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(OptionRiskFactor current, OptionRiskFactor previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<OptionRiskFactor> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "OptionRiskFactor.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<OptionRiskFactor.PKeyLayout, OptionRiskFactor> objectsByKey = new Dictionary<OptionRiskFactor.PKeyLayout, OptionRiskFactor>();
            
            [ThreadStatic] private static OptionRiskFactor decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(OptionRiskFactor.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(OptionRiskFactor.PKeyLayout))));
                }           
                
                OptionRiskFactor.PKeyLayout pkey = *(OptionRiskFactor.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                OptionRiskFactor item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new OptionRiskFactor(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new OptionRiskFactor();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class ProductDefinitionV2ContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<ProductDefinitionV2> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<ProductDefinitionV2> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<ProductDefinitionV2> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<ProductDefinitionV2>> Created;
            public event EventHandler<ChangedEventArgs<ProductDefinitionV2>> Changed;
            public event EventHandler<UpdatedEventArgs<ProductDefinitionV2>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<ProductDefinitionV2> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<ProductDefinitionV2>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<ProductDefinitionV2> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<ProductDefinitionV2>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<ProductDefinitionV2> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<ProductDefinitionV2>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(ProductDefinitionV2 obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<ProductDefinitionV2>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<ProductDefinitionV2> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "ProductDefinitionV2.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(ProductDefinitionV2 obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<ProductDefinitionV2>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<ProductDefinitionV2> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "ProductDefinitionV2.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(ProductDefinitionV2 current, ProductDefinitionV2 previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<ProductDefinitionV2> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "ProductDefinitionV2.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<ProductDefinitionV2.PKeyLayout, ProductDefinitionV2> objectsByKey = new Dictionary<ProductDefinitionV2.PKeyLayout, ProductDefinitionV2>();
            
            [ThreadStatic] private static ProductDefinitionV2 decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(ProductDefinitionV2.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(ProductDefinitionV2.PKeyLayout))));
                }           
                
                ProductDefinitionV2.PKeyLayout pkey = *(ProductDefinitionV2.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                ProductDefinitionV2 item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new ProductDefinitionV2(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new ProductDefinitionV2();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class RootDefinitionContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<RootDefinition> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<RootDefinition> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<RootDefinition> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<RootDefinition>> Created;
            public event EventHandler<ChangedEventArgs<RootDefinition>> Changed;
            public event EventHandler<UpdatedEventArgs<RootDefinition>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<RootDefinition> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<RootDefinition>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<RootDefinition> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<RootDefinition>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<RootDefinition> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<RootDefinition>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(RootDefinition obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<RootDefinition>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<RootDefinition> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "RootDefinition.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(RootDefinition obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<RootDefinition>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<RootDefinition> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "RootDefinition.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(RootDefinition current, RootDefinition previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<RootDefinition> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "RootDefinition.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<RootDefinition.PKeyLayout, RootDefinition> objectsByKey = new Dictionary<RootDefinition.PKeyLayout, RootDefinition>();
            
            [ThreadStatic] private static RootDefinition decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(RootDefinition.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(RootDefinition.PKeyLayout))));
                }           
                
                RootDefinition.PKeyLayout pkey = *(RootDefinition.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                RootDefinition item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new RootDefinition(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new RootDefinition();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class SpreadBookQuoteContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<SpreadBookQuote> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<SpreadBookQuote> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<SpreadBookQuote> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<SpreadBookQuote>> Created;
            public event EventHandler<ChangedEventArgs<SpreadBookQuote>> Changed;
            public event EventHandler<UpdatedEventArgs<SpreadBookQuote>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<SpreadBookQuote> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<SpreadBookQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<SpreadBookQuote> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<SpreadBookQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<SpreadBookQuote> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<SpreadBookQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(SpreadBookQuote obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<SpreadBookQuote>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<SpreadBookQuote> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "SpreadBookQuote.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(SpreadBookQuote obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<SpreadBookQuote>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<SpreadBookQuote> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "SpreadBookQuote.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(SpreadBookQuote current, SpreadBookQuote previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<SpreadBookQuote> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "SpreadBookQuote.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<SpreadBookQuote.PKeyLayout, SpreadBookQuote> objectsByKey = new Dictionary<SpreadBookQuote.PKeyLayout, SpreadBookQuote>();
            
            [ThreadStatic] private static SpreadBookQuote decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(SpreadBookQuote.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(SpreadBookQuote.PKeyLayout))));
                }           
                
                SpreadBookQuote.PKeyLayout pkey = *(SpreadBookQuote.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                SpreadBookQuote item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new SpreadBookQuote(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new SpreadBookQuote();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class StockBookQuoteContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<StockBookQuote> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<StockBookQuote> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<StockBookQuote> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<StockBookQuote>> Created;
            public event EventHandler<ChangedEventArgs<StockBookQuote>> Changed;
            public event EventHandler<UpdatedEventArgs<StockBookQuote>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<StockBookQuote> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<StockBookQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<StockBookQuote> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<StockBookQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<StockBookQuote> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<StockBookQuote>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(StockBookQuote obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<StockBookQuote>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<StockBookQuote> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockBookQuote.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(StockBookQuote obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<StockBookQuote>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<StockBookQuote> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockBookQuote.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(StockBookQuote current, StockBookQuote previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<StockBookQuote> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockBookQuote.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<StockBookQuote.PKeyLayout, StockBookQuote> objectsByKey = new Dictionary<StockBookQuote.PKeyLayout, StockBookQuote>();
            
            [ThreadStatic] private static StockBookQuote decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(StockBookQuote.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(StockBookQuote.PKeyLayout))));
                }           
                
                StockBookQuote.PKeyLayout pkey = *(StockBookQuote.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                StockBookQuote item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new StockBookQuote(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new StockBookQuote();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class StockExchImbalanceContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<StockExchImbalance> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<StockExchImbalance> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<StockExchImbalance> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<StockExchImbalance>> Created;
            public event EventHandler<ChangedEventArgs<StockExchImbalance>> Changed;
            public event EventHandler<UpdatedEventArgs<StockExchImbalance>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<StockExchImbalance> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<StockExchImbalance>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<StockExchImbalance> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<StockExchImbalance>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<StockExchImbalance> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<StockExchImbalance>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(StockExchImbalance obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<StockExchImbalance>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<StockExchImbalance> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockExchImbalance.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(StockExchImbalance obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<StockExchImbalance>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<StockExchImbalance> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockExchImbalance.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(StockExchImbalance current, StockExchImbalance previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<StockExchImbalance> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockExchImbalance.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<StockExchImbalance.PKeyLayout, StockExchImbalance> objectsByKey = new Dictionary<StockExchImbalance.PKeyLayout, StockExchImbalance>();
            
            [ThreadStatic] private static StockExchImbalance decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(StockExchImbalance.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(StockExchImbalance.PKeyLayout))));
                }           
                
                StockExchImbalance.PKeyLayout pkey = *(StockExchImbalance.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                StockExchImbalance item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new StockExchImbalance(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new StockExchImbalance();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class StockExchImbalanceV2ContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<StockExchImbalanceV2> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<StockExchImbalanceV2> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<StockExchImbalanceV2> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<StockExchImbalanceV2>> Created;
            public event EventHandler<ChangedEventArgs<StockExchImbalanceV2>> Changed;
            public event EventHandler<UpdatedEventArgs<StockExchImbalanceV2>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<StockExchImbalanceV2> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<StockExchImbalanceV2>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<StockExchImbalanceV2> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<StockExchImbalanceV2>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<StockExchImbalanceV2> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<StockExchImbalanceV2>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(StockExchImbalanceV2 obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<StockExchImbalanceV2>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<StockExchImbalanceV2> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockExchImbalanceV2.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(StockExchImbalanceV2 obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<StockExchImbalanceV2>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<StockExchImbalanceV2> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockExchImbalanceV2.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(StockExchImbalanceV2 current, StockExchImbalanceV2 previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<StockExchImbalanceV2> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockExchImbalanceV2.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<StockExchImbalanceV2.PKeyLayout, StockExchImbalanceV2> objectsByKey = new Dictionary<StockExchImbalanceV2.PKeyLayout, StockExchImbalanceV2>();
            
            [ThreadStatic] private static StockExchImbalanceV2 decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(StockExchImbalanceV2.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(StockExchImbalanceV2.PKeyLayout))));
                }           
                
                StockExchImbalanceV2.PKeyLayout pkey = *(StockExchImbalanceV2.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                StockExchImbalanceV2 item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new StockExchImbalanceV2(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new StockExchImbalanceV2();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class StockMarketSummaryContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<StockMarketSummary> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<StockMarketSummary> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<StockMarketSummary> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<StockMarketSummary>> Created;
            public event EventHandler<ChangedEventArgs<StockMarketSummary>> Changed;
            public event EventHandler<UpdatedEventArgs<StockMarketSummary>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<StockMarketSummary> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<StockMarketSummary>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<StockMarketSummary> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<StockMarketSummary>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<StockMarketSummary> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<StockMarketSummary>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(StockMarketSummary obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<StockMarketSummary>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<StockMarketSummary> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockMarketSummary.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(StockMarketSummary obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<StockMarketSummary>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<StockMarketSummary> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockMarketSummary.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(StockMarketSummary current, StockMarketSummary previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<StockMarketSummary> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockMarketSummary.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<StockMarketSummary.PKeyLayout, StockMarketSummary> objectsByKey = new Dictionary<StockMarketSummary.PKeyLayout, StockMarketSummary>();
            
            [ThreadStatic] private static StockMarketSummary decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(StockMarketSummary.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(StockMarketSummary.PKeyLayout))));
                }           
                
                StockMarketSummary.PKeyLayout pkey = *(StockMarketSummary.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                StockMarketSummary item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new StockMarketSummary(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new StockMarketSummary();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class StockPrintContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<StockPrint> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<StockPrint> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<StockPrint> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<StockPrint>> Created;
            public event EventHandler<ChangedEventArgs<StockPrint>> Changed;
            public event EventHandler<UpdatedEventArgs<StockPrint>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<StockPrint> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<StockPrint>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<StockPrint> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<StockPrint>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<StockPrint> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<StockPrint>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(StockPrint obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<StockPrint>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<StockPrint> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockPrint.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(StockPrint obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<StockPrint>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<StockPrint> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockPrint.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(StockPrint current, StockPrint previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<StockPrint> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "StockPrint.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<StockPrint.PKeyLayout, StockPrint> objectsByKey = new Dictionary<StockPrint.PKeyLayout, StockPrint>();
            
            [ThreadStatic] private static StockPrint decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(StockPrint.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(StockPrint.PKeyLayout))));
                }           
                
                StockPrint.PKeyLayout pkey = *(StockPrint.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                StockPrint item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new StockPrint(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new StockPrint();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   
 
        private sealed class TickerDefinitionContainerCache
        {
            #region Events
            
            [ThreadStatic] private static CreatedEventArgs<TickerDefinition> createdEventArgs;
            [ThreadStatic] private static ChangedEventArgs<TickerDefinition> changedEventArgs;
            [ThreadStatic] private static UpdatedEventArgs<TickerDefinition> updatedEventArgs;

            public event EventHandler<CreatedEventArgs<TickerDefinition>> Created;
            public event EventHandler<ChangedEventArgs<TickerDefinition>> Changed;
            public event EventHandler<UpdatedEventArgs<TickerDefinition>> Updated;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static CreatedEventArgs<TickerDefinition> GetCreatedEventArgs()
            {
                return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<TickerDefinition>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static ChangedEventArgs<TickerDefinition> GetChangedEventArgs()
            {
                return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<TickerDefinition>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static UpdatedEventArgs<TickerDefinition> GetUpdatedEventArgs()
            {
                return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<TickerDefinition>());
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireCreatedEventIfSubscribed(TickerDefinition obj, Channel channel)
            {
                EventHandler<CreatedEventArgs<TickerDefinition>> created = Created;
                if (created == null) return;
                try
                {
                    CreatedEventArgs<TickerDefinition> args = GetCreatedEventArgs();
                    args.Created = obj;
                    args.Channel = channel;
                    created(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "TickerDefinition.FireCreatedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireChangedEventIfSubscribed(TickerDefinition obj, Channel channel)
            {
                EventHandler<ChangedEventArgs<TickerDefinition>> changed = Changed;
                if (changed == null) return;
                try
                {
                    ChangedEventArgs<TickerDefinition> args = GetChangedEventArgs();
                    args.Changed = obj;
                    args.Channel = channel;
                    changed(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "TickerDefinition.FireChangedEventIfSubscribed exception");
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void FireUpdatedEvent(TickerDefinition current, TickerDefinition previous, Channel channel)
            {
                try
                {
                    UpdatedEventArgs<TickerDefinition> args = GetUpdatedEventArgs();
                    args.Current = current;
                    args.Previous = previous;
                    args.Channel = channel;                    
                    Updated(this, args);
                }
                catch (Exception e)
                {
                    SRTrace.Default.TraceError(e, "TickerDefinition.FireUpdatedEvent exception");
                }
            }

            #endregion
            
            private readonly Dictionary<TickerDefinition.PKeyLayout, TickerDefinition> objectsByKey = new Dictionary<TickerDefinition.PKeyLayout, TickerDefinition>();
            
            [ThreadStatic] private static TickerDefinition decodeTarget;

            public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp, Channel channel)
            {
                if (hdr.keylen != sizeof(TickerDefinition.PKeyLayout))
                {
                    throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(TickerDefinition.PKeyLayout))));
                }           
                
                TickerDefinition.PKeyLayout pkey = *(TickerDefinition.PKeyLayout*)(ptr + offset + sizeof(Header)); 
                TickerDefinition item;        
                
                if (!objectsByKey.TryGetValue(pkey, out item))
                {       
                    lock (objectsByKey)
                    {
                        if (!objectsByKey.TryGetValue(pkey, out item))
                        {       
                            item = new TickerDefinition(pkey) {TimeRcvd = timestamp};
                            unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                            
                            FireCreatedEventIfSubscribed(item, channel);
                            if (Updated != null)
                            {
                                FireUpdatedEvent(item, null, channel);
                            }
                            FireChangedEventIfSubscribed(item, channel);

                            item.header.bits &= ~HeaderBits.FromCache;
                            
                            objectsByKey[pkey] = item;
                            
                            return;                                         
                        }   
                    }   
                }
                
                if ((hdr.bits & HeaderBits.FromCache) == HeaderBits.FromCache) return;  

                item.TimeRcvd = timestamp;
                item.Invalidate();

                if (Updated != null)
                {
                    if (decodeTarget == null) decodeTarget = new TickerDefinition();
                    
                    unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

                    decodeTarget.Invalidate();
                    item.pkey.CopyTo(decodeTarget.pkey);
                    
                    FireUpdatedEvent(decodeTarget, item, channel);
                    
                    decodeTarget.CopyTo(item);                                                                              
                }
                else
                {
                    unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
                }

                FireChangedEventIfSubscribed(item, channel);         
            }
            
            public void Clear()
            {
                lock (objectsByKey)
                {
                    objectsByKey.Clear();
                }
            }
        }   


        #endregion
        
        #region Container cache declarations
        
        private readonly FutureBookQuoteContainerCache futureBookQuoteContainerCache = new FutureBookQuoteContainerCache();
         private readonly FuturePrintContainerCache futurePrintContainerCache = new FuturePrintContainerCache();
         private readonly IndexQuoteContainerCache indexQuoteContainerCache = new IndexQuoteContainerCache();
         private readonly LiveSurfaceAtmContainerCache liveSurfaceAtmContainerCache = new LiveSurfaceAtmContainerCache();
         private readonly OptionImpliedQuoteContainerCache optionImpliedQuoteContainerCache = new OptionImpliedQuoteContainerCache();
         private readonly OptionNbboQuoteContainerCache optionNbboQuoteContainerCache = new OptionNbboQuoteContainerCache();
         private readonly OptionPrintContainerCache optionPrintContainerCache = new OptionPrintContainerCache();
         private readonly OptionRiskFactorContainerCache optionRiskFactorContainerCache = new OptionRiskFactorContainerCache();
         private readonly ProductDefinitionV2ContainerCache productDefinitionV2ContainerCache = new ProductDefinitionV2ContainerCache();
         private readonly RootDefinitionContainerCache rootDefinitionContainerCache = new RootDefinitionContainerCache();
         private readonly SpreadBookQuoteContainerCache spreadBookQuoteContainerCache = new SpreadBookQuoteContainerCache();
         private readonly StockBookQuoteContainerCache stockBookQuoteContainerCache = new StockBookQuoteContainerCache();
         private readonly StockExchImbalanceContainerCache stockExchImbalanceContainerCache = new StockExchImbalanceContainerCache();
         private readonly StockExchImbalanceV2ContainerCache stockExchImbalanceV2ContainerCache = new StockExchImbalanceV2ContainerCache();
         private readonly StockMarketSummaryContainerCache stockMarketSummaryContainerCache = new StockMarketSummaryContainerCache();
         private readonly StockPrintContainerCache stockPrintContainerCache = new StockPrintContainerCache();
         private readonly TickerDefinitionContainerCache tickerDefinitionContainerCache = new TickerDefinitionContainerCache();

        #endregion
        
        unsafe private void InitializeFrameHandler()
        {
            if (frameHandler == null)
            {
                frameHandler = new FrameHandler(sysEnvironment);
                frameHandler.OnMessage(MessageType.FutureBookQuote, futureBookQuoteContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.FuturePrint, futurePrintContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.IndexQuote, indexQuoteContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.LiveSurfaceAtm, liveSurfaceAtmContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.OptionImpliedQuote, optionImpliedQuoteContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.OptionNbboQuote, optionNbboQuoteContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.OptionPrint, optionPrintContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.OptionRiskFactor, optionRiskFactorContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.ProductDefinitionV2, productDefinitionV2ContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.RootDefinition, rootDefinitionContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.SpreadBookQuote, spreadBookQuoteContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.StockBookQuote, stockBookQuoteContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.StockExchImbalance, stockExchImbalanceContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.StockExchImbalanceV2, stockExchImbalanceV2ContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.StockMarketSummary, stockMarketSummaryContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.StockPrint, stockPrintContainerCache.OnMessage);
                 frameHandler.OnMessage(MessageType.TickerDefinition, tickerDefinitionContainerCache.OnMessage);

            }
        }
        
        private void ClearContainerCaches()
        {
            futureBookQuoteContainerCache.Clear();
             futurePrintContainerCache.Clear();
             indexQuoteContainerCache.Clear();
             liveSurfaceAtmContainerCache.Clear();
             optionImpliedQuoteContainerCache.Clear();
             optionNbboQuoteContainerCache.Clear();
             optionPrintContainerCache.Clear();
             optionRiskFactorContainerCache.Clear();
             productDefinitionV2ContainerCache.Clear();
             rootDefinitionContainerCache.Clear();
             spreadBookQuoteContainerCache.Clear();
             stockBookQuoteContainerCache.Clear();
             stockExchImbalanceContainerCache.Clear();
             stockExchImbalanceV2ContainerCache.Clear();
             stockMarketSummaryContainerCache.Clear();
             stockPrintContainerCache.Clear();
             tickerDefinitionContainerCache.Clear();

        }

        #region Event definitions

        private readonly object eventLock = new object();
        
        public event EventHandler<CreatedEventArgs<FutureBookQuote>> FutureBookQuoteCreated
        {
            add     { lock (eventLock) { futureBookQuoteContainerCache.Created += value; } }
            remove  { lock (eventLock) { futureBookQuoteContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<FutureBookQuote>> FutureBookQuoteChanged
        {
            add     { lock (eventLock) { futureBookQuoteContainerCache.Changed += value; } }
            remove  { lock (eventLock) { futureBookQuoteContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<FutureBookQuote>> FutureBookQuoteUpdated
        {
            add     { lock (eventLock) { futureBookQuoteContainerCache.Updated += value; } }
            remove  { lock (eventLock) { futureBookQuoteContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<FuturePrint>> FuturePrintCreated
        {
            add     { lock (eventLock) { futurePrintContainerCache.Created += value; } }
            remove  { lock (eventLock) { futurePrintContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<FuturePrint>> FuturePrintChanged
        {
            add     { lock (eventLock) { futurePrintContainerCache.Changed += value; } }
            remove  { lock (eventLock) { futurePrintContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<FuturePrint>> FuturePrintUpdated
        {
            add     { lock (eventLock) { futurePrintContainerCache.Updated += value; } }
            remove  { lock (eventLock) { futurePrintContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<IndexQuote>> IndexQuoteCreated
        {
            add     { lock (eventLock) { indexQuoteContainerCache.Created += value; } }
            remove  { lock (eventLock) { indexQuoteContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<IndexQuote>> IndexQuoteChanged
        {
            add     { lock (eventLock) { indexQuoteContainerCache.Changed += value; } }
            remove  { lock (eventLock) { indexQuoteContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<IndexQuote>> IndexQuoteUpdated
        {
            add     { lock (eventLock) { indexQuoteContainerCache.Updated += value; } }
            remove  { lock (eventLock) { indexQuoteContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<LiveSurfaceAtm>> LiveSurfaceAtmCreated
        {
            add     { lock (eventLock) { liveSurfaceAtmContainerCache.Created += value; } }
            remove  { lock (eventLock) { liveSurfaceAtmContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<LiveSurfaceAtm>> LiveSurfaceAtmChanged
        {
            add     { lock (eventLock) { liveSurfaceAtmContainerCache.Changed += value; } }
            remove  { lock (eventLock) { liveSurfaceAtmContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<LiveSurfaceAtm>> LiveSurfaceAtmUpdated
        {
            add     { lock (eventLock) { liveSurfaceAtmContainerCache.Updated += value; } }
            remove  { lock (eventLock) { liveSurfaceAtmContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<OptionImpliedQuote>> OptionImpliedQuoteCreated
        {
            add     { lock (eventLock) { optionImpliedQuoteContainerCache.Created += value; } }
            remove  { lock (eventLock) { optionImpliedQuoteContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<OptionImpliedQuote>> OptionImpliedQuoteChanged
        {
            add     { lock (eventLock) { optionImpliedQuoteContainerCache.Changed += value; } }
            remove  { lock (eventLock) { optionImpliedQuoteContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<OptionImpliedQuote>> OptionImpliedQuoteUpdated
        {
            add     { lock (eventLock) { optionImpliedQuoteContainerCache.Updated += value; } }
            remove  { lock (eventLock) { optionImpliedQuoteContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<OptionNbboQuote>> OptionNbboQuoteCreated
        {
            add     { lock (eventLock) { optionNbboQuoteContainerCache.Created += value; } }
            remove  { lock (eventLock) { optionNbboQuoteContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<OptionNbboQuote>> OptionNbboQuoteChanged
        {
            add     { lock (eventLock) { optionNbboQuoteContainerCache.Changed += value; } }
            remove  { lock (eventLock) { optionNbboQuoteContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<OptionNbboQuote>> OptionNbboQuoteUpdated
        {
            add     { lock (eventLock) { optionNbboQuoteContainerCache.Updated += value; } }
            remove  { lock (eventLock) { optionNbboQuoteContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<OptionPrint>> OptionPrintCreated
        {
            add     { lock (eventLock) { optionPrintContainerCache.Created += value; } }
            remove  { lock (eventLock) { optionPrintContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<OptionPrint>> OptionPrintChanged
        {
            add     { lock (eventLock) { optionPrintContainerCache.Changed += value; } }
            remove  { lock (eventLock) { optionPrintContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<OptionPrint>> OptionPrintUpdated
        {
            add     { lock (eventLock) { optionPrintContainerCache.Updated += value; } }
            remove  { lock (eventLock) { optionPrintContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<OptionRiskFactor>> OptionRiskFactorCreated
        {
            add     { lock (eventLock) { optionRiskFactorContainerCache.Created += value; } }
            remove  { lock (eventLock) { optionRiskFactorContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<OptionRiskFactor>> OptionRiskFactorChanged
        {
            add     { lock (eventLock) { optionRiskFactorContainerCache.Changed += value; } }
            remove  { lock (eventLock) { optionRiskFactorContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<OptionRiskFactor>> OptionRiskFactorUpdated
        {
            add     { lock (eventLock) { optionRiskFactorContainerCache.Updated += value; } }
            remove  { lock (eventLock) { optionRiskFactorContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<ProductDefinitionV2>> ProductDefinitionV2Created
        {
            add     { lock (eventLock) { productDefinitionV2ContainerCache.Created += value; } }
            remove  { lock (eventLock) { productDefinitionV2ContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<ProductDefinitionV2>> ProductDefinitionV2Changed
        {
            add     { lock (eventLock) { productDefinitionV2ContainerCache.Changed += value; } }
            remove  { lock (eventLock) { productDefinitionV2ContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<ProductDefinitionV2>> ProductDefinitionV2Updated
        {
            add     { lock (eventLock) { productDefinitionV2ContainerCache.Updated += value; } }
            remove  { lock (eventLock) { productDefinitionV2ContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<RootDefinition>> RootDefinitionCreated
        {
            add     { lock (eventLock) { rootDefinitionContainerCache.Created += value; } }
            remove  { lock (eventLock) { rootDefinitionContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<RootDefinition>> RootDefinitionChanged
        {
            add     { lock (eventLock) { rootDefinitionContainerCache.Changed += value; } }
            remove  { lock (eventLock) { rootDefinitionContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<RootDefinition>> RootDefinitionUpdated
        {
            add     { lock (eventLock) { rootDefinitionContainerCache.Updated += value; } }
            remove  { lock (eventLock) { rootDefinitionContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<SpreadBookQuote>> SpreadBookQuoteCreated
        {
            add     { lock (eventLock) { spreadBookQuoteContainerCache.Created += value; } }
            remove  { lock (eventLock) { spreadBookQuoteContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<SpreadBookQuote>> SpreadBookQuoteChanged
        {
            add     { lock (eventLock) { spreadBookQuoteContainerCache.Changed += value; } }
            remove  { lock (eventLock) { spreadBookQuoteContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<SpreadBookQuote>> SpreadBookQuoteUpdated
        {
            add     { lock (eventLock) { spreadBookQuoteContainerCache.Updated += value; } }
            remove  { lock (eventLock) { spreadBookQuoteContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<StockBookQuote>> StockBookQuoteCreated
        {
            add     { lock (eventLock) { stockBookQuoteContainerCache.Created += value; } }
            remove  { lock (eventLock) { stockBookQuoteContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<StockBookQuote>> StockBookQuoteChanged
        {
            add     { lock (eventLock) { stockBookQuoteContainerCache.Changed += value; } }
            remove  { lock (eventLock) { stockBookQuoteContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<StockBookQuote>> StockBookQuoteUpdated
        {
            add     { lock (eventLock) { stockBookQuoteContainerCache.Updated += value; } }
            remove  { lock (eventLock) { stockBookQuoteContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<StockExchImbalance>> StockExchImbalanceCreated
        {
            add     { lock (eventLock) { stockExchImbalanceContainerCache.Created += value; } }
            remove  { lock (eventLock) { stockExchImbalanceContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<StockExchImbalance>> StockExchImbalanceChanged
        {
            add     { lock (eventLock) { stockExchImbalanceContainerCache.Changed += value; } }
            remove  { lock (eventLock) { stockExchImbalanceContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<StockExchImbalance>> StockExchImbalanceUpdated
        {
            add     { lock (eventLock) { stockExchImbalanceContainerCache.Updated += value; } }
            remove  { lock (eventLock) { stockExchImbalanceContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<StockExchImbalanceV2>> StockExchImbalanceV2Created
        {
            add     { lock (eventLock) { stockExchImbalanceV2ContainerCache.Created += value; } }
            remove  { lock (eventLock) { stockExchImbalanceV2ContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<StockExchImbalanceV2>> StockExchImbalanceV2Changed
        {
            add     { lock (eventLock) { stockExchImbalanceV2ContainerCache.Changed += value; } }
            remove  { lock (eventLock) { stockExchImbalanceV2ContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<StockExchImbalanceV2>> StockExchImbalanceV2Updated
        {
            add     { lock (eventLock) { stockExchImbalanceV2ContainerCache.Updated += value; } }
            remove  { lock (eventLock) { stockExchImbalanceV2ContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<StockMarketSummary>> StockMarketSummaryCreated
        {
            add     { lock (eventLock) { stockMarketSummaryContainerCache.Created += value; } }
            remove  { lock (eventLock) { stockMarketSummaryContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<StockMarketSummary>> StockMarketSummaryChanged
        {
            add     { lock (eventLock) { stockMarketSummaryContainerCache.Changed += value; } }
            remove  { lock (eventLock) { stockMarketSummaryContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<StockMarketSummary>> StockMarketSummaryUpdated
        {
            add     { lock (eventLock) { stockMarketSummaryContainerCache.Updated += value; } }
            remove  { lock (eventLock) { stockMarketSummaryContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<StockPrint>> StockPrintCreated
        {
            add     { lock (eventLock) { stockPrintContainerCache.Created += value; } }
            remove  { lock (eventLock) { stockPrintContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<StockPrint>> StockPrintChanged
        {
            add     { lock (eventLock) { stockPrintContainerCache.Changed += value; } }
            remove  { lock (eventLock) { stockPrintContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<StockPrint>> StockPrintUpdated
        {
            add     { lock (eventLock) { stockPrintContainerCache.Updated += value; } }
            remove  { lock (eventLock) { stockPrintContainerCache.Updated -= value; } }
        }
         
        public event EventHandler<CreatedEventArgs<TickerDefinition>> TickerDefinitionCreated
        {
            add     { lock (eventLock) { tickerDefinitionContainerCache.Created += value; } }
            remove  { lock (eventLock) { tickerDefinitionContainerCache.Created -= value; } }
        }
        
        public event EventHandler<ChangedEventArgs<TickerDefinition>> TickerDefinitionChanged
        {
            add     { lock (eventLock) { tickerDefinitionContainerCache.Changed += value; } }
            remove  { lock (eventLock) { tickerDefinitionContainerCache.Changed -= value; } }
        }
        
        public event EventHandler<UpdatedEventArgs<TickerDefinition>> TickerDefinitionUpdated
        {
            add     { lock (eventLock) { tickerDefinitionContainerCache.Updated += value; } }
            remove  { lock (eventLock) { tickerDefinitionContainerCache.Updated -= value; } }
        }

        
        #endregion
    }
}
