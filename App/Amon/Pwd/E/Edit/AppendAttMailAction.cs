namespace Me.Amon.Pwd.E.Edit
{
    public class AppendAttMailAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.AppendAtt(Att.TYPE_MAIL);
            }
        }
    }
}
