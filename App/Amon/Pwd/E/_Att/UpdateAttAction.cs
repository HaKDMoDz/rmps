﻿namespace Me.Amon.Pwd.E._Att
{
    public class UpdateAttAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.UpdateAtt();
            }
        }
    }
}
