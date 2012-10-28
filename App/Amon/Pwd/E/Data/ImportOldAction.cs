namespace Me.Amon.Pwd.E.Data
{
    public class ImportOldAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ImportOld();
            }
        }
    }
}
