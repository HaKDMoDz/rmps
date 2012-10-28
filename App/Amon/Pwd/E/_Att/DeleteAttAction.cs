namespace Me.Amon.Pwd.E._Att
{
    public class DeleteAttAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.DeleteAtt();
            }
        }
    }
}
