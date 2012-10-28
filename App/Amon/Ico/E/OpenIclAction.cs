using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.Amon.Ico.E
{
    public class OpenIclAction : WIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.OpenIcl();
            }
        }
    }
}
