// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#if defined (_WIN64) || (_WIN32)
#	include <windows.h>
#endif

#include <cstdint>

#include <string>
using std::string;
using std::wstring;
using std::to_string;

#include <vector>
using std::vector;

#include <stdexcept>
using std::exception;
using std::runtime_error;

#include <array>
using std::array;

#include <memory>
using std::unique_ptr;
using std::shared_ptr;
using std::make_shared;
#ifdef __GNUC__
template<typename T, typename... Args>
std::unique_ptr<T> make_unique(Args&&... args)
{
	return std::unique_ptr<T>(new T(std::forward<Args>(args)...));
}
#else
using std::make_unique;
#endif

#if ((__GNUC__ * 100) + __GNUC_MINOR__) >= 402
#define GCC_DIAG_STR(s) #s
#define GCC_DIAG_JOINSTR(x,y) GCC_DIAG_STR(x ## y)
# define GCC_DIAG_DO_PRAGMA(x) _Pragma (#x)
# define GCC_DIAG_PRAGMA(x) GCC_DIAG_DO_PRAGMA(GCC diagnostic x)
# if ((__GNUC__ * 100) + __GNUC_MINOR__) >= 406
#  define GCC_DIAG_OFF(x) GCC_DIAG_PRAGMA(push) \
	GCC_DIAG_PRAGMA(ignored GCC_DIAG_JOINSTR(-W,x))
#  define GCC_DIAG_ON(x) GCC_DIAG_PRAGMA(pop)
# else
#  define GCC_DIAG_OFF(x) GCC_DIAG_PRAGMA(ignored GCC_DIAG_JOINSTR(-W,x))
#  define GCC_DIAG_ON(x)  GCC_DIAG_PRAGMA(warning GCC_DIAG_JOINSTR(-W,x))
# endif
#else
# define GCC_DIAG_OFF(x)
# define GCC_DIAG_ON(x)
#endif

#include <functional>
using std::hash;

#include <unordered_map>
using std::unordered_map;

#include <utility>
using std::make_pair;

#include <mutex>
using std::mutex;
using std::lock_guard;

#include <initializer_list>
using std::initializer_list;

#include <thread>
using std::thread;

#define MBUS_STRUCT_PACK_ENABLE __pragma(pack (1))
#define MBUS_STRUCT_PACK_DISABLE __pragma(pack ())
