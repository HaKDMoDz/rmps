namespace Me.Amon.Pwd.E.Data
{
    public class SyncAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.SyncData();
            }
        }
    }
}
