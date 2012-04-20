namespace Me.Amon.Pwd.E.Data
{
    public class RemoteBackupAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.RemoteBackup();
            }
        }
    }
}
