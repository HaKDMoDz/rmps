namespace Me.Amon.Pwd.E.Edit
{
    public class AppendAttMemoAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.AppendAtt(Att.TYPE_MEMO);
            }
        }
    }
}
