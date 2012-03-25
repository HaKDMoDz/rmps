namespace Me.Amon.Bean
{
    public class Log : Vcs
    {
        private string _LogDate;

        /// <summary>
        /// 口令索引
        /// </summary>
        public Rec Key { get; set; }

        /// <summary>
        /// 日志时间
        /// </summary>
        public string LogDate
        {
            get
            {
                return _LogDate;
            }
        }

        public override string ToString()
        {
            return _LogDate;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is Log)
            {
                return Id == ((Log)obj).Id;
            }
            if (obj is string)
            {
                return Id == (string)obj;
            }
            return Id.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
