﻿namespace Me.Amon.Pwd.E._Att
{
    public class EditCopyAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.AttCopy(CopyType.Selected);
            }
        }
    }
}
