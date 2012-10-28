namespace Me.Amon.Pwd.E.User
{
    public class LibEditAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ShowLibEdit();
            }
        }
    }
}
