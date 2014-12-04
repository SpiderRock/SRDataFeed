using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SpiderRock.DataFeed.Diagnostics
{
    public class SRFileTraceListener : SRTraceListener
    {
        private readonly Func<string, string> logFilePathFactory;

        private readonly Dictionary<string, TextWriter> writersBySource =
            new Dictionary<string, TextWriter>();

        public SRFileTraceListener()
            : this(new DirectoryInfo(@"C:\SRLog"))
        {
        }

        public SRFileTraceListener(DirectoryInfo baseDirectory)
            : this(source => BuildPath(baseDirectory, source))
        {
        }

        public SRFileTraceListener(Func<string, string> logFilePathFactory)
        {
            this.logFilePathFactory = logFilePathFactory;
        }

        internal static SysEnvironment SysEnvironment { get; set; }

        protected override TextWriter GetWriter(string source)
        {
            TextWriter writer;
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

                var logFile = new FileInfo(logFilePathFactory(source));
                if (logFile.Directory != null)
                {
                    logFile.Directory.Create();
                }

                var streamWriter = new StreamWriter(logFile.FullName) {AutoFlush = true};
                writersBySource[source] = writer = streamWriter;
            }

            return writer;
        }

        public static string BuildPath(DirectoryInfo baseDirectory, string source)
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
    }
}