namespace Me.Amon.Pwd.E.View
{
    public class PadPatternAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ShowAPad();
            }
        }
    }
}
