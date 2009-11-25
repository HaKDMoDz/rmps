// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Ecclesiastical.java

package rmp.prp.aide.P3040000.proto;

import rmp.prp.aide.P3040000.solar.Gregorian;
import rmp.prp.aide.P3040000.solar.Julian;
import cons.prp.aide.P3040000.ConstUI;

// Referenced classes of package calendrica:
//            ProtoDate, Gregorian, Julian

public abstract class Ecclesiastical extends ProtoDate
{

    public static long orthodoxEaster(long l)
    {
        long l1 = ProtoDate.mod(14L + 11L * ProtoDate.mod(l, 19L), 30L);
        long l2 = l <= 0L ? l - 1L : l;
        long l3 = Julian.toFixed(l2, 4, 19) - l1;
        return ProtoDate.kDayAfter(l3, 0);
    }

    public static long altOrthodoxEaster(long l)
    {
        long l1 = (354L * l + 30L * ProtoDate.quotient(7L * l - 8L, 19D) + ProtoDate.quotient(l, 4D))
            - ProtoDate.quotient(l, 19D) - 272L;
        return ProtoDate.kDayAfter(l1, 0);
    }

    public static long easter(long l)
    {
        long l1 = 1L + ProtoDate.quotient(l, 100D);
        long l2 = ProtoDate.mod(((14L + 11L * ProtoDate.mod(l, 19L)) - ProtoDate.quotient(3L * l1, 4D))
            + ProtoDate.quotient(5L + 8L * l1, 25D), 30L);
        long l3 = l2 != 0L && (l2 != 1L || ProtoDate.mod(l, 19L) <= 10L) ? l2 : l2 + 1L;
        long l4 = Gregorian.toFixed(l, 4, 19) - l3;
        return ProtoDate.kDayAfter(l4, 0);
    }

    public static long pentecost(long l)
    {
        return easter(l) + 49L;
    }

    public static long astronomicalEaster(long l)
    {
        long l1 = Gregorian.toFixed(l, 1, 1);
        double d = ProtoDate.solarLongitudeAfter(l1, ConstUI.SPRING);
        long l2 = (long)Math.floor(ProtoDate.apparentFromLocal(ProtoDate.localFromUniversal(ProtoDate.lunarPhaseAfter(
            d, ConstUI.FULL), ConstUI.JERUSALEM)));
        return ProtoDate.kDayAfter(l2, 0);
    }

    public Ecclesiastical()
    {
    }
}
