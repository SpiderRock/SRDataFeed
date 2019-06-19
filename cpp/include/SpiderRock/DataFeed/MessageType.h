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
		const UShort MAX_MESSAGE_TYPE = 0x2000;

		enum class MessageType : UShort
		{
			None = 0,
			
			FutureBookQuote = 360,
			FuturePrint = 370,
			IndexQuote = 137,
			LiveSurfaceAtm = 2160,
			OptionImpliedQuote = 2300,
			OptionNbboQuote = 260,
			OptionPrint = 300,
			OptionRiskFactor = 2320,
			ProductDefinitionV2 = 2455,
			RootDefinition = 240,
			SpreadBookQuote = 525,
			StockBookQuote = 430,
			StockExchImbalanceV2 = 491,
			StockMarketSummary = 445,
			StockPrint = 440,
			TickerDefinition = 420,
			
			CacheComplete = 4106,
			GetCache = 4096,
			NetPulse = 5000,
		};
		
		inline bool IsValid(MessageType message_type)
		{
			return static_cast<UShort>(message_type) < MAX_MESSAGE_TYPE;
		}
	}
}
