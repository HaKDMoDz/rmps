using Me.Amon.Model;

namespace Me.Amon.Pwd
{
    public class Key : Vcs
    {
        public string RecId { get; set; }

        public string Data { get; set; }

        public bool FromLog(KeyLog log)
        {
            if (log == null)
            {
                return false;
            }

            RecId = log.RecId;
            Data = log.Data;
            return true;
        }

        public KeyLog ToLog()
        {
            KeyLog log = new KeyLog();
            log.RecId = RecId;
            log.Data = Data;
            return log;
        }
    }
}
