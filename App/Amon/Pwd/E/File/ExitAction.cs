namespace Me.Amon.Pwd.E.File
{
    public class ExitAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.ExitForm();
            }
        }
    }
}
