namespace Me.Amon.Pwd.E._Att
{
    public class AppendFileAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.AppendAtt(Att.TYPE_FILE);
            }
        }
    }
}
