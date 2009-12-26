// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   StandardDate.java

package rmp.prp.aide.P3040000.solar;

import rmp.prp.aide.P3040000.lunar.LunarDate;

// Referenced classes of package calendrica:
//            Date

public abstract class SolarDate extends LunarDate
{

    public SolarDate()
    {
    }

    public SolarDate(long l)
    {
        super(l);
    }

    public SolarDate(LunarDate date)
    {
        super(date);
    }

    public SolarDate(long l, int i, int j)
    {
        year = l;
        month = i;
        day = j;
    }

    public SolarDate(int ai[])
    {
        fromArray(ai);
    }

    public void fromArray(int ai[])
    {
        year = ai[0];
        month = ai[1];
        day = ai[2];
    }

    protected String toStringFields()
    {
        return "year=" + year + ",month=" + month + ",day=" + day;
    }

    protected boolean internalEquals(Object obj)
    {
        SolarDate standarddate = (SolarDate) obj;
        if (this == obj)
            return true;
        return standarddate.year == year && standarddate.month == month && standarddate.day == day;
    }

    public long year;
    public int month;
    public int day;
}
