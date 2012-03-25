namespace Me.Amon.Bean
{
    public class Key : Vcs
    {
        public string RecId { get; set; }

        public string Data { get; set; }

        public KeyLog ToLog()
        {
            KeyLog log = new KeyLog();
            log.LogId = Id;
            log.RecId = RecId;
            log.Data = Data;
            return log;
        }

        public bool FromLog(KeyLog log)
        {
            if (log == null)
            {
                return false;
            }

            Id = log.LogId;
            RecId = log.RecId;
            Data = log.Data;
            return true;
        }
    }
}
