// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2023, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#pragma once

#include "stdafx.h"

#include <vector>

#include "Fields.h"
#include "Enums.h"
#include "Header.h"

#pragma pack(1)

namespace SpiderRock { 

namespace DataFeed {

class MLinkCacheRequest
{
public:
	class MsgType
	{
		UShort msgType_;
		Long schemaHash_;
		
	public:
		inline UShort msgType() const { return msgType_; }
		inline Long schemaHash() const { return schemaHash_; }
		inline void msgType(UShort value) { msgType_ = value; }
		inline void schemaHash(Long value) { schemaHash_ = value; }
	};

private:
	struct Layout
	{
		String<64> queryLabel;
		Long highwaterTs;
		UShort sourceId;
		String<32> stripe;
	};
	
	Header header_;
	Layout layout_;
	std::vector<MsgType> msgtype_;
	int64_t time_received_;
	
public:
	inline Header& header() { return header_; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const String<64>& queryLabel() const { return layout_.queryLabel; }
	inline Long highwaterTs() const { return layout_.highwaterTs; }
	inline UShort sourceId() const { return layout_.sourceId; }
	inline const String<32>& stripe() const { return layout_.stripe; }
	inline void queryLabel(const String<64>& value) { layout_.queryLabel = value; }
	inline void highwaterTs(Long value) { layout_.highwaterTs = value; }
	inline void sourceId(UShort value) { layout_.sourceId = value; }
	inline void stripe(const String<32>& value) { layout_.stripe = value; }
	inline void msgtype(const std::vector<MsgType> value) { msgtype_.assign(value.begin(), value.end()); }
	
	inline uint16_t Encode(uint8_t* buf) 
	{
		uint8_t* start = buf;
		buf += sizeof(Header);

		*reinterpret_cast<MLinkCacheRequest::Layout*>(buf) = layout_;
		buf += sizeof(layout_);
		
		// MsgType Repeat Section
		*reinterpret_cast<uint16_t*>(buf) = (uint16_t)msgtype_.size();
		buf += sizeof(uint16_t);

		for ( MsgType i : msgtype_ )
		{
			*reinterpret_cast<MsgType*>(buf) = i;
			buf += sizeof(i);
		}


		header_.message_length = (uint16_t)(buf - start);
		header_.key_length = 0;
		header_.message_type = MessageType::MLinkCacheRequest;
		header_.len = sizeof(Header);
		
		*reinterpret_cast<Header*>(start) = header_;
		
		return header_.message_length;
	}

	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + header_->len;
		
		layout_ = *reinterpret_cast<MLinkCacheRequest::Layout*>(ptr);
		ptr += sizeof(layout_);
		
		// MsgType Repeat Section
		auto msgtype_count = *reinterpret_cast<uint16_t*>(ptr);
		ptr += sizeof(msgtype_count);

		for (int i = 0; i < msgtype_count; i++)
		{
			msgtype_.push_back(*reinterpret_cast<MsgType*>(ptr));
			ptr += sizeof(MsgType);
		}

	}


};

 class MLinkStreamCheckPt
{
public:

private:
	struct Layout
	{
		Short sessionID;
		Long queryID;
		Long signalID;
		MLinkStreamState state;
		String<255> detail;
		Long highwaterTs;
		Long numBytesSent;
		Int numMessagesSent;
		Double waitElapsed;
		Double queryElapsed;
		Double tryFwdElapsed;
		Double sendElapsed;
		Double flushElapsed;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;
	
public:
	inline Header& header() { return header_; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline Short sessionID() const { return layout_.sessionID; }
	inline Long queryID() const { return layout_.queryID; }
	inline Long signalID() const { return layout_.signalID; }
	inline MLinkStreamState state() const { return layout_.state; }
	inline String<255> detail() const { return layout_.detail; }
	inline Long highwaterTs() const { return layout_.highwaterTs; }
	inline Long numBytesSent() const { return layout_.numBytesSent; }
	inline Int numMessagesSent() const { return layout_.numMessagesSent; }
	inline Double waitElapsed() const { return layout_.waitElapsed; }
	inline Double queryElapsed() const { return layout_.queryElapsed; }
	inline Double tryFwdElapsed() const { return layout_.tryFwdElapsed; }
	inline Double sendElapsed() const { return layout_.sendElapsed; }
	inline Double flushElapsed() const { return layout_.flushElapsed; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	inline void sessionID(Short value) { layout_.sessionID = value; }
	inline void queryID(Long value) { layout_.queryID = value; }
	inline void signalID(Long value) { layout_.signalID = value; }
	inline void state(MLinkStreamState value) { layout_.state = value; }
	inline void detail(String<255> value) { layout_.detail = value; }
	inline void highwaterTs(Long value) { layout_.highwaterTs = value; }
	inline void numBytesSent(Long value) { layout_.numBytesSent = value; }
	inline void numMessagesSent(Int value) { layout_.numMessagesSent = value; }
	inline void waitElapsed(Double value) { layout_.waitElapsed = value; }
	inline void queryElapsed(Double value) { layout_.queryElapsed = value; }
	inline void tryFwdElapsed(Double value) { layout_.tryFwdElapsed = value; }
	inline void sendElapsed(Double value) { layout_.sendElapsed = value; }
	inline void flushElapsed(Double value) { layout_.flushElapsed = value; }
	inline void timestamp(DateTime value) { layout_.timestamp = value; }
	
	
	inline uint16_t Encode(uint8_t* buf) 
	{
		uint8_t* start = buf;
		buf += sizeof(Header);

		*reinterpret_cast<MLinkStreamCheckPt::Layout*>(buf) = layout_;
		buf += sizeof(layout_);
		


		header_.message_length = (uint16_t)(buf - start);
		header_.key_length = 0;
		header_.message_type = MessageType::MLinkStreamCheckPt;
		header_.len = sizeof(Header);
		
		*reinterpret_cast<Header*>(start) = header_;
		
		return header_.message_length;
	}

	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + header_->len;
		
		layout_ = *reinterpret_cast<MLinkStreamCheckPt::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}


};

 class NetPulse
{
public:

private:
	struct Layout
	{
		TimeSpan frequency;
		TimeSpan timeout;
		DateTime timestamp;
	};
	
	Header header_;
	Layout layout_;
	
	int64_t time_received_;
	
public:
	inline Header& header() { return header_; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline TimeSpan frequency() const { return layout_.frequency; }
	inline TimeSpan timeout() const { return layout_.timeout; }
	inline DateTime timestamp() const { return layout_.timestamp; }
	inline void frequency(TimeSpan value) { layout_.frequency = value; }
	inline void timeout(TimeSpan value) { layout_.timeout = value; }
	inline void timestamp(DateTime value) { layout_.timestamp = value; }
	
	
	inline uint16_t Encode(uint8_t* buf) 
	{
		uint8_t* start = buf;
		buf += sizeof(Header);

		*reinterpret_cast<NetPulse::Layout*>(buf) = layout_;
		buf += sizeof(layout_);
		


		header_.message_length = (uint16_t)(buf - start);
		header_.key_length = 0;
		header_.message_type = MessageType::NetPulse;
		header_.len = sizeof(Header);
		
		*reinterpret_cast<Header*>(start) = header_;
		
		return header_.message_length;
	}

	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + header_->len;
		
		layout_ = *reinterpret_cast<NetPulse::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}


};



}	// namespace DataFeed

}	// namespace SpiderRock

#pragma pack()
