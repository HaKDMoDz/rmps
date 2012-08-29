using System;

namespace Me.Amon.Gtd.Dates
{
    public class Hour : ADates
    {
        public Hour()
        {
            MinValue = 0;
            MaxValue = 23;
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
                return lastTime.AddHours(Values[0]);
            }
            if (Type == CGtd.TYPE_MINOR_WHEN)
            {
                int idx = currTime.Hour;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return currTime.AddHours(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return currTime.AddDays(1).AddHours(Values[0] - idx);
                }
            }
            return currTime;
        }
    }
}
