#pragma once

#include "stdafx.h"

#include <cstdint>
#include <memory>
#include <vector>
#include <thread>
#include <string>
#include <stdexcept>

#ifdef _WINDOWS_

// These are defined incorrectly in winsock.h and need to be overriden

#	undef IP_ADD_MEMBERSHIP
#	undef IP_DROP_MEMBERSHIP
#	undef EWOULDBLOCK

#	define	IP_ADD_MEMBERSHIP		12
#	define	IP_DROP_MEMBERSHIP		13
#	define	EWOULDBLOCK				WSAEWOULDBLOCK

#else

#	include <unistd.h>
#	include <netdb.h>
#	include <arpa/inet.h>
#	include <cstdio>
#	include <cstdlib>
#	include <cerrno>
#	include <sys/types.h>
#	include <sys/socket.h>
#	include <netinet/in.h>
#	include <fcntl.h>

typedef int SOCKET;
#define INVALID_SOCKET -1
#define SOCKET_ERROR -1

#endif

#include "Net/IPEndPoint.h"
#include "Net/IPAddress.h"

#include "Net/Proto/ReadHandler.h"
#include "Net/Proto/Receiver.h"

namespace SpiderRock
{
	namespace Net
	{
		namespace Proto
		{
			namespace UDP
			{
				template<class _Tcontext> class Receiver : public SpiderRock::Net::Proto::Receiver < _Tcontext >
				{
					class Channel
					{
						const int32_t BUFFER_LENGTH = 65536;

						SpiderRock::Net::IPAddress if_addr_;
						SpiderRock::Net::IPEndPoint end_point_;
						std::shared_ptr<_Tcontext> context_;
						SOCKET socket_;
						std::unique_ptr<uint8_t[]> buffer_;
						int offset_;
						sockaddr_in raw_end_point_;

					public:
						Channel(const SpiderRock::Net::IPAddress& if_addr, const SpiderRock::Net::IPEndPoint& end_point, std::shared_ptr<_Tcontext> context) :
							if_addr_(if_addr),
							end_point_(end_point),
							context_(context),
							socket_(INVALID_SOCKET),
							buffer_(new uint8_t[BUFFER_LENGTH]),
							offset_(0),
							raw_end_point_(end_point_)
						{
							SR_TRACE_INFO("Subscribing to ", end_point_.label());
#ifdef _WINDOWS_
							WSADATA wsaData;
							if (WSAStartup(MAKEWORD(2, 2), &wsaData) == SOCKET_ERROR)
							{
								SpiderRock::ThrowLastErrorAs<std::runtime_error>();
							}
#endif
							socket_ = socket(AF_INET, SOCK_DGRAM, IPPROTO_IP);
							if (socket_ < 0)
							{
								SpiderRock::ThrowLastErrorAs<std::runtime_error>();
							}

							int reuse = 1;
							if (setsockopt(socket_, SOL_SOCKET, SO_REUSEADDR, (char *)&reuse, sizeof(reuse)) < 0)
							{
								SpiderRock::ThrowLastErrorAs<std::runtime_error>();
							}

#ifdef _WINDOWS_
							u_long mode = 1; /* Non-blocking */
							if (ioctlsocket(socket_, FIONBIO, &mode) == SOCKET_ERROR)
							{
								SpiderRock::ThrowLastErrorAs<std::runtime_error>();
							}
#else
							int opts = fcntl(socket_, F_GETFL);
							if (opts < 0)
							{
								SpiderRock::ThrowLastErrorAs<std::runtime_error>();
							}
							if (fcntl(socket_, F_SETFL, opts & O_NONBLOCK) < 0)
							{
								SpiderRock::ThrowLastErrorAs<std::runtime_error>();
							}
#endif

							struct sockaddr_in local_socket;
							memset(reinterpret_cast<char*>(&local_socket), 0, sizeof(local_socket));
							local_socket.sin_family = AF_INET;
							local_socket.sin_port = htons(end_point_.port());
							local_socket.sin_addr = if_addr_;
							if (bind(socket_, reinterpret_cast<const struct sockaddr*>(&local_socket), static_cast<int>(sizeof(local_socket))) < 0)
							{
								SpiderRock::ThrowLastErrorAs<std::runtime_error>();
							}

							struct ip_mreq group;
							group.imr_multiaddr = end_point_.address();
							group.imr_interface = if_addr_;
							if (setsockopt(socket_, IPPROTO_IP, IP_ADD_MEMBERSHIP, reinterpret_cast<const char*>(&group), sizeof(group)) < 0)
							{
								SpiderRock::ThrowLastErrorAs<std::runtime_error>();
							}
							SR_TRACE_INFO("Subscribed to ", end_point_.label());
						}

						~Channel()
						{
							if (socket_ != INVALID_SOCKET)
							{
								SR_TRACE_INFO("Unsubscribing from ", end_point_.label());

								struct ip_mreq group;
								group.imr_multiaddr = end_point_.address();
								group.imr_interface = if_addr_;
								if (setsockopt(socket_, IPPROTO_IP, IP_DROP_MEMBERSHIP, (char *)&group, sizeof(group)) < 0)
								{
									SpiderRock::ThrowLastErrorAs<std::runtime_error>();
								}

#ifdef _WINDOWS_
								if (closesocket(socket_) == SOCKET_ERROR)
								{
									SpiderRock::ThrowLastErrorAs<std::runtime_error>();
								}
								if (WSACleanup() == SOCKET_ERROR)
								{
									SpiderRock::ThrowLastErrorAs<std::runtime_error>();
								}
#else
								if (close(socket_) < 0)
								{
									SpiderRock::ThrowLastErrorAs<std::runtime_error>();
								}
#endif
								socket_ = INVALID_SOCKET;

								SR_TRACE_INFO("Unsubscribed from ", end_point_.label());
							}
						}

						inline int Read()
						{
							return recv(socket_, reinterpret_cast<char*>(&buffer_[offset_]), BUFFER_LENGTH - offset_, 0);
						}

						inline const IPEndPoint& end_point() const { return end_point_; }
						inline const sockaddr_in& raw_end_point() const { return raw_end_point_; }
						inline _Tcontext* context() const { return context_.get(); }
						inline uint8_t* buffer() const { return &buffer_[offset_]; }
						inline void offset(int value) { offset_ = value; }
					};

					SpiderRock::Net::IPAddress if_addr_;
					SpiderRock::Net::Proto::ReadHandler<_Tcontext>* read_handler_;

					bool cancel_requested_;

					std::vector<std::unique_ptr<Channel>> channels_;
					std::thread worker_thread_;

					void Worker();

				public:
					Receiver(const SpiderRock::Net::IPAddress& if_addr, SpiderRock::Net::Proto::ReadHandler<_Tcontext>* read_handler) :
						if_addr_(if_addr),
						read_handler_(read_handler),
						cancel_requested_(true)
					{
					}

					~Receiver() override final
					{
						Stop();
						channels_.clear();

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

						channels_.push_back(std::unique_ptr<Channel>(new Channel(if_addr_, end_point, context)));
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
					int read_spin_cnt = 0,
						spin_miss_cnt = 0,
						spin_sleep_0 = 0,
						spin_yield_attempt = 0,
						spin_yield_switch = 0,
						read_loop_cnt = 0;

					std::chrono::microseconds zero(0);

					sockaddr_in source;
					memset(&source, 0, sizeof source);

					try
					{
						while (!cancel_requested_)
						{
							for (auto& channel : channels_)
							{
								int received = channel->Read();

								if (received < 1)
								{
									if (received == -1)
									{
										auto last_error = GetLastError();
										if (last_error != EWOULDBLOCK && last_error != EAGAIN)
										{
											SpiderRock::ThrowLastErrorAs<std::runtime_error>();
										}
									}

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

								read_loop_cnt += 1;

								try
								{
									int roffset = read_handler_->Handle(channel->buffer(), received, channel->context(), source);
									if (roffset < 0)
									{
										SR_TRACE_ERROR("handler (parser) error", channel->end_point().label());
									}
									channel->offset(roffset);
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
					catch (const std::exception& e)
					{
						SR_TRACE_ERROR("critical error", e.what());
					}
					catch (...)
					{
						SR_TRACE_ERROR("unknown critical error");
					}
				}
			}
		}
	}
}