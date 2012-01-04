// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Gregorian.java

package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            StandardDate, ProtoDate, Date

public class Gregorian extends SolarDate
{
    public Gregorian()
    {
    }

    public Gregorian(long l)
    {
        super(l);
    }

    public Gregorian(LunarDate date)
    {
        super(date);
    }

    public Gregorian(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        return ((365L * (l - 1L) + ProtoDate.quotient(l - 1L, 4D)) - ProtoDate.quotient(l - 1L, 100D)) + ProtoDate.quotient(l - 1L, 400D) + ProtoDate.quotient(367 * i - 362, 12D)
                + (long) (i > 2 ? isLeapYear(l) ? -1 : -2 : 0) + (long) j;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        super.year = yearFromFixed(l);
        long l1 = l - toFixed(super.year, 1, 1);
        int i = l >= toFixed(super.year, 3, 1) ? ((int) (isLeapYear(super.year) ? 1 : 2)) : 0;
        super.month = (int) ProtoDate.quotient(12L * (l1 + (long) i) + 373L, 367D);
        super.day = (int) ((l - toFixed(super.year, super.month, 1)) + 1L);
    }

    public static long altFixedFromGregorian(long l, int i, int j)
    {
        long l1 = ProtoDate.adjustedMod(i - 2, 12);
        long l2 = l + ProtoDate.quotient(i + 9, 12D);
        return ((-306L + 365L * (l2 - 1L) + ProtoDate.quotient(l2 - 1L, 4D)) - ProtoDate.quotient(l2 - 1L, 100D)) + ProtoDate.quotient(l2 - 1L, 400D) + ProtoDate.quotient(3L * l1 - 1L, 5D) + 30L
                * (l1 - 1L) + (long) j;
    }

    public void altGregorianFromFixed(long l)
    {
        long l1 = yearFromFixed(l + 306L);
        long l2 = l - toFixed(l1 - 1L, 3, 1);
        super.month = (int) ProtoDate.adjustedMod(ProtoDate.quotient(5L * l2 + 155L, 153D) + 2L, 12L);
        super.year = l1 - ProtoDate.quotient(super.month + 9, 12D);
        super.day = (int) ((1L + l) - toFixed(super.year, super.month, 1));
    }

    public static boolean isLeapYear(long l)
    {
        boolean flag = false;
        if (ProtoDate.mod(l, 4L) == 0L)
        {
            long l1 = ProtoDate.mod(l, 400L);
            if (l1 != 100L && l1 != 200L && l1 != 300L)
                flag = true;
        }
        return flag;
    }

    public static long yearFromFixed(long l)
    {
        long l1 = l - 1L;
        long l2 = ProtoDate.quotient(l1, 146097D);
        long l3 = ProtoDate.mod(l1, 0x23ab1L);
        long l4 = ProtoDate.quotient(l3, 36524D);
        long l5 = ProtoDate.mod(l3, 36524L);
        long l6 = ProtoDate.quotient(l5, 1461D);
        long l7 = ProtoDate.mod(l5, 1461L);
        long l8 = ProtoDate.quotient(l7, 365D);
        long l9 = 400L * l2 + 100L * l4 + 4L * l6 + l8;
        if (l4 == 4L || l8 == 4L)
            return l9;
        else
            return l9 + 1L;
    }

    public static long altGregorianYearFromFixed(long l)
    {
        long l1 = ProtoDate.quotient((l - 1L) + 2L, 365.24250000000001D);
        long l2 = ((1L + 365L * l1 + ProtoDate.quotient(l1, 4D)) - ProtoDate.quotient(l1, 100D)) + ProtoDate.quotient(l1, 400D);
        if (l < l2)
            return l1;
        else
            return l1 + 1L;
    }

    public int lastDayOfMonth()
    {
        switch (super.month)
        {
            case 2: // '\002'
                return !isLeapYear(super.year) ? 28 : 29;

            case 4: // '\004'
            case 6: // '\006'
            case 9: // '\t'
            case 11: // '\013'
                return 30;
        }
        return 31;
    }

    public long dayNumber()
    {
        return ProtoDate.difference(toFixed(super.year - 1L, 12, 31), toFixed());
    }

    public long daysRemaining()
    {
        return ProtoDate.difference(toFixed(), toFixed(super.year, 12, 31));
    }

    public static long independenceDay(long l)
    {
        return toFixed(l, 7, 4);
    }

    public static long laborDay(long l)
    {
        return ProtoDate.firstKDay(1, toFixed(l, 9, 1));
    }

    public static long memorialDay(long l)
    {
        return ProtoDate.lastKDay(1, toFixed(l, 5, 31));
    }

    public static long electionDay(long l)
    {
        return ProtoDate.firstKDay(2, toFixed(l, 11, 2));
    }

    public static long daylightSavingStart(long l)
    {
        return ProtoDate.firstKDay(0, toFixed(l, 4, 1));
    }

    public static long daylightSavingEnd(long l)
    {
        return ProtoDate.lastKDay(0, toFixed(l, 10, 31));
    }

    public static long christmas(long l)
    {
        return toFixed(l, 12, 25);
    }

    public static long advent(long l)
    {
        return ProtoDate.kDayNearest(toFixed(l, 11, 30), 0);
    }

    public static long epiphany(long l)
    {
        return ProtoDate.firstKDay(0, toFixed(l, 1, 2));
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1} {2} {3,number,#}", new Object[]
        { ProtoDate.nameFromDayOfWeek(toFixed(), dayOfWeekNames), new Integer(super.day), ProtoDate.nameFromMonth(super.month, monthNames), new Long(super.year) });
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof Gregorian))
            return false;
        else
            return internalEquals(obj);
    }

    public static final long EPOCH = 1L;
    public static final String dayOfWeekNames[] =
    { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
    public static final String monthNames[] =
    { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    /** serialVersionUID */
    private static final long serialVersionUID = 5763572875106047177L;
}
