using System;

namespace Me.Amon.Gtd.Dates
{
    public class Year : ADates
    {
        public override DateTime Next(DateTime currTime, DateTime lastTime, out bool changed)
        {
            changed = false;

            if (Type == CGtd.TYPE_MINOR_EACH)
            {
                if (Values.Count > 0)
                {
                    return lastTime.AddYears(Values[0]);
                }
            }
            return currTime;
        }
    }
}
