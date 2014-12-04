using System;
using System.Runtime.CompilerServices;

namespace SpiderRock.DataFeed
{
    public enum SysEnvironment : byte
    {
        None = 0,
        Stable = 1,
        Current = 2,
        UAT = 3
    }

    public static class SysEnvironmentExtensions
    {
        private static readonly bool[] SysEnvironments = new bool[byte.MaxValue];

        static SysEnvironmentExtensions()
        {
            foreach (SysEnvironment sysEnv in Enum.GetValues(typeof (SysEnvironment)))
            {
                SysEnvironments[(int) sysEnv] = true;
            }
            SysEnvironments[(int) SysEnvironment.None] = false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValid(this SysEnvironment value)
        {
            return SysEnvironments[(int) value];
        }
    }
}