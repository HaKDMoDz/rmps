using System;

namespace Me.Amon.Gtd.M.Dates
{
    public class Year : ADates
    {
        public override DateTime Next(DateTime time, out bool changed)
        {
            changed = false;

            if (Type == CGtd.DATES_TYPE_EACH)
            {
                if (Values.Count > 0)
                {
                    return time.AddYears(Values[0]);
                }
            }
            return time;
        }
    }
}
