#pragma once

#include "stdafx.h"
#include "Header.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		class MessageHandler
		{
		public:
			virtual void Handle(Header* header, uint64_t timestamp) = 0;
		};
	}
}