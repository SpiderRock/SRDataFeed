#include "stdafx.h"

#pragma warning( disable : 4996 )

// TODO: Consider MessageType as enum

namespace SpiderRock
{
	namespace DataFeed
	{
		typedef uint8_t SREnum;

		typedef float SRFloat;
		typedef double SRDouble;
		typedef uint8_t SRByte;
		typedef int16_t SRShort;
		typedef uint16_t SRUshort;
		typedef int32_t SRInt;
		typedef uint32_t SRUint;
		typedef int64_t SRLong;
		typedef uint64_t SRUlong;

		const uint16_t MAX_MESSAGE_TYPE = 1000;
		const uint16_t MAX_MESSAGE_LENGTH = 64000;

		typedef uint16_t MessageType;
		inline bool IsValid(MessageType messageType) { return messageType < MAX_MESSAGE_TYPE; }

		typedef uint16_t RepeatLength;

		enum class SysEnvironment : SREnum
		{
			None,
			Stable,
			Current,
			UAT
		};

		inline bool IsValid(SysEnvironment env)
		{
			return static_cast<int>(env) >= 0 && static_cast<int>(env) <= 5; // Only 3 are relevant to this API but 5 exist
		}

		enum class HeaderBits : SREnum
		{
			None = 0,
			IsDeleted = 1,
			FromCache = 2
		};

		inline HeaderBits operator|(HeaderBits a, HeaderBits b) { return static_cast<HeaderBits>(static_cast<int>(a) | static_cast<int>(b)); }
		inline HeaderBits operator&(HeaderBits a, HeaderBits b) { return static_cast<HeaderBits>(static_cast<int>(a)& static_cast<int>(b)); }
		inline HeaderBits operator~(HeaderBits a) { return static_cast<HeaderBits>(~static_cast<int>(a)); }

		enum class AssetType : SREnum
		{
			None = 0,
			EQT = 1,
			IDX = 2,
			BND = 3,
			CUR = 4,
			COM = 5,
			FUT = 6
		};

		enum class TickerSrc : SREnum
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

		enum class CallPut : SREnum
		{
			Call = 0,
			Put = 1
		};

		enum class UdpChannel : SREnum
		{
			StkNbboQuote1 = 1,
			StkNbboQuote2 = 2,
			StkNbboQuote3 = 3,
			StkNbboQuote4 = 4,

			OptNbboQuote1 = 11,
			OptNbboQuote2 = 12,
			OptNbboQuote3 = 13,
			OptNbboQuote4 = 14,

			FutQuoteCme = 21,
			FutQuoteCbot = 22,
			FutQuoteNymex = 23,
			FutQuoteComex = 24,

			CMEAdmin = 25,

			OptQuoteCme = 31,
			OptQuoteCbot = 32,
			OptQuoteNymex = 33,
			OptQuoteComex = 34,

			FutQuoteCfe = 41,

			IdxQuoteRut = 51,
			IdxQuoteCboe = 52,

			ImpliedQuoteNms = 61,
			ImpliedQuoteCme = 62,
			ImpliedQuoteCbot = 63,
			ImpliedQuoteNymex = 64,
			ImpliedQuoteComex = 65,

			StkExchQuote1Nsdq = 101,
			StkExchQuote2Nsdq = 102,
			StkExchQuote3Nsdq = 103,
			StkExchQuote4Nsdq = 104,

			StkExchQuote1Bats = 111,
			StkExchQuote2Bats = 112,
			StkExchQuote3Bats = 113,
			StkExchQuote4Bats = 114,

			StkExchQuote1Btsy = 121,
			StkExchQuote2Btsy = 122,
			StkExchQuote3Btsy = 123,
			StkExchQuote4Btsy = 124,

			StkExchQuote1Edgx = 131,
			StkExchQuote2Edgx = 132,
			StkExchQuote3Edgx = 133,
			StkExchQuote4Edgx = 134,

			StkExchQuote1Edga = 141,
			StkExchQuote2Edga = 142,
			StkExchQuote3Edga = 143,
			StkExchQuote4Edga = 144
		};

		MBUS_STRUCT_PACK_ENABLE
		struct Header
		{
			SysEnvironment env;
			MessageType msg_type;
			HeaderBits bits;
			uint16_t src_id;
			uint8_t seq_num;
			int64_t sent_ts;
			uint16_t msg_len;
			uint8_t key_len;

			Header() :
				env(SysEnvironment::Stable),
				msg_type(0),
				bits(HeaderBits::None),
				src_id(0),
				seq_num(0),
				sent_ts(0),
				msg_len(0),
				key_len(0)
			{
			}
		};
		MBUS_STRUCT_PACK_DISABLE

		MBUS_STRUCT_PACK_ENABLE
		template<uint16_t _Tsize> class SRFixedLengthString
		{
			static_assert(_Tsize <= 256, "SRFixedLengthString size argument must be < 256");

			char chars_[_Tsize];

		public:
			SRFixedLengthString()
			{
				chars_[0] = 0;
			}

			SRFixedLengthString(const string& value)
			{
				strncpy(&chars_[0], value.c_str(), _Tsize);
			}

			SRFixedLengthString(const char* value)
			{
				strncpy(&chars_[0], value, _Tsize);
			}

			inline uint16_t length() const { return (uint16_t)(chars_[_Tsize - 1] == 0 ? _Tsize : strlen(chars_)); }

			inline shared_ptr<const string> str() const { return make_shared<string>(chars_, length()); }

			inline size_t operator()(const SRFixedLengthString<_Tsize>& k) const
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

			inline bool operator!=(const SRFixedLengthString<_Tsize> &other) const { return !(*this == other); }

			inline bool operator==(const SRFixedLengthString<_Tsize> &other) const
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
		MBUS_STRUCT_PACK_DISABLE

		typedef SRFixedLengthString<6> CCode;
		typedef SRFixedLengthString<6> RootSymbol;
		typedef SRFixedLengthString<14> TickerSymbol;

		MBUS_STRUCT_PACK_ENABLE
		class SRFutureKey
		{
			AssetType asset_type_;
			TickerSrc ticker_src_;
			CCode ccode_;
			SRByte year_;
			SRByte month_;
			SRByte day_;
			char unused_[5];

		public:
			SRFutureKey() { }

			SRFutureKey(AssetType asset_type, TickerSrc ticker_src, const string& ccode, SRUshort year, SRByte month, SRByte day)
				: asset_type_(asset_type), ticker_src_(ticker_src), ccode_(ccode), year_(year - 1900), month_(month), day_(day)
			{
			}

			inline AssetType asset_type() const { return asset_type_; }
			inline TickerSrc ticker_src() const { return ticker_src_; }
			inline const CCode& ticker() const { return ccode_; }
			inline SRUshort year() const { return year_ + 1900; }
			inline SRByte month() const { return month_; }
			inline SRByte day() const { return day_; }

			inline size_t operator()(const SRFutureKey& k) const
			{
				auto ptr = reinterpret_cast<const int32_t*>(&k);

				size_t hash_code = *ptr;
				hash_code = (hash_code * 397) ^ *(ptr + 1);
				hash_code = (hash_code * 397) ^ *(ptr + 2);
				hash_code = (hash_code * 397) ^ *(ptr + 3);

				return hash_code;
			}

			inline bool operator==(const SRFutureKey &other) const
			{
				auto self_ptr = reinterpret_cast<const int64_t*>(this);
				auto other_ptr = reinterpret_cast<const int64_t*>(&other);
				return *self_ptr == *other_ptr && *(self_ptr + 1) == *(other_ptr + 1);
			}
		};
		MBUS_STRUCT_PACK_DISABLE

		MBUS_STRUCT_PACK_ENABLE
		class SROptionKey
		{
			AssetType asset_type_;
			TickerSrc ticker_src_;
			RootSymbol root_;
			SRByte year_;
			SRByte month_;
			SRByte day_;
			SRInt strike_;
			CallPut call_put_;

		public:
			SROptionKey() { }

			SROptionKey(
				AssetType asset_type,
				TickerSrc ticker_src,
				const string& root,
				SRUshort year,
				SRByte month,
				SRByte day,
				SRDouble strike,
				CallPut call_put)

				: asset_type_(asset_type),
				ticker_src_(ticker_src),
				root_(root),
				year_(year - 1900),
				month_(month),
				day_(day),
				strike_(static_cast<int32_t>(round(strike * 1000L))),
				call_put_(call_put)

			{
			}

			inline AssetType asset_type() const { return asset_type_; }
			inline TickerSrc ticker_src() const { return ticker_src_; }
			inline const RootSymbol& root() const { return root_; }

			inline SRUshort year() const { return year_ + 1900; }
			inline SRByte month() const { return month_; }
			inline SRByte day() const { return day_; }
			inline SRDouble strike() const { return 0.001L * strike_; }
			inline CallPut call_put() const { return call_put_; }

			inline size_t operator()(const SROptionKey& k) const
			{
				auto ptr = reinterpret_cast<const int32_t*>(&k);

				size_t hash_code = *ptr;
				hash_code = (hash_code * 397) ^ *(ptr + 1);
				hash_code = (hash_code * 397) ^ *(ptr + 2);
				hash_code = (hash_code * 397) ^ *(ptr + 3);

				return hash_code;
			}

			inline bool operator==(const SROptionKey &other) const
			{
				auto self_ptr = reinterpret_cast<const int64_t*>(this);
				auto other_ptr = reinterpret_cast<const int64_t*>(&other);
				return *self_ptr == *other_ptr && *(self_ptr + 1) == *(other_ptr + 1);
			}
		};
		MBUS_STRUCT_PACK_DISABLE

		MBUS_STRUCT_PACK_ENABLE
		class SRStockKey
		{
			AssetType asset_type_;
			TickerSrc ticker_src_;
			TickerSymbol ticker_;

		public:
			SRStockKey() { }

			SRStockKey(AssetType asset_type, TickerSrc ticker_src, const string& ticker)
				: asset_type_(asset_type), ticker_src_(ticker_src), ticker_(ticker)
			{
			}

			inline AssetType asset_type() const { return asset_type_; }
			inline TickerSrc ticker_src() const { return ticker_src_; }
			inline const TickerSymbol& ticker() const { return ticker_; }

			inline size_t operator()(const SRStockKey& k) const
			{
				auto ptr = reinterpret_cast<const int32_t*>(&k);

				size_t hash_code = *ptr;
				hash_code = (hash_code * 397) ^ *(ptr + 1);
				hash_code = (hash_code * 397) ^ *(ptr + 2);
				hash_code = (hash_code * 397) ^ *(ptr + 3);

				return hash_code;
			}

			inline bool operator==(const SRStockKey &other) const
			{
				auto self_ptr = reinterpret_cast<const int64_t*>(this);
				auto other_ptr = reinterpret_cast<const int64_t*>(&other);
				return *self_ptr == *other_ptr && *(self_ptr + 1) == *(other_ptr + 1);
			}
		};
		MBUS_STRUCT_PACK_DISABLE

		MBUS_STRUCT_PACK_ENABLE
		class SRRootKey
		{
			AssetType asset_type_;
			TickerSrc ticker_src_;
			RootSymbol root_;
			int64_t unused_;

		public:
			SRRootKey() { }

			SRRootKey(AssetType asset_type, TickerSrc ticker_src, const string& root)
				: asset_type_(asset_type), ticker_src_(ticker_src), root_(root)
			{
			}

			inline AssetType asset_type() const { return asset_type_; }
			inline TickerSrc ticker_src() const { return ticker_src_; }
			inline const RootSymbol& root() const { return root_; }

			inline size_t operator()(const SRRootKey& k) const
			{
				auto ptr = reinterpret_cast<const int32_t*>(&k);
				return (*ptr * 397) ^ *(ptr + 1);
			}

			inline bool operator==(const SRRootKey &other) const
			{
				return *reinterpret_cast<const int64_t*>(this) == *reinterpret_cast<const int64_t*>(&other);
			}
		};
		MBUS_STRUCT_PACK_DISABLE

		MBUS_STRUCT_PACK_ENABLE
		class SRDateTime
		{
			static const uint64_t UNIX_EPOCH = 0x089f7ff5f7b58000;	// Thursday, January 01, 1970 12:00:00 AM  
			static const uint64_t TICKS_PER_SECOND = 10000000;

			int64_t ticks_;

		public:

			inline int64_t ticks() const { return ticks_; }

			inline operator time_t() const { return static_cast<time_t>((ticks_ - UNIX_EPOCH) / TICKS_PER_SECOND); }

			inline size_t operator()(const SRDateTime& k) const { return hash<int64_t>()(ticks_); }
			inline bool operator==(const SRDateTime &other) const { return ticks_ == other.ticks_; }
		};
		MBUS_STRUCT_PACK_DISABLE

		static_assert(sizeof(float) == 4, "sizeof(float) must be 4 bytes");
		static_assert(sizeof(double) == 8, "sizeof(double) must be 8 bytes");

		static_assert(sizeof(SRRootKey) == 16, "sizeof(SRRootKey) must be 16 bytes");
		static_assert(sizeof(SRStockKey) == 16, "sizeof(SRStockKey) must be 16 bytes");
		static_assert(sizeof(SRFutureKey) == 16, "sizeof(SRFutureKey) must be 16 bytes");
		static_assert(sizeof(SROptionKey) == 16, "sizeof(SROptionKey) must be 16 bytes");

		static_assert(sizeof(CCode) == 6, "sizeof(CCode) must be 6 bytes");
		static_assert(sizeof(RootSymbol) == 6, "sizeof(RootSymbol) must be 6 bytes");
		static_assert(sizeof(TickerSymbol) == 14, "sizeof(TickerSymbol) must be 14 bytes");
		static_assert(sizeof(SRDateTime) == 8, "sizeof(SRDateTime) must be 8 bytes");

		typedef SRDateTime SRDateKey;
	}
}