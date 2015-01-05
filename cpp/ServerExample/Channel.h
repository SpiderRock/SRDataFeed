#pragma once

#include "stdafx.h"

#include "MbusEnums.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		using namespace Mbus;

		class Channel
		{
			string label_;
			char* last_error_;
			array<uint64_t, MAX_MESSAGE_TYPE> msg_type_num_;
			array<uint64_t, MAX_MESSAGE_TYPE> msg_type_bytes_;
			uint64_t partials_;

		public:
			Channel(const string& label);
			~Channel();

			inline const string& label() const { return label_; }

			void SetLastError(const char* last_err);
			void IncrementMessageTypeCounters(MessageType msg_type, uint16_t msg_len);
			void IncrementPartials();
		};
	}
}
