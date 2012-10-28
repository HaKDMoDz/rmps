namespace Me.Amon.Pwd.E._Att
{
    public class EditCutAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.AttCut();
            }
        }
    }
}
