// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Location.java

package rmp.prp.aide.P3040000.b;

import java.io.Serializable;
import java.text.MessageFormat;

import rmp.prp.aide.P3040000.proto.ProtoDate;

// Referenced classes of package calendrica:
//            ProtoDate

public class Location implements Cloneable, Serializable
{
    public Location()
    {
    }

    public Location(String s, double d, double d1, double d2, double d3)
    {
        name = s;
        latitude = d;
        longitude = d1;
        elevation = d2;
        zone = d3;
    }

    public String toString()
    {
        return getClass().getName() + "[latitude=" + latitude + ",longitude=" + longitude + ",elevation=" + elevation
            + ",zone=" + zone + "]";
    }

    public String format()
    {
        return MessageFormat.format("{0}: lat {1} long {2} elev {3} zone {4}", new Object[]{new String(name),
            new Double(latitude), new Double(longitude), new Double(elevation), new Double(zone)});
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof Location))
            return false;
        Location location = (Location)obj;
        return location.latitude == latitude && location.longitude == longitude && location.elevation == elevation
            && location.zone == zone;
    }

    public String                name;
    public double                latitude;
    public double                longitude;
    public double                elevation;
    public double                zone;
    public static final Location URBANA           = new Location("Urbana, IL, USA", 40.100000000000001D,
                                                      -88.200000000000003D, ProtoDate.mt(225D), -6D);
    public static final Location LOS_ANGELES      = new Location("Los Angeles, CA, USA",
                                                      ProtoDate.angle(34D, 4D, 0.0D),
                                                      -ProtoDate.angle(118D, 15D, 0.0D), ProtoDate.mt(0.0D), -8D);

    /** serialVersionUID */
    private static final long    serialVersionUID = -1934464804193388070L;
}
