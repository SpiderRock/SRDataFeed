#include "CacheClient.h"
#include "Mbus.h"
#include "AdminMessages.h"

#ifdef _WINDOWS_
#	include <winsock.h>
#else
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

using namespace SpiderRock::DataFeed;
using namespace SpiderRock::DataFeed::Mbus;

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

void CacheClient::ThrowLastError()
{
	auto last_error = WSAGetLastError();
	LPWSTR s = nullptr;
	FormatMessage(
		FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM,
		nullptr,
		last_error,
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
		(LPWSTR)&s,
		0,
		nullptr);

	auto wide_str = wstring(s);
	auto exception = CacheClientException(string(wide_str.begin(), wide_str.end()));
	LocalFree(s);
	throw exception;
}

void CacheClient::Connect()
{
	WSADATA wsaData;
	if (WSAStartup(MAKEWORD(2, 2), &wsaData) == SOCKET_ERROR)
	{
		ThrowLastError();
	}

	sockaddr_in ep = end_point_;
	socket_ = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (socket_ == INVALID_SOCKET)
	{
		ThrowLastError();
	}

	u_long mode = 0; /* Blocking */
	if (ioctlsocket(socket_, FIONBIO, &mode) == SOCKET_ERROR)
	{
		ThrowLastError();
	}

	int flag = 1;
	if (setsockopt(socket_, IPPROTO_TCP, TCP_NODELAY, reinterpret_cast<char*>(&flag), sizeof(flag)) == SOCKET_ERROR)
	{
		ThrowLastError();
	}

	auto addr = reinterpret_cast<sockaddr*>(&ep);
	if (connect(socket_, const_cast<const sockaddr*>(addr), sizeof ep) != 0)
	{
		ThrowLastError();
	}
}

void CacheClient::Disconnect()
{
	if (socket_ == INVALID_SOCKET) return;

	if (closesocket(socket_) == SOCKET_ERROR || WSACleanup() == SOCKET_ERROR)
	{
		ThrowLastError();
	}

	socket_ = INVALID_SOCKET;
}

#else

void CacheClient::ThrowLastError()
{
	throw CacheClientException(string(strerror(errno)));
}

void CacheClient::Connect()
{
	sockaddr_in ep = end_point_;
	socket_ = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (socket_ < 0) 
	{
		ThrowLastError();
	}

	int opts = fcntl(socket_, F_GETFL);
	if (opts < 0) 
	{
		ThrowLastError();
	}
	if (fcntl(socket_, F_SETFL, opts & (~O_NONBLOCK)) < 0) 
	{
		ThrowLastError();
	}

	int flag = 1;
	if (setsockopt(socket_, IPPROTO_TCP, TCP_NODELAY, reinterpret_cast<char*>(&flag), sizeof(flag)) < 0)
	{
		ThrowLastError();
	}

	auto addr = reinterpret_cast<sockaddr*>(&ep);
	if (connect(socket_, const_cast<const sockaddr*>(addr), sizeof ep) < 0)
	{
		ThrowLastError();
	}
}

void CacheClient::Disconnect()
{
	if (socket_ >= 0)
	{
		if (close(socket_) < 0)
		{
			ThrowLastError();
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
	if (sent != length) ThrowLastError();
}

void CacheClient::ReadResponse()
{
	uint8_t buf[MAX_MESSAGE_LENGTH];
	int roffset = 0;

	frame_handler_.RegisterMessageHandler(this, { MessageType::CacheComplete });

	while (!cancel_requested_)
	{
		int received = recv(socket_, reinterpret_cast<char*>(&buf[roffset]), MAX_MESSAGE_LENGTH - roffset, 0);
		if (received < 1) ThrowLastError();

		roffset = frame_handler_.Handle(&buf[0], roffset + received, receive_channel_.get(), end_point_);
		if (roffset < 0)
		{
			throw CacheClientException("Frame handler returned an error code");
		}
	}

	Disconnect();
}
