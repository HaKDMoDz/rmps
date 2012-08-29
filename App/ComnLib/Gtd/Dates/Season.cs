using System;

namespace Me.Amon.Gtd.Dates
{
    public class Season : ADates
    {
        public override DateTime Next(DateTime currTime, DateTime lastTime, out bool changed)
        {
            changed = false;
            return currTime;
        }
    }
}
