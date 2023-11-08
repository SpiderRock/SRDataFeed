using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SpiderRock.SpiderStream.Diagnostics;

internal class SRFileTraceListener : SRTraceListener, IEquatable<SRFileTraceListener>
{
    private readonly Dictionary<string, TextWriter> writersBySource =
        new();

    public SRFileTraceListener(string @namespace, DirectoryInfo baseDirectory)
    {
        if (string.IsNullOrWhiteSpace(@namespace))
        {
            throw new ArgumentException($"'{nameof(@namespace)}' cannot be null or whitespace.", nameof(@namespace));
        }

        Namespace = @namespace;
        BaseDirectory = baseDirectory ?? throw new ArgumentNullException(nameof(baseDirectory));
    }

    public override bool IsThreadSafe
    {
        get { return false; }
    }

    public DirectoryInfo BaseDirectory { get; }

    public string Namespace { get; }

    protected override TextWriter GetWriter(string source)
    {

        // ReSharper disable once InconsistentlySynchronizedField
        if (writersBySource.TryGetValue(source, out var writer))
        {
            return writer;
        }

        lock (writersBySource)
        {
            if (writersBySource.TryGetValue(source, out writer))
            {
                return writer;
            }

            var logFile = new FileInfo(BuildPath(BaseDirectory, source));
            if (logFile.Directory != null)
            {
                logFile.Directory.Create();
            }

            var streamWriter = new StreamWriter(logFile.FullName);
            writersBySource[source] = writer = streamWriter;
        }

        return writer;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing)
        {
            lock (writersBySource)
            {
                foreach (var value in writersBySource.Values)
                {
                    value.Close();
                }
                writersBySource.Clear();
            }
        }
    }

    public string BuildPath(DirectoryInfo baseDirectory, string source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        var process = Process.GetCurrentProcess();

        return Path.Combine(
            baseDirectory.FullName,
            Namespace.ToLowerInvariant(),
            process.StartTime.ToString("yyyy-MM-dd"),
            process.ProcessName + "p." + process.Id,
            source.ToLowerInvariant() + "." + process.StartTime.ToString("HH.mm.ss") + ".log");
    }

    public override bool Equals(object other)
    {
        return Equals(other as SRFileTraceListener);
    }

    public bool Equals(SRFileTraceListener other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(BaseDirectory.FullName, other.BaseDirectory.FullName,
            StringComparison.InvariantCultureIgnoreCase);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (GetType().GetHashCode()*397) ^ BaseDirectory.FullName.ToUpperInvariant().GetHashCode();
        }
    }
}
