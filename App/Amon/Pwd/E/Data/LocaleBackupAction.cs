namespace Me.Amon.Pwd.E.Data
{
    public class LocaleBackupAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (APwd != null)
            {
                APwd.LocaleBackup();
            }
        }
    }
}
