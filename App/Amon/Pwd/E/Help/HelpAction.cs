namespace Me.Amon.Pwd.E.Help
{
    public class HelpAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ShowHelp();
            }
        }
    }
}
