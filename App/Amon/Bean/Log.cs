using System;
namespace Me.Amon.Bean
{
    public abstract class Log
    {
        /// <summary>
        /// 日志索引
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 引用对象索引
        /// </summary>
        public string RefId { get; set; }
        /// <summary>
        /// 日志时间
        /// </summary>
        public DateTime LogTime { get; set; }

        public override string ToString()
        {
            return LogTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is KeyLog)
            {
                return Id == ((KeyLog)obj).Id;
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
