using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;

namespace Msec.Uc.UkUi
{
    public class Sstream : AUk
    {
        public Sstream(Main main, Uk uk)
            : base(main, uk)
        {
        }

        public override void InitOpt()
        {
            _Uk.Enabled = true;
        }

        public override void InitDir(string dir)
        {
            bool b = dir != "0";
            _Uk.TbPass.Enabled = b;
            _Uk.BtPass.Enabled = b;

            _Uk.TbSalt.Enabled = b;
            _Uk.BtSalt.Enabled = b;
        }

        public override void InitAlg(string alg)
        {
            Util.Clear(_Uk.CbSize);
            _Uk.CbSize.SelectedIndex = 0;

            switch (alg)
            {
                case IData.SSTREAM_HC128:
                    _SizeDef.D = "16";
                    //128
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    break;
                case IData.SSTREAM_HC256:
                    _SizeDef.D = "32";
                    //256
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case IData.SSTREAM_ISAAC:
                    _SizeDef.D = "64";
                    //32 .. 8192
                    for (int i = 64; i <= 1024; i += 64)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SSTREAM_RC4:
                    _SizeDef.D = "10";
                    //40 .. 2048
                    for (int i = 8; i <= 256; i += 8)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SSTREAM_SALSA20:
                    _SizeDef.D = "32";
                    //128/256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case IData.SSTREAM_VMPC:
                    _SizeDef.D = "32";
                    //8 .. 6144
                    for (int i = 32; i <= 768; i += 32)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SSTREAM_VMPCKSA3:
                    _SizeDef.D = "48";
                    //8 .. 6144
                    for (int i = 48; i <= 768; i += 48)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                default:
                    _SizeDef.D = "32767";
                    break;
            }

            _Uk.LbSize.Enabled = true;
            _Uk.CbSize.Enabled = true;
        }

        public override void MorePass()
        {
            _Main.ShowPass(_Uk.TbPass.Text, new CallBackHandler<string>(PassCallBack));
        }

        public override void MoreSalt()
        {
            _Main.ShowPass(_Uk.TbPass.Text, new CallBackHandler<string>(SaltCallBack));
        }

        public override bool Check()
        {
            if (string.IsNullOrEmpty(_Uk.TbPass.Text))
            {
                _Main.ShowAlert("请输入口令！");
                _Uk.TbPass.Focus();
                return false;
            }
            return true;
        }

        public override ICipherParameters GenParam()
        {
            string pass = Util.GenPass(_Uk.TbPass.Text, _Uk.TbPass.MaxLength);
            return new KeyParameter(Encoding.Default.GetBytes(pass));
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
