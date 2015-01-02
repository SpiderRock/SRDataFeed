#pragma once

#include "stdafx.h"

#if defined _WINDOWS_
#	include <winsock.h>
#else
#	include <sys/types.h>
#	include <sys/socket.h>
#	include <netinet/in.h>
#	include <arpa/inet.h>
#endif

#include "MessageBus.h"
#include "MessageHandler.h"
#include "FrameHandler.h"
#include "IPEndPoint.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		class CacheClientException : public runtime_error
		{
		public:
			CacheClientException(const string& message) : runtime_error(message) { }
			~CacheClientException() { }
		};

		class CacheClient : public MessageHandler
		{
			SysEnvironment environment_;
			IPEndPoint end_point_;
			FrameHandler& frame_handler_;
			bool cancel_requested_;
			Channel receive_channel_;
			Channel send_channel_;
			vector<MessageType> handled_types_;

#ifdef _WINDOWS_
			SOCKET socket_;
#else
			int socket_;
#endif

			void ThrowLastError();
			void Connect();
			void Disconnect();

		public:
			CacheClient(SysEnvironment environment, const IPEndPoint& end_point, FrameHandler& frame_handler);
			~CacheClient();

			void SendRequest(initializer_list<MessageType> message_types);
			void ReadResponse();

			void Handle(Header* header, uint64_t timestamp);
			const vector<MessageType>& HandledTypes() const;
		};
	}
}
