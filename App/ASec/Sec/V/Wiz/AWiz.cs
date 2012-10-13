using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Ce;
using Me.Amon.Sec.M;
using Me.Amon.Uc;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class AWiz : UserControl, ISec
    {
        #region 全局变量
        private ASec _ASec;
        private MSec _MSec;
        #endregion

        #region 构造函数
        public AWiz()
        {
            InitializeComponent();
        }

        public AWiz(ASec asec)
        {
            _ASec = asec;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce()
        {
            _MSec = new MSec();

            CbOpt.Items.Add(new Items { K = ESec.OPT_CONFUSE, V = "混淆算法" });
            CbOpt.Items.Add(new Items { K = ESec.OPT_WRAPPER, V = "掩码算法" });
            CbOpt.Items.Add(new Items { K = ESec.OPT_DIGEST, V = "摘要算法" });
            CbOpt.Items.Add(new Items { K = ESec.OPT_SCRYPTO, V = "块对称算法" });
            CbOpt.Items.Add(new Items { K = ESec.OPT_SSTREAM, V = "流对称算法" });
            CbOpt.Items.Add(new Items { K = ESec.OPT_ACRYPTO, V = "非对称算法" });
            CbOpt.SelectedIndex = 0;

            _ASec.ShowTips(PbAlg, "算法选项");

            _ASec.ShowTips(PbKey, "口令选项");

            SbDir.On = true;
            _ASec.ShowTips(SbDir, "加密/解密");

            SetKeyVisible(false);
        }

        public void LoadFav()
        {
        }

        public void SaveFav()
        {
        }

        public void DoCrypto()
        {
            Items opt = CbOpt.SelectedItem as Items;
            if (opt == null)
            {
                MessageBox.Show(_ASec, "请选择您要进行的操作！");
                CbOpt.Focus();
                return;
            }

            string key = "";
            if (TbKey.Visible)
            {
                key = TbKey.Text;
                if (string.IsNullOrEmpty(key))
                {
                    MessageBox.Show(_ASec, "请输入您的口令！");
                    TbKey.Focus();
                    return;
                }
            }

            if (!_UcSrc.CheckInput())
            {
                return;
            }

            if (!_UcDst.CheckInput())
            {
                return;
            }

            switch (opt.K)
            {
                case ESec.OPT_CONFUSE:
                    DoConfuse(key);
                    break;
                case ESec.OPT_WRAPPER:
                    DoWrapper(key);
                    break;
                case ESec.OPT_DIGEST:
                    DoDigest(key);
                    break;
                case ESec.OPT_SCRYPTO:
                    DoScrypto(key);
                    break;
                case ESec.OPT_SSTREAM:
                    DoSstream(key);
                    break;
                case ESec.OPT_ACRYPTO:
                    DoAcrypto(key);
                    break;
                default:
                    return;
            }
        }
        #endregion

        #region 公共函数
        public void ChangeFile(string file)
        {
            _UcSrc.ChangeFile(file);
        }

        public void RemoveSelectedFile()
        {
        }

        /// <summary>
        /// 另存为结果
        /// </summary>
        public void SaveAs()
        {
            SaveAsXml();
        }

        /// <summary>
        /// 从结果加载
        /// </summary>
        public void LoadFrom()
        {
            LoadFromXml();
        }
        #endregion

        #region 事件处理
        private void CbOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            Items item = CbOpt.SelectedItem as Items;
            if (item == null)
            {
                return;
            }

            _MSec.Operation = item.K;
            SetKeyVisible(item.K == ESec.OPT_SCRYPTO || item.K == ESec.OPT_SSTREAM || item.K == ESec.OPT_ACRYPTO);
            SbDir.Visible = (item.K != ESec.OPT_DIGEST);
        }

        private void PbAlg_Click(object sender, EventArgs e)
        {
            UwAlg alg = new UwAlg();
            alg.Init(_MSec);
            alg.ShowDialog(_ASec);
        }

        private void PbKey_Click(object sender, EventArgs e)
        {
            UwKey key = new UwKey();
            key.Init();
            key.ShowDialog(_ASec);
        }

        private void SbDir_Click(object sender, EventArgs e)
        {
            SbDir.On = !SbDir.On;
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            DoCrypto();
        }
        #endregion

        #region 私有函数
        #region 密码处理
        #region 混淆
        private void DoConfuse(string key)
        {
            if (!_UcSrc.Begin())
            {
                return;
            }
            _UcDst.Begin();

            var engine = CreateConfuseEngine();
            engine.Init(SbDir.On, 5, 4);

            char[] src = new char[ESec.BUF_SIZE];
            char[] dst = new char[ESec.BUF_SIZE];

            int len;
            while (true)
            {
                len = _UcSrc.Process(src, 0, src.Length);
                if (len < 1)
                {
                    break;
                }
                len = engine.Process(src, 0, len, dst, 0);
                _UcDst.Append(dst, 0, len);
            }

            len = engine.DoFinal(dst, 0);
            if (len > 0)
            {
                _UcDst.Append(dst, 0, len);
            }

            _UcDst.End();
            _UcSrc.End();
        }

        private ConfuseEngine CreateConfuseEngine()
        {
            return new ConfuseEngine();
        }
        #endregion

        #region 掩码
        private void DoWrapper(string key)
        {
            if (!_UcSrc.Begin())
            {
                return;
            }
            _UcDst.Begin();

            var engine = CreateWrapperEngine();
            engine.Init(SbDir.On, null);

            byte[] src = new byte[ESec.BUF_SIZE];
            char[] dst = new char[ESec.BUF_SIZE << 3];

            int len;
            while (true)
            {
                len = _UcSrc.Process(src, 0, src.Length);
                if (len < 1)
                {
                    break;
                }
                len = engine.Encode(src, 0, len, dst, 0);
                _UcDst.Append(dst, 0, len);
            }

            len = engine.DoFinal(dst, 0);
            if (len > 0)
            {
                _UcDst.Append(dst, 0, len);
            }

            _UcDst.End();
            _UcSrc.End();
        }

        private WrapperEngine CreateWrapperEngine()
        {
            return new WrapperEngine();
        }
        #endregion

        #region 摘要
        private void DoDigest(string key)
        {
            if (!_UcSrc.Begin())
            {
                return;
            }
            _UcDst.Begin();

            var engine = CreateDigestEngine();

            byte[] src = new byte[ESec.BUF_SIZE];

            int len;
            while (true)
            {
                len = _UcSrc.Process(src, 0, src.Length);
                if (len < 1)
                {
                    break;
                }
                engine.BlockUpdate(src, 0, len);
            }

            len = engine.DoFinal(src, 0);
            if (len > 0)
            {
                char[] dst = new char[len << 1];
                len = EncodeBytes(src, 0, len, dst, 0);
                _UcDst.Append(dst, 0, len);
            }

            _UcDst.End();
            _UcSrc.End();
        }

        private IDigest CreateDigestEngine()
        {
            switch (_MSec.Algorithm)
            {
                case ESec.DIGEST_GOST3411:
                    return new Gost3411Digest();
                case ESec.DIGEST_MD2:
                    return new MD2Digest();
                case ESec.DIGEST_MD4:
                    return new MD4Digest();
                case ESec.DIGEST_MD5:
                    return new MD5Digest();
                case ESec.DIGEST_NULL:
                    return new NullDigest();
                case ESec.DIGEST_RIPEMD128:
                    return new RipeMD128Digest();
                case ESec.DIGEST_RIPEMD160:
                    return new RipeMD160Digest();
                case ESec.DIGEST_RIPEMD256:
                    return new RipeMD256Digest();
                case ESec.DIGEST_RIPEMD320:
                    return new RipeMD320Digest();
                case ESec.DIGEST_SHA1:
                    return new Sha1Digest();
                case ESec.DIGEST_SHA224:
                    return new Sha224Digest();
                case ESec.DIGEST_SHA256:
                    return new Sha256Digest();
                case ESec.DIGEST_SHA384:
                    return new Sha384Digest();
                case ESec.DIGEST_SHA512:
                    return new Sha512Digest();
                case ESec.DIGEST_TIGER:
                    return new TigerDigest();
                case ESec.DIGEST_WHIRLPOOL:
                    return new WhirlpoolDigest();
                default:
                    return new MD5Digest();
            }
        }
        #endregion

        #region 块对称加密
        private void DoScrypto(string key)
        {
            if (!_UcSrc.Begin())
            {
                return;
            }
            _UcDst.Begin();

            key = GenPass(key, _MSec.KeySize);
            BufferedBlockCipher engine = CreateScryptoEngine();
            engine.Init(SbDir.On, new KeyParameter(Encoding.Default.GetBytes(key)));

            byte[] src = new byte[ESec.BUF_SIZE];
            byte[] dst = new byte[ESec.BUF_SIZE];
            char[] tmp = new char[dst.Length << 1];

            int len;
            while (true)
            {
                len = _UcSrc.Process(src, 0, src.Length);
                if (len < 1)
                {
                    break;
                }
                len = engine.ProcessBytes(src, 0, len, dst, 0);
                len = EncodeBytes(dst, 0, len, tmp, 0);
                _UcDst.Append(tmp, 0, len);
            }

            len = engine.DoFinal(dst, 0);
            if (len > 0)
            {
                len = EncodeBytes(dst, 0, len, tmp, 0);
                _UcDst.Append(tmp, 0, len);
            }

            _UcDst.End();
            _UcSrc.End();
        }

        private BufferedBlockCipher CreateScryptoEngine()
        {
            IBlockCipher engine;
            switch (_MSec.Algorithm)
            {
                case ESec.SCRYPTO_AES:
                    engine = new AesEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_AESFAST:
                    engine = new AesFastEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_AESLIGHT:
                    engine = new AesLightEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_BLOWFISH:
                    engine = new BlowfishEngine();
                    _MSec.KeySize = 56;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAMELLIA:
                    engine = new CamelliaEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAMELLIALIGHT:
                    engine = new CamelliaLightEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAST5:
                    engine = new Cast5Engine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAST6:
                    engine = new Cast6Engine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_DES:
                    engine = new DesEngine();
                    _MSec.KeySize = 8;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_DESEDE:
                    engine = new DesEdeEngine();
                    _MSec.KeySize = 24;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_GOST28147:
                    engine = new Gost28147Engine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_NOEKEON:
                    engine = new NoekeonEngine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_NULL:
                    engine = new NullEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 16;
                    break;
                case ESec.SCRYPTO_RC2:
                    engine = new RC2Engine();
                    _MSec.KeySize = 128;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_RC532:
                    engine = new RC532Engine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_RC564:
                    engine = new RC564Engine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_RC6:
                    engine = new RC6Engine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_RIJNDAEL:
                    engine = new RijndaelEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_SEED:
                    engine = new SeedEngine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_SERPENT:
                    engine = new SerpentEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_SKIPJACK:
                    engine = new SkipjackEngine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_TEA:
                    engine = new TeaEngine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_TWOFISH:
                    engine = new TwofishEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SCRYPTO_XTEA:
                    engine = new XteaEngine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 0;
                    break;
                default:
                    engine = new AesEngine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 0;
                    break;
            }

            switch (_MSec.Mode)
            {
                case ESec.MODE_CBC:
                    engine = new CbcBlockCipher(engine);
                    break;
                case ESec.MODE_CFB:
                    engine = new CfbBlockCipher(engine, 8);
                    break;
                case ESec.MODE_GOFB:
                    engine = new GOfbBlockCipher(engine);
                    break;
                case ESec.MODE_OFB:
                    engine = new OfbBlockCipher(engine, 8);
                    break;
                case ESec.MODE_OPENPGPCFB:
                    engine = new OpenPgpCfbBlockCipher(engine);
                    break;
                case ESec.MODE_SIC:
                    engine = new SicBlockCipher(engine);
                    break;
                default:
                    engine = new CbcBlockCipher(engine);
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
                default:
                    padding = new Pkcs7Padding();
                    break;
            }

            return new PaddedBufferedBlockCipher(engine, padding);
        }
        #endregion

        #region 流对称加密
        private void DoSstream(string key)
        {
            if (!_UcSrc.Begin())
            {
                return;
            }
            _UcDst.Begin();

            key = GenPass(key, _MSec.KeySize);
            BufferedStreamCipher engine = CreateSstreamEngine();
            engine.Init(SbDir.On, new KeyParameter(Encoding.Default.GetBytes(key)));

            byte[] src = new byte[ESec.BUF_SIZE];
            byte[] dst = new byte[ESec.BUF_SIZE];
            char[] tmp = new char[dst.Length << 1];

            int len;
            while (true)
            {
                len = _UcSrc.Process(src, 0, src.Length);
                if (len < 1)
                {
                    break;
                }
                len = engine.ProcessBytes(src, 0, len, dst, 0);
                len = EncodeBytes(dst, 0, len, tmp, 0);
                _UcDst.Append(tmp, 0, len);
            }

            len = engine.DoFinal(dst, 0);
            if (len > 0)
            {
                len = EncodeBytes(dst, 0, len, tmp, 0);
                _UcDst.Append(tmp, 0, len);
            }

            _UcDst.End();
            _UcSrc.End();
        }

        private BufferedStreamCipher CreateSstreamEngine()
        {
            IStreamCipher engine;
            switch (_MSec.Algorithm)
            {
                case ESec.SSTREAM_HC128:
                    engine = new HC128Engine();
                    _MSec.KeySize = 16;//128
                    _MSec.IVSize = 16;
                    break;
                case ESec.SSTREAM_HC256:
                    engine = new HC256Engine();
                    _MSec.KeySize = 32;
                    _MSec.IVSize = 16;
                    break;
                case ESec.SSTREAM_ISAAC:
                    engine = new IsaacEngine();
                    _MSec.KeySize = 10;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SSTREAM_RC4:
                    engine = new RC4Engine();
                    _MSec.KeySize = 10;
                    _MSec.IVSize = 0;
                    break;
                case ESec.SSTREAM_SALSA20:
                    engine = new Salsa20Engine();
                    _MSec.KeySize = 16;
                    _MSec.IVSize = 8;
                    break;
                case ESec.SSTREAM_VMPC:
                    engine = new VmpcEngine();
                    _MSec.KeySize = 10;
                    _MSec.IVSize = 16;
                    break;
                case ESec.SSTREAM_VMPCKSA3:
                    engine = new VmpcKsa3Engine();
                    _MSec.KeySize = 10;
                    _MSec.IVSize = 16;
                    break;
                default:
                    engine = null;
                    _MSec.KeySize = 0;
                    _MSec.IVSize = 0;
                    break;
            }

            return new BufferedStreamCipher(engine);
        }
        #endregion

        #region 非对称加密
        private void DoAcrypto(string key)
        {
        }

        private void CreateAcryptoEngine()
        {
            IAsymmetricBlockCipher engine;
            switch (_MSec.Algorithm)
            {
                case ESec.ACRYPTO_ELGAMAL:
                    engine = new ElGamalEngine();
                    break;
                case ESec.ACRYPTO_NACCACHESTERN:
                    engine = new NaccacheSternEngine();
                    break;
                case ESec.ACRYPTO_RSABLINDED:
                    engine = new RsaBlindedEngine();
                    break;
                case ESec.ACRYPTO_RSABLINDING:
                    engine = new RsaBlindingEngine();
                    break;
                case ESec.ACRYPTO_RSA:
                    engine = new RsaEngine();
                    break;
            }
        }
        #endregion

        private static string GenPass(string data, int length)
        {
            StringBuilder buf = new StringBuilder(data);
            for (int i = buf.Length, j = length; i < j; i += 1)
            {
                buf.Append(' ');
            }
            return buf.ToString();
        }

        private static int EncodeBytes(byte[] input, int srcFrom, int length, char[] output, int dstFrom)
        {
            char[] code = "0123456789ABCDEF".ToCharArray();
            int t = dstFrom;
            byte tmp;

            length += srcFrom;
            while (srcFrom < length)
            {
                tmp = input[srcFrom++];
                output[t++] = code[(tmp >> 4) & 0xF];
                output[t++] = code[tmp & 0xF];
            }
            return t - dstFrom;
        }
        #endregion

        private void WriteHeader(Stream stream)
        {
            string tmp = "ASec:1";
            byte[] buf = Encoding.UTF8.GetBytes(tmp);
            stream.Write(buf, 0, buf.Length);

            tmp = GetHeader();
            buf = Encoding.UTF8.GetBytes(tmp);
            stream.WriteByte((byte)buf.Length);
            stream.Write(buf, 0, buf.Length);
        }

        private void ReadHeader(Stream stream)
        {
            byte[] buf = new byte[1024];
            int len = stream.Read(buf, 0, 6);

            string tmp = Encoding.UTF8.GetString(buf, 0, len);
            if ("ASec:1" != tmp)
            {
                return;
            }

            len = stream.Read(buf, 0, buf[5]);
            tmp = Encoding.UTF8.GetString(buf, 0, len);
        }

        private string GetHeader()
        {
            // ASec:程序
            // 1:加密版本
            // int:头大小
            // AES:算法
            // BlockSize:块大小
            // Salt:随机向量
            return "";
        }

        private void DddHeader(string tmp)
        {
            string[] arr = tmp.Split(':');
            if (arr.Length != 3)
            {
                // 错误
                return;
            }
            string alg = arr[0];
            int block = int.Parse(arr[1]);
            string salt = arr[2];
        }

        /// <summary>
        /// 单独保存加密结果
        /// </summary>
        private void SaveAsXml()
        {
            XmlWriter writer = XmlWriter.Create("");


            writer.Close();
        }

        /// <summary>
        /// 从外部加载配置
        /// </summary>
        private void LoadFromXml()
        {
            XmlReader reader = XmlReader.Create("");
            _MSec.FromXml(reader);
            CbOpt.SelectedItem = new Items { K = _MSec.Operation };
            reader.Close();
        }

        private void SetKeyVisible(bool visible)
        {
            LlKey.Visible = visible;
            TbKey.Visible = visible;
            PbKey.Visible = visible;
        }
        #endregion
    }
}
