namespace Me.Amon.Pwd.E.User
{
    public class IcoEditAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.ShowIcoEdit();
            }
        }
    }
}
