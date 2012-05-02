namespace Me.Amon.Pwd.E.Data
{
    public class ExportTxtAction : APwdAction
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
