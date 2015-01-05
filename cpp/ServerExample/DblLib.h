#pragma once

#include "stdafx.h"

#ifdef _WINDOWS_
#	include <winsock.h>
#else
#	include <netdb.h>
#	include <sys/types.h>
#	include <sys/socket.h>
#	include <netinet/in.h>
#	include <arpa/inet.h>
#endif

#include "dbl.h"

#if !defined(SR_LOG_ERR)
#	include <iostream>
#	define SR_LOG_ERR(msg) std::cerr << msg << std::endl;
#endif

#include <chrono>
using std::chrono::microseconds;

#include "IPEndPoint.h"
using SpiderRock::Net::IPEndPoint;

namespace SpiderRock 
{
	namespace DataFeed
	{
		namespace Myricom 
		{
			class DblException : public runtime_error
			{
			public:
				DblException(const string& message) : runtime_error(message) { }
				~DblException() { }
			};

#define DblLibCall(dbl_call) do { int rc = dbl_call; if (rc != 0) { throw DblException(string(#dbl_call) + string(" returned error code ") + to_string(rc)); } } while(0)

			class DblLib
			{
			public:
				static void Initialize()
				{
					static bool initialized = false;
					if (initialized) return;
					DblLibCall(dbl_init(DBL_VERSION_API));
					initialized = true;
				}
			};

			template<class _Tcontext> class DblReadHandler
			{
			public:
				virtual int Handle(uint8_t* buffer, uint32_t length, _Tcontext* context, const sockaddr_in& source) = 0;
			};

			template<class _Tcontext> class DblDevice
			{
				class DblChannel
				{
					dbl_channel_t channel_;
					IPEndPoint end_point_;
					shared_ptr<_Tcontext> context_;

				public:
					DblChannel(const IPEndPoint& end_point, shared_ptr<_Tcontext> context)
						: channel_(nullptr), end_point_(end_point), context_(context)
					{
					}

					~DblChannel()
					{
						auto addr = end_point_.address();
						DblLibCall(dbl_mcast_leave(channel_, &addr));
						DblLibCall(dbl_unbind(channel_));
						context_ = nullptr;
					}

					inline const IPEndPoint& end_point() const { return end_point_; }
					inline _Tcontext* context() const { return context_.get(); }

					void Join(dbl_device_t device)
					{
						DblLibCall(dbl_bind(device, DBL_BIND_REUSEADDR, end_point_.port(), this, &channel_));
						auto addr = end_point_.address();
						DblLibCall(dbl_mcast_join(channel_, &addr, NULL));
					}

					bool operator == (const DblChannel& other) const
					{
						return end_point_ == other.end_point_;
					}
				};

				in_addr if_addr_;
				dbl_device_t device_;

				vector<unique_ptr<DblChannel>> channels_;
				DblReadHandler<_Tcontext>* read_handler_;

				bool cancel_requested_;
				thread worker_thread_;

				void ReceiveWorker();

			public:
				DblDevice(const in_addr& if_addr, DblReadHandler<_Tcontext>* read_handler)
					: if_addr_(if_addr),  device_(nullptr), read_handler_(read_handler), cancel_requested_(true)
				{
					DblLibCall(dbl_open(&if_addr_, DBL_OPEN_THREADSAFE, &device_));
				}

				~DblDevice()
				{
					Stop();
					channels_.clear();
					DblLibCall(dbl_close(device_));
					device_ = nullptr;
					read_handler_ = nullptr;
				}

				void AddChannel(const IPEndPoint& end_point, shared_ptr<_Tcontext> context);
				void Start();
				void Stop();
			};

			//////////////////////////////////////////////////////////////////
			//
			//		DblDevice implementation
			//
			//////////////////////////////////////////////////////////////////

			template<class _Tcontext>
			void DblDevice<_Tcontext>::Start()
			{
				cancel_requested_ = false;
				worker_thread_ = thread(&DblDevice::ReceiveWorker, this);
			}

			template<class _Tcontext>
			void DblDevice<_Tcontext>::Stop()
			{
				if (cancel_requested_) return;

				cancel_requested_ = true;

				worker_thread_.join();
			}

			template<class _Tcontext>
			void DblDevice<_Tcontext>::AddChannel(const IPEndPoint& end_point, shared_ptr<_Tcontext> context)
			{
				auto channel = make_unique<DblChannel>(end_point, context);

				for (auto& ch : channels_)
				{
					if (*ch == *channel)
					{
						throw DblException(string("Channel ") + context->label() + " has already been added");
					}
				}

				channel->Join(device_);
				channels_.push_back(move(channel));
			}

			template<class _Tcontext>
			void DblDevice<_Tcontext>::ReceiveWorker()
			{
				uint8_t buf[65536];
				dbl_recv_info info;

				int read_spin_cnt = 0,
					spin_miss_cnt = 0,
					spin_sleep_0 = 0,
					spin_yield_attempt = 0,
					spin_yield_switch = 0,
					read_loop_cnt = 0;

				microseconds zero(0);

				while (!cancel_requested_)
				{
					int rc = dbl_recvfrom(device_, DBL_RECV_NONBLOCK, buf, sizeof buf, &info);

					if (rc == EAGAIN)
					{
						++read_spin_cnt; // one spin count is roughly 1us
						++spin_miss_cnt;

						if (spin_miss_cnt > 200)
						{
							++spin_sleep_0;
							std::this_thread::sleep_for(zero);
							if (cancel_requested_)
							{
								return;
							}
						}
						else if (spin_miss_cnt > 40)
						{
							++spin_yield_attempt;

							std::this_thread::yield();
							++spin_yield_switch;
						}

						continue;
					}

					spin_miss_cnt = 0;

					if (rc)
					{
						SR_LOG_ERR("dbl_recvfrom(): returned an error code " + to_string(rc));
						continue;
					}

					if (info.msg_len == 0)
					{
						SR_LOG_ERR("dbl_recvfrom(): zero length msg");
						continue;
					}

					read_loop_cnt += 1;

					auto channel = reinterpret_cast<DblChannel*>(info.chan_context);

					try
					{
						int roffset = read_handler_->Handle(buf, info.msg_len, channel->context(), info.sin_from);
						if (roffset < 0)
						{
							SR_LOG_ERR("Parse error on channel " + string(inet_ntoa(channel->end_point().address())) + ":" + to_string(channel->end_point().port()));
						}
					}
					catch (const exception& e)
					{
						SR_LOG_ERR(e.what());
					}
					catch (...)
					{
						SR_LOG_ERR("Unknown error");
					}
				}
			}
		}
	}
}

#undef SR_LOG_ERR
