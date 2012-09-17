using System;

namespace Me.Amon.Ren.E
{
    public class AboutAction : ARenAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp != null)
            {
                Main.ShowAbout(IApp);
            }
        }
    }
}
