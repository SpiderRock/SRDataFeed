#pragma once

#include "stdafx.h"
#include "Header.h"

namespace SpiderRock
{
	namespace SpiderStream
	{
		class MessageHandler
		{
		public:
			virtual void Handle(Header* header, uint64_t timestamp, bool drops) = 0;
		};
	}
}