#pragma once

#include <memory>
#include <unordered_map>

#include "PacketFragment.h"

#define NUMBLOCKS(x,y) (((x) + (y) - 1) / (y))

class Packetizer
{
private:
    struct SenderState
    {
        int32_t pid;
        int32_t msg_id;
        int32_t count;
        uint8_t buffer[MAX_PACKET_LENGTH * NUMBLOCKS(MAX_MESSAGE_LENGTH, PKT_FRAG_PAYLOAD_LEN)];
        uint16_t msg_len;
    };

    /* corresponds to SRMsgBase.Header field values:
            sysEnvironment = 0x00 (None),
            messageType = 0x0000 (None),
            bits = 0xFF (All ON which makes no sense) */
    const uint32_t FragmentType = 0xFF000000;

    std::unordered_map<app_id_t, std::shared_ptr<SenderState>> sender_states_;

public:
    Packetizer() :
        sender_states_()
    {
    }

    bool IsFragment(void* message, size_t msg_len) const noexcept;

    bool TryCompleteMessage(void*& message, message_length_t& msg_len) noexcept;
};

inline bool Packetizer::IsFragment(void* message, size_t msg_len) const noexcept
{
    if (msg_len < sizeof(PacketFragment::Header))
    {
        return false;
    }

    auto pkt_hdr = reinterpret_cast<PacketFragment::Header*>(message);
    return pkt_hdr->type == FragmentType;
}

inline bool Packetizer::TryCompleteMessage(void*& message, message_length_t& msg_len) noexcept
{
    auto pkt_frag = reinterpret_cast<PacketFragment*>(message);
    auto pkt_frag_hdr = &pkt_frag->header;

    auto entry = sender_states_.find(pkt_frag_hdr->app_id);
    std::shared_ptr<SenderState> sender_state;

    if (entry == sender_states_.end())
    {
        sender_state = std::make_shared<SenderState>();
        sender_states_.insert(std::make_pair(pkt_frag_hdr->app_id, sender_state));
    }
    else
    {
        sender_state = entry->second;
    }

    if (pkt_frag_hdr->index + 1 == pkt_frag_hdr->count)
    {
        if (--sender_state->count == 0)
        {
            // dispatch

            auto payload_length = msg_len - sizeof(PacketFragment::Header);

            std::memcpy(sender_state->buffer + sender_state->msg_len, &pkt_frag->payload, payload_length);

            message = sender_state->buffer;
            msg_len = static_cast<message_length_t>(payload_length + sender_state->msg_len);

            return true;
        }
    }
    else if (msg_len == sizeof(PacketFragment))
    {
        // buffer

        if (pkt_frag_hdr->index == 0)
        {
            sender_state->pid = pkt_frag_hdr->pid;
            sender_state->msg_id = pkt_frag_hdr->id;
            sender_state->count = pkt_frag_hdr->count - 1;
            sender_state->msg_len = static_cast<message_length_t>(PKT_FRAG_PAYLOAD_LEN);

            std::memcpy(sender_state->buffer, pkt_frag->payload, PKT_FRAG_PAYLOAD_LEN);
        }
        else if (pkt_frag_hdr->pid == sender_state->pid && pkt_frag_hdr->id == sender_state->msg_id)
        {
            sender_state->count -= 1;

            std::memcpy(sender_state->buffer + sender_state->msg_len, pkt_frag->payload, PKT_FRAG_PAYLOAD_LEN);
            sender_state->msg_len += PKT_FRAG_PAYLOAD_LEN;
        }
    }

    return false;
}
