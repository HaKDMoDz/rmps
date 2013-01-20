using Me.Amon.M;

namespace Me.Amon.Pwd.E._Cat
{
    public class ChangeIcoAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ChangeCatIcon();
            }
        }
    }
}
