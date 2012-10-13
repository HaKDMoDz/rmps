using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class UcDst : UserControl
    {
        private ASec _ASec;
        private BinaryWriter _Writer;
        private MemoryStream _Stream;

        #region 构造函数
        public UcDst()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共函数
        public void InitView(ASec asec)
        {
            _ASec = asec;

            _ASec.ShowTips(PbMask, "选择掩码");
        }

        public void ChangeOpt(string opt)
        {
            bool b = opt == ESec.OPT_SCRYPTO || opt == ESec.OPT_SSTREAM || opt == ESec.OPT_ACRYPTO;
            PbMask.Visible = b;
        }

        public void ChangeDir(bool encrypt)
        {
        }

        public bool CheckInput()
        {
            return true;
        }

        public bool Begin()
        {
            if (TcDst.SelectedTab == TpText)
            {
                _Stream = new MemoryStream();
                _Writer = new BinaryWriter(_Stream);
                return true;
            }

            if (TcDst.SelectedTab == TpFile)
            {
                if (string.IsNullOrEmpty(LbFile.UserFile) || !File.Exists(LbFile.UserFile))
                {
                    MessageBox.Show("请选择输出文件！");
                    return false;
                }
                _Writer = new BinaryWriter(File.OpenWrite(LbFile.UserFile));
                return true;
            }
            return false;
        }

        public void Append(byte[] buffer, int offset, int length)
        {
            _Writer.Write(buffer, offset, length);
        }

        public void Append(char[] buffer, int offset, int length)
        {
            _Writer.Write(buffer, offset, length);
        }

        public void End()
        {
            _Writer.Flush();
            _Writer.Close();

            if (TcDst.SelectedTab == TpText)
            {
                _Stream.Close();
                TbText.Text = Encoding.UTF8.GetString(_Stream.ToArray());
                return;
            }
        }
        #endregion

        #region 事件处理
        private void TcDst_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void PbMask_Click(object sender, EventArgs e)
        {

        }

        private void PbFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdOpen = new FolderBrowserDialog();
            fdOpen.Description = "请选择文件输出目录：";
            if (DialogResult.OK != fdOpen.ShowDialog())
            {
                return;
            }
            //AppendFiles(fdOpen.SelectedPath);
        }
        #endregion
    }
}
