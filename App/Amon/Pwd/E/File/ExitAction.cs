namespace Me.Amon.Pwd.E.File
{
    public class ExitAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.Close();
            }
        }
    }
}
