namespace Me.Amon.Pwd.E.Edit
{
    public class DeleteAttAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.DeleteAtt();
            }
        }
    }
}
