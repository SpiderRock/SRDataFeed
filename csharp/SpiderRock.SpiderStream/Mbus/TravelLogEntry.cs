using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.SpiderStream.Mbus;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TravelLogEntry : IEquatable<SysEnvironmentRealm>
{
    public SysEnvironmentRealm sysEnvironmentRealm;
    public RunStatus runStatus;

    public TravelLogEntry(SysEnvironmentRealm sysEnvironmentRealm, RunStatus runStatus = RunStatus.Prod)
    {
        this.sysEnvironmentRealm = sysEnvironmentRealm;
        this.runStatus = runStatus;
    }

    public TravelLogEntry(SysEnvironment sysEnvironment, SysRealm sysRealm, RunStatus runStatus = RunStatus.Prod)
    {
        this.sysEnvironmentRealm = new(sysEnvironment, sysRealm);
        this.runStatus = runStatus;
    }

    public bool IsBlank => sysEnvironmentRealm.IsBlank;

    public override readonly string ToString() => $"{nameof(sysEnvironmentRealm)}={{{sysEnvironmentRealm}}}, {nameof(runStatus)}={runStatus}";

    public override int GetHashCode() => sysEnvironmentRealm.GetHashCode() << 8 | (int)runStatus;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals([NotNullWhen(true)] object obj) => obj is TravelLogEntry other && Equals(other.sysEnvironmentRealm);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(SysEnvironmentRealm other) => sysEnvironmentRealm == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear()
    {
        sysEnvironmentRealm.Clear();
        runStatus = default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyFrom(TravelLogEntry source)
    {
        sysEnvironmentRealm.CopyFrom(source.sysEnvironmentRealm);
        runStatus = source.runStatus;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(TravelLogEntry x, TravelLogEntry y) => x.Equals(y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(TravelLogEntry x, TravelLogEntry y) => !x.Equals(y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator SysEnvironmentRealm(TravelLogEntry entry) => entry.sysEnvironmentRealm;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator SysEnvironment(TravelLogEntry entry) => entry.sysEnvironmentRealm;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator SysRealm(TravelLogEntry entry) => entry.sysEnvironmentRealm;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator RunStatus(TravelLogEntry entry) => entry.runStatus;
}

