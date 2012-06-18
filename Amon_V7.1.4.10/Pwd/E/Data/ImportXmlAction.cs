namespace Me.Amon.Pwd.E.Data
{
    public class ImportXmlAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ImportXml();
            }
        }
    }
}
