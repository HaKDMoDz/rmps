using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class UcDst : UserControl
    {
        private ASec _ASec;
        private TextWriter _Writer;

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
            _ASec.ShowTips(PbFile, "选择输出目录");
        }

        public bool CheckInput()
        {
            return true;
        }

        private StringBuilder _Builder;
        public void Begin()
        {
            if (TcDst.SelectedTab == TpText)
            {
                _Builder = new StringBuilder();
                _Writer = new StringWriter(_Builder);
                return;
            }

            if (TcDst.SelectedTab == TpFile)
            {
                _Writer = new StreamWriter("");
            }
        }

        public void Append(byte[] buffer, int offset, int length)
        {
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
                TbText.Text = _Builder.ToString();
                return;
            }
        }
        #endregion

        #region 事件处理
        private void TcDst_SelectedIndexChanged(object sender, EventArgs e)
        {
            PbFile.Visible = TcDst.SelectedTab == TpFile;
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
