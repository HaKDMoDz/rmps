// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   ChineseName.java

package rmp.prp.aide.P3040000.lunar;

import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            BogusDateException, ProtoDate

public class ChineseName
{

    public ChineseName()
    {
        stem = 1;
        branch = 1;
    }

    public ChineseName(int i, int j) throws Exception
    {
        if (ProtoDate.mod(i, 2) == ProtoDate.mod(j, 2))
        {
            stem = i;
            branch = j;
            return;
        }
        else
        {
            throw new Exception();
        }
    }

    public int stem;
    public int branch;
}
