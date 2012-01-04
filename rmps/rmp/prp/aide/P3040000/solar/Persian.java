// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Persian.java

package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.b.Location;
import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;
import cons.prp.aide.P3040000.ConstUI;

// Referenced classes of package calendrica:
//            StandardDate, Gregorian, Julian, Location, 
//            ProtoDate, Date

public class Persian extends SolarDate
{
    public Persian()
    {
    }

    public Persian(long l)
    {
        super(l);
    }

    public Persian(LunarDate date)
    {
        super(date);
    }

    public Persian(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        long l1 = newYearOnOrBefore(EPOCH + 180L + (long) Math.floor(365.242189D * (double) (l <= 0L ? l : l - 1L)));
        return (l1 - 1L) + (long) (i > 7 ? 30 * (i - 1) + 6 : 31 * (i - 1)) + (long) j;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        long l1 = newYearOnOrBefore(l);
        long l2 = 1L + Math.round((double) (l1 - EPOCH) / 365.242189D);
        super.year = l2 <= 0L ? l2 - 1L : l2;
        long l3 = (1L + l) - toFixed(super.year, 1, 1);
        super.month = l3 >= 186L ? (int) Math.ceil((double) (l3 - 6L) / 30D) : (int) Math.ceil((double) l3 / 31D);
        super.day = (int) (l - (toFixed(super.year, super.month, 1) - 1L));
    }

    public static double middayInTehran(long l)
    {
        return ProtoDate.universalFromStandard(ProtoDate.midday(l, TEHRAN), TEHRAN);
    }

    public static long newYearOnOrBefore(long l)
    {
        double d = ProtoDate.estimatePriorSolarLongitude(middayInTehran(l), ConstUI.SPRING);
        long l1;
        for (l1 = (long) Math.floor(d) - 1L; ProtoDate.solarLongitude(middayInTehran(l1)) > ConstUI.SPRING + ProtoDate.deg(2D); l1++)
            ;
        return l1;
    }

    public static long nawRuz(long l)
    {
        long l1 = (1L + l) - Gregorian.yearFromFixed(EPOCH);
        return toFixed(l1 > 0L ? l1 : l1 - 1L, 1, 1);
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1} {2} {3,number,#} A.P.", new Object[]
        { ProtoDate.nameFromDayOfWeek(toFixed(), dayOfWeekNames), new Integer(super.day), ProtoDate.nameFromMonth(super.month, monthNames), new Long(super.year) });
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof Persian))
            return false;
        else
            return internalEquals(obj);
    }

    public static final long EPOCH = Julian.toFixed(Julian.CE(622L), 3, 19);
    public static final Location TEHRAN = new Location("Tehran, Iran", ProtoDate.deg(35.68D), ProtoDate.deg(51.420000000000002D), ProtoDate.mt(1100D), 3.5D);
    public static final String dayOfWeekNames[] =
    { "Yek-shanbeh", "Do-shanbeh", "Se-shanbeh", "Char-shanbeh", "Panj-shanbeh", "Jom`eh", "Shanbeh" };
    public static final String monthNames[] =
    { "Farvardin", "Ordibehesht", "Xordad", "Tir", "Mordad", "Shahrivar", "Mehr", "Aban", "Azar", "Dey", "Bahman", "Esfand" };

    /** serialVersionUID */
    private static final long serialVersionUID = -5304927747732573424L;
}
