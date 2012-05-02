namespace Me.Amon.Pwd.E.Edit
{
    public class UpdateCatAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.UpdateCat();
            }
        }
    }
}
