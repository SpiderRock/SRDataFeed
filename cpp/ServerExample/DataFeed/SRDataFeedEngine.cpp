// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#include "SRDataFeedEngine.h"

#include <string>
#include <memory>
#include <vector>
#include <initializer_list>

#include "Net/IPAddress.h"
#include "Net/IPEndPoint.h"
#include "Net/Proto/Receiver.h"
#include "Net/Proto/DBL/Receiver.h"
#include "Net/Proto/UDP/Receiver.h"
#include "MessageEventSource.h"
#include "FrameHandler.h"
#include "CacheClient.h"
#include "EventObserver.h"

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
	MessageEventSource<LiveSurfaceAtm::Key, LiveSurfaceAtm> livesurfaceatm;
	MessageEventSource<OptionCloseMark::Key, OptionCloseMark> optionclosemark;
	MessageEventSource<OptionCloseQuote::Key, OptionCloseQuote> optionclosequote;
	MessageEventSource<OptionImpliedQuote::Key, OptionImpliedQuote> optionimpliedquote;
	MessageEventSource<OptionNbboQuote::Key, OptionNbboQuote> optionnbboquote;
	MessageEventSource<OptionOpenMark::Key, OptionOpenMark> optionopenmark;
	MessageEventSource<OptionPrint::Key, OptionPrint> optionprint;
	MessageEventSource<OptionSettlementMark::Key, OptionSettlementMark> optionsettlementmark;
	MessageEventSource<SpreadQuote::Key, SpreadQuote> spreadquote;
	MessageEventSource<StockBookQuote::Key, StockBookQuote> stockbookquote;
	MessageEventSource<StockCloseMark::Key, StockCloseMark> stockclosemark;
	MessageEventSource<StockCloseQuote::Key, StockCloseQuote> stockclosequote;
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

SRDataFeedEngine::SRDataFeedEngine(SysEnvironment environment, in_addr device_address)
	: impl_{ new impl(environment, device_address) }
{
	impl_->frame_handler.RegisterMessageHandler(&impl_->futurebookquote, { MessageType::FutureBookQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->futureprint, { MessageType::FuturePrint });
	impl_->frame_handler.RegisterMessageHandler(&impl_->futuresettlementmark, { MessageType::FutureSettlementMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->livesurfaceatm, { MessageType::LiveSurfaceAtm });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionclosemark, { MessageType::OptionCloseMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionclosequote, { MessageType::OptionCloseQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionimpliedquote, { MessageType::OptionImpliedQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionnbboquote, { MessageType::OptionNbboQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionopenmark, { MessageType::OptionOpenMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionprint, { MessageType::OptionPrint });
	impl_->frame_handler.RegisterMessageHandler(&impl_->optionsettlementmark, { MessageType::OptionSettlementMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->spreadquote, { MessageType::SpreadQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockbookquote, { MessageType::StockBookQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockclosemark, { MessageType::StockCloseMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockclosequote, { MessageType::StockCloseQuote });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockopenmark, { MessageType::StockOpenMark });
	impl_->frame_handler.RegisterMessageHandler(&impl_->stockprint, { MessageType::StockPrint });
}

SRDataFeedEngine::~SRDataFeedEngine()
{
}

void SRDataFeedEngine::MakeCacheRequest(const IPEndPoint& end_point, initializer_list<MessageType> message_types)
{
	auto send_channel = make_shared<Channel>("tcp.send(" + end_point.label() + ")");
	auto receive_channel = make_shared<Channel>("tcp.recv(" + end_point.label() + ")");
	impl_->channels.push_back(send_channel);
	impl_->channels.push_back(receive_channel);

	CacheClient cache_client(impl_->environment, end_point, impl_->frame_handler, receive_channel, send_channel);
	cache_client.SendRequest(message_types);
	cache_client.ReadResponse();
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
		uint16_t port = 40000 + (30 + static_cast<uint16_t>(impl_->environment)) * 500 + static_cast<uint16_t>(c);
		string address = "233.74.249." + to_string(static_cast<uint16_t>(c));
		IPEndPoint ep(address, port);

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

void SRDataFeedEngine::RegisterObserver(std::shared_ptr<void> observer)
{
	void* observer_ptr = observer.get();
	FutureBookQuote* fbq = dynamic_cast<FutureBookQuote*>(observer_ptr);
	if (dynamic_pointer_cast<CreateEventObserver<FutureBookQuote>>(observer)) impl_->futurebookquote.RegisterObserver(dynamic_pointer_cast<CreateEventObserver<FutureBookQuote>>(observer));
}
