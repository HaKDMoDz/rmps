namespace Msec.Uc
{
    public abstract class AUk
    {
        #region 构造函数
        protected Main _Main;
        protected Uk _Uk;

        public AUk(Main main, Uk uk)
        {
            _Main = main;
            _Uk = uk;
        }
        #endregion

        #region 用户交互
        public static Item _SizeDef = new Item { K = "0", V = "默认", D = "32767" };
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