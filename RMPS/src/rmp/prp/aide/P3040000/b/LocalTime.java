
package rmp.prp.aide.P3040000.b;

import java.io.Serializable;
import java.text.MessageFormat;

import rmp.prp.aide.P3040000.proto.ProtoDate;

public class LocalTime implements Cloneable, Serializable
{
    public LocalTime()
    {
    }

    public LocalTime(double d)
    {
        fromMoment(d);
    }

    public LocalTime(int i, int j, double d)
    {
        hour = i;
        minute = j;
        second = d;
    }

    public static double toMoment(int i, int j, double d)
    {
        return (double)i / 24D + (double)j / 1440D + d / 86400D;
    }

    public double toMoment()
    {
        return toMoment(hour, minute, second);
    }

    /*-
    (defun time-from-moment (moment)
      ;; TYPE moment -> (hour minute second)
      ;; Time of day (hour minute second) from moment moment.
      (let* ((hour (floor (mod ( * moment 24) 24)))
             (minute (floor (mod ( * moment 24 60) 60)))
             (second (double-float (mod ( * moment 24 60 60) 60))))
        (time-of-day hour minute second)))
    -*/
    public void fromMoment(double d)
    {
        hour = (int)Math.floor(ProtoDate.mod(d * 24D, 24D));
        minute = (int)Math.floor(ProtoDate.mod(d * 24D * 60D, 60D));
        second = ProtoDate.mod(d * 24D * 60D * 60D, 60D);
    }

    public String toString()
    {
        return getClass().getName() + "[hour=" + hour + ",minute=" + minute + ",second=" + second + "]";
    }

    public String format()
    {
        int i = ProtoDate.mod(hour, 12);
        int j = i != 0 ? i : 12;
        return MessageFormat.format("{0,number,00}:{1,number,00}:{2,number,00} {3}", new Object[]{new Integer(j),
            new Integer(minute), new Integer((int)second), ProtoDate.mod(hour, 24) >= 12 ? "P.M." : "A.M."});
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof LocalTime))
            return false;
        LocalTime time = (LocalTime)obj;
        return time.hour == hour && time.minute == minute && time.second == second;
    }

    public int                hour;
    public int                minute;
    public double             second;

    /** serialVersionUID */
    private static final long serialVersionUID = 3441943374677522410L;
}
