using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;

namespace Msec.Uc.UkUi
{
    public class Scrypto : AUk
    {
        public Scrypto(Main main, Uk uk)
            : base(main, uk)
        {
        }

        public override void InitOpt()
        {
        }

        public override void InitDir(string dir)
        {
            _Uk.Enabled = true;

            _Uk.TbPass.Enabled = true;

            _Uk.LbSalt.Visible = false;
            _Uk.TbSalt.Visible = false;
            _Uk.BtSalt.Visible = false;
        }

        public override void InitAlg(string alg)
        {
            Util.Clear(_Uk.CbSize);
            _Uk.CbSize.SelectedIndex = 0;

            switch (alg)
            {
                case IData.SCRYPTO_AES:
                    _SizeDef.D = "32";
                    //128,192,256--0 .. 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case IData.SCRYPTO_AESFAST:
                    _SizeDef.D = "32";
                    //128,192,256--0 .. 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case IData.SCRYPTO_AESLIGHT:
                    _SizeDef.D = "32";
                    //128,192,256--0 .. 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case IData.SCRYPTO_BLOWFISH:
                    _SizeDef.D = "32";
                    //0 .. 448
                    for (int i = 4; i <= 56; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SCRYPTO_CAMELLIA:
                    _SizeDef.D = "32";
                    //128, 192, 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case IData.SCRYPTO_CAMELLIALIGHT:
                    _SizeDef.D = "32";
                    //128, 192, 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case IData.SCRYPTO_CAST5:
                    _SizeDef.D = "16";
                    //0 .. 128
                    for (int i = 4; i <= 16; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SCRYPTO_CAST6:
                    _SizeDef.D = "32";
                    //0 .. 256
                    for (int i = 4; i <= 32; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SCRYPTO_DES:
                    _SizeDef.D = "8";
                    //64
                    _Uk.CbSize.Items.Add(new Item { K = "8", V = "8 字节" });
                    break;
                case IData.SCRYPTO_DESEDE:
                    _SizeDef.D = "24";
                    //128, 192
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    break;
                case IData.SCRYPTO_GOST28147:
                    _SizeDef.D = "32";
                    //256
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case IData.SCRYPTO_NOEKEON:
                    _SizeDef.D = "16";
                    //128
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    break;
                case IData.SCRYPTO_NULL:
                    _SizeDef.D = "32";
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case IData.SCRYPTO_RC2:
                    _SizeDef.D = "128";
                    //0 .. 1024
                    for (int i = 8; i <= 128; i += 8)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SCRYPTO_RC532:
                    _SizeDef.D = "16";
                    //0 .. 128
                    for (int i = 4; i <= 16; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SCRYPTO_RC564:
                    _SizeDef.D = "16";
                    //0 .. 128
                    for (int i = 4; i <= 16; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SCRYPTO_RC6:
                    _SizeDef.D = "32";
                    //0 .. 256
                    for (int i = 4; i <= 32; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SCRYPTO_RIJNDAEL:
                    _SizeDef.D = "32";
                    //0 .. 256
                    for (int i = 4; i <= 32; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SCRYPTO_SEED:
                    _SizeDef.D = "16";
                    //128
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    break;
                case IData.SCRYPTO_SERPENT:
                    _SizeDef.D = "32";
                    //128, 192, 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case IData.SCRYPTO_SKIPJACK:
                    _SizeDef.D = "16";
                    //0 .. 128
                    for (int i = 4; i <= 16; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case IData.SCRYPTO_TEA:
                    _SizeDef.D = "16";
                    //128
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    break;
                case IData.SCRYPTO_TWOFISH:
                    _SizeDef.D = "32";
                    //128, 192, 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case IData.SCRYPTO_XTEA:
                    _SizeDef.D = "16";
                    //128
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
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
            //if (string.IsNullOrEmpty(_Uk.TbSalt.Text))
            //{
            //    _Main.ShowAlert("请输入口令！");
            //    _Uk.TbSalt.Focus();
            //    return false;
            //}
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