namespace Me.Amon.Pwd.E.Data
{
    public class ImportTxtAction : APwdAction
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
