// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

#include "SRDataFeedEngine.h"
#include "CacheClient.h"
#include "DblLib.h"
#include "MessageEventSource.h"
#include "FrameHandler.h"

using namespace SpiderRock::DataFeed;
using namespace SpiderRock::DataFeed::Myricom;

class SRDataFeedEngine::impl {
public:
	SysEnvironment environment;
	FrameHandler frame_handler;
	vector<unique_ptr<Myricom::DblDevice<Channel>>> devices;
	vector<shared_ptr<Channel>> channels;
	in_addr device_address;

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

	impl(SysEnvironment environment, in_addr device_address)
		: environment(environment), frame_handler(environment), device_address(device_address)
	{
	}
};

SRDataFeedEngine::SRDataFeedEngine(SysEnvironment environment, in_addr device_address)
	: impl_{ new impl(environment, device_address) }
{
	Myricom::DblLib::Initialize();

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
	impl_->devices.clear();
	impl_->channels.clear();
}

void SRDataFeedEngine::MakeCacheRequest(const IPEndPoint& end_point, initializer_list<MessageType> message_types)
{
	auto send_channel = make_shared<Channel>("tcp.send(" + end_point.str() + ")");
	auto receive_channel = make_shared<Channel>("tcp.recv(" + end_point.str() + ")");
	impl_->channels.push_back(send_channel);
	impl_->channels.push_back(receive_channel);

	CacheClient cache_client(impl_->environment, end_point, impl_->frame_handler, receive_channel, send_channel);
	cache_client.SendRequest(message_types);
	cache_client.ReadResponse();
}
			
void SRDataFeedEngine::CreateThreadGroup(initializer_list<UdpChannel> channels)
{
	auto dev = make_unique<DblDevice<Channel>>(impl_->device_address, &impl_->frame_handler);

	for (auto c : channels)
	{
		uint16_t port = 40000 + (30 + static_cast<uint16_t>(impl_->environment)) * 500 + static_cast<uint16_t>(c);
		string address = "233.74.249." + to_string(static_cast<uint16_t>(c));
		IPEndPoint ep(address, port);

		auto channel = make_shared<Channel>("dbl.recv(" + ep.str() + ")");
		impl_->channels.push_back(channel);
		dev->AddChannel(ep, channel);
	}

	impl_->devices.push_back(move(dev));
}

void SRDataFeedEngine::Start()
{
	static bool started = false;

	if (started) return;

	for (auto& dev : impl_->devices)
	{
		dev->Start();
	}

	started = true;
}

void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<FutureBookQuote>> observer) { impl_->futurebookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<FuturePrint>> observer) { impl_->futureprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<FutureSettlementMark>> observer) { impl_->futuresettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionCloseMark>> observer) { impl_->optionclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionCloseQuote>> observer) { impl_->optionclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionOpenMark>> observer) { impl_->optionopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<OptionSettlementMark>> observer) { impl_->optionsettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<SpreadQuote>> observer) { impl_->spreadquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockCloseMark>> observer) { impl_->stockclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockCloseQuote>> observer) { impl_->stockclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockOpenMark>> observer) { impl_->stockopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<CreateEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }

void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<FutureBookQuote>> observer) { impl_->futurebookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<FuturePrint>> observer) { impl_->futureprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<FutureSettlementMark>> observer) { impl_->futuresettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionCloseMark>> observer) { impl_->optionclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionCloseQuote>> observer) { impl_->optionclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionOpenMark>> observer) { impl_->optionopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<OptionSettlementMark>> observer) { impl_->optionsettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<SpreadQuote>> observer) { impl_->spreadquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockCloseMark>> observer) { impl_->stockclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockCloseQuote>> observer) { impl_->stockclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockOpenMark>> observer) { impl_->stockopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<ChangeEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }

void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<FutureBookQuote>> observer) { impl_->futurebookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<FuturePrint>> observer) { impl_->futureprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<FutureSettlementMark>> observer) { impl_->futuresettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<LiveSurfaceAtm>> observer) { impl_->livesurfaceatm.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionCloseMark>> observer) { impl_->optionclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionCloseQuote>> observer) { impl_->optionclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionImpliedQuote>> observer) { impl_->optionimpliedquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionNbboQuote>> observer) { impl_->optionnbboquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionOpenMark>> observer) { impl_->optionopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionPrint>> observer) { impl_->optionprint.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<OptionSettlementMark>> observer) { impl_->optionsettlementmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<SpreadQuote>> observer) { impl_->spreadquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockBookQuote>> observer) { impl_->stockbookquote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockCloseMark>> observer) { impl_->stockclosemark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockCloseQuote>> observer) { impl_->stockclosequote.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockOpenMark>> observer) { impl_->stockopenmark.RegisterObserver(observer); }
void SRDataFeedEngine::RegisterObserver(shared_ptr<UpdateEventObserver<StockPrint>> observer) { impl_->stockprint.RegisterObserver(observer); }
