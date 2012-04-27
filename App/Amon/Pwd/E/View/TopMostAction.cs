namespace Me.Amon.Pwd.E.View
{
    public class TopMostAction : AAction
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
