using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Sec.M;
using Me.Amon.Uc;

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
            //_Digest = new Digest(UcFile, UcText);
            //_Encode = new Encode(UcFile, UcText);
            //_Decode = new Decode(UcFile, UcText);
            System.Security.Cryptography.SymmetricAlgorithm d;

            CbOpt.Items.Add(new Items { K = ESec.OPT_CONFUSE, V = "混淆算法" });
            CbOpt.Items.Add(new Items { K = ESec.OPT_WRAPPER, V = "掩码算法" });
            CbOpt.Items.Add(new Items { K = ESec.OPT_DIGEST, V = "摘要算法" });
            CbOpt.Items.Add(new Items { K = ESec.OPT_SCRYPTO, V = "块对称算法" });
            CbOpt.Items.Add(new Items { K = ESec.OPT_SSTREAM, V = "流对称算法" });
            CbOpt.Items.Add(new Items { K = ESec.OPT_ACRYPTO, V = "非对称算法" });
            CbOpt.SelectedIndex = 0;

            _ASec.ShowTips(PbOpt, "算法选项");
            _ASec.ShowTips(PbKey, "口令选项");
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
                MessageBox.Show(this, "请选择您要进行的操作！");
                CbOpt.Focus();
                return;
            }

            if (TbKey.Visible)
            {
                string key = TbKey.Text;
                if (string.IsNullOrEmpty(key))
                {
                    MessageBox.Show(this, "请输入您的口令！");
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
                    DoConfuse();
                    break;
                case ESec.OPT_WRAPPER:
                    DoWrapper();
                    break;
                case ESec.OPT_DIGEST:
                    DoDigest();
                    break;
                case ESec.OPT_SCRYPTO:
                    DoScrypto();
                    break;
                case ESec.OPT_SSTREAM:
                    DoSstream();
                    break;
                case ESec.OPT_ACRYPTO:
                    DoAcrypto();
                    break;
                default:
                    return;
            }
        }
        #endregion

        #region 公共函数
        public void AppendFiles(string[] files)
        {
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
        private void CbDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            Items item = CbOpt.SelectedItem as Items;
            if (item == null)
            {
                return;
            }

            bool b = item.K == ESec.OPT_SCRYPTO || item.K == ESec.OPT_SSTREAM || item.K == ESec.OPT_ACRYPTO;
            LlKey.Visible = b;
            TbKey.Visible = b;
            PbKey.Visible = b;
        }

        private void PbAlg_Click(object sender, EventArgs e)
        {
            UwAlg alg = new UwAlg();
            alg.Init();
            alg.ShowDialog(_ASec);
        }

        private void PbKey_Click(object sender, EventArgs e)
        {
            UwKey key = new UwKey();
            key.Init();
            key.ShowDialog(_ASec);
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {

        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            DoCrypto();
        }
        #endregion

        #region 私有函数
        #region 密码处理
        private Confuse _Confuse;
        private void DoConfuse()
        {
            if (_Confuse == null)
            {
                _Confuse = new Confuse();
            }
            _Confuse.Init(_MSec);

            _UcSrc.Begin();
            _UcDst.Begin();

            char[] buf = new char[ESec.BUF_SIZE];

            int len = _UcSrc.Process(buf, 0, buf.Length);
            while (len > 0)
            {
                _UcDst.Append(buf, 0, len);
                len = _UcSrc.Process(buf, 0, buf.Length);
            }

            _UcDst.End();
            _UcSrc.End();
        }

        private Wrapper _Wrapper;
        private void DoWrapper()
        {
            if (_Wrapper == null)
            {
                _Wrapper = new Wrapper();
            }
            _Wrapper.Init(_MSec);
        }

        private Digest _Digest;
        private void DoDigest()
        {
            if (_Digest == null)
            {
                _Digest = new Digest();
            }
            _Digest.Init(_MSec);
        }

        private Scrypto _Scrypto;
        private void DoScrypto()
        {
            if (_Scrypto == null)
            {
                _Scrypto = new Scrypto();
            }
            _Scrypto.Init(_MSec);
        }

        private Sstream _Sstream;
        private void DoSstream()
        {
            if (_Sstream == null)
            {
                _Sstream = new Sstream();
            }
            _Sstream.Init(_MSec);
        }

        private Acrypto _Acrypto;
        private void DoAcrypto()
        {
            if (_Acrypto == null)
            {
                _Acrypto = new Acrypto();
            }
            _Acrypto.Init(_MSec);
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

        private string FileHash(string file)
        {
            FileStream stream = File.OpenRead(file);
            HashAlgorithm alg = HashAlgorithm.Create("");
            byte[] buf = alg.ComputeHash(stream);
            stream.Close();
            return "";
        }
        #endregion
    }
}
