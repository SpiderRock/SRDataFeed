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

	public enum AssetType : byte { None=0,EQT=1,IDX=2,BND=3,CUR=4,COM=5,FUT=6,SYN=7,WAR=8,FLX=9,MUT=10,SPD=11,MM=12,MF=13 };		
 	public enum AuctionReason : byte { None=0,Open=1,Market=2,Halt=3,Closing=4,RegulatoryImbalance=5 };		
 	public enum BuySell : byte { None=0,Buy=1,Sell=2 };		
 	public enum CalcSource : byte { None=0,Tick=1,Loop=2,Close=3 };		
 	public enum CallPut : byte { Call=0,Put=1,Pair=2 };		
 	public enum FitType : byte { None=0,InitAtm=1,LoBound=2,HiBound=3,MidGap=4,MidGapW=5,MidGapN=6 };		
 	public enum FutExch : byte { None=0,CFE=1,CME=2,CBT=3,COMEX=4,NYMEX=5,ICE=6 };		
 	public enum GridType : byte { Uniform=0,SRCubic=1,SRFixed=2 };		
 	public enum IdxSrc : byte { Unknown=0,Indication=1,Quote=2 };		
 	public enum LiveSurfaceType : byte { None=0,Live=1,Hist=2,PriorDay=3,Skew=4,Interp=5,Test1=6,Test2=7,Test3=8 };		
 	public enum MarketStatus : byte { None=0,PreOpen=1,PreCross=2,Cross=3,Open=4,Closed=5,Halted=6,AfterHours=7 };		
 	public enum MoneynessType : byte { PctStd=0,LogStd=1,NormStd=2 };		
 	[System.Flags] public enum OpraMktType : byte { None=0,Rotation=1,TradingHalted=2,CustInterest=4,QuoteNotFirm=8 };		
 	public enum OptExch : byte { None=0,AMEX=1,BOX=2,CBOE=3,ISE=4,NYSE=5,PHLX=6,NSDQ=7,BATS=8,C2=9,NQBX=10,MIAX=11,GMNI=12,CME=13,CBOT=14,NYMEX=15,COMEX=16,ICE=17,EDGO=18,MCRY=19,MPRL=20 };		
 	public enum PricingGroup : byte { Default=0,Gelber=1,User=2,Test=3,Implied=4,Override=5 };		
 	public enum PrtSide : byte { None=0,Mid=1,Bid=1,Ask=2 };		
 	public enum StkExch : byte { None=0,AMEX=1,NQBX=2,NSX=3,FNRA=4,ISE=5,EDGA=6,EDGX=7,CHX=8,NYSE=9,ARCA=10,NSDQ=11,CBSX=12,PSX=13,BTSY=14,BATS=15,CBIDX=16,IEX=17,OTC=18 };		
 	public enum StkPrintType : byte { None=0,RegularSequence=1,OutOfSequence=2,VolumeOnly=3,ExtendedHours=4 };		
 	public enum SurfaceResult : byte { None=0,OK=1,EOD=2,Init=3,Cache=4,PrevDay=5,NullExpIdx=6,NoStrikes=7,NoBaseCurve=8,BadBootAtm=9,NoGoodStrikes=10,BadAtmVol=11,Bootstrap=12,NoUPrc=13,NoIVols=14,NoModelPts=15 };		
 	public enum SysEnvironment : byte { None=0,Red=1,Blue=2 };		
 	public enum TickerSrc : byte { None=0,SR=1,NMS=2,CME=3,ICE=4,CFE=5,CBOT=6,TD=7,NYMEX=8,COMEX=9,RUT=10,CBOE=11,KET=12,ISE=13,ARCA=14,NYSE=15,OTC=16 };		
 	public enum UpdateType : byte { None=0,PrcChange=1,SizeOnly=2 };		

}
