#pragma once

#include <cstdint>
#include <stdexcept>

namespace SpiderRock
{
    template <typename T>
    class CompactArray16
    {
    private:
        T **arr[256];

    public:
        CompactArray16() : arr{nullptr}
        { 
            for (int i = 0; i < 256; ++i)
            {
                arr[i] = nullptr;
            }
        }

        ~CompactArray16()
        {
            for (int i = 0; i < 256; ++i)
            {
                delete[] arr[i];
            }
        }

        T &operator[](uint16_t index)
        {
            uint8_t high = index >> 8;
            uint8_t low = index & 0x00FF;

            if (arr[high] == nullptr)
            {
                arr[high] = new T *[256]();
            }

            if (arr[high][low] == nullptr)
            {
                arr[high][low] = new T();
            }

            return *arr[high][low];
        }

        // Preventing copying and moving for simplicity
        CompactArray16(const CompactArray16 &) = delete;
        CompactArray16 &operator=(const CompactArray16 &) = delete;
        CompactArray16(CompactArray16 &&) = delete;
        CompactArray16 &operator=(CompactArray16 &&) = delete;
    };
}