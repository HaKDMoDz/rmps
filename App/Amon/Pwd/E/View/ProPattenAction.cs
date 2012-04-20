namespace Me.Amon.Pwd.E.View
{
    public class ProPattenAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.ShowAPro();
            }
        }
    }
}
