#pragma once

#include "stdafx.h"

#include <string>
#include <stdexcept>
#include <memory>
#include <initializer_list>

#ifndef _WINDOWS_
#	include <sys/types.h>
#	include <sys/socket.h>
#	include <netinet/in.h>
#	include <arpa/inet.h>
#endif

#include "SpiderRock/SpiderStream/CodeGen/MessageType.h"
#include "SpiderRock/SpiderStream/MessageHandler.h"
#include "SpiderRock/SpiderStream/FrameHandler.h"
#include "SpiderRock/Net/IPEndPoint.h"

namespace SpiderRock
{
	namespace SpiderStream
	{
		class CacheClientException : public std::runtime_error
		{
		public:
			CacheClientException(const std::string& message) : std::runtime_error(message) { }
			~CacheClientException() { }
		};

		class CacheClient : public MessageHandler
		{
			SysEnvironment environment_;
			SpiderRock::Net::IPEndPoint end_point_;
			FrameHandler& frame_handler_;
			bool cancel_requested_;
			std::shared_ptr<Channel> receive_channel_;
			std::shared_ptr<Channel> send_channel_;

#ifdef _WINDOWS_
			SOCKET socket_;
#else
			int socket_;
#endif

			void Connect();
			void Disconnect();

		public:
			CacheClient(SysEnvironment environment, const SpiderRock::Net::IPEndPoint& end_point, FrameHandler& frame_handler, std::shared_ptr<Channel> receive_channel, std::shared_ptr<Channel> send_channel);
			~CacheClient();

			void SendRequest(std::initializer_list<MessageType> message_types);
			void ReadResponse();

			void Handle(Header* header, uint64_t timestamp);
		};
	}
}
