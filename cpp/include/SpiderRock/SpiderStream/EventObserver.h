#pragma once

#include "stdafx.h"

namespace SpiderRock
{
	namespace SpiderStream
	{
		template<class _Tmessage> class CreateEventObserver
		{
		public:
			virtual void OnCreate(const _Tmessage& created, const bool drops) = 0;
		};

		template<class _Tmessage> class ChangeEventObserver
		{
		public:
			virtual void OnChange(const _Tmessage& changed, const bool drops) = 0;
		};

		template<class _Tmessage> class UpdateEventObserver
		{
		public:
			virtual void OnUpdate(const _Tmessage& received, const _Tmessage& current, const bool drops) = 0;
		};
	}
}