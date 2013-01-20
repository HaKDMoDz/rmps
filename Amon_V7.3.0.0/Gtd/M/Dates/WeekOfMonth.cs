using System;

namespace Me.Amon.Gtd.M.Dates
{
    public class WeekOfMonth : ADates
    {
        public WeekOfMonth()
        {
            MinValue = 1;
            MaxValue = 4;
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
                return time.AddDays(Values[0] * 7);
            }
            if (Type == CGtd.DATES_TYPE_WHEN)
            {
                // 当前日期
                int day = time.Day;
                // 当月天数
                int cnt = DateTime.DaysInMonth(time.Year, time.Month);

                if (Reverse)
                {
                    // 当前周数
                    int idx = time.Day / 7 + 1;
                    // 下个周数
                    int tmp = NextValue(idx, changed);
                    if (tmp > 0)
                    {
                        return time.AddDays(tmp * 7);
                    }
                    if (tmp < 0)
                    {
                        changed = true;
                        return time.AddDays((Values[0] - idx) * 7).AddMonths(1);
                    }
                }
                else
                {
                    // 当前周数
                    int idx = (cnt - day) / 7 + 1;
                    // 下个周数
                    int tmp = NextValue(idx, changed);
                    if (tmp > 0)
                    {
                        return time.AddDays(tmp * -7);
                    }
                    if (tmp < 0)
                    {
                        changed = true;
                        return time.AddDays((Values[0] - idx) * -7).AddMonths(1);
                    }
                }
            }
            return time;
        }
    }
}
