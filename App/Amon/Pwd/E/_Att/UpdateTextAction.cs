﻿namespace Me.Amon.Pwd.E._Att
{
    public class UpdateTextAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.UpdateAtt(Att.TYPE_TEXT);
            }
        }
    }
}