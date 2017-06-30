// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#pragma once

#include "stdafx.h"

#include <memory>
#include <initializer_list>

#include "DataChannel.h"
#include "EventObserver.h"
#include "CoreMessages.h"
#include "SpiderRock/Net/IPEndPoint.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		class SRDataFeedEngine
		{
			class impl;
			std::unique_ptr<impl> impl_;

			SpiderRock::Net::IPEndPoint GetIPEndPoint(DataChannel channel);

		public:
			SRDataFeedEngine(in_addr device_address);
			~SRDataFeedEngine();
			
			enum class Protocol { DBL, UDP };

			void MakeCacheRequest(std::initializer_list<MessageType> message_types);
			void CreateThreadGroup(Protocol proto, std::initializer_list<DataChannel> channels);
			void Start();

			void RegisterObserver(std::shared_ptr<CreateEventObserver<FutureBookQuote>> observer);
			void RegisterObserver(std::shared_ptr<CreateEventObserver<FuturePrint>> observer);
			void RegisterObserver(std::shared_ptr<CreateEventObserver<IndexQuote>> observer);
			void RegisterObserver(std::shared_ptr<CreateEventObserver<LiveSurfaceAtm>> observer);
			void RegisterObserver(std::shared_ptr<CreateEventObserver<OptionImpliedQuote>> observer);
			void RegisterObserver(std::shared_ptr<CreateEventObserver<OptionNbboQuote>> observer);
			void RegisterObserver(std::shared_ptr<CreateEventObserver<OptionPrint>> observer);
			void RegisterObserver(std::shared_ptr<CreateEventObserver<OptionRiskFactor>> observer);
			void RegisterObserver(std::shared_ptr<CreateEventObserver<StockBookQuote>> observer);
			void RegisterObserver(std::shared_ptr<CreateEventObserver<StockExchImbalance>> observer);
			void RegisterObserver(std::shared_ptr<CreateEventObserver<StockPrint>> observer);
			
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<FutureBookQuote>> observer);
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<FuturePrint>> observer);
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<IndexQuote>> observer);
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<LiveSurfaceAtm>> observer);
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<OptionImpliedQuote>> observer);
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<OptionNbboQuote>> observer);
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<OptionPrint>> observer);
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<OptionRiskFactor>> observer);
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<StockBookQuote>> observer);
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<StockExchImbalance>> observer);
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<StockPrint>> observer);
			
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<FutureBookQuote>> observer);
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<FuturePrint>> observer);
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<IndexQuote>> observer);
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<LiveSurfaceAtm>> observer);
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<OptionImpliedQuote>> observer);
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<OptionNbboQuote>> observer);
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<OptionPrint>> observer);
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<OptionRiskFactor>> observer);
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<StockBookQuote>> observer);
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<StockExchImbalance>> observer);
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<StockPrint>> observer);			
		};
	}
}
