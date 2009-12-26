// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   OldHinduLunar.java

package rmp.prp.aide.P3040000.lunar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.proto.ProtoDate;
import rmp.prp.aide.P3040000.solar.OldHinduSolar;

// Referenced classes of package calendrica:
//            Date, OldHinduSolar, ProtoDate

public class OldHinduLunar extends LunarDate
{
    public OldHinduLunar()
    {
    }

    public OldHinduLunar(long l)
    {
        super(l);
    }

    public OldHinduLunar(LunarDate date)
    {
        super(date);
    }

    public OldHinduLunar(long l, int i, boolean flag, int j)
    {
        year = l;
        month = i;
        leapMonth = flag;
        day = j;
    }

    public static long toFixed(long l, int i, boolean flag, int j)
    {
        double d = (double) (12L * l - 1L) * 30.43822337962963D;
        double d1 = 29.530581807581694D * (double) (ProtoDate.quotient(d, 29.530581807581694D) + 1L);
        return (long) Math.floor((double) OldHinduSolar.EPOCH + d1 + 29.530581807581694D * (double) (flag || Math.ceil((d1 - d) / 0.90764157204793605D) > (double) i ? i - 1 : i) + (double) (j - 1)
                * 0.9843527269193898D + 0.75D);
    }

    public long toFixed()
    {
        return toFixed(year, month, leapMonth, day);
    }

    public void fromFixed(long l)
    {
        double d = (double) OldHinduSolar.dayCount(l) + 0.25D;
        double d1 = d - ProtoDate.mod(d, 29.530581807581694D);
        leapMonth = ProtoDate.mod(d1, 30.43822337962963D) <= 0.90764157204793605D && ProtoDate.mod(d1, 30.43822337962963D) > 0.0D;
        month = 1 + (int) ProtoDate.mod(Math.ceil(d1 / 30.43822337962963D), 12D);
        day = 1 + (int) ProtoDate.mod(ProtoDate.quotient(d, 0.9843527269193898D), 30L);
        year = (long) Math.ceil((d1 + 30.43822337962963D) / 365.25868055555554D) - 1L;
    }

    public void fromArray(int ai[])
    {
        year = ai[0];
        month = ai[1];
        leapMonth = ai[2] != 0;
        day = ai[3];
    }

    public static boolean isLeapYear(long l)
    {
        return ProtoDate.mod((double) l * 365.25868055555554D - 30.43822337962963D, 29.530581807581694D) >= 18.638882943006465D;
    }

    protected String toStringFields()
    {
        return "year=" + year + ",month=" + month + ",leapMonth=" + leapMonth + ",day=" + day;
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1} {2}{3} {4,number,#} K.Y.", new Object[]
        { ProtoDate.nameFromDayOfWeek(toFixed(), dayOfWeekNames), new Integer(day), ProtoDate.nameFromMonth(month, monthNames), leapMonth ? " II" : "", new Long(year) });
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof OldHinduLunar))
            return false;
        OldHinduLunar oldhindulunar = (OldHinduLunar) obj;
        return oldhindulunar.year == year && oldhindulunar.month == month && oldhindulunar.leapMonth == leapMonth && oldhindulunar.day == day;
    }

    public long year;
    public int month;
    public boolean leapMonth;
    public int day;
    public static final double ARYA_LUNAR_MONTH = 29.530581807581694D;
    public static final double ARYA_LUNAR_DAY = 0.9843527269193898D;
    public static final String dayOfWeekNames[] =
    { "Ravivara", "Chandravara", "Mangalavara", "Buddhavara", "Brihaspatvara", "Sukravara", "Sanivara" };
    public static final String monthNames[] =
    { "Chaitra", "Vaisakha", "Jyaishtha", "Ashadha", "Sravana", "Bhadrapada", "Asvina", "Kartika", "Margasirsha", "Pausha", "Magha", "Phalguna" };

    /** serialVersionUID */
    private static final long serialVersionUID = 6452632135091841020L;
}
