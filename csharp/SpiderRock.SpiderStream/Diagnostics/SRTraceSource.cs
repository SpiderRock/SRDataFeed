using System;
using System.Diagnostics;
using System.Text;

namespace SpiderRock.SpiderStream.Diagnostics;

public sealed class SRTraceSource : TraceSource
{
    public SRTraceSource(string name) : base(name)
    {
    }

    public SRTraceSource(string name, SourceLevels defaultLevel) : base(name, defaultLevel)
    {
    }

    public void TraceDebug(string message)
    {
        TraceEvent(TraceEventType.Verbose, 0, message, Array.Empty<object>());
    }

    public void TraceInfo(string message)
    {
        TraceEvent(TraceEventType.Information, 0, message, Array.Empty<object>());
    }

    public void TraceWarning(string message)
    {
        TraceEvent(TraceEventType.Warning, 0, message, Array.Empty<object>());
    }

    public void TraceError(string message)
    {
        TraceEvent(TraceEventType.Error, 0, message, Array.Empty<object>());
    }

    [ThreadStatic]
    private static StringBuilder messageBuilder;

    public void TraceError(Exception error, string message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        TraceEvent(TraceEventType.Error, 0, (messageBuilder ??= new StringBuilder(1024)).Clear().Append(message).AppendLine(":").Append(error).ToString());
    }

    public void TraceError(Exception error)
    {
        TraceEvent(TraceEventType.Error, 0, error.ToString());
    }
}
