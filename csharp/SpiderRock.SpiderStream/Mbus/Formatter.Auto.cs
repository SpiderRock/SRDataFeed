// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2023, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SpiderRock.SpiderStream.Mbus.Layouts;


namespace SpiderRock.SpiderStream.Mbus;

internal unsafe partial class Formatter
{
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, FutureBookQuote dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, FutureBookQuote dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(FutureBookQuote.PKeyLayout) + sizeof(FutureBookQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding FutureBookQuote");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((FutureBookQuote.PKeyLayout*) src); src += sizeof(FutureBookQuote.PKeyLayout);
             dest.body = *((FutureBookQuote.BodyLayout*) src); src += sizeof(FutureBookQuote.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, FuturePrint dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, FuturePrint dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(FuturePrint.PKeyLayout) + sizeof(FuturePrint.BodyLayout) > max) throw new IOException("Max exceeded decoding FuturePrint");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((FuturePrint.PKeyLayout*) src); src += sizeof(FuturePrint.PKeyLayout);
             dest.body = *((FuturePrint.BodyLayout*) src); src += sizeof(FuturePrint.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, FuturePrintMarkup dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, FuturePrintMarkup dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(FuturePrintMarkup.PKeyLayout) + sizeof(FuturePrintMarkup.BodyLayout) > max) throw new IOException("Max exceeded decoding FuturePrintMarkup");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((FuturePrintMarkup.PKeyLayout*) src); src += sizeof(FuturePrintMarkup.PKeyLayout);
             dest.body = *((FuturePrintMarkup.BodyLayout*) src); src += sizeof(FuturePrintMarkup.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, IndexQuote dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, IndexQuote dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(IndexQuote.PKeyLayout) + sizeof(IndexQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding IndexQuote");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((IndexQuote.PKeyLayout*) src); src += sizeof(IndexQuote.PKeyLayout);
             dest.body = *((IndexQuote.BodyLayout*) src); src += sizeof(IndexQuote.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, LiveImpliedQuote dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, LiveImpliedQuote dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(LiveImpliedQuote.PKeyLayout) + sizeof(LiveImpliedQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding LiveImpliedQuote");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((LiveImpliedQuote.PKeyLayout*) src); src += sizeof(LiveImpliedQuote.PKeyLayout);
             dest.body = *((LiveImpliedQuote.BodyLayout*) src); src += sizeof(LiveImpliedQuote.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, LiveSurfaceAtm dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, LiveSurfaceAtm dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(LiveSurfaceAtm.PKeyLayout) + sizeof(LiveSurfaceAtm.BodyLayout) > max) throw new IOException("Max exceeded decoding LiveSurfaceAtm");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((LiveSurfaceAtm.PKeyLayout*) src); src += sizeof(LiveSurfaceAtm.PKeyLayout);
             dest.body = *((LiveSurfaceAtm.BodyLayout*) src); src += sizeof(LiveSurfaceAtm.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, OptionCloseMark dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, OptionCloseMark dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(OptionCloseMark.PKeyLayout) + sizeof(OptionCloseMark.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionCloseMark");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((OptionCloseMark.PKeyLayout*) src); src += sizeof(OptionCloseMark.PKeyLayout);
             dest.body = *((OptionCloseMark.BodyLayout*) src); src += sizeof(OptionCloseMark.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, OptionExchOrder dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, OptionExchOrder dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(OptionExchOrder.PKeyLayout) + sizeof(OptionExchOrder.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionExchOrder");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((OptionExchOrder.PKeyLayout*) src); src += sizeof(OptionExchOrder.PKeyLayout);
             dest.body = *((OptionExchOrder.BodyLayout*) src); src += sizeof(OptionExchOrder.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, OptionExchPrint dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, OptionExchPrint dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(OptionExchPrint.PKeyLayout) + sizeof(OptionExchPrint.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionExchPrint");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((OptionExchPrint.PKeyLayout*) src); src += sizeof(OptionExchPrint.PKeyLayout);
             dest.body = *((OptionExchPrint.BodyLayout*) src); src += sizeof(OptionExchPrint.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, OptionMarketSummary dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, OptionMarketSummary dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(OptionMarketSummary.PKeyLayout) + sizeof(OptionMarketSummary.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionMarketSummary");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((OptionMarketSummary.PKeyLayout*) src); src += sizeof(OptionMarketSummary.PKeyLayout);
             dest.body = *((OptionMarketSummary.BodyLayout*) src); src += sizeof(OptionMarketSummary.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, OptionNbboQuote dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, OptionNbboQuote dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(OptionNbboQuote.PKeyLayout) + sizeof(OptionNbboQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionNbboQuote");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((OptionNbboQuote.PKeyLayout*) src); src += sizeof(OptionNbboQuote.PKeyLayout);
             dest.body = *((OptionNbboQuote.BodyLayout*) src); src += sizeof(OptionNbboQuote.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, OptionOpenInterest dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, OptionOpenInterest dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(OptionOpenInterest.PKeyLayout) + sizeof(OptionOpenInterest.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionOpenInterest");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((OptionOpenInterest.PKeyLayout*) src); src += sizeof(OptionOpenInterest.PKeyLayout);
             dest.body = *((OptionOpenInterest.BodyLayout*) src); src += sizeof(OptionOpenInterest.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, OptionPrint dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, OptionPrint dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(OptionPrint.PKeyLayout) + sizeof(OptionPrint.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionPrint");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((OptionPrint.PKeyLayout*) src); src += sizeof(OptionPrint.PKeyLayout);
             dest.body = *((OptionPrint.BodyLayout*) src); src += sizeof(OptionPrint.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, OptionPrint2 dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, OptionPrint2 dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(OptionPrint2.PKeyLayout) + sizeof(OptionPrint2.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionPrint2");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((OptionPrint2.PKeyLayout*) src); src += sizeof(OptionPrint2.PKeyLayout);
             dest.body = *((OptionPrint2.BodyLayout*) src); src += sizeof(OptionPrint2.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, OptionPrintMarkup dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, OptionPrintMarkup dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(OptionPrintMarkup.PKeyLayout) + sizeof(OptionPrintMarkup.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionPrintMarkup");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((OptionPrintMarkup.PKeyLayout*) src); src += sizeof(OptionPrintMarkup.PKeyLayout);
             dest.body = *((OptionPrintMarkup.BodyLayout*) src); src += sizeof(OptionPrintMarkup.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, OptionRiskFactor dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, OptionRiskFactor dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(OptionRiskFactor.PKeyLayout) + sizeof(OptionRiskFactor.BodyLayout) > max) throw new IOException("Max exceeded decoding OptionRiskFactor");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((OptionRiskFactor.PKeyLayout*) src); src += sizeof(OptionRiskFactor.PKeyLayout);
             dest.body = *((OptionRiskFactor.BodyLayout*) src); src += sizeof(OptionRiskFactor.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, ProductDefinitionV2 dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, ProductDefinitionV2 dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(ProductDefinitionV2.PKeyLayout) + sizeof(ProductDefinitionV2.BodyLayout) > max) throw new IOException("Max exceeded decoding ProductDefinitionV2");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((ProductDefinitionV2.PKeyLayout*) src); src += sizeof(ProductDefinitionV2.PKeyLayout);
             dest.body = *((ProductDefinitionV2.BodyLayout*) src); src += sizeof(ProductDefinitionV2.BodyLayout);
 
            // LegsItem Repeat Section

            if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding ProductDefinitionV2.Legs length");
            ushort size = *((ushort*) src); src += sizeof(ushort);
            if (src + size * ProductDefinitionV2.LegsItem.Length > max) throw new IOException("Max exceeded decoding ProductDefinitionV2.Legs items");

            dest.LegsList = new ProductDefinitionV2.LegsItem[size];
            
            for (int i = 0; i < size; i++)
            {
                var item = new ProductDefinitionV2.LegsItem();
                    item.LegID = *((FixedString24Layout*) src); src += sizeof(FixedString24Layout);
                     item.SecKey = OptionKey.GetCreateOptionKey(*((OptionKeyLayout*) src)); src += sizeof(OptionKeyLayout);
                     item.SecType = *((SpdrKeyType*) src); src++;
                     item.Side = *((BuySell*) src); src++;
                     item.Ratio = *((ushort*) src); src += sizeof(ushort);
                     item.RefDelta = *((float*) src); src += sizeof(float);
                     item.RefPrc = *((double*) src); src += sizeof(double);

                dest.LegsList[i] = item;
            }
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, RootDefinition dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, RootDefinition dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(RootDefinition.PKeyLayout) + sizeof(RootDefinition.BodyLayout) > max) throw new IOException("Max exceeded decoding RootDefinition");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((RootDefinition.PKeyLayout*) src); src += sizeof(RootDefinition.PKeyLayout);
             dest.body = *((RootDefinition.BodyLayout*) src); src += sizeof(RootDefinition.BodyLayout);
 
            // UnderlyingItem Repeat Section

            if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding RootDefinition.Underlying length");
            ushort size = *((ushort*) src); src += sizeof(ushort);
            if (src + size * RootDefinition.UnderlyingItem.Length > max) throw new IOException("Max exceeded decoding RootDefinition.Underlying items");

            dest.UnderlyingList = new RootDefinition.UnderlyingItem[size];
            
            for (int i = 0; i < size; i++)
            {
                var item = new RootDefinition.UnderlyingItem();
                    item.Ticker = TickerKey.GetCreateTickerKey(*((TickerKeyLayout*) src)); src += sizeof(TickerKeyLayout);
                     item.Spc = *((float*) src); src += sizeof(float);

                dest.UnderlyingList[i] = item;
            }
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, SpdrAuctionState dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, SpdrAuctionState dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(SpdrAuctionState.PKeyLayout) + sizeof(SpdrAuctionState.BodyLayout) > max) throw new IOException("Max exceeded decoding SpdrAuctionState");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((SpdrAuctionState.PKeyLayout*) src); src += sizeof(SpdrAuctionState.PKeyLayout);
             dest.body = *((SpdrAuctionState.BodyLayout*) src); src += sizeof(SpdrAuctionState.BodyLayout);
 
            // LegsItem Repeat Section

            if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding SpdrAuctionState.Legs length");
            ushort size = *((ushort*) src); src += sizeof(ushort);
            if (src + size * SpdrAuctionState.LegsItem.Length > max) throw new IOException("Max exceeded decoding SpdrAuctionState.Legs items");

            dest.LegsList = new SpdrAuctionState.LegsItem[size];
            
            for (int i = 0; i < size; i++)
            {
                var item = new SpdrAuctionState.LegsItem();
                    item.LegSecKey = OptionKey.GetCreateOptionKey(*((OptionKeyLayout*) src)); src += sizeof(OptionKeyLayout);
                     item.LegSecType = *((SpdrKeyType*) src); src++;
                     item.LegSide = *((BuySell*) src); src++;
                     item.LegRatio = *((ushort*) src); src += sizeof(ushort);

                dest.LegsList[i] = item;
            }
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, SpreadBookQuote dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, SpreadBookQuote dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(SpreadBookQuote.PKeyLayout) + sizeof(SpreadBookQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding SpreadBookQuote");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((SpreadBookQuote.PKeyLayout*) src); src += sizeof(SpreadBookQuote.PKeyLayout);
             dest.body = *((SpreadBookQuote.BodyLayout*) src); src += sizeof(SpreadBookQuote.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, SpreadExchOrder dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, SpreadExchOrder dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(SpreadExchOrder.PKeyLayout) + sizeof(SpreadExchOrder.BodyLayout) > max) throw new IOException("Max exceeded decoding SpreadExchOrder");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((SpreadExchOrder.PKeyLayout*) src); src += sizeof(SpreadExchOrder.PKeyLayout);
             dest.body = *((SpreadExchOrder.BodyLayout*) src); src += sizeof(SpreadExchOrder.BodyLayout);
 
            // LegsItem Repeat Section

            if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding SpreadExchOrder.Legs length");
            ushort size = *((ushort*) src); src += sizeof(ushort);
            if (src + size * SpreadExchOrder.LegsItem.Length > max) throw new IOException("Max exceeded decoding SpreadExchOrder.Legs items");

            dest.LegsList = new SpreadExchOrder.LegsItem[size];
            
            for (int i = 0; i < size; i++)
            {
                var item = new SpreadExchOrder.LegsItem();
                    item.LegSecKey = OptionKey.GetCreateOptionKey(*((OptionKeyLayout*) src)); src += sizeof(OptionKeyLayout);
                     item.LegSecType = *((SpdrKeyType*) src); src++;
                     item.LegSide = *((BuySell*) src); src++;
                     item.LegRatio = *((uint*) src); src += sizeof(uint);
                     item.PositionType = *((PositionType*) src); src++;

                dest.LegsList[i] = item;
            }
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, SpreadExchPrint dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, SpreadExchPrint dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(SpreadExchPrint.PKeyLayout) + sizeof(SpreadExchPrint.BodyLayout) > max) throw new IOException("Max exceeded decoding SpreadExchPrint");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((SpreadExchPrint.PKeyLayout*) src); src += sizeof(SpreadExchPrint.PKeyLayout);
             dest.body = *((SpreadExchPrint.BodyLayout*) src); src += sizeof(SpreadExchPrint.BodyLayout);
 
            // LegsItem Repeat Section

            if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding SpreadExchPrint.Legs length");
            ushort size = *((ushort*) src); src += sizeof(ushort);
            if (src + size * SpreadExchPrint.LegsItem.Length > max) throw new IOException("Max exceeded decoding SpreadExchPrint.Legs items");

            dest.LegsList = new SpreadExchPrint.LegsItem[size];
            
            for (int i = 0; i < size; i++)
            {
                var item = new SpreadExchPrint.LegsItem();
                    item.LegSecKey = OptionKey.GetCreateOptionKey(*((OptionKeyLayout*) src)); src += sizeof(OptionKeyLayout);
                     item.LegSecType = *((SpdrKeyType*) src); src++;
                     item.LegSide = *((BuySell*) src); src++;
                     item.LegRatio = *((uint*) src); src += sizeof(uint);
                     item.PositionType = *((PositionType*) src); src++;

                dest.LegsList[i] = item;
            }
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, StockBookQuote dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, StockBookQuote dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(StockBookQuote.PKeyLayout) + sizeof(StockBookQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding StockBookQuote");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((StockBookQuote.PKeyLayout*) src); src += sizeof(StockBookQuote.PKeyLayout);
             dest.body = *((StockBookQuote.BodyLayout*) src); src += sizeof(StockBookQuote.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, StockExchImbalanceV2 dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, StockExchImbalanceV2 dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(StockExchImbalanceV2.PKeyLayout) + sizeof(StockExchImbalanceV2.BodyLayout) > max) throw new IOException("Max exceeded decoding StockExchImbalanceV2");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((StockExchImbalanceV2.PKeyLayout*) src); src += sizeof(StockExchImbalanceV2.PKeyLayout);
             dest.body = *((StockExchImbalanceV2.BodyLayout*) src); src += sizeof(StockExchImbalanceV2.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, StockImbalance dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, StockImbalance dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(StockImbalance.PKeyLayout) + sizeof(StockImbalance.BodyLayout) > max) throw new IOException("Max exceeded decoding StockImbalance");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((StockImbalance.PKeyLayout*) src); src += sizeof(StockImbalance.PKeyLayout);
             dest.body = *((StockImbalance.BodyLayout*) src); src += sizeof(StockImbalance.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, StockMarketSummary dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, StockMarketSummary dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(StockMarketSummary.PKeyLayout) + sizeof(StockMarketSummary.BodyLayout) > max) throw new IOException("Max exceeded decoding StockMarketSummary");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((StockMarketSummary.PKeyLayout*) src); src += sizeof(StockMarketSummary.PKeyLayout);
             dest.body = *((StockMarketSummary.BodyLayout*) src); src += sizeof(StockMarketSummary.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, StockPrint dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, StockPrint dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(StockPrint.PKeyLayout) + sizeof(StockPrint.BodyLayout) > max) throw new IOException("Max exceeded decoding StockPrint");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((StockPrint.PKeyLayout*) src); src += sizeof(StockPrint.PKeyLayout);
             dest.body = *((StockPrint.BodyLayout*) src); src += sizeof(StockPrint.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, StockPrintMarkup dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, StockPrintMarkup dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(StockPrintMarkup.PKeyLayout) + sizeof(StockPrintMarkup.BodyLayout) > max) throw new IOException("Max exceeded decoding StockPrintMarkup");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((StockPrintMarkup.PKeyLayout*) src); src += sizeof(StockPrintMarkup.PKeyLayout);
             dest.body = *((StockPrintMarkup.BodyLayout*) src); src += sizeof(StockPrintMarkup.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, SyntheticPrint dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, SyntheticPrint dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(SyntheticPrint.PKeyLayout) + sizeof(SyntheticPrint.BodyLayout) > max) throw new IOException("Max exceeded decoding SyntheticPrint");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((SyntheticPrint.PKeyLayout*) src); src += sizeof(SyntheticPrint.PKeyLayout);
             dest.body = *((SyntheticPrint.BodyLayout*) src); src += sizeof(SyntheticPrint.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, SyntheticQuote dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, SyntheticQuote dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(SyntheticQuote.PKeyLayout) + sizeof(SyntheticQuote.BodyLayout) > max) throw new IOException("Max exceeded decoding SyntheticQuote");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((SyntheticQuote.PKeyLayout*) src); src += sizeof(SyntheticQuote.PKeyLayout);
             dest.body = *((SyntheticQuote.BodyLayout*) src); src += sizeof(SyntheticQuote.BodyLayout);
			
            return src;
        }
    }
     
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, TickerDefinitionExt dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, TickerDefinitionExt dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;
            if (src + sizeOfHeader + sizeof(TickerDefinitionExt.PKeyLayout) + sizeof(TickerDefinitionExt.BodyLayout) > max) throw new IOException("Max exceeded decoding TickerDefinitionExt");
            
            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;

            dest.pkey.body = *((TickerDefinitionExt.PKeyLayout*) src); src += sizeof(TickerDefinitionExt.PKeyLayout);
             dest.body = *((TickerDefinitionExt.BodyLayout*) src); src += sizeof(TickerDefinitionExt.BodyLayout);
			
            return src;
        }
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Encode(Span<byte> buffer, MLinkCacheRequest src)
    {
        fixed (byte* p = buffer)
        {
            return (int)(Encode(src, p, p + buffer.Length) - p);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Encode(MLinkCacheRequest src, byte* dest, byte* max)
    {
        unchecked
        {
            int length = sizeof(Header) + sizeof(MLinkCacheRequest.BodyLayout) + (sizeof(ushort) + (src.MsgTypeList == null ? 0 : src.MsgTypeList.Length * MLinkCacheRequest.MsgTypeItem.Length));
            if (length > (int) (max - dest)) throw new IOException("Cannot encode MLinkCacheRequest because it will exceed the buffer length");
            
            src.header.hdrlen = (byte)sizeof(Header);
            src.header.msgtype = MessageType.MLinkCacheRequest;
            src.header.msglen = (ushort) length;
            src.header.keylen = 0;
            src.header.sentts = System.DateTime.UtcNow.Ticks;
            
            *((Header*) dest) =	src.header; dest += sizeof(Header);
            
            *((MLinkCacheRequest.BodyLayout*) dest) = src.body; dest += sizeof(MLinkCacheRequest.BodyLayout);
 
            // MsgTypeItem Repeat Section

            if (src.MsgTypeList == null)
            {
                *((ushort*) dest) = 0;
            }
            else 
            {
                *((ushort*) dest) = (ushort) src.MsgTypeList.Length; dest += sizeof(ushort);
                
                for (int i = 0; i < src.MsgTypeList.Length; i++)
                {
                    var item = src.MsgTypeList[i];
                    *((ushort*) dest) = item.MsgType; dest += sizeof(ushort);
					*((long*) dest) = item.SchemaHash; dest += sizeof(long);
                }
            }
			
            return dest;
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, MLinkCacheRequest dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, MLinkCacheRequest dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;

            if (src + sizeOfHeader + sizeof(MLinkCacheRequest.BodyLayout) > max) throw new IOException("Max exceeded decoding MLinkCacheRequest");

            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;
            dest.body = *((MLinkCacheRequest.BodyLayout*) src); src += sizeof(MLinkCacheRequest.BodyLayout);
 
            // MsgTypeItem Repeat Section

            if (src + sizeof(ushort) > max) throw new IOException("Max exceeded decoding MLinkCacheRequest.MsgType length");
            ushort size = *((ushort*) src); src += sizeof(ushort);
            if (src + size * MLinkCacheRequest.MsgTypeItem.Length > max) throw new IOException("Max exceeded decoding MLinkCacheRequest.MsgType items");

            dest.MsgTypeList = new MLinkCacheRequest.MsgTypeItem[size];
            
            for (int i = 0; i < size; i++)
            {
                var item = new MLinkCacheRequest.MsgTypeItem();
                item.MsgType = *((ushort*) src); src += sizeof(ushort);
				item.SchemaHash = *((long*) src); src += sizeof(long);
                dest.MsgTypeList[i] = item;
            }
			
            return src;
        }
    }
 
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Encode(Span<byte> buffer, MLinkStreamCheckPt src)
    {
        fixed (byte* p = buffer)
        {
            return (int)(Encode(src, p, p + buffer.Length) - p);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Encode(MLinkStreamCheckPt src, byte* dest, byte* max)
    {
        unchecked
        {
            int length = sizeof(Header) + sizeof(MLinkStreamCheckPt.BodyLayout) + (sizeof(byte) + (src.Detail?.Length ?? 0));
            if (length > (int) (max - dest)) throw new IOException("Cannot encode MLinkStreamCheckPt because it will exceed the buffer length");
            
            src.header.hdrlen = (byte)sizeof(Header);
            src.header.msgtype = MessageType.MLinkStreamCheckPt;
            src.header.msglen = (ushort) length;
            src.header.keylen = 0;
            src.header.sentts = System.DateTime.UtcNow.Ticks;
            
            *((Header*) dest) =	src.header; dest += sizeof(Header);
            
            *((MLinkStreamCheckPt.BodyLayout*) dest) = src.body; dest += sizeof(MLinkStreamCheckPt.BodyLayout);
             dest = EncodeText1(dest, src.Detail, "MLinkStreamCheckPt.detail");
			
            return dest;
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, MLinkStreamCheckPt dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, MLinkStreamCheckPt dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;

            if (src + sizeOfHeader + sizeof(MLinkStreamCheckPt.BodyLayout) > max) throw new IOException("Max exceeded decoding MLinkStreamCheckPt");

            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;
            dest.body = *((MLinkStreamCheckPt.BodyLayout*) src); src += sizeof(MLinkStreamCheckPt.BodyLayout);
             dest.Detail = DecodeText1(ref src, max, "MLinkStreamCheckPt.detail");
			
            return src;
        }
    }
 
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Encode(Span<byte> buffer, NetPulse src)
    {
        fixed (byte* p = buffer)
        {
            return (int)(Encode(src, p, p + buffer.Length) - p);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Encode(NetPulse src, byte* dest, byte* max)
    {
        unchecked
        {
            int length = sizeof(Header) + sizeof(NetPulse.BodyLayout);
            if (length > (int) (max - dest)) throw new IOException("Cannot encode NetPulse because it will exceed the buffer length");
            
            src.header.hdrlen = (byte)sizeof(Header);
            src.header.msgtype = MessageType.NetPulse;
            src.header.msglen = (ushort) length;
            src.header.keylen = 0;
            src.header.sentts = System.DateTime.UtcNow.Ticks;
            
            *((Header*) dest) =	src.header; dest += sizeof(Header);
            
            *((NetPulse.BodyLayout*) dest) = src.body; dest += sizeof(NetPulse.BodyLayout);
			
            return dest;
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Decode(ReadOnlySpan<byte> buffer, NetPulse dest)
    {
        fixed (byte* p = buffer)
        {
            _  = Decode(p, dest, p + buffer.Length);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Decode(byte* src, NetPulse dest, byte* max)
    {
        unchecked
        {
            var sizeOfHeader = *src;

            if (src + sizeOfHeader + sizeof(NetPulse.BodyLayout) > max) throw new IOException("Max exceeded decoding NetPulse");

            if (sizeOfHeader == sizeof(Header))
            {
                dest.header = *((Header*) src);
            }
            else
            {
                new Span<byte>(src, sizeOfHeader).CopyTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref dest.header, sizeof(Header))));
            }

            src += sizeOfHeader;
            dest.body = *((NetPulse.BodyLayout*) src); src += sizeof(NetPulse.BodyLayout);
			
            return src;
        }
    }

}
