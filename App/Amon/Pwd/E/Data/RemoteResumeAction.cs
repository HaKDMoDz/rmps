namespace Me.Amon.Pwd.E.Data
{
    public class RemoteResumeAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.RemoteResume();
            }
        }
    }
}
