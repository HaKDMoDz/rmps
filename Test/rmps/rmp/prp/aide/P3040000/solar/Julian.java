// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Julian.java

package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;
import java.util.Vector;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            StandardDate, FixedVector, Gregorian, ProtoDate, 
//            Date

public class Julian extends SolarDate
{
    public Julian()
    {
    }

    public Julian(long l)
    {
        super(l);
    }

    public Julian(LunarDate date)
    {
        super(date);
    }

    public Julian(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        long l1 = l >= 0L ? l : l + 1L;
        return (EPOCH - 1L) + 365L * (l1 - 1L) + ProtoDate.quotient(l1 - 1L, 4D)
            + ProtoDate.quotient(367 * i - 362, 12D) + (long)(i > 2 ? isLeapYear(l) ? -1 : -2 : 0) + (long)j;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        long l1 = ProtoDate.quotient(4L * (l - EPOCH) + 1464L, 1461D);
        super.year = l1 > 0L ? l1 : l1 - 1L;
        long l2 = l - toFixed(super.year, 1, 1);
        int i = l >= toFixed(super.year, 3, 1) ? ((int)(isLeapYear(super.year) ? 1 : 2)) : 0;
        super.month = (int)ProtoDate.quotient(12L * (l2 + (long)i) + 373L, 367D);
        super.day = (int)((l - toFixed(super.year, super.month, 1)) + 1L);
    }

    public static long BCE(long l)
    {
        return -l;
    }

    public static long CE(long l)
    {
        return l;
    }

    public static boolean isLeapYear(long l)
    {
        return ProtoDate.mod(l, 4L) == (long)(l <= 0L ? 3 : 0);
    }

    public static Vector<Long> inGregorian(int i, int j, long l)
    {
        long l1 = Gregorian.toFixed(l, 1, 1);
        long l2 = Gregorian.toFixed(l, 12, 31);
        long l3 = ((SolarDate)(new Julian(l1))).year;
        long l4 = l3 != -1L ? l3 + 1L : 1L;
        long l5 = toFixed(l3, i, j);
        long l6 = toFixed(l4, i, j);
        Vector<Long> fixedvector = new Vector<Long>(1, 1);
        if (l1 <= l5 && l5 <= l2)
            fixedvector.add(l5);
        if (l1 <= l6 && l6 <= l2)
            fixedvector.add(l6);
        return fixedvector;
    }

    public static Vector<Long> easternOrthodoxChristmas(long l)
    {
        return inGregorian(12, 25, l);
    }

    public String format()
    {
        return MessageFormat.format("{0} {1} {2,number,#} {3}", new Object[]{new Integer(super.day),
            ProtoDate.nameFromMonth(super.month, Gregorian.monthNames),
            new Long(super.year >= 0L ? super.year : -super.year), super.year >= 0L ? "C.E." : "B.C.E."});
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof Julian))
            return false;
        else
            return internalEquals(obj);
    }

    public static final long  EPOCH            = Gregorian.toFixed(0L, 12, 30);

    /** serialVersionUID */
    private static final long serialVersionUID = -3704317648739602537L;
}
