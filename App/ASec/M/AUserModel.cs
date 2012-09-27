using Me.Amon.Da;
using Me.Amon.Util;

namespace Me.Amon.M
{
    public class AUserModel
    {
        #region 全局变量
        private string _Info;
        private string _Lock;
        private byte[] _Data;

        private byte[] _Keys;
        private byte[] _Salt;
        private char[] _Mask;

        public string Code { get; protected set; }
        public string Name { get; protected set; }
        /// <summary>
        /// 用户数据所在目录
        /// </summary>
        public string DatHome { get; protected set; }
        /// <summary>
        /// 系统配置所在目录
        /// </summary>
        public string SysHome { get; protected set; }
        /// <summary>
        /// 资源文件所在目录
        /// </summary>
        public string ResHome { get; protected set; }
        public string Look { get; set; }
        public string Feel { get; set; }

        public DBA DBA { get; protected set; }
        //public DCAccess DCAccess { get { return _DCAccess; } }
        public DFA DFA { get; protected set; }
        #endregion

        #region 初始化
        public virtual void Init()
        {
        }

        public virtual void Load()
        {
        }
        #endregion

        #region 私有函数
        private char[] GenChar()
        {
            char[] c = new char[93];
            char t = '!';
            int i = 0;
            while (i < 6)
            {
                c[i++] = t++;
            }
            t = '(';
            while (i < 93)
            {
                c[i++] = t++;
            }
            return SafeUtil.NextRandomKey(c, 16, false);
        }
        #endregion
    }
}
