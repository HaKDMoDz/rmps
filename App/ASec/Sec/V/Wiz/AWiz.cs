using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class AWiz : UserControl, ISec
    {
        private string _Alg;
        private int _BlockSize;
        private byte[] _Salt;
        private char[] _Mask;
        #region 全局变量
        private ASec _ASec;
        private ICrypto _Crypto;
        private Encode _Encode;
        private Decode _Decode;
        private Digest _Digest;
        #endregion

        #region 构造函数
        public AWiz()
        {
            InitializeComponent();
        }

        public AWiz(ASec asec)
        {
            InitializeComponent();

            _ASec = asec;
        }
        #endregion

        #region 接口实现
        public void InitOnce()
        {
            //_Digest = new Digest(UcFile, UcText);
            //_Encode = new Encode(UcFile, UcText);
            //_Decode = new Decode(UcFile, UcText);

            CbDir.Items.Add(new Items { K = "hash", V = "摘要" });
            CbDir.Items.Add(new Items { K = "enc", V = "加密" });
            CbDir.Items.Add(new Items { K = "dec", V = "解密" });
            CbDir.SelectedIndex = 0;
        }

        public void InitView()
        {
            Location = new Point(10, 10);
            Size = new Size(546, 296);
            TabIndex = 0;
            _ASec.Controls.Add(this);
            _ASec.ClientSize = new Size(564, 344);
        }

        public void HideView()
        {
            _ASec.Controls.Remove(this);
        }

        public void LoadFav()
        {
        }

        public void SaveFav()
        {
        }

        public void DoCrypto()
        {
            Items opt = CbDir.SelectedItem as Items;
            if (opt == null)
            {
                MessageBox.Show(this, "请选择您要进行的操作！");
                CbDir.Focus();
                return;
            }

            if (TcSrc.SelectedTab == TpSrcText)
            {
                string text = TbSrcText.Text;
                if (string.IsNullOrEmpty(text))
                {
                    MessageBox.Show(this, "请输入您要处理的文本！");
                    TbSrcText.Focus();
                    return;
                }
            }
            else if (TcSrc.SelectedTab == TpSrcFile)
            {
                if (LbSrcFile.Items.Count < 1)
                {
                    MessageBox.Show(this, "请选择您要处理的文件！");
                    LbSrcFile.Focus();
                    return;
                }
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

            //string pass = "";

            //if (TbPass.Enabled)
            //{
            //    pass = TbPass.Text;
            //    if (string.IsNullOrEmpty(pass))
            //    {
            //        Main.ShowAlert("请输入您的密码！");
            //        TbPass.Focus();
            //    }
            //}

            //_Crypto.IsText = TcCrypto.SelectedIndex == 1;
            //if (_Crypto.DoCrypto(pass))
            //{
            //    _ASec.ShowEcho("处理完成！");
            //}
            //else
            //{
            //    _ASec.ShowEcho("处理失败！");
            //}
        }
        #endregion

        #region 公共函数
        public void AppendFiles(string[] files)
        {
            foreach (string file in files)
            {
                if (Exists(file))
                {
                    continue;
                }
                LbSrcFile.Items.Add(new Items { K = file, V = Path.GetFileName(file) });
            }
        }

        public void RemoveSelectedFile()
        {
            var idx = LbSrcFile.SelectedIndex;
            if (idx < 0)
            {
                return;
            }
            LbSrcFile.Items.RemoveAt(idx);
            if (idx == LbSrcFile.Items.Count)
            {
                idx -= 1;
            }
            if (idx > 0)
            {
                LbSrcFile.SelectedIndex = idx;
            }
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

        }

        private void PbAlg_Click(object sender, EventArgs e)
        {

        }

        private void PbIUdc_Click(object sender, EventArgs e)
        {

        }

        private void PbKey_Click(object sender, EventArgs e)
        {

        }

        private void PbOUdc_Click(object sender, EventArgs e)
        {

        }

        private void TcSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            PbSrcPath.Visible = TcSrc.SelectedTab == TpSrcFile;
        }

        private void PbSrcPath_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != Main.ShowOpenFileDialog(null, CApp.FILE_OPEN_ALL, null, true))
            {
                return;
            }
            AppendFiles(Main.OpenFileDialog.FileNames);
        }

        private void LbSrcFile_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void LbSrcFile_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void TbSrcText_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void TbSrcText_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void TcDst_SelectedIndexChanged(object sender, EventArgs e)
        {
            PbDstPath.Visible = TcDst.SelectedTab == TpDstFile;
        }

        private void PbDstPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdOpen = new OpenFileDialog();
            fdOpen.ShowDialog();
            AppendFiles(fdOpen.FileNames);
        }

        private void LbDstFile_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void LbDstFile_DragDrop(object sender, DragEventArgs e)
        {

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
        private void Encode()
        {
        }

        private void Decode()
        {
        }

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

        private bool Exists(string file)
        {
            foreach (Items item in LbSrcFile.Items)
            {
                if (file == item.K)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 单独保存加密结果
        /// </summary>
        private void SaveAsXml()
        {
            XmlWriter writer = XmlWriter.Create("");

            // 算法
            writer.WriteElementString("Alg", _Alg);
            // 块大小
            writer.WriteElementString("BlockSize", _BlockSize.ToString());
            // 随机向量
            writer.WriteElementString("Salt", "");
            // 掩码文本
            writer.WriteElementString("Mask", "");
            // 文件摘要
            writer.WriteElementString("Hash", FileHash(""));

            writer.Close();
        }

        /// <summary>
        /// 从外部加载配置
        /// </summary>
        private void LoadFromXml()
        {
            XmlReader reader = XmlReader.Create("");

            _Alg = reader.ReadElementContentAsString();
            CbDir.SelectedItem = new Items { K = _Alg };

            _BlockSize = reader.ReadElementContentAsInt();

            string salt = reader.ReadElementContentAsString();
            _Salt = null;

            string mask = reader.ReadElementContentAsString();
            _Mask = null;

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
