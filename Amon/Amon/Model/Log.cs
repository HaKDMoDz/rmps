using System;

namespace Me.Amon.Model
{
    public class Log
    {
        private long _Id;
        private string _LogDate;

        /// <summary>
        /// 日志索引
        /// </summary>
        public long Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                _LogDate = DateTime.FromBinary(_Id).ToString(IEnv.DATEIME_FORMAT);
            }
        }

        /// <summary>
        /// 口令索引
        /// </summary>
        public Key Key { get; set; }

        /// <summary>
        /// 日志时间
        /// </summary>
        public String LogDate
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
            if (obj is long)
            {
                return _Id == (long)obj;
            }
            return _Id.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _Id.GetHashCode();
        }
    }
}
