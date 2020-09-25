// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
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

class GetExtCache
{
public:
	class MsgType
	{
		UShort msgtype_;
		
	public:
		inline UShort msgtype() const { return msgtype_; }
		inline void msgtype(UShort value) { msgtype_ = value; }
	};

private:
	struct Layout
	{
		String<32> appName;
		Int requestID;
		String<255> filter;
		Int limit;
	};
	
	Header header_;
	Layout layout_;
	std::vector<MsgType> msgtype_;
	int64_t time_received_;
	
public:
	inline Header& header() { return header_; }
	
	inline void time_received(uint64_t value) { time_received_ = value; }
	inline uint64_t time_received() const { return time_received_; }
	
	inline const String<32>& appName() const { return layout_.appName; }
	inline Int requestID() const { return layout_.requestID; }
	inline const String<255>& filter() const { return layout_.filter; }
	inline Int limit() const { return layout_.limit; }
	inline void appName(const String<32>& value) { layout_.appName = value; }
	inline void requestID(Int value) { layout_.requestID = value; }
	inline void filter(const String<255>& value) { layout_.filter = value; }
	inline void limit(Int value) { layout_.limit = value; }
	inline void msgtype(const std::vector<MsgType> value) { msgtype_.assign(value.begin(), value.end()); }
	
	inline uint16_t Encode(uint8_t* buf) 
	{
		uint8_t* start = buf;
		buf += sizeof(Header);

		*reinterpret_cast<GetExtCache::Layout*>(buf) = layout_;
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
		header_.message_type = MessageType::GetExtCache;
		
		*reinterpret_cast<Header*>(start) = header_;
		
		return header_.message_length;
	}

	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<GetExtCache::Layout*>(ptr);
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
		
		*reinterpret_cast<Header*>(start) = header_;
		
		return header_.message_length;
	}

	inline void Decode(Header* buf) 
	{
		header_ = *buf;
		auto ptr = reinterpret_cast<uint8_t*>(buf) + sizeof(Header);
		
		layout_ = *reinterpret_cast<NetPulse::Layout*>(ptr);
		ptr += sizeof(layout_);
		

	}


};



}	// namespace DataFeed

}	// namespace SpiderRock

#pragma pack()
