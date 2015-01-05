#pragma once

#include "stdafx.h"

#include "MbusEnums.h"
#include "MessageHandler.h"
#include "Channel.h"
#include "DblLib.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		using namespace Mbus;

		class FrameHandler : public Myricom::DblReadHandler<Channel>
		{
			class ErrorCounter
			{
				int16_t counter_;
				int16_t max_;
				bool max_reached_;
				string label_;

			public:
				ErrorCounter(const string& label, uint8_t max) : counter_(-1), max_(max), max_reached_(false), label_(label) { }
				~ErrorCounter() { }

				inline const string& label() const { return label_; }
				inline bool ShouldLog();
			};

			const char* INVALID_HEADER_ENCOUNTERED = "Invalid header encountered";

			SysEnvironment env_;
			array<MessageHandler*, MAX_MESSAGE_TYPE> msg_handlers_;
			ErrorCounter frame_parse_error_;
			array<unique_ptr<ErrorCounter>, MAX_MESSAGE_TYPE> channel_cross_errors_;
			array<unique_ptr<ErrorCounter>, MAX_MESSAGE_TYPE> msg_parse_errors_;
			array<unique_ptr<ErrorCounter>, MAX_MESSAGE_TYPE> unknown_msg_type_errors_;

		public:
			FrameHandler(SysEnvironment env);
			~FrameHandler();

			void RegisterMessageHandler(MessageHandler* message_handler, initializer_list<MessageType> message_types);

			int Handle(uint8_t* buffer, uint32_t length, Channel* channel, const sockaddr_in& source);
		};
	}
}
