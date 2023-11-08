#pragma once

#include "stdafx.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		template<class _Tmessage> class CreateEventObserver
		{
		public:
			virtual void OnCreate(const _Tmessage& created) = 0;
		};

		template<class _Tmessage> class ChangeEventObserver
		{
		public:
			virtual void OnChange(const _Tmessage& changed) = 0;
		};

		template<class _Tmessage> class UpdateEventObserver
		{
		public:
			virtual void OnUpdate(const _Tmessage& received, const _Tmessage& current) = 0;
		};
	}
}