namespace Me.Amon.Pwd.E._Att
{
    public class EditClearAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.AttClear();
            }
        }
    }
}
