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
		const UShort MAX_MESSAGE_TYPE = 1000;

		enum class MessageType : UShort
		{
			None = 0,
			
			CCodeDefinition = 110,
			FutureBookQuote = 111,
			FuturePrint = 115,
			FutureSettlementMark = 375,
			IndexQuote = 137,
			LiveSurfaceAtm = 356,
			OptionCloseMark = 373,
			OptionCloseQuote = 104,
			OptionImpliedQuote = 377,
			OptionNbboQuote = 102,
			OptionOpenMark = 105,
			OptionPrint = 106,
			OptionRiskFactor = 379,
			OptionSettlementMark = 374,
			RootDefinition = 100,
			StockBookQuote = 121,
			StockCloseMark = 125,
			StockCloseQuote = 123,
			StockOpenMark = 124,
			StockPrint = 122,
			
			CacheComplete = 504,
			GetCache = 503,
		};
		
		inline bool IsValid(MessageType message_type)
		{
			return static_cast<UShort>(message_type) < MAX_MESSAGE_TYPE;
		}
	}
}
