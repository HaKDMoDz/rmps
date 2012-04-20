namespace Me.Amon.Pwd.E.User
{
    public class LibEditAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.ShowLibEdit();
            }
        }
    }
}
