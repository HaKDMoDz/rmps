using System.Text;
using Me.Amon.Uc;
using Me.Amon.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;

namespace Me.Amon.Sec.Pro.Uc.UkUi
{
    public class Scrypto : AUk
    {
        public Scrypto(APro apro, Uk uk)
            : base(apro, uk)
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
            _Uk.LbSize.Enabled = true;
            _Uk.CbSize.Enabled = true;

            switch (alg)
            {
                case ESec.SCRYPTO_AES:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //128,192,256--0 .. 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_AESFAST:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //128,192,256--0 .. 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_AESLIGHT:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //128,192,256--0 .. 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_BLOWFISH:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //0 .. 448
                    for (int i = 4; i <= 56; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_CAMELLIA:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //128, 192, 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_CAMELLIALIGHT:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //128, 192, 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_CAST5:
                    _SizeDef.D = "16";
                    _Uk.TbPass.MaxLength = 16;
                    _Uk.TbSalt.MaxLength = 16;
                    //0 .. 128
                    for (int i = 4; i <= 16; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_CAST6:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //0 .. 256
                    for (int i = 4; i <= 32; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_DES:
                    _SizeDef.D = "8";
                    _Uk.TbPass.MaxLength = 8;
                    _Uk.TbSalt.MaxLength = 8;
                    //64
                    _Uk.CbSize.Items.Add(new Item { K = "8", V = "8 字节" });
                    break;
                case ESec.SCRYPTO_DESEDE:
                    _SizeDef.D = "24";
                    _Uk.TbPass.MaxLength = 24;
                    _Uk.TbSalt.MaxLength = 24;
                    //128, 192
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    break;
                case ESec.SCRYPTO_GOST28147:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //256
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_NOEKEON:
                    _SizeDef.D = "16";
                    _Uk.TbPass.MaxLength = 16;
                    _Uk.TbSalt.MaxLength = 16;
                    //128
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    break;
                case ESec.SCRYPTO_NULL:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_RC2:
                    _SizeDef.D = "128";
                    _Uk.TbPass.MaxLength = 128;
                    _Uk.TbSalt.MaxLength = 128;
                    //0 .. 1024
                    for (int i = 8; i <= 128; i += 8)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_RC532:
                    _SizeDef.D = "16";
                    _Uk.TbPass.MaxLength = 16;
                    _Uk.TbSalt.MaxLength = 16;
                    //0 .. 128
                    for (int i = 4; i <= 16; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_RC564:
                    _SizeDef.D = "16";
                    _Uk.TbPass.MaxLength = 16;
                    _Uk.TbSalt.MaxLength = 16;
                    //0 .. 128
                    for (int i = 4; i <= 16; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_RC6:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //0 .. 256
                    for (int i = 4; i <= 32; i += 4)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_RIJNDAEL:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //0 .. 256
                    //128,160,192,224,256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "20", V = "20 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "28", V = "28 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_SEED:
                    _SizeDef.D = "16";
                    _Uk.TbPass.MaxLength = 16;
                    _Uk.TbSalt.MaxLength = 16;
                    //128
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    break;
                case ESec.SCRYPTO_SERPENT:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //128, 192, 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_SKIPJACK:
                    _SizeDef.D = "16";
                    _Uk.TbPass.MaxLength = 16;
                    _Uk.TbSalt.MaxLength = 16;
                    //0 .. 128
                    for (int i = 10; i <= 16; i += 1)
                    {
                        _Uk.CbSize.Items.Add(new Item { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_TEA:
                    _SizeDef.D = "16";
                    _Uk.TbPass.MaxLength = 16;
                    _Uk.TbSalt.MaxLength = 16;
                    //128
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    break;
                case ESec.SCRYPTO_TWOFISH:
                    _SizeDef.D = "32";
                    _Uk.TbPass.MaxLength = 32;
                    _Uk.TbSalt.MaxLength = 32;
                    //128, 192, 256
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "24", V = "24 字节" });
                    _Uk.CbSize.Items.Add(new Item { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_XTEA:
                    _SizeDef.D = "16";
                    _Uk.TbPass.MaxLength = 16;
                    _Uk.TbSalt.MaxLength = 16;
                    //128
                    _Uk.CbSize.Items.Add(new Item { K = "16", V = "16 字节" });
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
            _APro.ShowPass(_Uk.TbPass.Text, new CallBackHandler<string>(PassCallBack));
        }

        public override void MoreSalt()
        {
            _APro.ShowPass(_Uk.TbPass.Text, new CallBackHandler<string>(SaltCallBack));
        }

        public override bool Check()
        {
            if (string.IsNullOrEmpty(_Uk.TbPass.Text))
            {
                Main.ShowAlert("请输入口令！");
                _Uk.TbPass.Focus();
                return false;
            }
            if (_Uk.TbSalt.Visible && string.IsNullOrEmpty(_Uk.TbSalt.Text))
            {
                Main.ShowAlert("请输入向量！");
                _Uk.TbSalt.Focus();
                return false;
            }
            return true;
        }

        public override ICipherParameters GenParam()
        {
            string pass = CharUtil.GenPass(_Uk.TbPass.Text, _Uk.TbPass.MaxLength);
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