// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   ObservationalIslamic.java

package rmp.prp.aide.P3040000.solar;

import rmp.prp.aide.P3040000.b.Location;
import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            Islamic, BogusTimeException, Location, ProtoDate, 
//            StandardDate, Date

public class ObservationalIslamic extends Islamic
{
    public ObservationalIslamic()
    {
    }

    public ObservationalIslamic(long l)
    {
        super(l);
    }

    public ObservationalIslamic(LunarDate date)
    {
        super(date);
    }

    public ObservationalIslamic(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        long l1;
        try
        {
            long l2 = Islamic.EPOCH + (long) Math.floor(((double) ((l - 1L) * 12L + (long) i) - 0.5D) * 29.530588853000001D);
            l1 = (ProtoDate.phasisOnOrBefore(l2, ISLAMIC_LOCALE) + (long) j) - 1L;
        }
        catch (Exception _ex)
        {
            l1 = 0L;
        }
        return l1;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        try
        {
            long l1 = ProtoDate.phasisOnOrBefore(l, ISLAMIC_LOCALE);
            long l2 = Math.round((double) (l1 - Islamic.EPOCH) / 29.530588853000001D);
            super.year = ProtoDate.quotient(l2, 12D) + 1L;
            super.month = (int) (ProtoDate.mod(l2, 12L) + 1L);
            super.day = (int) ((l - l1) + 1L);
            return;
        }
        catch (Exception _ex)
        {
            return;
        }
    }

    public static final Location CAIRO;
    public static final Location ISLAMIC_LOCALE;

    static
    {
        CAIRO = new Location("Cairo, Egypt", ProtoDate.deg(30.100000000000001D), ProtoDate.deg(31.300000000000001D), ProtoDate.mt(200D), 2D);
        ISLAMIC_LOCALE = CAIRO;
    }

    /** serialVersionUID */
    private static final long serialVersionUID = 2794363507261911993L;
}
