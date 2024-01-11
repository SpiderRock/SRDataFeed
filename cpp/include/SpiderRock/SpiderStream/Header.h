#pragma once

#include "stdafx.h"

#include "Fields.h"
#include "CodeGen/MessageType.h"

namespace SpiderRock
{
	namespace SpiderStream
	{
		enum class HeaderBits : Flag
		{
			None                = 0,

			IsDeleted           = 1 << 0,
			FromRotation        = 1 << 7,

			FromCache           = 1 << 1,
			FromBridge          = 1 << 2,
			FromApplication     = 1 << 6,

			/// <summary>
			/// Mutually exclusive bits
			/// </summary>
			ExclusiveFrom = FromCache | FromBridge | FromApplication,

			/// <summary>
			/// Bits that can be set individually
			/// </summary>
			IndividualBits = 0xFF ^ ExclusiveFrom,
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
			struct TravelLog
			{
				struct Entry
				{
					Byte sysEnvironmentRealm;
					Byte runStatus;
				};

				Byte entries;
				Entry origin;
				Entry entry1;
				Entry entry2;
			};
			
			Byte len;
			UShort message_length;
			Byte key_length;

			MessageType message_type;
			HeaderBits bits;

			AppId source_id;

			SequenceNumber sequence_number;
			Long sent_time;

			TravelLog log;

			Header() :
				len(sizeof(Header)),
				message_length(0),
				key_length(0),
				message_type(),
				bits(HeaderBits::None),
				source_id(0),
				sequence_number(0),
				sent_time(0),
				log()
			{
			}
		};
#pragma pack()
	}
}
