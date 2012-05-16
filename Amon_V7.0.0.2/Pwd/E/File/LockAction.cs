namespace Me.Amon.Pwd.E.File
{
    public class LockAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.LockForm();
            }
        }
    }
}
