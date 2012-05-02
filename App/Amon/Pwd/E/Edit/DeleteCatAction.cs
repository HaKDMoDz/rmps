namespace Me.Amon.Pwd.E.Edit
{
    public class DeleteCatAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.DeleteCat();
            }
        }
    }
}
