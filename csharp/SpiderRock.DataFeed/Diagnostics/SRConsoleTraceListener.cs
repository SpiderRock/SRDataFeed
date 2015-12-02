using System;
using System.IO;

namespace SpiderRock.DataFeed.Diagnostics
{
    public class SRConsoleTraceListener : SRTraceListener
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
    }
}