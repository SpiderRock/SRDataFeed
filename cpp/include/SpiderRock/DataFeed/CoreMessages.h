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
		FutureKey fkey_;
		
	public:
		inline const FutureKey& fkey() const { return fkey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = FutureKey()(k.fkey_);

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
		Int bidPrintQuan;
		Int askPrintQuan;
		Int timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
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
	inline Int bidPrintQuan() const { return layout_.bidPrintQuan; }
	inline Int askPrintQuan() const { return layout_.askPrintQuan; }
	inline Int timestamp() const { return layout_.timestamp; }
	
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
		FutureKey fkey_;
		
	public:
		inline const FutureKey& fkey() const { return fkey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = FutureKey()(k.fkey_);

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
		FutExch futexch;
		Double prtPrice;
		Int prtQuan;
		Int prtSize;
		Byte prtType;
		UShort prtOrders;
		Int prtVolume;
		UShort bidCount;
		UShort askCount;
		Int bidVolume;
		Int askVolume;
		Double iniPrice;
		Double mrkPrice;
		Double opnPrice;
		Double clsPrice;
		Double minPrice;
		Double maxPrice;
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
	
	inline FutExch futexch() const { return layout_.futexch; }
	inline Double prtPrice() const { return layout_.prtPrice; }
	inline Int prtQuan() const { return layout_.prtQuan; }
	inline Int prtSize() const { return layout_.prtSize; }
	inline Byte prtType() const { return layout_.prtType; }
	inline UShort prtOrders() const { return layout_.prtOrders; }
	inline Int prtVolume() const { return layout_.prtVolume; }
	inline UShort bidCount() const { return layout_.bidCount; }
	inline UShort askCount() const { return layout_.askCount; }
	inline Int bidVolume() const { return layout_.bidVolume; }
	inline Int askVolume() const { return layout_.askVolume; }
	inline Double iniPrice() const { return layout_.iniPrice; }
	inline Double mrkPrice() const { return layout_.mrkPrice; }
	inline Double opnPrice() const { return layout_.opnPrice; }
	inline Double clsPrice() const { return layout_.clsPrice; }
	inline Double minPrice() const { return layout_.minPrice; }
	inline Double maxPrice() const { return layout_.maxPrice; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<FuturePrint::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class FutureSettlementMark
{
public:
	class Key
	{
		FutureKey fkey_;
		YesNo early_;
		YesNo priorPeriod_;
		
	public:
		inline const FutureKey& fkey() const { return fkey_; }
		inline YesNo early() const { return early_; }
		inline YesNo priorPeriod() const { return priorPeriod_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = FutureKey()(k.fkey_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.early_));
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.priorPeriod_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.fkey_ == b.fkey_
				&& a.early_ == b.early_
				&& a.priorPeriod_ == b.priorPeriod_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		DateKey settleDate;
		Double settlePx;
		Double lowLmtPx;
		Double highLmtPx;
		Int openInt;
		Int volume;
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
	
	inline DateKey settleDate() const { return layout_.settleDate; }
	inline Double settlePx() const { return layout_.settlePx; }
	inline Double lowLmtPx() const { return layout_.lowLmtPx; }
	inline Double highLmtPx() const { return layout_.highLmtPx; }
	inline Int openInt() const { return layout_.openInt; }
	inline Int volume() const { return layout_.volume; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<FutureSettlementMark::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class LiveSurfaceAtm
{
public:
	class Key
	{
		FutureKey fkey_;
		LiveSurfaceType surfaceType_;
		
	public:
		inline const FutureKey& fkey() const { return fkey_; }
		inline LiveSurfaceType surfaceType() const { return surfaceType_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = FutureKey()(k.fkey_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.surfaceType_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.fkey_ == b.fkey_
				&& a.surfaceType_ == b.surfaceType_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		StockKey ticker;
		Float uBid;
		Float uAsk;
		Float years;
		Float rate;
		Float sdiv;
		Float ddiv;
		Byte exType;
		Float axisVol;
		Float cAtm;
		Float pAtm;
		Float adjDI;
		Float adjD8;
		Float adjD7;
		Float adjD6;
		Float adjD5;
		Float adjD4;
		Float adjD3;
		Float adjD2;
		Float adjD1;
		Float adjU1;
		Float adjU2;
		Float adjU3;
		Float adjU4;
		Float adjU5;
		Float adjU6;
		Float adjU7;
		Float adjU8;
		Float adjUI;
		Float slope;
		Float cmult;
		Float pwidth;
		Float vwidth;
		Float sdivEMA;
		Float sdivLoEMA;
		Float sdivHiEMA;
		Float atmMAC;
		Float cprMAC;
		Float cAtmMove;
		Float pAtmMove;
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
		CallOrPut fitErrCP;
		Float fitErrBid;
		Float fitErrAsk;
		Float fitErrPrc;
		Float fitErrVol;
		FitType fitType;
		FutureKey sFKey;
		LiveSurfaceType sType;
		DateTime sTimestamp;
		Int counter;
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
	
	inline const StockKey& ticker() const { return layout_.ticker; }
	inline Float uBid() const { return layout_.uBid; }
	inline Float uAsk() const { return layout_.uAsk; }
	inline Float years() const { return layout_.years; }
	inline Float rate() const { return layout_.rate; }
	inline Float sdiv() const { return layout_.sdiv; }
	inline Float ddiv() const { return layout_.ddiv; }
	inline Byte exType() const { return layout_.exType; }
	inline Float axisVol() const { return layout_.axisVol; }
	inline Float cAtm() const { return layout_.cAtm; }
	inline Float pAtm() const { return layout_.pAtm; }
	inline Float adjDI() const { return layout_.adjDI; }
	inline Float adjD8() const { return layout_.adjD8; }
	inline Float adjD7() const { return layout_.adjD7; }
	inline Float adjD6() const { return layout_.adjD6; }
	inline Float adjD5() const { return layout_.adjD5; }
	inline Float adjD4() const { return layout_.adjD4; }
	inline Float adjD3() const { return layout_.adjD3; }
	inline Float adjD2() const { return layout_.adjD2; }
	inline Float adjD1() const { return layout_.adjD1; }
	inline Float adjU1() const { return layout_.adjU1; }
	inline Float adjU2() const { return layout_.adjU2; }
	inline Float adjU3() const { return layout_.adjU3; }
	inline Float adjU4() const { return layout_.adjU4; }
	inline Float adjU5() const { return layout_.adjU5; }
	inline Float adjU6() const { return layout_.adjU6; }
	inline Float adjU7() const { return layout_.adjU7; }
	inline Float adjU8() const { return layout_.adjU8; }
	inline Float adjUI() const { return layout_.adjUI; }
	inline Float slope() const { return layout_.slope; }
	inline Float cmult() const { return layout_.cmult; }
	inline Float pwidth() const { return layout_.pwidth; }
	inline Float vwidth() const { return layout_.vwidth; }
	inline Float sdivEMA() const { return layout_.sdivEMA; }
	inline Float sdivLoEMA() const { return layout_.sdivLoEMA; }
	inline Float sdivHiEMA() const { return layout_.sdivHiEMA; }
	inline Float atmMAC() const { return layout_.atmMAC; }
	inline Float cprMAC() const { return layout_.cprMAC; }
	inline Float cAtmMove() const { return layout_.cAtmMove; }
	inline Float pAtmMove() const { return layout_.pAtmMove; }
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
	inline CallOrPut fitErrCP() const { return layout_.fitErrCP; }
	inline Float fitErrBid() const { return layout_.fitErrBid; }
	inline Float fitErrAsk() const { return layout_.fitErrAsk; }
	inline Float fitErrPrc() const { return layout_.fitErrPrc; }
	inline Float fitErrVol() const { return layout_.fitErrVol; }
	inline FitType fitType() const { return layout_.fitType; }
	inline const FutureKey& sFKey() const { return layout_.sFKey; }
	inline LiveSurfaceType sType() const { return layout_.sType; }
	inline DateTime sTimestamp() const { return layout_.sTimestamp; }
	inline Int counter() const { return layout_.counter; }
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
		Float uBid;
		Float uAsk;
		Float bidPx;
		Float askPx;
		Float bidIV;
		Float askIV;
		Float srPrc;
		Float srVol;
		MarkSource srSrc;
		Float de;
		Float ga;
		Float th;
		Float ve;
		Float rh;
		Float ph;
		Float sdiv;
		Float ddiv;
		Float rate;
		Byte error;
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
	
	inline Float uBid() const { return layout_.uBid; }
	inline Float uAsk() const { return layout_.uAsk; }
	inline Float bidPx() const { return layout_.bidPx; }
	inline Float askPx() const { return layout_.askPx; }
	inline Float bidIV() const { return layout_.bidIV; }
	inline Float askIV() const { return layout_.askIV; }
	inline Float srPrc() const { return layout_.srPrc; }
	inline Float srVol() const { return layout_.srVol; }
	inline MarkSource srSrc() const { return layout_.srSrc; }
	inline Float de() const { return layout_.de; }
	inline Float ga() const { return layout_.ga; }
	inline Float th() const { return layout_.th; }
	inline Float ve() const { return layout_.ve; }
	inline Float rh() const { return layout_.rh; }
	inline Float ph() const { return layout_.ph; }
	inline Float sdiv() const { return layout_.sdiv; }
	inline Float ddiv() const { return layout_.ddiv; }
	inline Float rate() const { return layout_.rate; }
	inline Byte error() const { return layout_.error; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionCloseMark::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionCloseQuote
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
		Float bidPrice;
		Float askPrice;
		UShort bidSize;
		UShort askSize;
		OptExch bidExch;
		OptExch askExch;
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
	
	inline Float bidPrice() const { return layout_.bidPrice; }
	inline Float askPrice() const { return layout_.askPrice; }
	inline UShort bidSize() const { return layout_.bidSize; }
	inline UShort askSize() const { return layout_.askSize; }
	inline OptExch bidExch() const { return layout_.bidExch; }
	inline OptExch askExch() const { return layout_.askExch; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionCloseQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionImpliedQuote
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
		StockKey ticker;
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
		String<16> calcErr;
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
	
	inline const StockKey& ticker() const { return layout_.ticker; }
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
	inline const String<16>& calcErr() const { return layout_.calcErr; }
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
		Float bidPrice2;
		Float askPrice2;
		UShort cumBidSize2;
		UShort cumAskSize2;
		Int bidTime;
		Int askTime;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
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
	inline Float bidPrice2() const { return layout_.bidPrice2; }
	inline Float askPrice2() const { return layout_.askPrice2; }
	inline UShort cumBidSize2() const { return layout_.cumBidSize2; }
	inline UShort cumAskSize2() const { return layout_.cumAskSize2; }
	inline Int bidTime() const { return layout_.bidTime; }
	inline Int askTime() const { return layout_.askTime; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionNbboQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionOpenMark
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
		Float uBid;
		Float uAsk;
		Float bidPx;
		Float askPx;
		Float bidIV;
		Float askIV;
		Float srPrc;
		Float srVol;
		MarkSource srSrc;
		Float de;
		Float ga;
		Float th;
		Float ve;
		Float rh;
		Float ph;
		Float sdiv;
		Float ddiv;
		Float rate;
		Byte error;
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
	
	inline Float uBid() const { return layout_.uBid; }
	inline Float uAsk() const { return layout_.uAsk; }
	inline Float bidPx() const { return layout_.bidPx; }
	inline Float askPx() const { return layout_.askPx; }
	inline Float bidIV() const { return layout_.bidIV; }
	inline Float askIV() const { return layout_.askIV; }
	inline Float srPrc() const { return layout_.srPrc; }
	inline Float srVol() const { return layout_.srVol; }
	inline MarkSource srSrc() const { return layout_.srSrc; }
	inline Float de() const { return layout_.de; }
	inline Float ga() const { return layout_.ga; }
	inline Float th() const { return layout_.th; }
	inline Float ve() const { return layout_.ve; }
	inline Float rh() const { return layout_.rh; }
	inline Float ph() const { return layout_.ph; }
	inline Float sdiv() const { return layout_.sdiv; }
	inline Float ddiv() const { return layout_.ddiv; }
	inline Float rate() const { return layout_.rate; }
	inline Byte error() const { return layout_.error; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionOpenMark::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionPrint
{
public:
	class Key
	{
		OptionKey okey_;
		OptExch exch_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }
		inline OptExch exch() const { return exch_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.exch_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_
				&& a.exch_ == b.exch_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		Float prtPrice;
		Int prtSize;
		Byte prtType;
		UShort prtOrders;
		Int prtVolume;
		Int cxlVolume;
		Float lastPrice;
		Int lastSize;
		DateTime lastTime;
		UShort bidCount;
		UShort askCount;
		Int bidVolume;
		Int askVolume;
		Float ebid;
		Float eask;
		UShort ebsz;
		UShort easz;
		Float eage;
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
	
	inline Float prtPrice() const { return layout_.prtPrice; }
	inline Int prtSize() const { return layout_.prtSize; }
	inline Byte prtType() const { return layout_.prtType; }
	inline UShort prtOrders() const { return layout_.prtOrders; }
	inline Int prtVolume() const { return layout_.prtVolume; }
	inline Int cxlVolume() const { return layout_.cxlVolume; }
	inline Float lastPrice() const { return layout_.lastPrice; }
	inline Int lastSize() const { return layout_.lastSize; }
	inline DateTime lastTime() const { return layout_.lastTime; }
	inline UShort bidCount() const { return layout_.bidCount; }
	inline UShort askCount() const { return layout_.askCount; }
	inline Int bidVolume() const { return layout_.bidVolume; }
	inline Int askVolume() const { return layout_.askVolume; }
	inline Float ebid() const { return layout_.ebid; }
	inline Float eask() const { return layout_.eask; }
	inline UShort ebsz() const { return layout_.ebsz; }
	inline UShort easz() const { return layout_.easz; }
	inline Float eage() const { return layout_.eage; }
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
		StockKey ticker;
		Float uprc;
		Float years;
		Float svol;
		Float sprc;
		Float de;
		Float obid;
		Float oask;
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
		String<16> calcErr;
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
	
	inline const StockKey& ticker() const { return layout_.ticker; }
	inline Float uprc() const { return layout_.uprc; }
	inline Float years() const { return layout_.years; }
	inline Float svol() const { return layout_.svol; }
	inline Float sprc() const { return layout_.sprc; }
	inline Float de() const { return layout_.de; }
	inline Float obid() const { return layout_.obid; }
	inline Float oask() const { return layout_.oask; }
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
	inline const String<16>& calcErr() const { return layout_.calcErr; }
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

 class OptionSettlementMark
{
public:
	class Key
	{
		OptionKey okey_;
		YesNo early_;
		YesNo priorPeriod_;
		
	public:
		inline const OptionKey& okey() const { return okey_; }
		inline YesNo early() const { return early_; }
		inline YesNo priorPeriod() const { return priorPeriod_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = OptionKey()(k.okey_);
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.early_));
			hash_code = (hash_code * 397) ^ std::hash<Byte>()(static_cast<Byte>(k.priorPeriod_));

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_
				&& a.early_ == b.early_
				&& a.priorPeriod_ == b.priorPeriod_;
		}
	};
	

private:
	struct Layout
	{
		Key pkey;
		DateKey settleDate;
		Float settlePx;
		Float settleDe;
		Float lowLmtPx;
		Float highLmtPx;
		Int openInt;
		Int volume;
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
	
	inline DateKey settleDate() const { return layout_.settleDate; }
	inline Float settlePx() const { return layout_.settlePx; }
	inline Float settleDe() const { return layout_.settleDe; }
	inline Float lowLmtPx() const { return layout_.lowLmtPx; }
	inline Float highLmtPx() const { return layout_.highLmtPx; }
	inline Int openInt() const { return layout_.openInt; }
	inline Int volume() const { return layout_.volume; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionSettlementMark::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class StockBookQuote
{
public:
	class Key
	{
		StockKey ticker_;
		
	public:
		inline const StockKey& ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = StockKey()(k.ticker_);

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
		Byte expCnt;
		Float expWidth;
		Int bidPrintQuan;
		Int askPrintQuan;
		Int timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
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
	inline Byte expCnt() const { return layout_.expCnt; }
	inline Float expWidth() const { return layout_.expWidth; }
	inline Int bidPrintQuan() const { return layout_.bidPrintQuan; }
	inline Int askPrintQuan() const { return layout_.askPrintQuan; }
	inline Int timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<StockBookQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class StockCloseMark
{
public:
	class Key
	{
		StockKey ticker_;
		
	public:
		inline const StockKey& ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = StockKey()(k.ticker_);

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
		Float bidPrc;
		Float askPrc;
		Float closePrc;
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
	
	inline Float bidPrc() const { return layout_.bidPrc; }
	inline Float askPrc() const { return layout_.askPrc; }
	inline Float closePrc() const { return layout_.closePrc; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<StockCloseMark::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class StockCloseQuote
{
public:
	class Key
	{
		StockKey ticker_;
		
	public:
		inline const StockKey& ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = StockKey()(k.ticker_);

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
		Float bidPrice;
		Float askPrice;
		Int bidSize;
		Int askSize;
		StkExch bidExch;
		StkExch askExch;
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
	
	inline Float bidPrice() const { return layout_.bidPrice; }
	inline Float askPrice() const { return layout_.askPrice; }
	inline Int bidSize() const { return layout_.bidSize; }
	inline Int askSize() const { return layout_.askSize; }
	inline StkExch bidExch() const { return layout_.bidExch; }
	inline StkExch askExch() const { return layout_.askExch; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<StockCloseQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class StockOpenMark
{
public:
	class Key
	{
		StockKey ticker_;
		
	public:
		inline const StockKey& ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = StockKey()(k.ticker_);

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
		Float bidPrc;
		Float askPrc;
		Float closePrc;
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
	
	inline Float bidPrc() const { return layout_.bidPrc; }
	inline Float askPrc() const { return layout_.askPrc; }
	inline Float closePrc() const { return layout_.closePrc; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<StockOpenMark::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class StockPrint
{
public:
	class Key
	{
		StockKey ticker_;
		
	public:
		inline const StockKey& ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = StockKey()(k.ticker_);

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
		MarketStatus marketStatus;
		StkExch prtExch;
		Int prtSize;
		Int prtQuan;
		Float prtPrice;
		Int prtVolume;
		StockTick lastTick;
		Float iniPrice;
		Float mrkPrice;
		Float opnPrice;
		Float clsPrice;
		Float minPrice;
		Float maxPrice;
		Int bCnt;
		Int sCnt;
		Int shBot;
		Int shSld;
		Float shMny;
		UShort expCnt;
		Float expV1;
		Float expV2;
		Float expV3;
		Float expV4;
		Float expV5;
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
	
	inline MarketStatus marketStatus() const { return layout_.marketStatus; }
	inline StkExch prtExch() const { return layout_.prtExch; }
	inline Int prtSize() const { return layout_.prtSize; }
	inline Int prtQuan() const { return layout_.prtQuan; }
	inline Float prtPrice() const { return layout_.prtPrice; }
	inline Int prtVolume() const { return layout_.prtVolume; }
	inline StockTick lastTick() const { return layout_.lastTick; }
	inline Float iniPrice() const { return layout_.iniPrice; }
	inline Float mrkPrice() const { return layout_.mrkPrice; }
	inline Float opnPrice() const { return layout_.opnPrice; }
	inline Float clsPrice() const { return layout_.clsPrice; }
	inline Float minPrice() const { return layout_.minPrice; }
	inline Float maxPrice() const { return layout_.maxPrice; }
	inline Int bCnt() const { return layout_.bCnt; }
	inline Int sCnt() const { return layout_.sCnt; }
	inline Int shBot() const { return layout_.shBot; }
	inline Int shSld() const { return layout_.shSld; }
	inline Float shMny() const { return layout_.shMny; }
	inline UShort expCnt() const { return layout_.expCnt; }
	inline Float expV1() const { return layout_.expV1; }
	inline Float expV2() const { return layout_.expV2; }
	inline Float expV3() const { return layout_.expV3; }
	inline Float expV4() const { return layout_.expV4; }
	inline Float expV5() const { return layout_.expV5; }
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
