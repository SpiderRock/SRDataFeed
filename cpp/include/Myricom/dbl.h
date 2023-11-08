/*************************************************************************
 * The contents of this file are subject to the MYRICOM DBL              *
 * NETWORKING SOFTWARE AND DOCUMENTATION LICENSE (the "License");        *
 * User may not use this file except in compliance with the              *
 * License.  The full text of the License can found in LICENSE.TXT       *
 *                                                                       *
 * Software distributed under the License is distributed on an "AS IS"   *
 * basis, WITHOUT WARRANTY OF ANY KIND, either express or implied.  See  *
 * the License for the specific language governing rights and            *
 * limitations under the License.                                        *
 *                                                                       *
 * Copyright 2009 by Myricom, Inc.  All rights reserved.                 *
 *************************************************************************/



#ifndef _DBL_H
#define _DBL_H
#ifdef __cplusplus
extern "C"
{
#endif

/**********************************************************************/
/* Control import/export of symbols and calling convention.           */
/**********************************************************************/
#ifndef _WIN32
#  define DBL_FUNC(type) type
#  define DBL_VAR(type) type
#else
#  ifdef DBL_BUILDING_LIB
#    ifdef __cplusplus
#      define DBL_FUNC(type) extern "C" __declspec(dllexport) type __cdecl
#      define DBL_VAR(type) extern "C" __declspec(dllexport) type
#    else
#      define DBL_FUNC(type) __declspec(dllexport) type __cdecl
#      define DBL_VAR(type) __declspec(dllexport) type
#    endif
#  else
#    ifdef __cplusplus
#      define DBL_FUNC(type) extern "C" __declspec(dllimport) type __cdecl
#      define DBL_VAR(type) extern "C" __declspec(dllimport) type
#    else
#      define DBL_FUNC(type) __declspec(dllimport) type __cdecl
#      define DBL_VAR(type) __declspec(dllimport) type
#    endif
#  endif
#endif

#ifdef _WIN32
typedef HANDLE DBL_OS_HANDLE;
#else
typedef int DBL_OS_HANDLE;
#endif

/* define for use in ioctl call to query NIC time */

#define SIO_GETNICTIME 0x5465 

/* keep cache warm flag by exercising tcp send routine */

#define MSG_WARM 0x20000

/* Opaque/internal-only structures */
typedef struct dbl__ep      *dbl_device_t;
typedef struct dbl__channel *dbl_channel_t;
typedef struct dbl__send    *dbl_send_t;
typedef struct dbl_ticks_ {
  uint64_t nic_ticks;
  uint64_t host_nsecs;
  uint64_t host_nsecs_delay;
} dbl_ticks_t;



/*
 * DBL API version number
 * LSB increases for minor backwards compatible changes in the API
 * MSB increases for incompatible changes in the API
 *
 * dbl release 0.5 is at API version 0x0001
 * dbl_init() can be called multiple times, as long as the DBL_VERSION_API is
 * the same each time.
 */


#define DBL_VERSION_API 0x0003


DBL_FUNC(int) 
dbl_init(uint16_t api_version); /* DBL_VERSION_API */



#define DBL_OPEN_THREADSAFE 0x1


#define DBL_OPEN_DISABLED 0x2


#define DBL_OPEN_HW_TIMESTAMPING 0x4





DBL_FUNC(int) 
dbl_open(const struct in_addr *interface_addr,
         int flags,
	 dbl_device_t *dev_out);
  



DBL_FUNC(int)
dbl_open_if(const char*ifname,
	    int flags,
	    dbl_device_t *dev_out);


struct dbl_device_attrs {
  uint32_t  recvq_filter_mode; /**< DBL receive filter mode, see @ref dbl_filter_mode */
  uint32_t  recvq_size;        /**< Host receive queue size for device */
  uint32_t  hw_timestamping;   /**< Timestamp field is filled in for @ref dbl_recv_info */ 
  uint32_t  reserved_1;
};


DBL_FUNC(int)
dbl_device_get_attrs(dbl_device_t dev, struct dbl_device_attrs *attr);


DBL_FUNC(int)
dbl_device_set_attrs(dbl_device_t dev, const struct dbl_device_attrs *attr);


DBL_FUNC(int)
dbl_device_enable(dbl_device_t dev);



enum dbl_filter_mode {
  DBL_RECV_FILTER_NORMAL = 0,
  DBL_RECV_FILTER_ALLMULTI = 1,
  DBL_RECV_FILTER_RAW = 2
};


DBL_FUNC(int)
dbl_set_filter_mode(dbl_device_t dep, enum dbl_filter_mode mode);


DBL_FUNC(DBL_OS_HANDLE)
dbl_device_handle(dbl_device_t dev);


DBL_FUNC(int) 
dbl_close(dbl_device_t dev);



#define DBL_BIND_REUSEADDR	0x02

#define DBL_BIND_DUP_TO_KERNEL	0x04

#define DBL_BIND_NO_UNICAST	0x08

#define DBL_BIND_BROADCAST	0x10


/* Recv functionality, multicast and unicast.
 * dbl_bind() creates a channel associated with a given port on the
 * specified device.  Incoming packets directed to this port will be received
 * on this channel, and all packets sent through this channel will have
 * this port as the sender address.
 */


DBL_FUNC(int) 
dbl_bind(dbl_device_t dev, int flags, int port,
             void *context, dbl_channel_t *handle_out);


DBL_FUNC(int)
dbl_bind_addr(dbl_device_t dev, const struct in_addr *ipaddr, int flags, int port,
	      void *context, dbl_channel_t *handle_out);
  

DBL_FUNC(int) 
dbl_unbind(dbl_channel_t handle);

/* return bound address for a channel */

 

DBL_FUNC(int) 
dbl_getaddress(dbl_channel_t ch, struct sockaddr_in *sin);

/* return current NIC time */


DBL_FUNC(int) 
dbl_getticks(dbl_device_t dev, dbl_ticks_t *ticks);

/* Join/leave a multicast group
 */

DBL_FUNC(int) 
dbl_mcast_join(dbl_channel_t ch, const struct in_addr *mcast_addr, void *unused);


DBL_FUNC(int) 
dbl_mcast_leave(dbl_channel_t ch, const struct in_addr *mcast_addr);


struct dbl_recv_info {
  
  dbl_channel_t      chan;
  
  void              *chan_context; /* context from dbl_bind() */
  
  void              *in_buffer; 
  
  struct sockaddr_in sin_from;
  
  struct sockaddr_in sin_to;	   /* destination address */
  
  uint32_t           msg_len;
  
  uint64_t	     timestamp;
};


enum dbl_recvmode { 
  
  DBL_RECV_DEFAULT = 0, 
  
  DBL_RECV_NONBLOCK = 1, 
  
  DBL_RECV_BLOCK = 2, 
  
  DBL_RECV_PEEK = 3, 
  
  DBL_RECV_PEEK_MSG = 4, 
#ifdef _WIN32
  
  DBL_RECV_NONBLOCK_SETEVENT = 5,
#endif
};



DBL_FUNC(int) 
dbl_recvfrom(dbl_device_t dev, enum dbl_recvmode mode, 
                 void *buf, size_t len, struct dbl_recv_info *info);

/* 
 * Send functionality
 */

DBL_FUNC(int) 
dbl_send_connect(dbl_channel_t chan, const struct sockaddr_in *dest_sin, 
                     int flags, int ttl, dbl_send_t *hsend);



#define DBL_NONBLOCK 0x4



DBL_FUNC(int) 
dbl_send(dbl_send_t sendh, const void *buf, size_t len, int flags);


DBL_FUNC(int) 
dbl_send_disconnect(dbl_send_t hsend);


DBL_FUNC(int) 
dbl_sendto(dbl_channel_t ch, const struct sockaddr_in *sin,
               const void *buf, size_t len, int flags);

#ifdef _WIN32

DBL_FUNC(int) 
dbl_eventselect(dbl_device_t dev, HANDLE event, long mask);
#endif




#ifdef __cplusplus
}
#endif

#endif /* _DBL_H */
