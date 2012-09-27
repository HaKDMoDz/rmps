using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.Amon.Sec.E
{
    public class LoadFavAction : ASecAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            IApp.LoadFav();
        }
    }
}
