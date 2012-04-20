namespace Me.Amon.Pwd.E.Edit
{
    public class UpdateKeyAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.UpdateKey();
            }
        }
    }
}
