namespace Me.Amon.Sql.E
{
    public class NewDbrAction : ASqlAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.NewDbrTab(true);
            }
        }
    }
}
