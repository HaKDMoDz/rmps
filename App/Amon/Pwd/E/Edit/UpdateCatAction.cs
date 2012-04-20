namespace Me.Amon.Pwd.E.Edit
{
    public class UpdateCatAction : AAction
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
