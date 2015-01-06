#pragma once

#include "stdafx.h"

#include <cstdint>
#include <string>
#include <array>

#include "MessageType.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		class Channel
		{
			std::string label_;
			char* last_error_;
			std::array<uint64_t, MAX_MESSAGE_TYPE> msg_type_num_;
			std::array<uint64_t, MAX_MESSAGE_TYPE> msg_type_bytes_;
			uint64_t partials_;

		public:
			Channel(const std::string& label);
			~Channel();

			inline const std::string& label() const { return label_; }

			void SetLastError(const char* last_err);
			void IncrementMessageTypeCounters(MessageType msg_type, uint16_t msg_len);
			void IncrementPartials();
		};
	}
}
