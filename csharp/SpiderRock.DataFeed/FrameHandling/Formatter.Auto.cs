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
		public byte* Decode(byte* src, FuturePrintMarkup dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(FuturePrintMarkup.PKeyLayout) + sizeof(FuturePrintMarkup.BodyLayout) > max) throw new IOException("Max exceeded decoding FuturePrintMarkup");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((FuturePrintMarkup.PKeyLayout*) src); src += sizeof(FuturePrintMarkup.PKeyLayout);
 				dest.body = *((FuturePrintMarkup.BodyLayout*) src); src += sizeof(FuturePrintMarkup.BodyLayout);
			
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
		public byte* Decode(byte* src, OptionExchOrder dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionExchOrder.PKeyLayout) + sizeof(OptionExchOrder.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionExchOrder");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionExchOrder.PKeyLayout*) src); src += sizeof(OptionExchOrder.PKeyLayout);
 				dest.body = *((OptionExchOrder.BodyLayout*) src); src += sizeof(OptionExchOrder.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, OptionExchPrint dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionExchPrint.PKeyLayout) + sizeof(OptionExchPrint.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionExchPrint");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionExchPrint.PKeyLayout*) src); src += sizeof(OptionExchPrint.PKeyLayout);
 				dest.body = *((OptionExchPrint.BodyLayout*) src); src += sizeof(OptionExchPrint.BodyLayout);
			
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
		public byte* Decode(byte* src, OptionOpenInterestV2 dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionOpenInterestV2.PKeyLayout) + sizeof(OptionOpenInterestV2.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionOpenInterestV2");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionOpenInterestV2.PKeyLayout*) src); src += sizeof(OptionOpenInterestV2.PKeyLayout);
 				dest.body = *((OptionOpenInterestV2.BodyLayout*) src); src += sizeof(OptionOpenInterestV2.BodyLayout);
			
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
		public byte* Decode(byte* src, OptionPrintMarkup dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(OptionPrintMarkup.PKeyLayout) + sizeof(OptionPrintMarkup.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionPrintMarkup");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((OptionPrintMarkup.PKeyLayout*) src); src += sizeof(OptionPrintMarkup.PKeyLayout);
 				dest.body = *((OptionPrintMarkup.BodyLayout*) src); src += sizeof(OptionPrintMarkup.BodyLayout);
			
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
		public byte* Decode(byte* src, ProductDefinitionV2 dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(ProductDefinitionV2.PKeyLayout) + sizeof(ProductDefinitionV2.BodyLayout) > max) throw new IOException("Max exceeded decoding ProductDefinitionV2");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((ProductDefinitionV2.PKeyLayout*) src); src += sizeof(ProductDefinitionV2.PKeyLayout);
 				dest.body = *((ProductDefinitionV2.BodyLayout*) src); src += sizeof(ProductDefinitionV2.BodyLayout);
 
				// LegsItem Repeat Section

				if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding ProductDefinitionV2.Legs length");
				ushort size = *((ushort*) src); src += sizeof(ushort);
				if (src + size * ProductDefinitionV2.LegsItem.Length > max) throw new IOException("Max exceeded decoding ProductDefinitionV2.Legs items");

				dest.LegsList = new ProductDefinitionV2.LegsItem[size];
				
				for (int i = 0; i < size; i++)
				{
					var item = new ProductDefinitionV2.LegsItem();
					item.LegID = *((FixedString24Layout*) src); src += sizeof(FixedString24Layout);
 					item.SecKey = OptionKey.GetCreateOptionKey(*((OptionKeyLayout*) src)); src += sizeof(OptionKeyLayout);
 					item.SecType = *((SpdrKeyType*) src); src++;
 					item.Side = *((BuySell*) src); src++;
 					item.Ratio = *((ushort*) src); src += sizeof(ushort);
 					item.RefDelta = *((float*) src); src += sizeof(float);
 					item.RefPrc = *((double*) src); src += sizeof(double);

					dest.LegsList[i] = item;
				}
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, RootDefinition dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(RootDefinition.PKeyLayout) + sizeof(RootDefinition.BodyLayout) > max) throw new IOException("Max exceeded decoding RootDefinition");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((RootDefinition.PKeyLayout*) src); src += sizeof(RootDefinition.PKeyLayout);
 				dest.body = *((RootDefinition.BodyLayout*) src); src += sizeof(RootDefinition.BodyLayout);
 
				// UnderlyingItem Repeat Section

				if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding RootDefinition.Underlying length");
				ushort size = *((ushort*) src); src += sizeof(ushort);
				if (src + size * RootDefinition.UnderlyingItem.Length > max) throw new IOException("Max exceeded decoding RootDefinition.Underlying items");

				dest.UnderlyingList = new RootDefinition.UnderlyingItem[size];
				
				for (int i = 0; i < size; i++)
				{
					var item = new RootDefinition.UnderlyingItem();
					item.Ticker = TickerKey.GetCreateTickerKey(*((TickerKeyLayout*) src)); src += sizeof(TickerKeyLayout);
 					item.Spc = *((float*) src); src += sizeof(float);

					dest.UnderlyingList[i] = item;
				}
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, SpdrAuctionState dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(SpdrAuctionState.PKeyLayout) + sizeof(SpdrAuctionState.BodyLayout) > max) throw new IOException("Max exceeded decoding SpdrAuctionState");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((SpdrAuctionState.PKeyLayout*) src); src += sizeof(SpdrAuctionState.PKeyLayout);
 				dest.body = *((SpdrAuctionState.BodyLayout*) src); src += sizeof(SpdrAuctionState.BodyLayout);
 
				// LegsItem Repeat Section

				if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding SpdrAuctionState.Legs length");
				ushort size = *((ushort*) src); src += sizeof(ushort);
				if (src + size * SpdrAuctionState.LegsItem.Length > max) throw new IOException("Max exceeded decoding SpdrAuctionState.Legs items");

				dest.LegsList = new SpdrAuctionState.LegsItem[size];
				
				for (int i = 0; i < size; i++)
				{
					var item = new SpdrAuctionState.LegsItem();
					item.LegSecKey = OptionKey.GetCreateOptionKey(*((OptionKeyLayout*) src)); src += sizeof(OptionKeyLayout);
 					item.LegSecType = *((SpdrKeyType*) src); src++;
 					item.LegSide = *((BuySell*) src); src++;
 					item.LegRatio = *((ushort*) src); src += sizeof(ushort);

					dest.LegsList[i] = item;
				}
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, SpreadBookQuote dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(SpreadBookQuote.PKeyLayout) + sizeof(SpreadBookQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding SpreadBookQuote");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((SpreadBookQuote.PKeyLayout*) src); src += sizeof(SpreadBookQuote.PKeyLayout);
 				dest.body = *((SpreadBookQuote.BodyLayout*) src); src += sizeof(SpreadBookQuote.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, SpreadExchOrder dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(SpreadExchOrder.PKeyLayout) + sizeof(SpreadExchOrder.BodyLayout) > max) throw new IOException("Max exceeded decoding SpreadExchOrder");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((SpreadExchOrder.PKeyLayout*) src); src += sizeof(SpreadExchOrder.PKeyLayout);
 				dest.body = *((SpreadExchOrder.BodyLayout*) src); src += sizeof(SpreadExchOrder.BodyLayout);
 
				// LegsItem Repeat Section

				if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding SpreadExchOrder.Legs length");
				ushort size = *((ushort*) src); src += sizeof(ushort);
				if (src + size * SpreadExchOrder.LegsItem.Length > max) throw new IOException("Max exceeded decoding SpreadExchOrder.Legs items");

				dest.LegsList = new SpreadExchOrder.LegsItem[size];
				
				for (int i = 0; i < size; i++)
				{
					var item = new SpreadExchOrder.LegsItem();
					item.LegSecKey = OptionKey.GetCreateOptionKey(*((OptionKeyLayout*) src)); src += sizeof(OptionKeyLayout);
 					item.LegSecType = *((SpdrKeyType*) src); src++;
 					item.LegSide = *((BuySell*) src); src++;
 					item.LegRatio = *((uint*) src); src += sizeof(uint);
 					item.PositionType = *((PositionType*) src); src++;

					dest.LegsList[i] = item;
				}
			
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
		public byte* Decode(byte* src, StockExchImbalanceV2 dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(StockExchImbalanceV2.PKeyLayout) + sizeof(StockExchImbalanceV2.BodyLayout) > max) throw new IOException("Max exceeded decoding StockExchImbalanceV2");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((StockExchImbalanceV2.PKeyLayout*) src); src += sizeof(StockExchImbalanceV2.PKeyLayout);
 				dest.body = *((StockExchImbalanceV2.BodyLayout*) src); src += sizeof(StockExchImbalanceV2.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, StockImbalance dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(StockImbalance.PKeyLayout) + sizeof(StockImbalance.BodyLayout) > max) throw new IOException("Max exceeded decoding StockImbalance");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((StockImbalance.PKeyLayout*) src); src += sizeof(StockImbalance.PKeyLayout);
 				dest.body = *((StockImbalance.BodyLayout*) src); src += sizeof(StockImbalance.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, StockMarketSummary dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(StockMarketSummary.PKeyLayout) + sizeof(StockMarketSummary.BodyLayout) > max) throw new IOException("Max exceeded decoding StockMarketSummary");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((StockMarketSummary.PKeyLayout*) src); src += sizeof(StockMarketSummary.PKeyLayout);
 				dest.body = *((StockMarketSummary.BodyLayout*) src); src += sizeof(StockMarketSummary.BodyLayout);
			
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
		public byte* Decode(byte* src, StockPrintMarkup dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(StockPrintMarkup.PKeyLayout) + sizeof(StockPrintMarkup.BodyLayout) > max) throw new IOException("Max exceeded decoding StockPrintMarkup");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((StockPrintMarkup.PKeyLayout*) src); src += sizeof(StockPrintMarkup.PKeyLayout);
 				dest.body = *((StockPrintMarkup.BodyLayout*) src); src += sizeof(StockPrintMarkup.BodyLayout);
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, TickerDefinition dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(TickerDefinition.PKeyLayout) + sizeof(TickerDefinition.BodyLayout) > max) throw new IOException("Max exceeded decoding TickerDefinition");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.pkey.body = *((TickerDefinition.PKeyLayout*) src); src += sizeof(TickerDefinition.PKeyLayout);
 				dest.body = *((TickerDefinition.BodyLayout*) src); src += sizeof(TickerDefinition.BodyLayout);
			
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
		public byte* Encode(GetExtCache src, byte* dest, byte* max)
		{
			unchecked
			{
				int length = sizeof(Header) + sizeof(GetExtCache.BodyLayout) + (sizeof(ushort) + (src.MsgTypeList == null ? 0 : src.MsgTypeList.Length * GetExtCache.MsgTypeItem.Length));
				if (length > (int) (max - dest)) throw new IOException("Cannot encode GetExtCache because it will exceed the buffer length");
				
				src.header.msgtype = MessageType.GetExtCache;
				src.header.msglen = (ushort) length;
				src.header.keylen = 0;
				src.header.sentts = System.DateTime.UtcNow.Ticks;
				
				*((Header*) dest) =	src.header; dest += sizeof(Header);
				
				*((GetExtCache.BodyLayout*) dest) = src.body; dest += sizeof(GetExtCache.BodyLayout);
 
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
		public byte* Decode(byte* src, GetExtCache dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(GetExtCache.BodyLayout) > max) throw new IOException("Max exceeded decoding GetExtCache");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.body = *((GetExtCache.BodyLayout*) src); src += sizeof(GetExtCache.BodyLayout);
 
				// MsgTypeItem Repeat Section

				if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding GetExtCache.MsgType length");
				ushort size = *((ushort*) src); src += sizeof(ushort);
				if (src + size * GetExtCache.MsgTypeItem.Length > max) throw new IOException("Max exceeded decoding GetExtCache.MsgType items");

				dest.MsgTypeList = new GetExtCache.MsgTypeItem[size];
				
				for (int i = 0; i < size; i++)
				{
					var item = new GetExtCache.MsgTypeItem();
					item.Msgtype = *((ushort*) src); src += sizeof(ushort);

					dest.MsgTypeList[i] = item;
				}
			
				return src;
			}
		}
 		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Encode(NetPulse src, byte* dest, byte* max)
		{
			unchecked
			{
				int length = sizeof(Header) + sizeof(NetPulse.BodyLayout);
				if (length > (int) (max - dest)) throw new IOException("Cannot encode NetPulse because it will exceed the buffer length");
				
				src.header.msgtype = MessageType.NetPulse;
				src.header.msglen = (ushort) length;
				src.header.keylen = 0;
				src.header.sentts = System.DateTime.UtcNow.Ticks;
				
				*((Header*) dest) =	src.header; dest += sizeof(Header);
				
				*((NetPulse.BodyLayout*) dest) = src.body; dest += sizeof(NetPulse.BodyLayout);
			
				return dest;
			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte* Decode(byte* src, NetPulse dest, byte* max)
		{
			unchecked
			{
				if (src + sizeof(Header) + sizeof(NetPulse.BodyLayout) > max) throw new IOException("Max exceeded decoding NetPulse");
				
				dest.header = *((Header*) src); src += sizeof(Header);
				dest.body = *((NetPulse.BodyLayout*) src); src += sizeof(NetPulse.BodyLayout);
			
				return src;
			}
		}

	}
} // namespace
