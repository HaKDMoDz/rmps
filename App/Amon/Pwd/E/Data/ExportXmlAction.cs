namespace Me.Amon.Pwd.E.Data
{
    public class ExportXmlAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.ExportXml();
            }
        }
    }
}
