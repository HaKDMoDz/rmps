namespace Me.Amon.Pwd.E.Edit
{
    public class AppendAttTextAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.AppendAtt(Att.TYPE_TEXT);
            }
        }
    }
}
