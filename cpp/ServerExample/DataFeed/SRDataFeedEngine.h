#pragma once

#include "stdafx.h"

#include <memory>
#include <initializer_list>

#include "DataChannel.h"
#include "Net/IPEndPoint.h"
#include "EventObserver.h"
#include "CoreMessages.h"
#include "SysEnvironment.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		class SRDataFeedEngine
		{
			class impl;
			std::unique_ptr<impl> impl_;

		public:
			SRDataFeedEngine(SysEnvironment environment, in_addr device_address);
			~SRDataFeedEngine();
			
			enum class Protocol { DBL, UDP };

			void MakeCacheRequest(const SpiderRock::Net::IPEndPoint& end_point, std::initializer_list<MessageType> message_types);
			void CreateThreadGroup(Protocol proto, std::initializer_list<DataChannel> channels);
			void Start();

			void RegisterObserver(std::shared_ptr<void> observer);
		};
	}
}
