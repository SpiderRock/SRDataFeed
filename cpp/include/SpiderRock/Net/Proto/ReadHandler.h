#pragma once

#include "stdafx.h"

#ifndef _WINDOWS_
#	include <netinet/in.h>
#endif

namespace SpiderRock
{
	namespace Net
	{
		namespace Proto
		{
			template<class _Tcontext> class ReadHandler
			{
			public:
				virtual int Handle(uint8_t* buffer, uint32_t length, _Tcontext* context, const sockaddr_in& source) = 0;
			};
		}
	}
}