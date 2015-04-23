#include "SpiderRock/DataFeed/CacheClient.h"

#include "SpiderRock/DataFeed/AdminMessages.h"

#ifndef _WINDOWS_
#	include <netinet/tcp.h>
#	include <unistd.h>
#	include <fcntl.h>
#	include <netdb.h>
#	include <sys/types.h>
#	include <sys/socket.h>
#	include <netinet/in.h>
#	include <arpa/inet.h>
#	include <stdio.h>
#	include <errno.h>
#endif

#if ((__GNUC__ * 100) + __GNUC_MINOR__) >= 402
#define GCC_DIAG_STR(s) #s
#define GCC_DIAG_JOINSTR(x,y) GCC_DIAG_STR(x ## y)
# define GCC_DIAG_DO_PRAGMA(x) _Pragma (#x)
# define GCC_DIAG_PRAGMA(x) GCC_DIAG_DO_PRAGMA(GCC diagnostic x)
# if ((__GNUC__ * 100) + __GNUC_MINOR__) >= 406
#  define GCC_DIAG_OFF(x) GCC_DIAG_PRAGMA(push) \
	GCC_DIAG_PRAGMA(ignored GCC_DIAG_JOINSTR(-W,x))
#  define GCC_DIAG_ON(x) GCC_DIAG_PRAGMA(pop)
# else
#  define GCC_DIAG_OFF(x) GCC_DIAG_PRAGMA(ignored GCC_DIAG_JOINSTR(-W,x))
#  define GCC_DIAG_ON(x)  GCC_DIAG_PRAGMA(warning GCC_DIAG_JOINSTR(-W,x))
# endif
#else
# define GCC_DIAG_OFF(x)
# define GCC_DIAG_ON(x)
#endif

using namespace SpiderRock::DataFeed;
using std::vector;
using std::string;
using std::wstring;
using std::initializer_list;
using std::shared_ptr;
using SpiderRock::Net::IPEndPoint;
using SpiderRock::ThrowLastErrorAs;

const uint16_t MAX_MESSAGE_LENGTH = 64000;

CacheClient::CacheClient(SysEnvironment environment, const IPEndPoint& end_point, FrameHandler& frame_handler, shared_ptr<Channel> receive_channel, shared_ptr<Channel> send_channel) :
	environment_		(environment),
	end_point_		(end_point),
	frame_handler_		(frame_handler),
	cancel_requested_	(false),
	receive_channel_	(receive_channel),
	send_channel_		(send_channel),
	socket_			(0)
{
}

CacheClient::~CacheClient()
{
	Disconnect();
}

#ifdef _WINDOWS_

void CacheClient::Connect()
{
	WSADATA wsaData;
	if (WSAStartup(MAKEWORD(2, 2), &wsaData) == SOCKET_ERROR)
	{
		ThrowLastErrorAs<CacheClientException>();
	}

	sockaddr_in ep = end_point_;
	socket_ = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (socket_ == INVALID_SOCKET)
	{
		ThrowLastErrorAs<CacheClientException>();
	}

	u_long mode = 0; /* Blocking */
	if (ioctlsocket(socket_, FIONBIO, &mode) == SOCKET_ERROR)
	{
		ThrowLastErrorAs<CacheClientException>();
	}

	int flag = 1;
	if (setsockopt(socket_, IPPROTO_TCP, TCP_NODELAY, reinterpret_cast<char*>(&flag), sizeof(flag)) == SOCKET_ERROR)
	{
		ThrowLastErrorAs<CacheClientException>();
	}

	auto addr = reinterpret_cast<sockaddr*>(&ep);
	if (connect(socket_, const_cast<const sockaddr*>(addr), sizeof ep) != 0)
	{
		ThrowLastErrorAs<CacheClientException>();
	}
}

void CacheClient::Disconnect()
{
	if (socket_ == INVALID_SOCKET) return;

	if (closesocket(socket_) == SOCKET_ERROR || WSACleanup() == SOCKET_ERROR)
	{
		ThrowLastErrorAs<CacheClientException>();
	}

	socket_ = INVALID_SOCKET;
}

#else

void CacheClient::Connect()
{
	sockaddr_in ep = end_point_;
	socket_ = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (socket_ < 0) 
	{
		ThrowLastErrorAs<CacheClientException>();
	}

	int opts = fcntl(socket_, F_GETFL);
	if (opts < 0) 
	{
		ThrowLastErrorAs<CacheClientException>();
	}
	if (fcntl(socket_, F_SETFL, opts & (~O_NONBLOCK)) < 0) 
	{
		ThrowLastErrorAs<CacheClientException>();
	}

	int flag = 1;
	if (setsockopt(socket_, IPPROTO_TCP, TCP_NODELAY, reinterpret_cast<char*>(&flag), sizeof(flag)) < 0)
	{
		ThrowLastErrorAs<CacheClientException>();
	}

	auto addr = reinterpret_cast<sockaddr*>(&ep);
	if (connect(socket_, const_cast<const sockaddr*>(addr), sizeof ep) < 0)
	{
		ThrowLastErrorAs<CacheClientException>();
	}
}

void CacheClient::Disconnect()
{
	if (socket_ >= 0)
	{
		if (close(socket_) < 0)
		{
			ThrowLastErrorAs<CacheClientException>();
		}
		socket_ = 0;
	}
}
#endif

GCC_DIAG_OFF(unused-parameter);
void CacheClient::Handle(Header* header, uint64_t timestamp)
{
	CacheComplete cache_complete;
	cache_complete.Decode(header);

	if (cache_complete.result().length() == 0)
	{
		throw CacheClientException("Cache server did not specify a result");
	}

	auto error_prefix = string("Error: ");
	auto result = cache_complete.result().str();

	if (result->substr(0, error_prefix.length()) == error_prefix)
	{
		throw CacheClientException(result->substr(error_prefix.length()));
	}

	cancel_requested_ = true;
}
GCC_DIAG_ON(unused-parameter);

void CacheClient::SendRequest(initializer_list<MessageType> message_types)
{
	uint8_t buf[MAX_MESSAGE_LENGTH];

	GetCache get_cache;
	get_cache.requestID(1);
	vector<GetCache::MsgType> msg_types;
	for (MessageType t : message_types)
	{
		GetCache::MsgType i;
		i.msgtype(static_cast<UShort>(t));
		msg_types.push_back(i);
	}
	get_cache.header().environment = environment_;
	get_cache.msgtype(msg_types);
	uint16_t length = get_cache.Encode(&buf[0]);

	Connect();

	int sent = send(socket_, reinterpret_cast<char*>(&buf[0]), length, 0);
	send_channel_->IncrementMessageTypeCounters(MessageType::GetCache, length);
	if (sent != length) 
	{
		ThrowLastErrorAs<CacheClientException>();
	}
}

void CacheClient::ReadResponse()
{
	uint8_t buf[MAX_MESSAGE_LENGTH];
	int roffset = 0;

	frame_handler_.RegisterMessageHandler(this, { MessageType::CacheComplete });

	while (!cancel_requested_)
	{
		int received = recv(socket_, reinterpret_cast<char*>(&buf[roffset]), MAX_MESSAGE_LENGTH - roffset, 0);
		if (received < 1)
		{
			ThrowLastErrorAs<CacheClientException>();
		}

		roffset = frame_handler_.Handle(&buf[0], roffset + received, receive_channel_.get(), end_point_);
		if (roffset < 0)
		{
			throw CacheClientException("Frame handler returned an error code");
		}
	}

	Disconnect();
}
