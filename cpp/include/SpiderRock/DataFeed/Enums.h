// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#pragma once

#include "stdafx.h"

namespace SpiderRock
{ 
	namespace DataFeed
	{
		typedef uint8_t Enum;
		typedef uint8_t Flag;

		enum class AssetType : Enum 
		{
			None=0,
			EQT=1,
			IDX=2,
			BND=3,
			CUR=4,
			COM=5,
			FUT=6,
			SYN=7
		};

 		enum class AuctionType : Enum 
		{
			None=0,
			Open=1,
			Market=2,
			Halt=3,
			Closing=4,
			RegulatoryImbalance=5
		};

 		enum class BuySell : Enum 
		{
			None=0,
			Buy=1,
			Sell=2
		};

 		enum class CalcSource : Enum 
		{
			None=0,
			Tick=1,
			Loop=2,
			Close=3
		};

 		enum class CallPut : Enum 
		{
			Call=0,
			Put=1
		};

 		enum class FitType : Enum 
		{
			None=0,
			InitAtm=1,
			LoBound=2,
			HiBound=3,
			MidGap=4,
			MidGapW=5,
			MidGapN=6
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

 		enum class IdxSrc : Enum 
		{
			Unknown=0,
			Indication=1,
			Quote=2
		};

 		enum class LiveSurfaceType : Enum 
		{
			None=0,
			Live=1,
			Hist=2,
			PriorDay=3,
			Skew=4,
			Interp=5,
			Test1=6,
			Test2=7,
			Test3=8
		};

 		enum class MarkSource : Enum 
		{
			None=0,
			NbboMid=1,
			SRVol=2,
			LoBound=3,
			HiBound=4,
			SRPricer=5,
			SRQuote=6
		};

 		enum class MarketStatus : Enum 
		{
			None=0,
			PreOpen=1,
			PreCross=2,
			Cross=3,
			Open=4,
			Closed=5,
			Halted=6,
			AfterHours=7
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
			COMEX=16,
			ICE=17,
			EDGO=18
		};

 		enum class PricingGroup : Enum 
		{
			Default=0,
			Gelber=1,
			User=2
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

 		enum class SurfaceResult : Enum 
		{
			None=0,
			OK=1,
			Init=2,
			Cache=3,
			PrevDay=4,
			NullExpIdx=5,
			NoStrikes=6,
			NoBaseCurve=7,
			BadBootAtm=8,
			NoGoodStrikes=9,
			BadAtmVol=10,
			Bootstrap=11,
			NoUPrc=12,
			NoIVols=13,
			NoModelPts=14
		};

 		enum class SysEnvironment : Enum 
		{
			None=0,
			Stable=1,
			Beta=2
		};

 		enum class TickerSrc : Enum 
		{
			None=0,
			SR=1,
			NMS=2,
			CME=3,
			ICE=4,
			CFE=5,
			CBOT=6,
			COIN=7,
			NYMEX=8,
			COMEX=9,
			RUT=10,
			CBOE=11,
			KET=12,
			ISE=13,
			ARCA=14,
			NYSE=15
		};

 		enum class YesNo : Enum 
		{
			None=0,
			Yes=1,
			No=2
		};

			
	}
}
