
namespace Msec.Uc.UkUi
{
    public class Default : AUk
    {
        public Default(Main main, Uk uk)
            : base(main, uk)
        {
        }

        public override void InitOpt()
        {
            _Uk.Enabled = false;

            _Uk.LbPass.Text = "口令(&K)";

            _Uk.LbSalt.Visible = false;
            _Uk.TbSalt.Visible = false;
            _Uk.BtSalt.Visible = false;
        }

        public override void InitDir(string dir)
        {
        }

        public override void InitAlg(string alg)
        {
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