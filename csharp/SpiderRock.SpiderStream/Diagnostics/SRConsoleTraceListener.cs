using System;
using System.IO;

namespace SpiderRock.SpiderStream.Diagnostics;

internal class SRConsoleTraceListener : SRTraceListener, IEquatable<SRConsoleTraceListener>
{
    public override bool IsThreadSafe
    {
        get { return true; }
    }

    protected override TextWriter GetWriter(string source)
    {
        return Console.Out;
    }

    public override void Flush()
    {
        Console.Out.Flush();
    }

    public override bool Equals(object other)
    {
        return Equals(other as SRConsoleTraceListener);
    }

    public bool Equals(SRConsoleTraceListener other)
    {
        if (ReferenceEquals(null, other)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode();
    }
}