#pragma once

#include "stdafx.h"
#include "MessageBus.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		class MessageHandler
		{
		public:
			virtual void Handle(Header* header, uint64_t timestamp) = 0;
			virtual const vector<MessageType>& HandledTypes() const = 0;
		};
	}
}