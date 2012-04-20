namespace Me.Amon.Pwd.E.File
{
    public class LockAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.LockForm();
            }
        }
    }
}
