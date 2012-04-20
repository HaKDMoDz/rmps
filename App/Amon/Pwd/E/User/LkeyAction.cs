namespace Me.Amon.Pwd.E.User
{
    public class LkeyAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.LkeyEdit();
            }
        }
    }
}
