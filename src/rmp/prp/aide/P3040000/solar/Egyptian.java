// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Egyptian.java

package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            StandardDate, ProtoDate, Date

public class Egyptian extends SolarDate
{
    public Egyptian()
    {
    }

    public Egyptian(long l)
    {
        super(l);
    }

    public Egyptian(LunarDate date)
    {
        super(date);
    }

    public Egyptian(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        return (EPOCH + 365L * (l - 1L) + (long)(30 * (i - 1)) + (long)j) - 1L;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        long l1 = l - EPOCH;
        super.year = 1L + ProtoDate.quotient(l1, 365D);
        super.month = (int)(1L + ProtoDate.quotient(ProtoDate.mod(l1, 365L), 30D));
        super.day = (int)((l1 - 365L * (super.year - 1L) - (long)(30 * (super.month - 1))) + 1L);
    }

    public String format()
    {
        return MessageFormat.format("{0} {1} {2,number,#}", new Object[]{new Integer(super.day),
            ProtoDate.nameFromMonth(super.month, monthNames), new Long(super.year)});
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof Egyptian))
            return false;
        else
            return internalEquals(obj);
    }

    public static final long   EPOCH            = ProtoDate.fixedFromJD(1448638D);
    public static final String monthNames[]     = {"Thoth", "Phaophi", "Athyr", "Choiak", "Tybi", "Mechir",
        "Phamenoth", "Pharmuthi", "Pachon", "Payni", "Epiphi", "Mesori", "Epagomenai"};

    /** serialVersionUID */
    private static final long  serialVersionUID = -6576823410651813935L;
}
