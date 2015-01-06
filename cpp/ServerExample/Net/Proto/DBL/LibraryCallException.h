#pragma once

#include "stdafx.h"

#include <stdexcept>
#include <string>

namespace SpiderRock
{
	namespace Net
	{
		namespace Proto
		{
			namespace DBL
			{
				class LibraryCallException : public std::runtime_error
				{
				public:
					LibraryCallException(const std::string& message) : std::runtime_error(message)
					{
					}

					~LibraryCallException()
					{
					}
				};
			}
		}
	}
}