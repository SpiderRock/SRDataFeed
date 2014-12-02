using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SpiderRock.DataFeed.Diagnostics
{
    public abstract class SRTraceListener : TraceListener
    {
        private const TraceEventType Off = 0;
        private const string DateFormat = "HH:mm:ss.fff";
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

        public override bool IsThreadSafe
        {
            get { return true; }
        }

        protected abstract TextWriter GetWriter(string source);

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id,
            params object[] data)
        {
            TextWriter writer = GetWriter(source);
            string ts = "[" + eventCache.DateTime.ToString(DateFormat) + "] ";

            lock (writer)
            {
                foreach (object o in data)
                {
                    writer.Write(ts);
                    writer.WriteLine(o.ToString());
                }
            }
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id,
            object data)
        {
            TextWriter writer = GetWriter(source);
            lock (writer)
            {
                writer.Write("[");
                writer.Write(eventCache.DateTime.ToString(DateFormat));
                writer.Write("] ");

                writer.WriteLine(data.ToString());
            }
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
        {
            throw new NotSupportedException(GetType().Name + 
                ".TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id) overload not supported");
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id,
            string message)
        {
            TextWriter writer = GetWriter(source);
            lock (writer)
            {
                writer.Write("[");
                writer.Write(eventCache.DateTime.ToString(DateFormat));
                writer.Write("] ");

                if (eventType == Off)
                {
                    writer.WriteLine(message);
                    return;
                }

                writer.Write(EventTypeFormat, EventTypeMap[(int) eventType]);
                writer.WriteLine(message);
            }
        }

        public override void Flush()
        {
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id,
            string format, params object[] args)
        {
            TextWriter writer = GetWriter(source);
            lock (writer)
            {
                writer.Write("[");
                writer.Write(eventCache.DateTime.ToString(DateFormat));
                writer.Write("] ");

                if (eventType == Off)
                {
                    writer.WriteLine(format, args);
                    return;
                }

                writer.Write(EventTypeFormat, EventTypeMap[(int) eventType]);
                writer.WriteLine(format, args);
            }
        }

        public override void TraceTransfer(TraceEventCache eventCache, string source, int id, string message,
            Guid relatedActivityId)
        {
            throw new NotSupportedException(GetType().Name + ".TraceTransfer() not supported");
        }

        public override void Write(string message)
        {
        }

        public override void WriteLine(string message)
        {
        }
    }
}