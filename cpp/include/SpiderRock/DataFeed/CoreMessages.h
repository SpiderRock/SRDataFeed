// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#pragma once

#include <functional>
#include <vector>

using std::vector;

#include "stdafx.h"
#include "Fields.h"
#include "Enums.h"
#include "Header.h"

#pragma pack(1)

namespace SpiderRock { 

namespace DataFeed {

class FutureBookQuote
{
public:
	class Key
	{
		ExpiryKey fkey_;
		
	public:
		inline const ExpiryKey& fkey() const { return fkey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = ExpiryKey()(k.fkey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.fkey_ == b.fkey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		UpdateType updateType;
		MarketStatus marketStatus;
		Double bidPrice1;
		Double askPrice1;
		Int bidSize1;
		Int askSize1;
		UShort bidOrders1;
		UShort askOrders1;
		Double bidPrice2;
		Double askPrice2;
		Int bidSize2;
		Int askSize2;
		UShort bidOrders2;
		UShort askOrders2;
		Double bidPrice3;
		Double askPrice3;
		Int bidSize3;
		Int askSize3;
		UShort bidOrders3;
		UShort askOrders3;
		Double bidPrice4;
		Double askPrice4;
		Int bidSize4;
		Int askSize4;
		UShort bidOrders4;
		UShort askOrders4;
		Long srcTimestamp;
		Long netTimestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline UpdateType updateType() const { return layout_.updateType; }
	inline MarketStatus marketStatus() const { return layout_.marketStatus; }
	inline Double bidPrice1() const { return layout_.bidPrice1; }
	inline Double askPrice1() const { return layout_.askPrice1; }
	inline Int bidSize1() const { return layout_.bidSize1; }
	inline Int askSize1() const { return layout_.askSize1; }
	inline UShort bidOrders1() const { return layout_.bidOrders1; }
	inline UShort askOrders1() const { return layout_.askOrders1; }
	inline Double bidPrice2() const { return layout_.bidPrice2; }
	inline Double askPrice2() const { return layout_.askPrice2; }
	inline Int bidSize2() const { return layout_.bidSize2; }
	inline Int askSize2() const { return layout_.askSize2; }
	inline UShort bidOrders2() const { return layout_.bidOrders2; }
	inline UShort askOrders2() const { return layout_.askOrders2; }
	inline Double bidPrice3() const { return layout_.bidPrice3; }
	inline Double askPrice3() const { return layout_.askPrice3; }
	inline Int bidSize3() const { return layout_.bidSize3; }
	inline Int askSize3() const { return layout_.askSize3; }
	inline UShort bidOrders3() const { return layout_.bidOrders3; }
	inline UShort askOrders3() const { return layout_.askOrders3; }
	inline Double bidPrice4() const { return layout_.bidPrice4; }
	inline Double askPrice4() const { return layout_.askPrice4; }
	inline Int bidSize4() const { return layout_.bidSize4; }
	inline Int askSize4() const { return layout_.askSize4; }
	inline UShort bidOrders4() const { return layout_.bidOrders4; }
	inline UShort askOrders4() const { return layout_.askOrders4; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<FutureBookQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class FuturePrint
{
public:
	class Key
	{
		ExpiryKey fkey_;
		
	public:
		inline const ExpiryKey& fkey() const { return fkey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = ExpiryKey()(k.fkey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.fkey_ == b.fkey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		FutExch prtExch;
		Int prtSize;
		Double prtPrice;
		Int prtClusterNum;
		Int prtClusterSize;
		Byte prtType;
		UShort prtOrders;
		Int prtQuan;
		Int prtVolume;
		Float bid;
		Float ask;
		Int bsz;
		Int asz;
		Float age;
		PrtSide prtSide;
		Long prtTimestamp;
		Long netTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline FutExch prtExch() const { return layout_.prtExch; }
	inline Int prtSize() const { return layout_.prtSize; }
	inline Double prtPrice() const { return layout_.prtPrice; }
	inline Int prtClusterNum() const { return layout_.prtClusterNum; }
	inline Int prtClusterSize() const { return layout_.prtClusterSize; }
	inline Byte prtType() const { return layout_.prtType; }
	inline UShort prtOrders() const { return layout_.prtOrders; }
	inline Int prtQuan() const { return layout_.prtQuan; }
	inline Int prtVolume() const { return layout_.prtVolume; }
	inline Float bid() const { return layout_.bid; }
	inline Float ask() const { return layout_.ask; }
	inline Int bsz() const { return layout_.bsz; }
	inline Int asz() const { return layout_.asz; }
	inline Float age() const { return layout_.age; }
	inline PrtSide prtSide() const { return layout_.prtSide; }
	inline Long prtTimestamp() const { return layout_.prtTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<FuturePrint::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class FuturePrintMarkup
{
public:
	class Key
	{
		ExpiryKey fkey_;
		
	public:
		inline const ExpiryKey& fkey() const { return fkey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = ExpiryKey()(k.fkey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.fkey_ == b.fkey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		Long prtNumber;
		TickerKey ticker;
		FutExch prtExch;
		Int prtSize;
		Double prtPrice;
		Byte prtType;
		UShort prtOrders;
		Int prtClusterNum;
		Int prtClusterSize;
		Int prtVolume;
		PrtSide prtSide;
		Double bidPrice;
		Double askPrice;
		Int bidSize;
		Int askSize;
		Double bidPrice2;
		Double askPrice2;
		Int bidSize2;
		Int askSize2;
		Long srcTimestamp;
		Long netTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline Long prtNumber() const { return layout_.prtNumber; }
	inline const TickerKey& ticker() const { return layout_.ticker; }
	inline FutExch prtExch() const { return layout_.prtExch; }
	inline Int prtSize() const { return layout_.prtSize; }
	inline Double prtPrice() const { return layout_.prtPrice; }
	inline Byte prtType() const { return layout_.prtType; }
	inline UShort prtOrders() const { return layout_.prtOrders; }
	inline Int prtClusterNum() const { return layout_.prtClusterNum; }
	inline Int prtClusterSize() const { return layout_.prtClusterSize; }
	inline Int prtVolume() const { return layout_.prtVolume; }
	inline PrtSide prtSide() const { return layout_.prtSide; }
	inline Double bidPrice() const { return layout_.bidPrice; }
	inline Double askPrice() const { return layout_.askPrice; }
	inline Int bidSize() const { return layout_.bidSize; }
	inline Int askSize() const { return layout_.askSize; }
	inline Double bidPrice2() const { return layout_.bidPrice2; }
	inline Double askPrice2() const { return layout_.askPrice2; }
	inline Int bidSize2() const { return layout_.bidSize2; }
	inline Int askSize2() const { return layout_.askSize2; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<FuturePrintMarkup::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class IndexQuote
{
public:
	class Key
	{
		TickerKey ticker_;
		
	public:
		inline const TickerKey& ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.ticker_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		IdxSrc priceSource;
		Double idxBid;
		Double idxAsk;
		Double idxPrice;
		Long netTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline IdxSrc priceSource() const { return layout_.priceSource; }
	inline Double idxBid() const { return layout_.idxBid; }
	inline Double idxAsk() const { return layout_.idxAsk; }
	inline Double idxPrice() const { return layout_.idxPrice; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<IndexQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class LiveImpliedQuote
{
public:
	class Key
	{
		OptionKey okey_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		TickerKey ticker;
		Float uPrc;
		Float uOff;
		Float years;
		Float xAxis;
		Float rate;
		Float sdiv;
		Float ddiv;
		Float oBid;
		Float oAsk;
		Float oBidIv;
		Float oAskIv;
		Float atmVol;
		Float sVol;
		Float sPrc;
		Float sMark;
		Float veSlope;
		Float de;
		Float ga;
		Float th;
		Float ve;
		Float va;
		Float vo;
		Float ro;
		Float ph;
		Float deDecay;
		Float up50;
		Float dn50;
		Float up15;
		Float dn15;
		Float up06;
		Float dn08;
		ImpliedQuoteError calcErr;
		CalcSource calcSource;
		Long srcTimestamp;
		Long netTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const TickerKey& ticker() const { return layout_.ticker; }
	inline Float uPrc() const { return layout_.uPrc; }
	inline Float uOff() const { return layout_.uOff; }
	inline Float years() const { return layout_.years; }
	inline Float xAxis() const { return layout_.xAxis; }
	inline Float rate() const { return layout_.rate; }
	inline Float sdiv() const { return layout_.sdiv; }
	inline Float ddiv() const { return layout_.ddiv; }
	inline Float oBid() const { return layout_.oBid; }
	inline Float oAsk() const { return layout_.oAsk; }
	inline Float oBidIv() const { return layout_.oBidIv; }
	inline Float oAskIv() const { return layout_.oAskIv; }
	inline Float atmVol() const { return layout_.atmVol; }
	inline Float sVol() const { return layout_.sVol; }
	inline Float sPrc() const { return layout_.sPrc; }
	inline Float sMark() const { return layout_.sMark; }
	inline Float veSlope() const { return layout_.veSlope; }
	inline Float de() const { return layout_.de; }
	inline Float ga() const { return layout_.ga; }
	inline Float th() const { return layout_.th; }
	inline Float ve() const { return layout_.ve; }
	inline Float va() const { return layout_.va; }
	inline Float vo() const { return layout_.vo; }
	inline Float ro() const { return layout_.ro; }
	inline Float ph() const { return layout_.ph; }
	inline Float deDecay() const { return layout_.deDecay; }
	inline Float up50() const { return layout_.up50; }
	inline Float dn50() const { return layout_.dn50; }
	inline Float up15() const { return layout_.up15; }
	inline Float dn15() const { return layout_.dn15; }
	inline Float up06() const { return layout_.up06; }
	inline Float dn08() const { return layout_.dn08; }
	inline ImpliedQuoteError calcErr() const { return layout_.calcErr; }
	inline CalcSource calcSource() const { return layout_.calcSource; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<LiveImpliedQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class LiveSurfaceAtm
{
public:
	class Key
	{
		ExpiryKey ekey_;
		LiveSurfaceType surfaceType_;
		
	public:
		inline const ExpiryKey& ekey() const { return ekey_; }
		inline LiveSurfaceType surfaceType() const { return surfaceType_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = ExpiryKey()(k.ekey_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.surfaceType_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ekey_ == b.ekey_
				&& a.surfaceType_ == b.surfaceType_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		RunStatus runStatus;
		SRDataCenter dataCenter;
		SysEnvironment sysEnvironment;
		String<10> date;
		String<8> time;
		TickerKey ticker;
		ExpiryKey fkey;
		Float uBid;
		Float uAsk;
		Float years;
		Float rate;
		Float ddiv;
		Byte exType;
		Byte modelType;
		Float earnCnt;
		Float earnCntAdj;
		Float axisVolRT;
		Float axisFUPrc;
		MoneynessType moneynessType;
		UnderlierMode underlierMode;
		PriceQuoteType priceQuoteType;
		Float atmVol;
		Float atmCen;
		Float atmVolHist;
		Float atmCenHist;
		Float minAtmVol;
		Float maxAtmVol;
		Float minCPAdjVal;
		Float maxCPAdjVal;
		Float eMove;
		Float eMoveHist;
		Float uPrcOffset;
		Float uPrcOffsetEMA;
		Float sdiv;
		Float sdivEMA;
		Float atmMove;
		Float atmCenMove;
		Float atmPhi;
		Float atmVega;
		Float slope;
		Float varSwapFV;
		GridType gridType;
		Float minXAxis;
		Float maxXAxis;
		Float minCurvValue;
		Float minCurvXAxis;
		Float maxCurvValue;
		Float maxCurvXAxis;
		Float skewMinX;
		Float skewMinY;
		Float skewD11;
		Float skewD10;
		Float skewD9;
		Float skewD8;
		Float skewD7;
		Float skewD6;
		Float skewD5;
		Float skewD4;
		Float skewD3;
		Float skewD2;
		Float skewD1;
		Float skewC0;
		Float skewU1;
		Float skewU2;
		Float skewU3;
		Float skewU4;
		Float skewU5;
		Float skewU6;
		Float skewU7;
		Float skewU8;
		Float skewU9;
		Float skewU10;
		Float skewU11;
		Float sdivD3;
		Float sdivD2;
		Float sdivD1;
		Float sdivU1;
		Float sdivU2;
		Float sdivU3;
		Float pwidth;
		Float vwidth;
		Byte cCnt;
		Byte pCnt;
		Byte cBidMiss;
		Byte cAskMiss;
		Byte pBidMiss;
		Byte pAskMiss;
		FitPath fitPath;
		Float fitAvgErr;
		Float fitAvgAbsErr;
		Float fitMaxPrcErr;
		Float fitErrXX;
		CallPut fitErrCP;
		Float fitErrDe;
		Float fitErrBid;
		Float fitErrAsk;
		Float fitErrPrc;
		Float fitErrVol;
		Byte cBidMissT;
		Byte cAskMissT;
		Byte pBidMissT;
		Byte pAskMissT;
		Float fitAvgAbsErrT;
		ExpiryKey sEKey;
		LiveSurfaceType sType;
		DateTime sTimestamp;
		Int counter;
		Int skewCounter;
		Int sdivCounter;
		MarketSession marketSession;
		TradeableStatus tradeableStatus;
		SurfaceResult surfaceResult;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline RunStatus runStatus() const { return layout_.runStatus; }
	inline SRDataCenter dataCenter() const { return layout_.dataCenter; }
	inline SysEnvironment sysEnvironment() const { return layout_.sysEnvironment; }
	inline const String<10>& date() const { return layout_.date; }
	inline const String<8>& time() const { return layout_.time; }
	inline const TickerKey& ticker() const { return layout_.ticker; }
	inline const ExpiryKey& fkey() const { return layout_.fkey; }
	inline Float uBid() const { return layout_.uBid; }
	inline Float uAsk() const { return layout_.uAsk; }
	inline Float years() const { return layout_.years; }
	inline Float rate() const { return layout_.rate; }
	inline Float ddiv() const { return layout_.ddiv; }
	inline Byte exType() const { return layout_.exType; }
	inline Byte modelType() const { return layout_.modelType; }
	inline Float earnCnt() const { return layout_.earnCnt; }
	inline Float earnCntAdj() const { return layout_.earnCntAdj; }
	inline Float axisVolRT() const { return layout_.axisVolRT; }
	inline Float axisFUPrc() const { return layout_.axisFUPrc; }
	inline MoneynessType moneynessType() const { return layout_.moneynessType; }
	inline UnderlierMode underlierMode() const { return layout_.underlierMode; }
	inline PriceQuoteType priceQuoteType() const { return layout_.priceQuoteType; }
	inline Float atmVol() const { return layout_.atmVol; }
	inline Float atmCen() const { return layout_.atmCen; }
	inline Float atmVolHist() const { return layout_.atmVolHist; }
	inline Float atmCenHist() const { return layout_.atmCenHist; }
	inline Float minAtmVol() const { return layout_.minAtmVol; }
	inline Float maxAtmVol() const { return layout_.maxAtmVol; }
	inline Float minCPAdjVal() const { return layout_.minCPAdjVal; }
	inline Float maxCPAdjVal() const { return layout_.maxCPAdjVal; }
	inline Float eMove() const { return layout_.eMove; }
	inline Float eMoveHist() const { return layout_.eMoveHist; }
	inline Float uPrcOffset() const { return layout_.uPrcOffset; }
	inline Float uPrcOffsetEMA() const { return layout_.uPrcOffsetEMA; }
	inline Float sdiv() const { return layout_.sdiv; }
	inline Float sdivEMA() const { return layout_.sdivEMA; }
	inline Float atmMove() const { return layout_.atmMove; }
	inline Float atmCenMove() const { return layout_.atmCenMove; }
	inline Float atmPhi() const { return layout_.atmPhi; }
	inline Float atmVega() const { return layout_.atmVega; }
	inline Float slope() const { return layout_.slope; }
	inline Float varSwapFV() const { return layout_.varSwapFV; }
	inline GridType gridType() const { return layout_.gridType; }
	inline Float minXAxis() const { return layout_.minXAxis; }
	inline Float maxXAxis() const { return layout_.maxXAxis; }
	inline Float minCurvValue() const { return layout_.minCurvValue; }
	inline Float minCurvXAxis() const { return layout_.minCurvXAxis; }
	inline Float maxCurvValue() const { return layout_.maxCurvValue; }
	inline Float maxCurvXAxis() const { return layout_.maxCurvXAxis; }
	inline Float skewMinX() const { return layout_.skewMinX; }
	inline Float skewMinY() const { return layout_.skewMinY; }
	inline Float skewD11() const { return layout_.skewD11; }
	inline Float skewD10() const { return layout_.skewD10; }
	inline Float skewD9() const { return layout_.skewD9; }
	inline Float skewD8() const { return layout_.skewD8; }
	inline Float skewD7() const { return layout_.skewD7; }
	inline Float skewD6() const { return layout_.skewD6; }
	inline Float skewD5() const { return layout_.skewD5; }
	inline Float skewD4() const { return layout_.skewD4; }
	inline Float skewD3() const { return layout_.skewD3; }
	inline Float skewD2() const { return layout_.skewD2; }
	inline Float skewD1() const { return layout_.skewD1; }
	inline Float skewC0() const { return layout_.skewC0; }
	inline Float skewU1() const { return layout_.skewU1; }
	inline Float skewU2() const { return layout_.skewU2; }
	inline Float skewU3() const { return layout_.skewU3; }
	inline Float skewU4() const { return layout_.skewU4; }
	inline Float skewU5() const { return layout_.skewU5; }
	inline Float skewU6() const { return layout_.skewU6; }
	inline Float skewU7() const { return layout_.skewU7; }
	inline Float skewU8() const { return layout_.skewU8; }
	inline Float skewU9() const { return layout_.skewU9; }
	inline Float skewU10() const { return layout_.skewU10; }
	inline Float skewU11() const { return layout_.skewU11; }
	inline Float sdivD3() const { return layout_.sdivD3; }
	inline Float sdivD2() const { return layout_.sdivD2; }
	inline Float sdivD1() const { return layout_.sdivD1; }
	inline Float sdivU1() const { return layout_.sdivU1; }
	inline Float sdivU2() const { return layout_.sdivU2; }
	inline Float sdivU3() const { return layout_.sdivU3; }
	inline Float pwidth() const { return layout_.pwidth; }
	inline Float vwidth() const { return layout_.vwidth; }
	inline Byte cCnt() const { return layout_.cCnt; }
	inline Byte pCnt() const { return layout_.pCnt; }
	inline Byte cBidMiss() const { return layout_.cBidMiss; }
	inline Byte cAskMiss() const { return layout_.cAskMiss; }
	inline Byte pBidMiss() const { return layout_.pBidMiss; }
	inline Byte pAskMiss() const { return layout_.pAskMiss; }
	inline FitPath fitPath() const { return layout_.fitPath; }
	inline Float fitAvgErr() const { return layout_.fitAvgErr; }
	inline Float fitAvgAbsErr() const { return layout_.fitAvgAbsErr; }
	inline Float fitMaxPrcErr() const { return layout_.fitMaxPrcErr; }
	inline Float fitErrXX() const { return layout_.fitErrXX; }
	inline CallPut fitErrCP() const { return layout_.fitErrCP; }
	inline Float fitErrDe() const { return layout_.fitErrDe; }
	inline Float fitErrBid() const { return layout_.fitErrBid; }
	inline Float fitErrAsk() const { return layout_.fitErrAsk; }
	inline Float fitErrPrc() const { return layout_.fitErrPrc; }
	inline Float fitErrVol() const { return layout_.fitErrVol; }
	inline Byte cBidMissT() const { return layout_.cBidMissT; }
	inline Byte cAskMissT() const { return layout_.cAskMissT; }
	inline Byte pBidMissT() const { return layout_.pBidMissT; }
	inline Byte pAskMissT() const { return layout_.pAskMissT; }
	inline Float fitAvgAbsErrT() const { return layout_.fitAvgAbsErrT; }
	inline const ExpiryKey& sEKey() const { return layout_.sEKey; }
	inline LiveSurfaceType sType() const { return layout_.sType; }
	inline DateTime sTimestamp() const { return layout_.sTimestamp; }
	inline Int counter() const { return layout_.counter; }
	inline Int skewCounter() const { return layout_.skewCounter; }
	inline Int sdivCounter() const { return layout_.sdivCounter; }
	inline MarketSession marketSession() const { return layout_.marketSession; }
	inline TradeableStatus tradeableStatus() const { return layout_.tradeableStatus; }
	inline SurfaceResult surfaceResult() const { return layout_.surfaceResult; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<LiveSurfaceAtm::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionCloseMark
{
public:
	class Key
	{
		OptionKey okey_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		DateKey tradeDate;
		ClsMarkState clsMarkState;
		Double uBid;
		Double uAsk;
		Double uSrCls;
		Double uClose;
		Float bidPrc;
		Float askPrc;
		Double srClsPrc;
		Double closePrc;
		YesNo hasSRClsPrc;
		YesNo hasClosePrc;
		Float bidIV;
		Float askIV;
		Float srPrc;
		Float srVol;
		MarkSource srSrc;
		Float de;
		Float ga;
		Float th;
		Float ve;
		Float vo;
		Float va;
		Float rh;
		Float ph;
		Float srSlope;
		Float deDecay;
		Float sdiv;
		Float ddiv;
		Float rate;
		Float years;
		Byte error;
		Int openInterest;
		Int prtCount;
		Int prtVolume;
		DateTime srCloseMarkDttm;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline DateKey tradeDate() const { return layout_.tradeDate; }
	inline ClsMarkState clsMarkState() const { return layout_.clsMarkState; }
	inline Double uBid() const { return layout_.uBid; }
	inline Double uAsk() const { return layout_.uAsk; }
	inline Double uSrCls() const { return layout_.uSrCls; }
	inline Double uClose() const { return layout_.uClose; }
	inline Float bidPrc() const { return layout_.bidPrc; }
	inline Float askPrc() const { return layout_.askPrc; }
	inline Double srClsPrc() const { return layout_.srClsPrc; }
	inline Double closePrc() const { return layout_.closePrc; }
	inline YesNo hasSRClsPrc() const { return layout_.hasSRClsPrc; }
	inline YesNo hasClosePrc() const { return layout_.hasClosePrc; }
	inline Float bidIV() const { return layout_.bidIV; }
	inline Float askIV() const { return layout_.askIV; }
	inline Float srPrc() const { return layout_.srPrc; }
	inline Float srVol() const { return layout_.srVol; }
	inline MarkSource srSrc() const { return layout_.srSrc; }
	inline Float de() const { return layout_.de; }
	inline Float ga() const { return layout_.ga; }
	inline Float th() const { return layout_.th; }
	inline Float ve() const { return layout_.ve; }
	inline Float vo() const { return layout_.vo; }
	inline Float va() const { return layout_.va; }
	inline Float rh() const { return layout_.rh; }
	inline Float ph() const { return layout_.ph; }
	inline Float srSlope() const { return layout_.srSlope; }
	inline Float deDecay() const { return layout_.deDecay; }
	inline Float sdiv() const { return layout_.sdiv; }
	inline Float ddiv() const { return layout_.ddiv; }
	inline Float rate() const { return layout_.rate; }
	inline Float years() const { return layout_.years; }
	inline Byte error() const { return layout_.error; }
	inline Int openInterest() const { return layout_.openInterest; }
	inline Int prtCount() const { return layout_.prtCount; }
	inline Int prtVolume() const { return layout_.prtVolume; }
	inline DateTime srCloseMarkDttm() const { return layout_.srCloseMarkDttm; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionCloseMark::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionExchOrder
{
public:
	class Key
	{
		OptionKey okey_;
		BuySell side_;
		OptExch exch_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }
		inline BuySell side() const { return side_; }
		inline OptExch exch() const { return exch_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.side_));
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.exch_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_
				&& a.side_ == b.side_
				&& a.exch_ == b.exch_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		Long exchOrderID;
		Int size;
		Double price;
		Int origOrderSize;
		ExchOrderType orderType;
		ExchOrderStatus orderStatus;
		MarketQualifier marketQualifier;
		ExecQualifier execQualifier;
		TimeInForce timeInForce;
		FirmType firmType;
		PositionType positionType;
		String<5> clearingFirm;
		String<8> clearingAccnt;
		String<16> otherDetail;
		Long srcTimestamp;
		Long netTimestamp;
		Long dgwTimestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline Long exchOrderID() const { return layout_.exchOrderID; }
	inline Int size() const { return layout_.size; }
	inline Double price() const { return layout_.price; }
	inline Int origOrderSize() const { return layout_.origOrderSize; }
	inline ExchOrderType orderType() const { return layout_.orderType; }
	inline ExchOrderStatus orderStatus() const { return layout_.orderStatus; }
	inline MarketQualifier marketQualifier() const { return layout_.marketQualifier; }
	inline ExecQualifier execQualifier() const { return layout_.execQualifier; }
	inline TimeInForce timeInForce() const { return layout_.timeInForce; }
	inline FirmType firmType() const { return layout_.firmType; }
	inline PositionType positionType() const { return layout_.positionType; }
	inline const String<5>& clearingFirm() const { return layout_.clearingFirm; }
	inline const String<8>& clearingAccnt() const { return layout_.clearingAccnt; }
	inline const String<16>& otherDetail() const { return layout_.otherDetail; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline Long dgwTimestamp() const { return layout_.dgwTimestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionExchOrder::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionExchPrint
{
public:
	class Key
	{
		Long srPrintID_;
		
	public:
		inline Long srPrintID() const { return srPrintID_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = std::hash<Long>()(k.srPrintID_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.srPrintID_ == b.srPrintID_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		OptionKey okey;
		OptExch exch;
		Long exchOrderID;
		Int prtSize;
		Double prtPrice;
		ExchPrtType exchPrtType;
		Long srcTimestamp;
		Long netTimestamp;
		Long dgwTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const OptionKey& okey() const { return layout_.okey; }
	inline OptExch exch() const { return layout_.exch; }
	inline Long exchOrderID() const { return layout_.exchOrderID; }
	inline Int prtSize() const { return layout_.prtSize; }
	inline Double prtPrice() const { return layout_.prtPrice; }
	inline ExchPrtType exchPrtType() const { return layout_.exchPrtType; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline Long dgwTimestamp() const { return layout_.dgwTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionExchPrint::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionImpliedQuote
{
public:
	class Key
	{
		OptionKey okey_;
		CalcType calcType_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }
		inline CalcType calcType() const { return calcType_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.calcType_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_
				&& a.calcType_ == b.calcType_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		TickerKey ticker;
		Float uprc;
		Float years;
		Float rate;
		Float sdiv;
		Float ddiv;
		Float obid;
		Float oask;
		Float obiv;
		Float oaiv;
		Float satm;
		Float smny;
		Float svol;
		Float sprc;
		Float smrk;
		Float veSlope;
		Float de;
		Float ga;
		Float th;
		Float ve;
		Float ro;
		Float ph;
		Float up50;
		Float dn50;
		Float up15;
		Float dn15;
		Float up06;
		Float dn08;
		String<24> calcErr;
		CalcSource calcSource;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const TickerKey& ticker() const { return layout_.ticker; }
	inline Float uprc() const { return layout_.uprc; }
	inline Float years() const { return layout_.years; }
	inline Float rate() const { return layout_.rate; }
	inline Float sdiv() const { return layout_.sdiv; }
	inline Float ddiv() const { return layout_.ddiv; }
	inline Float obid() const { return layout_.obid; }
	inline Float oask() const { return layout_.oask; }
	inline Float obiv() const { return layout_.obiv; }
	inline Float oaiv() const { return layout_.oaiv; }
	inline Float satm() const { return layout_.satm; }
	inline Float smny() const { return layout_.smny; }
	inline Float svol() const { return layout_.svol; }
	inline Float sprc() const { return layout_.sprc; }
	inline Float smrk() const { return layout_.smrk; }
	inline Float veSlope() const { return layout_.veSlope; }
	inline Float de() const { return layout_.de; }
	inline Float ga() const { return layout_.ga; }
	inline Float th() const { return layout_.th; }
	inline Float ve() const { return layout_.ve; }
	inline Float ro() const { return layout_.ro; }
	inline Float ph() const { return layout_.ph; }
	inline Float up50() const { return layout_.up50; }
	inline Float dn50() const { return layout_.dn50; }
	inline Float up15() const { return layout_.up15; }
	inline Float dn15() const { return layout_.dn15; }
	inline Float up06() const { return layout_.up06; }
	inline Float dn08() const { return layout_.dn08; }
	inline const String<24>& calcErr() const { return layout_.calcErr; }
	inline CalcSource calcSource() const { return layout_.calcSource; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionImpliedQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionNbboQuote
{
public:
	class Key
	{
		OptionKey okey_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		UpdateType updateType;
		Float bidPrice;
		Float askPrice;
		Int bidSize;
		Int askSize;
		Int cumBidSize;
		Int cumAskSize;
		OptExch bidExch;
		OptExch askExch;
		UInt bidMask;
		UInt askMask;
		OpraMktType bidMktType;
		OpraMktType askMktType;
		Float bidPrice2;
		Float askPrice2;
		Int cumBidSize2;
		Int cumAskSize2;
		Int bidTime;
		Int askTime;
		Long srcTimestamp;
		Long netTimestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline UpdateType updateType() const { return layout_.updateType; }
	inline Float bidPrice() const { return layout_.bidPrice; }
	inline Float askPrice() const { return layout_.askPrice; }
	inline Int bidSize() const { return layout_.bidSize; }
	inline Int askSize() const { return layout_.askSize; }
	inline Int cumBidSize() const { return layout_.cumBidSize; }
	inline Int cumAskSize() const { return layout_.cumAskSize; }
	inline OptExch bidExch() const { return layout_.bidExch; }
	inline OptExch askExch() const { return layout_.askExch; }
	inline UInt bidMask() const { return layout_.bidMask; }
	inline UInt askMask() const { return layout_.askMask; }
	inline OpraMktType bidMktType() const { return layout_.bidMktType; }
	inline OpraMktType askMktType() const { return layout_.askMktType; }
	inline Float bidPrice2() const { return layout_.bidPrice2; }
	inline Float askPrice2() const { return layout_.askPrice2; }
	inline Int cumBidSize2() const { return layout_.cumBidSize2; }
	inline Int cumAskSize2() const { return layout_.cumAskSize2; }
	inline Int bidTime() const { return layout_.bidTime; }
	inline Int askTime() const { return layout_.askTime; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionNbboQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionOpenInterest
{
public:
	class Key
	{
		OptionKey okey_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		Int openInt;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline Int openInt() const { return layout_.openInt; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionOpenInterest::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionPrint
{
public:
	class Key
	{
		OptionKey okey_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		OptExch prtExch;
		Int prtSize;
		Float prtPrice;
		Int prtClusterNum;
		Int prtClusterSize;
		Byte prtType;
		UShort prtOrders;
		Int prtVolume;
		Int cxlVolume;
		UShort bidCount;
		UShort askCount;
		Int bidVolume;
		Int askVolume;
		Float ebid;
		Float eask;
		Int ebsz;
		Int easz;
		Float eage;
		PrtSide prtSide;
		Long prtTimestamp;
		Long netTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline OptExch prtExch() const { return layout_.prtExch; }
	inline Int prtSize() const { return layout_.prtSize; }
	inline Float prtPrice() const { return layout_.prtPrice; }
	inline Int prtClusterNum() const { return layout_.prtClusterNum; }
	inline Int prtClusterSize() const { return layout_.prtClusterSize; }
	inline Byte prtType() const { return layout_.prtType; }
	inline UShort prtOrders() const { return layout_.prtOrders; }
	inline Int prtVolume() const { return layout_.prtVolume; }
	inline Int cxlVolume() const { return layout_.cxlVolume; }
	inline UShort bidCount() const { return layout_.bidCount; }
	inline UShort askCount() const { return layout_.askCount; }
	inline Int bidVolume() const { return layout_.bidVolume; }
	inline Int askVolume() const { return layout_.askVolume; }
	inline Float ebid() const { return layout_.ebid; }
	inline Float eask() const { return layout_.eask; }
	inline Int ebsz() const { return layout_.ebsz; }
	inline Int easz() const { return layout_.easz; }
	inline Float eage() const { return layout_.eage; }
	inline PrtSide prtSide() const { return layout_.prtSide; }
	inline Long prtTimestamp() const { return layout_.prtTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionPrint::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionPrint2
{
public:
	class Key
	{
		OptionKey okey_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		OptExch prtExch;
		Int prtSize;
		Float prtPrice;
		Int prtClusterNum;
		Int prtClusterSize;
		Byte prtType;
		UShort prtOrders;
		Int prtVolume;
		Int oosVolume;
		Int isoVolume;
		Int slaVolume;
		Int mlaVolume;
		Int crxVolume;
		Int flrVolume;
		Int mlgVolume;
		Int uknVolume;
		Int cxlVolume;
		Int totalVolume;
		UShort bidCount;
		UShort askCount;
		Int bidVolume;
		Int askVolume;
		Float ebid;
		Float eask;
		Int ebsz;
		Int easz;
		Float eage;
		PrtSide prtSide;
		Long prtTimestamp;
		Long netTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline OptExch prtExch() const { return layout_.prtExch; }
	inline Int prtSize() const { return layout_.prtSize; }
	inline Float prtPrice() const { return layout_.prtPrice; }
	inline Int prtClusterNum() const { return layout_.prtClusterNum; }
	inline Int prtClusterSize() const { return layout_.prtClusterSize; }
	inline Byte prtType() const { return layout_.prtType; }
	inline UShort prtOrders() const { return layout_.prtOrders; }
	inline Int prtVolume() const { return layout_.prtVolume; }
	inline Int oosVolume() const { return layout_.oosVolume; }
	inline Int isoVolume() const { return layout_.isoVolume; }
	inline Int slaVolume() const { return layout_.slaVolume; }
	inline Int mlaVolume() const { return layout_.mlaVolume; }
	inline Int crxVolume() const { return layout_.crxVolume; }
	inline Int flrVolume() const { return layout_.flrVolume; }
	inline Int mlgVolume() const { return layout_.mlgVolume; }
	inline Int uknVolume() const { return layout_.uknVolume; }
	inline Int cxlVolume() const { return layout_.cxlVolume; }
	inline Int totalVolume() const { return layout_.totalVolume; }
	inline UShort bidCount() const { return layout_.bidCount; }
	inline UShort askCount() const { return layout_.askCount; }
	inline Int bidVolume() const { return layout_.bidVolume; }
	inline Int askVolume() const { return layout_.askVolume; }
	inline Float ebid() const { return layout_.ebid; }
	inline Float eask() const { return layout_.eask; }
	inline Int ebsz() const { return layout_.ebsz; }
	inline Int easz() const { return layout_.easz; }
	inline Float eage() const { return layout_.eage; }
	inline PrtSide prtSide() const { return layout_.prtSide; }
	inline Long prtTimestamp() const { return layout_.prtTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionPrint2::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionPrintMarkup
{
public:
	class Key
	{
		OptionKey okey_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		Long prtNumber;
		ExpiryKey fkey;
		TickerKey ticker;
		OptExch prtExch;
		Int prtSize;
		Float prtPrice;
		Byte prtType;
		UShort prtOrders;
		Int prtClusterNum;
		Int prtClusterSize;
		Int prtVolume;
		Int cxlVolume;
		UShort bidCount;
		UShort askCount;
		Int bidVolume;
		Int askVolume;
		Float ebid;
		Float eask;
		Int ebsz;
		Int easz;
		Float eage;
		PrtSide prtSide;
		Float oBid;
		Float oAsk;
		Int oBidSz;
		Int oAskSz;
		OptExch oBidEx;
		OptExch oAskEx;
		Int oBidExSz;
		Int oAskExSz;
		Byte oBidCnt;
		Byte oAskCnt;
		Float oBid2;
		Float oAsk2;
		Int oBidSz2;
		Int oAskSz2;
		Double uBid;
		Double uAsk;
		Double uPrc;
		Float yrs;
		Float rate;
		Float sdiv;
		Float ddiv;
		Float xDe;
		Float xAxis;
		Multihedge multihedge;
		Float prtIv;
		Float prtDe;
		Float prtGa;
		Float prtTh;
		Float prtVe;
		Float prtRo;
		String<24> calcErr;
		Float surfVol;
		Float surfOpx;
		Float surfAtm;
		Long srcTimestamp;
		Long netTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline Long prtNumber() const { return layout_.prtNumber; }
	inline const ExpiryKey& fkey() const { return layout_.fkey; }
	inline const TickerKey& ticker() const { return layout_.ticker; }
	inline OptExch prtExch() const { return layout_.prtExch; }
	inline Int prtSize() const { return layout_.prtSize; }
	inline Float prtPrice() const { return layout_.prtPrice; }
	inline Byte prtType() const { return layout_.prtType; }
	inline UShort prtOrders() const { return layout_.prtOrders; }
	inline Int prtClusterNum() const { return layout_.prtClusterNum; }
	inline Int prtClusterSize() const { return layout_.prtClusterSize; }
	inline Int prtVolume() const { return layout_.prtVolume; }
	inline Int cxlVolume() const { return layout_.cxlVolume; }
	inline UShort bidCount() const { return layout_.bidCount; }
	inline UShort askCount() const { return layout_.askCount; }
	inline Int bidVolume() const { return layout_.bidVolume; }
	inline Int askVolume() const { return layout_.askVolume; }
	inline Float ebid() const { return layout_.ebid; }
	inline Float eask() const { return layout_.eask; }
	inline Int ebsz() const { return layout_.ebsz; }
	inline Int easz() const { return layout_.easz; }
	inline Float eage() const { return layout_.eage; }
	inline PrtSide prtSide() const { return layout_.prtSide; }
	inline Float oBid() const { return layout_.oBid; }
	inline Float oAsk() const { return layout_.oAsk; }
	inline Int oBidSz() const { return layout_.oBidSz; }
	inline Int oAskSz() const { return layout_.oAskSz; }
	inline OptExch oBidEx() const { return layout_.oBidEx; }
	inline OptExch oAskEx() const { return layout_.oAskEx; }
	inline Int oBidExSz() const { return layout_.oBidExSz; }
	inline Int oAskExSz() const { return layout_.oAskExSz; }
	inline Byte oBidCnt() const { return layout_.oBidCnt; }
	inline Byte oAskCnt() const { return layout_.oAskCnt; }
	inline Float oBid2() const { return layout_.oBid2; }
	inline Float oAsk2() const { return layout_.oAsk2; }
	inline Int oBidSz2() const { return layout_.oBidSz2; }
	inline Int oAskSz2() const { return layout_.oAskSz2; }
	inline Double uBid() const { return layout_.uBid; }
	inline Double uAsk() const { return layout_.uAsk; }
	inline Double uPrc() const { return layout_.uPrc; }
	inline Float yrs() const { return layout_.yrs; }
	inline Float rate() const { return layout_.rate; }
	inline Float sdiv() const { return layout_.sdiv; }
	inline Float ddiv() const { return layout_.ddiv; }
	inline Float xDe() const { return layout_.xDe; }
	inline Float xAxis() const { return layout_.xAxis; }
	inline Multihedge multihedge() const { return layout_.multihedge; }
	inline Float prtIv() const { return layout_.prtIv; }
	inline Float prtDe() const { return layout_.prtDe; }
	inline Float prtGa() const { return layout_.prtGa; }
	inline Float prtTh() const { return layout_.prtTh; }
	inline Float prtVe() const { return layout_.prtVe; }
	inline Float prtRo() const { return layout_.prtRo; }
	inline const String<24>& calcErr() const { return layout_.calcErr; }
	inline Float surfVol() const { return layout_.surfVol; }
	inline Float surfOpx() const { return layout_.surfOpx; }
	inline Float surfAtm() const { return layout_.surfAtm; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionPrintMarkup::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionRiskFactor
{
public:
	class Key
	{
		OptionKey okey_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		TickerKey ticker;
		Float svol;
		Float years;
		Float up50;
		Float dn50;
		Float up15;
		Float dn15;
		Float up12;
		Float dn12;
		Float up09;
		Float dn09;
		Float dn08;
		Float up06;
		Float dn06;
		Float up03;
		Float dn03;
		String<24> calcErr;
		CalcSource calcSource;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const TickerKey& ticker() const { return layout_.ticker; }
	inline Float svol() const { return layout_.svol; }
	inline Float years() const { return layout_.years; }
	inline Float up50() const { return layout_.up50; }
	inline Float dn50() const { return layout_.dn50; }
	inline Float up15() const { return layout_.up15; }
	inline Float dn15() const { return layout_.dn15; }
	inline Float up12() const { return layout_.up12; }
	inline Float dn12() const { return layout_.dn12; }
	inline Float up09() const { return layout_.up09; }
	inline Float dn09() const { return layout_.dn09; }
	inline Float dn08() const { return layout_.dn08; }
	inline Float up06() const { return layout_.up06; }
	inline Float dn06() const { return layout_.dn06; }
	inline Float up03() const { return layout_.up03; }
	inline Float dn03() const { return layout_.dn03; }
	inline const String<24>& calcErr() const { return layout_.calcErr; }
	inline CalcSource calcSource() const { return layout_.calcSource; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionRiskFactor::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class ProductDefinitionV2
{
public:
	class Key
	{
		OptionKey secKey_;
		SpdrKeyType secType_;
		
	public:
		inline const OptionKey& secKey() const { return secKey_; }
		inline SpdrKeyType secType() const { return secType_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.secKey_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.secType_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.secKey_ == b.secKey_
				&& a.secType_ == b.secType_;
		}
	};
	
	class Legs
	{
		String<24> legID_;
		OptionKey secKey_;
		SpdrKeyType secType_;
		BuySell side_;
		UShort ratio_;
		Float refDelta_;
		Double refPrc_;
		
	public:
		inline const String<24>& legID() const { return legID_; }
		inline const OptionKey& secKey() const { return secKey_; }
		inline SpdrKeyType secType() const { return secType_; }
		inline BuySell side() const { return side_; }
		inline UShort ratio() const { return ratio_; }
		inline Float refDelta() const { return refDelta_; }
		inline Double refPrc() const { return refPrc_; }
		inline void legID(const String<24>& value) { legID_ = value; }
		inline void secKey(const OptionKey& value) { secKey_ = value; }
		inline void secType(SpdrKeyType value) { secType_ = value; }
		inline void side(BuySell value) { side_ = value; }
		inline void ratio(UShort value) { ratio_ = value; }
		inline void refDelta(Float value) { refDelta_ = value; }
		inline void refPrc(Double value) { refPrc_ = value; }
	};

private:
	struct Layout
	{
		Key pkey;
		String<24> securityID;
		ProductClass productClass;
		Long underlierID;
		ExpiryKey undKey;
		SpdrKeyType undType;
		String<6> productGroup;
		String<6> securityGroup;
		Int marketSegmentID;
		String<80> securityDesc;
		String<8> exchange;
		ProductType productType;
		ProductTerm productTerm;
		ProductIndexType productIndexType;
		Float productRate;
		Float contractSize;
		ContractUnit contractUnit;
		PriceFormat priceFormat;
		Double minTickSize;
		Double displayFactor;
		Double strikeScale;
		Short minLotSize;
		Short bookDepth;
		Short impliedBookDepth;
		Short impMarketInd;
		Float minPriceIncrementAmount;
		Float parValue;
		Float contMultiplier;
		Double cabPrice;
		Currency tradeCurr;
		Currency settleCurr;
		Currency strikeCurr;
		DateTime expiration;
		DateKey maturity;
		ExerciseType exerciseType;
		YesNo userDefined;
		Short decayStartYear;
		Byte decayStartMonth;
		Byte decayStartDay;
		Int decayQty;
		Double priceRatio;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	vector<Legs>legs_;
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const String<24>& securityID() const { return layout_.securityID; }
	inline ProductClass productClass() const { return layout_.productClass; }
	inline Long underlierID() const { return layout_.underlierID; }
	inline const ExpiryKey& undKey() const { return layout_.undKey; }
	inline SpdrKeyType undType() const { return layout_.undType; }
	inline const String<6>& productGroup() const { return layout_.productGroup; }
	inline const String<6>& securityGroup() const { return layout_.securityGroup; }
	inline Int marketSegmentID() const { return layout_.marketSegmentID; }
	inline const String<80>& securityDesc() const { return layout_.securityDesc; }
	inline const String<8>& exchange() const { return layout_.exchange; }
	inline ProductType productType() const { return layout_.productType; }
	inline ProductTerm productTerm() const { return layout_.productTerm; }
	inline ProductIndexType productIndexType() const { return layout_.productIndexType; }
	inline Float productRate() const { return layout_.productRate; }
	inline Float contractSize() const { return layout_.contractSize; }
	inline ContractUnit contractUnit() const { return layout_.contractUnit; }
	inline PriceFormat priceFormat() const { return layout_.priceFormat; }
	inline Double minTickSize() const { return layout_.minTickSize; }
	inline Double displayFactor() const { return layout_.displayFactor; }
	inline Double strikeScale() const { return layout_.strikeScale; }
	inline Short minLotSize() const { return layout_.minLotSize; }
	inline Short bookDepth() const { return layout_.bookDepth; }
	inline Short impliedBookDepth() const { return layout_.impliedBookDepth; }
	inline Short impMarketInd() const { return layout_.impMarketInd; }
	inline Float minPriceIncrementAmount() const { return layout_.minPriceIncrementAmount; }
	inline Float parValue() const { return layout_.parValue; }
	inline Float contMultiplier() const { return layout_.contMultiplier; }
	inline Double cabPrice() const { return layout_.cabPrice; }
	inline Currency tradeCurr() const { return layout_.tradeCurr; }
	inline Currency settleCurr() const { return layout_.settleCurr; }
	inline Currency strikeCurr() const { return layout_.strikeCurr; }
	inline DateTime expiration() const { return layout_.expiration; }
	inline DateKey maturity() const { return layout_.maturity; }
	inline ExerciseType exerciseType() const { return layout_.exerciseType; }
	inline YesNo userDefined() const { return layout_.userDefined; }
	inline Short decayStartYear() const { return layout_.decayStartYear; }
	inline Byte decayStartMonth() const { return layout_.decayStartMonth; }
	inline Byte decayStartDay() const { return layout_.decayStartDay; }
	inline Int decayQty() const { return layout_.decayQty; }
	inline Double priceRatio() const { return layout_.priceRatio; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<ProductDefinitionV2::Layout*>(ptr);
		ptr += sizeof(layout_);
		
		// Legs Repeat Section
		auto legs_count = *reinterpret_cast<uint16_t*>(ptr);
		ptr += sizeof(legs_count);

		for (int i = 0; i < legs_count; i++)
		{
			legs_.push_back(*reinterpret_cast<Legs*>(ptr));
			ptr += sizeof(Legs);
		}

	}

};

 class RootDefinition
{
public:
	class Key
	{
		TickerKey root_;
		
	public:
		inline const TickerKey& root() const { return root_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.root_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.root_ == b.root_;
		}
	};
	
	class Underlying
	{
		TickerKey ticker_;
		Float spc_;
		
	public:
		inline const TickerKey& ticker() const { return ticker_; }
		inline Float spc() const { return spc_; }
		inline void ticker(const TickerKey& value) { ticker_ = value; }
		inline void spc(Float value) { spc_ = value; }
	};

private:
	struct Layout
	{
		Key pkey;
		TickerKey ticker;
		String<8> osiRoot;
		TickerKey ccode;
		ExpirationMap expirationMap;
		UnderlierMode underlierMode;
		OptionType optionType;
		Multihedge multihedge;
		ExerciseTime exerciseTime;
		ExerciseType exerciseType;
		TimeMetric timeMetric;
		PricingModel pricingModel;
		MoneynessType moneynessType;
		PriceQuoteType priceQuoteType;
		VolumeTier volumeTier;
		Int positionLimit;
		String<24> exchanges;
		Float tickValue;
		Float pointValue;
		Double strikeScale;
		Float strikeRatio;
		Float cashOnExercise;
		Int underliersPerCn;
		Double premiumMult;
		AdjConvention adjConvention;
		OptPriceInc optPriceInc;
		PriceFormat priceFormat;
		Currency tradeCurr;
		Currency settleCurr;
		Currency strikeCurr;
		TickerKey defaultSurfaceRoot;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	vector<Underlying>underlying_;
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const TickerKey& ticker() const { return layout_.ticker; }
	inline const String<8>& osiRoot() const { return layout_.osiRoot; }
	inline const TickerKey& ccode() const { return layout_.ccode; }
	inline ExpirationMap expirationMap() const { return layout_.expirationMap; }
	inline UnderlierMode underlierMode() const { return layout_.underlierMode; }
	inline OptionType optionType() const { return layout_.optionType; }
	inline Multihedge multihedge() const { return layout_.multihedge; }
	inline ExerciseTime exerciseTime() const { return layout_.exerciseTime; }
	inline ExerciseType exerciseType() const { return layout_.exerciseType; }
	inline TimeMetric timeMetric() const { return layout_.timeMetric; }
	inline PricingModel pricingModel() const { return layout_.pricingModel; }
	inline MoneynessType moneynessType() const { return layout_.moneynessType; }
	inline PriceQuoteType priceQuoteType() const { return layout_.priceQuoteType; }
	inline VolumeTier volumeTier() const { return layout_.volumeTier; }
	inline Int positionLimit() const { return layout_.positionLimit; }
	inline const String<24>& exchanges() const { return layout_.exchanges; }
	inline Float tickValue() const { return layout_.tickValue; }
	inline Float pointValue() const { return layout_.pointValue; }
	inline Double strikeScale() const { return layout_.strikeScale; }
	inline Float strikeRatio() const { return layout_.strikeRatio; }
	inline Float cashOnExercise() const { return layout_.cashOnExercise; }
	inline Int underliersPerCn() const { return layout_.underliersPerCn; }
	inline Double premiumMult() const { return layout_.premiumMult; }
	inline AdjConvention adjConvention() const { return layout_.adjConvention; }
	inline OptPriceInc optPriceInc() const { return layout_.optPriceInc; }
	inline PriceFormat priceFormat() const { return layout_.priceFormat; }
	inline Currency tradeCurr() const { return layout_.tradeCurr; }
	inline Currency settleCurr() const { return layout_.settleCurr; }
	inline Currency strikeCurr() const { return layout_.strikeCurr; }
	inline const TickerKey& defaultSurfaceRoot() const { return layout_.defaultSurfaceRoot; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<RootDefinition::Layout*>(ptr);
		ptr += sizeof(layout_);
		
		// Underlying Repeat Section
		auto underlying_count = *reinterpret_cast<uint16_t*>(ptr);
		ptr += sizeof(underlying_count);

		for (int i = 0; i < underlying_count; i++)
		{
			underlying_.push_back(*reinterpret_cast<Underlying*>(ptr));
			ptr += sizeof(Underlying);
		}

	}

};

 class SpdrAuctionState
{
public:
	class Key
	{
		Long srAuctionID_;
		
	public:
		inline Long srAuctionID() const { return srAuctionID_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = std::hash<Long>()(k.srAuctionID_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.srAuctionID_ == b.srAuctionID_;
		}
	};
	
	class Legs
	{
		OptionKey legSecKey_;
		SpdrKeyType legSecType_;
		BuySell legSide_;
		UShort legRatio_;
		
	public:
		inline const OptionKey& legSecKey() const { return legSecKey_; }
		inline SpdrKeyType legSecType() const { return legSecType_; }
		inline BuySell legSide() const { return legSide_; }
		inline UShort legRatio() const { return legRatio_; }
		inline void legSecKey(const OptionKey& value) { legSecKey_ = value; }
		inline void legSecType(SpdrKeyType value) { legSecType_ = value; }
		inline void legSide(BuySell value) { legSide_ = value; }
		inline void legRatio(UShort value) { legRatio_ = value; }
	};

private:
	struct Layout
	{
		Key pkey;
		OptionKey secKey;
		SpdrKeyType secType;
		String<20> exchAuctionId;
		String<4> exchAuctionType;
		YesNo isTestAuction;
		AuctionState auctionState;
		NoticeShape auctionShape;
		AuctionType auctionType;
		OptExch auctionExch;
		String<12> auctionExDest;
		BuySell auctionSide;
		Int auctionSize;
		Double auctionPrice;
		YesNo isAuctionPriceValid;
		Int auctionDuration;
		Int auctionStartSize;
		Double auctionStartPrice;
		Long auctionStartTimestamp;
		Int minResponseSize;
		AuctionLimitType limitType;
		FirmType firmType;
		String<10> memberMPID;
		String<10> clientAccnt;
		String<16> otherDetail;
		Int matchedSize;
		Byte numUpdates;
		Byte numResponses;
		Int bestResponseSize;
		Double bestResponsePrice;
		Int cumFillQuantity;
		Double avgFillPrice;
		MarketStatus marketStatus;
		Long srcTimestamp;
		Long netTimestamp;
		Long dgwTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	vector<Legs>legs_;
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const OptionKey& secKey() const { return layout_.secKey; }
	inline SpdrKeyType secType() const { return layout_.secType; }
	inline const String<20>& exchAuctionId() const { return layout_.exchAuctionId; }
	inline const String<4>& exchAuctionType() const { return layout_.exchAuctionType; }
	inline YesNo isTestAuction() const { return layout_.isTestAuction; }
	inline AuctionState auctionState() const { return layout_.auctionState; }
	inline NoticeShape auctionShape() const { return layout_.auctionShape; }
	inline AuctionType auctionType() const { return layout_.auctionType; }
	inline OptExch auctionExch() const { return layout_.auctionExch; }
	inline const String<12>& auctionExDest() const { return layout_.auctionExDest; }
	inline BuySell auctionSide() const { return layout_.auctionSide; }
	inline Int auctionSize() const { return layout_.auctionSize; }
	inline Double auctionPrice() const { return layout_.auctionPrice; }
	inline YesNo isAuctionPriceValid() const { return layout_.isAuctionPriceValid; }
	inline Int auctionDuration() const { return layout_.auctionDuration; }
	inline Int auctionStartSize() const { return layout_.auctionStartSize; }
	inline Double auctionStartPrice() const { return layout_.auctionStartPrice; }
	inline Long auctionStartTimestamp() const { return layout_.auctionStartTimestamp; }
	inline Int minResponseSize() const { return layout_.minResponseSize; }
	inline AuctionLimitType limitType() const { return layout_.limitType; }
	inline FirmType firmType() const { return layout_.firmType; }
	inline const String<10>& memberMPID() const { return layout_.memberMPID; }
	inline const String<10>& clientAccnt() const { return layout_.clientAccnt; }
	inline const String<16>& otherDetail() const { return layout_.otherDetail; }
	inline Int matchedSize() const { return layout_.matchedSize; }
	inline Byte numUpdates() const { return layout_.numUpdates; }
	inline Byte numResponses() const { return layout_.numResponses; }
	inline Int bestResponseSize() const { return layout_.bestResponseSize; }
	inline Double bestResponsePrice() const { return layout_.bestResponsePrice; }
	inline Int cumFillQuantity() const { return layout_.cumFillQuantity; }
	inline Double avgFillPrice() const { return layout_.avgFillPrice; }
	inline MarketStatus marketStatus() const { return layout_.marketStatus; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline Long dgwTimestamp() const { return layout_.dgwTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<SpdrAuctionState::Layout*>(ptr);
		ptr += sizeof(layout_);
		
		// Legs Repeat Section
		auto legs_count = *reinterpret_cast<uint16_t*>(ptr);
		ptr += sizeof(legs_count);

		for (int i = 0; i < legs_count; i++)
		{
			legs_.push_back(*reinterpret_cast<Legs*>(ptr));
			ptr += sizeof(Legs);
		}

	}

};

 class SpreadBookQuote
{
public:
	class Key
	{
		TickerKey skey_;
		YesNo isTest_;
		
	public:
		inline const TickerKey& skey() const { return skey_; }
		inline YesNo isTest() const { return isTest_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.skey_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.isTest_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.skey_ == b.skey_
				&& a.isTest_ == b.isTest_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		TickerKey ticker;
		Double bidPrice1;
		YesNo isBidPrice1Valid;
		Double askPrice1;
		YesNo isAskPrice1Valid;
		Int bidSize1;
		Int askSize1;
		Double bidPrice2;
		YesNo isBidPrice2Valid;
		Double askPrice2;
		YesNo isAskPrice2Valid;
		Int bidSize2;
		Int askSize2;
		OptExch bidExch1;
		OptExch askExch1;
		UInt bidMask1;
		UInt askMask1;
		DateTime bidTime;
		DateTime askTime;
		UpdateType updateType;
		Long srcTimestamp;
		Long netTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const TickerKey& ticker() const { return layout_.ticker; }
	inline Double bidPrice1() const { return layout_.bidPrice1; }
	inline YesNo isBidPrice1Valid() const { return layout_.isBidPrice1Valid; }
	inline Double askPrice1() const { return layout_.askPrice1; }
	inline YesNo isAskPrice1Valid() const { return layout_.isAskPrice1Valid; }
	inline Int bidSize1() const { return layout_.bidSize1; }
	inline Int askSize1() const { return layout_.askSize1; }
	inline Double bidPrice2() const { return layout_.bidPrice2; }
	inline YesNo isBidPrice2Valid() const { return layout_.isBidPrice2Valid; }
	inline Double askPrice2() const { return layout_.askPrice2; }
	inline YesNo isAskPrice2Valid() const { return layout_.isAskPrice2Valid; }
	inline Int bidSize2() const { return layout_.bidSize2; }
	inline Int askSize2() const { return layout_.askSize2; }
	inline OptExch bidExch1() const { return layout_.bidExch1; }
	inline OptExch askExch1() const { return layout_.askExch1; }
	inline UInt bidMask1() const { return layout_.bidMask1; }
	inline UInt askMask1() const { return layout_.askMask1; }
	inline DateTime bidTime() const { return layout_.bidTime; }
	inline DateTime askTime() const { return layout_.askTime; }
	inline UpdateType updateType() const { return layout_.updateType; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<SpreadBookQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class SpreadExchOrder
{
public:
	class Key
	{
		String<24> orderID_;
		OptExch exch_;
		BuySell side_;
		YesNo isTest_;
		
	public:
		inline const String<24>& orderID() const { return orderID_; }
		inline OptExch exch() const { return exch_; }
		inline BuySell side() const { return side_; }
		inline YesNo isTest() const { return isTest_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = String<24>()(k.orderID_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.exch_));
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.side_));
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.isTest_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.orderID_ == b.orderID_
				&& a.exch_ == b.exch_
				&& a.side_ == b.side_
				&& a.isTest_ == b.isTest_;
		}
	};
	
	class Legs
	{
		OptionKey legSecKey_;
		SpdrKeyType legSecType_;
		BuySell legSide_;
		UInt legRatio_;
		PositionType positionType_;
		
	public:
		inline const OptionKey& legSecKey() const { return legSecKey_; }
		inline SpdrKeyType legSecType() const { return legSecType_; }
		inline BuySell legSide() const { return legSide_; }
		inline UInt legRatio() const { return legRatio_; }
		inline PositionType positionType() const { return positionType_; }
		inline void legSecKey(const OptionKey& value) { legSecKey_ = value; }
		inline void legSecType(SpdrKeyType value) { legSecType_ = value; }
		inline void legSide(BuySell value) { legSide_ = value; }
		inline void legRatio(UInt value) { legRatio_ = value; }
		inline void positionType(PositionType value) { positionType_ = value; }
	};

private:
	struct Layout
	{
		Key pkey;
		TickerKey skey;
		Int size;
		Double price;
		YesNo isPriceValid;
		Int origOrderSize;
		ExchOrderType orderType;
		ExchOrderStatus orderStatus;
		MarketQualifier marketQualifier;
		ExecQualifier execQualifier;
		TimeInForce timeInForce;
		FirmType firmType;
		String<5> clearingFirm;
		String<8> clearingAccnt;
		Long srcTimestamp;
		Long netTimestamp;
		Long dgwTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	vector<Legs>legs_;
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const TickerKey& skey() const { return layout_.skey; }
	inline Int size() const { return layout_.size; }
	inline Double price() const { return layout_.price; }
	inline YesNo isPriceValid() const { return layout_.isPriceValid; }
	inline Int origOrderSize() const { return layout_.origOrderSize; }
	inline ExchOrderType orderType() const { return layout_.orderType; }
	inline ExchOrderStatus orderStatus() const { return layout_.orderStatus; }
	inline MarketQualifier marketQualifier() const { return layout_.marketQualifier; }
	inline ExecQualifier execQualifier() const { return layout_.execQualifier; }
	inline TimeInForce timeInForce() const { return layout_.timeInForce; }
	inline FirmType firmType() const { return layout_.firmType; }
	inline const String<5>& clearingFirm() const { return layout_.clearingFirm; }
	inline const String<8>& clearingAccnt() const { return layout_.clearingAccnt; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline Long dgwTimestamp() const { return layout_.dgwTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<SpreadExchOrder::Layout*>(ptr);
		ptr += sizeof(layout_);
		
		// Legs Repeat Section
		auto legs_count = *reinterpret_cast<uint16_t*>(ptr);
		ptr += sizeof(legs_count);

		for (int i = 0; i < legs_count; i++)
		{
			legs_.push_back(*reinterpret_cast<Legs*>(ptr));
			ptr += sizeof(Legs);
		}

	}

};

 class StockBookQuote
{
public:
	class Key
	{
		TickerKey ticker_;
		
	public:
		inline const TickerKey& ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.ticker_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		UpdateType updateType;
		MarketStatus marketStatus;
		Float bidPrice1;
		Int bidSize1;
		StkExch bidExch1;
		UInt bidMask1;
		Float askPrice1;
		Int askSize1;
		StkExch askExch1;
		UInt askMask1;
		Float bidPrice2;
		Int bidSize2;
		StkExch bidExch2;
		UInt bidMask2;
		Float askPrice2;
		Int askSize2;
		StkExch askExch2;
		UInt askMask2;
		UInt haltMask;
		Long srcTimestamp;
		Long netTimestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline UpdateType updateType() const { return layout_.updateType; }
	inline MarketStatus marketStatus() const { return layout_.marketStatus; }
	inline Float bidPrice1() const { return layout_.bidPrice1; }
	inline Int bidSize1() const { return layout_.bidSize1; }
	inline StkExch bidExch1() const { return layout_.bidExch1; }
	inline UInt bidMask1() const { return layout_.bidMask1; }
	inline Float askPrice1() const { return layout_.askPrice1; }
	inline Int askSize1() const { return layout_.askSize1; }
	inline StkExch askExch1() const { return layout_.askExch1; }
	inline UInt askMask1() const { return layout_.askMask1; }
	inline Float bidPrice2() const { return layout_.bidPrice2; }
	inline Int bidSize2() const { return layout_.bidSize2; }
	inline StkExch bidExch2() const { return layout_.bidExch2; }
	inline UInt bidMask2() const { return layout_.bidMask2; }
	inline Float askPrice2() const { return layout_.askPrice2; }
	inline Int askSize2() const { return layout_.askSize2; }
	inline StkExch askExch2() const { return layout_.askExch2; }
	inline UInt askMask2() const { return layout_.askMask2; }
	inline UInt haltMask() const { return layout_.haltMask; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<StockBookQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class StockExchImbalanceV2
{
public:
	class Key
	{
		TickerKey ticker_;
		DateTime auctionTime_;
		AuctionReason auctionType_;
		
	public:
		inline const TickerKey& ticker() const { return ticker_; }
		inline DateTime auctionTime() const { return auctionTime_; }
		inline AuctionReason auctionType() const { return auctionType_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.ticker_);
			hash_code = (hash_code * 397) ^ DateTime()(k.auctionTime_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.auctionType_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_
				&& a.auctionTime_ == b.auctionTime_
				&& a.auctionType_ == b.auctionType_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		Float referencePx;
		Int pairedQty;
		Int totalImbalanceQty;
		Int marketImbalanceQty;
		ImbalanceSide imbalanceSide;
		Float continuousBookClrPx;
		Float closingOnlyClrPx;
		Float ssrFillingPx;
		Float indicativeMatchPx;
		Float upperCollar;
		Float lowerCollar;
		AuctionStatus auctionStatus;
		YesNo freezeStatus;
		Byte numExtensions;
		Long netTimestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline Float referencePx() const { return layout_.referencePx; }
	inline Int pairedQty() const { return layout_.pairedQty; }
	inline Int totalImbalanceQty() const { return layout_.totalImbalanceQty; }
	inline Int marketImbalanceQty() const { return layout_.marketImbalanceQty; }
	inline ImbalanceSide imbalanceSide() const { return layout_.imbalanceSide; }
	inline Float continuousBookClrPx() const { return layout_.continuousBookClrPx; }
	inline Float closingOnlyClrPx() const { return layout_.closingOnlyClrPx; }
	inline Float ssrFillingPx() const { return layout_.ssrFillingPx; }
	inline Float indicativeMatchPx() const { return layout_.indicativeMatchPx; }
	inline Float upperCollar() const { return layout_.upperCollar; }
	inline Float lowerCollar() const { return layout_.lowerCollar; }
	inline AuctionStatus auctionStatus() const { return layout_.auctionStatus; }
	inline YesNo freezeStatus() const { return layout_.freezeStatus; }
	inline Byte numExtensions() const { return layout_.numExtensions; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<StockExchImbalanceV2::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class StockImbalance
{
public:
	class Key
	{
		TickerKey ticker_;
		AuctionReason auctionType_;
		
	public:
		inline const TickerKey& ticker() const { return ticker_; }
		inline AuctionReason auctionType() const { return auctionType_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.ticker_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.auctionType_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_
				&& a.auctionType_ == b.auctionType_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		DateTime auctionTime;
		Int maxImbalance;
		StkExch maxImbalanceExch;
		Double maxImbalanceMatchPx;
		AuctionStatus maxImbalanceStatus;
		Int cumBidImbalanceMkt;
		Int cumAskImbalanceMkt;
		Int cumBidImbalanceTot;
		Int cumAskImbalanceTot;
		Int cumPairedQty;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline DateTime auctionTime() const { return layout_.auctionTime; }
	inline Int maxImbalance() const { return layout_.maxImbalance; }
	inline StkExch maxImbalanceExch() const { return layout_.maxImbalanceExch; }
	inline Double maxImbalanceMatchPx() const { return layout_.maxImbalanceMatchPx; }
	inline AuctionStatus maxImbalanceStatus() const { return layout_.maxImbalanceStatus; }
	inline Int cumBidImbalanceMkt() const { return layout_.cumBidImbalanceMkt; }
	inline Int cumAskImbalanceMkt() const { return layout_.cumAskImbalanceMkt; }
	inline Int cumBidImbalanceTot() const { return layout_.cumBidImbalanceTot; }
	inline Int cumAskImbalanceTot() const { return layout_.cumAskImbalanceTot; }
	inline Int cumPairedQty() const { return layout_.cumPairedQty; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<StockImbalance::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class StockMarketSummary
{
public:
	class Key
	{
		TickerKey ticker_;
		
	public:
		inline const TickerKey& ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.ticker_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		Double opnPrice;
		Double mrkPrice;
		Double clsPrice;
		Double minPrice;
		Double maxPrice;
		Int sharesOutstanding;
		Int bidCount;
		Int bidVolume;
		Int askCount;
		Int askVolume;
		Int midCount;
		Int midVolume;
		Int prtCount;
		Double prtPrice;
		Int expCount;
		Double expWidth;
		Float expBidSize;
		Float expAskSize;
		DateTime lastPrint;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline Double opnPrice() const { return layout_.opnPrice; }
	inline Double mrkPrice() const { return layout_.mrkPrice; }
	inline Double clsPrice() const { return layout_.clsPrice; }
	inline Double minPrice() const { return layout_.minPrice; }
	inline Double maxPrice() const { return layout_.maxPrice; }
	inline Int sharesOutstanding() const { return layout_.sharesOutstanding; }
	inline Int bidCount() const { return layout_.bidCount; }
	inline Int bidVolume() const { return layout_.bidVolume; }
	inline Int askCount() const { return layout_.askCount; }
	inline Int askVolume() const { return layout_.askVolume; }
	inline Int midCount() const { return layout_.midCount; }
	inline Int midVolume() const { return layout_.midVolume; }
	inline Int prtCount() const { return layout_.prtCount; }
	inline Double prtPrice() const { return layout_.prtPrice; }
	inline Int expCount() const { return layout_.expCount; }
	inline Double expWidth() const { return layout_.expWidth; }
	inline Float expBidSize() const { return layout_.expBidSize; }
	inline Float expAskSize() const { return layout_.expAskSize; }
	inline DateTime lastPrint() const { return layout_.lastPrint; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<StockMarketSummary::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class StockPrint
{
public:
	class Key
	{
		TickerKey ticker_;
		
	public:
		inline const TickerKey& ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.ticker_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		StkExch prtExch;
		Int prtSize;
		Float prtPrice;
		Int prtClusterNum;
		Int prtClusterSize;
		Int prtVolume;
		Float mrkPrice;
		Float clsPrice;
		StkPrintType prtType;
		Byte prtCond1;
		Byte prtCond2;
		Byte prtCond3;
		Byte prtCond4;
		Float ebid;
		Float eask;
		Int ebsz;
		Int easz;
		Float eage;
		PrtSide prtSide;
		Long prtTimestamp;
		Long netTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline StkExch prtExch() const { return layout_.prtExch; }
	inline Int prtSize() const { return layout_.prtSize; }
	inline Float prtPrice() const { return layout_.prtPrice; }
	inline Int prtClusterNum() const { return layout_.prtClusterNum; }
	inline Int prtClusterSize() const { return layout_.prtClusterSize; }
	inline Int prtVolume() const { return layout_.prtVolume; }
	inline Float mrkPrice() const { return layout_.mrkPrice; }
	inline Float clsPrice() const { return layout_.clsPrice; }
	inline StkPrintType prtType() const { return layout_.prtType; }
	inline Byte prtCond1() const { return layout_.prtCond1; }
	inline Byte prtCond2() const { return layout_.prtCond2; }
	inline Byte prtCond3() const { return layout_.prtCond3; }
	inline Byte prtCond4() const { return layout_.prtCond4; }
	inline Float ebid() const { return layout_.ebid; }
	inline Float eask() const { return layout_.eask; }
	inline Int ebsz() const { return layout_.ebsz; }
	inline Int easz() const { return layout_.easz; }
	inline Float eage() const { return layout_.eage; }
	inline PrtSide prtSide() const { return layout_.prtSide; }
	inline Long prtTimestamp() const { return layout_.prtTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<StockPrint::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class StockPrintMarkup
{
public:
	class Key
	{
		TickerKey ticker_;
		
	public:
		inline const TickerKey& ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.ticker_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		Long prtNumber;
		StkExch prtExch;
		Int prtSize;
		Float prtPrice;
		Int prtClusterNum;
		Int prtClusterSize;
		Int prtVolume;
		Float mrkPrice;
		Byte prtType;
		Byte prtCond1;
		Byte prtCond2;
		Byte prtCond3;
		Byte prtCond4;
		PrtSide prtSide;
		Float bidPrice;
		Float askPrice;
		Int bidSize;
		Int askSize;
		Float bidPrice2;
		Float askPrice2;
		Int bidSize2;
		Int askSize2;
		Long srcTimestamp;
		Long netTimestamp;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline Long prtNumber() const { return layout_.prtNumber; }
	inline StkExch prtExch() const { return layout_.prtExch; }
	inline Int prtSize() const { return layout_.prtSize; }
	inline Float prtPrice() const { return layout_.prtPrice; }
	inline Int prtClusterNum() const { return layout_.prtClusterNum; }
	inline Int prtClusterSize() const { return layout_.prtClusterSize; }
	inline Int prtVolume() const { return layout_.prtVolume; }
	inline Float mrkPrice() const { return layout_.mrkPrice; }
	inline Byte prtType() const { return layout_.prtType; }
	inline Byte prtCond1() const { return layout_.prtCond1; }
	inline Byte prtCond2() const { return layout_.prtCond2; }
	inline Byte prtCond3() const { return layout_.prtCond3; }
	inline Byte prtCond4() const { return layout_.prtCond4; }
	inline PrtSide prtSide() const { return layout_.prtSide; }
	inline Float bidPrice() const { return layout_.bidPrice; }
	inline Float askPrice() const { return layout_.askPrice; }
	inline Int bidSize() const { return layout_.bidSize; }
	inline Int askSize() const { return layout_.askSize; }
	inline Float bidPrice2() const { return layout_.bidPrice2; }
	inline Float askPrice2() const { return layout_.askPrice2; }
	inline Int bidSize2() const { return layout_.bidSize2; }
	inline Int askSize2() const { return layout_.askSize2; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<StockPrintMarkup::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class TickerDefinitionExt
{
public:
	class Key
	{
		TickerKey ticker_;
		
	public:
		inline const TickerKey& ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.ticker_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		SymbolType symbolType;
		String<72> name;
		String<72> issuerName;
		String<2> cntryOfIncorp;
		Float parValue;
		String<3> parValueCurrency;
		PrimaryExchange primaryExch;
		String<4> mic;
		String<4> micSeg;
		String<12> symbol;
		String<1> issueClass;
		Int securityID;
		String<4> sic;
		String<10> cik;
		String<8> gics;
		String<20> lei;
		String<6> naics;
		String<6> cfi;
		String<4> cic;
		String<40> fisn;
		String<12> isin;
		String<12> bbgCompositeTicker;
		String<28> bbgExchangeTicker;
		String<12> bbgCompositeGlobalID;
		String<12> bbgGlobalID;
		String<3> bbgCurrency;
		StkPriceInc stkPriceInc;
		Float stkVolume;
		Float futVolume;
		Float optVolume;
		String<8> exchString;
		Int numOptions;
		Int sharesOutstanding;
		TimeMetric timeMetric;
		OTCPrimaryMarket otcPrimaryMarket;
		OTCTier otcTier;
		String<1> otcReportingStatus;
		Int otcDisclosureStatus;
		Int otcFlags;
		TkDefSource tkDefSource;
		TkStatusFlag statusFlag;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SymbolType symbolType() const { return layout_.symbolType; }
	inline const String<72>& name() const { return layout_.name; }
	inline const String<72>& issuerName() const { return layout_.issuerName; }
	inline const String<2>& cntryOfIncorp() const { return layout_.cntryOfIncorp; }
	inline Float parValue() const { return layout_.parValue; }
	inline const String<3>& parValueCurrency() const { return layout_.parValueCurrency; }
	inline PrimaryExchange primaryExch() const { return layout_.primaryExch; }
	inline const String<4>& mic() const { return layout_.mic; }
	inline const String<4>& micSeg() const { return layout_.micSeg; }
	inline const String<12>& symbol() const { return layout_.symbol; }
	inline const String<1>& issueClass() const { return layout_.issueClass; }
	inline Int securityID() const { return layout_.securityID; }
	inline const String<4>& sic() const { return layout_.sic; }
	inline const String<10>& cik() const { return layout_.cik; }
	inline const String<8>& gics() const { return layout_.gics; }
	inline const String<20>& lei() const { return layout_.lei; }
	inline const String<6>& naics() const { return layout_.naics; }
	inline const String<6>& cfi() const { return layout_.cfi; }
	inline const String<4>& cic() const { return layout_.cic; }
	inline const String<40>& fisn() const { return layout_.fisn; }
	inline const String<12>& isin() const { return layout_.isin; }
	inline const String<12>& bbgCompositeTicker() const { return layout_.bbgCompositeTicker; }
	inline const String<28>& bbgExchangeTicker() const { return layout_.bbgExchangeTicker; }
	inline const String<12>& bbgCompositeGlobalID() const { return layout_.bbgCompositeGlobalID; }
	inline const String<12>& bbgGlobalID() const { return layout_.bbgGlobalID; }
	inline const String<3>& bbgCurrency() const { return layout_.bbgCurrency; }
	inline StkPriceInc stkPriceInc() const { return layout_.stkPriceInc; }
	inline Float stkVolume() const { return layout_.stkVolume; }
	inline Float futVolume() const { return layout_.futVolume; }
	inline Float optVolume() const { return layout_.optVolume; }
	inline const String<8>& exchString() const { return layout_.exchString; }
	inline Int numOptions() const { return layout_.numOptions; }
	inline Int sharesOutstanding() const { return layout_.sharesOutstanding; }
	inline TimeMetric timeMetric() const { return layout_.timeMetric; }
	inline OTCPrimaryMarket otcPrimaryMarket() const { return layout_.otcPrimaryMarket; }
	inline OTCTier otcTier() const { return layout_.otcTier; }
	inline const String<1>& otcReportingStatus() const { return layout_.otcReportingStatus; }
	inline Int otcDisclosureStatus() const { return layout_.otcDisclosureStatus; }
	inline Int otcFlags() const { return layout_.otcFlags; }
	inline TkDefSource tkDefSource() const { return layout_.tkDefSource; }
	inline TkStatusFlag statusFlag() const { return layout_.statusFlag; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<TickerDefinitionExt::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};



}	// namespace DataFeed

}	// namespace SpiderRock

#pragma pack()
