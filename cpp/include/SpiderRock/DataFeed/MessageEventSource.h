#pragma once

#include "stdafx.h"

#include <memory>
#include <unordered_map>
#include <mutex>
#include <vector>
#include <utility>
#include <stdexcept>

#include "MessageHandler.h"
#include "EventObserver.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		template<class _Tkey, class _Tmessage> 
		class MessageEventSource : public SpiderRock::DataFeed::MessageHandler
		{
			std::unordered_map<_Tkey, _Tmessage, _Tkey, _Tkey> objects_by_key_;
			std::mutex objects_by_key_mutex_;

			std::vector<std::shared_ptr<CreateEventObserver<_Tmessage>>> on_create_observers_;
			std::vector<std::shared_ptr<ChangeEventObserver<_Tmessage>>> on_change_observers_;
			std::vector<std::shared_ptr<UpdateEventObserver<_Tmessage>>> on_update_observers_;

		public:
			MessageEventSource() :
				objects_by_key_(),
				objects_by_key_mutex_()
			{
			}

			~MessageEventSource()
			{
			}

			void RegisterObserver(std::shared_ptr<CreateEventObserver<_Tmessage>> observer);
			void RegisterObserver(std::shared_ptr<ChangeEventObserver<_Tmessage>> observer);
			void RegisterObserver(std::shared_ptr<UpdateEventObserver<_Tmessage>> observer);

			void Handle(Header* header, uint64_t timestamp);
		};

		template<class _Tkey, class _Tmessage>
		void MessageEventSource<_Tkey, _Tmessage>::RegisterObserver(std::shared_ptr<CreateEventObserver<_Tmessage>> observer)
		{
			on_create_observers_.push_back(observer);
		}

		template<class _Tkey, class _Tmessage>
		void MessageEventSource<_Tkey, _Tmessage>::RegisterObserver(std::shared_ptr<ChangeEventObserver<_Tmessage>> observer)
		{
			on_change_observers_.push_back(observer);
		}

		template<class _Tkey, class _Tmessage>
		void MessageEventSource<_Tkey, _Tmessage>::RegisterObserver(std::shared_ptr<UpdateEventObserver<_Tmessage>> observer)
		{
			on_update_observers_.push_back(observer);
		}

		template<class _Tkey, class _Tmessage>
		void MessageEventSource<_Tkey, _Tmessage>::Handle(Header* header, uint64_t timestamp)
		{
			static _Tmessage nullMessage;

			if (header->key_length != sizeof(_Tkey))
			{
				throw std::runtime_error(
					"Invalid MBUS Record: msg.keylen=" + std::to_string(header->key_length) +
					", obj.keylen=" + std::to_string(sizeof(_Tkey)));
			}

			_Tmessage received;
			received.Decode(header);
			received.time_received(timestamp);

			auto pkey = received.pkey();
			auto entry = objects_by_key_.find(pkey);

			if (entry == objects_by_key_.end())
			{
				std::lock_guard<std::mutex> lock(objects_by_key_mutex_);

				entry = objects_by_key_.find(pkey);

				if (entry == objects_by_key_.end())
				{
					if (on_create_observers_.size() > 0)
					{
						for (const auto& obs : on_create_observers_) obs->OnCreate(received);
					}

					if (on_change_observers_.size() > 0)
					{
						for (const auto& obs : on_change_observers_) obs->OnChange(received);
					}

					if (on_update_observers_.size() > 0)
					{
						for (const auto& obs : on_update_observers_) obs->OnUpdate(received, nullMessage);
					}

					received.header().bits = ~HeaderBits::FromCache & received.header().bits;

					objects_by_key_.insert(std::make_pair(pkey, received));

					return;
				}
			}

			if ((header->bits & HeaderBits::FromCache) == HeaderBits::FromCache) return;

			if (on_update_observers_.size() > 0)
			{
				for (const auto& obs : on_update_observers_) obs->OnUpdate(received, entry->second);

				entry->second = received;
			}

			if (on_change_observers_.size() > 0)
			{
				for (const auto& obs : on_change_observers_) obs->OnChange(received);
			}
		}
	}
}
