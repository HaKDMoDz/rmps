namespace Me.Amon.Pwd.E.Data
{
    public class ImportTxtAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ImportTxt();
            }
        }
    }
}
