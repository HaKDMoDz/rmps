namespace Me.Amon.Pwd.E.Data
{
    public class NativeConfigAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.NativeConfig();
            }
        }
    }
}
