// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Bahai.java

package rmp.prp.aide.P3040000.lunar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.proto.ProtoDate;
import rmp.prp.aide.P3040000.solar.Gregorian;

// Referenced classes of package calendrica:
//            Date, Gregorian, ProtoDate

public class Bahai extends LunarDate
{
    public Bahai()
    {
    }

    public Bahai(long l)
    {
        super(l);
    }

    public Bahai(LunarDate date)
    {
        super(date);
    }

    public Bahai(long l, int i, int j, int k, int i1)
    {
        major = l;
        cycle = i;
        year = j;
        month = k;
        day = i1;
    }

    public static long toFixed(long l, int i, int j, int k, int i1)
    {
        long l1 = ((361L * (l - 1L) + (long)(19 * (i - 1)) + (long)j) - 1L) + Gregorian.yearFromFixed(EPOCH);
        long l2;
        if (k == 0)
            l2 = 342L;
        else if (k == 19)
            l2 = Gregorian.isLeapYear(l1 + 1L) ? 347 : '\u015A';
        else
            l2 = 19 * (k - 1);
        return Gregorian.toFixed(l1, 3, 20) + l2 + (long)i1;
    }

    public long toFixed()
    {
        return toFixed(major, cycle, year, month, day);
    }

    public void fromFixed(long l)
    {
        long l1 = Gregorian.yearFromFixed(l);
        long l2 = Gregorian.yearFromFixed(EPOCH);
        long l3 = l1 - l2 - (long)(l > Gregorian.toFixed(l1, 3, 20) ? 0 : 1);
        major = 1L + ProtoDate.quotient(l3, 361D);
        cycle = 1 + (int)ProtoDate.quotient(ProtoDate.mod(l3, 361L), 19D);
        year = 1 + (int)ProtoDate.mod(l3, 19L);
        long l4 = l - toFixed(major, cycle, year, 1, 1);
        if (l >= toFixed(major, cycle, year, 19, 1))
            month = 19;
        else if (l >= toFixed(major, cycle, year, 0, 1))
            month = 0;
        else
            month = (int)(1L + ProtoDate.quotient(l4, 19D));
        day = (int)((l + 1L) - toFixed(major, cycle, year, month, 1));
    }

    public void fromArray(int ai[])
    {
        major = ai[0];
        cycle = ai[1];
        year = ai[2];
        month = ai[3];
        day = ai[4];
    }

    /*-
    (defun bahai-new-year (g-year)
      ;; TYPE gregorian-year -> fixed-date
      ;; Fixed date of Bahai New Year in Gregorian year.
      (fixed-from-gregorian
       (gregorian-date march 21 g-year)))
    -*/
    public static long newYear(long l)
    {
        return Gregorian.toFixed(l, 3, 21);
    }

    protected String toStringFields()
    {
        return "major=" + major + ",cycle=" + cycle + ",year=" + year + ",month=" + month + ",day=" + day;
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1} {2}, {3} of Vahid {4}, Kull-i-Shay {5} B.E.", new Object[]{
            ProtoDate.nameFromDayOfWeek(toFixed(), dayOfWeekNames), ProtoDate.nameFromNumber(day, dayOfMonthNames),
            ProtoDate.nameFromMonth(month + 1, monthNames), ProtoDate.nameFromNumber(year, yearNames),
            new Integer(cycle), new Long(major)});
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof Bahai))
            return false;
        Bahai bahai = (Bahai)obj;
        return bahai.major == major && bahai.cycle == cycle && bahai.year == year && bahai.month == month
            && bahai.day == day;
    }

    public long                major;
    public int                 cycle;
    public int                 year;
    public int                 month;
    public int                 day;
    public static final long   EPOCH             = Gregorian.toFixed(1844L, 3, 21);
    public static final int    AYYAM_I_HA        = 0;
    public static final String dayOfWeekNames[]  = {"Jamal", "Kamal", "Fidal", "`Idal", "Istijlal", "Istiqlal", "Jalal"};
    public static final String dayOfMonthNames[] = {"Baha'", "Jalal", "Jamal", "`Azamat", "Nur", "Rahmat", "Kalimat",
        "Kamal", "Asma'", "`Izzat", "Mashiyyat", "`Ilm", "Qudrat", "Qawl", "Masa'il", "Sharaf", "Sultan", "Mulk",
        "`Ala'"                                  };
    public static final String monthNames[]      = {"Ayyam-i-Ha", "Baha'", "Jalal", "Jamal", "`Azamat", "Nur",
        "Rahmat", "Kalimat", "Kamal", "Asma'", "`Izzat", "Mashiyyat", "`Ilm", "Qudrat", "Qawl", "Masa'il", "Sharaf",
        "Sultan", "Mulk", "`Ala'"                };
    public static final String yearNames[]       = {"Alif", "Ba'", "Ab", "Dal", "Bab", "Vav", "Abad", "Jad", "Baha'",
        "Hubb", "Bahhaj", "Javab", "Ahad", "Vahhab", "Vidad", "Badi'", "Bahi", "Abha", "Vahid"};

    /** serialVersionUID */
    private static final long  serialVersionUID  = 6612815110842006429L;
}
