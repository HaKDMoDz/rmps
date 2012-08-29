using System;

namespace Me.Amon.Gtd.Dates
{
    public class Second : ADates
    {
        public Second()
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
                return lastTime.AddSeconds(Values[0]);
            }
            if (Type == CGtd.TYPE_MINOR_WHEN)
            {
                int idx = currTime.Second;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return currTime.AddSeconds(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return currTime.AddMinutes(1).AddSeconds(Values[0] - idx);
                }
            }
            return currTime;
        }
    }
}
