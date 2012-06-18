namespace Me.Amon.Pwd.E._Cat
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
