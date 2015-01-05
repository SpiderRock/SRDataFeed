// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#pragma once

#include "stdafx.h"

#include "MbusFields.h"

namespace SpiderRock
{ 
	namespace DataFeed
	{
		namespace Mbus
		{
			const UShort MAX_MESSAGE_TYPE = 1000;

			enum class MessageType : UShort
			{
				None = 0,
				
				FutureBookQuote = 111,
				FuturePrint = 115,
				FutureSettlementMark = 375,
				LiveSurfaceAtm = 356,
				OptionCloseMark = 373,
				OptionCloseQuote = 104,
				OptionImpliedQuote = 377,
				OptionNbboQuote = 102,
				OptionOpenMark = 105,
				OptionPrint = 106,
				OptionSettlementMark = 374,
				SpreadQuote = 131,
				StockBookQuote = 121,
				StockCloseMark = 125,
				StockCloseQuote = 123,
				StockOpenMark = 124,
				StockPrint = 122,
				
				CacheComplete = 504,
				GetCache = 503,
				
				Max = MAX_MESSAGE_TYPE
			};
			
			inline bool IsValid(MessageType message_type)
			{
				return message_type < MessageType::Max;
			}

			enum class UdpChannel : Enum
			{
				StkNbboQuote1 = 1,
				StkNbboQuote2 = 2,
				StkNbboQuote3 = 3,
				StkNbboQuote4 = 4,

				OptNbboQuote1 = 11,
				OptNbboQuote2 = 12,
				OptNbboQuote3 = 13,
				OptNbboQuote4 = 14,

				FutQuoteCme = 21,
				FutQuoteCbot = 22,
				FutQuoteNymex = 23,
				FutQuoteComex = 24,

				CMEAdmin = 25,

				OptQuoteCme = 31,
				OptQuoteCbot = 32,
				OptQuoteNymex = 33,
				OptQuoteComex = 34,

				FutQuoteCfe = 41,

				IdxQuoteRut = 51,
				IdxQuoteCboe = 52,

				ImpliedQuoteNms = 61,
				ImpliedQuoteCme = 62,
				ImpliedQuoteCbot = 63,
				ImpliedQuoteNymex = 64,
				ImpliedQuoteComex = 65,

				StkExchQuote1Nsdq = 101,
				StkExchQuote2Nsdq = 102,
				StkExchQuote3Nsdq = 103,
				StkExchQuote4Nsdq = 104,

				StkExchQuote1Bats = 111,
				StkExchQuote2Bats = 112,
				StkExchQuote3Bats = 113,
				StkExchQuote4Bats = 114,

				StkExchQuote1Btsy = 121,
				StkExchQuote2Btsy = 122,
				StkExchQuote3Btsy = 123,
				StkExchQuote4Btsy = 124,

				StkExchQuote1Edgx = 131,
				StkExchQuote2Edgx = 132,
				StkExchQuote3Edgx = 133,
				StkExchQuote4Edgx = 134,

				StkExchQuote1Edga = 141,
				StkExchQuote2Edga = 142,
				StkExchQuote3Edga = 143,
				StkExchQuote4Edga = 144
			};

			enum class BuySell : Enum 
			{
				None=0,
				Buy=1,
				Sell=2
			};

 			enum class CallOrPut : Enum 
			{
				Call=0,
				Put=1
			};

 			enum class FitType : Enum 
			{
				None=0,
				Ci=1,
				Ii=2,
				CiCs=3,
				IiCs=4,
				CiCm=5,
				IiCm=6,
				CiCsCm=7,
				IiCsCm=8
			};

 			enum class FutExch : Enum 
			{
				None=0,
				CFE=1,
				CME=2,
				CBT=3,
				COMEX=4,
				NYMEX=5,
				ICE=6
			};

 			enum class LiveSurfaceType : Enum 
			{
				None=0,
				Live=1,
				Hist=2,
				PriorDay=3
			};

 			enum class MarkSource : Enum 
			{
				None=0,
				NbboMid=1,
				SRVol=2,
				LoBound=3,
				HiBound=4,
				SRPricer=5
			};

 			enum class MarketStatus : Enum 
			{
				None=0,
				PreOpen=1,
				Open=2,
				AfterHours=3,
				Halted=4
			};

 			enum class OptExch : Enum 
			{
				None=0,
				AMEX=1,
				BOX=2,
				CBOE=3,
				ISE=4,
				NYSE=5,
				PHLX=6,
				NSDQ=7,
				BATS=8,
				C2=9,
				NQBX=10,
				MIAX=11,
				GMNI=12,
				CME=13,
				CBOT=14,
				NYMEX=15,
				COMEX=16
			};

 			enum class QuoteType : Enum 
			{
				New=0,
				Modify=1,
				Delete=2,
				Print=3,
				Internal=4
			};

 			enum class SettleTime : Enum 
			{
				None=0,
				PM=1,
				AM=2
			};

 			enum class SprdSource : Enum 
			{
				None=0,
				Internal=1,
				ISE=2,
				CBOE=3,
				PHLX=4
			};

 			enum class StkExch : Enum 
			{
				None=0,
				AMEX=1,
				NQBX=2,
				NSX=3,
				FNRA=4,
				ISE=5,
				EDGA=6,
				EDGX=7,
				CHX=8,
				NYSE=9,
				ARCA=10,
				NSDQ=11,
				CBSX=12,
				PSX=13,
				BTSY=14,
				BATS=15,
				CBIDX=16
			};

 			enum class StockTick : Enum 
			{
				None=0,
				Up=1,
				Down=2
			};

 			enum class YesNo : Enum 
			{
				None=0,
				Yes=1,
				No=2
			};

			
		}		
	}
}
