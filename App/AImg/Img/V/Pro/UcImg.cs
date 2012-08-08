using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Me.Amon.Img.V.Pro
{
    public partial class UcImg : UserControl
    {
        private APro _APro;

        public UcImg()
        {
            InitializeComponent();
        }

        public UcImg(APro apro)
        {
            _APro = apro;

            InitializeComponent();
        }

        public void Open(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return;
            }

            _APro.SrcImage = Image.FromFile(path);
            Image = _APro.SrcImage;
        }

        public Image Image
        {
            get
            {
                return PbImg.Image;
            }
            set
            {
                PbImg.Width = value.Width;
                PbImg.Height = value.Height;
                PbImg.Image = value;
                ReLayout();
            }
        }

        #region 事件处理
        private void UcImg_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void UcImg_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                object obj = e.Data.GetData(DataFormats.FileDrop);
                if (obj == null)
                {
                    return;
                }
                string[] arr = obj as string[];
                if (arr != null && arr.Length > 0)
                {
                    Open(arr[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcImg_Resize(object sender, EventArgs e)
        {
            ReLayout();
        }

        private void PbImg_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void ReLayout()
        {
            PbImg.Location = new Point((this.Width - PbImg.Width) >> 1, (this.Height - PbImg.Height) >> 1);
        }
    }
}
