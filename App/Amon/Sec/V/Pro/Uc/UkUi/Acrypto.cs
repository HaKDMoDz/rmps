using Me.Amon.Util;

namespace Me.Amon.Sec.Pro.Uc.UkUi
{
    public class Acrypto : AUk
    {
        public Acrypto(APro apro, Uk uk)
            : base(apro, uk)
        {
        }

        public override void InitOpt()
        {
            _Uk.Enabled = false;

            _Uk.LbSalt.Visible = false;
            _Uk.TbSalt.Visible = false;
            _Uk.BtSalt.Visible = false;
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
            if (string.IsNullOrEmpty(_Uk.TbPass.Text))
            {
                Main.ShowAlert("请输入口令！");
                _Uk.TbPass.Focus();
                return false;
            }
            return true;
        }

        public override Org.BouncyCastle.Crypto.ICipherParameters GenParam()
        {
            return null;
        }
    }
}