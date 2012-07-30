namespace Me.Amon.Sql.E
{
    public class NewPdqAction : ASqlAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.NewPdqTab(true);
            }
        }
    }
}
