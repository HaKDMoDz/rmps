namespace Me.Amon.Pwd.E.Data
{
    public class RemoteResumeAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.RemoteResume();
            }
        }
    }
}
