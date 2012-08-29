using System;

namespace Me.Amon.Gtd.Dates
{
    public class Day : ADates
    {
        public Day()
        {
            MinValue = 1;
            MaxValue = 31;
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
                int idx = currTime.Day;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return currTime.AddDays(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return currTime.AddMonths(1).AddDays(Values[0] - idx);
                }
            }
            return currTime;
        }
    }
}
