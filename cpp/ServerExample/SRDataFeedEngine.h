// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#pragma once

#include "stdafx.h"

#include "MessageBus.h"
#include "IPEndPoint.h"
#include "EventObserver.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		class SRDataFeedEngine
		{
			class impl;
			unique_ptr<impl> impl_;

		public:
			SRDataFeedEngine(SysEnvironment environment, in_addr device_address);
			~SRDataFeedEngine();

			void MakeCacheRequest(const SpiderRock::Net::IPEndPoint& end_point, initializer_list<MessageType> message_types);
			void CreateThreadGroup(initializer_list<UdpChannel> channels);
			void Start();

			void RegisterObserver(shared_ptr<CreateEventObserver<FutureBookQuote>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<FuturePrint>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<FutureSettlementMark>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<LiveSurfaceAtm>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<OptionCloseMark>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<OptionCloseQuote>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<OptionImpliedQuote>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<OptionNbboQuote>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<OptionOpenMark>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<OptionPrint>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<OptionSettlementMark>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<SpreadQuote>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<StockBookQuote>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<StockCloseMark>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<StockCloseQuote>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<StockOpenMark>> observer);
			void RegisterObserver(shared_ptr<CreateEventObserver<StockPrint>> observer);
			
			void RegisterObserver(shared_ptr<ChangeEventObserver<FutureBookQuote>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<FuturePrint>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<FutureSettlementMark>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<LiveSurfaceAtm>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<OptionCloseMark>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<OptionCloseQuote>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<OptionImpliedQuote>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<OptionNbboQuote>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<OptionOpenMark>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<OptionPrint>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<OptionSettlementMark>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<SpreadQuote>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<StockBookQuote>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<StockCloseMark>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<StockCloseQuote>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<StockOpenMark>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<StockPrint>> observer);
			
			void RegisterObserver(shared_ptr<UpdateEventObserver<FutureBookQuote>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<FuturePrint>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<FutureSettlementMark>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<LiveSurfaceAtm>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<OptionCloseMark>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<OptionCloseQuote>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<OptionImpliedQuote>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<OptionNbboQuote>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<OptionOpenMark>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<OptionPrint>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<OptionSettlementMark>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<SpreadQuote>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<StockBookQuote>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<StockCloseMark>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<StockCloseQuote>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<StockOpenMark>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<StockPrint>> observer);			
		};
	}
}
