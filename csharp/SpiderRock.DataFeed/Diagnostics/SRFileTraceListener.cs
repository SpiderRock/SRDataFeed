using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SpiderRock.DataFeed.Diagnostics
{
    internal class SRFileTraceListener : SRTraceListener, IEquatable<SRFileTraceListener>
    {
        private readonly Dictionary<string, TextWriter> writersBySource =
            new Dictionary<string, TextWriter>();

        public SRFileTraceListener(SysEnvironment sysEnvironment, DirectoryInfo baseDirectory)
        {
            if (baseDirectory == null) throw new ArgumentNullException("baseDirectory");
            SysEnvironment = sysEnvironment;
            BaseDirectory = baseDirectory;
        }

        public override bool IsThreadSafe
        {
            get { return false; }
        }

        public DirectoryInfo BaseDirectory { get; private set; }

        public SysEnvironment SysEnvironment { get; private set; }

        protected override TextWriter GetWriter(string source)
        {
            TextWriter writer;

            // ReSharper disable once InconsistentlySynchronizedField
            if (writersBySource.TryGetValue(source, out writer))
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
            if (source == null) throw new ArgumentNullException("source");

            var process = Process.GetCurrentProcess();

            return Path.Combine(
                baseDirectory.FullName,
                SysEnvironment.ToString().ToLowerInvariant(),
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
}