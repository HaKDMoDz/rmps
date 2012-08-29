using System;

namespace Me.Amon.Gtd.Dates
{
    public class Month : ADates
    {
        public Month()
        {
            MinValue = 1;
            MaxValue = 12;
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
                return lastTime.AddMonths(Values[0]);
            }
            if (Type == CGtd.TYPE_MINOR_WHEN)
            {
                int idx = currTime.Month;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return currTime.AddMonths(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return currTime.AddYears(1).AddMonths(Values[0] - idx);
                }
            }
            return currTime;
        }
    }
}
