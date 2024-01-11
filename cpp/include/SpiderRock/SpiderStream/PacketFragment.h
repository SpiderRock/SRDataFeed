#pragma once

#include <cstdint>
// #include <iostream>
// #include <memory>
// #include <string>
// #include <algorithm>

#define MAX_PACKET_LENGTH 1400
#define PKT_FRAG_HDR_LEN 16
#define PKT_FRAG_PAYLOAD_LEN MAX_PACKET_LENGTH - PKT_FRAG_HDR_LEN

struct PacketFragment
{
#pragma pack(1)
    struct Header
    {
        uint32_t type;
        uint16_t app_id;
        int32_t pid;
        int32_t id;
        int8_t index;
        int8_t count;
    };
#pragma pack()

    Header header;
    uint8_t payload[PKT_FRAG_PAYLOAD_LEN];
};

static_assert(sizeof(PacketFragment::Header) == PKT_FRAG_HDR_LEN, "PacketFragment::Header size is wrong");
