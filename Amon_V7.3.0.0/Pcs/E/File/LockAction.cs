namespace Me.Amon.Pcs.E.File
{
    public class LockAction : APcsAction
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
