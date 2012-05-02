namespace Me.Amon.Pwd.E.Edit
{
    public class AppendKeyAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.AppendKey();
            }
        }
    }
}
