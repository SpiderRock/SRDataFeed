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
using SpiderRock::DataFeed::DataChannel;
using SpiderRock::DataFeed::SysEnvironment;

using SpiderRock::DataFeed::UpdateEventObserver;
using SpiderRock::DataFeed::ChangeEventObserver;
using SpiderRock::DataFeed::ChangeEventObserver;

using SpiderRock::DataFeed::StockBookQuote;
using SpiderRock::DataFeed::StockPrint;
using SpiderRock::DataFeed::OptionNbboQuote;
using SpiderRock::DataFeed::OptionPrint;
using SpiderRock::DataFeed::LiveSurfaceAtm;

using SpiderRock::DataFeed::Root;
using SpiderRock::DataFeed::Ticker;
using SpiderRock::DataFeed::MessageType;

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

		cout 
			<< "Bid price change for " << *received.pkey().ticker().ticker().str()
			<< " from " << to_string(current.bidPrice1()) 
			<< " to " << to_string(received.bidPrice1()) << endl;
	}

	void OnChange(const StockPrint& obj)
	{
		static Ticker spy = Ticker("SPY");
		if (obj.pkey().ticker().ticker() != spy) return;
		time_t t = static_cast<time_t>(obj.timestamp());
		struct tm* timeinfo = gmtime(&t);
		cout << "Printed " << *obj.pkey().ticker().ticker().str() << " at " << asctime(timeinfo);
	}

	void OnChange(const OptionNbboQuote& obj)
	{
		static Root spy = Root("SPY");

		if (obj.pkey().okey().root() != spy) return;

		cout << "SPY " << obj.pkey().okey().strike() << endl;
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
		ifaddr.s_addr = inet_addr("10.37.200.95");

		SRDataFeedEngine engine(SysEnvironment::Stable, ifaddr);

		engine.CreateThreadGroup(
			SRDataFeedEngine::Protocol::UDP,
			{
				DataChannel::StkNbboQuote1,
				DataChannel::StkNbboQuote2,

				DataChannel::OptNbboQuote1,
				DataChannel::OptNbboQuote2
			});

		engine.CreateThreadGroup(
			SRDataFeedEngine::Protocol::UDP,
			{
				DataChannel::StkNbboQuote3,
				DataChannel::StkNbboQuote4,

				DataChannel::OptNbboQuote3,
				DataChannel::OptNbboQuote4
			});

		auto observer = make_shared<Observer>();
		engine.RegisterObserver(dynamic_pointer_cast<UpdateEventObserver<StockBookQuote>>(observer));
		engine.RegisterObserver(dynamic_pointer_cast<ChangeEventObserver<StockPrint>>(observer));
		engine.RegisterObserver(dynamic_pointer_cast<ChangeEventObserver<OptionNbboQuote>>(observer));

		engine.Start();

		auto start = clock();

		engine.MakeCacheRequest(
			IPEndPoint("198.102.4.145:3340"),	// Primary cache server
			//IPEndPoint("198.102.4.146:3340"),	// Secondary cache server
			{
				MessageType::StockBookQuote, 
				MessageType::OptionNbboQuote
			}
		);

		cout << "Cache request time: " << ((double)clock() - start) / CLOCKS_PER_SEC << "s" << endl;

		this_thread::sleep_for(chrono::milliseconds(5000));

		cout << endl << "Exiting..." << endl;
	}
	catch (const runtime_error& e)
	{
		cerr << e.what() << endl;
	}

	return 0;
}

