#include "FrameHandler.h"

using namespace SpiderRock::DataFeed;

#if !defined(SR_LOG_ERR)
#	include <iostream>
#	define SR_LOG_ERR(msg) std::cerr << msg << std::endl;
#endif

inline bool FrameHandler::ErrorCounter::ShouldLog()
{
	if (max_reached_) return false;

#if defined(_WINDOWS_)
	auto c = InterlockedIncrement16(&counter_);
#else
#	error FrameHandler::ErrorCounter::ShouldLog() only implemented on Windows
#endif

	if (c == max_)
	{
		max_reached_ = true;
		SR_LOG_ERR("Error category '" + label_ + "' reached its max of " + to_string(max_) + " log messages.  Logging for this error category will be suppressed going forward.");
	}
	else if (c < max_)
	{
		return true;
	}
	return false;
}

FrameHandler::FrameHandler(SysEnvironment env)
	: env_(env), frame_parse_error_("Frame parse error", 50)
{
	for (int i = 0; i < MAX_MESSAGE_TYPE; i++)
	{
		msg_handlers_[i] = nullptr;

		auto messageType = to_string(i);
		channel_cross_errors_[i] = make_unique<ErrorCounter>(ErrorCounter("Channel cross error: " + messageType, 20));
		msg_parse_errors_[i] = make_unique<ErrorCounter>(ErrorCounter("Message parse error: " + messageType, 20));
		unknown_msg_type_errors_[i] = make_unique<ErrorCounter>(ErrorCounter("Unknown message type: " + messageType, 1));
	}
}

FrameHandler::~FrameHandler()
{
	for (int i = 0; i < MAX_MESSAGE_TYPE; i++)
	{
		msg_handlers_[i] = nullptr;
		channel_cross_errors_[i] = nullptr;
		msg_parse_errors_[i] = nullptr;
		unknown_msg_type_errors_[i] = nullptr;
	}
}

void FrameHandler::RegisterMessageHandler(MessageHandler* msg_handler)
{
	for (MessageType message_type : msg_handler->HandledTypes())
	{
		msg_handlers_[message_type] = msg_handler;
	}
}

int FrameHandler::Handle(uint8_t* buffer, uint32_t length, Channel* channel, const sockaddr_in& source)
{
	uint32_t offset = 0;

	try
	{
		LARGE_INTEGER ts;
		QueryPerformanceCounter(&ts);

		while (offset + sizeof(Header) <= length)
		{
			Header* header = reinterpret_cast<Header*>(buffer + offset);

			if (!IsValid(header->env) || !IsValid(header->msg_type) || header->msg_len <= sizeof(Header) + header->key_len)
			{
				channel->SetLastError(INVALID_HEADER_ENCOUNTERED);
				return -1; // throw invalid frame error
			}

			if (offset + header->msg_len > length) break;

			channel->IncrementMessageTypeCounters(header->msg_type, header->msg_len);

			if (header->env == env_)
			{
				try
				{
					MessageHandler* handler = msg_handlers_[header->msg_type];
					if (handler)
					{
						msg_handlers_[header->msg_type]->Handle(header, ts.QuadPart - ts.QuadPart);
					}
					else if (unknown_msg_type_errors_[header->msg_type]->ShouldLog())
					{
						auto label = unknown_msg_type_errors_[header->msg_type]->label();
						channel->SetLastError(label.c_str());
						SR_LOG_ERR(label);
					}
				}
				catch (const exception& e)
				{
					auto error_counter = msg_parse_errors_[header->msg_type].get();

					if (error_counter->ShouldLog())
					{
						SR_LOG_ERR(e.what());
					}

					channel->SetLastError(e.what());
				}
			}
			else
			{
				auto error_counter = channel_cross_errors_[header->msg_type].get();

				if (error_counter->ShouldLog())
				{
					SR_LOG_ERR(
						"Channel cross: MessageType=" + to_string(header->msg_type) +
						", SysEnvironment=" + to_string(static_cast<int>(header->env)) +
						", Channel=" + channel->label() + ", Source=" + string(inet_ntoa(source.sin_addr)) + ":" + to_string(source.sin_port));
				}

				channel->SetLastError(error_counter->label().c_str());
			}

			offset += header->msg_len;
		} // while              

		if (offset < 0) return offset; // frame parse error (generally not recoverable)

		if (offset == length) return 0;
		if (offset == 0) return length;

		channel->IncrementPartials();

		int remainder = length - offset;

		// copy residual to beginning of buffer       
		memcpy(buffer, buffer + offset, remainder);

		return remainder;
	}
	catch (const exception& e)
	{
		channel->SetLastError(frame_parse_error_.label().c_str());

		if (frame_parse_error_.ShouldLog())
		{
			SR_LOG_ERR(e.what());
		}

		return -1;
	}
}

#undef SR_LOG_ERR
