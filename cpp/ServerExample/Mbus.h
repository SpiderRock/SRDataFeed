#pragma once

#include "stdafx.h"

#include "MbusFields.h"
#include "MbusEnums.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		namespace Mbus
		{
			enum class SysEnvironment : Enum
			{
				None = 0,
				Stable = 1,
				Current = 2,
				UAT = 3
			};

			inline bool IsValid(SysEnvironment env)
			{
				return static_cast<int>(env) <= 5; // Only 3 are relevant to this API but 5 exist
			}

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
}
