using System;

namespace Me.Amon.Gtd.M.Dates
{
    public class Season : ADates
    {
        public override DateTime Next(DateTime time, out bool changed)
        {
            changed = false;
            return time;
        }
    }
}
