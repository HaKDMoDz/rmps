// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Roman.java

package rmp.prp.aide.P3040000.lunar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.proto.ProtoDate;
import rmp.prp.aide.P3040000.solar.Gregorian;
import rmp.prp.aide.P3040000.solar.Julian;
import rmp.prp.aide.P3040000.solar.SolarDate;

// Referenced classes of package calendrica:
//            Date, Gregorian, Julian, ProtoDate, 
//            StandardDate

public class Roman extends LunarDate
{
    public Roman()
    {
    }

    public Roman(long l)
    {
        super(l);
    }

    public Roman(LunarDate date)
    {
        super(date);
    }

    public Roman(long l, int i, int j, int k, boolean flag)
    {
        year = l;
        month = i;
        event = j;
        count = k;
        leapDay = flag;
    }

    public static long toFixed(long l, int i, int j, int k, boolean flag)
    {
        long l1 = 0L;
        if (j == 1)
            l1 = Julian.toFixed(l, i, 1);
        else if (j == 2)
            l1 = Julian.toFixed(l, i, nonesOfMonth(i));
        else if (j == 3)
            l1 = Julian.toFixed(l, i, idesOfMonth(i));
        return (l1 - (long) k) + (long) (!Julian.isLeapYear(l) || i != 3 || j != 1 || k > 16 || k < 6 ? 1 : 0) + (long) (flag ? 1 : 0);
    }

    public long toFixed()
    {
        return toFixed(year, month, event, count, leapDay);
    }

    public void fromFixed(long l)
    {
        Julian julian = new Julian(l);
        int i = ((SolarDate) (julian)).month;
        int j = ((SolarDate) (julian)).day;
        long l1 = ((SolarDate) (julian)).year;
        int k = ProtoDate.adjustedMod(i + 1, 12);
        long l2 = k != 1 ? l1 : l1 + 1L;
        long l3 = toFixed(l2, k, 1, 1, false);
        if (j == 1)
        {
            year = l1;
            month = i;
            event = 1;
            count = 1;
            leapDay = false;
            return;
        }
        if (j <= nonesOfMonth(i))
        {
            year = l1;
            month = i;
            event = 2;
            count = (nonesOfMonth(i) - j) + 1;
            leapDay = false;
            return;
        }
        if (j <= idesOfMonth(i))
        {
            year = l1;
            month = i;
            event = 3;
            count = (idesOfMonth(i) - j) + 1;
            leapDay = false;
            return;
        }
        if (i != 2 || !Julian.isLeapYear(l1))
        {
            year = l2;
            month = k;
            event = 1;
            count = (int) ((l3 - l) + 1L);
            leapDay = false;
            return;
        }
        if (j < 25)
        {
            year = l1;
            month = 3;
            event = 1;
            count = 30 - j;
            leapDay = false;
            return;
        }
        else
        {
            year = l1;
            month = 3;
            event = 1;
            count = 31 - j;
            leapDay = j == 25;
            return;
        }
    }

    public void fromArray(int ai[])
    {
        year = ai[0];
        month = ai[1];
        event = ai[2];
        count = ai[3];
        leapDay = ai[4] != 0;
    }

    public static int idesOfMonth(int i)
    {
        return i != 3 && i != 5 && i != 7 && i != 10 ? 13 : 15;
    }

    public static int nonesOfMonth(int i)
    {
        return idesOfMonth(i) - 8;
    }

    protected String toStringFields()
    {
        return "year=" + year + ",month=" + month + ",event=" + event + ",count=" + count + ",leapDay=" + leapDay;
    }

    public String format()
    {
        return MessageFormat.format("{0}{1} {2}, {3,number,#} {4}", new Object[]
        { leapDay ? "ante diem bis vi " : ProtoDate.nameFromNumber(count, countNames), ProtoDate.nameFromNumber(event, eventNames), ProtoDate.nameFromMonth(month, Gregorian.monthNames),
                new Long(year >= 0L ? year : -year), year >= 0L ? "C.E." : "B.C.E." });
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof Roman))
            return false;
        Roman roman = (Roman) obj;
        return roman.year == year && roman.month == month && roman.event == event && roman.count == count && roman.leapDay == leapDay;
    }

    public long year;
    public int month;
    public int event;
    public int count;
    public boolean leapDay;
    public static final int KALENDS = 1;
    public static final int NONES = 2;
    public static final int IDES = 3;
    public static final String countNames[] =
    { "", "pridie ", "ante diem iii ", "ante diem iv ", "ante diem v ", "ante diem vi ", "ante diem vii ", "ante diem viii ", "ante diem ix ", "ante diem x ", "ante diem xi ", "ante diem xii ",
            "ante diem xiii ", "ante diem xiv ", "ante diem xv ", "ante diem xvi ", "ante diem xvii ", "ante diem xviii ", "ante diem xix " };
    public static final String eventNames[] =
    { "Kalends", "Nones", "Ides" };

    /** serialVersionUID */
    private static final long serialVersionUID = -8671979783772688456L;
}
