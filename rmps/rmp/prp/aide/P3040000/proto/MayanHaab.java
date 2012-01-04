// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   MayanHaab.java

package rmp.prp.aide.P3040000.proto;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.lunar.MayanLongCount;

// Referenced classes of package calendrica:
//            ProtoDate, MayanLongCount, Date

public class MayanHaab extends ProtoDate
{
    public MayanHaab()
    {
    }

    public MayanHaab(long l)
    {
        super(l);
    }

    public MayanHaab(LunarDate date)
    {
        super(date);
    }

    public MayanHaab(int i, int j)
    {
        month = i;
        day = j;
    }

    public void fromFixed(long l)
    {
        long l1 = ProtoDate.mod(l - EPOCH, 365L);
        day = (int) ProtoDate.mod(l1, 20L);
        month = 1 + (int) ProtoDate.quotient(l1, 20D);
    }

    public void fromArray(int ai[])
    {
        month = ai[0];
        day = ai[1];
    }

    public static int ordinal(MayanHaab mayanhaab)
    {
        return (mayanhaab.month - 1) * 20 + mayanhaab.day;
    }

    public static long onOrBefore(MayanHaab mayanhaab, long l)
    {
        return l - ProtoDate.mod(l - EPOCH - (long) ordinal(mayanhaab), 365L);
    }

    protected String toStringFields()
    {
        return "month=" + month + ",day=" + day;
    }

    public String format()
    {
        return MessageFormat.format("{0} {1}", new Object[]
        { new Integer(day), ProtoDate.nameFromMonth(month, monthNames) });
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof MayanHaab))
            return false;
        MayanHaab mayanhaab = (MayanHaab) obj;
        return mayanhaab.month == month && mayanhaab.day == day;
    }

    public int month;
    public int day;
    public static final long EPOCH;
    public static final String monthNames[] =
    { "Pop", "Uo", "Zip", "Zotz", "Tzec", "Xul", "Yaxkin", "Mol", "Chen", "Yax", "Zac", "Ceh", "Mac", "Kankin", "Muan", "Pax", "Kayab", "Cumku", "Uayeb" };

    static
    {
        EPOCH = MayanLongCount.EPOCH - (long) ordinal(new MayanHaab(18, 8));
    }

    /** serialVersionUID */
    private static final long serialVersionUID = 101609239783409778L;
}
