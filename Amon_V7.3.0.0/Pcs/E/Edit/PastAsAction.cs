using System;

namespace Me.Amon.Pcs.E.Edit
{
    public class PastAsAction : APcsAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp != null)
            {
                IApp.PasteMetaAs();
            }
        }
    }
}
