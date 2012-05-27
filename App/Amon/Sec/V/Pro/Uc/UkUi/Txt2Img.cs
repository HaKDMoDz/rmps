using Me.Amon.Util;

namespace Me.Amon.Sec.V.Pro.Uc.UkUi
{
    public class Txt2Img : AUk
    {
        public Txt2Img(APro apro, Uk uk)
            : base(apro, uk)
        {
        }

        public override void InitOpt()
        {
        }

        public override void InitDir(string dir)
        {
        }

        public override void InitAlg(string alg)
        {
            BeanUtil.Clear(_Uk.CbSize);
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