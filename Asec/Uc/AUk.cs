using Org.BouncyCastle.Crypto;

namespace Msec.Uc
{
    public abstract class AUk
    {
        protected Main _Main;
        protected Uk _Uk;

        public AUk(Main main, Uk uk)
        {
            _Main = main;
            _Uk = uk;
        }

        public abstract void InitOpt();

        public abstract void InitKey(string key);

        public abstract void MorePass();

        public abstract void MoreSalt();

        public abstract bool Check();
    }
}