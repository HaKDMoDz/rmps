namespace Me.Amon.Pwd.E.Edit
{
    public class UpdateAttLineAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.UpdateAtt(Att.TYPE_LINE);
            }
        }
    }
}
