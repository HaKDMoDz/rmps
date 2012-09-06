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

        public override DateTime Next(DateTime time, out bool changed)
        {
            changed = false;

            if (Values.Count < 1)
            {
                return time;
            }
            if (Type == CGtd.DATES_TYPE_EACH)
            {
                return time.AddSeconds(Values[0]);
            }
            if (Type == CGtd.DATES_TYPE_WHEN)
            {
                int idx = time.Second;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return time.AddSeconds(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return time.AddMinutes(1).AddSeconds(Values[0] - idx);
                }
            }
            return time;
        }
    }
}
