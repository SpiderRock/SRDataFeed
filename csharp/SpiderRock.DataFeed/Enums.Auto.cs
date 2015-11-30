// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

namespace SpiderRock.DataFeed
{
    // ReSharper disable InconsistentNaming

	public enum AdjConvention : byte { Original=0,OSI=1,SpcOnly=2,OSIAlt=3 };		
 	public enum CalcSource : byte { None=0,Tick=1,Loop=2,Close=3 };		
 	public enum CallOrPut : byte { Call=0,Put=1 };		
 	public enum ExerciseTime : byte { None=0,PM=1,AM=2 };		
 	public enum ExerciseType : byte { None=0,American=1,European=2 };		
 	public enum ExpirationMap : byte { None=0,ExactMatch=1,UnderlyerMap=2 };		
 	public enum FitType : byte { None=0,InitAtm=1,LoBound=2,HiBound=3,MidGap=4,MidGapW=5,MidGapN=6 };		
 	public enum FutExch : byte { None=0,CFE=1,CME=2,CBT=3,COMEX=4,NYMEX=5,ICE=6 };		
 	public enum IdxSrc : byte { Unknown=0,Indication=1,Quote=2 };		
 	public enum LiveSurfaceType : byte { None=0,Live=1,Hist=2,PriorDay=3 };		
 	public enum MarkSource : byte { None=0,NbboMid=1,SRVol=2,LoBound=3,HiBound=4,SRPricer=5,SRQuote=6 };		
 	public enum MarketStatus : byte { None=0,PreOpen=1,PreCross=2,Cross=3,Open=4,Closed=5,Halted=6,AfterHours=7 };		
 	public enum Multihedge : byte { None=0,Simple=1,Complex=2,AllCash=3,Binary=4 };		
 	public enum OptExch : byte { None=0,AMEX=1,BOX=2,CBOE=3,ISE=4,NYSE=5,PHLX=6,NSDQ=7,BATS=8,C2=9,NQBX=10,MIAX=11,GMNI=12,CME=13,CBOT=14,NYMEX=15,COMEX=16,ICE=17,EDGO=18 };		
 	public enum OptionType : byte { None=0,Equity=1,Index=2,Future=3,Binary=4,MapError=99 };		
 	public enum PricingGroup : byte { Default=0,Gelber=1,User=2 };		
 	public enum PricingModel : byte { None=0,Equity=1,FutureMarginAppr=2,FutureCashAppr=3,FutureMarginExact=4,FutureCashExact=5,Eurodollar=6 };		
 	public enum SettleTime : byte { None=0,PM=1,AM=2 };		
 	public enum StkExch : byte { None=0,AMEX=1,NQBX=2,NSX=3,FNRA=4,ISE=5,EDGA=6,EDGX=7,CHX=8,NYSE=9,ARCA=10,NSDQ=11,CBSX=12,PSX=13,BTSY=14,BATS=15,CBIDX=16 };		
 	public enum StockTick : byte { None=0,Up=1,Down=2 };		
 	public enum TimeMetric : byte { None=0,D252=1,D365=2 };		
 	public enum VolumeTier : byte { None=0,Top50=1 };		
 	public enum YellowKey : byte { None=0,Govt=1,Corp=2,Mtge=3,MMkt=4,Muni=5,Pfd=6,Equity=7,Comdty=8,Index=9,Curncy=10 };		
 	public enum YesNo : byte { None=0,Yes=1,No=2 };		

}
