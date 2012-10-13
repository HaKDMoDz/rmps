using System;
using System.Windows.Forms;
using Me.Amon.Sec.M;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class UwAlg : Form
    {
        private MSec _MSec;
        private Items _DefAlg;
        private Items _DefMod;
        private Items _DefPad;
        private Items _DefLen;

        public UwAlg()
        {
            InitializeComponent();
        }

        public void Init(MSec mSec)
        {
            _MSec = mSec;
            _DefAlg = new Items { K = "", V = "默认" };
            _DefMod = new Items { K = "", V = "默认" };
            _DefPad = new Items { K = "", V = "默认" };
            _DefLen = new Items { K = "", V = "默认" };

            switch (_MSec.Operation)
            {
                case ESec.OPT_CONFUSE:
                    ShowConfuse();
                    break;
                case ESec.OPT_WRAPPER:
                    ShowWrapper();
                    break;
                case ESec.OPT_DIGEST:
                    ShowDigest();
                    break;
                case ESec.OPT_SCRYPTO:
                    ShowScrypto();
                    break;
                case ESec.OPT_SSTREAM:
                    ShowSstream();
                    break;
                case ESec.OPT_ACRYPTO:
                    ShowAcrypto();
                    break;
            }
        }

        private void ShowConfuse()
        {
        }

        private void ShowWrapper()
        {
        }

        private void ShowDigest()
        {
            CbAlg.Items.Clear();
            _DefAlg.K = ESec.DIGEST_MD5;
            CbAlg.Items.Add(_DefAlg);
            CbAlg.SelectedIndex = 0;

            CbAlg.Items.Add(new Items { K = ESec.DIGEST_GOST3411, V = "Gost3411" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_MD2, V = "MD2" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_MD4, V = "MD4" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_MD5, V = "MD5" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_NULL, V = "Null" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_RIPEMD128, V = "RipeMD128" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_RIPEMD160, V = "RipeMD160" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_RIPEMD256, V = "RipeMD256" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_RIPEMD320, V = "RipeMD320" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_SHA1, V = "Sha1" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_SHA224, V = "Sha224" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_SHA256, V = "Sha256" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_SHA384, V = "Sha384" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_SHA512, V = "Sha512" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_TIGER, V = "Tiger" });
            CbAlg.Items.Add(new Items { K = ESec.DIGEST_WHIRLPOOL, V = "Whirlpool" });

            LlMod.Visible = false;
            CbMod.Visible = false;
            LlPad.Visible = false;
            CbPad.Visible = false;
            LlLen.Visible = false;
            CbLen.Visible = false;
        }

        private void ShowScrypto()
        {
            CbAlg.Items.Clear();
            _DefAlg.K = ESec.SCRYPTO_AES;
            CbAlg.Items.Add(_DefAlg);
            CbAlg.SelectedIndex = 0;
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_AES, V = "Aes" });//0 .. 256
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_AESFAST, V = "AesFast" });
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_AESLIGHT, V = "AesLight" });
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_BLOWFISH, V = "Blowfish" });//0 .. 448
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_CAMELLIA, V = "Camellia" });//128, 192, 256
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_CAMELLIALIGHT, V = "CamelliaLight" });
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_CAST5, V = "Cast5" });//0 .. 128
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_CAST6, V = "Cast6" });//0 .. 256
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_DES, V = "Des" });//64
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_DESEDE, V = "DesEde" });//128, 192
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_GOST28147, V = "Gost28147" });//256
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_NOEKEON, V = "Noekeon" });//128
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_NULL, V = "Null" });
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_RC2, V = "RC2" });//0 .. 1024
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_RC532, V = "RC5" });//0 .. 128
            //CbAlg.Items.Add(new Item { K = IData.SCRYPTO_RC564, V = "RC5（64位）" });//0 .. 128
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_RC6, V = "RC6" });//0 .. 256
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_RIJNDAEL, V = "Rijndael" });//0 .. 256
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_SEED, V = "Seed" });//128
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_SERPENT, V = "Serpent" });//128, 192, 256
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_SKIPJACK, V = "Skipjack" });//0 .. 128
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_TEA, V = "Tea" });//128
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_TWOFISH, V = "Twofish" });//128, 192, 256
            CbAlg.Items.Add(new Items { K = ESec.SCRYPTO_XTEA, V = "Xtea" });//128

            CbMod.Items.Clear();
            _DefMod.K = ESec.MODE_CBC;
            CbMod.Items.Add(_DefMod);
            CbMod.SelectedIndex = 0;
            CbMod.Items.Add(new Items { K = ESec.MODE_CBC, V = "CBC" });
            CbMod.Items.Add(new Items { K = ESec.MODE_CCM, V = "CCM" });
            CbMod.Items.Add(new Items { K = ESec.MODE_CFB, V = "CFB" });
            CbMod.Items.Add(new Items { K = ESec.MODE_EAX, V = "EAX" });
            CbMod.Items.Add(new Items { K = ESec.MODE_ECB, V = "ECB" });
            CbMod.Items.Add(new Items { K = ESec.MODE_GCM, V = "GCM" });
            //CbMod.Items.Add(new Item { K = ESec.MODE_GOFB, V = "GOFB" });
            CbMod.Items.Add(new Items { K = ESec.MODE_OFB, V = "OFB" });
            CbMod.Items.Add(new Items { K = ESec.MODE_CTS, V = "CTS" });
            CbMod.Items.Add(new Items { K = ESec.MODE_OPENPGPCFB, V = "OpenPgpCFB" });
            //CbMod.Items.Add(new Item { K = ESec.MODE_SIC, V = "SIC" });

            CbPad.Items.Clear();
            _DefPad.K = ESec.PADDING_PKCS7;
            CbPad.Items.Add(_DefPad);
            CbPad.SelectedIndex = 0;
            CbPad.Items.Add(new Items { K = ESec.PADDING_ISO10126d2, V = "ISO10126d2" });
            CbPad.Items.Add(new Items { K = ESec.PADDING_ISO7816d4, V = "ISO7816d4" });
            CbPad.Items.Add(new Items { K = ESec.PADDING_PKCS7, V = "Pkcs7" });
            CbPad.Items.Add(new Items { K = ESec.PADDING_TBC, V = "Tbc" });
            CbPad.Items.Add(new Items { K = ESec.PADDING_X923, V = "X923" });
            CbPad.Items.Add(new Items { K = ESec.PADDING_ZEROBYTE, V = "ZeroByte" });

            CbLen.Items.Clear();
            _DefLen.K = "16";
            CbLen.Items.Add(_DefLen);
            CbLen.SelectedIndex = 0;
        }

        private void ShowSstream()
        {
            CbAlg.Items.Clear();
            _DefAlg.K = ESec.SSTREAM_RC4;
            CbAlg.Items.Add(_DefAlg);
            CbAlg.SelectedIndex = 0;
            CbAlg.Items.Add(new Items { K = ESec.SSTREAM_HC128, V = "HC128", D = "128" });//128
            CbAlg.Items.Add(new Items { K = ESec.SSTREAM_HC256, V = "HC256", D = "256" });//256
            CbAlg.Items.Add(new Items { K = ESec.SSTREAM_ISAAC, V = "Isaac", D = "32" });//32 .. 8192
            CbAlg.Items.Add(new Items { K = ESec.SSTREAM_RC4, V = "RC4", D = "40" });//40 .. 2048
            CbAlg.Items.Add(new Items { K = ESec.SSTREAM_SALSA20, V = "Salsa20", D = "128" });//128/256
            CbAlg.Items.Add(new Items { K = ESec.SSTREAM_VMPC, V = "Vmpc", D = "32" });//8 .. 6144
            CbAlg.Items.Add(new Items { K = ESec.SSTREAM_VMPCKSA3, V = "VmpcKsa3", D = "32" });

            CbMod.Enabled = false;
            CbPad.Enabled = false;
        }

        private void ShowAcrypto()
        {
        }

        private void CbAlg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Items item = CbAlg.SelectedItem as Items;
            if (item == null)
            {
                return;
            }

            switch (_MSec.Operation)
            {
                case ESec.OPT_CONFUSE:
                    ChangeConfuse();
                    break;
                case ESec.OPT_WRAPPER:
                    ChangeWrapper();
                    break;
                case ESec.OPT_DIGEST:
                    ChangeDigest();
                    break;
                case ESec.OPT_SCRYPTO:
                    ChangeScrypto();
                    break;
                case ESec.OPT_SSTREAM:
                    ChangeSstream();
                    break;
                case ESec.OPT_ACRYPTO:
                    ChangeAcrypto();
                    break;
            }
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangeConfuse()
        {
        }

        private void ChangeWrapper()
        {
        }

        private void ChangeDigest()
        {
        }

        private void ChangeScrypto()
        {
            CbLen.Items.Clear();
            CbLen.Items.Add(_DefLen);
            CbLen.SelectedIndex = 0;

            switch (_MSec.Algorithm)
            {
                case ESec.SCRYPTO_AES:
                    _DefLen.K = "32";
                    //128,192,256--0 .. 256
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    CbLen.Items.Add(new Items { K = "24", V = "24 字节" });
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_AESFAST:
                    _DefLen.K = "32";
                    //128,192,256--0 .. 256
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    CbLen.Items.Add(new Items { K = "24", V = "24 字节" });
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_AESLIGHT:
                    _DefLen.K = "32";
                    //128,192,256--0 .. 256
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    CbLen.Items.Add(new Items { K = "24", V = "24 字节" });
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_BLOWFISH:
                    _DefLen.K = "32";
                    //0 .. 448
                    for (int i = 4; i <= 56; i += 4)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_CAMELLIA:
                    _DefLen.K = "32";
                    //128, 192, 256
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    CbLen.Items.Add(new Items { K = "24", V = "24 字节" });
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_CAMELLIALIGHT:
                    _DefLen.K = "32";
                    //128, 192, 256
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    CbLen.Items.Add(new Items { K = "24", V = "24 字节" });
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_CAST5:
                    _DefLen.K = "16";
                    //0 .. 128
                    for (int i = 4; i <= 16; i += 4)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_CAST6:
                    _DefLen.K = "32";
                    //0 .. 256
                    for (int i = 4; i <= 32; i += 4)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_DES:
                    _DefLen.K = "8";
                    //64
                    CbLen.Items.Add(new Items { K = "8", V = "8 字节" });
                    break;
                case ESec.SCRYPTO_DESEDE:
                    _DefLen.K = "24";
                    //128, 192
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    CbLen.Items.Add(new Items { K = "24", V = "24 字节" });
                    break;
                case ESec.SCRYPTO_GOST28147:
                    _DefLen.K = "32";
                    //256
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_NOEKEON:
                    _DefLen.K = "16";
                    //128
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    break;
                case ESec.SCRYPTO_NULL:
                    _DefLen.K = "32";
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_RC2:
                    _DefLen.K = "128";
                    //0 .. 1024
                    for (int i = 8; i <= 128; i += 8)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_RC532:
                    _DefLen.K = "16";
                    //0 .. 128
                    for (int i = 4; i <= 16; i += 4)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_RC564:
                    _DefLen.K = "16";
                    //0 .. 128
                    for (int i = 4; i <= 16; i += 4)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_RC6:
                    _DefLen.K = "32";
                    //0 .. 256
                    for (int i = 4; i <= 32; i += 4)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_RIJNDAEL:
                    _DefLen.K = "32";
                    //0 .. 256
                    //128,160,192,224,256
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    CbLen.Items.Add(new Items { K = "20", V = "20 字节" });
                    CbLen.Items.Add(new Items { K = "24", V = "24 字节" });
                    CbLen.Items.Add(new Items { K = "28", V = "28 字节" });
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_SEED:
                    _DefLen.K = "16";
                    //128
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    break;
                case ESec.SCRYPTO_SERPENT:
                    _DefLen.K = "32";
                    //128, 192, 256
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    CbLen.Items.Add(new Items { K = "24", V = "24 字节" });
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_SKIPJACK:
                    _DefLen.K = "16";
                    //0 .. 128
                    for (int i = 10; i <= 16; i += 1)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SCRYPTO_TEA:
                    _DefLen.K = "16";
                    //128
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    break;
                case ESec.SCRYPTO_TWOFISH:
                    _DefLen.K = "32";
                    //128, 192, 256
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    CbLen.Items.Add(new Items { K = "24", V = "24 字节" });
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SCRYPTO_XTEA:
                    _DefLen.K = "16";
                    //128
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    break;
                default:
                    _DefLen.K = "32";
                    //128,192,256--0 .. 256
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    CbLen.Items.Add(new Items { K = "24", V = "24 字节" });
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
            }
        }

        private void ChangeSstream()
        {
            CbLen.Items.Clear();
            CbLen.Items.Add(_DefLen);
            CbLen.SelectedIndex = 0;

            switch (_MSec.Algorithm)
            {
                case ESec.SSTREAM_HC128:
                    _DefLen.K = "16";
                    //128
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    break;
                case ESec.SSTREAM_HC256:
                    _DefLen.K = "32";
                    //256
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SSTREAM_ISAAC:
                    _DefLen.K = "64";
                    //32 .. 8192
                    for (int i = 64; i <= 1024; i += 64)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SSTREAM_RC4:
                    _DefLen.K = "16";
                    //40 .. 2048
                    for (int i = 16; i <= 256; i += 16)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SSTREAM_SALSA20:
                    _DefLen.K = "32";
                    //128/256
                    CbLen.Items.Add(new Items { K = "16", V = "16 字节" });
                    CbLen.Items.Add(new Items { K = "32", V = "32 字节" });
                    break;
                case ESec.SSTREAM_VMPC:
                    _DefLen.K = "32";
                    //8 .. 6144
                    for (int i = 48; i <= 768; i += 48)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                case ESec.SSTREAM_VMPCKSA3:
                    _DefLen.K = "48";
                    //8 .. 6144
                    for (int i = 48; i <= 768; i += 48)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
                default:
                    _DefLen.K = "16";
                    //40 .. 2048
                    for (int i = 16; i <= 256; i += 16)
                    {
                        CbLen.Items.Add(new Items { K = i.ToString(), V = i + " 字节" });
                    }
                    break;
            }
        }

        private void ChangeAcrypto()
        {
        }
    }
}
