#pragma once

#include "stdafx.h"

#include <string>
#include <array>
#include <initializer_list>
#include <memory>

#ifndef _WINDOWS_
#	include <netinet/in.h>
#endif

#include "MessageHandler.h"
#include "MessageType.h"
#include "Channel.h"
#include "Net/Proto/ReadHandler.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		class FrameHandler : public SpiderRock::Net::Proto::ReadHandler<Channel>
		{
			class ErrorCounter
			{
				int16_t counter_;
				int16_t max_;
				bool max_reached_;
				std::string label_;

			public:
				ErrorCounter(const std::string& label, uint8_t max) : counter_(-1), max_(max), max_reached_(false), label_(label) { }
				~ErrorCounter() { }

				inline const std::string& label() const { return label_; }
				inline bool ShouldLog();
			};

			const char* INVALID_HEADER_ENCOUNTERED = "Invalid header encountered";

			SysEnvironment env_;
			std::array<MessageHandler*, MAX_MESSAGE_TYPE> msg_handlers_;
			ErrorCounter frame_parse_error_;
			std::array<std::unique_ptr<ErrorCounter>, MAX_MESSAGE_TYPE> channel_cross_errors_;
			std::array<std::unique_ptr<ErrorCounter>, MAX_MESSAGE_TYPE> msg_parse_errors_;
			std::array<std::unique_ptr<ErrorCounter>, MAX_MESSAGE_TYPE> unknown_msg_type_errors_;

		public:
			FrameHandler(SysEnvironment env);
			~FrameHandler();

			void RegisterMessageHandler(MessageHandler* message_handler, std::initializer_list<MessageType> message_types);

			int Handle(uint8_t* buffer, uint32_t length, Channel* channel, const sockaddr_in& source);
		};
	}
}
