#pragma once

#include "stdafx.h"

#include <cstdint>
#include <string>
#include <array>

#include "CodeGen/MessageType.h"
#include "SpiderRock/CompactArray16.h"

namespace SpiderRock
{
	namespace SpiderStream
	{
		class Channel
		{
			std::string label_;
			char *last_error_;
			std::array<uint64_t, MAX_MESSAGE_TYPE> msg_type_num_;
			std::array<uint64_t, MAX_MESSAGE_TYPE> msg_type_bytes_;
			std::array<uint64_t, MAX_MESSAGE_TYPE> msg_type_drops_;
			uint64_t partials_;
			CompactArray16<CompactArray16<SequenceNumber>> seq_numbers_;

		public:
			Channel(const std::string &label);
			~Channel();

			inline const std::string &label() const { return label_; }
			inline SequenceNumber GetExpectedSequenceNumber(MessageType msg_type, AppId source_id) { return seq_numbers_[static_cast<uint16_t>(msg_type)][source_id]; }

			void SetLastError(const char *last_err);
			void IncrementMessageTypeCounters(MessageType msg_type, uint16_t msg_len);
			void IncrementMessageTypeDrops(MessageType msg_type);
			void IncrementPartials();
		};
	}
}
