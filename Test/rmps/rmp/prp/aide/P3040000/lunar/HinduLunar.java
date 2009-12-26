// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   HinduLunar.java

package rmp.prp.aide.P3040000.lunar;

import java.text.MessageFormat;
import java.util.Vector;

import rmp.prp.aide.P3040000.proto.ProtoDate;
import rmp.prp.aide.P3040000.solar.Gregorian;
import rmp.prp.aide.P3040000.solar.HinduSolar;
import rmp.prp.aide.P3040000.solar.OldHinduSolar;

// Referenced classes of package calendrica:
//            Date, FixedVector, Gregorian, HinduSolar, 
//            OldHinduLunar, OldHinduSolar, ProtoDate

public class HinduLunar extends LunarDate
{
    public HinduLunar()
    {
    }

    public HinduLunar(long l)
    {
        super(l);
    }

    public HinduLunar(LunarDate date)
    {
        super(date);
    }

    public HinduLunar(long l, int i, boolean flag, int j, boolean flag1)
    {
        year = l;
        month = i;
        leapMonth = flag;
        day = j;
        leapDay = flag1;
    }

    public static long toFixed(long l, int i, boolean flag, int j, boolean flag1)
    {
        return (new HinduLunar(l, i, flag, j, flag1)).toFixed();
    }

    public long toFixed()
    {
        double d = (double)OldHinduSolar.EPOCH + 365.2587564814815D
            * ((double)(year + 3044L) + (double)(month - 1) / 12D);
        long l = (long)Math.floor(d
            - (1.0D / ProtoDate.deg(360D))
            * 365.2587564814815D
            * (ProtoDate.mod((HinduSolar.solarLongitude(d) - (double)(month - 1) * ProtoDate.deg(30D))
                + ProtoDate.deg(180D), ProtoDate.deg(360D)) - 180D));
        int i = lunarDay((double)l + 0.25D);
        long l1;
        if (i > 3 && i < 27)
        {
            l1 = i;
        }
        else
        {
            HinduLunar hindulunar = new HinduLunar(l - 15L);
            if (hindulunar.month < month || hindulunar.leapMonth && !leapMonth)
                l1 = ProtoDate.mod(i + 15, 30) - 15;
            else
                l1 = ProtoDate.mod(i - 15, 30) + 15;
        }
        long l2 = (l + (long)day) - l1;
        long l3 = (l2 - (long)ProtoDate.mod((lunarDay((double)l2 + 0.25D) - day) + 15, 30)) + 15L;
        long l4;
        for (l4 = l3 - 1L; !onOrBefore(this, new HinduLunar(l4)); l4++)
            ;
        return l4;
    }

    public void fromFixed(long l)
    {
        double d = HinduSolar.sunrise(l);
        day = lunarDay(d);
        leapDay = day == lunarDay(HinduSolar.sunrise(l - 1L));
        double d1 = newMoonBefore(d);
        double d2 = newMoonBefore(Math.floor(d1) + 35D);
        int i = HinduSolar.zodiac(d1);
        leapMonth = i == HinduSolar.zodiac(d2);
        month = ProtoDate.adjustedMod(i + 1, 12);
        year = HinduSolar.calendarYear(d2) - 3044L - (long)(!leapMonth || month != 1 ? 0 : -1);
    }

    public void fromArray(int ai[])
    {
        year = ai[0];
        month = ai[1];
        leapMonth = ai[2] != 0;
        day = ai[3];
        leapDay = ai[4] != 0;
    }

    public static double newMoonBefore(double d)
    {
        double d1 = Math.pow(2D, -34D);
        double d2 = d - (1.0D / ProtoDate.deg(360D)) * lunarPhase(d) * 29.530587946071719D;
        double d3 = d2 - 1.0D;
        double d4 = Math.min(d, d2 + 1.0D);
        double d5 = d3;
        double d6 = d4;
        double d7;
        for (d7 = (d6 + d5) / 2D; HinduSolar.zodiac(d5) != HinduSolar.zodiac(d6) && d6 - d5 >= d1; d7 = (d6 + d5) / 2D)
            if (lunarPhase(d7) < ProtoDate.deg(180D))
                d6 = d7;
            else
                d5 = d7;

        return d7;
    }

    public static boolean onOrBefore(HinduLunar hindulunar, HinduLunar hindulunar1)
    {
        return hindulunar.year < hindulunar1.year
            || hindulunar.year == hindulunar1.year
            && (hindulunar.month < hindulunar1.month || hindulunar.month == hindulunar1.month
                && (hindulunar.leapMonth && !hindulunar1.leapMonth || hindulunar.leapMonth == hindulunar1.leapMonth
                    && (hindulunar.day < hindulunar1.day || hindulunar.day == hindulunar1.day
                        && (!hindulunar.leapDay || hindulunar1.leapDay))));
    }

    public static double lunarDayAfter(double d, double d1)
    {
        double d2 = Math.pow(2D, -17D);
        double d3 = (d1 - 1.0D) * 12D;
        double d4 = d + 0.0027777777777777779D * ProtoDate.mod(d3 - lunarPhase(d), ProtoDate.deg(360D))
            * 29.530587946071719D;
        double d5 = Math.max(d, d4 - 2D);
        double d6 = d4 + 2D;
        double d7 = d5;
        double d8 = d6;
        double d9;
        for (d9 = (d8 + d7) / 2D; d8 - d7 >= d2; d9 = (d8 + d7) / 2D)
            if (ProtoDate.mod(lunarPhase(d9) - d3, 360D) < ProtoDate.deg(180D))
                d8 = d9;
            else
                d7 = d9;

        return d9;
    }

    public static double lunarLongitude(double d)
    {
        return HinduSolar.truePosition(d, 27.321674162683866D, 0.088888888888888892D, 27.554597974680476D,
            0.010416666666666666D);
    }

    public static double lunarPhase(double d)
    {
        return ProtoDate.mod(lunarLongitude(d) - HinduSolar.solarLongitude(d), 360D);
    }

    public static int lunarDay(double d)
    {
        return (int)ProtoDate.quotient(lunarPhase(d), ProtoDate.deg(12D)) + 1;
    }

    public static int lunarStation(long l)
    {
        double d = HinduSolar.sunrise(l);
        return (int)ProtoDate.quotient(lunarLongitude(d), ProtoDate.deg(800D) / 60D) + 1;
    }

    public static long newYear(long l)
    {
        long l1 = Gregorian.toFixed(l, 1, 1);
        double d = HinduSolar.solarLongitudeAfter(l1, ProtoDate.deg(330D));
        double d1 = lunarDayAfter(d, 1.0D);
        long l2 = (long)Math.floor(d1);
        double d2 = HinduSolar.sunrise(l2);
        return l2 + (long)(d1 >= d2 && lunarDay(HinduSolar.sunrise(l2 + 1L)) != 2 ? 1 : 0);
    }

    public static int karana(int i)
    {
        if (i == 1)
            return 0;
        if (i > 57)
            return i - 50;
        else
            return ProtoDate.adjustedMod(i - 1, 7);
    }

    public static int yoga(long l)
    {
        return (int)Math.floor(ProtoDate.mod(((HinduSolar.solarLongitude(l) + lunarLongitude(l)) * 60D) / 800D,
            ProtoDate.deg(27D))) + 1;
    }

    public static Vector<Long> sacredWednesdaysInGregorian(long l)
    {
        return sacredWednesdays(Gregorian.toFixed(l, 1, 1), Gregorian.toFixed(l, 12, 31));
    }

    public static Vector<Long> sacredWednesdays(long l, long l1)
    {
        long l2 = ProtoDate.kDayOnOrAfter(l, 3);
        Vector<Long> fixedvector = new Vector<Long>();
        for (; l2 <= l1; l2 += 7L)
        {
            HinduLunar hindulunar = new HinduLunar(l2);
            if (hindulunar.day == 8)
                fixedvector.add(l2);
        }

        return fixedvector;
    }

    protected String toStringFields()
    {
        return "year=" + year + ",month=" + month + ",leapMonth=" + leapMonth + ",day=" + day + ",leapDay=" + leapDay;
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1}{2} {3}{4} {5,number,#} V.E.", new Object[]{
            ProtoDate.nameFromDayOfWeek(toFixed(), OldHinduLunar.dayOfWeekNames), new Integer(day),
            leapDay ? " II" : "", ProtoDate.nameFromMonth(month, OldHinduLunar.monthNames), leapMonth ? " II" : "",
            new Long(year)});
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof HinduLunar))
            return false;
        HinduLunar hindulunar = (HinduLunar)obj;
        return hindulunar.year == year && hindulunar.month == month && hindulunar.leapMonth == leapMonth
            && hindulunar.day == day && hindulunar.leapDay == leapDay;
    }

    public long                year;
    public int                 month;
    public boolean             leapMonth;
    public int                 day;
    public boolean             leapDay;
    public static final int    LUNAR_ERA         = 3044;
    public static final double SYNODIC_MONTH     = 29.530587946071719D;
    public static final double SIDEREAL_MONTH    = 27.321674162683866D;
    public static final double ANOMALISTIC_MONTH = 27.554597974680476D;

    /** serialVersionUID */
    private static final long  serialVersionUID  = -5860669173503488740L;
}
