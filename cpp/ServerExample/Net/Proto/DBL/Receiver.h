#pragma once

#include "stdafx.h"

#include <memory>
#include <vector>
#include <thread>
#include <string>
#include <stdexcept>
#include <chrono>

#include "dbl.h"

#include "Net/IPAddress.h"
#include "Net/IPEndPoint.h"

#include "Net/Proto/Receiver.h"
#include "Net/Proto/ReadHandler.h"

class DblLibraryCallException;
#define THROW_IF_ERROR(dbl_call) do { int rc = dbl_call; if (rc != 0) { throw DblLibraryCallException(std::string(#dbl_call) + std::string(" returned error code ") + std::to_string(rc)); } } while(0)

namespace SpiderRock
{
	namespace Net
	{
		namespace Proto
		{
			namespace DBL
			{
				class DblLibraryCallException : public std::runtime_error
				{
				public:
					DblLibraryCallException(const std::string& message) : std::runtime_error(message)
					{
					}

					~DblLibraryCallException()
					{
					}
				};

				template<class _Tcontext> class Receiver : public SpiderRock::Net::Proto::Receiver<_Tcontext>
				{
					class Channel
					{
						dbl_channel_t channel_;
						SpiderRock::Net::IPEndPoint end_point_;
						std::shared_ptr<_Tcontext> context_;

					public:
						Channel(dbl_device_t dbl_device, const SpiderRock::Net::IPEndPoint& end_point, std::shared_ptr<_Tcontext> context)
							: channel_(nullptr), end_point_(end_point), context_(context)
						{
							THROW_IF_ERROR(dbl_bind(dbl_device, DBL_BIND_REUSEADDR, end_point_.port(), this, &channel_));
							auto addr = (in_addr)end_point_.address();
							THROW_IF_ERROR(dbl_mcast_join(channel_, &addr, NULL));
						}

						~Channel()
						{
							in_addr addr = end_point_.address();
							THROW_IF_ERROR(dbl_mcast_leave(channel_, &addr));
							THROW_IF_ERROR(dbl_unbind(channel_));
							context_ = nullptr;
						}

						inline const SpiderRock::Net::IPEndPoint& end_point() const { return end_point_; }
						inline _Tcontext* context() const { return context_.get(); }
					};

					SpiderRock::Net::IPAddress if_addr_;
					SpiderRock::Net::Proto::ReadHandler<_Tcontext>* read_handler_;
					dbl_device_t dbl_device_;
					std::vector<std::unique_ptr<Channel>> channels_;

					bool cancel_requested_;
					std::thread worker_thread_;

					void Worker();

				public:
					Receiver(const SpiderRock::Net::IPAddress& if_addr, SpiderRock::Net::Proto::ReadHandler<_Tcontext>* read_handler) : 
						if_addr_(if_addr), 
						read_handler_(read_handler), 
						dbl_device_(nullptr), 
						cancel_requested_(true)
					{
						static bool initialized = false;

						if (!initialized)
						{
							THROW_IF_ERROR(dbl_init(DBL_VERSION_API));
							initialized = true;
						}

						in_addr addr = if_addr_;
						THROW_IF_ERROR(dbl_open(&addr, DBL_OPEN_THREADSAFE, &dbl_device_));
					}

					~Receiver() override final
					{
						Stop();
						channels_.clear();
						THROW_IF_ERROR(dbl_close(dbl_device_));
						dbl_device_ = nullptr;
						read_handler_ = nullptr;
					}

					void AddChannel(const SpiderRock::Net::IPEndPoint& end_point, std::shared_ptr<_Tcontext> context) override final
					{
						for (auto& ch : channels_)
						{
							if (ch->end_point() == end_point)
							{
								throw std::invalid_argument(std::string("Channel ") + context->label() + " has already been added");
							}
						}

						channels_.push_back(std::unique_ptr<Channel>(new Channel(dbl_device_, end_point, context)));
					}

					void Start() override final
					{
						cancel_requested_ = false;
						worker_thread_ = std::thread(&Receiver::Worker, this);
					}

					void Stop() override final
					{
						if (cancel_requested_) return;

						cancel_requested_ = true;

						worker_thread_.join();
					}
				};

				template<class _Tcontext>
				void Receiver<_Tcontext>::Worker()
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
						int rc = dbl_recvfrom(dbl_device_, DBL_RECV_NONBLOCK, buf, sizeof buf, &info);

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
							SR_TRACE_ERROR("dbl_recvfrom(): returned an error code", rc);
							continue;
						}

						if (info.msg_len == 0)
						{
							SR_TRACE_ERROR("dbl_recvfrom(): zero length msg", rc);
							continue;
						}

						read_loop_cnt += 1;

						auto channel = reinterpret_cast<Channel*>(info.chan_context);

						try
						{
							int roffset = read_handler_->Handle(buf, info.msg_len, channel->context(), info.sin_from);
							if (roffset < 0)
							{
								SR_TRACE_ERROR("handler (parser) error", channel->end_point().label());
							}
						}
						catch (const std::exception& e)
						{
							SR_TRACE_ERROR("handler error", e.what());
						}
						catch (...)
						{
							SR_TRACE_ERROR("unknown handler error");
						}
					}
				}
			}
		}
	}
}