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

        public override DateTime Next(DateTime time, out bool changed)
        {
            changed = false;

            if (Values.Count < 1)
            {
                return time;
            }
            if (Type == CGtd.TYPE_MINOR_EACH)
            {
                return time.AddMonths(Values[0]);
            }
            if (Type == CGtd.TYPE_MINOR_WHEN)
            {
                int idx = time.Month;
                int tmp = NextValue(idx, changed);
                if (tmp > 0)
                {
                    return time.AddMonths(tmp);
                }
                if (tmp < 0)
                {
                    changed = true;
                    return time.AddYears(1).AddMonths(Values[0] - idx);
                }
            }
            return time;
        }
    }
}
