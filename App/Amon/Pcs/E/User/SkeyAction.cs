namespace Me.Amon.Pcs.E.User
{
    public class SkeyAction : APcsAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.SkeyEdit();
            }
        }
    }
}
