using System;

namespace Me.Amon.Ren.E
{
    public class ExitAction : ARenAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp != null)
            {
                IApp.Close();
            }
        }
    }
}
