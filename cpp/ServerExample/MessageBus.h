// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#pragma once

#include "stdafx.h"
#include "MessageBusTypes.h"

namespace SpiderRock { 

namespace DataFeed {

enum class BuySell : SREnum 
{
	None=0,
	Buy=1,
	Sell=2
};

 enum class CallOrPut : SREnum 
{
	Call=0,
	Put=1
};

 enum class FitType : SREnum 
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

 enum class FutExch : SREnum 
{
	None=0,
	CFE=1,
	CME=2,
	CBT=3,
	COMEX=4,
	NYMEX=5,
	ICE=6
};

 enum class LiveSurfaceType : SREnum 
{
	None=0,
	Live=1,
	Hist=2,
	PriorDay=3
};

 enum class MarkSource : SREnum 
{
	None=0,
	NbboMid=1,
	SRVol=2,
	LoBound=3,
	HiBound=4,
	SRPricer=5
};

 enum class MarketStatus : SREnum 
{
	None=0,
	PreOpen=1,
	Open=2,
	AfterHours=3,
	Halted=4
};

 enum class OptExch : SREnum 
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

 enum class QuoteType : SREnum 
{
	New=0,
	Modify=1,
	Delete=2,
	Print=3,
	Internal=4
};

 enum class SettleTime : SREnum 
{
	None=0,
	PM=1,
	AM=2
};

 enum class SprdSource : SREnum 
{
	None=0,
	Internal=1,
	ISE=2,
	CBOE=3,
	PHLX=4
};

 enum class StkExch : SREnum 
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

 enum class StockTick : SREnum 
{
	None=0,
	Up=1,
	Down=2
};

 enum class YesNo : SREnum 
{
	None=0,
	Yes=1,
	No=2
};


class CacheComplete
{
public:

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		SRInt requestID;
		SRFixedLengthString<256> result;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;
	
public:
	static const MessageType Type = 504;
	
	inline Header& header() { return header_; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRInt requestID() const { return layout_.requestID; }
	inline const SRFixedLengthString<256>& result() const { return layout_.result; }
	inline void requestID(SRInt value) { layout_.requestID = value; }
	inline void result(const SRFixedLengthString<256>& value) { layout_.result = value; }
	
	
	inline uint16_t Encode(uint8_t* buf) 
	{
		uint8_t* start = buf;
		buf += sizeof(Header);

		*reinterpret_cast<CacheComplete::Layout*>(buf) = layout_;
		buf += sizeof(layout_);
		


		header_.msg_len = (uint16_t)(buf - start);
		header_.key_len = 0;
		header_.msg_type = Type;
		
		*reinterpret_cast<Header*>(start) = header_;
		
		return header_.msg_len;
	}

	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<CacheComplete::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}


};

 class GetCache
{
public:
	MBUS_STRUCT_PACK_ENABLE
	class MsgType
	{
		SRUshort msgtype_;
		
	public:
		inline SRUshort msgtype() const { return msgtype_; }
		inline void msgtype(SRUshort value) { msgtype_ = value; }
	};
	MBUS_STRUCT_PACK_DISABLE

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		SRInt requestID;
		SRFixedLengthString<32> filter;
		SRInt limit;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	vector<MsgType> msgtype_;
	int64_t time_received_;
	
public:
	static const MessageType Type = 503;
	
	inline Header& header() { return header_; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRInt requestID() const { return layout_.requestID; }
	inline const SRFixedLengthString<32>& filter() const { return layout_.filter; }
	inline SRInt limit() const { return layout_.limit; }
	inline void requestID(SRInt value) { layout_.requestID = value; }
	inline void filter(const SRFixedLengthString<32>& value) { layout_.filter = value; }
	inline void limit(SRInt value) { layout_.limit = value; }
	inline void msgtype(const vector<MsgType> value) { msgtype_.assign(value.begin(), value.end()); }
	
	inline uint16_t Encode(uint8_t* buf) 
	{
		uint8_t* start = buf;
		buf += sizeof(Header);

		*reinterpret_cast<GetCache::Layout*>(buf) = layout_;
		buf += sizeof(layout_);
		
		// MsgType Repeat Section
		*reinterpret_cast<RepeatLength*>(buf) = (RepeatLength)msgtype_.size();
		buf += sizeof(RepeatLength);

		for ( MsgType i : msgtype_ )
		{
			*reinterpret_cast<MsgType*>(buf) = i;
			buf += sizeof(i);
		}


		header_.msg_len = (uint16_t)(buf - start);
		header_.key_len = 0;
		header_.msg_type = Type;
		
		*reinterpret_cast<Header*>(start) = header_;
		
		return header_.msg_len;
	}

	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<GetCache::Layout*>(ptr);
		ptr += sizeof(layout_);
		
		// MsgType Repeat Section
		auto msgtype_count = *reinterpret_cast<RepeatLength*>(ptr);
		ptr += sizeof(msgtype_count);

		for (int i = 0; i < msgtype_count; i++)
		{
			msgtype_.push_back(*reinterpret_cast<MsgType*>(ptr));
			ptr += sizeof(MsgType);
		}

	}


};


class FutureBookQuote
{
public:
	class Key
	{
		SRFutureKey fkey_;
		
	public:
		inline SRFutureKey fkey() const { return fkey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SRFutureKey()(k.fkey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.fkey_ == b.fkey_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		FutExch futexch;
		SRDouble bidPrice1;
		SRDouble askPrice1;
		SRUshort bidSize1;
		SRUshort askSize1;
		SRDouble bidPrice2;
		SRDouble askPrice2;
		SRUshort bidSize2;
		SRUshort askSize2;
		SRDouble bidPrice3;
		SRDouble askPrice3;
		SRUshort bidSize3;
		SRUshort askSize3;
		SRDouble bidPrice4;
		SRDouble askPrice4;
		SRUshort bidSize4;
		SRUshort askSize4;
		SRInt bidPrintQuan;
		SRInt askPrintQuan;
		SRFloat displayFactor;
		SettleTime session;
		SRInt timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 111;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline FutExch futexch() const { return layout_.futexch; }
	inline SRDouble bidPrice1() const { return layout_.bidPrice1; }
	inline SRDouble askPrice1() const { return layout_.askPrice1; }
	inline SRUshort bidSize1() const { return layout_.bidSize1; }
	inline SRUshort askSize1() const { return layout_.askSize1; }
	inline SRDouble bidPrice2() const { return layout_.bidPrice2; }
	inline SRDouble askPrice2() const { return layout_.askPrice2; }
	inline SRUshort bidSize2() const { return layout_.bidSize2; }
	inline SRUshort askSize2() const { return layout_.askSize2; }
	inline SRDouble bidPrice3() const { return layout_.bidPrice3; }
	inline SRDouble askPrice3() const { return layout_.askPrice3; }
	inline SRUshort bidSize3() const { return layout_.bidSize3; }
	inline SRUshort askSize3() const { return layout_.askSize3; }
	inline SRDouble bidPrice4() const { return layout_.bidPrice4; }
	inline SRDouble askPrice4() const { return layout_.askPrice4; }
	inline SRUshort bidSize4() const { return layout_.bidSize4; }
	inline SRUshort askSize4() const { return layout_.askSize4; }
	inline SRInt bidPrintQuan() const { return layout_.bidPrintQuan; }
	inline SRInt askPrintQuan() const { return layout_.askPrintQuan; }
	inline SRFloat displayFactor() const { return layout_.displayFactor; }
	inline SettleTime session() const { return layout_.session; }
	inline SRInt timestamp() const { return layout_.timestamp; }
	
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
		SRFutureKey fkey_;
		
	public:
		inline SRFutureKey fkey() const { return fkey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SRFutureKey()(k.fkey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.fkey_ == b.fkey_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		FutExch futexch;
		SRDouble prtPrice;
		SRInt prtQuan;
		SRInt prtSize;
		SRByte prtType;
		SRInt prtVolume;
		SRUshort bidCount;
		SRUshort askCount;
		SRInt bidVolume;
		SRInt askVolume;
		SRDouble iniPrice;
		SRDouble mrkPrice;
		SRDouble opnPrice;
		SRDouble clsPrice;
		SRDouble minPrice;
		SRDouble maxPrice;
		SettleTime session;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 115;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline FutExch futexch() const { return layout_.futexch; }
	inline SRDouble prtPrice() const { return layout_.prtPrice; }
	inline SRInt prtQuan() const { return layout_.prtQuan; }
	inline SRInt prtSize() const { return layout_.prtSize; }
	inline SRByte prtType() const { return layout_.prtType; }
	inline SRInt prtVolume() const { return layout_.prtVolume; }
	inline SRUshort bidCount() const { return layout_.bidCount; }
	inline SRUshort askCount() const { return layout_.askCount; }
	inline SRInt bidVolume() const { return layout_.bidVolume; }
	inline SRInt askVolume() const { return layout_.askVolume; }
	inline SRDouble iniPrice() const { return layout_.iniPrice; }
	inline SRDouble mrkPrice() const { return layout_.mrkPrice; }
	inline SRDouble opnPrice() const { return layout_.opnPrice; }
	inline SRDouble clsPrice() const { return layout_.clsPrice; }
	inline SRDouble minPrice() const { return layout_.minPrice; }
	inline SRDouble maxPrice() const { return layout_.maxPrice; }
	inline SettleTime session() const { return layout_.session; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
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
		SRFutureKey fkey_;
		YesNo early_;
		YesNo priorPeriod_;
		
	public:
		inline SRFutureKey fkey() const { return fkey_; }
		inline YesNo early() const { return early_; }
		inline YesNo priorPeriod() const { return priorPeriod_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SRFutureKey()(k.fkey_);
			hash_code = (hash_code * 397) ^ hash<YesNo>()(k.early_);
			hash_code = (hash_code * 397) ^ hash<YesNo>()(k.priorPeriod_);

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
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRDateKey settleDate;
		SRDouble settlePx;
		SRDouble lowLmtPx;
		SRDouble highLmtPx;
		SRInt openInt;
		SRInt volume;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 375;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRDateKey settleDate() const { return layout_.settleDate; }
	inline SRDouble settlePx() const { return layout_.settlePx; }
	inline SRDouble lowLmtPx() const { return layout_.lowLmtPx; }
	inline SRDouble highLmtPx() const { return layout_.highLmtPx; }
	inline SRInt openInt() const { return layout_.openInt; }
	inline SRInt volume() const { return layout_.volume; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
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
		SRFutureKey fkey_;
		LiveSurfaceType surfaceType_;
		
	public:
		inline SRFutureKey fkey() const { return fkey_; }
		inline LiveSurfaceType surfaceType() const { return surfaceType_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SRFutureKey()(k.fkey_);
			hash_code = (hash_code * 397) ^ hash<LiveSurfaceType>()(k.surfaceType_);

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
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRStockKey ticker;
		SRFloat uBid;
		SRFloat uAsk;
		SRFloat years;
		SRFloat rate;
		SRFloat sdiv;
		SRFloat ddiv;
		SRFloat axisVol;
		SRFloat cAtm;
		SRFloat pAtm;
		SRFloat adjDI;
		SRFloat adjD8;
		SRFloat adjD7;
		SRFloat adjD6;
		SRFloat adjD5;
		SRFloat adjD4;
		SRFloat adjD3;
		SRFloat adjD2;
		SRFloat adjD1;
		SRFloat adjU1;
		SRFloat adjU2;
		SRFloat adjU3;
		SRFloat adjU4;
		SRFloat adjU5;
		SRFloat adjU6;
		SRFloat adjU7;
		SRFloat adjU8;
		SRFloat adjUI;
		SRFloat slope;
		SRFloat cmult;
		SRFloat pwidth;
		SRFloat vwidth;
		SRFloat sdivEMA;
		SRFloat sdivLoEMA;
		SRFloat sdivHiEMA;
		SRFloat atmMAC;
		SRFloat cprMAC;
		SRFloat cAtmMove;
		SRFloat pAtmMove;
		SRByte cCnt;
		SRByte pCnt;
		SRByte cBidMiss;
		SRByte cAskMiss;
		SRByte pBidMiss;
		SRByte pAskMiss;
		SRFloat fitAvgErr;
		SRFloat fitAvgAbsErr;
		SRFloat fitMaxPrcErr;
		SRFloat fitErrXX;
		CallOrPut fitErrCP;
		SRFloat fitErrBid;
		SRFloat fitErrAsk;
		SRFloat fitErrPrc;
		SRFloat fitErrVol;
		FitType fitType;
		SRFutureKey sFKey;
		LiveSurfaceType sType;
		SRDateTime sTimestamp;
		SRInt counter;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 356;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRStockKey ticker() const { return layout_.ticker; }
	inline SRFloat uBid() const { return layout_.uBid; }
	inline SRFloat uAsk() const { return layout_.uAsk; }
	inline SRFloat years() const { return layout_.years; }
	inline SRFloat rate() const { return layout_.rate; }
	inline SRFloat sdiv() const { return layout_.sdiv; }
	inline SRFloat ddiv() const { return layout_.ddiv; }
	inline SRFloat axisVol() const { return layout_.axisVol; }
	inline SRFloat cAtm() const { return layout_.cAtm; }
	inline SRFloat pAtm() const { return layout_.pAtm; }
	inline SRFloat adjDI() const { return layout_.adjDI; }
	inline SRFloat adjD8() const { return layout_.adjD8; }
	inline SRFloat adjD7() const { return layout_.adjD7; }
	inline SRFloat adjD6() const { return layout_.adjD6; }
	inline SRFloat adjD5() const { return layout_.adjD5; }
	inline SRFloat adjD4() const { return layout_.adjD4; }
	inline SRFloat adjD3() const { return layout_.adjD3; }
	inline SRFloat adjD2() const { return layout_.adjD2; }
	inline SRFloat adjD1() const { return layout_.adjD1; }
	inline SRFloat adjU1() const { return layout_.adjU1; }
	inline SRFloat adjU2() const { return layout_.adjU2; }
	inline SRFloat adjU3() const { return layout_.adjU3; }
	inline SRFloat adjU4() const { return layout_.adjU4; }
	inline SRFloat adjU5() const { return layout_.adjU5; }
	inline SRFloat adjU6() const { return layout_.adjU6; }
	inline SRFloat adjU7() const { return layout_.adjU7; }
	inline SRFloat adjU8() const { return layout_.adjU8; }
	inline SRFloat adjUI() const { return layout_.adjUI; }
	inline SRFloat slope() const { return layout_.slope; }
	inline SRFloat cmult() const { return layout_.cmult; }
	inline SRFloat pwidth() const { return layout_.pwidth; }
	inline SRFloat vwidth() const { return layout_.vwidth; }
	inline SRFloat sdivEMA() const { return layout_.sdivEMA; }
	inline SRFloat sdivLoEMA() const { return layout_.sdivLoEMA; }
	inline SRFloat sdivHiEMA() const { return layout_.sdivHiEMA; }
	inline SRFloat atmMAC() const { return layout_.atmMAC; }
	inline SRFloat cprMAC() const { return layout_.cprMAC; }
	inline SRFloat cAtmMove() const { return layout_.cAtmMove; }
	inline SRFloat pAtmMove() const { return layout_.pAtmMove; }
	inline SRByte cCnt() const { return layout_.cCnt; }
	inline SRByte pCnt() const { return layout_.pCnt; }
	inline SRByte cBidMiss() const { return layout_.cBidMiss; }
	inline SRByte cAskMiss() const { return layout_.cAskMiss; }
	inline SRByte pBidMiss() const { return layout_.pBidMiss; }
	inline SRByte pAskMiss() const { return layout_.pAskMiss; }
	inline SRFloat fitAvgErr() const { return layout_.fitAvgErr; }
	inline SRFloat fitAvgAbsErr() const { return layout_.fitAvgAbsErr; }
	inline SRFloat fitMaxPrcErr() const { return layout_.fitMaxPrcErr; }
	inline SRFloat fitErrXX() const { return layout_.fitErrXX; }
	inline CallOrPut fitErrCP() const { return layout_.fitErrCP; }
	inline SRFloat fitErrBid() const { return layout_.fitErrBid; }
	inline SRFloat fitErrAsk() const { return layout_.fitErrAsk; }
	inline SRFloat fitErrPrc() const { return layout_.fitErrPrc; }
	inline SRFloat fitErrVol() const { return layout_.fitErrVol; }
	inline FitType fitType() const { return layout_.fitType; }
	inline SRFutureKey sFKey() const { return layout_.sFKey; }
	inline LiveSurfaceType sType() const { return layout_.sType; }
	inline SRDateTime sTimestamp() const { return layout_.sTimestamp; }
	inline SRInt counter() const { return layout_.counter; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
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
		SROptionKey okey_;
		
	public:
		inline SROptionKey okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SROptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRFloat uBid;
		SRFloat uAsk;
		SRFloat bidPx;
		SRFloat askPx;
		SRFloat bidIV;
		SRFloat askIV;
		SRFloat srPrc;
		SRFloat srVol;
		MarkSource srSrc;
		SRFloat de;
		SRFloat ga;
		SRFloat th;
		SRFloat ve;
		SRFloat rh;
		SRFloat ph;
		SRFloat sdiv;
		SRFloat ddiv;
		SRFloat rate;
		SRByte error;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 373;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRFloat uBid() const { return layout_.uBid; }
	inline SRFloat uAsk() const { return layout_.uAsk; }
	inline SRFloat bidPx() const { return layout_.bidPx; }
	inline SRFloat askPx() const { return layout_.askPx; }
	inline SRFloat bidIV() const { return layout_.bidIV; }
	inline SRFloat askIV() const { return layout_.askIV; }
	inline SRFloat srPrc() const { return layout_.srPrc; }
	inline SRFloat srVol() const { return layout_.srVol; }
	inline MarkSource srSrc() const { return layout_.srSrc; }
	inline SRFloat de() const { return layout_.de; }
	inline SRFloat ga() const { return layout_.ga; }
	inline SRFloat th() const { return layout_.th; }
	inline SRFloat ve() const { return layout_.ve; }
	inline SRFloat rh() const { return layout_.rh; }
	inline SRFloat ph() const { return layout_.ph; }
	inline SRFloat sdiv() const { return layout_.sdiv; }
	inline SRFloat ddiv() const { return layout_.ddiv; }
	inline SRFloat rate() const { return layout_.rate; }
	inline SRByte error() const { return layout_.error; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
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
		SROptionKey okey_;
		
	public:
		inline SROptionKey okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SROptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRFloat bidPrice;
		SRFloat askPrice;
		SRUshort bidSize;
		SRUshort askSize;
		OptExch bidExch;
		OptExch askExch;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 104;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRFloat bidPrice() const { return layout_.bidPrice; }
	inline SRFloat askPrice() const { return layout_.askPrice; }
	inline SRUshort bidSize() const { return layout_.bidSize; }
	inline SRUshort askSize() const { return layout_.askSize; }
	inline OptExch bidExch() const { return layout_.bidExch; }
	inline OptExch askExch() const { return layout_.askExch; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
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
		SROptionKey okey_;
		
	public:
		inline SROptionKey okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SROptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRStockKey ticker;
		SRFloat ubid;
		SRFloat uask;
		SRFloat years;
		SRFloat rate;
		SRFloat sdiv;
		SRFloat ddiv;
		SRFloat obid;
		SRFloat oask;
		SRFloat obiv;
		SRFloat oaiv;
		SRFloat satm;
		SRFloat smny;
		SRFloat svol;
		SRFloat sprc;
		SRFloat de;
		SRFloat ga;
		SRFloat th;
		SRFloat ve;
		SRFloat ro;
		SRFixedLengthString<16> calcErr;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 377;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRStockKey ticker() const { return layout_.ticker; }
	inline SRFloat ubid() const { return layout_.ubid; }
	inline SRFloat uask() const { return layout_.uask; }
	inline SRFloat years() const { return layout_.years; }
	inline SRFloat rate() const { return layout_.rate; }
	inline SRFloat sdiv() const { return layout_.sdiv; }
	inline SRFloat ddiv() const { return layout_.ddiv; }
	inline SRFloat obid() const { return layout_.obid; }
	inline SRFloat oask() const { return layout_.oask; }
	inline SRFloat obiv() const { return layout_.obiv; }
	inline SRFloat oaiv() const { return layout_.oaiv; }
	inline SRFloat satm() const { return layout_.satm; }
	inline SRFloat smny() const { return layout_.smny; }
	inline SRFloat svol() const { return layout_.svol; }
	inline SRFloat sprc() const { return layout_.sprc; }
	inline SRFloat de() const { return layout_.de; }
	inline SRFloat ga() const { return layout_.ga; }
	inline SRFloat th() const { return layout_.th; }
	inline SRFloat ve() const { return layout_.ve; }
	inline SRFloat ro() const { return layout_.ro; }
	inline const SRFixedLengthString<16>& calcErr() const { return layout_.calcErr; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
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
		SROptionKey okey_;
		
	public:
		inline SROptionKey okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SROptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRFloat bidPrice;
		SRFloat askPrice;
		SRUshort bidSize;
		SRUshort askSize;
		SRUshort cumBidSize;
		SRUshort cumAskSize;
		OptExch bidExch;
		OptExch askExch;
		SRUint bidMask;
		SRUint askMask;
		SRFloat bidPrice2;
		SRFloat askPrice2;
		SRUshort cumBidSize2;
		SRUshort cumAskSize2;
		SRInt bidTime;
		SRInt askTime;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 102;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRFloat bidPrice() const { return layout_.bidPrice; }
	inline SRFloat askPrice() const { return layout_.askPrice; }
	inline SRUshort bidSize() const { return layout_.bidSize; }
	inline SRUshort askSize() const { return layout_.askSize; }
	inline SRUshort cumBidSize() const { return layout_.cumBidSize; }
	inline SRUshort cumAskSize() const { return layout_.cumAskSize; }
	inline OptExch bidExch() const { return layout_.bidExch; }
	inline OptExch askExch() const { return layout_.askExch; }
	inline SRUint bidMask() const { return layout_.bidMask; }
	inline SRUint askMask() const { return layout_.askMask; }
	inline SRFloat bidPrice2() const { return layout_.bidPrice2; }
	inline SRFloat askPrice2() const { return layout_.askPrice2; }
	inline SRUshort cumBidSize2() const { return layout_.cumBidSize2; }
	inline SRUshort cumAskSize2() const { return layout_.cumAskSize2; }
	inline SRInt bidTime() const { return layout_.bidTime; }
	inline SRInt askTime() const { return layout_.askTime; }
	
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
		SROptionKey okey_;
		
	public:
		inline SROptionKey okey() const { return okey_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SROptionKey()(k.okey_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.okey_ == b.okey_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRFloat uBid;
		SRFloat uAsk;
		SRFloat bidPx;
		SRFloat askPx;
		SRFloat bidIV;
		SRFloat askIV;
		SRFloat srPrc;
		SRFloat srVol;
		MarkSource srSrc;
		SRFloat de;
		SRFloat ga;
		SRFloat th;
		SRFloat ve;
		SRFloat rh;
		SRFloat ph;
		SRFloat sdiv;
		SRFloat ddiv;
		SRFloat rate;
		SRByte error;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 105;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRFloat uBid() const { return layout_.uBid; }
	inline SRFloat uAsk() const { return layout_.uAsk; }
	inline SRFloat bidPx() const { return layout_.bidPx; }
	inline SRFloat askPx() const { return layout_.askPx; }
	inline SRFloat bidIV() const { return layout_.bidIV; }
	inline SRFloat askIV() const { return layout_.askIV; }
	inline SRFloat srPrc() const { return layout_.srPrc; }
	inline SRFloat srVol() const { return layout_.srVol; }
	inline MarkSource srSrc() const { return layout_.srSrc; }
	inline SRFloat de() const { return layout_.de; }
	inline SRFloat ga() const { return layout_.ga; }
	inline SRFloat th() const { return layout_.th; }
	inline SRFloat ve() const { return layout_.ve; }
	inline SRFloat rh() const { return layout_.rh; }
	inline SRFloat ph() const { return layout_.ph; }
	inline SRFloat sdiv() const { return layout_.sdiv; }
	inline SRFloat ddiv() const { return layout_.ddiv; }
	inline SRFloat rate() const { return layout_.rate; }
	inline SRByte error() const { return layout_.error; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
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
		SROptionKey okey_;
		OptExch exch_;
		
	public:
		inline SROptionKey okey() const { return okey_; }
		inline OptExch exch() const { return exch_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SROptionKey()(k.okey_);
			hash_code = (hash_code * 397) ^ hash<OptExch>()(k.exch_);

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
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRFloat prtPrice;
		SRInt prtSize;
		SRByte prtType;
		SRInt prtVolume;
		SRInt cxlVolume;
		SRFloat lastPrice;
		SRInt lastSize;
		SRDateTime lastTime;
		SRUshort bidCount;
		SRUshort askCount;
		SRInt bidVolume;
		SRInt askVolume;
		SRFloat ebid;
		SRFloat eask;
		SRUshort ebsz;
		SRUshort easz;
		SRFloat eage;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 106;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRFloat prtPrice() const { return layout_.prtPrice; }
	inline SRInt prtSize() const { return layout_.prtSize; }
	inline SRByte prtType() const { return layout_.prtType; }
	inline SRInt prtVolume() const { return layout_.prtVolume; }
	inline SRInt cxlVolume() const { return layout_.cxlVolume; }
	inline SRFloat lastPrice() const { return layout_.lastPrice; }
	inline SRInt lastSize() const { return layout_.lastSize; }
	inline SRDateTime lastTime() const { return layout_.lastTime; }
	inline SRUshort bidCount() const { return layout_.bidCount; }
	inline SRUshort askCount() const { return layout_.askCount; }
	inline SRInt bidVolume() const { return layout_.bidVolume; }
	inline SRInt askVolume() const { return layout_.askVolume; }
	inline SRFloat ebid() const { return layout_.ebid; }
	inline SRFloat eask() const { return layout_.eask; }
	inline SRUshort ebsz() const { return layout_.ebsz; }
	inline SRUshort easz() const { return layout_.easz; }
	inline SRFloat eage() const { return layout_.eage; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionPrint::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class OptionSettlementMark
{
public:
	class Key
	{
		SROptionKey okey_;
		YesNo early_;
		YesNo priorPeriod_;
		
	public:
		inline SROptionKey okey() const { return okey_; }
		inline YesNo early() const { return early_; }
		inline YesNo priorPeriod() const { return priorPeriod_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SROptionKey()(k.okey_);
			hash_code = (hash_code * 397) ^ hash<YesNo>()(k.early_);
			hash_code = (hash_code * 397) ^ hash<YesNo>()(k.priorPeriod_);

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
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRDateKey settleDate;
		SRFloat settlePx;
		SRFloat settleDe;
		SRFloat lowLmtPx;
		SRFloat highLmtPx;
		SRInt openInt;
		SRInt volume;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 374;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRDateKey settleDate() const { return layout_.settleDate; }
	inline SRFloat settlePx() const { return layout_.settlePx; }
	inline SRFloat settleDe() const { return layout_.settleDe; }
	inline SRFloat lowLmtPx() const { return layout_.lowLmtPx; }
	inline SRFloat highLmtPx() const { return layout_.highLmtPx; }
	inline SRInt openInt() const { return layout_.openInt; }
	inline SRInt volume() const { return layout_.volume; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<OptionSettlementMark::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class SpreadQuote
{
public:
	class Key
	{
		SRStockKey ticker_;
		SprdSource sprdSource_;
		
	public:
		inline SRStockKey ticker() const { return ticker_; }
		inline SprdSource sprdSource() const { return sprdSource_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SRStockKey()(k.ticker_);
			hash_code = (hash_code * 397) ^ hash<SprdSource>()(k.sprdSource_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_
				&& a.sprdSource_ == b.sprdSource_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRFixedLengthString<16> spreadID;
		SRByte isOurs;
		SRFixedLengthString<12> source;
		QuoteType type;
		SRFloat premium;
		SRInt quantity;
		SRDateTime validTill;
		BuySell stockSide;
		SRInt stockShares;
		SRByte numLegs;
		SROptionKey okey1;
		SRUshort mult1;
		BuySell side1;
		SROptionKey okey2;
		SRUshort mult2;
		BuySell side2;
		SROptionKey okey3;
		SRUshort mult3;
		BuySell side3;
		SROptionKey okey4;
		SRUshort mult4;
		BuySell side4;
		SROptionKey okey5;
		SRUshort mult5;
		BuySell side5;
		SROptionKey okey6;
		SRUshort mult6;
		BuySell side6;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 131;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const SRFixedLengthString<16>& spreadID() const { return layout_.spreadID; }
	inline SRByte isOurs() const { return layout_.isOurs; }
	inline const SRFixedLengthString<12>& source() const { return layout_.source; }
	inline QuoteType type() const { return layout_.type; }
	inline SRFloat premium() const { return layout_.premium; }
	inline SRInt quantity() const { return layout_.quantity; }
	inline SRDateTime validTill() const { return layout_.validTill; }
	inline BuySell stockSide() const { return layout_.stockSide; }
	inline SRInt stockShares() const { return layout_.stockShares; }
	inline SRByte numLegs() const { return layout_.numLegs; }
	inline SROptionKey okey1() const { return layout_.okey1; }
	inline SRUshort mult1() const { return layout_.mult1; }
	inline BuySell side1() const { return layout_.side1; }
	inline SROptionKey okey2() const { return layout_.okey2; }
	inline SRUshort mult2() const { return layout_.mult2; }
	inline BuySell side2() const { return layout_.side2; }
	inline SROptionKey okey3() const { return layout_.okey3; }
	inline SRUshort mult3() const { return layout_.mult3; }
	inline BuySell side3() const { return layout_.side3; }
	inline SROptionKey okey4() const { return layout_.okey4; }
	inline SRUshort mult4() const { return layout_.mult4; }
	inline BuySell side4() const { return layout_.side4; }
	inline SROptionKey okey5() const { return layout_.okey5; }
	inline SRUshort mult5() const { return layout_.mult5; }
	inline BuySell side5() const { return layout_.side5; }
	inline SROptionKey okey6() const { return layout_.okey6; }
	inline SRUshort mult6() const { return layout_.mult6; }
	inline BuySell side6() const { return layout_.side6; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<SpreadQuote::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}

};

 class StockBookQuote
{
public:
	class Key
	{
		SRStockKey ticker_;
		
	public:
		inline SRStockKey ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SRStockKey()(k.ticker_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRFloat bidPrice1;
		SRUshort bidSize1;
		StkExch bidExch1;
		SRUint bidMask1;
		SRFloat askPrice1;
		SRUshort askSize1;
		StkExch askExch1;
		SRUint askMask1;
		SRFloat bidPrice2;
		SRUshort bidSize2;
		StkExch bidExch2;
		SRUint bidMask2;
		SRFloat askPrice2;
		SRUshort askSize2;
		StkExch askExch2;
		SRUint askMask2;
		SRByte expCnt;
		SRFloat expWidth;
		SRInt bidPrintQuan;
		SRInt askPrintQuan;
		SRInt timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 121;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRFloat bidPrice1() const { return layout_.bidPrice1; }
	inline SRUshort bidSize1() const { return layout_.bidSize1; }
	inline StkExch bidExch1() const { return layout_.bidExch1; }
	inline SRUint bidMask1() const { return layout_.bidMask1; }
	inline SRFloat askPrice1() const { return layout_.askPrice1; }
	inline SRUshort askSize1() const { return layout_.askSize1; }
	inline StkExch askExch1() const { return layout_.askExch1; }
	inline SRUint askMask1() const { return layout_.askMask1; }
	inline SRFloat bidPrice2() const { return layout_.bidPrice2; }
	inline SRUshort bidSize2() const { return layout_.bidSize2; }
	inline StkExch bidExch2() const { return layout_.bidExch2; }
	inline SRUint bidMask2() const { return layout_.bidMask2; }
	inline SRFloat askPrice2() const { return layout_.askPrice2; }
	inline SRUshort askSize2() const { return layout_.askSize2; }
	inline StkExch askExch2() const { return layout_.askExch2; }
	inline SRUint askMask2() const { return layout_.askMask2; }
	inline SRByte expCnt() const { return layout_.expCnt; }
	inline SRFloat expWidth() const { return layout_.expWidth; }
	inline SRInt bidPrintQuan() const { return layout_.bidPrintQuan; }
	inline SRInt askPrintQuan() const { return layout_.askPrintQuan; }
	inline SRInt timestamp() const { return layout_.timestamp; }
	
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
		SRStockKey ticker_;
		
	public:
		inline SRStockKey ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SRStockKey()(k.ticker_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRFloat bidPrc;
		SRFloat askPrc;
		SRFloat closePrc;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 125;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRFloat bidPrc() const { return layout_.bidPrc; }
	inline SRFloat askPrc() const { return layout_.askPrc; }
	inline SRFloat closePrc() const { return layout_.closePrc; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
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
		SRStockKey ticker_;
		
	public:
		inline SRStockKey ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SRStockKey()(k.ticker_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRFloat bidPrice;
		SRFloat askPrice;
		SRInt bidSize;
		SRInt askSize;
		StkExch bidExch;
		StkExch askExch;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 123;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRFloat bidPrice() const { return layout_.bidPrice; }
	inline SRFloat askPrice() const { return layout_.askPrice; }
	inline SRInt bidSize() const { return layout_.bidSize; }
	inline SRInt askSize() const { return layout_.askSize; }
	inline StkExch bidExch() const { return layout_.bidExch; }
	inline StkExch askExch() const { return layout_.askExch; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
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
		SRStockKey ticker_;
		
	public:
		inline SRStockKey ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SRStockKey()(k.ticker_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		SRFloat bidPrc;
		SRFloat askPrc;
		SRFloat closePrc;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 124;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline SRFloat bidPrc() const { return layout_.bidPrc; }
	inline SRFloat askPrc() const { return layout_.askPrc; }
	inline SRFloat closePrc() const { return layout_.closePrc; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
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
		SRStockKey ticker_;
		
	public:
		inline SRStockKey ticker() const { return ticker_; }

		inline size_t operator()(const Key& k) const
		{
			size_t hash_code = SRStockKey()(k.ticker_);

			return hash_code;
		}
		
		inline bool operator()(const Key& a, const Key& b) const
		{
			return
				a.ticker_ == b.ticker_;
		}
	};
	

private:
	MBUS_STRUCT_PACK_ENABLE
	struct Layout
	{
		Key pkey;
		MarketStatus marketStatus;
		StkExch prtExch;
		SRInt prtSize;
		SRInt prtQuan;
		SRFloat prtPrice;
		SRInt prtVolume;
		StockTick lastTick;
		SRFloat iniPrice;
		SRFloat mrkPrice;
		SRFloat opnPrice;
		SRFloat clsPrice;
		SRFloat minPrice;
		SRFloat maxPrice;
		SRInt bCnt;
		SRInt sCnt;
		SRInt shBot;
		SRInt shSld;
		SRFloat shMny;
		SRUshort expCnt;
		SRFloat expV1;
		SRFloat expV2;
		SRFloat expV3;
		SRFloat expV4;
		SRFloat expV5;
		SRDateTime timestamp;
	};
	MBUS_STRUCT_PACK_DISABLE
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;

public:
	static const MessageType Type = 122;
	
	inline Header& header() { return header_; }
	inline const Key& pkey() const { return layout_.pkey; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline MarketStatus marketStatus() const { return layout_.marketStatus; }
	inline StkExch prtExch() const { return layout_.prtExch; }
	inline SRInt prtSize() const { return layout_.prtSize; }
	inline SRInt prtQuan() const { return layout_.prtQuan; }
	inline SRFloat prtPrice() const { return layout_.prtPrice; }
	inline SRInt prtVolume() const { return layout_.prtVolume; }
	inline StockTick lastTick() const { return layout_.lastTick; }
	inline SRFloat iniPrice() const { return layout_.iniPrice; }
	inline SRFloat mrkPrice() const { return layout_.mrkPrice; }
	inline SRFloat opnPrice() const { return layout_.opnPrice; }
	inline SRFloat clsPrice() const { return layout_.clsPrice; }
	inline SRFloat minPrice() const { return layout_.minPrice; }
	inline SRFloat maxPrice() const { return layout_.maxPrice; }
	inline SRInt bCnt() const { return layout_.bCnt; }
	inline SRInt sCnt() const { return layout_.sCnt; }
	inline SRInt shBot() const { return layout_.shBot; }
	inline SRInt shSld() const { return layout_.shSld; }
	inline SRFloat shMny() const { return layout_.shMny; }
	inline SRUshort expCnt() const { return layout_.expCnt; }
	inline SRFloat expV1() const { return layout_.expV1; }
	inline SRFloat expV2() const { return layout_.expV2; }
	inline SRFloat expV3() const { return layout_.expV3; }
	inline SRFloat expV4() const { return layout_.expV4; }
	inline SRFloat expV5() const { return layout_.expV5; }
	inline SRDateTime timestamp() const { return layout_.timestamp; }
	
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
