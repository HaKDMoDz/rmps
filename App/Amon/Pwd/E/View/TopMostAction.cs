namespace Me.Amon.Pwd.E.View
{
    public class TopMostAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.TopMost = !APwd.TopMost;
            }
        }
    }
}
