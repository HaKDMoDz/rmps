namespace Me.Amon.Pwd.E.Edit
{
    public class AppendAttFileAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.AppendAtt(Att.TYPE_FILE);
            }
        }
    }
}
