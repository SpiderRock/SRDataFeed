using SpiderRock.DataFeed;
using SpiderRock.DataFeed.Diagnostics;
using System;
using System.Collections.Concurrent;
using System.Threading;


namespace TimeBoxAnalysis
{
    public class FencepostValues
    {
        public static long NANOS_PER_MINUTE = 60_000_000_000;
        public string ticker;
        public long srcTimestamp;
        public float askPrice;
        public float bidPrice;

        public string Update(long ts, float bid, float ask)
        {
            long thisMinute = this.srcTimestamp / NANOS_PER_MINUTE;
            long updateMinute = ts / NANOS_PER_MINUTE;

            string fencePostValue = updateMinute > thisMinute ? this.ToString() : String.Empty;

            if (ts > srcTimestamp)
            {
                srcTimestamp = ts;
                askPrice = ask;
                bidPrice = bid;
            }

            return fencePostValue;
        }

        public override string ToString()
        {
            return $"{ticker},{srcTimestamp},{bidPrice},{askPrice}";
        }

        public static string GetHeader()
        {
            return "Ticker,SrcTimestamp,BidPrice,AskPrice";
        }
    }


    public class StockBookQuoteHandler
    {
        public static ConcurrentDictionary<string, TimeBox> timeBoxSet = new ConcurrentDictionary<string, TimeBox>();
        private string fencepostLogLine = String.Empty;
        public static readonly FileQueueWriter fencepostWriter = new FileQueueWriter("StockFenceposts", FencepostValues.GetHeader(), 250_000, 30);

        private ConcurrentDictionary<string, FencepostValues> fencepostValues = new ConcurrentDictionary<string, FencepostValues>();

        public void OnChange(object sender, ChangedEventArgs<StockBookQuote> args)
        {
            var ticker = args.Changed.Key.Ticker.ToString();

            if (!timeBoxSet.TryGetValue(ticker, out var timeBox))
            {
                timeBox = new TimeBox(ticker);
                timeBoxSet[ticker] = timeBox;
            }

            timeBox.Update(args.Changed);

            if (!fencepostValues.TryGetValue(ticker, out var current))
            {
                current = new FencepostValues();
                current.ticker = ticker;
                fencepostValues[ticker] = current;
            }

            fencepostLogLine = current.Update(args.Changed.SrcTimestamp, args.Changed.BidPrice1, args.Changed.AskPrice1);

            if (!String.IsNullOrEmpty(fencepostLogLine))
            {
                fencepostWriter.WriteRecord(fencepostLogLine);
            }
        }
    }


    public class TimeBox
    {

        public const long TimeBoxSpan = 300_000_000_000;    // 5 minutes

        public static readonly FileQueueWriter fileWriter = new FileQueueWriter("StockTimeBox", GetFileHeader(), 250_000, 30);

        public object lockObject = new object();

        public string ticker;

        public ushort lastSourceID;

        public ushort minSourceID;
        public ushort maxSourceID;

        public long srcTimeBox;

        public bool hasMixedID;

        public int numPrcChgUpdates;
        public int numSizeOnlyUpdates;

        public int numBidImpr;
        public int numBidFade;

        public int numAskImpr;
        public int numAskFade;

        public float lastBidPrc;
        public float lastAskPrc;

        public int numMktNone;
        public int numMktPreOpen;
        public int numMktPreCross;
        public int numMktCross;
        public int numMktOpen;
        public int numMktClosed;
        public int numMktHalted;
        public int numMktAfterHours;

        public int numLockMiss;

        public TimeBox(string ticker)
        {
            this.ticker = ticker;
        }

        public void Update(StockBookQuote tsObj)
        {
            bool lockTaken = false;

            try
            {
                Monitor.TryEnter(lockObject, ref lockTaken);

                if (!lockTaken)
                {
                    numLockMiss += 1;

                    Monitor.Enter(lockObject, ref lockTaken);
                }

                long srcTimeBox = tsObj.SrcTimestamp / TimeBoxSpan;

                if (srcTimeBox != this.srcTimeBox)
                {
                    WriteTimeBox();

                    hasMixedID = false;

                    lastSourceID = 0;

                    minSourceID = 0;
                    maxSourceID = 0;

                    numPrcChgUpdates = 0;
                    numSizeOnlyUpdates = 0;

                    numBidImpr = 0;
                    numBidFade = 0;

                    numAskImpr = 0;
                    numAskFade = 0;

                    numMktNone = 0;
                    numMktPreOpen = 0;
                    numMktPreCross = 0;
                    numMktCross = 0;
                    numMktOpen = 0;
                    numMktClosed = 0;
                    numMktHalted = 0;
                    numMktAfterHours = 0;

                    numLockMiss = 0;

                    this.srcTimeBox = srcTimeBox;
                }

                if (tsObj.header.sourceid != lastSourceID && lastSourceID > 0 && tsObj.header.sourceid > 0)
                {
                    hasMixedID = true;
                }

                lastSourceID = tsObj.header.sourceid;

                if (minSourceID == 0 || tsObj.header.sourceid < minSourceID) minSourceID = tsObj.header.sourceid;
                if (maxSourceID == 0 || tsObj.header.sourceid > maxSourceID) maxSourceID = tsObj.header.sourceid;

                if (tsObj.UpdateType == UpdateType.PrcChange)
                {
                    numPrcChgUpdates += 1;
                }
                else if (tsObj.UpdateType == UpdateType.SizeOnly)
                {
                    numSizeOnlyUpdates += 1;
                }

                if (tsObj.BidPrice1 > lastBidPrc + 0.000001f)
                {
                    numBidImpr += 1;
                }
                else if (tsObj.BidPrice1 < lastBidPrc - 0.000001f)
                {
                    numBidFade += 1;
                }

                if (tsObj.AskPrice1 > lastAskPrc + 0.000001f)
                {
                    numAskImpr += 1;
                }
                else if (tsObj.AskPrice1 < lastAskPrc - 0.000001f)
                {
                    numAskFade += 1;
                }

                switch (tsObj.MarketStatus)
                {
                    case MarketStatus.None:
                        numMktNone += 1;
                        break;

                    case MarketStatus.PreOpen:
                        numMktPreOpen += 1;
                        break;

                    case MarketStatus.PreCross:
                        numMktPreCross += 1;
                        break;

                    case MarketStatus.Cross:
                        numMktCross += 1;
                        break;

                    case MarketStatus.Open:
                        numMktOpen += 1;
                        break;

                    case MarketStatus.Closed:
                        numMktClosed += 1;
                        break;

                    case MarketStatus.Halted:
                        numMktHalted += 1;
                        break;

                    case MarketStatus.AfterHours:
                        numMktAfterHours += 1;
                        break;
                }

                lastBidPrc = tsObj.BidPrice1;
                lastAskPrc = tsObj.AskPrice1;
            }
            catch (Exception e)
            {
                SRTrace.Default.TraceError(e, "TimeBoxError");
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(lockObject);
                }
            }
        }

        public static string GetFileHeader()
        {
            return $"ticker\thasMixedID\tminSourceID\tmaxSourceID\tsrcTimeBox\tnumLockMiss\tnumPrcChgUpdates\tnumSizeOnlyUpdates\tnumBidImpr\tnumBidFade\tnumAskImpr\tnumAskFade\tnumMktNone\tnumMktPreOpen\tnumMktPreCross\tnumMktCross\tnumMktOpen\tnumMktClosed\tnumMktHalted\tnumMktAfterHours";
        }

        public void WriteTimeBox()
        {
            if (hasMixedID || numLockMiss > 0)
            {
                SRTrace.Default.TraceWarning($"TIME.BOX.ERROR ticker={ticker}, srcTimeBox={srcTimeBox:N0}, hasMixedID={hasMixedID}, numLockMiss={numLockMiss:N0}");
            }

            string line = $"{ticker}\t{(hasMixedID ? 'T' : 'F')}\t{minSourceID:N0}\t{maxSourceID:N0}\t{srcTimeBox:N0}\t{numLockMiss:N0}\t{numPrcChgUpdates}\t{numSizeOnlyUpdates}\t{numBidImpr}\t{numBidFade}\t{numAskImpr}\t{numAskFade}\t{numMktNone}\t{numMktPreOpen}\t{numMktPreCross}\t{numMktCross}\t{numMktOpen}\t{numMktClosed}\t{numMktHalted}\t{numMktAfterHours}";

            fileWriter.WriteRecord(line);
        }
    }
}
