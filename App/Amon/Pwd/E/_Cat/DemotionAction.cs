namespace Me.Amon.Pwd.E._Cat
{
    public class DemotionAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.CatDemotion();
            }
        }
    }
}
