namespace Me.Amon.Pwd.E.Edit
{
    public class UpdateAttPassAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.UpdateAtt(Att.TYPE_PASS);
            }
        }
    }
}
