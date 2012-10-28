namespace Me.Amon.Pwd.E._Key
{
    public class DeleteKeyAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.DeleteKey();
            }
        }
    }
}
