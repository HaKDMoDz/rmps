namespace Me.Amon.Pwd.E.User
{
    public class PkeyAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.PkeyEdit();
            }
        }
    }
}
