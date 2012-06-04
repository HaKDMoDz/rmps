namespace Me.Amon.Sql.E
{
    public class ConnectAction : ASqlAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ChangeDdl();
            }
        }
    }
}
