// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   HinduSolar.java

package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.b.Location;
import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.lunar.OldHinduLunar;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            StandardDate, BogusTimeException, Gregorian, Location, 
//            OldHinduLunar, OldHinduSolar, ProtoDate, Date

public class HinduSolar extends SolarDate
{
    public HinduSolar()
    {
    }

    public HinduSolar(long l)
    {
        super(l);
    }

    public HinduSolar(LunarDate date)
    {
        super(date);
    }

    public HinduSolar(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        return (new HinduSolar(l, i, j)).toFixed();
    }

    public long toFixed()
    {
        long l = ((long) Math.floor(((double) (super.year + 3179L) + (double) (super.month - 1) / 12D) * 365.2587564814815D) + OldHinduSolar.EPOCH + (long) super.day) - 1L;
        double d = ProtoDate.deg(360D) / 365.2587564814815D;
        double d1 = (double) (super.month - 1) * ProtoDate.deg(30D) + (double) (super.day - 1) * d;
        double d2 = ProtoDate.mod((solarLongitude((double) l + 0.25D) - d1) + ProtoDate.deg(180D), 360D) - ProtoDate.deg(180D);
        long l1 = l - (long) Math.ceil(d2 / d);
        long l2;
        for (l2 = l1 - 2L; !onOrBefore(this, new HinduSolar(l2)); l2++)
            ;
        return l2;
    }

    public void fromFixed(long l)
    {
        double d = sunrise(l + 1L);
        super.month = zodiac(d);
        super.year = calendarYear(d) - 3179L;
        long l1 = l - 3L - (long) ProtoDate.mod(Math.floor(solarLongitude(d)), ProtoDate.deg(30D));
        long l2;
        for (l2 = l1; zodiac(sunrise(1L + l2)) != super.month; l2++)
            ;
        super.day = (int) ((l - l2) + 1L);
    }

    public static double hinduSineTable(int i)
    {
        double d = 3438D * ProtoDate.sinDegrees(((double) i * 225D) / 60D);
        double d1 = 0.215D * (double) ProtoDate.signum(d) * (double) ProtoDate.signum(Math.abs(d) - 1716D);
        return (double) Math.round(d + d1) / 3438D;
    }

    public static double hinduSine(double d)
    {
        double d1 = (d * 60D) / 225D;
        double d2 = ProtoDate.mod(d1, 1.0D);
        return d2 * hinduSineTable((int) Math.ceil(d1)) + (1.0D - d2) * hinduSineTable((int) Math.floor(d1));
    }

    public static double hinduArcsin(double d)
    {
        boolean flag = d < 0.0D;
        if (flag)
            d = -d;
        int i;
        for (i = 0; d > hinduSineTable(i); i++)
            ;
        double d1 = hinduSineTable(i - 1);
        double d2 = 3.75D * ((double) (i - 1) + (d - d1) / (hinduSineTable(i) - d1));
        if (flag)
            d2 = -d2;
        return d2;
    }

    public static double meanPosition(double d, double d1)
    {
        return ProtoDate.deg(360D) * ProtoDate.mod((d - CREATION) / d1, 1.0D);
    }

    public static double truePosition(double d, double d1, double d2, double d3, double d4)
    {
        double d5 = meanPosition(d, d1);
        double d6 = hinduSine(meanPosition(d, d3));
        double d7 = Math.abs(d6) * d4 * d2;
        double d8 = hinduArcsin(d6 * (d2 - d7));
        return ProtoDate.mod(d5 - d8, 360D);
    }

    public static double solarLongitude(double d)
    {
        return truePosition(d, 365.2587564814815D, 0.03888888888888889D, 365.25878920258134D, 0.023809523809523808D);
    }

    public static int zodiac(double d)
    {
        return (int) ProtoDate.quotient(solarLongitude(d), ProtoDate.deg(30D)) + 1;
    }

    public static boolean onOrBefore(HinduSolar hindusolar, HinduSolar hindusolar1)
    {
        return ((SolarDate) (hindusolar)).year < ((SolarDate) (hindusolar1)).year
                || ((SolarDate) (hindusolar)).year == ((SolarDate) (hindusolar1)).year
                && (((SolarDate) (hindusolar)).month < ((SolarDate) (hindusolar1)).month || ((SolarDate) (hindusolar)).month == ((SolarDate) (hindusolar1)).month
                        && ((SolarDate) (hindusolar)).day <= ((SolarDate) (hindusolar1)).day);
    }

    public static long calendarYear(double d)
    {
        return Math.round((d - (double) OldHinduSolar.EPOCH) / 365.2587564814815D - solarLongitude(d) / ProtoDate.deg(360D));
    }

    public static double equationOfTime(long l)
    {
        double d = hinduSine(meanPosition(l, 365.25878920258134D));
        double d1 = ((d * 3438D) / 60D) * (Math.abs(d) / 1080D - 0.03888888888888889D);
        return (((dailyMotion(l) / 360D) * d1) / 360D) * 365.2587564814815D;
    }

    public static double ascensionalDifference(long l, Location location)
    {
        double d = 0.40634089586969169D * hinduSine(tropicalLongitude(l));
        double d1 = location.latitude;
        double d2 = hinduSine(ProtoDate.deg(90D) + hinduArcsin(d));
        double d3 = hinduSine(d1) / hinduSine(ProtoDate.deg(90D) + d1);
        double d4 = d * d3;
        return hinduArcsin(-(d4 / d2));
    }

    public static double tropicalLongitude(long l)
    {
        long l1 = (long) Math.floor(l - OldHinduSolar.EPOCH);
        double d = ProtoDate.deg(27D) - Math.abs(ProtoDate.deg(54D) - ProtoDate.mod(ProtoDate.deg(27D) + ProtoDate.deg(108D) * 3.8024793772721099E-007D * (double) l1, 108D));
        return ProtoDate.mod(solarLongitude(l) - d, 360D);
    }

    public static double risingSign(long l)
    {
        int i = (int) ProtoDate.mod(ProtoDate.quotient(tropicalLongitude(l), ProtoDate.deg(30D)), 6L);
        return rs[i];
    }

    public static double dailyMotion(long l)
    {
        double d = ProtoDate.deg(360D) / 365.2587564814815D;
        double d1 = meanPosition(l, 365.25878920258134D);
        double d2 = 0.03888888888888889D - Math.abs(hinduSine(d1)) / 1080D;
        int i = (int) ProtoDate.quotient(d1, ProtoDate.deg(225D) / 60D);
        double d3 = hinduSineTable(i + 1) - hinduSineTable(i);
        double d4 = d3 * -15D * d2;
        return d * (d4 + 1.0D);
    }

    public static double solarSiderealDifference(long l)
    {
        return dailyMotion(l) * risingSign(l);
    }

    public static double sunrise(long l)
    {
        return (double) l + 0.25D + (UJJAIN.longitude - HINDU_LOCALE.longitude) / ProtoDate.deg(360D) + equationOfTime(l) + (0.99726968985094955D / ProtoDate.deg(360D))
                * (ascensionalDifference(l, HINDU_LOCALE) + 0.25D * solarSiderealDifference(l));
    }

    public static double altSunrise(long l)
    {
        try
        {
            double d = ProtoDate.sunrise(l, UJJAIN);
            return 0.00069444444444444436D * (double) Math.round(d * 24D * 60D);
        }
        catch (Exception _ex)
        {
            return 0.0D;
        }
    }

    public static double solarLongitudeAfter(double d, double d1)
    {
        double d2 = 9.9999999999999995E-007D;
        double d3 = d + 1.0146076568930043D * ProtoDate.mod(d1 - solarLongitude(d), ProtoDate.deg(360D));
        double d4 = Math.max(d, d3 - 5D);
        double d5 = d3 + 5D;
        double d6 = d4;
        double d7 = d5;
        double d8;
        for (d8 = (d7 + d6) / 2D; d7 - d6 >= d2; d8 = (d7 + d6) / 2D)
            if (ProtoDate.mod(solarLongitude(d8) - d1, 360D) < ProtoDate.deg(180D))
                d7 = d8;
            else
                d6 = d8;

        return d8;
    }

    public static double meshaSamkranti(long l)
    {
        long l1 = Gregorian.toFixed(l, 1, 1);
        return solarLongitudeAfter(l1, ProtoDate.deg(0.0D));
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1} {2} {3,number,#} S.E.", new Object[]
        { ProtoDate.nameFromDayOfWeek(toFixed(), OldHinduSolar.dayOfWeekNames), new Integer(super.day), ProtoDate.nameFromMonth(ProtoDate.adjustedMod(super.month + 1, 12), OldHinduLunar.monthNames),
                new Long(super.year) });
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof HinduSolar))
            return false;
        else
            return internalEquals(obj);
    }

    public static final double SIDEREAL_YEAR = 365.2587564814815D;
    public static final double CREATION;
    public static final double ANOMALISTIC_YEAR = 365.25878920258134D;
    public static final int SOLAR_ERA = 3179;
    public static final Location UJJAIN;
    public static final Location HINDU_LOCALE;
    private static final double rs[] =
    { 0.92777777777777781D, 0.99722222222222223D, 1.075D, 1.075D, 0.99722222222222223D, 0.92777777777777781D };

    static
    {
        CREATION = (double) OldHinduSolar.EPOCH - 714402296627D;
        UJJAIN = new Location("Ujjain, India", ProtoDate.angle(23D, 9D, 0.0D), ProtoDate.angle(75D, 46D, 0.0D), ProtoDate.mt(0.0D), 5.0512222222222221D);
        HINDU_LOCALE = UJJAIN;
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -694089942794432377L;
}
