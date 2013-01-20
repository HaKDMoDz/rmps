using System;

namespace Me.Amon.Pcs.E.File
{
    public class NativeAction : APcsAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp != null)
            {
                //IApp.NewNative();
            }
        }
    }
}
