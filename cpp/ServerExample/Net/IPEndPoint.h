#pragma once

#include "stdafx.h"

#include <string>
#include <stdexcept>
#include <cstring>

#include "IPAddress.h"

#ifndef _WINDOWS_
#	include <netinet/in.h>
#	include <arpa/inet.h>
#	include <sys/socket.h>
#endif

namespace SpiderRock
{
	namespace Net
	{
		class IPEndPoint
		{
			IPAddress address_;
			uint32_t port_;
			std::string label_;

			static std::string GetHostname(const std::string& end_point)
			{
				auto colon = end_point.find_last_of(":");

				if (colon < 1)
				{
					throw std::invalid_argument("end_point argument must be of format (HOSTNAME|IPADDRESS):PORT");
				}

				return end_point.substr(0, colon);
			}

			static uint16_t GetPort(const std::string& end_point)
			{
				auto colon = end_point.find_last_of(":");

				if (colon < 1)
				{
					throw std::invalid_argument("end_point argument must be of format (HOSTNAME|IPADDRESS):PORT");
				}

				return (uint16_t)stoi(end_point.substr(colon + 1));
			}

			static std::string CreateLabel(const IPAddress& address, uint16_t port)
			{
				return std::string(inet_ntoa(address)) + ":" + std::to_string(port);
			}

		public:
			IPEndPoint(const std::string& end_point) : 
				address_(GetHostname(end_point)), 
				port_(GetPort(end_point)),
				label_(CreateLabel(address_, port_))
			{
			}

			IPEndPoint(const IPAddress& hostname, uint16_t port) :
				address_(hostname), 
				port_(port), 
				label_(CreateLabel(address_, port_))
			{
			}

			IPEndPoint(const IPEndPoint& end_point) : 
				address_(end_point.address_), 
				port_(end_point.port_), 
				label_(CreateLabel(address_, port_))
			{
			}

			~IPEndPoint()
			{
			}

			inline uint32_t port() const { return port_; }
			inline const IPAddress& address() const { return address_; }
			inline std::string label() const { return label_; }

			inline operator sockaddr_in() const
			{
				sockaddr_in addr;
				memset(&addr, 0, sizeof addr);
				addr.sin_addr = address_;
				addr.sin_port = htons(port_);
				addr.sin_family = AF_INET;
				return addr;
			}

			inline operator std::string() { return label_; }

			inline bool operator == (const IPEndPoint& other) const
			{
				return port_ == other.port_ && address_ == other.address_;
			}
		};
	}
}
