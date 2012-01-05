namespace Msec.Uc.UkUi
{
    public class Confuse : AUk
    {
        public Confuse(Main main, Uk uk)
            : base(main, uk)
        {
        }

        public override void InitOpt()
        {
            _Uk.Enabled = false;
        }

        public override void InitDir(string dir)
        {
        }

        public override void InitAlg(string alg)
        {
            Util.Clear(_Uk.CbSize);
            _SizeDef.D = "32767";
            _Uk.CbSize.SelectedIndex = 0;

            _Uk.LbSize.Enabled = false;
            _Uk.CbSize.Enabled = false;
        }

        public override void MorePass()
        {
        }

        public override void MoreSalt()
        {
        }

        public override bool Check()
        {
            return true;
        }

        public override Org.BouncyCastle.Crypto.ICipherParameters GenParam()
        {
            return null;
        }
    }
}