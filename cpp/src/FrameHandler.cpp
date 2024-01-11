#include "SpiderRock/SpiderStream/FrameHandler.h"

#include <stdio.h>
#include <memory>
#include <string>
#include <stdexcept>
#include <initializer_list>

#ifdef __GNUC__
#include <ctime>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#endif

using namespace SpiderRock::SpiderStream;
using std::exception;
using std::initializer_list;
using std::string;
using std::to_string;
using std::unique_ptr;

#ifndef SR_LOG_ERR
#include <iostream>
#define SR_LOG_ERR(msg) std::cerr << msg << std::endl;
#endif

inline bool FrameHandler::ErrorCounter::ShouldLog()
{
	if (max_reached_)
		return false;

#ifdef _WINDOWS_
	auto c = InterlockedIncrement16(&counter_);
#elif defined __GNUC__
	auto c = __sync_add_and_fetch(&counter_, 1);
#else
#error FrameHandler::ErrorCounter::ShouldLog() InterlockedIncrement implementation missing for this compiler
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
	for (UShort i = 0; i < MAX_MESSAGE_TYPE; i++)
	{
		msg_handlers_[i] = nullptr;

		auto messageType = to_string(i);
		channel_cross_errors_[i] = unique_ptr<ErrorCounter>(new ErrorCounter("Channel cross error: " + messageType, 20));
		msg_parse_errors_[i] = unique_ptr<ErrorCounter>(new ErrorCounter("Message parse error: " + messageType, 20));
		unknown_msg_type_errors_[i] = unique_ptr<ErrorCounter>(new ErrorCounter("Unknown message type: " + messageType, 1));
	}
}

FrameHandler::~FrameHandler()
{
	for (UShort i = 0; i < MAX_MESSAGE_TYPE; i++)
	{
		msg_handlers_[i] = nullptr;
		channel_cross_errors_[i] = nullptr;
		msg_parse_errors_[i] = nullptr;
		unknown_msg_type_errors_[i] = nullptr;
	}
}

void FrameHandler::RegisterMessageHandler(MessageHandler *message_handler, initializer_list<MessageType> message_types)
{
	for (MessageType message_type : message_types)
	{
		msg_handlers_[static_cast<size_t>(message_type)] = message_handler;
	}
}

const int64_t TICKS_PER_SECOND = 10000000;
const int64_t TICKS_PER_NANOSECOND = 100;

int FrameHandler::Handle(uint8_t *buffer, uint32_t length, Channel *channel, const sockaddr_in & /* unused for now: source */)
{
	int32_t offset = 0;

	try
	{
		int64_t timestamp;
#ifdef _WINDOWS_
		LARGE_INTEGER ts;
		QueryPerformanceCounter(&ts);
		timestamp = ts.QuadPart;
#elif defined __GNUC__
		timespec ts;
		clock_gettime(CLOCK_MONOTONIC, &ts);
		timestamp = ts.tv_sec * TICKS_PER_SECOND + ts.tv_nsec / TICKS_PER_NANOSECOND;
#endif

		while (offset + sizeof(Header) <= length)
		{
			Header *header = reinterpret_cast<Header *>(buffer + offset);

			if (!IsValid(header->message_type) ||
				header->message_length <= (header->len + header->key_length))
			{
				channel->SetLastError(INVALID_HEADER_ENCOUNTERED);
				return -1; // throw invalid frame error
			}

			if (offset + header->message_length > (int32_t)length)
				break;

			channel->IncrementMessageTypeCounters(header->message_type, header->message_length);

			try
			{
				auto expectedSeqNo = channel->GetExpectedSequenceNumber(header->message_type, header->source_id);

				auto actualSeqNo = header->sequence_number;

				// turn a blind eye to the zeroes since they may be caused by process restarts
				bool drops = false;

				if (expectedSeqNo == actualSeqNo || expectedSeqNo == 0 || actualSeqNo == 0)
				{
					expectedSeqNo++;
				}
				else
				{
					channel->IncrementMessageTypeDrops(header->message_type);
					expectedSeqNo = header->sequence_number + 1;
					drops = true;
				}

				MessageHandler *handler = msg_handlers_[static_cast<size_t>(header->message_type)];
				if (handler)
				{
					msg_handlers_[static_cast<size_t>(header->message_type)]->Handle(header, timestamp, drops);
				}
				else if (unknown_msg_type_errors_[static_cast<size_t>(header->message_type)]->ShouldLog())
				{
					auto label = unknown_msg_type_errors_[static_cast<size_t>(header->message_type)]->label();
					channel->SetLastError(label.c_str());
					SR_LOG_ERR(label);
				}
			}
			catch (const exception &e)
			{
				auto error_counter = msg_parse_errors_[static_cast<size_t>(header->message_type)].get();

				if (error_counter->ShouldLog())
				{
					SR_LOG_ERR(e.what());
				}

				channel->SetLastError(e.what());
			}

			offset += header->message_length;
		} // while

		if (offset < 0)
			return offset; // frame parse error (generally not recoverable)

		if (offset == (int32_t)length)
			return 0;
		if (offset == 0)
			return length;

		channel->IncrementPartials();

		int remainder = length - offset;

		// copy residual to beginning of buffer
		memcpy(buffer, buffer + offset, remainder);

		return remainder;
	}
	catch (const exception &e)
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
