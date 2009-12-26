
package rmp.prp.aide.P3040000.solar;

import java.text.MessageFormat;

import rmp.prp.aide.P3040000.b.Location;
import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.proto.ProtoDate;
import cons.prp.aide.P3040000.ConstUI;

public class French extends SolarDate
{
    public French()
    {
    }

    public French(long l)
    {
        super(l);
    }

    public French(LunarDate date)
    {
        super(date);
    }

    public French(long l, int i, int j)
    {
        super(l, i, j);
    }

    public static long toFixed(long l, int i, int j)
    {
        long l1 = newYearOnOrBefore((long)Math.floor((double)(EPOCH + 180L) + 365.242189D * (double)(l - 1L)));
        return (l1 - 1L) + (long)(30 * (i - 1)) + (long)j;
    }

    public long toFixed()
    {
        return toFixed(super.year, super.month, super.day);
    }

    public void fromFixed(long l)
    {
        long l1 = newYearOnOrBefore(l);
        super.year = Math.round((double)(l1 - EPOCH) / 365.242189D) + 1L;
        super.month = 1 + (int)ProtoDate.quotient(l - l1, 30D);
        super.day = 1 + (int)ProtoDate.mod(l - l1, 30L);
    }

    public static double midnightInParis(long l)
    {
        return ProtoDate.universalFromStandard(ProtoDate.midnight(l + 1L, PARIS), PARIS);
    }

    public static long newYearOnOrBefore(long l)
    {
        double d = ProtoDate.estimatePriorSolarLongitude(midnightInParis(l), ConstUI.AUTUMN);
        long l1;
        for (l1 = (long)(Math.floor(d) - 1.0D); ConstUI.AUTUMN > ProtoDate.solarLongitude(midnightInParis(l1)); l1++)
            ;
        return l1;
    }

    public String format()
    {
        if (super.month == 13)
            return MessageFormat.format("{0} de l''Annee {1,number,#} de la Revolution", new Object[]{
                ProtoDate.nameFromNumber(super.day, specialDayNames), new Long(super.year)});
        else
            return MessageFormat.format("Decade {0}, {1} de {2} de l''Annee {3,number,#} de la Revolution",
                new Object[]{decadeNames[(int)ProtoDate.quotient(super.day - 1, 10D)],
                    ProtoDate.nameFromNumber(super.day, dayOfWeekNames),
                    ProtoDate.nameFromMonth(super.month, monthNames), new Long(super.year)});
    }

    public boolean equals(Object obj)
    {
        if (!(obj instanceof French))
            return false;
        else
            return internalEquals(obj);
    }

    public static final long     EPOCH             = Gregorian.toFixed(1792L, 9, 22);
    public static final Location PARIS             = new Location("Paris, France", ProtoDate.angle(48D, 50D, 11D),
                                                       ProtoDate.angle(2D, 20D, 15D), ProtoDate.mt(27D), 1.0D);
    public static final String   monthNames[]      = {"Vendemiaire", "Brumaire", "Frimaire", "Nivose", "Pluviose",
        "Ventose", "Germinal", "Floreal", "Prairial", "Messidor", "Thermidor", "Fructidor", "Sansculottides"};
    public static final String   dayOfWeekNames[]  = {"Primidi", "Duodi", "Tridi", "Quartidi", "Quintidi", "Sextidi",
        "Septidi", "Octidi", "Nonidi", "Decadi"    };
    public static final String   specialDayNames[] = {"Jour de la Vertu", "Jour du Genie", "Jour du Labour",
        "Jour de la Raison", "Jour de la Recompense", "Jour de la Revolution"};
    public static final String   decadeNames[]     = {"I", "II", "III"};

    /** serialVersionUID */
    private static final long    serialVersionUID  = 7526777109571170235L;
}
