#pragma once

#include "stdafx.h"
#include <cmath>
#include <cstring>

#ifdef _WINDOWS_
#	pragma warning( disable : 4996 )
#endif

#pragma pack(1)

namespace SpiderRock
{
	namespace DataFeed
	{
		namespace Mbus
		{
			typedef uint8_t Enum;
			typedef uint8_t Flag;
			typedef float Float;
			typedef double Double;
			typedef uint8_t Byte;
			typedef int16_t Short;
			typedef uint16_t UShort;
			typedef int32_t Int;
			typedef uint32_t UInt;
			typedef int64_t Long;
			typedef uint64_t ULong;

			enum class AssetType : Enum
			{
				None = 0,
				EQT = 1,
				IDX = 2,
				BND = 3,
				CUR = 4,
				COM = 5,
				FUT = 6
			};

			enum class TickerSource : Enum
			{
				None = 0,
				SR = 1,
				NMS = 2,
				CME = 3,
				ICE = 4,
				CFE = 5,
				CBOT = 6,
				COIN = 7,
				NYMEX = 8,
				COMEX = 9,
				RUT = 10,
				CBOE = 11
			};

			enum class CallPut : Enum
			{
				Call = 0,
				Put = 1
			};

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

				FixedLengthString(const string& value)
				{
					strncpy(&chars_[0], value.c_str(), _Tsize);
				}

				FixedLengthString(const char* value)
				{
					strncpy(&chars_[0], value, _Tsize);
				}

				inline uint16_t length() const
				{
					return (uint16_t)(chars_[_Tsize - 1] == 0 ? _Tsize : strlen(chars_));
				}

				inline shared_ptr<const string> str() const
				{
					return make_shared<string>(chars_, length());
				}

				inline operator string() const
				{
					return string(chars_, length());
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
						hash_code ^= hash<int64_t>()(*(ptr64++));
					}

					auto ptr32 = reinterpret_cast<const int32_t*>(ptr64);
					while (ptr32 < max32)
					{
						hash_code *= 397;
						hash_code ^= hash<int32_t>()(*(ptr32++));
					}

					auto ptr8 = reinterpret_cast<const int8_t*>(ptr32);
					while (ptr8 < max8)
					{
						hash_code *= 397;
						hash_code ^= hash<uint8_t>()(*ptr8++);
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

			typedef String<6> CCode;
			typedef String<6> Root;
			typedef String<14> Ticker;

			class RootKey
			{
				AssetType asset_type_;
				TickerSource ticker_source_;
				Root root_;
				int64_t reserved_;

			public:
				RootKey() { }

				RootKey(
					AssetType asset_type,
					TickerSource ticker_source,
					const Root& root
					) :
					asset_type_(asset_type),
					ticker_source_(ticker_source),
					root_(root)
				{
				}

				inline AssetType asset_type() const { return asset_type_; }
				inline TickerSource ticker_source() const { return ticker_source_; }
				inline const Root& root() const { return root_; }

				inline size_t operator()(const RootKey& k) const
				{
					auto ptr = reinterpret_cast<const int32_t*>(&k);
					return (*ptr * 397) ^ *(ptr + 1);
				}

				inline bool operator==(const RootKey &other) const
				{
					return *reinterpret_cast<const int64_t*>(this) == *reinterpret_cast<const int64_t*>(&other);
				}
			};

			class StockKey
			{
				AssetType asset_type_;
				TickerSource ticker_source_;
				Ticker ticker_;

			public:
				StockKey() { }

				StockKey(
					AssetType asset_type,
					TickerSource ticker_source,
					const Ticker& ticker
					) :
					asset_type_(asset_type),
					ticker_source_(ticker_source),
					ticker_(ticker)
				{
				}

				inline AssetType asset_type() const { return asset_type_; }
				inline TickerSource ticker_source() const { return ticker_source_; }
				inline const Ticker& ticker() const { return ticker_; }

				inline size_t operator()(const StockKey& k) const
				{
					auto ptr = reinterpret_cast<const int32_t*>(&k);

					size_t hash_code = *ptr;
					hash_code = (hash_code * 397) ^ *(ptr + 1);
					hash_code = (hash_code * 397) ^ *(ptr + 2);
					hash_code = (hash_code * 397) ^ *(ptr + 3);

					return hash_code;
				}

				inline bool operator==(const StockKey &other) const
				{
					auto self_ptr = reinterpret_cast<const int64_t*>(this);
					auto other_ptr = reinterpret_cast<const int64_t*>(&other);
					return *self_ptr == *other_ptr && *(self_ptr + 1) == *(other_ptr + 1);
				}
			};

			class FutureKey
			{
				AssetType asset_type_;
				TickerSource ticker_source_;
				CCode CCode_;
				Byte year_;
				Byte month_;
				Byte day_;
				char reserved_[5];

			public:
				FutureKey() { }

				FutureKey(
					AssetType asset_type,
					TickerSource ticker_source,
					const CCode& CCode,
					UShort year,
					Byte month,
					Byte day
					) :
					asset_type_(asset_type),
					ticker_source_(ticker_source),
					CCode_(CCode),
					year_(year - 1900),
					month_(month),
					day_(day)
				{
				}

				inline AssetType asset_type() const { return asset_type_; }
				inline TickerSource ticker_source() const { return ticker_source_; }
				inline const CCode& ticker() const { return CCode_; }
				inline UShort year() const { return year_ + 1900; }
				inline Byte month() const { return month_; }
				inline Byte day() const { return day_; }

				inline size_t operator()(const FutureKey& k) const
				{
					auto ptr = reinterpret_cast<const int32_t*>(&k);

					size_t hash_code = *ptr;
					hash_code = (hash_code * 397) ^ *(ptr + 1);
					hash_code = (hash_code * 397) ^ *(ptr + 2);
					hash_code = (hash_code * 397) ^ *(ptr + 3);

					return hash_code;
				}

				inline bool operator==(const FutureKey &other) const
				{
					auto self_ptr = reinterpret_cast<const int64_t*>(this);
					auto other_ptr = reinterpret_cast<const int64_t*>(&other);
					return *self_ptr == *other_ptr && *(self_ptr + 1) == *(other_ptr + 1);
				}
			};

			class OptionKey
			{
				AssetType asset_type_;
				TickerSource ticker_source_;
				Root root_;
				Byte year_;
				Byte month_;
				Byte day_;
				Int strike_;
				CallPut call_put_;

			public:
				OptionKey() { }

				OptionKey(
					AssetType asset_type,
					TickerSource ticker_source,
					const Root& root,
					UShort year,
					Byte month,
					Byte day,
					Double strike,
					CallPut call_put
					) :
					asset_type_(asset_type),
					ticker_source_(ticker_source),
					root_(root),
					year_(year - 1900),
					month_(month),
					day_(day),
					strike_(static_cast<int32_t>(round(strike * 1000L))),
					call_put_(call_put)
				{
				}

				inline AssetType asset_type() const { return asset_type_; }
				inline TickerSource ticker_source() const { return ticker_source_; }
				inline const Root& root() const { return root_; }

				inline UShort year() const { return year_ + 1900; }
				inline Byte month() const { return month_; }
				inline Byte day() const { return day_; }
				inline Double strike() const { return 0.001L * strike_; }
				inline CallPut call_put() const { return call_put_; }

				inline size_t operator()(const OptionKey& k) const
				{
					auto ptr = reinterpret_cast<const int32_t*>(&k);

					size_t hash_code = *ptr;
					hash_code = (hash_code * 397) ^ *(ptr + 1);
					hash_code = (hash_code * 397) ^ *(ptr + 2);
					hash_code = (hash_code * 397) ^ *(ptr + 3);

					return hash_code;
				}

				inline bool operator==(const OptionKey &other) const
				{
					auto self_ptr = reinterpret_cast<const int64_t*>(this);
					auto other_ptr = reinterpret_cast<const int64_t*>(&other);
					return *self_ptr == *other_ptr && *(self_ptr + 1) == *(other_ptr + 1);
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

				inline size_t operator()(const DateTime& k) const { return hash<int64_t>()(k.ticks_); }
				inline bool operator==(const DateTime &other) const { return ticks_ == other.ticks_; }
			};

			typedef DateTime DateKey;

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

			static_assert(sizeof(RootKey) == 16, "sizeof(RootKey) must be 16 bytes");
			static_assert(sizeof(StockKey) == 16, "sizeof(StockKey) must be 16 bytes");
			static_assert(sizeof(FutureKey) == 16, "sizeof(FutureKey) must be 16 bytes");
			static_assert(sizeof(OptionKey) == 16, "sizeof(OptionKey) must be 16 bytes");
			static_assert(sizeof(DateTime) == 8, "sizeof(DateTime) must be 8 bytes");
			static_assert(sizeof(DateKey) == 8, "sizeof(DateKey) must be 8 bytes");

			static_assert(sizeof(CCode) == 6, "sizeof(CCode) must be 6 bytes");
			static_assert(sizeof(Root) == 6, "sizeof(Root) must be 6 bytes");
			static_assert(sizeof(Ticker) == 14, "sizeof(Ticker) must be 14 bytes");
		}
	}
}

#pragma pack()
