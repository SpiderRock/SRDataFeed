using System;
using System.Diagnostics;

namespace SpiderRock.DataFeed.Diagnostics
{
    internal class ProcessStatisticsAggregator : IDisposable
    {
        private static readonly object Header =
            string.Format(
                "{0,10} {1,8} {2,8} {3,8} {4,16} {5,16} {6,16} {7,16} {8,16} {9,16} {10,16} {11,16} {12,16} {13,16} {14,16} {15,16} {16,16} {17,16} {18,16} {19,16} {20,16} {21,16} {22,16} {23,16} {24,16} {25,16} {26,16}",
                "TimeDelta",
                "SysFrac",
                "UsrFrac",
                "TotFrac",
                "MinWorkingSet",
                "MaxWorkingSet",
                "WorkingSet",
                "VirtualMemory",
                "PrivateMemory",
                "PagedMemory",
                "NonPagedMemory",
                "PagedSysMemory",
                "PeakVirtualMem",
                "PeakWorkingSet",
                "gcCnt.0",
                "gcCnt.1",
                "gcCnt.2",
                "gcTotalBytes",
                "TotalClrMem",
                "Gen2Mem",
                "LargeObjMem",
                "ReservedMem",
                "CommittedMem",
                "ContendRate",
                "CurQueueLen",
                "LogicalThrds",
                "PhysicalThrds");

        private readonly Process process;
        private readonly string processName;

        private PerformanceCounter committedMemory;
        private PerformanceCounter contentionRate;
        private PerformanceCounter currentQueueLen;
        private PerformanceCounter gen2Memory;
        private PerformanceCounter largeObjectMemory;
        private PerformanceCounter numLogicalThreads;
        private PerformanceCounter numPhysicalThreads;
        private PerformanceCounter reservedMemory;
        private PerformanceCounter totalMemory;

        private double lastPpt;
        private double lastTpt;
        private double lastUpt;

        private int numMonitorLinesWritten;

        public ProcessStatisticsAggregator()
        {
            process = Process.GetCurrentProcess();
            processName = process.ProcessName;

            SRTrace.Aggregate += OnAggregate;
        }

        ~ProcessStatisticsAggregator()
        {
            InternalDispose();
        }

        private PerformanceCounter GetPerformanceCounter(string categoryName, string counterName)
        {
            try
            {
                return new PerformanceCounter(categoryName, counterName, processName);
            }
            catch
            {
                return null;
            }
        }

        private void OnAggregate(double elapsedSeconds)
        {
            try
            {
                Stopwatch sw = Stopwatch.StartNew();

                if (totalMemory == null)
                {
                    totalMemory = GetPerformanceCounter(".NET CLR Memory", "# bytes in all heaps");
                }

                if (gen2Memory == null)
                {
                    gen2Memory = GetPerformanceCounter(".NET CLR Memory", "gen 2 heap size");
                }

                if (largeObjectMemory == null)
                {
                    largeObjectMemory = GetPerformanceCounter(".NET CLR Memory", "large object heap size");
                }

                if (reservedMemory == null)
                {
                    reservedMemory = GetPerformanceCounter(".NET CLR Memory", "# total reserved bytes");
                }

                if (committedMemory == null)
                {
                    committedMemory = GetPerformanceCounter(".NET CLR Memory", "# total committed bytes");
                }

                if (contentionRate == null)
                {
                    contentionRate = GetPerformanceCounter(".NET CLR LocksAndThreads", "contention rate / sec");
                }

                if (currentQueueLen == null)
                {
                    currentQueueLen = GetPerformanceCounter(".NET CLR LocksAndThreads", "current queue length");
                }

                if (numLogicalThreads == null)
                {
                    numLogicalThreads = GetPerformanceCounter(".NET CLR LocksAndThreads", "# of current logical threads");
                }

                if (numPhysicalThreads == null)
                {
                    numPhysicalThreads = GetPerformanceCounter(".NET CLR LocksAndThreads",
                        "# of current physical threads");
                }

                process.Refresh();

                sw.Stop();

                if (sw.Elapsed.TotalSeconds > 0.010)
                {
                    SRTrace.Default.TraceWarning("ProcessStatisticsAggregator: SLOW PROCESS REFRESH: {0:F3}s", sw.Elapsed.TotalSeconds);
                }

                // --- write process statistics ---                           

                double curPpt = process.PrivilegedProcessorTime.TotalSeconds;
                double curUpt = process.UserProcessorTime.TotalSeconds;
                double curTpt = process.TotalProcessorTime.TotalSeconds;

                double ppt = curPpt - lastPpt;
                double upt = curUpt - lastUpt;
                double tpt = curTpt - lastTpt;

                lastPpt = curPpt;
                lastUpt = curUpt;
                lastTpt = curTpt;

                long minWorkingSet = process.MinWorkingSet.ToInt64();
                long maxWorkingSet = process.MaxWorkingSet.ToInt64();

                object dataLine =
                    string.Format(
                        "{0,10:N0} {1,8:N3} {2,8:N3} {3,8:N3} {4,16:N0} {5,16:N0} {6,16:N0} {7,16:N0} {8,16:N0} {9,16:N0} {10,16:N0} {11,16:N0} {12,16:N0} {13,16:N0} {14,16:N0} {15,16:N0} {16,16:N0} {17,16:N0} {18,16:N0} {19,16:N0} {20,16:N0} {21,16:N0} {22,16:N0} {23,16:N3} {24,16:N0} {25,16:N0} {26,16:N0}",
                        elapsedSeconds,
                        elapsedSeconds > 0.01 ? ppt/elapsedSeconds : 0,
                        elapsedSeconds > 0.01 ? upt/elapsedSeconds : 0,
                        elapsedSeconds > 0.01 ? tpt/elapsedSeconds : 0,
                        minWorkingSet,
                        maxWorkingSet,
                        process.WorkingSet64,
                        process.VirtualMemorySize64,
                        process.PrivateMemorySize64,
                        process.PagedMemorySize64,
                        process.NonpagedSystemMemorySize64,
                        process.PagedSystemMemorySize64,
                        process.PeakVirtualMemorySize64,
                        process.PeakWorkingSet64,
                        GC.CollectionCount(0),
                        GC.CollectionCount(1),
                        GC.CollectionCount(2),
                        GC.GetTotalMemory(false),
                        totalMemory != null ? totalMemory.NextValue() : 0,
                        gen2Memory != null ? gen2Memory.NextValue() : 0,
                        largeObjectMemory != null ? largeObjectMemory.NextValue() : 0,
                        reservedMemory != null ? reservedMemory.NextValue() : 0,
                        committedMemory != null ? committedMemory.NextValue() : 0,
                        contentionRate != null ? contentionRate.NextValue() : 0,
                        currentQueueLen != null ? currentQueueLen.NextValue() : 0,
                        numLogicalThreads != null ? numLogicalThreads.NextValue() : 0,
                        numPhysicalThreads != null ? numPhysicalThreads.NextValue() : 0
                        );

                SRTrace.Process.TraceData(TraceEventType.Verbose, 0,
                    numMonitorLinesWritten++%30 == 0 ? new[] {Header, dataLine} : new[] {dataLine});
            }
            catch (Exception e)
            {
                SRTrace.Default.TraceError(e, "ProcessStatisticsAggregator failure");
            }
        }

        public void Dispose()
        {
            InternalDispose();
            GC.SuppressFinalize(this);
        }

        private void InternalDispose()
        {
            SRTrace.Aggregate -= OnAggregate;
            if (totalMemory != null)
            {
                totalMemory.Dispose();
            }

            if (gen2Memory != null)
            {
                gen2Memory.Dispose();
            }

            if (largeObjectMemory != null)
            {
                largeObjectMemory.Dispose();
            }

            if (reservedMemory != null)
            {
                reservedMemory.Dispose();
            }

            if (committedMemory != null)
            {
                committedMemory.Dispose();
            }

            if (contentionRate != null)
            {
                contentionRate.Dispose();
            }

            if (currentQueueLen != null)
            {
                currentQueueLen.Dispose();
            }

            if (numLogicalThreads != null)
            {
                numLogicalThreads.Dispose();
            }

            if (numPhysicalThreads != null)
            {
                numPhysicalThreads.Dispose();
            }
        }
    }
}