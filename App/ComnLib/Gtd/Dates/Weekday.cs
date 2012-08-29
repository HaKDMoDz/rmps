using System;

namespace Me.Amon.Gtd.Dates
{
    public class Weekday : ADates
    {
        public Weekday()
        {
            MinValue = 0;
            MaxValue = 6;
        }

        public override DateTime Next(DateTime currTime, DateTime lastTime, out bool changed)
        {
            changed = false;

            if (Values.Count < 1)
            {
                return currTime;
            }
            if (Type == CGtd.TYPE_MINOR_EACH)
            {
                return lastTime.AddDays(Values[0]);
            }
            if (Type == CGtd.TYPE_MINOR_WHEN)
            {
                int idx = (int)currTime.DayOfWeek;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return currTime.AddDays(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return currTime.AddDays(7 + Values[0] - idx);
                }
            }
            return currTime;
        }
    }
}
