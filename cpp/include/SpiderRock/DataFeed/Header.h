#pragma once

#include "stdafx.h"

#include "Fields.h"
#include "MessageType.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		enum class HeaderBits : Flag
		{
			None = 0,
			IsDeleted = 1,
			FromCache = 2
		};

		inline HeaderBits operator|(HeaderBits a, HeaderBits b)
		{
			return static_cast<HeaderBits>(static_cast<int>(a) | static_cast<int>(b));
		}

		inline HeaderBits operator&(HeaderBits a, HeaderBits b)
		{
			return static_cast<HeaderBits>(static_cast<int>(a)& static_cast<int>(b));
		}

		inline HeaderBits operator~(HeaderBits a)
		{
			return static_cast<HeaderBits>(~static_cast<int>(a));
		}

#pragma pack(1)
		struct Header
		{
			SysEnvironment environment;
			MessageType message_type;
			HeaderBits bits;
			UShort source_id;
			Byte sequence_number;
			Long sent_time;
			UShort message_length;
			Byte key_length;

			Header() :
				environment(SysEnvironment::Stable),
				message_type(MessageType::None),
				bits(HeaderBits::None),
				source_id(0),
				sequence_number(0),
				sent_time(0),
				message_length(0),
				key_length(0)
			{
			}
		};
#pragma pack()
	}
}
