using System;
using System.Diagnostics;

namespace Me.Amon.Pcs.E.Help
{
    public class WebHostAction : APcsAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            try
            {
                Process.Start("http://amon.me/");
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
            }
        }
    }
}
