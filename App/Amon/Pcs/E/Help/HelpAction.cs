namespace Me.Amon.Pcs.E.Help
{
    public class HelpAction : APcsAction
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
