namespace Me.Amon.Pwd.E._Key
{
    public class AppendKeyAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.NewKey();
            }
        }
    }
}
