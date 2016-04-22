// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

using System.IO;
using System.Runtime.CompilerServices;
using SpiderRock.DataFeed.Layouts;

namespace SpiderRock.DataFeed.FrameHandling
{
    unsafe internal partial class Formatter
    {
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, FutureBookQuote dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(FutureBookQuote.PKeyLayout) + sizeof(FutureBookQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding FutureBookQuote");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((FutureBookQuote.PKeyLayout*) src); src += sizeof(FutureBookQuote.PKeyLayout);
 				dest.body = *((FutureBookQuote.BodyLayout*) src); src += sizeof(FutureBookQuote.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, FuturePrint dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(FuturePrint.PKeyLayout) + sizeof(FuturePrint.BodyLayout) > max) throw new IOException("Max exceeded decoding FuturePrint");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((FuturePrint.PKeyLayout*) src); src += sizeof(FuturePrint.PKeyLayout);
 				dest.body = *((FuturePrint.BodyLayout*) src); src += sizeof(FuturePrint.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, FutureSettlementMark dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(FutureSettlementMark.PKeyLayout) + sizeof(FutureSettlementMark.BodyLayout) > max) throw new IOException("Max exceeded decoding FutureSettlementMark");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((FutureSettlementMark.PKeyLayout*) src); src += sizeof(FutureSettlementMark.PKeyLayout);
 				dest.body = *((FutureSettlementMark.BodyLayout*) src); src += sizeof(FutureSettlementMark.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, IndexQuote dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(IndexQuote.PKeyLayout) + sizeof(IndexQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding IndexQuote");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((IndexQuote.PKeyLayout*) src); src += sizeof(IndexQuote.PKeyLayout);
 				dest.body = *((IndexQuote.BodyLayout*) src); src += sizeof(IndexQuote.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, LiveSurfaceAtm dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(LiveSurfaceAtm.PKeyLayout) + sizeof(LiveSurfaceAtm.BodyLayout) > max) throw new IOException("Max exceeded decoding LiveSurfaceAtm");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((LiveSurfaceAtm.PKeyLayout*) src); src += sizeof(LiveSurfaceAtm.PKeyLayout);
 				dest.body = *((LiveSurfaceAtm.BodyLayout*) src); src += sizeof(LiveSurfaceAtm.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, OptionCloseMark dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionCloseMark.PKeyLayout) + sizeof(OptionCloseMark.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionCloseMark");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionCloseMark.PKeyLayout*) src); src += sizeof(OptionCloseMark.PKeyLayout);
 				dest.body = *((OptionCloseMark.BodyLayout*) src); src += sizeof(OptionCloseMark.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, OptionCloseQuote dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionCloseQuote.PKeyLayout) + sizeof(OptionCloseQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionCloseQuote");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionCloseQuote.PKeyLayout*) src); src += sizeof(OptionCloseQuote.PKeyLayout);
 				dest.body = *((OptionCloseQuote.BodyLayout*) src); src += sizeof(OptionCloseQuote.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, OptionImpliedQuote dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionImpliedQuote.PKeyLayout) + sizeof(OptionImpliedQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionImpliedQuote");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionImpliedQuote.PKeyLayout*) src); src += sizeof(OptionImpliedQuote.PKeyLayout);
 				dest.body = *((OptionImpliedQuote.BodyLayout*) src); src += sizeof(OptionImpliedQuote.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, OptionNbboQuote dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionNbboQuote.PKeyLayout) + sizeof(OptionNbboQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionNbboQuote");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionNbboQuote.PKeyLayout*) src); src += sizeof(OptionNbboQuote.PKeyLayout);
 				dest.body = *((OptionNbboQuote.BodyLayout*) src); src += sizeof(OptionNbboQuote.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, OptionOpenMark dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionOpenMark.PKeyLayout) + sizeof(OptionOpenMark.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionOpenMark");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionOpenMark.PKeyLayout*) src); src += sizeof(OptionOpenMark.PKeyLayout);
 				dest.body = *((OptionOpenMark.BodyLayout*) src); src += sizeof(OptionOpenMark.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, OptionPrint dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionPrint.PKeyLayout) + sizeof(OptionPrint.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionPrint");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionPrint.PKeyLayout*) src); src += sizeof(OptionPrint.PKeyLayout);
 				dest.body = *((OptionPrint.BodyLayout*) src); src += sizeof(OptionPrint.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, OptionPrint2 dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionPrint2.PKeyLayout) + sizeof(OptionPrint2.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionPrint2");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionPrint2.PKeyLayout*) src); src += sizeof(OptionPrint2.PKeyLayout);
 				dest.body = *((OptionPrint2.BodyLayout*) src); src += sizeof(OptionPrint2.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, OptionRiskFactor dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionRiskFactor.PKeyLayout) + sizeof(OptionRiskFactor.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionRiskFactor");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionRiskFactor.PKeyLayout*) src); src += sizeof(OptionRiskFactor.PKeyLayout);
 				dest.body = *((OptionRiskFactor.BodyLayout*) src); src += sizeof(OptionRiskFactor.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, OptionSettlementMark dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionSettlementMark.PKeyLayout) + sizeof(OptionSettlementMark.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionSettlementMark");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionSettlementMark.PKeyLayout*) src); src += sizeof(OptionSettlementMark.PKeyLayout);
 				dest.body = *((OptionSettlementMark.BodyLayout*) src); src += sizeof(OptionSettlementMark.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, StockBookQuote dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(StockBookQuote.PKeyLayout) + sizeof(StockBookQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding StockBookQuote");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((StockBookQuote.PKeyLayout*) src); src += sizeof(StockBookQuote.PKeyLayout);
 				dest.body = *((StockBookQuote.BodyLayout*) src); src += sizeof(StockBookQuote.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, StockCloseMark dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(StockCloseMark.PKeyLayout) + sizeof(StockCloseMark.BodyLayout) > max) throw new IOException("Max exceeded decoding StockCloseMark");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((StockCloseMark.PKeyLayout*) src); src += sizeof(StockCloseMark.PKeyLayout);
 				dest.body = *((StockCloseMark.BodyLayout*) src); src += sizeof(StockCloseMark.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, StockCloseQuote dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(StockCloseQuote.PKeyLayout) + sizeof(StockCloseQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding StockCloseQuote");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((StockCloseQuote.PKeyLayout*) src); src += sizeof(StockCloseQuote.PKeyLayout);
 				dest.body = *((StockCloseQuote.BodyLayout*) src); src += sizeof(StockCloseQuote.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, StockExchImbalance dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(StockExchImbalance.PKeyLayout) + sizeof(StockExchImbalance.BodyLayout) > max) throw new IOException("Max exceeded decoding StockExchImbalance");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((StockExchImbalance.PKeyLayout*) src); src += sizeof(StockExchImbalance.PKeyLayout);
 				dest.body = *((StockExchImbalance.BodyLayout*) src); src += sizeof(StockExchImbalance.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, StockOpenMark dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(StockOpenMark.PKeyLayout) + sizeof(StockOpenMark.BodyLayout) > max) throw new IOException("Max exceeded decoding StockOpenMark");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((StockOpenMark.PKeyLayout*) src); src += sizeof(StockOpenMark.PKeyLayout);
 				dest.body = *((StockOpenMark.BodyLayout*) src); src += sizeof(StockOpenMark.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, StockPrint dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(StockPrint.PKeyLayout) + sizeof(StockPrint.BodyLayout) > max) throw new IOException("Max exceeded decoding StockPrint");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((StockPrint.PKeyLayout*) src); src += sizeof(StockPrint.PKeyLayout);
 				dest.body = *((StockPrint.BodyLayout*) src); src += sizeof(StockPrint.BodyLayout);
			
				return src;
			}
		}

		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Encode(CacheComplete src, byte* dest, byte* max)
		{
			unchecked
			{
				int length = sizeof(Header) + sizeof(CacheComplete.BodyLayout);
				if (length > (int) (max - dest)) throw new IOException("Cannot encode CacheComplete because it will exceed the buffer length");
				
				src.header.msgtype = MessageType.CacheComplete;
				src.header.msglen = (ushort) length;
				src.header.keylen = 0;
				src.header.sentts = System.DateTime.UtcNow.Ticks;
				
				*((Header*) dest) =	src.header; dest += sizeof(Header);
				
				*((CacheComplete.BodyLayout*) dest) = src.body; dest += sizeof(CacheComplete.BodyLayout);
			
				return dest;
			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, CacheComplete dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(CacheComplete.BodyLayout) > max) throw new IOException("Max exceeded decoding CacheComplete");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.body = *((CacheComplete.BodyLayout*) src); src += sizeof(CacheComplete.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Encode(GetCache src, byte* dest, byte* max)
		{
			unchecked
			{
				int length = sizeof(Header) + sizeof(GetCache.BodyLayout) + (sizeof(ushort) + (src.MsgTypeList == null ? 0 : src.MsgTypeList.Length * GetCache.MsgTypeItem.Length));
				if (length > (int) (max - dest)) throw new IOException("Cannot encode GetCache because it will exceed the buffer length");
				
				src.header.msgtype = MessageType.GetCache;
				src.header.msglen = (ushort) length;
				src.header.keylen = 0;
				src.header.sentts = System.DateTime.UtcNow.Ticks;
				
				*((Header*) dest) =	src.header; dest += sizeof(Header);
				
				*((GetCache.BodyLayout*) dest) = src.body; dest += sizeof(GetCache.BodyLayout);
 
				// MsgTypeItem Repeat Section

				if (src.MsgTypeList == null)
				{
					*((ushort*) dest) = 0;
				}
				else 
				{
					*((ushort*) dest) = (ushort) src.MsgTypeList.Length; dest += sizeof(ushort);
					
					for (int i = 0; i < src.MsgTypeList.Length; i++)
					{
						var item = src.MsgTypeList[i];
						*((ushort*) dest) = item.Msgtype; dest += sizeof(ushort);

					}
				}
			
				return dest;
			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, GetCache dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(GetCache.BodyLayout) > max) throw new IOException("Max exceeded decoding GetCache");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.body = *((GetCache.BodyLayout*) src); src += sizeof(GetCache.BodyLayout);
 
				// MsgTypeItem Repeat Section

				if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding GetCache.MsgType length");
				ushort size = *((ushort*) src); src += sizeof(ushort);
				if (src + size * GetCache.MsgTypeItem.Length > max) throw new IOException("Max exceeded decoding GetCache.MsgType items");

				dest.MsgTypeList = new GetCache.MsgTypeItem[size];
				
				for (int i = 0; i < size; i++)
				{
					var item = new GetCache.MsgTypeItem();
					item.Msgtype = *((ushort*) src); src += sizeof(ushort);

					dest.MsgTypeList[i] = item;
				}
			
				return src;
			}
		}

	}
} // namespace
