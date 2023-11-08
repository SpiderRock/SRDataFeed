using System.Runtime.CompilerServices;
using System.Threading;

namespace SpiderRock.SpiderStream.Diagnostics;

internal sealed class TraceThrottle
{
    private int counter;
    private readonly int max;
    private volatile bool maxReached;

    public TraceThrottle(string label, int max)
    {
        Label = label;
        this.max = max;
    }

    public string Label { get; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryIncrement()
    {
        if (maxReached) return false;
        var c = Interlocked.Increment(ref counter);
        if (c == max)
        {
            SRTrace.Default.TraceWarning($"Warning category '{Label}' reached its max of {max} log messages.  Logging for this error category will be suppressed going forward.");
        }
        else if (c < max)
        {
            return true;
        }
        maxReached = true;
        return false;
    }
}
