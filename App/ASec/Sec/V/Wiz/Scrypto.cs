using System.Security.Cryptography;
using Me.Amon.Sec.M;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;

namespace Me.Amon.Sec.V.Wiz
{
    class Scrypto : ICrypto
    {
        private MSec _MSec;
        private IBlockCipher _Engine;
        private BufferedBlockCipher _Cipher;

        #region 构造函数
        public Scrypto()
        {
            //_AFile = file;
            //_AText = text;
        }
        #endregion

        #region 接口实现
        public void Init(MSec msec)
        {
            _MSec = msec;

            if (IsText)
            {
                return;
            }

            //_AFile.ClSrc.HeaderText = "输入文件";
            //_AFile.ClDst.HeaderText = "输出文件";
        }

        public bool IsText { get; set; }

        public bool DoCrypto(string pass)
        {
            //if (IsText)
            //{
            //    if (string.IsNullOrEmpty(_AText.TbSrc.Text))
            //    {
            //        Main.ShowAlert("请输入您要加密的文本！");
            //        _AText.TbSrc.Focus();
            //        return false;
            //    }

            //    pass = "";
            //}

            //if (_AFile.FileList == null || _AFile.FileList.Count < 1)
            //{
            //    Main.ShowAlert("请选择您要加密的文件！");
            //    _AFile.GvFile.Focus();
            //    return false;
            //}

            //using (SymmetricAlgorithm alg = SymmetricAlgorithm.Create(Algorithm))
            //{
            //    alg.Key = Encoding.UTF8.GetBytes(SafeUtil.GenPass(pass, 32));
            //    alg.IV = Encoding.UTF8.GetBytes(SafeUtil.GenPass(pass, 16));

            //    if (IsText)
            //    {
            //        EncryptText(alg);
            //    }
            //    else
            //    {
            //        EncryptFile(alg);
            //    }
            //}
            return true;
        }
        #endregion

        #region 私有函数
        private void CreateEngine()
        {
            switch (_MSec.Algorithm)
            {
                case ESec.SCRYPTO_AES:
                    _Engine = new AesEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_AESFAST:
                    _Engine = new AesFastEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_AESLIGHT:
                    _Engine = new AesLightEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_BLOWFISH:
                    _Engine = new BlowfishEngine();
                    _MSec.KeySize = 56;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAMELLIA:
                    _Engine = new CamelliaEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAMELLIALIGHT:
                    _Engine = new CamelliaLightEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAST5:
                    _Engine = new Cast5Engine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAST6:
                    _Engine = new Cast6Engine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_DES:
                    _Engine = new DesEngine();
                    _MSec.KeySize = 8;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_DESEDE:
                    _Engine = new DesEdeEngine();
                    _MSec.KeySize = 24;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_GOST28147:
                    _Engine = new Gost28147Engine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_NOEKEON:
                    _Engine = new NoekeonEngine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_NULL:
                    _Engine = new NullEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 16;
                    break;
                case ESec.SCRYPTO_RC2:
                    _Engine = new RC2Engine();
                    _MSec.KeySize = 128;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_RC532:
                    _Engine = new RC532Engine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_RC564:
                    _Engine = new RC564Engine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_RC6:
                    _Engine = new RC6Engine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_RIJNDAEL:
                    _Engine = new RijndaelEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_SEED:
                    _Engine = new SeedEngine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_SERPENT:
                    _Engine = new SerpentEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_SKIPJACK:
                    _Engine = new SkipjackEngine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_TEA:
                    _Engine = new TeaEngine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_TWOFISH:
                    _Engine = new TwofishEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_XTEA:
                    _Engine = new XteaEngine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                default:
                    _Engine = null;
                    _MSec.KeySize = 0;
                    _MSec.IVSize = 0;
                    break;
            }

            switch (_MSec.Mode)
            {
                case ESec.MODE_CBC:
                    _Engine = new CbcBlockCipher(_Engine);
                    break;
                case ESec.MODE_CFB:
                    _Engine = new CfbBlockCipher(_Engine, 8);
                    break;
                case ESec.MODE_GOFB:
                    _Engine = new GOfbBlockCipher(_Engine);
                    break;
                case ESec.MODE_OFB:
                    _Engine = new OfbBlockCipher(_Engine, 8);
                    break;
                case ESec.MODE_OPENPGPCFB:
                    _Engine = new OpenPgpCfbBlockCipher(_Engine);
                    break;
                case ESec.MODE_SIC:
                    _Engine = new SicBlockCipher(_Engine);
                    break;
            }

            IBlockCipherPadding padding = null;
            switch (_MSec.Padding)
            {
                case ESec.PADDING_ISO10126d2:
                    padding = new ISO10126d2Padding();
                    break;
                case ESec.PADDING_ISO7816d4:
                    padding = new ISO7816d4Padding();
                    break;
                case ESec.PADDING_PKCS7:
                    padding = new Pkcs7Padding();
                    break;
                case ESec.PADDING_TBC:
                    padding = new TbcPadding();
                    break;
                case ESec.PADDING_X923:
                    padding = new X923Padding();
                    break;
                case ESec.PADDING_ZEROBYTE:
                    padding = new ZeroBytePadding();
                    break;
            }

            _Cipher = new PaddedBufferedBlockCipher(_Engine, padding);
        }
        #endregion

        private bool EncryptFile(SymmetricAlgorithm alg)
        {
            //Items item;
            //for (int i = 0; i < _AFile.FileList.Count; i += 1)
            //{
            //    item = _AFile.FileList[i];
            //    item.D = item.V + ".bin";
            //    if (!File.Exists(item.K))
            //    {
            //        continue;
            //    }

            //    FileStream iStream = null;
            //    FileStream oStream = null;
            //    try
            //    {
            //        iStream = File.OpenRead(item.K);
            //        oStream = File.OpenWrite(Path.Combine(Path.GetDirectoryName(item.K), item.D));
            //        CryptoStream cStream = new CryptoStream(oStream, alg.CreateEncryptor(), CryptoStreamMode.Write);
            //        byte[] buf = new byte[4096];
            //        int len = iStream.Read(buf, 0, buf.Length);
            //        while (len > 0)
            //        {
            //            cStream.Write(buf, 0, len);
            //            len = iStream.Read(buf, 0, buf.Length);
            //        }
            //        cStream.FlushFinalBlock();
            //    }
            //    catch (Exception exp)
            //    {
            //        Main.ShowError(null, exp);
            //    }
            //    finally
            //    {
            //        if (oStream != null)
            //        {
            //            oStream.Close();
            //        }
            //        if (iStream != null)
            //        {
            //            iStream.Close();
            //        }
            //    }

            //    if (i < _AFile.GvFile.Rows.Count)
            //    {
            //        _AFile.GvFile.Rows[i].Cells[1].Value = item.D;
            //    }
            //}
            return true;
        }

        private bool EncryptText(SymmetricAlgorithm alg)
        {
            //string src = _AText.TbSrc.Text;
            //if (string.IsNullOrEmpty(src))
            //{
            //    return false;
            //}

            //byte[] buf;
            //MemoryStream mStream = new MemoryStream();
            //using (CryptoStream cStream = new CryptoStream(mStream, alg.CreateEncryptor(), CryptoStreamMode.Write))
            //{
            //    buf = Encoding.UTF8.GetBytes(src);
            //    cStream.Write(buf, 0, buf.Length);
            //    cStream.FlushFinalBlock();
            //}
            //buf = mStream.ToArray();
            //_AText.TbDst.Text = CharUtil.EncodeString(buf);
            //mStream.Close();
            return true;
        }
    }
}