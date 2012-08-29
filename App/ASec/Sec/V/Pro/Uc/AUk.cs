using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Pro.Uc
{
    public abstract class AUk
    {
        #region 构造函数
        protected APro _APro;
        protected Uk _Uk;

        public AUk(APro apro, Uk uk)
        {
            _APro = apro;
            _Uk = uk;
        }
        #endregion

        #region 用户交互
        public static Items _SizeDef = new Items { K = "0", V = "默认", D = "32767" };
        public abstract void InitOpt();

        public abstract void InitDir(string dir);

        public abstract void InitAlg(string alg);

        public abstract void MorePass();

        public abstract void MoreSalt();

        public abstract bool Check();

        public abstract Org.BouncyCastle.Crypto.ICipherParameters GenParam();
        #endregion
    }
}