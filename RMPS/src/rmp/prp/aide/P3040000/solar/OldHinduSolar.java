// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   OldHinduSolar.java

package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            StandardDate, Julian, ProtoDate, Date

public class OldHinduSolar extends SolarDate
{
    public OldHinduSolar()
    {
    }

    public OldHinduSolar(long l)
    {
        super(l);
    }

    public OldHinduSolar(LunarDate date)
    {
        super(date);
    }

    public OldHinduSolar(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        return (long)Math
            .ceil(((double)EPOCH + (double)l * 365.25868055555554D + (double)(i - 1) * 30.43822337962963D + (double)j) - 1.25D);
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        double d = (double)dayCount(l) + 0.25D;
        super.year = ProtoDate.quotient(d, 365.25868055555554D);
        super.month = 1 + (int)ProtoDate.mod(ProtoDate.quotient(d, 30.43822337962963D), 12L);
        super.day = 1 + (int)Math.floor(ProtoDate.mod(d, 30.43822337962963D));
    }

    public static long dayCount(long l)
    {
        return l - EPOCH;
    }

    public static double dayCount(double d)
    {
        return d - (double)EPOCH;
    }

    public static int jovianYear(long l)
    {
        return 1 + (int)ProtoDate.mod(ProtoDate.quotient(dayCount(l), 361.02268109734672D), 60L);
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1} {2} {3,number,#} K.Y.", new Object[]{
            ProtoDate.nameFromDayOfWeek(toFixed(), dayOfWeekNames), new Integer(super.day),
            ProtoDate.nameFromMonth(super.month, monthNames), new Long(super.year)});
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof OldHinduSolar))
            return false;
        else
            return internalEquals(obj);
    }

    public static final long   EPOCH              = Julian.toFixed(Julian.BCE(3102L), 2, 18);
    public static final double ARYA_SOLAR_YEAR    = 365.25868055555554D;
    public static final double ARYA_SOLAR_MONTH   = 30.43822337962963D;
    public static final double ARYA_JOVIAN_PERIOD = 4332.2721731681604D;
    public static final String dayOfWeekNames[]   = {"Ravivara", "Chandravara", "Mangalavara", "Buddhavara",
        "Brihaspatvara", "Sukravara", "Sanivara"  };
    public static final String monthNames[]       = {"Mesha", "Vrishabha", "Mithuna", "Karka", "Simha", "Kanya",
        "Tula", "Vrischika", "Dhanu", "Makara", "Kumbha", "Mina"};

    /** serialVersionUID */
    private static final long  serialVersionUID   = 3729992565417739165L;
}
