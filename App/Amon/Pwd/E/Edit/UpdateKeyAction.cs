﻿namespace Me.Amon.Pwd.E.Edit
{
    public class UpdateKeyAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.UpdateKey();
            }
        }
    }
}
