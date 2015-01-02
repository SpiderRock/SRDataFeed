#include "Channel.h"

using namespace SpiderRock::DataFeed;

Channel::Channel(const string& label) : label_(label), partials_(0), last_error_(nullptr)
{
}

Channel::~Channel()
{
	last_error_ = nullptr;
}

void Channel::SetLastError(const char* last_err)
{
	last_error_ = (char*)last_err;
}

void Channel::IncrementMessageTypeCounters(MessageType msg_type, uint16_t msg_len)
{
#if defined(_WINDOWS_)
	InterlockedIncrement64(reinterpret_cast<LONG64*>(&msg_type_num_[msg_type]));
	InterlockedAdd64(reinterpret_cast<LONG64*>(&msg_type_bytes_[msg_type]), msg_len);
#else
#	error Channel::IncrementMessageTypeCounters only implemented on Windows
#endif
}

void Channel::IncrementPartials()
{
#if defined(_WINDOWS_)
	InterlockedIncrement64(reinterpret_cast<LONG64*>(&partials_));
#else
#	error Channel::IncrementPartials only implemented on Windows
#endif
}