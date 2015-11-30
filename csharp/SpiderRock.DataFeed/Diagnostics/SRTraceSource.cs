using System;
using System.Diagnostics;
using System.Text;

namespace SpiderRock.DataFeed.Diagnostics
{
    public sealed class SRTraceSource : TraceSource
    {
        public SRTraceSource(string name) : base(name)
        {
        }

        public SRTraceSource(string name, SourceLevels defaultLevel) : base(name, defaultLevel)
        {
        }

        public void TraceDebug(string format, params object[] args)
        {
            TraceEvent(TraceEventType.Verbose, 0, format, args);
        }

        public void TraceWarning(string format, params object[] args)
        {
            TraceEvent(TraceEventType.Warning, 0, format, args);
        }

        public void TraceError(string format, params object[] args)
        {
            TraceEvent(TraceEventType.Error, 0, format, args);
        }

        [ThreadStatic]
        private static StringBuilder messageBuilder;

        public void TraceError(Exception error, string format, params object[] args)
        {
            if (error == null) throw new ArgumentNullException("error");
            if (format == null) throw new ArgumentNullException("format");
            if (args == null) throw new ArgumentNullException("args");

            if (messageBuilder == null)
            {
                messageBuilder = new StringBuilder(1024);
            }
            else
            {
                messageBuilder.Clear();
            }
            messageBuilder.AppendFormat(format, args);
            messageBuilder.AppendLine(":");
            messageBuilder.Append(error);

            TraceEvent(TraceEventType.Error, 0, messageBuilder.ToString());
        }

        public void TraceError(Exception error)
        {
            TraceEvent(TraceEventType.Error, 0, error.ToString());
        }
    }
}