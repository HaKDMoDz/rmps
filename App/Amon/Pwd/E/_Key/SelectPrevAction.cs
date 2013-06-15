namespace Me.Amon.Pwd.E._Key
{
    public class SelectPrevAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.SelectPrevKey();
            }
        }
    }
}
