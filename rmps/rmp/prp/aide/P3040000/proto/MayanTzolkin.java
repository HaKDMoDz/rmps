// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   MayanTzolkin.java

package rmp.prp.aide.P3040000.proto;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.lunar.MayanLongCount;

// Referenced classes of package calendrica:
//            ProtoDate, BogusDateException, MayanHaab, MayanLongCount, 
//            Date

public class MayanTzolkin extends ProtoDate
{
    public MayanTzolkin()
    {
    }

    public MayanTzolkin(long l)
    {
        super(l);
    }

    public MayanTzolkin(LunarDate date)
    {
        super(date);
    }

    public MayanTzolkin(int i, int j)
    {
        number = i;
        name = j;
    }

    public void fromFixed(long l)
    {
        long l1 = (l - EPOCH) + 1L;
        number = (int) ProtoDate.adjustedMod(l1, 13L);
        name = (int) ProtoDate.adjustedMod(l1, 20L);
    }

    public void fromArray(int ai[])
    {
        number = ai[0];
        name = ai[1];
    }

    public static int ordinal(MayanTzolkin mayantzolkin)
    {
        return ProtoDate.mod((mayantzolkin.number - 1) + 39 * (mayantzolkin.number - mayantzolkin.name), 260);
    }

    public static long onOrBefore(MayanTzolkin mayantzolkin, long l)
    {
        return l - ProtoDate.mod(l - EPOCH - (long) ordinal(mayantzolkin), 260L);
    }

    public static long calendarRoundOnOrBefore(MayanHaab mayanhaab, MayanTzolkin mayantzolkin, long l) throws Exception
    {
        long l1 = (long) MayanHaab.ordinal(mayanhaab) + MayanHaab.EPOCH;
        long l2 = (long) ordinal(mayantzolkin) + EPOCH;
        long l3 = l2 - l1;
        long l4;
        if (ProtoDate.mod(l3, 5L) == 0L)
            l4 = l - ProtoDate.mod(l - l1 - 365L * l3, 18980L);
        else
            throw new Exception();
        return l4;
    }

    protected String toStringFields()
    {
        return "number=" + number + ",name=" + name;
    }

    public String format()
    {
        return MessageFormat.format("{0} {1}", new Object[]
        { new Integer(number), ProtoDate.nameFromNumber(name, names) });
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof MayanTzolkin))
            return false;
        MayanTzolkin mayantzolkin = (MayanTzolkin) obj;
        return mayantzolkin.number == number && mayantzolkin.name == name;
    }

    public int number;
    public int name;
    public static final long EPOCH;
    public static final String names[] =
    { "Imix", "Ik", "Akbal", "Kan", "Chicchan", "Cimi", "Manik", "Lamat", "Muluc", "Oc", "Chuen", "Eb", "Ben", "Ix", "Men", "Cib", "Caban", "Etznab", "Cauac", "Ahau" };

    static
    {
        EPOCH = MayanLongCount.EPOCH - (long) ordinal(new MayanTzolkin(4, 20));
    }

    /** serialVersionUID */
    private static final long serialVersionUID = -5212719614175376937L;
}
