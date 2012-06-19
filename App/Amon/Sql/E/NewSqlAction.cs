namespace Me.Amon.Sql.E
{
    public class NewSqlAction : ASqlAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.NewSqlTab(true);
            }
        }
    }
}
