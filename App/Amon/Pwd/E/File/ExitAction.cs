namespace Me.Amon.Pwd.E.File
{
    public class ExitAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ExitForm();
            }
        }
    }
}
