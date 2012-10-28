namespace Me.Amon.Pwd.E._Att
{
    public class MoveUpAction : WPwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.AttMoveUp();
            }
        }
    }
}
