#pragma once

#include "stdafx.h"

#include <memory>
#include <vector>
#include <thread>
#include <string>
#include <stdexcept>

#include "dbl.h"
#include "LibraryCallException.h"
#include "ReadHandler.h"

#ifndef SR_LOG_ERR
#	include <iostream>
#	define SR_LOG_ERR(msg) std::cerr << msg << std::endl;
#endif

#include <chrono>
#include "Net/IPEndPoint.h"

#define THROW_IF_ERROR(dbl_call) do { int rc = dbl_call; if (rc != 0) { throw LibraryCallException(std::string(#dbl_call) + std::string(" returned error code ") + std::to_string(rc)); } } while(0)

namespace SpiderRock
{
	namespace Net
	{
		namespace Proto
		{
			namespace DBL
			{
				template<class _Tcontext> class Device
				{
					class Channel
					{
						dbl_channel_t channel_;
						SpiderRock::Net::IPEndPoint end_point_;
						std::shared_ptr<_Tcontext> context_;

					public:
						Channel(dbl_device_t device, const SpiderRock::Net::IPEndPoint& end_point, std::shared_ptr<_Tcontext> context)
							: channel_(nullptr), end_point_(end_point), context_(context)
						{
							THROW_IF_ERROR(dbl_bind(device, DBL_BIND_REUSEADDR, end_point_.port(), this, &channel_));
							auto addr = end_point_.address();
							THROW_IF_ERROR(dbl_mcast_join(channel_, &addr, NULL));
						}

						~Channel()
						{
							auto addr = end_point_.address();
							THROW_IF_ERROR(dbl_mcast_leave(channel_, &addr));
							THROW_IF_ERROR(dbl_unbind(channel_));
							context_ = nullptr;
						}

						inline const SpiderRock::Net::IPEndPoint& end_point() const { return end_point_; }
						inline _Tcontext* context() const { return context_.get(); }
					};

					in_addr if_addr_;
					dbl_device_t device_;

					std::vector<std::unique_ptr<Channel>> channels_;
					ReadHandler<_Tcontext>* read_handler_;

					bool cancel_requested_;
					std::thread worker_thread_;

					void ReceiveWorker();

				public:
					Device(const in_addr& if_addr, ReadHandler<_Tcontext>* read_handler)
						: if_addr_(if_addr), device_(nullptr), read_handler_(read_handler), cancel_requested_(true)
					{
						static bool initialized = false;

						if (!initialized)
						{
							THROW_IF_ERROR(dbl_init(DBL_VERSION_API));
							initialized = true;
						}

						THROW_IF_ERROR(dbl_open(&if_addr_, DBL_OPEN_THREADSAFE, &device_));
					}

					~Device()
					{
						Stop();
						channels_.clear();
						THROW_IF_ERROR(dbl_close(device_));
						device_ = nullptr;
						read_handler_ = nullptr;
					}

					void AddChannel(const SpiderRock::Net::IPEndPoint& end_point, std::shared_ptr<_Tcontext> context);
					void Start();
					void Stop();
				};

				template<class _Tcontext>
				void Device<_Tcontext>::Start()
				{
					cancel_requested_ = false;
					worker_thread_ = std::thread(&Device::ReceiveWorker, this);
				}

				template<class _Tcontext>
				void Device<_Tcontext>::Stop()
				{
					if (cancel_requested_) return;

					cancel_requested_ = true;

					worker_thread_.join();
				}

				template<class _Tcontext>
				void Device<_Tcontext>::AddChannel(const SpiderRock::Net::IPEndPoint& end_point, std::shared_ptr<_Tcontext> context)
				{
					for (auto& ch : channels_)
					{
						if (ch->end_point() == end_point)
						{
							throw std::invalid_argument(std::string("Channel ") + context->label() + " has already been added");
						}
					}

					channels_.push_back(std::unique_ptr<Channel>(new Channel(device_, end_point, context)));
				}

				template<class _Tcontext>
				void Device<_Tcontext>::ReceiveWorker()
				{
					uint8_t buf[65536];
					dbl_recv_info info;

					int read_spin_cnt = 0,
						spin_miss_cnt = 0,
						spin_sleep_0 = 0,
						spin_yield_attempt = 0,
						spin_yield_switch = 0,
						read_loop_cnt = 0;

					std::chrono::microseconds zero(0);

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
							SR_LOG_ERR("dbl_recvfrom(): returned an error code " + std::to_string(rc));
							continue;
						}

						if (info.msg_len == 0)
						{
							SR_LOG_ERR("dbl_recvfrom(): zero length msg");
							continue;
						}

						read_loop_cnt += 1;

						auto channel = reinterpret_cast<Channel*>(info.chan_context);

						try
						{
							int roffset = read_handler_->Handle(buf, info.msg_len, channel->context(), info.sin_from);
							if (roffset < 0)
							{
								SR_LOG_ERR("Parse error on channel " + std::string(inet_ntoa(channel->end_point().address())) + ":" + std::to_string(channel->end_point().port()));
							}
						}
						catch (const std::exception& e)
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
}

#undef SR_LOG_ERR
#undef THROW_IF_ERROR
