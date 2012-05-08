namespace Me.Amon.Pwd.E._Att
{
    public class CutAttAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.CutAtt();
            }
        }
    }
}
