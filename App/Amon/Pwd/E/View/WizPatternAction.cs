namespace Me.Amon.Pwd.E.View
{
    public class WizPatternAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ShowAWiz();
            }
        }
    }
}
