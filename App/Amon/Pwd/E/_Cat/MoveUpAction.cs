namespace Me.Amon.Pwd.E._Cat
{
    public class MoveUpAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.CatMoveUp();
            }
        }
    }
}
