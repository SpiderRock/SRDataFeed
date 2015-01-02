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
 * Copyright 2013 by Myricom, Inc.  All rights reserved.                 *
 *************************************************************************/



#ifndef _DBL_EXT_H
#define _DBL_EXT_H

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

	/* #ifdef DBL_VERSION_API */
	/* #undef DBL_VERSION_API  */
	/* #define DBL_VERSION_API 0x0004 */
	/* #endif */

#define DBL_PROTO_IS_MTCP(flags)  ((flags & (1 << 7)) != 0)
#define DBL_TYPE_IS_TCP(flags)    ((flags & (1 << 8)) != 0)
#define DBL_INITFLAGS(type,proto) (type << 8 | proto << 7)

#define DBL_TCP  1
#define DBL_UDP  0
#define DBL_BSD  1  /* use the BSD stack */
#define DBL_MYRI 0  /* use the DBL_API for UDP */

	/* set the highest bit if SOCK_STREAM
	   set the 2nd highest bit if DBL_BSD
	   */
#define DBL_CHANNEL_FLAGS(type, proto) DBL_INITFLAGS(type, proto)


	DBL_FUNC(int)
		dbl_ext_accept(dbl_channel_t ch, struct sockaddr *sad, int *len, void *rcontext, dbl_channel_t *rch);


	DBL_FUNC(int)
		dbl_ext_listen(dbl_channel_t ch);


	DBL_FUNC(int)
		dbl_ext_recv(dbl_channel_t ch, enum dbl_recvmode mode, void *buf, size_t len, struct dbl_recv_info *info);



	DBL_FUNC(int)
		dbl_ext_recvmsg(dbl_device_t dev, enum dbl_recvmode recv_mode,
	struct dbl_recv_info **info, int recvmax);


	DBL_FUNC(int)
		dbl_ext_poll(dbl_channel_t *chs, int nchs, int timeout);



	DBL_FUNC(int)
		dbl_ext_getchopt(dbl_channel_t ch, int level, int optname, void *optval, socklen_t *optlen);


	DBL_FUNC(int)
		dbl_ext_setchopt(dbl_channel_t ch, int level, int optname, const void *optval, socklen_t optlen);

	DBL_FUNC(int)
		dbl_ext_channel_type(dbl_channel_t ch);




#ifdef __cplusplus
}
#endif

#endif /* _DBL_EXT_H */
