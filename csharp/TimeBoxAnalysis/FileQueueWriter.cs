using SpiderRock.DataFeed.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TimeBoxAnalysis
{

    public class FileQueueWriter : IDisposable
    {
        private static readonly HashSet<FileQueueWriter> Instances = new HashSet<FileQueueWriter>();

        private readonly object lockObject = new object();

        private readonly string basePath;
        private readonly string baseName;
        private readonly string fileHeader;

        private readonly int maxFileLines;
        private readonly int maxFileMinutes;

        private StreamWriter writer;
        private DateTime writerDate;

        private string txtFileName;
        private string tmpFileName;

        private int numLines;

        private bool closeWriter;

        private DateTime created;

        private List<Timer> timerList;

        private int errorCounter;
        private bool fileWriterError;

        public FileQueueWriter(string baseName, string fileHeader, int maxFileLines, int maxFileMinutes, string basePath = null)
        {
            this.basePath = "c:/SRDiagnostics/daily";

            this.baseName = baseName;
            this.fileHeader = fileHeader;

            this.maxFileLines = maxFileLines;
            this.maxFileMinutes = maxFileMinutes;

            lock (Instances)
            {
                Instances.Add(this);
            }
        }

        ~FileQueueWriter()
        {
            RotateFile(writer, txtFileName, tmpFileName);

            lock (Instances)
            {
                Instances.Remove(this);
            }
        }

        public static void Shutdown()
        {
            lock (Instances)
            {
                foreach (var fileQueueWriter in Instances)
                {
                    fileQueueWriter.Dispose();
                }

                Instances.Clear();
            }
        }

        public void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }

        public void AddForceFlushTime(TimeSpan eventTime)
        {
            int dueTime = (int)(eventTime - DateTime.Now.TimeOfDay).TotalMilliseconds;
            if (dueTime < 0) return;

            var timer = new Timer(ForceFlushQueue, null, dueTime, Timeout.Infinite);

            if (timerList == null)
            {
                timerList = new List<Timer>();
            }

            timerList.Add(timer);
        }

        public bool WriterError
        {
            get { return fileWriterError; }
        }

        public void WriteRecord(string record)
        {
            if (record == null) return;

            try
            {
                lock (lockObject)
                {
                    StreamWriter writer = GetCreateWriter();

                    if (writer == null)
                    {
                        fileWriterError = true;
                        return;
                    }

                    writer.WriteLine(record);

                    numLines += 1;

                    if (numLines % 10 == 0)
                    {
                        writer.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                errorCounter += 1;
                fileWriterError = true;

                SRTrace.Default.TraceError(e, $"FILE.QUEUE.WRITER {tmpFileName}");
            }

        }

        public void Close()
        {
            lock (lockObject)
            {
                closeWriter = true;

                RotateFile(writer, txtFileName, tmpFileName);

                writer = null;

                txtFileName = null;
                tmpFileName = null;

                numLines = 0;
            }

            SRTrace.Default.TraceWarning($"FileQueueWriter: CLOSE FILE: [{tmpFileName}]");
        }

        private void InitFileRotate()
        {
            StreamWriter writer;

            string txtFileName = null;
            string tmpFileName = null;

            lock (lockObject)
            {
                writer = this.writer;
                if (writer == null) return;

                txtFileName = this.txtFileName;
                tmpFileName = this.tmpFileName;

                this.writer = null;

                this.txtFileName = null;
                this.tmpFileName = null;

                numLines = 0;
            }

            Task.Factory.StartNew(() => RotateFile(writer, txtFileName, tmpFileName));
        }

        public void Rotate()
        {
            InitFileRotate();
        }

        private void ForceFlushQueue(object state)
        {
            InitFileRotate();
        }

        private StreamWriter GetCreateWriter()
        {
            try
            {
                lock (lockObject)
                {
                    if (closeWriter) return null;
                    if (errorCounter > 100) return null;

                    DateTime now = DateTime.Now;

                    TimeSpan elapsed = now - created;

                    if (numLines >= maxFileLines || elapsed.TotalMinutes >= maxFileMinutes)
                    {
                        InitFileRotate();
                    }

                    if (writerDate == now.Date)
                    {
                        if (writer != null) return writer;
                    }

                    string fileName = $"{basePath}/{now.Year}-{now.Month:D2}-{now.Day:D2}/{baseName}.{now.Hour:D2}.{now.Minute:D2}.{now.Day:D2}";

                    txtFileName = $"{fileName}.txt";
                    tmpFileName = $"{fileName}.tmp";

                    created = now;
                    writerDate = now.Date;

                    SRTrace.Default.TraceWarning($"FileQueueWriter: CREATE FILE: ({tmpFileName})");

                    string dir = Path.GetDirectoryName(txtFileName);

                    if (dir == null)
                    {
                        throw new NullReferenceException($"Path.GetDirectoryName({tmpFileName}) returned a null");
                    }

                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                    //if (File.Exists(tmpFileName))
                    //{
                    //    File.Delete(tmpFileName);
                    //}

                    // We are getting a strange, inconsistent error on Create so I want to give  it some retry attempts in case this is related to OS file indexing
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            writer = File.CreateText(tmpFileName);
                        }
                        catch (Exception e)
                        {
                            if (i == 9)
                            {
                                fileWriterError = true;
                                errorCounter += 1;

                                SRTrace.Default.TraceError(e, $"FileQueueWriter: CREATE EXCEPTION: ({tmpFileName})");
                                return null;
                            }
                            Thread.Sleep(50);
                            continue;
                        }
                        break;
                    }

                    if (!string.IsNullOrWhiteSpace(fileHeader))
                    {
                        writer.WriteLine(fileHeader);
                        writer.Flush();
                    }

                    return writer;
                }
            }
            catch (Exception e)
            {
                fileWriterError = true;
                errorCounter += 1;

                SRTrace.Default.TraceError(e, $"FileQueueWriter: CREATE EXCEPTION: ({tmpFileName})");
            }

            return null;
        }

        private static void RotateFile(StreamWriter writer, string txtFileName, string tmpFileName)
        {

            try
            {
                // close existing writer
                if (writer != null)
                {
                    writer.Close();

                    try
                    {
                        writer.Dispose();
                    }
                    catch (ObjectDisposedException)
                    {
                    }
                }

                // move .tmp -> .txt

                if (tmpFileName != null && txtFileName != null)
                {
                    if (File.Exists(tmpFileName))
                    {
                        SRTrace.Default.TraceWarning($"FileQueueWriter: ROTATE FILE: [{tmpFileName}]");

                        if (File.Exists(txtFileName))
                        {
                            File.Delete(txtFileName);
                        }

                        File.Move(tmpFileName, txtFileName);
                    }
                }
            }
            catch (Exception e)
            {
                SRTrace.Default.TraceError(e, $"FileQueueWriter: ROTATE EXCEPTION: [{tmpFileName}]");
            }

        }

    }
}