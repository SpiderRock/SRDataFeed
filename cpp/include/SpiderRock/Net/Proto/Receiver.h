#pragma once

#include "stdafx.h"

#include <memory>

#include "SpiderRock/Net/IPEndPoint.h"

namespace SpiderRock
{
	namespace Net
	{
		namespace Proto
		{
			template<class _Tcontext> class Receiver
			{
			public:
				virtual ~Receiver() { }
				virtual void AddChannel(const SpiderRock::Net::IPEndPoint& end_point, std::shared_ptr<_Tcontext> context) = 0;
				virtual void Start() = 0;
				virtual void Stop() = 0;
			};
		}
	}
}
