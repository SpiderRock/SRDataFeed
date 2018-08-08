// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#pragma once

#include <functional>

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
		UShort bidSize1;
		UShort askSize1;
		UShort bidOrders1;
		UShort askOrders1;
		Double bidPrice2;
		Double askPrice2;
		UShort bidSize2;
		UShort askSize2;
		UShort bidOrders2;
		UShort askOrders2;
		Double bidPrice3;
		Double askPrice3;
		UShort bidSize3;
		UShort askSize3;
		UShort bidOrders3;
		UShort askOrders3;
		Double bidPrice4;
		Double askPrice4;
		UShort bidSize4;
		UShort askSize4;
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
	inline UShort bidSize1() const { return layout_.bidSize1; }
	inline UShort askSize1() const { return layout_.askSize1; }
	inline UShort bidOrders1() const { return layout_.bidOrders1; }
	inline UShort askOrders1() const { return layout_.askOrders1; }
	inline Double bidPrice2() const { return layout_.bidPrice2; }
	inline Double askPrice2() const { return layout_.askPrice2; }
	inline UShort bidSize2() const { return layout_.bidSize2; }
	inline UShort askSize2() const { return layout_.askSize2; }
	inline UShort bidOrders2() const { return layout_.bidOrders2; }
	inline UShort askOrders2() const { return layout_.askOrders2; }
	inline Double bidPrice3() const { return layout_.bidPrice3; }
	inline Double askPrice3() const { return layout_.askPrice3; }
	inline UShort bidSize3() const { return layout_.bidSize3; }
	inline UShort askSize3() const { return layout_.askSize3; }
	inline UShort bidOrders3() const { return layout_.bidOrders3; }
	inline UShort askOrders3() const { return layout_.askOrders3; }
	inline Double bidPrice4() const { return layout_.bidPrice4; }
	inline Double askPrice4() const { return layout_.askPrice4; }
	inline UShort bidSize4() const { return layout_.bidSize4; }
	inline UShort askSize4() const { return layout_.askSize4; }
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
		UShort bsz;
		UShort asz;
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
	inline UShort bsz() const { return layout_.bsz; }
	inline UShort asz() const { return layout_.asz; }
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
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<IndexQuote::Layout*>(ptr);
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
		Float atmVol;
		Float atmCen;
		Float minAtmVol;
		Float maxAtmVol;
		Float eMove;
		Float uPrcOffset;
		Float uPrcOffsetEMA;
		Float sdiv;
		Float sdivEMA;
		Float atmMove;
		Float atmCenMove;
		Float atmVega;
		Float slope;
		Float varSwapFV;
		GridType gridType;
		Float minXAxis;
		Float maxXAxis;
		Float xAxisScale;
		Float xAxisOffset;
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
		Float fitAvgErr;
		Float fitAvgAbsErr;
		Float fitMaxPrcErr;
		Float fitErrXX;
		CallPut fitErrCP;
		Float fitErrBid;
		Float fitErrAsk;
		Float fitErrPrc;
		Float fitErrVol;
		ExpiryKey sEKey;
		LiveSurfaceType sType;
		DateTime sTimestamp;
		Int counter;
		Int skewCounter;
		Int sdivCounter;
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
	inline Float atmVol() const { return layout_.atmVol; }
	inline Float atmCen() const { return layout_.atmCen; }
	inline Float minAtmVol() const { return layout_.minAtmVol; }
	inline Float maxAtmVol() const { return layout_.maxAtmVol; }
	inline Float eMove() const { return layout_.eMove; }
	inline Float uPrcOffset() const { return layout_.uPrcOffset; }
	inline Float uPrcOffsetEMA() const { return layout_.uPrcOffsetEMA; }
	inline Float sdiv() const { return layout_.sdiv; }
	inline Float sdivEMA() const { return layout_.sdivEMA; }
	inline Float atmMove() const { return layout_.atmMove; }
	inline Float atmCenMove() const { return layout_.atmCenMove; }
	inline Float atmVega() const { return layout_.atmVega; }
	inline Float slope() const { return layout_.slope; }
	inline Float varSwapFV() const { return layout_.varSwapFV; }
	inline GridType gridType() const { return layout_.gridType; }
	inline Float minXAxis() const { return layout_.minXAxis; }
	inline Float maxXAxis() const { return layout_.maxXAxis; }
	inline Float xAxisScale() const { return layout_.xAxisScale; }
	inline Float xAxisOffset() const { return layout_.xAxisOffset; }
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
	inline Float fitAvgErr() const { return layout_.fitAvgErr; }
	inline Float fitAvgAbsErr() const { return layout_.fitAvgAbsErr; }
	inline Float fitMaxPrcErr() const { return layout_.fitMaxPrcErr; }
	inline Float fitErrXX() const { return layout_.fitErrXX; }
	inline CallPut fitErrCP() const { return layout_.fitErrCP; }
	inline Float fitErrBid() const { return layout_.fitErrBid; }
	inline Float fitErrAsk() const { return layout_.fitErrAsk; }
	inline Float fitErrPrc() const { return layout_.fitErrPrc; }
	inline Float fitErrVol() const { return layout_.fitErrVol; }
	inline const ExpiryKey& sEKey() const { return layout_.sEKey; }
	inline LiveSurfaceType sType() const { return layout_.sType; }
	inline DateTime sTimestamp() const { return layout_.sTimestamp; }
	inline Int counter() const { return layout_.counter; }
	inline Int skewCounter() const { return layout_.skewCounter; }
	inline Int sdivCounter() const { return layout_.sdivCounter; }
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
		UShort bidSize;
		UShort askSize;
		UShort cumBidSize;
		UShort cumAskSize;
		OptExch bidExch;
		OptExch askExch;
		UInt bidMask;
		UInt askMask;
		OpraMktType bidMktType;
		OpraMktType askMktType;
		Float bidPrice2;
		Float askPrice2;
		UShort cumBidSize2;
		UShort cumAskSize2;
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
	inline UShort bidSize() const { return layout_.bidSize; }
	inline UShort askSize() const { return layout_.askSize; }
	inline UShort cumBidSize() const { return layout_.cumBidSize; }
	inline UShort cumAskSize() const { return layout_.cumAskSize; }
	inline OptExch bidExch() const { return layout_.bidExch; }
	inline OptExch askExch() const { return layout_.askExch; }
	inline UInt bidMask() const { return layout_.bidMask; }
	inline UInt askMask() const { return layout_.askMask; }
	inline OpraMktType bidMktType() const { return layout_.bidMktType; }
	inline OpraMktType askMktType() const { return layout_.askMktType; }
	inline Float bidPrice2() const { return layout_.bidPrice2; }
	inline Float askPrice2() const { return layout_.askPrice2; }
	inline UShort cumBidSize2() const { return layout_.cumBidSize2; }
	inline UShort cumAskSize2() const { return layout_.cumAskSize2; }
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
		UShort ebsz;
		UShort easz;
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
	inline UShort ebsz() const { return layout_.ebsz; }
	inline UShort easz() const { return layout_.easz; }
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

 class SpreadBookQuote
{
public:
	class Key
	{
		TickerKey skey_;
		
	public:
		inline const TickerKey& skey() const { return skey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.skey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.skey_ == b.skey_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		UpdateType updateType;
		UInt bidMask1;
		UInt askMask1;
		Float bidPrice1;
		Float askPrice1;
		UShort bidSize1;
		UShort askSize1;
		Float bidPrice2;
		Float askPrice2;
		UShort bidSize2;
		UShort askSize2;
		DateTime bidTime;
		DateTime askTime;
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
	inline UInt bidMask1() const { return layout_.bidMask1; }
	inline UInt askMask1() const { return layout_.askMask1; }
	inline Float bidPrice1() const { return layout_.bidPrice1; }
	inline Float askPrice1() const { return layout_.askPrice1; }
	inline UShort bidSize1() const { return layout_.bidSize1; }
	inline UShort askSize1() const { return layout_.askSize1; }
	inline Float bidPrice2() const { return layout_.bidPrice2; }
	inline Float askPrice2() const { return layout_.askPrice2; }
	inline UShort bidSize2() const { return layout_.bidSize2; }
	inline UShort askSize2() const { return layout_.askSize2; }
	inline DateTime bidTime() const { return layout_.bidTime; }
	inline DateTime askTime() const { return layout_.askTime; }
	inline Long srcTimestamp() const { return layout_.srcTimestamp; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<SpreadBookQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

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
		UShort bidSize1;
		StkExch bidExch1;
		UInt bidMask1;
		Float askPrice1;
		UShort askSize1;
		StkExch askExch1;
		UInt askMask1;
		Float bidPrice2;
		UShort bidSize2;
		StkExch bidExch2;
		UInt bidMask2;
		Float askPrice2;
		UShort askSize2;
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
	inline UShort bidSize1() const { return layout_.bidSize1; }
	inline StkExch bidExch1() const { return layout_.bidExch1; }
	inline UInt bidMask1() const { return layout_.bidMask1; }
	inline Float askPrice1() const { return layout_.askPrice1; }
	inline UShort askSize1() const { return layout_.askSize1; }
	inline StkExch askExch1() const { return layout_.askExch1; }
	inline UInt askMask1() const { return layout_.askMask1; }
	inline Float bidPrice2() const { return layout_.bidPrice2; }
	inline UShort bidSize2() const { return layout_.bidSize2; }
	inline StkExch bidExch2() const { return layout_.bidExch2; }
	inline UInt bidMask2() const { return layout_.bidMask2; }
	inline Float askPrice2() const { return layout_.askPrice2; }
	inline UShort askSize2() const { return layout_.askSize2; }
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

 class StockExchImbalance
{
public:
	class Key
	{
		TickerKey ticker_;
		StkExch exch_;
		
	public:
		inline const TickerKey& ticker() const { return ticker_; }
		inline StkExch exch() const { return exch_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = TickerKey()(k.ticker_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.exch_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_
				&& a.exch_ == b.exch_;
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
		DateTime auctionTime;
		AuctionReason auctionType;
		ImbalanceSide imbalanceSide;
		Float continuousBookClrPx;
		Float closingOnlyClrPx;
		Float ssrFillingPx;
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
	inline DateTime auctionTime() const { return layout_.auctionTime; }
	inline AuctionReason auctionType() const { return layout_.auctionType; }
	inline ImbalanceSide imbalanceSide() const { return layout_.imbalanceSide; }
	inline Float continuousBookClrPx() const { return layout_.continuousBookClrPx; }
	inline Float closingOnlyClrPx() const { return layout_.closingOnlyClrPx; }
	inline Float ssrFillingPx() const { return layout_.ssrFillingPx; }
	inline Long netTimestamp() const { return layout_.netTimestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<StockExchImbalance::Layout*>(ptr);
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
		Double iniPrice;
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
	
	inline Double iniPrice() const { return layout_.iniPrice; }
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
		UShort ebsz;
		UShort easz;
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
	inline UShort ebsz() const { return layout_.ebsz; }
	inline UShort easz() const { return layout_.easz; }
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



}	// namespace DataFeed

}	// namespace SpiderRock

#pragma pack()
