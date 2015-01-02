#pragma once

#include "stdafx.h"

#include "MessageHandler.h"
#include "Channel.h"
#include "DblLib.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		class FrameHandler : public Myricom::DblReadHandler<Channel>
		{
			class ErrorCounter
			{
				int16_t counter_;
				int16_t max_;
				bool max_reached_;
				string label_;

			public:
				ErrorCounter(const string& label, uint8_t max) : label_(label), max_(max), counter_(-1), max_reached_(false) { }
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

			void RegisterMessageHandler(MessageHandler* msg_handler);

			int Handle(uint8_t* buffer, uint32_t length, Channel* channel, const sockaddr_in& source);
		};
	}
}