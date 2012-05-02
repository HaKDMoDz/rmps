namespace Me.Amon.Pwd.E.View
{
    public class ProPattenAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ShowAPro();
            }
        }
    }
}
