using System;
using System.IO;

namespace SpiderRock.DataFeed.Diagnostics
{
    public class SRConsoleTraceListener : SRTraceListener
    {
        protected override TextWriter GetWriter(string source)
        {
            return Console.Out;
        }
    }
}