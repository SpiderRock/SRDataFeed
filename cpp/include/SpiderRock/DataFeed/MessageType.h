// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
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
			
			FutureBookQuote = 360,
			FuturePrint = 370,
			FuturePrintMarkup = 3024,
			IndexQuote = 137,
			LiveSurfaceAtm = 2160,
			OptionCloseMark = 292,
			OptionExchOrder = 270,
			OptionExchPrint = 275,
			OptionImpliedQuote = 2300,
			OptionNbboQuote = 260,
			OptionOpenInterestV2 = 2131,
			OptionPrint = 300,
			OptionPrint2 = 301,
			OptionPrintMarkup = 3026,
			OptionRiskFactor = 2320,
			ProductDefinitionV2 = 2455,
			RootDefinition = 240,
			SpreadBookQuote = 525,
			StockBookQuote = 430,
			StockExchImbalanceV2 = 491,
			StockImbalance = 495,
			StockMarketSummary = 445,
			StockPrint = 440,
			StockPrintMarkup = 3022,
			TickerDefinition = 420,
			
			GetExtCache = 4096,
			NetPulse = 5000,
		};
		
		inline bool IsValid(MessageType message_type)
		{
			return static_cast<UShort>(message_type) < MAX_MESSAGE_TYPE;
		}
	}
}
