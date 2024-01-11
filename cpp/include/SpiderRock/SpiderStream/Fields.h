#pragma once

#include "stdafx.h"

#include <cstdint>
#include <cmath>
#include <cstring>
#include <string>
#include <memory>

#ifdef _WINDOWS_
#	pragma warning( disable : 4996 )
#endif

#include "CodeGen/Enums.h"

#pragma pack(1)

namespace SpiderRock
{
	namespace SpiderStream
	{
		typedef float Float;
		typedef double Double;
		typedef uint8_t Byte;
		typedef int16_t Short;
		typedef uint16_t UShort;
		typedef int32_t Int;
		typedef uint32_t UInt;
		typedef int64_t Long;
		typedef uint64_t ULong;

		typedef Byte SequenceNumber;
		typedef UShort AppId;

		template<uint16_t _Tsize> class FixedLengthString
		{
			static_assert(_Tsize <= 256, "FixedLengthString size argument must be < 256");

			char chars_[_Tsize];

		public:
			FixedLengthString()
			{
				chars_[0] = 0;
			}

			FixedLengthString(const FixedLengthString<_Tsize>& value)
			{
				memcpy(&chars_[0], &value.chars_[0], _Tsize);
			}

			FixedLengthString(const std::string& value)
			{
				strncpy(&chars_[0], value.c_str(), _Tsize);
			}

			FixedLengthString(const char* value)
			{
				strncpy(&chars_[0], value, _Tsize);
			}

			inline uint16_t length() const
			{
				return (uint16_t)(chars_[_Tsize - 1] == 0 ? strlen(chars_) : _Tsize);
			}

			inline std::shared_ptr<const std::string> str() const
			{
				return std::make_shared<std::string>(chars_, length());
			}

			inline operator std::string() const
			{
				return std::string(chars_, length());
			}

			inline size_t operator()(const FixedLengthString<_Tsize>& k) const
			{
				size_t hash_code = 0;
				auto max8 = reinterpret_cast<const int8_t*>(&k.chars_[_Tsize]);
				auto max32 = reinterpret_cast<const int32_t*>(max8);
				auto max64 = reinterpret_cast<const int64_t*>(max8);

				auto ptr64 = reinterpret_cast<const int64_t*>(&k);
				while (ptr64 < max64)
				{
					hash_code *= 397;
					hash_code ^= std::hash<int64_t>()(*(ptr64++));
				}

				auto ptr32 = reinterpret_cast<const int32_t*>(ptr64);
				while (ptr32 < max32)
				{
					hash_code *= 397;
					hash_code ^= std::hash<int32_t>()(*(ptr32++));
				}

				auto ptr8 = reinterpret_cast<const int8_t*>(ptr32);
				while (ptr8 < max8)
				{
					hash_code *= 397;
					hash_code ^= std::hash<uint8_t>()(*ptr8++);
				}

				return hash_code;
			}

			inline bool operator!=(const FixedLengthString<_Tsize> &other) const { return !(*this == other); }

			inline bool operator==(const FixedLengthString<_Tsize> &other) const
			{
				auto count = _Tsize;
				auto self_ptr = reinterpret_cast<const uint8_t*>(this);
				auto other_ptr = reinterpret_cast<const uint8_t*>(&other);

				while (count >= sizeof(int64_t))
				{
					if (*reinterpret_cast<const int64_t*>(self_ptr) != *reinterpret_cast<const int64_t*>(other_ptr)) return false;
					count -= sizeof(int64_t);
					other_ptr += sizeof(int64_t);
					self_ptr += sizeof(int64_t);
				}

				while (count >= sizeof(int32_t))
				{
					if (*reinterpret_cast<const int32_t*>(self_ptr) != *reinterpret_cast<const int32_t*>(other_ptr)) return false;
					count -= sizeof(int32_t);
					other_ptr += sizeof(int32_t);
					self_ptr += sizeof(int32_t);
				}

				while (count > 0)
				{
					if (*self_ptr != *other_ptr) return false;
					--count;
					++other_ptr;
					++self_ptr;
				}

				return true;
			}
		};

		template <uint16_t _Tsize> using String = FixedLengthString < _Tsize > ;

		typedef String<12> Ticker;

		class ExpiryKey
		{
			AssetType asset_type_;
			TickerSrc ticker_source_;
			Ticker ticker_;
			Short reserved1_;
			Byte reserved2_;

		public:
			ExpiryKey() { }

			ExpiryKey(
				AssetType asset_type,
				TickerSrc ticker_source,
				const Ticker& ticker
				) :
				asset_type_(asset_type),
				ticker_source_(ticker_source),
				ticker_(ticker),
				reserved1_(0),
				reserved2_(0)
			{
			}

			inline AssetType asset_type() const { return asset_type_; }
			inline TickerSrc ticker_source() const { return ticker_source_; }
			inline const Ticker& ticker() const { return ticker_; }

			inline size_t operator()(const ExpiryKey& k) const
			{
				auto ptr = reinterpret_cast<const int64_t*>(&k);

				size_t hash_code = *ptr;
				hash_code = (hash_code * 397) ^ *(ptr + 1);
				hash_code = (hash_code * 397) ^ *(int8_t*)(ptr + 2);

				return hash_code;
			}

			inline bool operator==(const ExpiryKey &other) const
			{
				auto self_ptr = reinterpret_cast<const int64_t*>(this);
				auto other_ptr = reinterpret_cast<const int64_t*>(&other);
				return 
					*self_ptr == *other_ptr && 
					*(self_ptr + 1) == *(other_ptr + 1) &&
					*(int8_t*)(self_ptr + 1) == *(int8_t*)(other_ptr + 1);
			}
		};


		class TickerKey
		{
			AssetType asset_type_;
			TickerSrc ticker_source_;
			Ticker ticker_;

		public:
			TickerKey() { }

			TickerKey(
				AssetType asset_type,
				TickerSrc ticker_source,
				const Ticker& ticker
				) :
				asset_type_(asset_type),
				ticker_source_(ticker_source),
				ticker_(ticker)
			{
			}

			inline AssetType asset_type() const { return asset_type_; }
			inline TickerSrc ticker_source() const { return ticker_source_; }
			inline const Ticker& ticker() const { return ticker_; }

			inline size_t operator()(const TickerKey& k) const
			{
				auto ptr = reinterpret_cast<const int64_t*>(&k);

				size_t hash_code = *ptr;
				hash_code = (hash_code * 397) ^ *(int32_t*)(ptr + 1);
				// only using 12 of the 14 bytes, betting on the fact
				// that most tickers are empty at the end
				// the equality should fill that gap

				return hash_code;
			}

			inline bool operator==(const TickerKey &other) const
			{
				return 
					ticker_ == other.ticker_ && 
					asset_type_ == other.asset_type_ && 
					ticker_source_ == other.ticker_source_;
			}
		};


		class OptionKey
		{
			AssetType asset_type_;
			TickerSrc ticker_source_;
			Ticker ticker_;
			Byte year_;
			Byte month_;
			Byte day_;
			Double strike_;
			CallPut call_put_;

		public:
			OptionKey() { }

			OptionKey(
				AssetType asset_type,
				TickerSrc ticker_source,
				const Ticker& ticker,
				UShort year,
				Byte month,
				Byte day,
				Double strike,
				CallPut call_put
				) :
				asset_type_(asset_type),
				ticker_source_(ticker_source),
				ticker_(ticker),
				year_(year - 1900),
				month_(month),
				day_(day),
				strike_(strike),
				call_put_(call_put)
			{
			}

			inline AssetType asset_type() const { return asset_type_; }
			inline TickerSrc ticker_source() const { return ticker_source_; }
			inline const Ticker& ticker() const { return ticker_; }

			inline UShort year() const { return year_ + 1900; }
			inline Byte month() const { return month_; }
			inline Byte day() const { return day_; }
			inline Double strike() const { return strike_; }
			inline CallPut call_put() const { return call_put_; }

			inline size_t operator()(const OptionKey& k) const
			{
				auto ptr = reinterpret_cast<const int64_t*>(&k);

				size_t hash_code = *ptr;
				hash_code = (hash_code * 397) ^ *(ptr + 1);
				hash_code = (hash_code * 397) ^ *(ptr + 2);
				hash_code = (hash_code * 397) ^ *(int16_t*)(ptr + 3);

				return hash_code;
			}

			inline bool operator==(const OptionKey &other) const
			{
				auto self_ptr = reinterpret_cast<const int64_t*>(this);
				auto other_ptr = reinterpret_cast<const int64_t*>(&other);
				return 
					*self_ptr == *other_ptr && 
					*(self_ptr + 1) == *(other_ptr + 1) &&
					*(self_ptr + 2) == *(other_ptr + 2) &&
					*(int16_t*)(self_ptr + 3) == *(int16_t*)(other_ptr + 3);
			}
		};

		class DateTime
		{
			static const uint64_t UNIX_EPOCH = 0x089f7ff5f7b58000;	// Thursday, January 01, 1970 12:00:00 AM  
			static const uint64_t TICKS_PER_SECOND = 10000000;

			int64_t ticks_;

		public:

			inline int64_t ticks() const { return ticks_; }

			inline operator time_t() const { return static_cast<time_t>((ticks_ - UNIX_EPOCH) / TICKS_PER_SECOND); }

			inline size_t operator()(const DateTime& k) const { return std::hash<int64_t>()(k.ticks_); }
			inline bool operator==(const DateTime &other) const { return ticks_ == other.ticks_; }
		};

		typedef DateTime DateKey;
        typedef int64_t TimeSpan;

		static_assert(sizeof(size_t) == 8, "sizeof(size_t) must be 8 bytes");

		static_assert(sizeof(Enum) == 1, "sizeof(Enum) must be 1 bytes");
		static_assert(sizeof(Flag) == 1, "sizeof(Flag) must be 1 bytes");
		static_assert(sizeof(Byte) == 1, "sizeof(Byte) must be 1 bytes");
		static_assert(sizeof(Short) == 2, "sizeof(Short) must be 2 bytes");
		static_assert(sizeof(UShort) == 2, "sizeof(UShort) must be 2 bytes");
		static_assert(sizeof(Int) == 4, "sizeof(Int) must be 4 bytes");
		static_assert(sizeof(UInt) == 4, "sizeof(UInt) must be 4 bytes");
		static_assert(sizeof(Long) == 8, "sizeof(Long) must be 8 bytes");
		static_assert(sizeof(ULong) == 8, "sizeof(ULong) must be 8 bytes");
		static_assert(sizeof(Float) == 4, "sizeof(Float) must be 4 bytes");
		static_assert(sizeof(Double) == 8, "sizeof(Double) must be 8 bytes");

		static_assert(sizeof(ExpiryKey) == 17, "sizeof(CCodeKey) must be 17 bytes");
		static_assert(sizeof(TickerKey) == 14, "sizeof(TickerKey) must be 14 bytes");
		static_assert(sizeof(OptionKey) == 26, "sizeof(OptionKey) must be 26 bytes");
		static_assert(sizeof(DateTime) == 8, "sizeof(DateTime) must be 8 bytes");
		static_assert(sizeof(DateKey) == 8, "sizeof(DateKey) must be 8 bytes");
		static_assert(sizeof(TimeSpan) == 8, "sizeof(TimeSpan) must be 8 bytes");

		static_assert(sizeof(Ticker) == 12, "sizeof(Ticker) must be 14 bytes");
	}
}

#pragma pack()
