using System;

namespace Me.Amon.Ren.E.File
{
    public class ClearAction : ARenAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ClearAllFile();
            }
        }
    }
}
