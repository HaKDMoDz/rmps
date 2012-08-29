using System;

namespace Me.Amon.Gtd.Dates
{
    public class Minute : ADates
    {
        public Minute()
        {
            MinValue = 0;
            MaxValue = 59;
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
                return lastTime.AddMinutes(Values[0]);
            }
            if (Type == CGtd.TYPE_MINOR_WHEN)
            {
                int idx = currTime.Minute;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return currTime.AddMinutes(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return currTime.AddHours(1).AddMinutes(Values[0] - idx);
                }
            }
            return currTime;
        }
    }
}
