// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   FutureBahai.java

package rmp.prp.aide.P3040000.lunar;

import rmp.prp.aide.P3040000.b.Location;
import rmp.prp.aide.P3040000.proto.ProtoDate;
import rmp.prp.aide.P3040000.solar.Gregorian;
import cons.prp.aide.P3040000.ConstUI;

// Referenced classes of package calendrica:
//            Bahai, BogusTimeException, Gregorian, Location, 
//            ProtoDate, Date

public class FutureBahai extends Bahai
{
    public FutureBahai()
    {
    }

    public FutureBahai(long l)
    {
        super(l);
    }

    public FutureBahai(LunarDate date)
    {
        super(date);
    }

    public FutureBahai(long l, int i, int j, int k, int i1)
    {
        super.major = l;
        super.cycle = i;
        super.year = j;
        super.month = k;
        super.day = i1;
    }

    public static long toFixed(long l, int i, int j, int k, int i1)
    {
        long l1 = 361L * (l - 1L) + (long)(19 * (i - 1)) + (long)j;
        if (k == 19)
            return ((newYearOnOrBefore(Bahai.EPOCH + (long)Math.floor(365.242189D * ((double)l1 + 0.5D))) - 19L) + (long)i1) - 1L;
        if (k == 0)
            return (newYearOnOrBefore(Bahai.EPOCH + (long)Math.floor(365.242189D * ((double)l1 - 0.5D))) + 342L + (long)i1) - 1L;
        else
            return (newYearOnOrBefore(Bahai.EPOCH + (long)Math.floor(365.242189D * ((double)l1 - 0.5D)))
                + (long)((k - 1) * 19) + (long)i1) - 1L;
    }

    public long toFixed()
    {
        return toFixed(super.major, super.cycle, super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        long l1 = newYearOnOrBefore(l);
        long l2 = Math.round((double)(l1 - Bahai.EPOCH) / 365.242189D);
        super.major = ProtoDate.quotient(l2, 361D) + 1L;
        super.cycle = (int)ProtoDate.quotient(ProtoDate.mod(l2, 361L), 19D) + 1;
        super.year = (int)ProtoDate.mod(l2, 19L) + 1;
        long l3 = l - l1;
        if (l >= toFixed(super.major, super.cycle, super.year, 19, 1))
            super.month = 19;
        else if (l >= toFixed(super.major, super.cycle, super.year, 0, 1))
            super.month = 0;
        else
            super.month = (int)ProtoDate.quotient(l3, 19D) + 1;
        super.day = (int)((l + 1L) - toFixed(super.major, super.cycle, super.year, super.month, 1));
    }

    public static double sunsetInHaifa(long l)
    {
        try
        {
            return ProtoDate.universalFromStandard(ProtoDate.sunset(l, HAIFA), HAIFA);
        }
        catch(Exception _ex)
        {
            return 0.0D;
        }
    }

    public static long newYearOnOrBefore(long l)
    {
        double d = ProtoDate.estimatePriorSolarLongitude(sunsetInHaifa(l), ConstUI.SPRING);
        long l1;
        for (l1 = (long)Math.floor(d) - 1L; ProtoDate.solarLongitude(sunsetInHaifa(l1)) > ConstUI.SPRING
            + ProtoDate.deg(2D); l1++)
            ;
        return l1;
    }

    public static long feastOfRidvan(long l)
    {
        long l1 = l - Gregorian.yearFromFixed(Bahai.EPOCH);
        long l2 = 1L + ProtoDate.quotient(l1, 361D);
        int i = 1 + (int)ProtoDate.quotient(ProtoDate.mod(l1, 361L), 19D);
        int j = 1 + (int)ProtoDate.mod(l1, 19L);
        return toFixed(l2, i, j, 2, 13);
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof FutureBahai))
            return false;
        FutureBahai futurebahai = (FutureBahai)obj;
        return ((Bahai)(futurebahai)).major == super.major && ((Bahai)(futurebahai)).cycle == super.cycle
            && ((Bahai)(futurebahai)).year == super.year && ((Bahai)(futurebahai)).month == super.month
            && ((Bahai)(futurebahai)).day == super.day;
    }

    public static final Location HAIFA            = new Location("Haifa, Israel", ProtoDate.deg(32.82D), ProtoDate
                                                      .deg(35D), ProtoDate.mt(0.0D), 2D);

    /** serialVersionUID */
    private static final long    serialVersionUID = 8950273878592286943L;
}
