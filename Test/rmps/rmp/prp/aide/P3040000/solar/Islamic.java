// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Islamic.java

package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;
import java.util.Vector;

import rmp.prp.aide.P3040000.b.Location;
import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            StandardDate, BogusTimeException, FixedVector, Gregorian, 
//            Julian, Location, ProtoDate, Date

public class Islamic extends SolarDate
{
    public Islamic()
    {
    }

    public Islamic(long l)
    {
        super(l);
    }

    public Islamic(LunarDate date)
    {
        super(date);
    }

    public Islamic(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        return ((long) (j + 29 * (i - 1)) + ProtoDate.quotient(6 * i - 1, 11D) + (l - 1L) * 354L + ProtoDate.quotient(3L + 11L * l, 30D) + EPOCH) - 1L;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        super.year = ProtoDate.quotient(30L * (l - EPOCH) + 10646L, 10631D);
        long l1 = l - toFixed(super.year, 1, 1);
        super.month = (int) ProtoDate.quotient(11L * l1 + 330L, 325D);
        super.day = (int) ((1L + l) - toFixed(super.year, super.month, 1));
    }

    public static boolean isLeapYear(long l)
    {
        return ProtoDate.mod(11L * l + 14L, 30L) < 11L;
    }

    public static double asr(long l, Location location) throws Exception
    {
        double d = ProtoDate.universalFromStandard(ProtoDate.midday(l, location), location);
        double d1 = location.latitude;
        double d2 = ProtoDate.arcSinDegrees(ProtoDate.sinDegrees(ProtoDate.obliquity(d)) * ProtoDate.sinDegrees(ProtoDate.solarLongitude(d)));
        double d3 = ProtoDate.arcSinDegrees(ProtoDate.sinDegrees(d1) * ProtoDate.sinDegrees(d2) + ProtoDate.cosDegrees(d1) * ProtoDate.cosDegrees(d2));
        double d4 = ProtoDate.arcTanDegrees(ProtoDate.tanDegrees(d3) / (1.0D + 2D * ProtoDate.tanDegrees(d3)), 1);
        return ProtoDate.dusk(l, location, -d4);
    }

    public static Vector<Long> inGregorian(int i, int j, long l)
    {
        long l1 = Gregorian.toFixed(l, 1, 1);
        long l2 = Gregorian.toFixed(l, 12, 31);
        long l3 = ((SolarDate) (new Islamic(l1))).year;
        long l4 = toFixed(l3, i, j);
        long l5 = toFixed(l3 + 1L, i, j);
        long l6 = toFixed(l3 + 2L, i, j);
        Vector<Long> fixedvector = new Vector<Long>(1, 1);
        if (l1 <= l4 && l4 <= l2)
            fixedvector.add(l4);
        if (l1 <= l5 && l5 <= l2)
            fixedvector.add(l5);
        if (l1 <= l6 && l6 <= l2)
            fixedvector.add(l6);
        return fixedvector;
    }

    public static Vector<Long> mawlidAnNabi(long l)
    {
        return inGregorian(3, 12, l);
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1} {2} {3,number,#} A.H.", new Object[]
        { ProtoDate.nameFromDayOfWeek(toFixed(), dayOfWeekNames), new Integer(super.day), ProtoDate.nameFromMonth(super.month, monthNames), new Long(super.year) });
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof Islamic))
            return false;
        else
            return internalEquals(obj);
    }

    public static final long EPOCH = Julian.toFixed(Julian.CE(622L), 7, 16);
    public static final Location MECCA = new Location("Mecca, Saudi Arabia", ProtoDate.angle(21D, 25D, 24D), ProtoDate.angle(39D, 49D, 24D), ProtoDate.mt(1000D), 2D);
    public static final String dayOfWeekNames[] =
    { "yaum al-ahad", "yaum al-ithnayna", "yaum ath-thalatha'", "yaum al-arba`a'", "yaum al-hamis", "yaum al-jum`a", "yaum as-sabt" };
    public static final String monthNames[] =
    { "Muharram", "Safar", "Rabi I", "Rabi II", "Jumada I", "Jumada II", "Rajab", "Sha`ban", "Ramadan", "Shawwal", "Dhu al-Qa`da", "Dhu al-Hijja" };

    /** serialVersionUID */
    private static final long serialVersionUID = 4293425095578663038L;
}
