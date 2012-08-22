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

        public override DateTime Next(DateTime time, out bool changed)
        {
            changed = false;

            if (Values.Count < 1)
            {
                return time;
            }
            if (Type == CGtd.TYPE_MINOR_EACH)
            {
                return time.AddMinutes(Values[0]);
            }
            if (Type == CGtd.TYPE_MINOR_WHEN)
            {
                int idx = time.Minute;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return time.AddMinutes(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return time.AddHours(1).AddMinutes(Values[0] - idx);
                }
            }
            return time;
        }
    }
}
