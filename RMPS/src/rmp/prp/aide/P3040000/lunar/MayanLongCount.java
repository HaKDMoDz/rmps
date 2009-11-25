// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   MayanLongCount.java

package rmp.prp.aide.P3040000.lunar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            Date, ProtoDate

public class MayanLongCount extends LunarDate
{
    public MayanLongCount()
    {
    }

    public MayanLongCount(long l)
    {
        super(l);
    }

    public MayanLongCount(LunarDate date)
    {
        super(date);
    }

    public MayanLongCount(long l, int i, int j, int k, int i1)
    {
        baktun = l;
        katun = i;
        tun = j;
        uinal = k;
        kin = i1;
    }

    public static long toFixed(long l, int i, int j, int k, int i1)
    {
        return EPOCH + l * 0x23280L + (long)(i * 7200) + (long)(j * 360) + (long)(k * 20) + (long)i1;
    }

    public long toFixed()
    {
        return toFixed(baktun, katun, tun, uinal, kin);
    }

    public void fromFixed(long l)
    {
        long l1 = l - EPOCH;
        baktun = ProtoDate.quotient(l1, 144000D);
        int i = (int)ProtoDate.mod(l1, 0x23280L);
        katun = (int)ProtoDate.quotient(i, 7200D);
        int j = ProtoDate.mod(i, 7200);
        tun = (int)ProtoDate.quotient(j, 360D);
        int k = ProtoDate.mod(j, 360);
        uinal = (int)ProtoDate.quotient(k, 20D);
        kin = ProtoDate.mod(k, 20);
    }

    public void fromArray(int ai[])
    {
        baktun = ai[0];
        katun = ai[1];
        tun = ai[2];
        uinal = ai[3];
        kin = ai[4];
    }

    protected String toStringFields()
    {
        return "baktun=" + baktun + ",katun=" + katun + ",tun=" + tun + ",uinal=" + uinal + ",kin=" + kin;
    }

    public String format()
    {
        return MessageFormat.format("{0}.{1}.{2}.{3}.{4}", new Object[]{new Long(baktun), new Integer(katun),
            new Integer(tun), new Integer(uinal), new Integer(kin)});
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof MayanLongCount))
            return false;
        MayanLongCount mayanlongcount = (MayanLongCount)obj;
        return mayanlongcount.baktun == baktun && mayanlongcount.katun == katun && mayanlongcount.tun == tun
            && mayanlongcount.uinal == uinal && mayanlongcount.kin == kin;
    }

    public long               baktun;
    public int                katun;
    public int                tun;
    public int                uinal;
    public int                kin;
    public static final long  EPOCH            = ProtoDate.fixedFromJD(584283D);

    /** serialVersionUID */
    private static final long serialVersionUID = -1597811056547377013L;
}
