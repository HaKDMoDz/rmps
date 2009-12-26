// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Hebrew.java

package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;
import java.util.Vector;

import rmp.prp.aide.P3040000.b.Location;
import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;
import cons.prp.aide.P3040000.ConstUI;

// Referenced classes of package calendrica:
//            StandardDate, BogusDateException, BogusTimeException, Coptic, 
//            FixedVector, Gregorian, Julian, ProtoDate, 
//            Date, Location

public class Hebrew extends SolarDate
{
    public Hebrew()
    {
    }

    public Hebrew(long l)
    {
        super(l);
    }

    public Hebrew(LunarDate date)
    {
        super(date);
    }

    public Hebrew(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        long l1 = (newYear(l) + (long) j) - 1L;
        if (i < 7)
        {
            for (int k = 7; k <= lastMonthOfYear(l); k++)
                l1 += lastDayOfMonth(k, l);

            for (int j1 = 1; j1 < i; j1++)
                l1 += lastDayOfMonth(j1, l);

        }
        else
        {
            for (int i1 = 7; i1 < i; i1++)
                l1 += lastDayOfMonth(i1, l);

        }
        return l1;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        long l1 = 1L + ProtoDate.quotient(l - EPOCH, 365.24682220597794D);
        for (super.year = l1 - 1L; newYear(super.year) <= l; super.year++)
            ;
        super.year--;
        int i = l >= toFixed(super.year, 1, 1) ? 1 : 7;
        for (super.month = i; l > toFixed(super.year, super.month, lastDayOfMonth(super.month, super.year)); super.month++)
            ;
        super.day = (int) ((1L + l) - toFixed(super.year, super.month, 1));
    }

    public static boolean isLeapYear(long l)
    {
        return ProtoDate.mod(1L + 7L * l, 19L) < 7L;
    }

    public static int lastMonthOfYear(long l)
    {
        return !isLeapYear(l) ? 12 : 13;
    }

    public static int lastDayOfMonth(int i, long l)
    {
        return i != 2 && i != 4 && i != 6 && i != 10 && i != 13 && (i != 12 || isLeapYear(l)) && (i != 8 || hasLongMarheshvan(l)) && (i != 9 || !hasShortKislev(l)) ? 30 : 29;
    }

    public static double moment(int i, long l)
    {
        long l1 = i >= 7 ? l : l + 1L;
        long l2 = (long) (i - 7) + ProtoDate.quotient(235L * l1 - 234L, 19D);
        return ((double) EPOCH - 0.033796296296296297D) + (double) l2 * (29D + ProtoDate.hr(12D) + 0.030594135802469134D);
    }

    public static long calendarElapsedDays(long l)
    {
        long l1 = ProtoDate.quotient(235L * l - 234L, 19D);
        double d = 12084D + 13753D * (double) l1;
        long l2 = 29L * l1 + ProtoDate.quotient(d, 25920D);
        if (ProtoDate.mod(3L * (l2 + 1L), 7L) < 3L)
            return l2 + 1L;
        else
            return l2;
    }

    public static long newYear(long l)
    {
        return EPOCH + calendarElapsedDays(l) + (long) newYearDelay(l);
    }

    public static int newYearDelay(long l)
    {
        long l1 = calendarElapsedDays(l - 1L);
        long l2 = calendarElapsedDays(l);
        long l3 = calendarElapsedDays(l + 1L);
        if (l3 - l2 == 356L)
            return 2;
        return l2 - l1 != 382L ? 0 : 1;
    }

    public static int daysInYear(long l)
    {
        return (int) (newYear(l + 1L) - newYear(l));
    }

    public static boolean hasLongMarheshvan(long l)
    {
        int i = daysInYear(l);
        return i == 355 || i == 385;
    }

    public static boolean hasShortKislev(long l)
    {
        int i = daysInYear(l);
        return i == 353 || i == 383;
    }

    public static double jewishDusk(long l, Location location) throws Exception
    {
        return ProtoDate.dusk(l, location, ProtoDate.angle(4D, 40D, 0.0D));
    }

    public static double jewishSabbathEnds(long l, Location location) throws Exception
    {
        return ProtoDate.dusk(l, location, ProtoDate.angle(7D, 5D, 0.0D));
    }

    public static double jewishMorningEnd(long l, Location location) throws Exception
    {
        return ProtoDate.standardFromSundial(l, 10D, location);
    }

    public static long yomKippur(long l)
    {
        long l1 = (1L + l) - Gregorian.yearFromFixed(EPOCH);
        return toFixed(l1, 7, 10);
    }

    public static long passover(long l)
    {
        long l1 = l - Gregorian.yearFromFixed(EPOCH);
        return toFixed(l1, 1, 15);
    }

    public static long classicalPassoverEve(long l)
    {
        long l1 = Gregorian.toFixed(l, 1, 1);
        double d = ProtoDate.solarLongitudeAfter(l1, ConstUI.SPRING);
        try
        {
            long l2 = ProtoDate.phasisOnOrBefore((long) Math.floor(d) + 10L, ConstUI.JERUSALEM);
            double d1 = ProtoDate.universalFromStandard(ProtoDate.sunset(l2 + 14L, ConstUI.JERUSALEM), ConstUI.JERUSALEM);
            long l3 = d >= d1 ? ProtoDate.phasisOnOrBefore(l2 + 45L, ConstUI.JERUSALEM) : l2;
            return l3 + 13L;
        }
        catch (Exception _ex)
        {
            return 0L;
        }
    }

    public static int[] omer(long l) throws Exception
    {
        long l1 = l - passover(Gregorian.yearFromFixed(l));
        int ai[];
        if (l1 >= 1L && l1 <= 49L)
            ai = (new int[]
            { (int) ProtoDate.quotient(l1, 7D), (int) ProtoDate.mod(l1, 7L) });
        else
            throw new Exception();
        return ai;
    }

    public static long purim(long l)
    {
        long l1 = l - Gregorian.yearFromFixed(EPOCH);
        int i = lastMonthOfYear(l1);
        return toFixed(l1, i, 14);
    }

    public static long taAnitEsther(long l)
    {
        long l1 = purim(l);
        if (ProtoDate.dayOfWeekFromFixed(l1) == 0L)
            return l1 - 3L;
        else
            return l1 - 1L;
    }

    public static long tishahBeAv(long l)
    {
        long l1 = l - Gregorian.yearFromFixed(EPOCH);
        long l2 = toFixed(l1, 5, 9);
        if (ProtoDate.dayOfWeekFromFixed(l2) == 6L)
            return l2 + 1L;
        else
            return l2;
    }

    public static Vector<Long> birkathHaHama(long l)
    {
        Vector<Long> fixedvector = Coptic.inGregorian(7, 30, l);
        if (fixedvector.size() != 0 && ProtoDate.mod(((SolarDate) (new Coptic(fixedvector.get(0)))).year, 28L) == 17L)
            return fixedvector;
        else
            return new Vector<Long>();
    }

    public static Vector<Long> shEla(long l)
    {
        return Coptic.inGregorian(3, 26, l);
    }

    public static long yomHaZikkaron(long l)
    {
        long l1 = l - Gregorian.yearFromFixed(EPOCH);
        long l2 = toFixed(l1, 2, 4);
        if (ProtoDate.dayOfWeekFromFixed(l2) > 3L)
            return ProtoDate.kDayBefore(l2, 3);
        else
            return l2;
    }

    public static long birthday(Hebrew hebrew, long l)
    {
        if (((SolarDate) (hebrew)).month == lastMonthOfYear(((SolarDate) (hebrew)).year))
            return toFixed(l, lastMonthOfYear(l), ((SolarDate) (hebrew)).day);
        else
            return (toFixed(l, ((SolarDate) (hebrew)).month, 1) + (long) ((SolarDate) (hebrew)).day) - 1L;
    }

    public static Vector<Long> birthdayInGregorian(Hebrew hebrew, long l)
    {
        long l1 = Gregorian.toFixed(l, 1, 1);
        long l2 = Gregorian.toFixed(l, 12, 31);
        long l3 = ((SolarDate) (new Hebrew(l1))).year;
        long l4 = birthday(hebrew, l3);
        long l5 = birthday(hebrew, l3 + 1L);
        Vector<Long> fixedvector = new Vector<Long>(1, 1);
        if (l1 <= l4)
            fixedvector.add(l4);
        if (l5 <= l2)
            fixedvector.add(l5);
        return fixedvector;
    }

    public static long yahrzeit(Hebrew hebrew, long l)
    {
        long l1;
        if (((SolarDate) (hebrew)).month == 8 && ((SolarDate) (hebrew)).day == 30 && !hasLongMarheshvan(((SolarDate) (hebrew)).year + 1L))
            l1 = toFixed(l, 9, 1) - 1L;
        else if (((SolarDate) (hebrew)).month == 9 && ((SolarDate) (hebrew)).day == 30 && hasShortKislev(((SolarDate) (hebrew)).year + 1L))
            l1 = toFixed(l, 10, 1) - 1L;
        else if (((SolarDate) (hebrew)).month == 13)
            l1 = toFixed(l, lastMonthOfYear(l), ((SolarDate) (hebrew)).day);
        else if (((SolarDate) (hebrew)).day == 30 && ((SolarDate) (hebrew)).month == 12 && !isLeapYear(l))
            l1 = toFixed(l, 11, 30);
        else
            l1 = (toFixed(l, ((SolarDate) (hebrew)).month, 1) + (long) ((SolarDate) (hebrew)).day) - 1L;
        return l1;
    }

    public static Vector<Long> yahrzeitInGregorian(Hebrew hebrew, long l)
    {
        long l1 = Gregorian.toFixed(l, 1, 1);
        long l2 = Gregorian.toFixed(l, 12, 31);
        long l3 = ((SolarDate) (new Hebrew(l1))).year;
        long l4 = yahrzeit(hebrew, l3);
        long l5 = yahrzeit(hebrew, l3 + 1L);
        Vector<Long> fixedvector = new Vector<Long>(1, 1);
        if (l1 <= l4)
            fixedvector.add(l4);
        if (l5 <= l2)
            fixedvector.add(l5);
        return fixedvector;
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1} {2} {3,number,#} A.M.", new Object[]
        { ProtoDate.nameFromDayOfWeek(toFixed(), dayOfWeekNames), new Integer(super.day), ProtoDate.nameFromMonth(super.month, isLeapYear(super.year) ? leapYearMonthNames : monthNames),
                new Long(super.year) });
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof Hebrew))
            return false;
        else
            return internalEquals(obj);
    }

    public static final int TISHRI = 7;
    public static final int NISAN = 1;
    public static final long EPOCH = Julian.toFixed(Julian.BCE(3761L), 10, 7);
    public static final String dayOfWeekNames[] =
    { "yom rishon", "yom sheni", "yom shelishi", "yom revi`i", "yom hamishi", "yom shishi", "yom shabbat" };
    public static final String monthNames[] =
    { "Nisan", "Iyyar", "Sivan", "Tammuz", "Av", "Elul", "Tishri", "Marheshvan", "Kislev", "Tevet", "Shevat", "Adar" };
    public static final String leapYearMonthNames[] =
    { "Nisan", "Iyyar", "Sivan", "Tammuz", "Av", "Elul", "Tishri", "Marheshvan", "Kislev", "Tevet", "Shevat", "Adar I", "Adar II" };

    /** serialVersionUID */
    private static final long serialVersionUID = 6903103842316234718L;
}
