#pragma once

#include "stdafx.h"

namespace SpiderRock
{
	namespace DataFeed
	{
		template<class __TmessageKey, class _Tmessage> 
		class MessageEventSource : public SpiderRock::DataFeed::MessageHandler
		{
			unordered_map<__TmessageKey, _Tmessage, __TmessageKey, __TmessageKey> objects_by_key_;
			mutex objects_by_key_mutex_;

			vector<shared_ptr<CreateEventObserver<_Tmessage>>> on_create_observers_;
			vector<shared_ptr<ChangeEventObserver<_Tmessage>>> on_change_observers_;
			vector<shared_ptr<UpdateEventObserver<_Tmessage>>> on_update_observers_;

		public:
			MessageEventSource() :
				objects_by_key_(),
				objects_by_key_mutex_()
			{
			}

			~MessageEventSource()
			{
			}

			void RegisterObserver(shared_ptr<CreateEventObserver<_Tmessage>> observer);
			void RegisterObserver(shared_ptr<ChangeEventObserver<_Tmessage>> observer);
			void RegisterObserver(shared_ptr<UpdateEventObserver<_Tmessage>> observer);

			void Handle(Header* header, uint64_t timestamp);
		};

		template<class __TmessageKey, class _Tmessage>
		void MessageEventSource<__TmessageKey, _Tmessage>::RegisterObserver(shared_ptr<CreateEventObserver<_Tmessage>> observer)
		{
			on_create_observers_.push_back(observer);
		}

		template<class __TmessageKey, class _Tmessage>
		void MessageEventSource<__TmessageKey, _Tmessage>::RegisterObserver(shared_ptr<ChangeEventObserver<_Tmessage>> observer)
		{
			on_change_observers_.push_back(observer);
		}

		template<class __TmessageKey, class _Tmessage>
		void MessageEventSource<__TmessageKey, _Tmessage>::RegisterObserver(shared_ptr<UpdateEventObserver<_Tmessage>> observer)
		{
			on_update_observers_.push_back(observer);
		}

		template<class __TmessageKey, class _Tmessage>
		void MessageEventSource<__TmessageKey, _Tmessage>::Handle(Header* header, uint64_t timestamp)
		{
			if (header->key_length != sizeof(__TmessageKey))
			{
				throw runtime_error(
					"Invalid MBUS Record: msg.keylen=" + to_string(header->key_length) +
					", obj.keylen=" + to_string(sizeof(__TmessageKey)));
			}

			_Tmessage received;
			received.Decode(header);
			received.time_received(timestamp);

			auto pkey = received.pkey();
			auto entry = objects_by_key_.find(pkey);

			if (entry == objects_by_key_.end())
			{
				lock_guard<mutex> lock(objects_by_key_mutex_);

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

					received.header().bits = ~HeaderBits::FromCache & received.header().bits;

					objects_by_key_.insert(make_pair(pkey, received));

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