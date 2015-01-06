#pragma once

#include "stdafx.h"

#ifdef _WINDOWS_
#	include <winsock.h>
#else
#	include <netinet/in.h>
#endif

namespace SpiderRock
{
	namespace Net
	{
		namespace Proto
		{
			namespace DBL
			{
				template<class _Tcontext> class ReadHandler
				{
				public:
					virtual int Handle(uint8_t* buffer, uint32_t length, _Tcontext* context, const sockaddr_in& source) = 0;
				};
			}
		}
	}
}