#pragma once

#include "stdafx.h"

#include "Fields.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		enum class SysEnvironment : Enum
		{
			None = 0,
			Stable = 1,
			Beta = 2
		};

		inline bool IsValid(SysEnvironment env)
		{
			return static_cast<int>(env) <= 5; // Only 2 are relevant to this API but 5 exist
		}
	}
}
