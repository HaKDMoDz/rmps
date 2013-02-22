using System;

namespace Me.Amon.Bean
{
    public class Log
    {
        private string _Id;
        private string _LogDate;

        /// <summary>
        /// 日志索引
        /// </summary>
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                _LogDate = DateTime.FromFileTime(Convert.ToInt64(_Id, 16)).ToString(IEnv.DATEIME_FORMAT);
            }
        }

        /// <summary>
        /// 口令索引
        /// </summary>
        public Key Key { get; set; }

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
                return _Id == ((Log)obj).Id;
            }
            if (obj is string)
            {
                return _Id == (string)obj;
            }
            return _Id.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _Id.GetHashCode();
        }
    }
}
