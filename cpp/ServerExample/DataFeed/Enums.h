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
