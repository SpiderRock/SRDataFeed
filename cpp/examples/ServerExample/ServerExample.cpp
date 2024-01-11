#include <iostream>
#include <memory>
#include <string>
#include <chrono>
#include <iomanip>

#ifdef _WINDOWS_
#include <tchar.h>
#else
#include <netdb.h>
#endif

#include <chrono>
#include <thread>

#include "SpiderStream.h"

using namespace SpiderRock::Net;
using namespace SpiderRock::SpiderStream;

using namespace std;
using namespace std::chrono;

class SpyMaster : public UpdateEventObserver<StockBookQuote>,
	public ChangeEventObserver<StockPrint>,
	public ChangeEventObserver<OptionNbboQuote>
{
	Float bidPrice_;

public:
	void OnUpdate(const StockBookQuote &previous, const StockBookQuote &current, bool drops)
	{
		static Ticker spy = Ticker("SPY");
		if (previous.pkey().ticker().ticker() != spy)
			return;

		auto bidDelta = previous.bidPrice1() - current.bidPrice1();
		if (abs(bidDelta) < 0.05)
			return;

		bidPrice_ = current.bidPrice1();

		(drops ? cerr : cout) 
			<< "Bid price change for " << *previous.pkey().ticker().ticker().str()
			<< " from " << to_string(previous.bidPrice1()) 
			<< " to " << to_string(current.bidPrice1()) << endl;
	}

	inline std::tm to_tm(int64_t nanosSinceUnixEpoch)
	{
		system_clock::time_point timePoint{nanoseconds{nanosSinceUnixEpoch}};
		std::time_t time = system_clock::to_time_t(timePoint);
		return *std::localtime(&time);
	}

	void OnChange(const StockPrint &obj, bool drops)
	{
		static Ticker spy = Ticker("SPY");

		if (obj.pkey().ticker().ticker() != spy)
			return;
		
    	auto prtTimestamp = to_tm(obj.prtTimestamp());

		(drops ? cerr : cout) << "Print: "
			<< *obj.pkey().ticker().ticker().str()
			<< obj.prtSize() << " shares at $" << obj.prtPrice() 
			<< " [" << std::put_time(&prtTimestamp, "%F %T") << "]" 
			<< endl;
	}

	void OnChange(const OptionNbboQuote &obj, bool drops)
	{
		static Ticker spy = Ticker("SPY");

		if (obj.pkey().okey().ticker() != spy)
			return;

		auto xx = obj.pkey().okey().strike();

		if (abs(xx - bidPrice_) > 1)
			return;

		(drops ? cerr : cout) << "SPY @ " << xx << " bid: " << obj.bidPrice() << ", ask: " << obj.askPrice() << endl;
	}
};

#ifdef _WINDOWS_
int _tmain(int argc, _TCHAR *argv[])
#else
int main()
#endif
{
	try
	{
		in_addr ifaddr;
		ifaddr.s_addr = inet_addr("local_interface");

		MbusClient engine(ifaddr);

		// engine.CreateThreadGroup(
		// 	MbusClient::Protocol::UDP,
		// 	{
		// 		DataChannel::StkNbboQuoteABCD,
		// 		DataChannel::OptNbboQuoteA,
		// 		DataChannel::OptNbboQuoteB,
		// 		DataChannel::OptNbboQuoteC,
		// 		DataChannel::OptNbboQuoteD
		// 	});

		// engine.CreateThreadGroup(
		// 	MbusClient::Protocol::UDP,
		// 	{
		// 		DataChannel::StkNbboQuoteEFGH,
		// 		DataChannel::OptNbboQuoteE,
		// 		DataChannel::OptNbboQuoteF,
		// 		DataChannel::OptNbboQuoteG,
		// 		DataChannel::OptNbboQuoteH
		// 	});

		// engine.CreateThreadGroup(
		// 	MbusClient::Protocol::UDP,
		// 	{
		// 		DataChannel::StkNbboQuoteS,
		// 		DataChannel::OptNbboQuoteS
		// 	});

		engine.CreateThreadGroup(
			MbusClient::Protocol::UDP,
			{
				DataChannel::StkNbboQuoteM,
				DataChannel::OptNbboQuoteM
			});

		auto spyMaster = make_shared<SpyMaster>();
		engine.RegisterObserver(dynamic_pointer_cast<UpdateEventObserver<StockBookQuote>>(spyMaster));
		engine.RegisterObserver(dynamic_pointer_cast<ChangeEventObserver<StockPrint>>(spyMaster));
		engine.RegisterObserver(dynamic_pointer_cast<ChangeEventObserver<OptionNbboQuote>>(spyMaster));

		engine.Start();

		/*
		auto start = clock();

		engine.MakeCacheRequest(
			{
				MessageType::StockBookQuote, 
				MessageType::OptionNbboQuote
			}
		);

		cout << "Cache request time: " << ((double)clock() - start) / CLOCKS_PER_SEC << "s" << endl;
		*/

		cout << "Press Enter to exit..." << std::endl;

		// Clear the input buffer
		cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
		cin.get();
	}
	catch (const runtime_error &e)
	{
		cerr << e.what() << endl;
	}

	return 0;
}
