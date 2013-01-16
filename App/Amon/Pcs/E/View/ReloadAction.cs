using System;

namespace Me.Amon.Pcs.E.View
{
    public class ReloadAction : APcsAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ReloadMeta();
            }
        }
    }
}
