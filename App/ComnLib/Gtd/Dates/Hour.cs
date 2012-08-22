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

        public override DateTime Next(DateTime time, out bool changed)
        {
            changed = false;

            if (Values.Count < 1)
            {
                return time;
            }
            if (Type == CGtd.TYPE_MINOR_EACH)
            {
                return time.AddHours(Values[0]);
            }
            if (Type == CGtd.TYPE_MINOR_WHEN)
            {
                int idx = time.Hour;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return time.AddHours(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return time.AddDays(1).AddHours(Values[0] - idx);
                }
            }
            return time;
        }
    }
}
