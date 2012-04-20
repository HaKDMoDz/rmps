namespace Me.Amon.Pwd.E.Edit
{
    public class DeleteAttAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.DeleteAtt();
            }
        }
    }
}
