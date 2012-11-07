namespace Me.Amon.Pwd.E.User
{
    public class UdcEditAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ShowUdcEdit();
            }
        }
    }
}
