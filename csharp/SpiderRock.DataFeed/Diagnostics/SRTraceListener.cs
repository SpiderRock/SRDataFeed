using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SpiderRock.DataFeed.Diagnostics
{
    public abstract class SRTraceListener : TraceListener
    {
        private const TraceEventType Off = 0;
        private const string EventTypeFormat = "{0,-6} : ";

        private static readonly string[] EventTypeMap;

        static SRTraceListener()
        {
            int[] values = Enum.GetValues(typeof (TraceEventType)).Cast<int>().ToArray();
            EventTypeMap = new string[values.Max() + 1];
            EventTypeMap[(int) TraceEventType.Error] = "Error";
            EventTypeMap[(int) TraceEventType.Critical] = "Fatal";
            EventTypeMap[(int) TraceEventType.Information] = "Info";
            EventTypeMap[(int) TraceEventType.Warning] = "Warn";
            EventTypeMap[(int) TraceEventType.Verbose] = "Debug";
            EventTypeMap[(int) TraceEventType.Start] = "Start";
            EventTypeMap[(int) TraceEventType.Stop] = "Stop";

            EventTypeMap[(int) TraceEventType.Resume] = "Info";
            EventTypeMap[(int) TraceEventType.Suspend] = "Info";
            EventTypeMap[(int) TraceEventType.Transfer] = "Info";
        }

        private TextWriter writer;

        protected abstract TextWriter GetWriter(string source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetTimestamp(TraceEventCache eventCache)
        {
            return "[" + eventCache.DateTime.ToLocalTime().ToString("HH:mm:ss.fff") + "] ";
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id,
            params object[] data)
        {
            writer = GetWriter(source);

            string ts = GetTimestamp(eventCache);

            foreach (object o in data)
            {
                writer.Write(ts);
                writer.WriteLine(o.ToString());
            }
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id,
            object data)
        {
            writer = GetWriter(source);

            writer.Write(GetTimestamp(eventCache));
            writer.WriteLine(data.ToString());
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
        {
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id,
            string message)
        {
            writer = GetWriter(source);

            writer.Write(GetTimestamp(eventCache));

            if (eventType == Off)
            {
                writer.WriteLine(message);
                return;
            }

            writer.Write(EventTypeFormat, EventTypeMap[(int) eventType]);
            writer.WriteLine(message);
        }

        public override void Flush()
        {
            if (writer == null) return;
            try
            {
                writer.Flush();
            }
            catch (ObjectDisposedException)
            {
                writer = null;
            }
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id,
            string format, params object[] args)
        {
            writer = GetWriter(source);

            writer.Write(GetTimestamp(eventCache));

            if (eventType == Off)
            {
                writer.WriteLine(format, args);
                return;
            }

            writer.Write(EventTypeFormat, EventTypeMap[(int) eventType]);
            writer.WriteLine(format, args);
        }

        public override void TraceTransfer(TraceEventCache eventCache, string source, int id, string message,
            Guid relatedActivityId)
        {
        }

        public override void Write(string message)
        {
        }

        public override void WriteLine(string message)
        {
        }
    }
}