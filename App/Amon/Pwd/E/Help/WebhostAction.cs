using System;
using System.Diagnostics;

namespace Me.Amon.Pwd.E.Help
{
    public class WebhostAction : APwdAction
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
