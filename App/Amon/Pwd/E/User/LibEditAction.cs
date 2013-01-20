namespace Me.Amon.Pwd.E.User
{
    public class LibEditAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ShowLibEditer();
            }
        }
    }
}
