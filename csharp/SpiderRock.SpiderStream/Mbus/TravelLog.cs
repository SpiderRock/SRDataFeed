using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.SpiderStream.Mbus;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct TravelLog
{
    public const int MaxEntries = 3; /* origin + entry1 + entry2, update if slots for more entries added */

    public byte entries;
    public TravelLogEntry origin;
    public TravelLogEntry entry1;
    public TravelLogEntry entry2;

    public bool IsFull => !entry2.IsBlank;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(SysEnvironmentRealm entry)
    {
        fixed (TravelLog* self = &this)
        {
            TravelLogEntry* ep = &self->origin;

            for (int i = 0; i < entries; i++)
            {
                if (*(ep++) == entry)
                {
                    return true;
                }
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(SysEnvironment sysEnvironment, SysRealm sysRealm) => Contains(new(sysEnvironment, sysRealm));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryAppend(SysEnvironment sysEnvironment, SysRealm sysRealm, RunStatus runStatus) => TryAppend(new(sysEnvironment, sysRealm, runStatus));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryAppend(SysEnvironmentRealm sysEnvironmentRealm, RunStatus runStatus) => TryAppend(new(sysEnvironmentRealm, runStatus));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryAppend(TravelLogEntry entry)
    {
        fixed (TravelLog* self = &this)
        {
            TravelLogEntry* ep = &self->origin;

            for (int i = 0; i < MaxEntries; i++)
            {
                if (ep->IsBlank)
                {
                    ep->CopyFrom(entry);
                    entries++;
                    return true;
                }
                else if (ep->Equals(entry))
                {
                    ep->CopyFrom(entry);
                    return true;
                }
                ep++;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear()
    {
        entry2.Clear();
        entry1.Clear();
        origin.Clear();
    }
}

