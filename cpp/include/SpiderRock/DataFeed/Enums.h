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
			SYN=7,
			WAR=8,
			FLX=9,
			MUT=10,
			SPD=11,
			MM=12,
			MF=13,
			COIN=14,
			TOKEN=15
		};

 		enum class AuctionReason : Enum 
		{
			None=0,
			Open=1,
			Market=2,
			Halt=3,
			Closing=4,
			RegulatoryImbalance=5
		};

 		enum class CalcSource : Enum 
		{
			None=0,
			Tick=1,
			Loop=2,
			Close=3
		};

 		enum class CalcType : Enum 
		{
			Loop=0,
			Tick=1
		};

 		enum class CallPut : Enum 
		{
			Call=0,
			Put=1,
			Pair=2
		};

 		enum class FutExch : Enum 
		{
			None=0,
			CFE=1,
			CME=2,
			CBOT=3,
			COMEX=4,
			NYMEX=5,
			ICE=6
		};

 		enum class GridType : Enum 
		{
			Uniform=0,
			SRCubic=1,
			SRFixed=2,
			BSpline=3
		};

 		enum class IdxSrc : Enum 
		{
			Unknown=0,
			Indication=1,
			Quote=2
		};

 		enum class ImbalanceSide : Enum 
		{
			None=0,
			Buy=1,
			Sell=2,
			NoImbalance=3,
			InsufOrdsToCalc=4
		};

 		enum class LiveSurfaceType : Enum 
		{
			None=0,
			Live=1,
			Hist=2,
			PriorDay=3,
			Skew=4,
			LiveSkew=5,
			LiveAdj=6,
			Interp=7,
			Test1=8,
			Test2=9,
			Test3=10
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

 		enum class MoneynessType : Enum 
		{
			PctStd=0,
			LogStd=1,
			NormStd=2
		};

 		enum class OpraMktType : Flag 
		{
			None=0,
			Rotation=1,
			TradingHalted=2,
			CustInterest=4,
			QuoteNotFirm=8
		};		
		inline OpraMktType operator|(OpraMktType a, OpraMktType b)
		{
			return static_cast<OpraMktType>(static_cast<int>(a) | static_cast<int>(b));
		}
			
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
			EDGO=18,
			MCRY=19,
			MPRL=20
		};

 		enum class PrtSide : Enum 
		{
			None=0,
			Mid=1,
			Bid=1,
			Ask=2
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
			CBIDX=16,
			IEX=17,
			OTC=18
		};

 		enum class StkPrintType : Enum 
		{
			None=0,
			RegularSequence=1,
			OutOfSequence=2,
			VolumeOnly=3,
			ExtendedHours=4
		};

 		enum class SurfaceResult : Enum 
		{
			None=0,
			OK=1,
			EOD=2,
			Init=3,
			Cache=4,
			PrevDay=5,
			NullExpIdx=6,
			NoStrikes=7,
			NoBaseCurve=8,
			BadBootAtm=9,
			NoGoodStrikes=10,
			BadAtmVol=11,
			Bootstrap=12,
			NoUPrc=13,
			NoIVols=14,
			NoModelPts=15,
			ZeroYears=16,
			NoSimpleVol=17,
			OptMktNotOpn=18
		};

 		enum class SysEnvironment : Enum 
		{
			None=0,
			V7_Stable=3
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
			TD=7,
			NYMEX=8,
			COMEX=9,
			RUT=10,
			CBOE=11,
			ISE=12,
			ARCA=13,
			NYSE=14,
			OTC=15,
			GDAX=16,
			BSTAMP=17,
			KRAKEN=18,
			TST=19,
			USR1=20,
			USR2=21,
			USR3=22,
			NSDQ=23
		};

 		enum class UnderlierMode : Enum 
		{
			None=0,
			Actual=1,
			FrontMonth=2
		};

 		enum class UpdateType : Enum 
		{
			None=0,
			PrcChange=1,
			SizeOnly=2
		};

			
	}
}
