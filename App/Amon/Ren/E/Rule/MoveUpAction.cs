using System;

namespace Me.Amon.Ren.E.Rule
{
    public class MoveUpAction : ARenAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp != null)
            {
                IApp.MoveUpSelectedRule();
            }
        }
    }
}
