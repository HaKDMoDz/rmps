using System.Text;
using Me.Amon.Uc;
using Me.Amon.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;

namespace Me.Amon.Sec.Uc.UkUi
{
    public class Sstream : AUk
    {
        public Sstream(ASec asec, Uk uk)
            : base(asec, uk)
        {
        }

        public override void InitOpt()
        {
            _Uk.Enabled = true;

            _Uk.LbSize.Enabled = false;
            _Uk.CbSize.Enabled = false;

            _Uk.LbPass.Enabled = false;
            _Uk.TbPass.Enabled = false;
            _Uk.BtPass.Enabled = false;

            _Uk.LbSalt.Visible = false;
            _Uk.TbSalt.Visible = false;
            _Uk.BtSalt.Visible = false;
        }

        public override void InitDir(string dir)
        {
            bool b = dir != "0";

            _Uk.LbSize.Enabled = b;
            _Uk.CbSize.Enabled = b;

            _Uk.LbPass.Enabled = b;
            _Uk.TbPass.Enabled = b;
            _Uk.BtPass.Enabled = b;
        }

        public override void InitAlg(string alg)
        {
            BeanUtil.Clear(_Uk.CbSize);
            _Uk.CbSize.SelectedIndex = 0;
            _Uk.CbSize.Enabled = true;

            switch (alg)
            {
                case IData.SSTREAM_HC128:
                    _SizeDef.D = "16";
                    _Uk.TbPass.MaxLength = 16;
                    _Uk.TbSalt.MaxLength = 16;
                    //128
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.LbSalt.Visible = false;
                    _Uk.TbSalt.Visible = false;
                    _Uk.BtSalt.Visible = false;
                    break;
                case IData.SSTREAM_HC256:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //256
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    _Uk.LbSalt.Visible = false;
                    _Uk.TbSalt.Visible = false;
                    _Uk.BtSalt.Visible = false;
                    break;
                case IData.SSTREAM_ISAAC:
                    _SizeDef.D = "64";
                    _Uk.TbPass.MaxLength = 64;
                    _Uk.TbSalt.MaxLength = 64;
                    //32 .. 8192
                    for (int i = 64; i <= 1024; i += 64)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    _Uk.LbSalt.Visible = false;
                    _Uk.TbSalt.Visible = false;
                    _Uk.BtSalt.Visible = false;
                    break;
                case IData.SSTREAM_RC4:
                    _SizeDef.D = "16";
                    _Uk.TbPass.MaxLength = 16;
                    _Uk.TbSalt.MaxLength = 16;
                    //40 .. 2048
                    for (int i = 16; i <= 256; i += 16)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    _Uk.LbSalt.Visible = false;
                    _Uk.TbSalt.Visible = false;
                    _Uk.BtSalt.Visible = false;
                    break;
                case IData.SSTREAM_SALSA20:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //128/256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    _Uk.LbSalt.Visible = false;
                    _Uk.TbSalt.Visible = false;
                    _Uk.BtSalt.Visible = false;
                    break;
                case IData.SSTREAM_VMPC:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //8 .. 6144
                    for (int i = 48; i <= 768; i += 48)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    _Uk.LbSalt.Visible = true;
                    _Uk.TbSalt.Visible = true;
                    _Uk.BtSalt.Visible = true;
                    break;
                case IData.SSTREAM_VMPCKSA3:
                    _SizeDef.D = "48";
                    _Uk.TbPass.MaxLength = 48;
                    _Uk.TbSalt.MaxLength = 48;
                    //8 .. 6144
                    for (int i = 48; i <= 768; i += 48)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    _Uk.LbSalt.Visible = true;
                    _Uk.TbSalt.Visible = true;
                    _Uk.BtSalt.Visible = true;
                    break;
                default:
                    _SizeDef.D = "32767";
                    _Uk.TbPass.MaxLength = 32767;
                    _Uk.TbSalt.MaxLength = 32767;

                    _Uk.LbSalt.Visible = false;
                    _Uk.TbSalt.Visible = false;
                    _Uk.BtSalt.Visible = false;
                    break;
            }
        }

        public override void MorePass()
        {
            _ASec.ShowPass(_Uk.TbPass.Text, new CallBackHandler<string>(PassCallBack));
        }

        public override void MoreSalt()
        {
            _ASec.ShowPass(_Uk.TbPass.Text, new CallBackHandler<string>(SaltCallBack));
        }

        public override bool Check()
        {
            if (string.IsNullOrEmpty(_Uk.TbPass.Text))
            {
                _ASec.ShowAlert("请输入口令！");
                _Uk.TbPass.Focus();
                return false;
            }
            if (_Uk.TbSalt.Visible && string.IsNullOrEmpty(_Uk.TbSalt.Text))
            {
                _ASec.ShowAlert("请输入向量！");
                _Uk.TbSalt.Focus();
                return false;
            }
            return true;
        }

        public override ICipherParameters GenParam()
        {
            string pass = CharUtil.GenPass(_Uk.TbPass.Text, _Uk.TbPass.MaxLength);
            ICipherParameters param = new KeyParameter(Encoding.Default.GetBytes(pass));
            if (_Uk.TbSalt.Visible)
            {
                pass = CharUtil.GenPass(_Uk.TbSalt.Text, _Uk.TbSalt.MaxLength);
                param = new ParametersWithIV(param, Encoding.Default.GetBytes(pass));
            }
            return param;
        }

        private void PassCallBack(string data)
        {
            _Uk.TbPass.Text = data.Length > _Uk.TbPass.MaxLength ? data.Substring(0, _Uk.TbPass.MaxLength) : data;
        }

        private void SaltCallBack(string data)
        {
            _Uk.TbPass.Text = data.Length > _Uk.TbSalt.MaxLength ? data.Substring(0, _Uk.TbSalt.MaxLength) : data;
        }
    }
}