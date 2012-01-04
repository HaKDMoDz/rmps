// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Date.java

package rmp.prp.aide.P3040000.lunar;

import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            ProtoDate

public abstract class LunarDate extends ProtoDate
{

    public LunarDate()
    {
    }

    public LunarDate(long l)
    {
        super(l);
    }

    public LunarDate(LunarDate date)
    {
        super(date);
    }

    public abstract long toFixed();

    public void convertTo(ProtoDate protodate)
    {
        ProtoDate.convert(this, protodate);
    }
}
