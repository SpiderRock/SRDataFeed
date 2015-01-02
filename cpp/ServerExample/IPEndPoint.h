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

namespace SpiderRock
{
	namespace Net
	{
		class IPEndPoint
		{
			in_addr address_;
			uint32_t port_;
			std::string label_;

			inline static in_addr GetAddress(const std::string& hostname)
			{
				const char* h = hostname.c_str();
				struct hostent* record;
				struct in_addr addr;

				memset(&addr, 0, sizeof addr);

				if (isalpha(h[0]))
				{
					record = gethostbyname(h);
					if (record == nullptr) throw std::runtime_error("Unable to resolve hostname");
					addr.s_addr = *(u_long *)record->h_addr_list[0];
				}
				else
				{
					addr.S_un.S_addr = inet_addr(h);
				}

				return addr;
			}

			inline static std::string GetHostname(const std::string& end_point)
			{
				auto colon = end_point.find_last_of(":");

				if (colon < 1)
				{
					throw std::invalid_argument("end_point argument must be of format (HOSTNAME|IPADDRESS):PORT");
				}

				return end_point.substr(0, colon);
			}

			inline static uint16_t GetPort(const std::string& end_point)
			{
				auto colon = end_point.find_last_of(":");

				if (colon < 1)
				{
					throw std::invalid_argument("end_point argument must be of format (HOSTNAME|IPADDRESS):PORT");
				}

				return (uint16_t)stoi(end_point.substr(colon + 1));
			}

			inline static std::string CreateLabel(in_addr address, uint16_t port)
			{
				return std::string(inet_ntoa(address)) + ":" + std::to_string(port);
			}

		public:
			IPEndPoint(const std::string& end_point)
				: IPEndPoint(GetAddress(GetHostname(end_point)), GetPort(end_point))
			{
			}

			IPEndPoint(const std::string& hostname, uint16_t port)
				: IPEndPoint(GetAddress(hostname), port)
			{
			}

			IPEndPoint(const IPEndPoint& end_point)
				: IPEndPoint(end_point.address_, end_point.port_)
			{
			}

			IPEndPoint(const sockaddr_in& end_point)
				: IPEndPoint(end_point.sin_addr, end_point.sin_port)
			{
			}

			IPEndPoint(in_addr address, uint16_t port)
				: address_(address), port_(port), label_(CreateLabel(address, port))
			{
			}

			~IPEndPoint()
			{
			}

			inline uint32_t port() const { return port_; }
			inline in_addr address() const { return address_; }
			inline std::string str() const { return label_; }

			inline operator sockaddr_in() const
			{
				sockaddr_in addr;
				memset(&addr, 0, sizeof addr);
				addr.sin_addr = address_;
				addr.sin_port = htons(port_);
				addr.sin_family = AF_INET;
				return addr;
			}

			inline bool operator == (const IPEndPoint& other) const
			{
				return port_ == other.port_ && address_.S_un.S_addr == other.address_.S_un.S_addr;
			}
		};
	}
}