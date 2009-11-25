// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Armenian.java

package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            StandardDate, Egyptian, ProtoDate, Date

public class Armenian extends SolarDate
{
    public Armenian()
    {
    }

    public Armenian(long l)
    {
        super(l);
    }

    public Armenian(LunarDate date)
    {
        super(date);
    }

    public Armenian(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        return (0x312e3L + Egyptian.toFixed(l, i, j)) - Egyptian.EPOCH;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        Egyptian egyptian = new Egyptian((l + Egyptian.EPOCH) - 0x312e3L);
        super.year = ((SolarDate)(egyptian)).year;
        super.month = ((SolarDate)(egyptian)).month;
        super.day = ((SolarDate)(egyptian)).day;
    }

    public String format()
    {
        return MessageFormat.format("{0}, {1} {2} {3,number,#}", new Object[]{
            ProtoDate.nameFromDayOfWeek(toFixed(), dayOfWeekNames), new Integer(super.day),
            ProtoDate.nameFromMonth(super.month, monthNames), new Long(super.year)});
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof Armenian))
            return false;
        else
            return internalEquals(obj);
    }

    public static final long   EPOCH            = 0x312e3L;
    public static final String dayOfWeekNames[] = {"Miashabathi", "Erkoushabathi", "Erekhshabathi", "Chorekhshabathi",
        "Hingshabathi", "Urbath", "Shabath"     };
    public static final String monthNames[]     = {"Nawasardi", "Hori", "Sahmi", "Tre", "Kaloch", "Arach", "Mehekani",
        "Areg", "Ahekani", "Mareri", "Margach", "Hrotich", "Aweleach"};

    /** serialVersionUID */
    private static final long  serialVersionUID = 5637062491755009633L;
}
