// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Coptic.java

package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;
import java.util.Vector;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            StandardDate, FixedVector, Gregorian, Julian, 
//            ProtoDate, Date

public class Coptic extends SolarDate
{
    public Coptic()
    {
    }

    public Coptic(long l)
    {
        super(l);
    }

    public Coptic(LunarDate date)
    {
        super(date);
    }

    public Coptic(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        return (EPOCH - 1L) + 365L * (l - 1L) + ProtoDate.quotient(l, 4D) + (long) (30 * (i - 1)) + (long) j;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        super.year = ProtoDate.quotient(4L * (l - EPOCH) + 1463L, 1461D);
        super.month = 1 + (int) ProtoDate.quotient(l - toFixed(super.year, 1, 1), 30D);
        super.day = (int) ((l + 1L) - toFixed(super.year, super.month, 1));
    }

    public static boolean isLeapYear(long l)
    {
        return ProtoDate.mod(l, 4L) == 3L;
    }

    public static Vector<Long> inGregorian(int i, int j, long l)
    {
        long l1 = Gregorian.toFixed(l, 1, 1);
        long l2 = Gregorian.toFixed(l, 12, 31);
        long l3 = ((SolarDate) (new Coptic(l1))).year;
        long l4 = toFixed(l3, i, j);
        long l5 = toFixed(l3 + 1L, i, j);
        Vector<Long> fixedvector = new Vector<Long>(1, 1);
        if (l1 <= l4 && l4 <= l2)
            fixedvector.add(l4);
        if (l1 <= l5 && l5 <= l2)
            fixedvector.add(l5);
        return fixedvector;
    }

    public static Vector<Long> christmas(long l)
    {
        return inGregorian(4, 29, l);
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1} {2} {3,number,#} A.M.", new Object[]
        { ProtoDate.nameFromDayOfWeek(toFixed(), dayOfWeekNames), new Integer(super.day), ProtoDate.nameFromMonth(super.month, monthNames), new Long(super.year) });
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof Coptic))
            return false;
        else
            return internalEquals(obj);
    }

    public static final long EPOCH = Julian.toFixed(Julian.CE(284L), 8, 29);
    public static final String dayOfWeekNames[] =
    { "Tkyriaka", "Pesnau", "Pshoment", "Peftoou", "Ptiou", "Psoou", "Psabbaton" };
    public static final String monthNames[] =
    { "Tut", "Babah", "Hatur", "Kiyahk", "Tubah", "Amshir", "Baramhat", "Baramundah", "Bashans", "Ba'unah", "Abib", "Misra", "al-Nasi" };

    /** serialVersionUID */
    private static final long serialVersionUID = -5975146782521992805L;
}
