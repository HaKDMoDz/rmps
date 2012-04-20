namespace Me.Amon.Pwd.E.Edit
{
    public class AppendAttCallAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.AppendAtt(Att.TYPE_CALL);
            }
        }
    }
}
