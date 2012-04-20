namespace Me.Amon.Pwd.E.User
{
    public class SkeyAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.SkeyEdit();
            }
        }
    }
}
