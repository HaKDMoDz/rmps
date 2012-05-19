namespace Me.Amon.Pwd.E.Help
{
    public class HelpAction : APwdAction
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
