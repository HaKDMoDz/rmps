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

        public override DateTime Next(DateTime time, out bool changed)
        {
            changed = false;

            if (Values.Count < 1)
            {
                return time;
            }
            if (Type == CGtd.DATES_TYPE_EACH)
            {
                return time.AddDays(Values[0]);
            }
            if (Type == CGtd.DATES_TYPE_WHEN)
            {
                int idx = time.Day;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return time.AddDays(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return time.AddMonths(1).AddDays(Values[0] - idx);
                }
            }
            return time;
        }
    }
}
