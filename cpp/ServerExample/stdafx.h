// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#if defined (_WIN64) || (_WIN32)
#	include <windows.h>
#endif

#include <iostream>

namespace SpiderRock
{
	template<typename TF>
	inline void Trace(std::ostream & out, TF const& f)
	{
		out << f << std::endl;
	}

	template<typename TF, typename ... TR>
	inline void Trace(std::ostream & out, TF const& f, TR const& ... rest)
	{
		out << f << " ";
		Trace(out, rest...);
	}
}

#ifndef SR_TRACE_INFO
#	ifdef _WINDOWS_
#		define SR_TRACE_INFO(...) SpiderRock::Trace( std::cout, __FUNCTION__, ":", __VA_ARGS__ )
#	else
#		define SR_TRACE_INFO(...) SpiderRock::Trace( std::cout, __PRETTY_FUNCTION__, ":", __VA_ARGS__ )
#	endif
#endif

#ifndef SR_TRACE_WARNING
#	ifdef _WINDOWS_
#		define SR_TRACE_WARNING(...) SpiderRock::Trace( std::cerr, __FUNCTION__, ":", __VA_ARGS__ )
#	else
#		define SR_TRACE_WARNING(...) SpiderRock::Trace( std::cerr, __PRETTY_FUNCTION__, ":", __VA_ARGS__ )
#	endif
#endif

#ifndef SR_TRACE_ERROR
#	ifdef _WINDOWS_
#		define SR_TRACE_ERROR(...) SpiderRock::Trace( std::cerr, __FUNCTION__, ":", __VA_ARGS__ )
#	else
#		define SR_TRACE_ERROR(...) SpiderRock::Trace( std::cerr, __PRETTY_FUNCTION__, ":", __VA_ARGS__ )
#	endif
#endif

#ifdef _WINDOWS_

#include <string>

namespace SpiderRock
{
	inline int GetLastError() { return WSAGetLastError(); }

	template<typename T> inline void ThrowLastErrorAs()
	{
		auto last_error = GetLastError();
		LPWSTR s = nullptr;
		FormatMessage(
			FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM,
			nullptr,
			last_error,
			MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
			(LPWSTR)&s,
			0,
			nullptr);

		auto wide_str = std::to_wstring(last_error) + L": " + std::wstring(s);
		SR_TRACE_ERROR(last_error, ":", s);
		auto exception = T(std::string(wide_str.begin(), wide_str.end()));
		LocalFree(s);
		throw exception;
	}
}

#else

#include <string>
#include <cstring>
#include <cerrno> 

namespace SpiderRock
{
	inline int GetLastError() { return errno; }

	template<typename T> inline void ThrowLastErrorAs() { throw T(std::string(strerror(GetLastError()))); }
}

#endif
