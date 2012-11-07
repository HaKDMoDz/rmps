namespace Me.Amon.Pwd.E._Att
{
    public class SelectNextAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.AttSelectNext();
            }
        }
    }
}
