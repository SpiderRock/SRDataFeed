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
	MessageEventSource<FutureSettlementMark::Key, FutureSettlementMark> futuresettlementmark;
	MessageEventSource<IndexClose::Key, IndexClose> indexclose;
	MessageEventSource<IndexQuote::Key, IndexQuote> indexquote;
	MessageEventSource<LiveSurfaceAtm::Key, LiveSurfaceAtm> livesurfaceatm;
	MessageEventSource<OptionCloseMark::Key, OptionCloseMark> optionclosemark;
	MessageEventSource<OptionCloseQuote::Key, OptionCloseQuote> optionclosequote;
	MessageEventSource<OptionImpliedQuote::Key, OptionImpliedQuote> optionimpliedquote;
	MessageEventSource<OptionNbboQuote::Key, OptionNbboQuote> optionnbboquote;
	MessageEventSource<OptionOpenMark::Key, OptionOpenMark> optionopenmark;
	MessageEventSource<OptionPrint::Key, OptionPrint> optionprint;
	MessageEventSource<OptionPrint2::Key, OptionPrint2> optionprint2;
	MessageEventSource<OptionRiskFactor::Key, OptionRiskFactor> optionriskfactor;
	MessageEventSource<OptionSettlementMark::Key, OptionSettlementMark> optionsettlementmark;
	MessageEventSource<StockBookQuote::Key, StockBookQuote> stockbookquote;
	MessageEventSource<StockCloseMark::Key, StockCloseMark> stockclosemark;
	MessageEventSource<StockCloseQuote::Key, StockCloseQuote> stockclosequote;
	MessageEventSource<StockExchImbalance::Key, StockExchImbalance> stockexchimbalance;
	MessageEventSource<StockOpenMark::Key, StockOpenMark> stockopenmark;
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
	: impl_{ new impl(SysEnvironment::Blue, device_address) }
{
	impl_->frame_handler.RegisterMessageHandler(&impl_->futurebookquote, { MessageType::FutureBookQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->futureprint, { MessageType::FuturePrint });
	impl_->frame_handler.RegisterMessageHandler(&impl_->futuresettlementmark, { MessageType::FutureSettlementMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->indexclose, { MessageType::IndexClose });
	impl_->frame_handler.RegisterMessageHandler(&impl_->indexquote, { MessageType::IndexQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->livesurfaceatm, { MessageType::LiveSurfaceAtm });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionclosemark, { MessageType::OptionCloseMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionclosequote, { MessageType::OptionCloseQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionimpliedquote, { MessageType::OptionImpliedQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionnbboquote, { MessageType::OptionNbboQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionopenmark, { MessageType::OptionOpenMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionprint, { MessageType::OptionPrint });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionprint2, { MessageType::OptionPrint2 });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionriskfactor, { MessageType::OptionRiskFactor });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionsettlementmark, { MessageType::OptionSettlementMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockbookquote, { MessageType::StockBookQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockclosemark, { MessageType::StockCloseMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockclosequote, { MessageType::StockCloseQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockexchimbalance, { MessageType::StockExchImbalance });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockopenmark, { MessageType::StockOpenMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockprint, { MessageType::StockPrint });
}

SRDataFeedEngine::~SRDataFeedEngine()
{
}

void SRDataFeedEngine::MakeCacheRequest(initializer_list<MessageType> message_types)
{
	int32_t ipport = 2340 + (static_cast<int32_t>(impl_->environment) * 1000);

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

	if (impl_->environment == SysEnvironment::Red)
	{
		ipaddr = "233.74.249." + to_string(chnum);
	}
	else if (impl_->environment == SysEnvironment::Blue)
	{
		ipaddr = "233.117.185." + to_string(chnum);
	}
	else
	{
		throw std::runtime_error("Unsupported SysEnvironment " + std::to_string(static_cast<int>(impl_->environment)));
	}

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
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<FutureSettlementMark>> observer) { impl_->futuresettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<IndexClose>> observer) { impl_->indexclose.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<IndexQuote>> observer) { impl_->indexquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionCloseMark>> observer) { impl_->optionclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionCloseQuote>> observer) { impl_->optionclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionOpenMark>> observer) { impl_->optionopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionPrint2>> observer) { impl_->optionprint2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionRiskFactor>> observer) { impl_->optionriskfactor.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionSettlementMark>> observer) { impl_->optionsettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockCloseMark>> observer) { impl_->stockclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockCloseQuote>> observer) { impl_->stockclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockExchImbalance>> observer) { impl_->stockexchimbalance.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockOpenMark>> observer) { impl_->stockopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }

void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<FutureBookQuote>> observer) { impl_->futurebookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<FuturePrint>> observer) { impl_->futureprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<FutureSettlementMark>> observer) { impl_->futuresettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<IndexClose>> observer) { impl_->indexclose.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<IndexQuote>> observer) { impl_->indexquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionCloseMark>> observer) { impl_->optionclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionCloseQuote>> observer) { impl_->optionclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionOpenMark>> observer) { impl_->optionopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionPrint2>> observer) { impl_->optionprint2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionRiskFactor>> observer) { impl_->optionriskfactor.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionSettlementMark>> observer) { impl_->optionsettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockCloseMark>> observer) { impl_->stockclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockCloseQuote>> observer) { impl_->stockclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockExchImbalance>> observer) { impl_->stockexchimbalance.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockOpenMark>> observer) { impl_->stockopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }

void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<FutureBookQuote>> observer) { impl_->futurebookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<FuturePrint>> observer) { impl_->futureprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<FutureSettlementMark>> observer) { impl_->futuresettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<IndexClose>> observer) { impl_->indexclose.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<IndexQuote>> observer) { impl_->indexquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionCloseMark>> observer) { impl_->optionclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionCloseQuote>> observer) { impl_->optionclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionOpenMark>> observer) { impl_->optionopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionPrint2>> observer) { impl_->optionprint2.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionRiskFactor>> observer) { impl_->optionriskfactor.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionSettlementMark>> observer) { impl_->optionsettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockCloseMark>> observer) { impl_->stockclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockCloseQuote>> observer) { impl_->stockclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockExchImbalance>> observer) { impl_->stockexchimbalance.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockOpenMark>> observer) { impl_->stockopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }
