// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#include "SpiderRock/DataFeed/SRDataFeedEngine.h"

#include <string>
#include <memory>
#include <vector>
#include <initializer_list>

#include "SpiderRock/Net/IPAddress.h"
#include "SpiderRock/Net/IPEndPoint.h"
#include "SpiderRock/Net/Proto/Receiver.h"
#include "SpiderRock/Net/Proto/DBL/Receiver.h"
#include "SpiderRock/Net/Proto/UDP/Receiver.h"
#include "SpiderRock/DataFeed/MessageEventSource.h"
#include "SpiderRock/DataFeed/FrameHandler.h"
#include "SpiderRock/DataFeed/CacheClient.h"

using namespace std;
using namespace SpiderRock::DataFeed;
using namespace SpiderRock::Net::Proto;
using SpiderRock::Net::IPEndPoint;
using SpiderRock::Net::IPAddress;

class SRDataFeedEngine::impl {
public:
	SysEnvironment environment;
	FrameHandler frame_handler;
	vector<unique_ptr<Receiver<Channel>>> receivers;
	vector<shared_ptr<Channel>> channels;
	IPAddress if_addr;

	MessageEventSource<FutureBookQuote::Key, FutureBookQuote> futurebookquote;
	MessageEventSource<FuturePrint::Key, FuturePrint> futureprint;
	MessageEventSource<IndexQuote::Key, IndexQuote> indexquote;
	MessageEventSource<LiveSurfaceAtm::Key, LiveSurfaceAtm> livesurfaceatm;
	MessageEventSource<OptionImpliedQuote::Key, OptionImpliedQuote> optionimpliedquote;
	MessageEventSource<OptionNbboQuote::Key, OptionNbboQuote> optionnbboquote;
	MessageEventSource<OptionPrint::Key, OptionPrint> optionprint;
	MessageEventSource<OptionRiskFactor::Key, OptionRiskFactor> optionriskfactor;
	MessageEventSource<SpreadBookQuote::Key, SpreadBookQuote> spreadbookquote;
	MessageEventSource<StockBookQuote::Key, StockBookQuote> stockbookquote;
	MessageEventSource<StockExchImbalance::Key, StockExchImbalance> stockexchimbalance;
	MessageEventSource<StockMarketSummary::Key, StockMarketSummary> stockmarketsummary;
	MessageEventSource<StockPrint::Key, StockPrint> stockprint;			

	impl(SysEnvironment environment, IPAddress if_addr)
		: environment(environment), frame_handler(environment), if_addr(if_addr)
	{
	}

	~impl()
	{
		receivers.clear();
		channels.clear();
	}
};

SRDataFeedEngine::SRDataFeedEngine(in_addr device_address)
	: impl_{ new impl(SysEnvironment::V7_Stable, device_address) }
{
	impl_->frame_handler.RegisterMessageHandler(&impl_->futurebookquote, { MessageType::FutureBookQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->futureprint, { MessageType::FuturePrint });
	impl_->frame_handler.RegisterMessageHandler(&impl_->indexquote, { MessageType::IndexQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->livesurfaceatm, { MessageType::LiveSurfaceAtm });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionimpliedquote, { MessageType::OptionImpliedQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionnbboquote, { MessageType::OptionNbboQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionprint, { MessageType::OptionPrint });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionriskfactor, { MessageType::OptionRiskFactor });
	impl_->frame_handler.RegisterMessageHandler(&impl_->spreadbookquote, { MessageType::SpreadBookQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockbookquote, { MessageType::StockBookQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockexchimbalance, { MessageType::StockExchImbalance });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockmarketsummary, { MessageType::StockMarketSummary });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockprint, { MessageType::StockPrint });
}

SRDataFeedEngine::~SRDataFeedEngine()
{
}

void SRDataFeedEngine::MakeCacheRequest(initializer_list<MessageType> message_types)
{
	int32_t ipport = 2280 + (static_cast<int32_t>(impl_->environment) * 1000);

	initializer_list<IPEndPoint> endpoints =
	{
		IPEndPoint(string("198.102.4.145"), ipport),
		IPEndPoint(string("198.102.4.146"), ipport)
	};

	for (auto ep : endpoints)
	{
		auto send_channel = make_shared<Channel>("tcp.send(" + ep.label() + ")");
		auto receive_channel = make_shared<Channel>("tcp.recv(" + ep.label() + ")");

		try
		{
			CacheClient cache_client(impl_->environment, ep, impl_->frame_handler, receive_channel, send_channel);
			cache_client.SendRequest(message_types);
			cache_client.ReadResponse();

			break;
		}
		catch (const std::exception& e)
		{
			SR_TRACE_ERROR("cache request error", e.what());
		}
		catch (...)
		{
			SR_TRACE_ERROR("unknown cache request error");
		}
	}
}

IPEndPoint SRDataFeedEngine::GetIPEndPoint(DataChannel channel)
{
	int32_t envnum = 30 + static_cast<int32_t>(impl_->environment);
	int32_t chnum = static_cast<int32_t>(channel);
	int32_t ipport = 22000 + (envnum * 250) + chnum;

	string ipaddr;

	ipaddr = "233.74.249." + to_string(chnum);

	IPEndPoint ep(ipaddr, ipport);

	return ep;
}

void SRDataFeedEngine::CreateThreadGroup(Protocol protocol, initializer_list<DataChannel> channels)
{
	unique_ptr<Receiver<Channel>> receiver;

	if (protocol == Protocol::DBL)
	{
		receiver = unique_ptr<Receiver<Channel>>(
			dynamic_cast<Receiver<Channel>*>(new DBL::Receiver<Channel>(impl_->if_addr, &impl_->frame_handler)));
	}
	else if (protocol == Protocol::UDP)
	{
		receiver = unique_ptr<Receiver<Channel>>(
			dynamic_cast<Receiver<Channel>*>(new UDP::Receiver<Channel>(impl_->if_addr, &impl_->frame_handler)));
	}
	else
	{
		throw std::invalid_argument("Unsupported protocol " + std::to_string(static_cast<int>(protocol)));
	}

	for (auto c : channels)
	{
		IPEndPoint ep = GetIPEndPoint(c);

		shared_ptr<Channel> channel;
		
		if (protocol == Protocol::DBL)
		{
			channel = make_shared<Channel>("dbl.recv(" + ep.label() + ")");
		}
		else if (protocol == Protocol::UDP)
		{
			channel = make_shared<Channel>("udp.recv(" + ep.label() + ")");
		}
		impl_->channels.push_back(channel);
		receiver->AddChannel(ep, channel);
	}

	impl_->receivers.push_back(move(receiver));
}

void SRDataFeedEngine::Start()
{
	static bool started = false;

	if (started) return;

	for (auto& receiver : impl_->receivers)
	{
		receiver->Start();
	}

	started = true;
}

void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<FutureBookQuote>> observer) { impl_->futurebookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<FuturePrint>> observer) { impl_->futureprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<IndexQuote>> observer) { impl_->indexquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionRiskFactor>> observer) { impl_->optionriskfactor.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<SpreadBookQuote>> observer) { impl_->spreadbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockExchImbalance>> observer) { impl_->stockexchimbalance.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockMarketSummary>> observer) { impl_->stockmarketsummary.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }

void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<FutureBookQuote>> observer) { impl_->futurebookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<FuturePrint>> observer) { impl_->futureprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<IndexQuote>> observer) { impl_->indexquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionRiskFactor>> observer) { impl_->optionriskfactor.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<SpreadBookQuote>> observer) { impl_->spreadbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockExchImbalance>> observer) { impl_->stockexchimbalance.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockMarketSummary>> observer) { impl_->stockmarketsummary.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }

void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<FutureBookQuote>> observer) { impl_->futurebookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<FuturePrint>> observer) { impl_->futureprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<IndexQuote>> observer) { impl_->indexquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionRiskFactor>> observer) { impl_->optionriskfactor.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<SpreadBookQuote>> observer) { impl_->spreadbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockExchImbalance>> observer) { impl_->stockexchimbalance.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockMarketSummary>> observer) { impl_->stockmarketsummary.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }
