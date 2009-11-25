// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Balinese.java

package rmp.prp.aide.P3040000.proto;

import java.text.MessageFormat;
import java.util.Vector;

import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.solar.Gregorian;

// Referenced classes of package calendrica:
//            ProtoDate, FixedVector, Gregorian, Date

public class Balinese extends ProtoDate
{
    public Balinese()
    {
    }

    public Balinese(long l)
    {
        super(l);
    }

    public Balinese(LunarDate date)
    {
        super(date);
    }

    public Balinese(boolean flag, int i, int j, int k, int l, int i1, int j1, int k1, int l1, int i2)
    {
        luang = flag;
        dwiwara = i;
        triwara = j;
        caturwara = k;
        pancawara = l;
        sadwara = i1;
        saptawara = j1;
        asatawara = k1;
        sangawara = l1;
        dasawara = i2;
    }

    public void fromFixed(long l)
    {
        luang = luangFromFixed(l);
        dwiwara = dwiwaraFromFixed(l);
        triwara = triwaraFromFixed(l);
        caturwara = caturwaraFromFixed(l);
        pancawara = pancawaraFromFixed(l);
        sadwara = sadwaraFromFixed(l);
        saptawara = saptawaraFromFixed(l);
        asatawara = asatawaraFromFixed(l);
        sangawara = sangawaraFromFixed(l);
        dasawara = dasawaraFromFixed(l);
    }

    public void fromArray(int ai[])
    {
        luang = ai[0] != 0;
        dwiwara = ai[1];
        triwara = ai[2];
        caturwara = ai[3];
        pancawara = ai[4];
        sadwara = ai[5];
        saptawara = ai[6];
        asatawara = ai[7];
        sangawara = ai[8];
        dasawara = ai[9];
    }

    public static int dayFromFixed(long l)
    {
        return (int)ProtoDate.mod(l - EPOCH, 210L);
    }

    public static boolean luangFromFixed(long l)
    {
        return ProtoDate.mod(dasawaraFromFixed(l), 2) == 0;
    }

    public static int dwiwaraFromFixed(long l)
    {
        return ProtoDate.mod(dasawaraFromFixed(l) + 1, 2) + 1;
    }

    public static int triwaraFromFixed(long l)
    {
        return ProtoDate.mod(dayFromFixed(l), 3) + 1;
    }

    public static int caturwaraFromFixed(long l)
    {
        return ProtoDate.adjustedMod(asatawaraFromFixed(l), 4);
    }

    public static int pancawaraFromFixed(long l)
    {
        return ProtoDate.mod(dayFromFixed(l) + 1, 5) + 1;
    }

    public static int sadwaraFromFixed(long l)
    {
        return ProtoDate.mod(dayFromFixed(l), 6) + 1;
    }

    public static int saptawaraFromFixed(long l)
    {
        return ProtoDate.mod(dayFromFixed(l), 7) + 1;
    }

    public static int asatawaraFromFixed(long l)
    {
        int i = dayFromFixed(l);
        return ProtoDate.mod(Math.max(6, 4 + ProtoDate.mod(i - 70, 210)), 8) + 1;
    }

    public static int sangawaraFromFixed(long l)
    {
        return ProtoDate.mod(Math.max(0, dayFromFixed(l) - 3), 9) + 1;
    }

    public static int dasawaraFromFixed(long l)
    {
        int i = pancawaraFromFixed(l);
        int j = saptawaraFromFixed(l);
        return ProtoDate.mod(pancawaraI[i - 1] + saptawaraJ[j - 1] + 1, 10);
    }

    public static int weekFromFixed(long l)
    {
        return (int)ProtoDate.quotient(dayFromFixed(l), 7D) + 1;
    }

    public static long onOrBefore(Balinese balinese, long l)
    {
        int i = balinese.pancawara - 1;
        int j = balinese.sadwara - 1;
        int k = balinese.saptawara - 1;
        int i1 = ProtoDate.mod(i + 14 + 15 * (k - i), 35);
        int j1 = j + 36 * (i1 - j);
        int k1 = dayFromFixed(0L);
        return l - ProtoDate.mod((l + (long)k1) - (long)j1, 210L);
    }

    public static int day(Balinese balinese)
    {
        return (int)((onOrBefore(balinese, EPOCH + 209L) - EPOCH) + 1L);
    }

    public static int week(Balinese balinese)
    {
        return (int)(ProtoDate.quotient(day(balinese) - 1, 7D) + 1L);
    }

    public static Vector<Long> positionsInInterval(int i, int j, int k, long l, long l1)
    {
        Vector<Long> fixedvector = new Vector<Long>();
        long l2 = l;
        do
        {
            l2 += ProtoDate.mod((long)i - l - (long)k - 1L, j);
            if (l2 <= l1)
            {
                fixedvector.add(l2);
                l2++;
            }
            else
            {
                return fixedvector;
            }
        }
        while (true);
    }

    public static Vector<Long> kajengKeliwonInGregorian(long l)
    {
        long l1 = Gregorian.toFixed(l, 1, 1);
        long l2 = Gregorian.toFixed(l, 12, 31);
        int i = dayFromFixed(0L);
        return positionsInInterval(9, 15, i, l1, l2);
    }

    public static Vector<Long> tumpekInGregorian(long l)
    {
        long l1 = Gregorian.toFixed(l, 1, 1);
        long l2 = Gregorian.toFixed(l, 12, 31);
        int i = dayFromFixed(0L);
        return positionsInInterval(14, 35, i, l1, l2);
    }

    protected String toStringFields()
    {
        return "luang=" + luang + ",dwiwara=" + dwiwara + ",triwara=" + triwara + ",caturwara=" + caturwara
            + ",pancawara=" + pancawara + ",sadwara=" + sadwara + ",saptawara=" + saptawara + ",asatawara=" + asatawara
            + ",sangawara=" + sangawara + ",dasawara=" + dasawara;
    }

    public String format()
    {
        return MessageFormat.format("{0}{1} {2} {3} {4} {5} {6} {7} {8} {9}", new Object[]{luang ? "Luang " : "",
            ProtoDate.nameFromNumber(dwiwara, dwiwaraNames), ProtoDate.nameFromNumber(triwara, triwaraNames),
            ProtoDate.nameFromNumber(caturwara, caturwaraNames), ProtoDate.nameFromNumber(pancawara, pancawaraNames),
            ProtoDate.nameFromNumber(sadwara, sadwaraNames), ProtoDate.nameFromNumber(saptawara, saptawaraNames),
            ProtoDate.nameFromNumber(asatawara, asatawaraNames), ProtoDate.nameFromNumber(sangawara, sangawaraNames),
            ProtoDate.nameFromNumber(dasawara, dasawaraNames)})
            + MessageFormat.format(" ({0})", new Object[]{ProtoDate.nameFromNumber(week(this), weekNames)});
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof Balinese))
            return false;
        Balinese balinese = (Balinese)obj;
        return balinese.luang == luang && balinese.dwiwara == dwiwara && balinese.triwara == triwara
            && balinese.caturwara == caturwara && balinese.pancawara == pancawara && balinese.sadwara == sadwara
            && balinese.saptawara == saptawara && balinese.asatawara == asatawara && balinese.sangawara == sangawara
            && balinese.dasawara == dasawara;
    }

    public boolean             luang;
    public int                 dwiwara;
    public int                 triwara;
    public int                 caturwara;
    public int                 pancawara;
    public int                 sadwara;
    public int                 saptawara;
    public int                 asatawara;
    public int                 sangawara;
    public int                 dasawara;
    public static final long   EPOCH            = ProtoDate.fixedFromJD(146D);
    private static final int   pancawaraI[]     = {5, 9, 7, 4, 8};
    private static final int   saptawaraJ[]     = {5, 4, 3, 7, 8, 6, 9};
    public static final String dwiwaraNames[]   = {"Menga", "Pepet"};
    public static final String triwaraNames[]   = {"Pasah", "Beteng", "Kajeng"};
    public static final String caturwaraNames[] = {"Sri", "Laba", "Jaya", "Menala"};
    public static final String pancawaraNames[] = {"Umanis", "Paing", "Pon", "Wage", "Keliwon"};
    public static final String sadwaraNames[]   = {"Tungleh", "Aryang", "Urukung", "Paniron", "Was", "Maulu"};
    public static final String saptawaraNames[] = {"Redite", "Coma", "Anggara", "Buda", "Wraspati", "Sukra",
        "Saniscara"                             };
    public static final String asatawaraNames[] = {"Sri", "Indra", "Guru", "Yama", "Ludra", "Brahma", "Kala", "Uma"};
    public static final String sangawaraNames[] = {"Dangu", "Jangur", "Gigis", "Nohan", "Ogan", "Erangan", "Urungan",
        "Tulus", "Dadi"                         };
    public static final String dasawaraNames[]  = {"Pandita", "Pati", "Suka", "Duka", "Sri", "Manuh", "Manusa", "Raja",
        "Dewa", "Raksasa"                       };
    public static final String weekNames[]      = {"Sinta", "Landep", "Ukir", "Kulantir", "Taulu", "Gumbreg", "Wariga",
        "Warigadian", "Jukungwangi", "Sungsang", "Dunggulan", "Kuningan", "Langkir", "Medangsia", "Pujut", "Pahang",
        "Krulut", "Merakih", "Tambir", "Medangkungan", "Matal", "Uye", "Menail", "Parangbakat", "Bala", "Ugu",
        "Wayang", "Kelawu", "Dukut", "Watugunung"};

    /** serialVersionUID */
    private static final long  serialVersionUID = 5988795538354770214L;
}
