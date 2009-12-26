// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   ModifiedFrench.java

package rmp.prp.aide.P3040000.solar;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            StandardDate, French, ProtoDate, Date

public class ModifiedFrench extends SolarDate
{
    public ModifiedFrench()
    {
    }

    public ModifiedFrench(long l)
    {
        super(l);
    }

    public ModifiedFrench(LunarDate date)
    {
        super(date);
    }

    public ModifiedFrench(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        return (((((French.EPOCH - 1L) + 365L * (l - 1L) + ProtoDate.quotient(l - 1L, 4D)) - ProtoDate.quotient(l - 1L, 100D)) + ProtoDate.quotient(l - 1L, 400D)) - ProtoDate.quotient(l - 1L, 4000D))
                + (long) (30 * (i - 1)) + (long) j;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        long l1 = 1L + ProtoDate.quotient((l - French.EPOCH) + 2L, 365.24225000000001D);
        super.year = l >= toFixed(l1, 1, 1) ? l1 : l1 - 1L;
        super.month = 1 + (int) ProtoDate.quotient(l - toFixed(super.year, 1, 1), 30D);
        super.day = (int) ((l - toFixed(super.year, super.month, 1)) + 1L);
    }

    public static boolean isLeapYear(long l)
    {
        boolean flag = false;
        if (ProtoDate.mod(l, 4L) == 0L)
        {
            long l1 = ProtoDate.mod(l, 400L);
            if (l1 != 100L && l1 != 200L && l1 != 300L && ProtoDate.mod(l, 4000L) != 0L)
                flag = true;
        }
        return flag;
    }

    public String format()
    {
        return (new French(super.year, super.month, super.day)).format();
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof ModifiedFrench))
            return false;
        else
            return internalEquals(obj);
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -2032111598162072098L;
}
