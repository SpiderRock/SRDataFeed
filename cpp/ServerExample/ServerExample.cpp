#include "stdafx.h"

#include <iostream>
#include <memory>
#include <string>
#include <tchar.h>
#include <time.h>

#include "SRDataFeed.h"

using SpiderRock::Net::IPEndPoint;

using SpiderRock::DataFeed::SRDataFeedEngine;
using SpiderRock::DataFeed::UdpChannel;
using SpiderRock::DataFeed::SysEnvironment;

using SpiderRock::DataFeed::UpdateEventObserver;
using SpiderRock::DataFeed::ChangeEventObserver;
using SpiderRock::DataFeed::ChangeEventObserver;

using SpiderRock::DataFeed::StockBookQuote;
using SpiderRock::DataFeed::StockPrint;
using SpiderRock::DataFeed::OptionNbboQuote;
using SpiderRock::DataFeed::OptionPrint;

using SpiderRock::DataFeed::RootSymbol;
using SpiderRock::DataFeed::TickerSymbol;

using namespace std;

class Observer : 
	public UpdateEventObserver<StockBookQuote>, 
	public ChangeEventObserver<StockPrint>,
	public ChangeEventObserver<OptionNbboQuote>
{
public:
	void OnUpdate(const StockBookQuote& received, const StockBookQuote& current)
	{
		static TickerSymbol spy = TickerSymbol("SPY");
		if (received.pkey().ticker().ticker() != spy) return;

		auto bidDelta = received.bidPrice1() - current.bidPrice1();
		if (abs(bidDelta) < 0.001) return;

		std::cout 
			<< "Bid price change for " << *received.pkey().ticker().ticker().str()
			<< " from " << std::to_string(current.bidPrice1()) 
			<< " to " << std::to_string(received.bidPrice1()) << std::endl;
	}

	void OnChange(const StockPrint& obj)
	{
		static TickerSymbol spy = TickerSymbol("SPY");
		if (obj.pkey().ticker().ticker() != spy) return;
		time_t t = static_cast<time_t>(obj.timestamp());
		struct tm* timeinfo = gmtime(&t);
		std::cout << "Printed " << *obj.pkey().ticker().ticker().str() << " at " << asctime(timeinfo);
	}

	void OnChange(const OptionNbboQuote& obj)
	{
		static RootSymbol spy = RootSymbol("SPY");

		if (obj.pkey().okey().root() != spy) return;

		std::cout << "SPY " << obj.pkey().okey().strike() << std::endl;
	}
};

int _tmain(int argc, _TCHAR* argv[])
{
	try
	{
		in_addr ifaddr;
		ifaddr.S_un.S_addr = inet_addr("10.37.12.95");

		SRDataFeedEngine engine(SysEnvironment::Stable, ifaddr);

		engine.CreateThreadGroup(
		{
			UdpChannel::OptNbboQuote1,
			UdpChannel::OptNbboQuote2,
			UdpChannel::OptNbboQuote3,
			UdpChannel::OptNbboQuote4,

			UdpChannel::StkNbboQuote1,
			UdpChannel::StkNbboQuote2,
			UdpChannel::StkNbboQuote3,
			UdpChannel::StkNbboQuote4
		});

		//engine.CreateThreadGroup(
		//{
		//	UdpChannel::StkNbboQuote1,
		//	UdpChannel::StkNbboQuote2,
		//	UdpChannel::StkNbboQuote3,
		//	UdpChannel::StkNbboQuote4
		//});

		auto observer = std::make_shared<Observer>();
		engine.RegisterObserver(std::dynamic_pointer_cast<UpdateEventObserver<StockBookQuote>>(observer));
		engine.RegisterObserver(std::dynamic_pointer_cast<ChangeEventObserver<StockPrint>>(observer));
		engine.RegisterObserver(std::dynamic_pointer_cast<ChangeEventObserver<OptionNbboQuote>>(observer));

		engine.Start();

		auto start = clock();

		engine.MakeCacheRequest(
			IPEndPoint("spidernj146:3260"),
			{ StockBookQuote::Type, StockPrint::Type, OptionNbboQuote::Type, OptionPrint::Type });

		std::cout << "Cache request time: " << ((double)clock() - start) / CLOCKS_PER_SEC << "s" << std::endl;

		Sleep(5000);

		std::cout << std::endl << "Exiting..." << std::endl;
	}
	catch (const std::runtime_error& e)
	{
		std::cerr << e.what() << std::endl;
	}

	return 0;
}

