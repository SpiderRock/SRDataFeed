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
	MessageEventSource<FuturePrintMarkup::Key, FuturePrintMarkup> futureprintmarkup;
	MessageEventSource<IndexQuote::Key, IndexQuote> indexquote;
	MessageEventSource<LiveImpliedQuote::Key, LiveImpliedQuote> liveimpliedquote;
	MessageEventSource<LiveSurfaceAtm::Key, LiveSurfaceAtm> livesurfaceatm;
	MessageEventSource<OptionCloseMark::Key, OptionCloseMark> optionclosemark;
	MessageEventSource<OptionExchOrder::Key, OptionExchOrder> optionexchorder;
	MessageEventSource<OptionExchPrint::Key, OptionExchPrint> optionexchprint;
	MessageEventSource<OptionImpliedQuote::Key, OptionImpliedQuote> optionimpliedquote;
	MessageEventSource<OptionNbboQuote::Key, OptionNbboQuote> optionnbboquote;
	MessageEventSource<OptionOpenInterestV2::Key, OptionOpenInterestV2> optionopeninterestv2;
	MessageEventSource<OptionPrint::Key, OptionPrint> optionprint;
	MessageEventSource<OptionPrint2::Key, OptionPrint2> optionprint2;
	MessageEventSource<OptionPrintMarkup::Key, OptionPrintMarkup> optionprintmarkup;
	MessageEventSource<OptionRiskFactor::Key, OptionRiskFactor> optionriskfactor;
	MessageEventSource<ProductDefinitionV2::Key, ProductDefinitionV2> productdefinitionv2;
	MessageEventSource<RootDefinition::Key, RootDefinition> rootdefinition;
	MessageEventSource<SpdrAuctionState::Key, SpdrAuctionState> spdrauctionstate;
	MessageEventSource<SpreadBookQuote::Key, SpreadBookQuote> spreadbookquote;
	MessageEventSource<SpreadExchOrder::Key, SpreadExchOrder> spreadexchorder;
	MessageEventSource<StockBookQuote::Key, StockBookQuote> stockbookquote;
	MessageEventSource<StockExchImbalanceV2::Key, StockExchImbalanceV2> stockexchimbalancev2;
	MessageEventSource<StockImbalance::Key, StockImbalance> stockimbalance;
	MessageEventSource<StockMarketSummary::Key, StockMarketSummary> stockmarketsummary;
	MessageEventSource<StockPrint::Key, StockPrint> stockprint;
	MessageEventSource<StockPrintMarkup::Key, StockPrintMarkup> stockprintmarkup;
	MessageEventSource<TickerDefinition::Key, TickerDefinition> tickerdefinition;
	MessageEventSource<TickerDefinitionV2::Key, TickerDefinitionV2> tickerdefinitionv2;			

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
	impl_->frame_handler.RegisterMessageHandler(&impl_->futureprintmarkup, { MessageType::FuturePrintMarkup });
	impl_->frame_handler.RegisterMessageHandler(&impl_->indexquote, { MessageType::IndexQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->liveimpliedquote, { MessageType::LiveImpliedQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->livesurfaceatm, { MessageType::LiveSurfaceAtm });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionclosemark, { MessageType::OptionCloseMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionexchorder, { MessageType::OptionExchOrder });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionexchprint, { MessageType::OptionExchPrint });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionimpliedquote, { MessageType::OptionImpliedQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionnbboquote, { MessageType::OptionNbboQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionopeninterestv2, { MessageType::OptionOpenInterestV2 });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionprint, { MessageType::OptionPrint });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionprint2, { MessageType::OptionPrint2 });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionprintmarkup, { MessageType::OptionPrintMarkup });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionriskfactor, { MessageType::OptionRiskFactor });
	impl_->frame_handler.RegisterMessageHandler(&impl_->productdefinitionv2, { MessageType::ProductDefinitionV2 });
	impl_->frame_handler.RegisterMessageHandler(&impl_->rootdefinition, { MessageType::RootDefinition });
	impl_->frame_handler.RegisterMessageHandler(&impl_->spdrauctionstate, { MessageType::SpdrAuctionState });
	impl_->frame_handler.RegisterMessageHandler(&impl_->spreadbookquote, { MessageType::SpreadBookQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->spreadexchorder, { MessageType::SpreadExchOrder });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockbookquote, { MessageType::StockBookQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockexchimbalancev2, { MessageType::StockExchImbalanceV2 });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockimbalance, { MessageType::StockImbalance });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockmarketsummary, { MessageType::StockMarketSummary });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockprint, { MessageType::StockPrint });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockprintmarkup, { MessageType::StockPrintMarkup });
	impl_->frame_handler.RegisterMessageHandler(&impl_->tickerdefinition, { MessageType::TickerDefinition });
	impl_->frame_handler.RegisterMessageHandler(&impl_->tickerdefinitionv2, { MessageType::TickerDefinitionV2 });
}

SRDataFeedEngine::~SRDataFeedEngine()
{
}

void SRDataFeedEngine::MakeCacheRequest(initializer_list<MessageType> message_types)
{
	int32_t ipport = 2280 + (static_cast<int32_t>(impl_->environment) * 1000);

	initializer_list<IPEndPoint> endpoints;

    if (impl_->environment == SysEnvironment::V7_Stable)
    {
        endpoints =
        {
            IPEndPoint(string("198.102.4.145"), ipport),
            IPEndPoint(string("198.102.4.146"), ipport)
        };
    }
    else if (impl_->environment == SysEnvironment::V7_Latest)
    {
        endpoints =
        {
            IPEndPoint(string("10.37.42.107"), ipport),
            IPEndPoint(string("10.37.42.163"), ipport)
        };
    }
    else
    {
        SR_TRACE_ERROR("MakeCacheRequest: unsupported environment");
        return;
    }

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

    if (impl_->environment == SysEnvironment::V7_Stable)
    {
        ipaddr = "233.74.249." + to_string(chnum);
    }
    else
    {
        ipaddr = "233.74." + to_string(static_cast<int32_t>(impl_->environment)) + "." + to_string(chnum);
    }

	IPEndPoint ep(ipaddr, ipport);

	return ep;
}

void SRDataFeedEngine::CreateThreadGroup(Protocol protocol, initializer_list<DataChannel> channels)
{
	unique_ptr<Receiver<Channel>> receiver;

	if (protocol == Protocol::UDP)
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
		
		if (protocol == Protocol::UDP)
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
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<FuturePrintMarkup>> observer) { impl_->futureprintmarkup.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<IndexQuote>> observer) { impl_->indexquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<LiveImpliedQuote>> observer) { impl_->liveimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionCloseMark>> observer) { impl_->optionclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionExchOrder>> observer) { impl_->optionexchorder.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionExchPrint>> observer) { impl_->optionexchprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionOpenInterestV2>> observer) { impl_->optionopeninterestv2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionPrint2>> observer) { impl_->optionprint2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionPrintMarkup>> observer) { impl_->optionprintmarkup.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionRiskFactor>> observer) { impl_->optionriskfactor.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<ProductDefinitionV2>> observer) { impl_->productdefinitionv2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<RootDefinition>> observer) { impl_->rootdefinition.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<SpdrAuctionState>> observer) { impl_->spdrauctionstate.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<SpreadBookQuote>> observer) { impl_->spreadbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<SpreadExchOrder>> observer) { impl_->spreadexchorder.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockExchImbalanceV2>> observer) { impl_->stockexchimbalancev2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockImbalance>> observer) { impl_->stockimbalance.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockMarketSummary>> observer) { impl_->stockmarketsummary.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockPrintMarkup>> observer) { impl_->stockprintmarkup.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<TickerDefinition>> observer) { impl_->tickerdefinition.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<TickerDefinitionV2>> observer) { impl_->tickerdefinitionv2.RegisterObserver(observer); }

void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<FutureBookQuote>> observer) { impl_->futurebookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<FuturePrint>> observer) { impl_->futureprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<FuturePrintMarkup>> observer) { impl_->futureprintmarkup.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<IndexQuote>> observer) { impl_->indexquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<LiveImpliedQuote>> observer) { impl_->liveimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionCloseMark>> observer) { impl_->optionclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionExchOrder>> observer) { impl_->optionexchorder.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionExchPrint>> observer) { impl_->optionexchprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionOpenInterestV2>> observer) { impl_->optionopeninterestv2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionPrint2>> observer) { impl_->optionprint2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionPrintMarkup>> observer) { impl_->optionprintmarkup.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionRiskFactor>> observer) { impl_->optionriskfactor.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<ProductDefinitionV2>> observer) { impl_->productdefinitionv2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<RootDefinition>> observer) { impl_->rootdefinition.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<SpdrAuctionState>> observer) { impl_->spdrauctionstate.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<SpreadBookQuote>> observer) { impl_->spreadbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<SpreadExchOrder>> observer) { impl_->spreadexchorder.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockExchImbalanceV2>> observer) { impl_->stockexchimbalancev2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockImbalance>> observer) { impl_->stockimbalance.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockMarketSummary>> observer) { impl_->stockmarketsummary.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockPrintMarkup>> observer) { impl_->stockprintmarkup.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<TickerDefinition>> observer) { impl_->tickerdefinition.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<TickerDefinitionV2>> observer) { impl_->tickerdefinitionv2.RegisterObserver(observer); }

void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<FutureBookQuote>> observer) { impl_->futurebookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<FuturePrint>> observer) { impl_->futureprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<FuturePrintMarkup>> observer) { impl_->futureprintmarkup.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<IndexQuote>> observer) { impl_->indexquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<LiveImpliedQuote>> observer) { impl_->liveimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionCloseMark>> observer) { impl_->optionclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionExchOrder>> observer) { impl_->optionexchorder.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionExchPrint>> observer) { impl_->optionexchprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionOpenInterestV2>> observer) { impl_->optionopeninterestv2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionPrint2>> observer) { impl_->optionprint2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionPrintMarkup>> observer) { impl_->optionprintmarkup.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionRiskFactor>> observer) { impl_->optionriskfactor.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<ProductDefinitionV2>> observer) { impl_->productdefinitionv2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<RootDefinition>> observer) { impl_->rootdefinition.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<SpdrAuctionState>> observer) { impl_->spdrauctionstate.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<SpreadBookQuote>> observer) { impl_->spreadbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<SpreadExchOrder>> observer) { impl_->spreadexchorder.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockExchImbalanceV2>> observer) { impl_->stockexchimbalancev2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockImbalance>> observer) { impl_->stockimbalance.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockMarketSummary>> observer) { impl_->stockmarketsummary.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockPrintMarkup>> observer) { impl_->stockprintmarkup.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<TickerDefinition>> observer) { impl_->tickerdefinition.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<TickerDefinitionV2>> observer) { impl_->tickerdefinitionv2.RegisterObserver(observer); }
