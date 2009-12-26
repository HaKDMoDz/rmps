// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   ISO.java

package rmp.prp.aide.P3040000.lunar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.proto.ProtoDate;
import rmp.prp.aide.P3040000.solar.Gregorian;

// Referenced classes of package calendrica:
//            Date, Gregorian, ProtoDate

public class ISO extends LunarDate
{
    public ISO()
    {
    }

    public ISO(long l)
    {
        super(l);
    }

    public ISO(LunarDate date)
    {
        super(date);
    }

    public ISO(long l, int i, int j)
    {
        year = l;
        week = i;
        day = j;
    }

    public static long toFixed(long l, int i, int j)
    {
        return ProtoDate.nthKDay(i, 0, Gregorian.toFixed(l - 1L, 12, 28)) + (long) j;
    }

    public long toFixed()
    {
        return toFixed(year, week, day);
    }

    public void fromFixed(long l)
    {
        long l1 = Gregorian.yearFromFixed(l - 3L);
        year = l < toFixed(l1 + 1L, 1, 1) ? l1 : l1 + 1L;
        week = (int) ProtoDate.quotient(l - toFixed(year, 1, 1), 7D) + 1;
        day = (int) ProtoDate.adjustedMod(l, 7L);
    }

    public void fromArray(int ai[])
    {
        year = ai[0];
        week = ai[1];
        day = ai[2];
    }

    protected String toStringFields()
    {
        return "year=" + year + ",week=" + week + ",day=" + day;
    }

    public String format()
    {
        return MessageFormat.format("{0}, Week {1}, {2,number,#}", new Object[]
        { ProtoDate.nameFromDayOfWeek(toFixed(), Gregorian.dayOfWeekNames), new Integer(week), new Long(year) });
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof ISO))
            return false;
        ISO iso = (ISO) obj;
        return iso.year == year && iso.week == week && iso.day == day;
    }

    public long year;
    public int week;
    public int day;

    /** serialVersionUID */
    private static final long serialVersionUID = -5713176521546385225L;
}
