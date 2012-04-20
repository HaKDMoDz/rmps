namespace Me.Amon.Pwd.E.Data
{
    public class ExportTxtAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.ImportTxt();
            }
        }
    }
}
