namespace Me.Amon.Pwd.E.Edit
{
    public class AppendAttListAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.AppendAtt(Att.TYPE_LIST);
            }
        }
    }
}
