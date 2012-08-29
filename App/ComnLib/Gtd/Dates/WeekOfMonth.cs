using System;

namespace Me.Amon.Gtd.Dates
{
    public class WeekOfMonth : ADates
    {
        public WeekOfMonth()
        {
            MinValue = 1;
            MaxValue = 4;
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
                return lastTime.AddDays(Values[0] * 7);
            }
            if (Type == CGtd.TYPE_MINOR_WHEN)
            {
                // 当前日期
                int day = currTime.Day;
                // 当月天数
                int cnt = DateTime.DaysInMonth(currTime.Year, currTime.Month);

                if (Reverse)
                {
                    // 当前周数
                    int idx = currTime.Day / 7 + 1;
                    // 下个周数
                    int tmp = NextValue(idx, changed);
                    if (tmp > 0)
                    {
                        return currTime.AddDays(tmp * 7);
                    }
                    if (tmp < 0)
                    {
                        changed = true;
                        return currTime.AddDays((Values[0] - idx) * 7).AddMonths(1);
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
                        return currTime.AddDays(tmp * -7);
                    }
                    if (tmp < 0)
                    {
                        changed = true;
                        return currTime.AddDays((Values[0] - idx) * -7).AddMonths(1);
                    }
                }
            }
            return currTime;
        }
    }
}
