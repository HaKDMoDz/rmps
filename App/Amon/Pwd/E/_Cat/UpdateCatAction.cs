namespace Me.Amon.Pwd.E._Cat
{
    public class UpdateCatAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.UpdateCat();
            }
        }
    }
}
