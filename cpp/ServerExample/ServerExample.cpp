#include "stdafx.h"

#include <iostream>
#include <memory>
#include <string>
#include <time.h>

#ifdef _WINDOWS_
#	include <tchar.h>
#else
#	include <netdb.h>
#endif

#include <chrono>
#include <thread>

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

using SpiderRock::DataFeed::Mbus::Root;
using SpiderRock::DataFeed::Mbus::Ticker;
using SpiderRock::DataFeed::Mbus::MessageType;

using namespace std;

class Observer : 
	public UpdateEventObserver<StockBookQuote>, 
	public ChangeEventObserver<StockPrint>,
	public ChangeEventObserver<OptionNbboQuote>
{
public:
	void OnUpdate(const StockBookQuote& received, const StockBookQuote& current)
	{
		static Ticker spy = Ticker("SPY");
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
		static Ticker spy = Ticker("SPY");
		if (obj.pkey().ticker().ticker() != spy) return;
		time_t t = static_cast<time_t>(obj.timestamp());
		struct tm* timeinfo = gmtime(&t);
		std::cout << "Printed " << *obj.pkey().ticker().ticker().str() << " at " << asctime(timeinfo);
	}

	void OnChange(const OptionNbboQuote& obj)
	{
		static Root spy = Root("SPY");

		if (obj.pkey().okey().root() != spy) return;

		std::cout << "SPY " << obj.pkey().okey().strike() << std::endl;
	}
};

#ifdef _WINDOWS_
int _tmain(int argc, _TCHAR* argv[])
#else
int main()
#endif
{
	try
	{
		in_addr ifaddr;
#ifdef _WINDOWS_
		ifaddr.S_un.S_addr = inet_addr("10.37.12.95");
#else
		ifaddr.s_addr = inet_addr("10.37.12.95");
#endif

		SRDataFeedEngine engine(SysEnvironment::Stable, ifaddr);

		engine.CreateThreadGroup(
		{
			UdpChannel::StkNbboQuote1,
			UdpChannel::StkNbboQuote2,

			UdpChannel::OptNbboQuote1,
			UdpChannel::OptNbboQuote2
		});

		engine.CreateThreadGroup(
		{
			UdpChannel::StkNbboQuote3,
			UdpChannel::StkNbboQuote4,

			UdpChannel::OptNbboQuote3,
			UdpChannel::OptNbboQuote4
		});

		auto observer = std::make_shared<Observer>();
		engine.RegisterObserver(std::dynamic_pointer_cast<UpdateEventObserver<StockBookQuote>>(observer));
		engine.RegisterObserver(std::dynamic_pointer_cast<ChangeEventObserver<StockPrint>>(observer));
		engine.RegisterObserver(std::dynamic_pointer_cast<ChangeEventObserver<OptionNbboQuote>>(observer));

		engine.Start();

		auto start = clock();

		engine.MakeCacheRequest(
			IPEndPoint("spidernj146:3260"),
			{ 
				MessageType::StockBookQuote, 
				MessageType::StockPrint, 
				MessageType::OptionNbboQuote, 
				MessageType::OptionPrint 
			}
		);

		std::cout << "Cache request time: " << ((double)clock() - start) / CLOCKS_PER_SEC << "s" << std::endl;

		std::this_thread::sleep_for(std::chrono::milliseconds(5000));

		std::cout << std::endl << "Exiting..." << std::endl;
	}
	catch (const std::runtime_error& e)
	{
		std::cerr << e.what() << std::endl;
	}

	return 0;
}

