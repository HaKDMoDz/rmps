﻿namespace Me.Amon.Pwd.E.User
{
    public class PkeyAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.PkeyEdit();
            }
        }
    }
}
