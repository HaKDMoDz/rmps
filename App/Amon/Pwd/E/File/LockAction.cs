namespace Me.Amon.Pwd.E.File
{
    public class LockAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.LockForm();
            }
        }
    }
}
