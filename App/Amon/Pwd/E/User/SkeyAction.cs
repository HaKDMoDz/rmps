namespace Me.Amon.Pwd.E.User
{
    public class SkeyAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.SkeyEdit();
            }
        }
    }
}
