#pragma once

#include "stdafx.h"
#include "Mbus.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		class MessageHandler
		{
		public:
			virtual void Handle(Mbus::Header* header, uint64_t timestamp) = 0;
		};
	}
}