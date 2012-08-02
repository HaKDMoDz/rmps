namespace Me.Amon.Sql.E
{
    public class ExecuteAction : ASqlAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.DoExecute();
            }
        }
    }
}
