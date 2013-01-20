using System;

namespace Me.Amon.Pcs.E.Edit
{
    public class CopyAction : APcsAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp != null)
            {
                IApp.CopyMeta();
            }
        }
    }
}
