namespace Me.Amon.Pwd.E.Edit
{
    public class DeleteCatAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.DeleteCat();
            }
        }
    }
}
