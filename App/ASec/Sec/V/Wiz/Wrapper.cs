using Me.Amon.Ce;
using Me.Amon.Sec.M;

namespace Me.Amon.Sec.V.Wiz
{
    public class Wrapper : ICrypto
    {
        private MSec _MSec;
        private WrapperEngine _Cipher;

        #region 接口实现
        public void Init(MSec msec)
        {
            _MSec = msec;

            if (IsText)
            {
                return;
            }

        }

        public bool IsText
        {
            get;
            set;
        }

        public bool DoCrypto(string pass)
        {
            return true;
        }
        #endregion

        #region 私有函数
        private void CreateEngine()
        {
            _Cipher = new WrapperEngine();
            _Cipher.Init(true, null);
        }
        #endregion
    }
}
