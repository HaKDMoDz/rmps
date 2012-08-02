namespace Me.Amon.Sql.E
{
    public class NewDbmsAction : ASqlAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ChangeDdl(null);
            }
        }
    }
}
