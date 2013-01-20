using System;
using System.Diagnostics;

namespace Me.Amon.Pcs.E.Help
{
    public class ProjectAction : APcsAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            try
            {
                Process.Start("http://code.google.com/p/rmps/");
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
            }
        }
    }
}
