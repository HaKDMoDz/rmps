﻿namespace Me.Amon.Pwd.E.Data
{
    public class RemoteConfigAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.RemoteConfig();
            }
        }
    }
}
