#include "CacheClient.h"

using namespace SpiderRock::DataFeed;

CacheClient::CacheClient(SysEnvironment environment, const IPEndPoint& end_point, FrameHandler& frame_handler) :
	socket_				(0),
	environment_		(environment),
	end_point_			(end_point),
	frame_handler_		(frame_handler),
	cancel_requested_	(false),
	handled_types_		({ CacheComplete::Type }),
	send_channel_		("tcp.send(" + end_point.str() + ")"),
	receive_channel_	("tcp.recv(" + end_point.str() + ")")
{
}

CacheClient::~CacheClient()
{
	Disconnect();
}

const vector<MessageType>& CacheClient::HandledTypes() const
{ 
	return handled_types_;
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
#	error CacheClientException::ThrowLastError() only defined for VC++ so far

void CacheClient::Connect()
{
	end_point_.sin_family = AF_INET;
	socket_ = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (socket_ == INVALID_SOCKET)
	{
		ThrowLastError();
	}

	int opts = fcntl(sock, F_GETFL);
	if (opts < 0)
	{
		ThrowLastError();
	}
	opts = (opts | O_NONBLOCK);
	if (fcntl(sock, F_SETFL, opts) < 0)
	{
		ThrowLastError();
	}

	int flag = 1;
	if (setsockopt(socket_, IPPROTO_TCP, TCP_NODELAY, reinterpret_cast<char*>(&flag), sizeof(flag)) != NO_ERROR)
	{
		ThrowLastError();
	}

	auto addr = reinterpret_cast<sockaddr*>(&end_point_);
	if (connect(socket_, const_cast<const sockaddr*>(addr), sizeof end_point_) != 0)
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

void CacheClient::SendRequest(initializer_list<MessageType> message_types)
{
	uint8_t buf[MAX_MESSAGE_LENGTH];

	GetCache get_cache;
	get_cache.requestID(1);
	vector<GetCache::MsgType> msg_types;
	for (MessageType t : message_types)
	{
		GetCache::MsgType i;
		i.msgtype(t);
		msg_types.push_back(i);
	}
	get_cache.header().env = environment_;
	get_cache.msgtype(msg_types);
	uint16_t length = get_cache.Encode(&buf[0]);

	Connect();

	int sent = send(socket_, reinterpret_cast<char*>(&buf[0]), length, 0);
	if (sent != length) ThrowLastError();
}

void CacheClient::ReadResponse()
{
	uint8_t buf[MAX_MESSAGE_LENGTH];
	int roffset = 0;

	frame_handler_.RegisterMessageHandler(this);

	while (!cancel_requested_)
	{
		int received = recv(socket_, reinterpret_cast<char*>(&buf[roffset]), MAX_MESSAGE_LENGTH - roffset, 0);
		if (received < 1) ThrowLastError();

		roffset = frame_handler_.Handle(&buf[0], roffset + received, &receive_channel_, end_point_);
		if (roffset < 0)
		{
			throw CacheClientException("Frame handler returned an error code");
		}
	}

	Disconnect();
}
