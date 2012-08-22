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

        public override DateTime Next(DateTime time, out bool changed)
        {
            changed = false;

            if (Values.Count < 1)
            {
                return time;
            }
            if (Type == CGtd.TYPE_MINOR_EACH)
            {
                return time.AddDays(Values[0]);
            }
            if (Type == CGtd.TYPE_MINOR_WHEN)
            {
                int idx = (int)time.DayOfWeek;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return time.AddDays(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return time.AddDays(7 + Values[0] - idx);
                }
            }
            return time;
        }
    }
}
