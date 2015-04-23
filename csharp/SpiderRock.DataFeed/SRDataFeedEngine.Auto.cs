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
			private void FireCreatedEventIfSubscribed(FutureBookQuote obj)
			{
				EventHandler<CreatedEventArgs<FutureBookQuote>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<FutureBookQuote> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "FutureBookQuote.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(FutureBookQuote obj)
			{
				EventHandler<ChangedEventArgs<FutureBookQuote>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<FutureBookQuote> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "FutureBookQuote.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(FutureBookQuote current, FutureBookQuote previous)
			{
				try
				{
					UpdatedEventArgs<FutureBookQuote> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
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

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
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
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
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
			private void FireCreatedEventIfSubscribed(FuturePrint obj)
			{
				EventHandler<CreatedEventArgs<FuturePrint>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<FuturePrint> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "FuturePrint.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(FuturePrint obj)
			{
				EventHandler<ChangedEventArgs<FuturePrint>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<FuturePrint> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "FuturePrint.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(FuturePrint current, FuturePrint previous)
			{
				try
				{
					UpdatedEventArgs<FuturePrint> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
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

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
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
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
			}
			
			public void Clear()
			{
				lock (objectsByKey)
				{
					objectsByKey.Clear();
				}
			}
		}	
 
		private sealed class FutureSettlementMarkContainerCache
		{
			#region Events
			
			[ThreadStatic] private static CreatedEventArgs<FutureSettlementMark> createdEventArgs;
			[ThreadStatic] private static ChangedEventArgs<FutureSettlementMark> changedEventArgs;
			[ThreadStatic] private static UpdatedEventArgs<FutureSettlementMark> updatedEventArgs;

			public event EventHandler<CreatedEventArgs<FutureSettlementMark>> Created;
			public event EventHandler<ChangedEventArgs<FutureSettlementMark>> Changed;
			public event EventHandler<UpdatedEventArgs<FutureSettlementMark>> Updated;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static CreatedEventArgs<FutureSettlementMark> GetCreatedEventArgs()
			{
				return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<FutureSettlementMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static ChangedEventArgs<FutureSettlementMark> GetChangedEventArgs()
			{
				return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<FutureSettlementMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static UpdatedEventArgs<FutureSettlementMark> GetUpdatedEventArgs()
			{
				return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<FutureSettlementMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireCreatedEventIfSubscribed(FutureSettlementMark obj)
			{
				EventHandler<CreatedEventArgs<FutureSettlementMark>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<FutureSettlementMark> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "FutureSettlementMark.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(FutureSettlementMark obj)
			{
				EventHandler<ChangedEventArgs<FutureSettlementMark>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<FutureSettlementMark> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "FutureSettlementMark.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(FutureSettlementMark current, FutureSettlementMark previous)
			{
				try
				{
					UpdatedEventArgs<FutureSettlementMark> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
					Updated(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "FutureSettlementMark.FireUpdatedEvent exception");
				}
			}

			#endregion
			
			private readonly Dictionary<FutureSettlementMark.PKeyLayout, FutureSettlementMark> objectsByKey = new Dictionary<FutureSettlementMark.PKeyLayout, FutureSettlementMark>();
			
			[ThreadStatic] private static FutureSettlementMark decodeTarget;

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
			{
				if (hdr.keylen != sizeof(FutureSettlementMark.PKeyLayout))
				{
					throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(FutureSettlementMark.PKeyLayout))));
				}			
				
				FutureSettlementMark.PKeyLayout pkey = *(FutureSettlementMark.PKeyLayout*)(ptr + offset + sizeof(Header)); 
				FutureSettlementMark item;		
				
				if (!objectsByKey.TryGetValue(pkey, out item))
				{		
					lock (objectsByKey)
					{
						if (!objectsByKey.TryGetValue(pkey, out item))
						{		
							item = new FutureSettlementMark(pkey) {TimeRcvd = timestamp};
							unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					if (decodeTarget == null) decodeTarget = new FutureSettlementMark();
					
					unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

					decodeTarget.Invalidate();
					item.pkey.CopyTo(decodeTarget.pkey);
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
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
			private void FireCreatedEventIfSubscribed(LiveSurfaceAtm obj)
			{
				EventHandler<CreatedEventArgs<LiveSurfaceAtm>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<LiveSurfaceAtm> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "LiveSurfaceAtm.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(LiveSurfaceAtm obj)
			{
				EventHandler<ChangedEventArgs<LiveSurfaceAtm>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<LiveSurfaceAtm> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "LiveSurfaceAtm.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(LiveSurfaceAtm current, LiveSurfaceAtm previous)
			{
				try
				{
					UpdatedEventArgs<LiveSurfaceAtm> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
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

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
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
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
			}
			
			public void Clear()
			{
				lock (objectsByKey)
				{
					objectsByKey.Clear();
				}
			}
		}	
 
		private sealed class OptionCloseMarkContainerCache
		{
			#region Events
			
			[ThreadStatic] private static CreatedEventArgs<OptionCloseMark> createdEventArgs;
			[ThreadStatic] private static ChangedEventArgs<OptionCloseMark> changedEventArgs;
			[ThreadStatic] private static UpdatedEventArgs<OptionCloseMark> updatedEventArgs;

			public event EventHandler<CreatedEventArgs<OptionCloseMark>> Created;
			public event EventHandler<ChangedEventArgs<OptionCloseMark>> Changed;
			public event EventHandler<UpdatedEventArgs<OptionCloseMark>> Updated;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static CreatedEventArgs<OptionCloseMark> GetCreatedEventArgs()
			{
				return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<OptionCloseMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static ChangedEventArgs<OptionCloseMark> GetChangedEventArgs()
			{
				return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<OptionCloseMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static UpdatedEventArgs<OptionCloseMark> GetUpdatedEventArgs()
			{
				return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<OptionCloseMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireCreatedEventIfSubscribed(OptionCloseMark obj)
			{
				EventHandler<CreatedEventArgs<OptionCloseMark>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<OptionCloseMark> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionCloseMark.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(OptionCloseMark obj)
			{
				EventHandler<ChangedEventArgs<OptionCloseMark>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<OptionCloseMark> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionCloseMark.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(OptionCloseMark current, OptionCloseMark previous)
			{
				try
				{
					UpdatedEventArgs<OptionCloseMark> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
					Updated(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionCloseMark.FireUpdatedEvent exception");
				}
			}

			#endregion
			
			private readonly Dictionary<OptionCloseMark.PKeyLayout, OptionCloseMark> objectsByKey = new Dictionary<OptionCloseMark.PKeyLayout, OptionCloseMark>();
			
			[ThreadStatic] private static OptionCloseMark decodeTarget;

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
			{
				if (hdr.keylen != sizeof(OptionCloseMark.PKeyLayout))
				{
					throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(OptionCloseMark.PKeyLayout))));
				}			
				
				OptionCloseMark.PKeyLayout pkey = *(OptionCloseMark.PKeyLayout*)(ptr + offset + sizeof(Header)); 
				OptionCloseMark item;		
				
				if (!objectsByKey.TryGetValue(pkey, out item))
				{		
					lock (objectsByKey)
					{
						if (!objectsByKey.TryGetValue(pkey, out item))
						{		
							item = new OptionCloseMark(pkey) {TimeRcvd = timestamp};
							unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					if (decodeTarget == null) decodeTarget = new OptionCloseMark();
					
					unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

					decodeTarget.Invalidate();
					item.pkey.CopyTo(decodeTarget.pkey);
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
			}
			
			public void Clear()
			{
				lock (objectsByKey)
				{
					objectsByKey.Clear();
				}
			}
		}	
 
		private sealed class OptionCloseQuoteContainerCache
		{
			#region Events
			
			[ThreadStatic] private static CreatedEventArgs<OptionCloseQuote> createdEventArgs;
			[ThreadStatic] private static ChangedEventArgs<OptionCloseQuote> changedEventArgs;
			[ThreadStatic] private static UpdatedEventArgs<OptionCloseQuote> updatedEventArgs;

			public event EventHandler<CreatedEventArgs<OptionCloseQuote>> Created;
			public event EventHandler<ChangedEventArgs<OptionCloseQuote>> Changed;
			public event EventHandler<UpdatedEventArgs<OptionCloseQuote>> Updated;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static CreatedEventArgs<OptionCloseQuote> GetCreatedEventArgs()
			{
				return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<OptionCloseQuote>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static ChangedEventArgs<OptionCloseQuote> GetChangedEventArgs()
			{
				return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<OptionCloseQuote>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static UpdatedEventArgs<OptionCloseQuote> GetUpdatedEventArgs()
			{
				return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<OptionCloseQuote>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireCreatedEventIfSubscribed(OptionCloseQuote obj)
			{
				EventHandler<CreatedEventArgs<OptionCloseQuote>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<OptionCloseQuote> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionCloseQuote.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(OptionCloseQuote obj)
			{
				EventHandler<ChangedEventArgs<OptionCloseQuote>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<OptionCloseQuote> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionCloseQuote.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(OptionCloseQuote current, OptionCloseQuote previous)
			{
				try
				{
					UpdatedEventArgs<OptionCloseQuote> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
					Updated(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionCloseQuote.FireUpdatedEvent exception");
				}
			}

			#endregion
			
			private readonly Dictionary<OptionCloseQuote.PKeyLayout, OptionCloseQuote> objectsByKey = new Dictionary<OptionCloseQuote.PKeyLayout, OptionCloseQuote>();
			
			[ThreadStatic] private static OptionCloseQuote decodeTarget;

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
			{
				if (hdr.keylen != sizeof(OptionCloseQuote.PKeyLayout))
				{
					throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(OptionCloseQuote.PKeyLayout))));
				}			
				
				OptionCloseQuote.PKeyLayout pkey = *(OptionCloseQuote.PKeyLayout*)(ptr + offset + sizeof(Header)); 
				OptionCloseQuote item;		
				
				if (!objectsByKey.TryGetValue(pkey, out item))
				{		
					lock (objectsByKey)
					{
						if (!objectsByKey.TryGetValue(pkey, out item))
						{		
							item = new OptionCloseQuote(pkey) {TimeRcvd = timestamp};
							unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					if (decodeTarget == null) decodeTarget = new OptionCloseQuote();
					
					unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

					decodeTarget.Invalidate();
					item.pkey.CopyTo(decodeTarget.pkey);
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
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
			private void FireCreatedEventIfSubscribed(OptionImpliedQuote obj)
			{
				EventHandler<CreatedEventArgs<OptionImpliedQuote>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<OptionImpliedQuote> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionImpliedQuote.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(OptionImpliedQuote obj)
			{
				EventHandler<ChangedEventArgs<OptionImpliedQuote>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<OptionImpliedQuote> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionImpliedQuote.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(OptionImpliedQuote current, OptionImpliedQuote previous)
			{
				try
				{
					UpdatedEventArgs<OptionImpliedQuote> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
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

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
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
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
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
			private void FireCreatedEventIfSubscribed(OptionNbboQuote obj)
			{
				EventHandler<CreatedEventArgs<OptionNbboQuote>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<OptionNbboQuote> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionNbboQuote.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(OptionNbboQuote obj)
			{
				EventHandler<ChangedEventArgs<OptionNbboQuote>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<OptionNbboQuote> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionNbboQuote.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(OptionNbboQuote current, OptionNbboQuote previous)
			{
				try
				{
					UpdatedEventArgs<OptionNbboQuote> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
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

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
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
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
			}
			
			public void Clear()
			{
				lock (objectsByKey)
				{
					objectsByKey.Clear();
				}
			}
		}	
 
		private sealed class OptionOpenMarkContainerCache
		{
			#region Events
			
			[ThreadStatic] private static CreatedEventArgs<OptionOpenMark> createdEventArgs;
			[ThreadStatic] private static ChangedEventArgs<OptionOpenMark> changedEventArgs;
			[ThreadStatic] private static UpdatedEventArgs<OptionOpenMark> updatedEventArgs;

			public event EventHandler<CreatedEventArgs<OptionOpenMark>> Created;
			public event EventHandler<ChangedEventArgs<OptionOpenMark>> Changed;
			public event EventHandler<UpdatedEventArgs<OptionOpenMark>> Updated;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static CreatedEventArgs<OptionOpenMark> GetCreatedEventArgs()
			{
				return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<OptionOpenMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static ChangedEventArgs<OptionOpenMark> GetChangedEventArgs()
			{
				return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<OptionOpenMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static UpdatedEventArgs<OptionOpenMark> GetUpdatedEventArgs()
			{
				return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<OptionOpenMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireCreatedEventIfSubscribed(OptionOpenMark obj)
			{
				EventHandler<CreatedEventArgs<OptionOpenMark>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<OptionOpenMark> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionOpenMark.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(OptionOpenMark obj)
			{
				EventHandler<ChangedEventArgs<OptionOpenMark>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<OptionOpenMark> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionOpenMark.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(OptionOpenMark current, OptionOpenMark previous)
			{
				try
				{
					UpdatedEventArgs<OptionOpenMark> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
					Updated(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionOpenMark.FireUpdatedEvent exception");
				}
			}

			#endregion
			
			private readonly Dictionary<OptionOpenMark.PKeyLayout, OptionOpenMark> objectsByKey = new Dictionary<OptionOpenMark.PKeyLayout, OptionOpenMark>();
			
			[ThreadStatic] private static OptionOpenMark decodeTarget;

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
			{
				if (hdr.keylen != sizeof(OptionOpenMark.PKeyLayout))
				{
					throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(OptionOpenMark.PKeyLayout))));
				}			
				
				OptionOpenMark.PKeyLayout pkey = *(OptionOpenMark.PKeyLayout*)(ptr + offset + sizeof(Header)); 
				OptionOpenMark item;		
				
				if (!objectsByKey.TryGetValue(pkey, out item))
				{		
					lock (objectsByKey)
					{
						if (!objectsByKey.TryGetValue(pkey, out item))
						{		
							item = new OptionOpenMark(pkey) {TimeRcvd = timestamp};
							unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					if (decodeTarget == null) decodeTarget = new OptionOpenMark();
					
					unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

					decodeTarget.Invalidate();
					item.pkey.CopyTo(decodeTarget.pkey);
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
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
			private void FireCreatedEventIfSubscribed(OptionPrint obj)
			{
				EventHandler<CreatedEventArgs<OptionPrint>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<OptionPrint> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionPrint.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(OptionPrint obj)
			{
				EventHandler<ChangedEventArgs<OptionPrint>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<OptionPrint> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionPrint.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(OptionPrint current, OptionPrint previous)
			{
				try
				{
					UpdatedEventArgs<OptionPrint> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
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

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
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
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
			}
			
			public void Clear()
			{
				lock (objectsByKey)
				{
					objectsByKey.Clear();
				}
			}
		}	
 
		private sealed class OptionSettlementMarkContainerCache
		{
			#region Events
			
			[ThreadStatic] private static CreatedEventArgs<OptionSettlementMark> createdEventArgs;
			[ThreadStatic] private static ChangedEventArgs<OptionSettlementMark> changedEventArgs;
			[ThreadStatic] private static UpdatedEventArgs<OptionSettlementMark> updatedEventArgs;

			public event EventHandler<CreatedEventArgs<OptionSettlementMark>> Created;
			public event EventHandler<ChangedEventArgs<OptionSettlementMark>> Changed;
			public event EventHandler<UpdatedEventArgs<OptionSettlementMark>> Updated;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static CreatedEventArgs<OptionSettlementMark> GetCreatedEventArgs()
			{
				return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<OptionSettlementMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static ChangedEventArgs<OptionSettlementMark> GetChangedEventArgs()
			{
				return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<OptionSettlementMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static UpdatedEventArgs<OptionSettlementMark> GetUpdatedEventArgs()
			{
				return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<OptionSettlementMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireCreatedEventIfSubscribed(OptionSettlementMark obj)
			{
				EventHandler<CreatedEventArgs<OptionSettlementMark>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<OptionSettlementMark> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionSettlementMark.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(OptionSettlementMark obj)
			{
				EventHandler<ChangedEventArgs<OptionSettlementMark>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<OptionSettlementMark> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionSettlementMark.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(OptionSettlementMark current, OptionSettlementMark previous)
			{
				try
				{
					UpdatedEventArgs<OptionSettlementMark> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
					Updated(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "OptionSettlementMark.FireUpdatedEvent exception");
				}
			}

			#endregion
			
			private readonly Dictionary<OptionSettlementMark.PKeyLayout, OptionSettlementMark> objectsByKey = new Dictionary<OptionSettlementMark.PKeyLayout, OptionSettlementMark>();
			
			[ThreadStatic] private static OptionSettlementMark decodeTarget;

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
			{
				if (hdr.keylen != sizeof(OptionSettlementMark.PKeyLayout))
				{
					throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(OptionSettlementMark.PKeyLayout))));
				}			
				
				OptionSettlementMark.PKeyLayout pkey = *(OptionSettlementMark.PKeyLayout*)(ptr + offset + sizeof(Header)); 
				OptionSettlementMark item;		
				
				if (!objectsByKey.TryGetValue(pkey, out item))
				{		
					lock (objectsByKey)
					{
						if (!objectsByKey.TryGetValue(pkey, out item))
						{		
							item = new OptionSettlementMark(pkey) {TimeRcvd = timestamp};
							unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					if (decodeTarget == null) decodeTarget = new OptionSettlementMark();
					
					unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

					decodeTarget.Invalidate();
					item.pkey.CopyTo(decodeTarget.pkey);
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
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
			private void FireCreatedEventIfSubscribed(StockBookQuote obj)
			{
				EventHandler<CreatedEventArgs<StockBookQuote>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<StockBookQuote> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockBookQuote.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(StockBookQuote obj)
			{
				EventHandler<ChangedEventArgs<StockBookQuote>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<StockBookQuote> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockBookQuote.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(StockBookQuote current, StockBookQuote previous)
			{
				try
				{
					UpdatedEventArgs<StockBookQuote> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
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

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
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
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
			}
			
			public void Clear()
			{
				lock (objectsByKey)
				{
					objectsByKey.Clear();
				}
			}
		}	
 
		private sealed class StockCloseMarkContainerCache
		{
			#region Events
			
			[ThreadStatic] private static CreatedEventArgs<StockCloseMark> createdEventArgs;
			[ThreadStatic] private static ChangedEventArgs<StockCloseMark> changedEventArgs;
			[ThreadStatic] private static UpdatedEventArgs<StockCloseMark> updatedEventArgs;

			public event EventHandler<CreatedEventArgs<StockCloseMark>> Created;
			public event EventHandler<ChangedEventArgs<StockCloseMark>> Changed;
			public event EventHandler<UpdatedEventArgs<StockCloseMark>> Updated;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static CreatedEventArgs<StockCloseMark> GetCreatedEventArgs()
			{
				return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<StockCloseMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static ChangedEventArgs<StockCloseMark> GetChangedEventArgs()
			{
				return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<StockCloseMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static UpdatedEventArgs<StockCloseMark> GetUpdatedEventArgs()
			{
				return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<StockCloseMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireCreatedEventIfSubscribed(StockCloseMark obj)
			{
				EventHandler<CreatedEventArgs<StockCloseMark>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<StockCloseMark> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockCloseMark.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(StockCloseMark obj)
			{
				EventHandler<ChangedEventArgs<StockCloseMark>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<StockCloseMark> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockCloseMark.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(StockCloseMark current, StockCloseMark previous)
			{
				try
				{
					UpdatedEventArgs<StockCloseMark> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
					Updated(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockCloseMark.FireUpdatedEvent exception");
				}
			}

			#endregion
			
			private readonly Dictionary<StockCloseMark.PKeyLayout, StockCloseMark> objectsByKey = new Dictionary<StockCloseMark.PKeyLayout, StockCloseMark>();
			
			[ThreadStatic] private static StockCloseMark decodeTarget;

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
			{
				if (hdr.keylen != sizeof(StockCloseMark.PKeyLayout))
				{
					throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(StockCloseMark.PKeyLayout))));
				}			
				
				StockCloseMark.PKeyLayout pkey = *(StockCloseMark.PKeyLayout*)(ptr + offset + sizeof(Header)); 
				StockCloseMark item;		
				
				if (!objectsByKey.TryGetValue(pkey, out item))
				{		
					lock (objectsByKey)
					{
						if (!objectsByKey.TryGetValue(pkey, out item))
						{		
							item = new StockCloseMark(pkey) {TimeRcvd = timestamp};
							unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					if (decodeTarget == null) decodeTarget = new StockCloseMark();
					
					unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

					decodeTarget.Invalidate();
					item.pkey.CopyTo(decodeTarget.pkey);
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
			}
			
			public void Clear()
			{
				lock (objectsByKey)
				{
					objectsByKey.Clear();
				}
			}
		}	
 
		private sealed class StockCloseQuoteContainerCache
		{
			#region Events
			
			[ThreadStatic] private static CreatedEventArgs<StockCloseQuote> createdEventArgs;
			[ThreadStatic] private static ChangedEventArgs<StockCloseQuote> changedEventArgs;
			[ThreadStatic] private static UpdatedEventArgs<StockCloseQuote> updatedEventArgs;

			public event EventHandler<CreatedEventArgs<StockCloseQuote>> Created;
			public event EventHandler<ChangedEventArgs<StockCloseQuote>> Changed;
			public event EventHandler<UpdatedEventArgs<StockCloseQuote>> Updated;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static CreatedEventArgs<StockCloseQuote> GetCreatedEventArgs()
			{
				return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<StockCloseQuote>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static ChangedEventArgs<StockCloseQuote> GetChangedEventArgs()
			{
				return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<StockCloseQuote>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static UpdatedEventArgs<StockCloseQuote> GetUpdatedEventArgs()
			{
				return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<StockCloseQuote>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireCreatedEventIfSubscribed(StockCloseQuote obj)
			{
				EventHandler<CreatedEventArgs<StockCloseQuote>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<StockCloseQuote> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockCloseQuote.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(StockCloseQuote obj)
			{
				EventHandler<ChangedEventArgs<StockCloseQuote>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<StockCloseQuote> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockCloseQuote.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(StockCloseQuote current, StockCloseQuote previous)
			{
				try
				{
					UpdatedEventArgs<StockCloseQuote> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
					Updated(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockCloseQuote.FireUpdatedEvent exception");
				}
			}

			#endregion
			
			private readonly Dictionary<StockCloseQuote.PKeyLayout, StockCloseQuote> objectsByKey = new Dictionary<StockCloseQuote.PKeyLayout, StockCloseQuote>();
			
			[ThreadStatic] private static StockCloseQuote decodeTarget;

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
			{
				if (hdr.keylen != sizeof(StockCloseQuote.PKeyLayout))
				{
					throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(StockCloseQuote.PKeyLayout))));
				}			
				
				StockCloseQuote.PKeyLayout pkey = *(StockCloseQuote.PKeyLayout*)(ptr + offset + sizeof(Header)); 
				StockCloseQuote item;		
				
				if (!objectsByKey.TryGetValue(pkey, out item))
				{		
					lock (objectsByKey)
					{
						if (!objectsByKey.TryGetValue(pkey, out item))
						{		
							item = new StockCloseQuote(pkey) {TimeRcvd = timestamp};
							unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					if (decodeTarget == null) decodeTarget = new StockCloseQuote();
					
					unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

					decodeTarget.Invalidate();
					item.pkey.CopyTo(decodeTarget.pkey);
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
			}
			
			public void Clear()
			{
				lock (objectsByKey)
				{
					objectsByKey.Clear();
				}
			}
		}	
 
		private sealed class StockOpenMarkContainerCache
		{
			#region Events
			
			[ThreadStatic] private static CreatedEventArgs<StockOpenMark> createdEventArgs;
			[ThreadStatic] private static ChangedEventArgs<StockOpenMark> changedEventArgs;
			[ThreadStatic] private static UpdatedEventArgs<StockOpenMark> updatedEventArgs;

			public event EventHandler<CreatedEventArgs<StockOpenMark>> Created;
			public event EventHandler<ChangedEventArgs<StockOpenMark>> Changed;
			public event EventHandler<UpdatedEventArgs<StockOpenMark>> Updated;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static CreatedEventArgs<StockOpenMark> GetCreatedEventArgs()
			{
				return createdEventArgs ?? (createdEventArgs = new CreatedEventArgs<StockOpenMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static ChangedEventArgs<StockOpenMark> GetChangedEventArgs()
			{
				return changedEventArgs ?? (changedEventArgs = new ChangedEventArgs<StockOpenMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static UpdatedEventArgs<StockOpenMark> GetUpdatedEventArgs()
			{
				return updatedEventArgs ?? (updatedEventArgs = new UpdatedEventArgs<StockOpenMark>());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireCreatedEventIfSubscribed(StockOpenMark obj)
			{
				EventHandler<CreatedEventArgs<StockOpenMark>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<StockOpenMark> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockOpenMark.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(StockOpenMark obj)
			{
				EventHandler<ChangedEventArgs<StockOpenMark>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<StockOpenMark> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockOpenMark.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(StockOpenMark current, StockOpenMark previous)
			{
				try
				{
					UpdatedEventArgs<StockOpenMark> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
					Updated(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockOpenMark.FireUpdatedEvent exception");
				}
			}

			#endregion
			
			private readonly Dictionary<StockOpenMark.PKeyLayout, StockOpenMark> objectsByKey = new Dictionary<StockOpenMark.PKeyLayout, StockOpenMark>();
			
			[ThreadStatic] private static StockOpenMark decodeTarget;

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
			{
				if (hdr.keylen != sizeof(StockOpenMark.PKeyLayout))
				{
					throw (new Exception(string.Format("Invalid MBUS Record: msg.keylen={0}, obj.keylen={1}", hdr.keylen, sizeof(StockOpenMark.PKeyLayout))));
				}			
				
				StockOpenMark.PKeyLayout pkey = *(StockOpenMark.PKeyLayout*)(ptr + offset + sizeof(Header)); 
				StockOpenMark item;		
				
				if (!objectsByKey.TryGetValue(pkey, out item))
				{		
					lock (objectsByKey)
					{
						if (!objectsByKey.TryGetValue(pkey, out item))
						{		
							item = new StockOpenMark(pkey) {TimeRcvd = timestamp};
							unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					if (decodeTarget == null) decodeTarget = new StockOpenMark();
					
					unchecked { Formatter.Default.Decode(ptr + offset, decodeTarget, ptr + maxptr); }

					decodeTarget.Invalidate();
					item.pkey.CopyTo(decodeTarget.pkey);
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
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
			private void FireCreatedEventIfSubscribed(StockPrint obj)
			{
				EventHandler<CreatedEventArgs<StockPrint>> created = Created;
				if (created == null) return;
				try
				{
					CreatedEventArgs<StockPrint> args = GetCreatedEventArgs();
					args.Created = obj;
					created(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockPrint.FireCreatedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireChangedEventIfSubscribed(StockPrint obj)
			{
				EventHandler<ChangedEventArgs<StockPrint>> changed = Changed;
				if (changed == null) return;
				try
				{
					ChangedEventArgs<StockPrint> args = GetChangedEventArgs();
					args.Changed = obj;
					changed(this, args);
				}
				catch (Exception e)
				{
					SRTrace.Default.TraceError(e, "StockPrint.FireChangedEventIfSubscribed exception");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void FireUpdatedEvent(StockPrint current, StockPrint previous)
			{
				try
				{
					UpdatedEventArgs<StockPrint> args = GetUpdatedEventArgs();
					args.Current = current;
					args.Previous = previous;
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

			public unsafe void OnMessage(byte* ptr, int maxptr, int offset, Header hdr, long timestamp)
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
							
							FireCreatedEventIfSubscribed(item);
							if (Updated != null)
							{
								FireUpdatedEvent(item, null);
							}
							FireChangedEventIfSubscribed(item);

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
					
					FireUpdatedEvent(decodeTarget, item);
					
					decodeTarget.CopyTo(item);																				
				}
				else
				{
					unchecked { Formatter.Default.Decode(ptr + offset, item, ptr + maxptr); }
				}

				FireChangedEventIfSubscribed(item);			
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
 		private readonly FutureSettlementMarkContainerCache futureSettlementMarkContainerCache = new FutureSettlementMarkContainerCache();
 		private readonly LiveSurfaceAtmContainerCache liveSurfaceAtmContainerCache = new LiveSurfaceAtmContainerCache();
 		private readonly OptionCloseMarkContainerCache optionCloseMarkContainerCache = new OptionCloseMarkContainerCache();
 		private readonly OptionCloseQuoteContainerCache optionCloseQuoteContainerCache = new OptionCloseQuoteContainerCache();
 		private readonly OptionImpliedQuoteContainerCache optionImpliedQuoteContainerCache = new OptionImpliedQuoteContainerCache();
 		private readonly OptionNbboQuoteContainerCache optionNbboQuoteContainerCache = new OptionNbboQuoteContainerCache();
 		private readonly OptionOpenMarkContainerCache optionOpenMarkContainerCache = new OptionOpenMarkContainerCache();
 		private readonly OptionPrintContainerCache optionPrintContainerCache = new OptionPrintContainerCache();
 		private readonly OptionSettlementMarkContainerCache optionSettlementMarkContainerCache = new OptionSettlementMarkContainerCache();
 		private readonly StockBookQuoteContainerCache stockBookQuoteContainerCache = new StockBookQuoteContainerCache();
 		private readonly StockCloseMarkContainerCache stockCloseMarkContainerCache = new StockCloseMarkContainerCache();
 		private readonly StockCloseQuoteContainerCache stockCloseQuoteContainerCache = new StockCloseQuoteContainerCache();
 		private readonly StockOpenMarkContainerCache stockOpenMarkContainerCache = new StockOpenMarkContainerCache();
 		private readonly StockPrintContainerCache stockPrintContainerCache = new StockPrintContainerCache();

		#endregion
		
		unsafe private void InitializeFrameHandler()
		{
			if (frameHandler == null)
			{
				frameHandler = new FrameHandler(SysEnvironment);
				frameHandler.OnMessage(MessageType.FutureBookQuote, futureBookQuoteContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.FuturePrint, futurePrintContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.FutureSettlementMark, futureSettlementMarkContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.LiveSurfaceAtm, liveSurfaceAtmContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.OptionCloseMark, optionCloseMarkContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.OptionCloseQuote, optionCloseQuoteContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.OptionImpliedQuote, optionImpliedQuoteContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.OptionNbboQuote, optionNbboQuoteContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.OptionOpenMark, optionOpenMarkContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.OptionPrint, optionPrintContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.OptionSettlementMark, optionSettlementMarkContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.StockBookQuote, stockBookQuoteContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.StockCloseMark, stockCloseMarkContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.StockCloseQuote, stockCloseQuoteContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.StockOpenMark, stockOpenMarkContainerCache.OnMessage);
 				frameHandler.OnMessage(MessageType.StockPrint, stockPrintContainerCache.OnMessage);

			}
			
			futureBookQuoteContainerCache.Clear();
 			futurePrintContainerCache.Clear();
 			futureSettlementMarkContainerCache.Clear();
 			liveSurfaceAtmContainerCache.Clear();
 			optionCloseMarkContainerCache.Clear();
 			optionCloseQuoteContainerCache.Clear();
 			optionImpliedQuoteContainerCache.Clear();
 			optionNbboQuoteContainerCache.Clear();
 			optionOpenMarkContainerCache.Clear();
 			optionPrintContainerCache.Clear();
 			optionSettlementMarkContainerCache.Clear();
 			stockBookQuoteContainerCache.Clear();
 			stockCloseMarkContainerCache.Clear();
 			stockCloseQuoteContainerCache.Clear();
 			stockOpenMarkContainerCache.Clear();
 			stockPrintContainerCache.Clear();

		}

		#region Event definitions

		private readonly object eventLock = new object();
		
		public event EventHandler<CreatedEventArgs<FutureBookQuote>> FutureBookQuoteCreated
        {
            add		{ lock (eventLock) { futureBookQuoteContainerCache.Created += value; } }
            remove	{ lock (eventLock) { futureBookQuoteContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<FutureBookQuote>> FutureBookQuoteChanged
        {
            add		{ lock (eventLock) { futureBookQuoteContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { futureBookQuoteContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<FutureBookQuote>> FutureBookQuoteUpdated
        {
            add		{ lock (eventLock) { futureBookQuoteContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { futureBookQuoteContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<FuturePrint>> FuturePrintCreated
        {
            add		{ lock (eventLock) { futurePrintContainerCache.Created += value; } }
            remove	{ lock (eventLock) { futurePrintContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<FuturePrint>> FuturePrintChanged
        {
            add		{ lock (eventLock) { futurePrintContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { futurePrintContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<FuturePrint>> FuturePrintUpdated
        {
            add		{ lock (eventLock) { futurePrintContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { futurePrintContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<FutureSettlementMark>> FutureSettlementMarkCreated
        {
            add		{ lock (eventLock) { futureSettlementMarkContainerCache.Created += value; } }
            remove	{ lock (eventLock) { futureSettlementMarkContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<FutureSettlementMark>> FutureSettlementMarkChanged
        {
            add		{ lock (eventLock) { futureSettlementMarkContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { futureSettlementMarkContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<FutureSettlementMark>> FutureSettlementMarkUpdated
        {
            add		{ lock (eventLock) { futureSettlementMarkContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { futureSettlementMarkContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<LiveSurfaceAtm>> LiveSurfaceAtmCreated
        {
            add		{ lock (eventLock) { liveSurfaceAtmContainerCache.Created += value; } }
            remove	{ lock (eventLock) { liveSurfaceAtmContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<LiveSurfaceAtm>> LiveSurfaceAtmChanged
        {
            add		{ lock (eventLock) { liveSurfaceAtmContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { liveSurfaceAtmContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<LiveSurfaceAtm>> LiveSurfaceAtmUpdated
        {
            add		{ lock (eventLock) { liveSurfaceAtmContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { liveSurfaceAtmContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<OptionCloseMark>> OptionCloseMarkCreated
        {
            add		{ lock (eventLock) { optionCloseMarkContainerCache.Created += value; } }
            remove	{ lock (eventLock) { optionCloseMarkContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<OptionCloseMark>> OptionCloseMarkChanged
        {
            add		{ lock (eventLock) { optionCloseMarkContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { optionCloseMarkContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<OptionCloseMark>> OptionCloseMarkUpdated
        {
            add		{ lock (eventLock) { optionCloseMarkContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { optionCloseMarkContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<OptionCloseQuote>> OptionCloseQuoteCreated
        {
            add		{ lock (eventLock) { optionCloseQuoteContainerCache.Created += value; } }
            remove	{ lock (eventLock) { optionCloseQuoteContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<OptionCloseQuote>> OptionCloseQuoteChanged
        {
            add		{ lock (eventLock) { optionCloseQuoteContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { optionCloseQuoteContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<OptionCloseQuote>> OptionCloseQuoteUpdated
        {
            add		{ lock (eventLock) { optionCloseQuoteContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { optionCloseQuoteContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<OptionImpliedQuote>> OptionImpliedQuoteCreated
        {
            add		{ lock (eventLock) { optionImpliedQuoteContainerCache.Created += value; } }
            remove	{ lock (eventLock) { optionImpliedQuoteContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<OptionImpliedQuote>> OptionImpliedQuoteChanged
        {
            add		{ lock (eventLock) { optionImpliedQuoteContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { optionImpliedQuoteContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<OptionImpliedQuote>> OptionImpliedQuoteUpdated
        {
            add		{ lock (eventLock) { optionImpliedQuoteContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { optionImpliedQuoteContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<OptionNbboQuote>> OptionNbboQuoteCreated
        {
            add		{ lock (eventLock) { optionNbboQuoteContainerCache.Created += value; } }
            remove	{ lock (eventLock) { optionNbboQuoteContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<OptionNbboQuote>> OptionNbboQuoteChanged
        {
            add		{ lock (eventLock) { optionNbboQuoteContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { optionNbboQuoteContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<OptionNbboQuote>> OptionNbboQuoteUpdated
        {
            add		{ lock (eventLock) { optionNbboQuoteContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { optionNbboQuoteContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<OptionOpenMark>> OptionOpenMarkCreated
        {
            add		{ lock (eventLock) { optionOpenMarkContainerCache.Created += value; } }
            remove	{ lock (eventLock) { optionOpenMarkContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<OptionOpenMark>> OptionOpenMarkChanged
        {
            add		{ lock (eventLock) { optionOpenMarkContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { optionOpenMarkContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<OptionOpenMark>> OptionOpenMarkUpdated
        {
            add		{ lock (eventLock) { optionOpenMarkContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { optionOpenMarkContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<OptionPrint>> OptionPrintCreated
        {
            add		{ lock (eventLock) { optionPrintContainerCache.Created += value; } }
            remove	{ lock (eventLock) { optionPrintContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<OptionPrint>> OptionPrintChanged
        {
            add		{ lock (eventLock) { optionPrintContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { optionPrintContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<OptionPrint>> OptionPrintUpdated
        {
            add		{ lock (eventLock) { optionPrintContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { optionPrintContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<OptionSettlementMark>> OptionSettlementMarkCreated
        {
            add		{ lock (eventLock) { optionSettlementMarkContainerCache.Created += value; } }
            remove	{ lock (eventLock) { optionSettlementMarkContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<OptionSettlementMark>> OptionSettlementMarkChanged
        {
            add		{ lock (eventLock) { optionSettlementMarkContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { optionSettlementMarkContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<OptionSettlementMark>> OptionSettlementMarkUpdated
        {
            add		{ lock (eventLock) { optionSettlementMarkContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { optionSettlementMarkContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<StockBookQuote>> StockBookQuoteCreated
        {
            add		{ lock (eventLock) { stockBookQuoteContainerCache.Created += value; } }
            remove	{ lock (eventLock) { stockBookQuoteContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<StockBookQuote>> StockBookQuoteChanged
        {
            add		{ lock (eventLock) { stockBookQuoteContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { stockBookQuoteContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<StockBookQuote>> StockBookQuoteUpdated
        {
            add		{ lock (eventLock) { stockBookQuoteContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { stockBookQuoteContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<StockCloseMark>> StockCloseMarkCreated
        {
            add		{ lock (eventLock) { stockCloseMarkContainerCache.Created += value; } }
            remove	{ lock (eventLock) { stockCloseMarkContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<StockCloseMark>> StockCloseMarkChanged
        {
            add		{ lock (eventLock) { stockCloseMarkContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { stockCloseMarkContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<StockCloseMark>> StockCloseMarkUpdated
        {
            add		{ lock (eventLock) { stockCloseMarkContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { stockCloseMarkContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<StockCloseQuote>> StockCloseQuoteCreated
        {
            add		{ lock (eventLock) { stockCloseQuoteContainerCache.Created += value; } }
            remove	{ lock (eventLock) { stockCloseQuoteContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<StockCloseQuote>> StockCloseQuoteChanged
        {
            add		{ lock (eventLock) { stockCloseQuoteContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { stockCloseQuoteContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<StockCloseQuote>> StockCloseQuoteUpdated
        {
            add		{ lock (eventLock) { stockCloseQuoteContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { stockCloseQuoteContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<StockOpenMark>> StockOpenMarkCreated
        {
            add		{ lock (eventLock) { stockOpenMarkContainerCache.Created += value; } }
            remove	{ lock (eventLock) { stockOpenMarkContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<StockOpenMark>> StockOpenMarkChanged
        {
            add		{ lock (eventLock) { stockOpenMarkContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { stockOpenMarkContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<StockOpenMark>> StockOpenMarkUpdated
        {
            add		{ lock (eventLock) { stockOpenMarkContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { stockOpenMarkContainerCache.Updated -= value; } }
        }
 		
		public event EventHandler<CreatedEventArgs<StockPrint>> StockPrintCreated
        {
            add		{ lock (eventLock) { stockPrintContainerCache.Created += value; } }
            remove	{ lock (eventLock) { stockPrintContainerCache.Created -= value; } }
        }
		
		public event EventHandler<ChangedEventArgs<StockPrint>> StockPrintChanged
        {
            add		{ lock (eventLock) { stockPrintContainerCache.Changed += value; } }
            remove	{ lock (eventLock) { stockPrintContainerCache.Changed -= value; } }
        }
		
		public event EventHandler<UpdatedEventArgs<StockPrint>> StockPrintUpdated
        {
            add		{ lock (eventLock) { stockPrintContainerCache.Updated += value; } }
            remove	{ lock (eventLock) { stockPrintContainerCache.Updated -= value; } }
        }

		
		#endregion
	}
}
