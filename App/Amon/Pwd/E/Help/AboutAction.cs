namespace Me.Amon.Pwd.E.Help
{
    public class AboutAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.ShowAbout();
            }
        }
    }
}
