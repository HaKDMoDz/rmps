namespace Me.Amon.Bean
{
    public class RecLog : Rec
    {
        public string LogId { get; set; }

        /// <summary>
        /// 日志时间
        /// </summary>
        public string LogTime { get; set; }

        public override string ToString()
        {
            return LogTime;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is RecLog)
            {
                return LogId == ((RecLog)obj).LogId;
            }
            if (obj is string)
            {
                return LogId == (string)obj;
            }
            return LogId.Equals(obj);
        }

        public override int GetHashCode()
        {
            return LogId.GetHashCode();
        }
    }
}
