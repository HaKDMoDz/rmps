namespace Me.Amon.Pwd.E.Edit
{
    public class AppendAttLinkAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.AppendAtt(Att.TYPE_LINK);
            }
        }
    }
}
