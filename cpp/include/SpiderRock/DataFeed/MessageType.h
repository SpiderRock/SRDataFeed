// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2023, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#pragma once

#include "stdafx.h"

#include "Fields.h"

namespace SpiderRock
{ 
	namespace DataFeed
	{
		const UShort MAX_MESSAGE_TYPE = 11000;

		enum class MessageType : UShort
		{
			None = 0,
			
			FutureBookQuote = 2580,
			FuturePrint = 2595,
			FuturePrintMarkup = 2605,
			IndexQuote = 2675,
			LiveImpliedQuote = 1015,
			LiveSurfaceAtm = 1030,
			OptionCloseMark = 3140,
			OptionExchOrder = 2765,
			OptionExchPrint = 2770,
			OptionMarketSummary = 2780,
			OptionNbboQuote = 2785,
			OptionOpenInterest = 3230,
			OptionPrint = 2800,
			OptionPrint2 = 2805,
			OptionPrintMarkup = 2810,
			OptionRiskFactor = 1095,
			ProductDefinitionV2 = 4360,
			RootDefinition = 4365,
			SpdrAuctionState = 2525,
			SpreadBookQuote = 2900,
			SpreadExchOrder = 2915,
			SpreadExchPrint = 2920,
			StockBookQuote = 3000,
			StockExchImbalanceV2 = 3020,
			StockImbalance = 3035,
			StockMarketSummary = 3040,
			StockPrint = 3045,
			StockPrintMarkup = 3055,
			SyntheticExpiryQuote = 2700,
			SyntheticFutureQuote = 2695,
			TickerDefinitionExt = 4380,
			
			MLinkCacheRequest = 3355,
			MLinkStreamCheckPt = 3382,
			NetPulse = 5900,
		};
		
		inline bool IsValid(MessageType message_type)
		{
			return static_cast<UShort>(message_type) < MAX_MESSAGE_TYPE;
		}
	}
}
