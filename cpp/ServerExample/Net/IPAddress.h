#pragma once

#include "stdafx.h"

#include <string>
#include <cstring>
#include <cctype>
#include <stdexcept>

#ifndef _WINDOWS_
#	include <netdb.h>
#	include <sys/types.h>
#	include <sys/socket.h>
#	include <netinet/in.h>
#	include <arpa/inet.h>
#endif

namespace SpiderRock
{
	namespace Net
	{
		class IPAddress
		{
			in_addr address_;

			static in_addr GetAddress(const std::string& hostname)
			{
				struct in_addr addr;

				std::memset(&addr, 0, sizeof addr);

				if (std::isalpha(hostname[0]))
				{
					struct hostent* record = gethostbyname(hostname.c_str());
					if (record == nullptr) throw std::runtime_error("Unable to resolve hostname");
					addr.s_addr = *(u_long *)record->h_addr_list[0];
				}
				else
				{
					addr.s_addr = inet_addr(hostname.c_str());
				}

				return addr;
			}

		public:
			IPAddress(const std::string& address)
				: IPAddress(GetAddress(address))
			{
			}

			IPAddress(const IPAddress& address)
				: address_(address.address_)
			{
			}

			IPAddress(in_addr address)
				: address_(address)
			{
			}

			~IPAddress()
			{
			}

			inline in_addr address() const { return address_; }

			inline operator std::string() const { return std::string(inet_ntoa(address_)); }
			inline operator in_addr() const { return address_; }
			inline bool operator == (const IPAddress& other) const { return address_.s_addr == other.address_.s_addr; }
		};
	}
}
