namespace Me.Amon.Pwd.E.Edit
{
    public class DeleteCatAction : AAction
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
