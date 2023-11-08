using System;

namespace SpiderRock.SpiderStream.Mbus;

[Flags]
public enum HeaderBits : byte
{
    None = 0,

    IsDeleted = 1 << 0,
    FromRotation = 1 << 7,

    FromCache = 1 << 1,
    FromBridge = 1 << 2,
    FromApplication = 1 << 6,

    /// <summary>
    /// Bits that can be set individually
    /// </summary>
    IndividualBits = 0xFF ^ ExclusiveFrom,

    /// <summary>
    /// Mutually exclusive bits
    /// </summary>
    ExclusiveFrom = FromCache | FromBridge | FromApplication
}
