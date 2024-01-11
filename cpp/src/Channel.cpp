#include "SpiderRock/SpiderStream/Channel.h"

using namespace SpiderRock::SpiderStream;
using std::array;
using std::string;

Channel::Channel(const string &label) : label_(label), last_error_(nullptr), partials_(0)
{
}

Channel::~Channel()
{
}

void Channel::SetLastError(const char *last_err)
{
	last_error_ = (char *)last_err;
}

void Channel::IncrementMessageTypeCounters(MessageType msg_type, uint16_t msg_len)
{
#ifdef _WINDOWS_
	InterlockedIncrement64(reinterpret_cast<LONG64 *>(&msg_type_num_[static_cast<UShort>(msg_type)]));
	InterlockedAdd64(reinterpret_cast<LONG64 *>(&msg_type_bytes_[static_cast<UShort>(msg_type)]), msg_len);
#elif __GNUC__
	__sync_add_and_fetch(&msg_type_num_[static_cast<UShort>(msg_type)], 1);
	__sync_add_and_fetch(&msg_type_bytes_[static_cast<UShort>(msg_type)], msg_len);
#else
#error Channel::IncrementMessageTypeCounters only implemented on Windows and GNU
#endif
}

void Channel::IncrementMessageTypeDrops(MessageType msg_type)
{
#ifdef _WINDOWS_
	InterlockedIncrement64(reinterpret_cast<LONG64 *>(&msg_type_drops_[static_cast<UShort>(msg_type)]));
#elif __GNUC__
	__sync_add_and_fetch(&msg_type_drops_[static_cast<UShort>(msg_type)], 1);
#else
#error Channel::IncrementMessageTypeCounters only implemented on Windows and GNU
#endif
}

void Channel::IncrementPartials()
{
#ifdef _WINDOWS_
	InterlockedIncrement64(reinterpret_cast<LONG64 *>(&partials_));
#elif defined __GNUC__
	__sync_add_and_fetch(&partials_, 1);
#else
#error Channel::IncrementPartials only implemented on Windows and GNU
#endif
}
