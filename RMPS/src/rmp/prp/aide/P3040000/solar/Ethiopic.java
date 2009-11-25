// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Ethiopic.java

package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            StandardDate, Coptic, Julian, ProtoDate, 
//            Date

public class Ethiopic extends SolarDate
{
    public Ethiopic()
    {
    }

    public Ethiopic(long l)
    {
        super(l);
    }

    public Ethiopic(LunarDate date)
    {
        super(date);
    }

    public Ethiopic(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        return (Coptic.toFixed(l, i, j) - Coptic.EPOCH) + EPOCH;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        Coptic coptic = new Coptic((l + Coptic.EPOCH) - EPOCH);
        super.month = ((SolarDate)(coptic)).month;
        super.day = ((SolarDate)(coptic)).day;
        super.year = ((SolarDate)(coptic)).year;
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1} {2} {3,number,#} E.E.", new Object[]{
            ProtoDate.nameFromDayOfWeek(toFixed(), dayOfWeekNames), new Integer(super.day),
            ProtoDate.nameFromMonth(super.month, monthNames), new Long(super.year)});
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof Ethiopic))
            return false;
        else
            return internalEquals(obj);
    }

    public static final long   EPOCH            = Julian.toFixed(Julian.CE(8L), 8, 29);
    public static final String dayOfWeekNames[] = {"Ihud", "Sanyo", "Maksanyo", "Rob", "Hamus", "Arb", "Kidamme"};
    public static final String monthNames[]     = {"Maskaram", "Teqemt", "Kehdar", "Takhsas", "Ter", "Yakatit",
        "Magabit", "Miyazya", "Genbot", "Sane", "Hamle", "Nahase", "Paguemen"};

    /** serialVersionUID */
    private static final long  serialVersionUID = -6918653972141090114L;
}
