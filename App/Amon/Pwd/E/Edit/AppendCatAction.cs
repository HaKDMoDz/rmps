namespace Me.Amon.Pwd.E.Edit
{
    public class AppendCatAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.AppendCat();
            }
        }
    }
}
