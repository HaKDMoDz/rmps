namespace Me.Amon.Pwd.E.Data
{
    public class ImportXmlAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.ImportXml();
            }
        }
    }
}
