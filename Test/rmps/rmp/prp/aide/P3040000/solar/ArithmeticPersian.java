// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   ArithmeticPersian.java

package rmp.prp.aide.P3040000.solar;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            Persian, ProtoDate, StandardDate, Date

public class ArithmeticPersian extends Persian
{
    public ArithmeticPersian()
    {
    }

    public ArithmeticPersian(long l)
    {
        super(l);
    }

    public ArithmeticPersian(LunarDate date)
    {
        super(date);
    }

    public ArithmeticPersian(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        long l1 = l <= 0L ? l - 473L : l - 474L;
        long l2 = ProtoDate.mod(l1, 2820L) + 474L;
        return (Persian.EPOCH - 1L) + 0xfb75fL * ProtoDate.quotient(l1, 2820D) + 365L * (l2 - 1L) + ProtoDate.quotient(682L * l2 - 110L, 2816D) + (long) (i > 7 ? 30 * (i - 1) + 6 : 31 * (i - 1))
                + (long) j;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        super.year = yearFromFixed(l);
        long l1 = (1L + l) - toFixed(super.year, 1, 1);
        super.month = (int) (l1 >= 186L ? Math.ceil((double) (l1 - 6L) / 30D) : Math.ceil((double) l1 / 31D));
        super.day = (int) (l - (toFixed(super.year, super.month, 1) - 1L));
    }

    public static boolean isLeapYear(long l)
    {
        long l1 = l <= 0L ? l - 473L : l - 474L;
        long l2 = ProtoDate.mod(l1, 2820L) + 474L;
        return ProtoDate.mod((l2 + 38L) * 682L, 2816L) < 682L;
    }

    public static long yearFromFixed(long l)
    {
        long l1 = l - toFixed(475L, 1, 1);
        long l2 = ProtoDate.quotient(l1, 1029983D);
        long l3 = ProtoDate.mod(l1, 0xfb75fL);
        long l4 = l3 != 0xfb75eL ? ProtoDate.quotient(2816D * (double) l3 + 1031337D, 1028522D) : 2820L;
        long l5 = 474L + 2820L * l2 + l4;
        if (l5 > 0L)
            return l5;
        else
            return l5 - 1L;
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -1333897849910967011L;
}
