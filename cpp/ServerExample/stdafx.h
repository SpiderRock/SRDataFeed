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
using std::make_unique;

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