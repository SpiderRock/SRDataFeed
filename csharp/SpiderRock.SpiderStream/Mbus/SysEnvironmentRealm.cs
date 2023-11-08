using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.SpiderStream.Mbus;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SysEnvironmentRealm : IEquatable<SysEnvironmentRealm>
{
    public SysEnvironment sysEnvironment;
    public SysRealm sysRealm;

    public SysEnvironmentRealm(SysEnvironment sysEnvironment, SysRealm sysRealm)
    {
        this.sysEnvironment = sysEnvironment;
        this.sysRealm = sysRealm;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear()
    {
        sysEnvironment = default;
        sysRealm = default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyFrom(SysEnvironmentRealm source)
    {
        sysEnvironment = source.sysEnvironment;
        sysRealm = source.sysRealm;
    }

    public bool IsBlank => sysEnvironment == default && sysRealm == default;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(SysEnvironmentRealm other) => sysEnvironment == other.sysEnvironment && sysRealm == other.sysRealm;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals([NotNullWhen(true)] object obj) => obj is SysEnvironmentRealm other && Equals(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => (int)sysRealm | ((int)sysEnvironment << 8);

    public override string ToString() => $"{nameof(sysEnvironment)}={sysEnvironment}, {nameof(sysRealm)}={sysRealm}";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(SysEnvironmentRealm x, SysEnvironmentRealm y) => x.Equals(y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(SysEnvironmentRealm x, SysEnvironmentRealm y) => !x.Equals(y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator SysEnvironment(SysEnvironmentRealm entry) => entry.sysEnvironment;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator SysRealm(SysEnvironmentRealm entry) => entry.sysRealm;
}

