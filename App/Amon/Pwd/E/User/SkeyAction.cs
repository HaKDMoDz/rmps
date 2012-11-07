namespace Me.Amon.Pwd.E.User
{
    public class SkeyAction : APwdAction
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
