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

		enum class AdjConvention : Enum 
		{
			Original=0,
			OSI=1,
			SpcOnly=2,
			OSIAlt=3
		};

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

 		enum class AuctionStatus : Enum 
		{
			None=0,
			WillRunOpenAndClose=1,
			WillRunInterest=2,
			WillNotRunImbalance=3,
			WillNotRunClsAuction=4
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

 		enum class ContractUnit : Enum 
		{
			None=0,
			AUD=1,
			BBL=2,
			BDFT=3,
			BRL=4,
			BU=5,
			CAD=6,
			CHF=7,
			CTRCT=8,
			CWT=9,
			CZK=10,
			EUR=11,
			GAL=12,
			GBP=13,
			HUF=14,
			ILS=15,
			IPNT=16,
			JPY=17,
			KRW=18,
			LBS=19,
			MMBTU=20,
			MWH=21,
			MXN=22,
			MYR=22,
			NOK=23,
			NZD=24,
			PLN=25,
			RMB=26,
			RUR=27,
			SEK=28,
			TON=29,
			TRY=31,
			TRYOZ=32,
			USD=33,
			ZAR=34
		};

 		enum class Currency : Enum 
		{
			None=0,
			AUD=1,
			BRL=2,
			CAD=3,
			CHF=4,
			CNH=5,
			CNY=6,
			EUR=7,
			GBP=8,
			JPY=9,
			KRW=10,
			MXN=11,
			MYR=12,
			NOK=13,
			NZD=14,
			SEK=15,
			TRY=16,
			USD=17,
			USDCents=18,
			CZK=19,
			ZAR=20,
			HUF=21,
			USX=22
		};

 		enum class ExerciseTime : Enum 
		{
			None=0,
			PM=1,
			AM=2
		};

 		enum class ExerciseType : Enum 
		{
			None=0,
			American=1,
			European=2,
			Asian=3,
			Cliquet=4
		};

 		enum class ExpirationMap : Enum 
		{
			None=0,
			ExactMatch=1,
			UnderlierMap=2
		};

 		enum class FitPath : Enum 
		{
			None=0,
			VolUPrc=2,
			VolUPrcDefault=3,
			VolSDiv=4,
			VolSDivDefault=5,
			BaseDefault=6,
			BaseDefaultAdj=7,
			HistVol=8,
			Default=9,
			NormalMid=10,
			WideMid=11,
			WideGap=12,
			WideBound=13,
			AtmRange=14
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
			None=0,
			Unused=1,
			SRCubic=2,
			SRCubic2=3,
			BSpline=4,
			BSpline2=5
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
			Test3=10,
			LiveC=11,
			BaseC=12,
			PrevC=13,
			HistC=14,
			InterpC=15,
			Default=16,
			BaseEMA_1=17,
			BaseEMA_2=18,
			BaseEMA_3=19
		};

 		enum class MarketSession : Enum 
		{
			None=0,
			EarlySession=1,
			RegularSession=2,
			LateSession=3,
			NextDay=4
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

 		enum class Multihedge : Enum 
		{
			None=0,
			Simple=1,
			Complex=2,
			AllCash=3,
			Binary=4
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
			MPRL=20,
			SDRK=21,
			DQTE=22,
			MEMLD=23,
			CFE=24
		};

 		enum class OptPriceInc : Enum 
		{
			None=0,
			PartPenny=1,
			PartNickle=2,
			FullPenny=3
		};

 		enum class OptionType : Enum 
		{
			None=0,
			Equity=1,
			Index=2,
			Future=3,
			Binary=4,
			Warrant=5,
			Flex=6,
			MapError=99
		};

 		enum class PriceFormat : Enum 
		{
			None=0,
			N0=1,
			N1=2,
			N2=3,
			N3=4,
			N4=5,
			N5=6,
			N6=7,
			N7=8,
			F4=9,
			F8=10,
			Q8=11,
			F16=12,
			F32=13,
			H32=14,
			Q32=15,
			F64=16,
			H64=17,
			FullPenny=18,
			PartPenny=19,
			PartNickle=20,
			EQT=21,
			V1=22,
			V2=23,
			V3=24,
			V4=25,
			V5=26,
			V6=27,
			V7=28,
			V8=29,
			V9=30,
			V10=31,
			V11=32,
			V12=33,
			V13=34,
			V14=35,
			V15=36,
			A0=37,
			A1=38,
			A2=39,
			A3=40,
			A4=41,
			A5=42,
			A6=43,
			A7=44
		};

 		enum class PriceQuoteType : Enum 
		{
			Price=0,
			Vol=1
		};

 		enum class PricingModel : Enum 
		{
			None=0,
			Equity=1,
			FutureApprox=2,
			FutureExact=3,
			NormalApprox=4,
			NormalExact=5
		};

 		enum class PrimaryExch : Enum 
		{
			None=0,
			NYSE=1,
			AMEX=2,
			Nasdaq=3,
			NasdaqSmallCap=4,
			OtcBB=5,
			Index=6,
			ARCA=7,
			CME=8,
			CBOT=9,
			NYMEX=10,
			COMEX=11,
			ICE=12,
			BATS=13,
			IEXG=14
		};

 		enum class ProductClass : Enum 
		{
			None=0,
			Equity=1,
			Index=2,
			Future=3,
			Option=4,
			Spread=5
		};

 		enum class ProductIndexType : Enum 
		{
			None=0,
			NextDay=1,
			FirstOfMonth=2,
			VWA=3,
			Russel=4
		};

 		enum class ProductTerm : Enum 
		{
			None=0,
			Month=1,
			Day=2,
			Week=3,
			BalanceOfMonth=4,
			Quarter=5,
			Season=6,
			BalanceOfWeek=7,
			CalendarYear=8,
			Variable=9,
			Custom=10,
			SameDay=11,
			NextDay=12,
			Weekly=13,
			Pack=14,
			Bundle=15,
			IRSAndCDSTenor=16
		};

 		enum class ProductType : Enum 
		{
			None=0,
			Outright=1,
			CalSpr=2,
			EqCalSpr=3,
			FXCalSpr=4,
			RedTick=5,
			BFly=6,
			Condor=7,
			Strip=8,
			InterCmd=9,
			Pack=10,
			MnPack=11,
			PackBFly=12,
			DblBFly=13,
			PackSpr=14,
			Crck=15,
			Bndl=16,
			BndlSpr=17,
			EnrStrp=18,
			BalStrp=19,
			UnbalStrp=20,
			EnICStrp=21,
			IRICStrp=22,
			ITRICSpr=23,
			UserDef=24,
			Combo=25,
			TAS=26,
			TASCalSpr=27,
			TAA=28,
			TIC=29,
			BIC=30,
			TAP=31,
			Index=32
		};

 		enum class PrtSide : Enum 
		{
			None=0,
			Mid=1,
			Bid=2,
			Ask=3
		};

 		enum class SpdrKeyType : Enum 
		{
			None=0,
			Stock=1,
			Future=2,
			Option=3,
			MLeg=4
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

 		enum class StkPriceInc : Enum 
		{
			None=0,
			FullPenny=1,
			Nickle=2
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
			OptMktNotOpn=18,
			NoBaseSurface=19,
			UPrcOffCnt=20,
			SkewKnotCnt=21,
			Exception=22,
			AxisError=23,
			CAskFit1Err=24,
			CAskFit2Err=25,
			PAskFit1Err=26,
			PAskFit2Err=27,
			CBidFit1Err=28,
			CBidFit2Err=29,
			PBidFit1Err=30,
			PBidFit2Err=31,
			CobsMidFitErr=31,
			CobsSampleErr=32,
			NoPrcFit=33,
			NumStrikes=34,
			CMidFitErr=35,
			PMidFitErr=36,
			StrikeCount=37,
			VolKnotCnt=38,
			InterpError=39,
			NoAtmStrike=40
		};

 		enum class SymbolType : Enum 
		{
			None=0,
			Equity=1,
			ADR=2,
			ETF=3,
			CashIndex=4,
			MutualFund=5,
			ShortETF=6,
			Future=7,
			Bond=8
		};

 		enum class SysEnvironment : Enum 
		{
			None=0,
			V7_Stable=3,
			V7_Latest=4
		};

 		enum class TapeCode : Enum 
		{
			None=0,
			A=1,
			B=2,
			C=3
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
			NSDQ=23,
			MFQS=24,
			PHLX=25,
			MIAX=26
		};

 		enum class TimeMetric : Enum 
		{
			None=0,
			D252=1,
			D365=2,
			SPX=3,
			WK1=4,
			WK2=5,
			WK3=6,
			WK4=7
		};

 		enum class TkDefSource : Enum 
		{
			None=0,
			Vendor=1,
			OTC=2,
			SR=3,
			Exchange=4
		};

 		enum class TradeableStatus : Enum 
		{
			None=0,
			OK=1,
			SurfaceErr=2,
			LowCCnt=3,
			LowPCnt=4,
			FitPrcErr=5,
			BidAskMiss=6,
			LowCounter=7,
			DefaultSkew=8,
			SessionMiss=9,
			BaseErr=10
		};

 		enum class UnderlierMode : Enum 
		{
			None=0,
			Actual=1,
			FrontMonth=2,
			UPrcAdj=3
		};

 		enum class UpdateType : Enum 
		{
			None=0,
			PrcChange=1,
			SizeOnly=2,
			PrevPeriod=3
		};

 		enum class VolumeTier : Enum 
		{
			None=0,
			Top50=1
		};

 		enum class YesNo : Enum 
		{
			None=0,
			Yes=1,
			No=2
		};

			
	}
}
