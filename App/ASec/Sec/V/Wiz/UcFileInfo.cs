using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Api.Structures;
using Me.Amon.Api.User32;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class UcFileInfo : UserControl
    {
        public UcFileInfo()
        {
            InitializeComponent();
        }

        public string UserFile { get; set; }

        public void ShowFileInfo(string file)
        {
            SHFILEINFO shInfo = User32.GetFileInfo(file, false);
            PbIcon.Image = Icon.FromHandle(shInfo.hIcon).ToBitmap();

            TbName.Text = shInfo.szDisplayName;
            TbType.Text = shInfo.szTypeName;

            FileInfo info = new FileInfo(file);
            TbPath.Text = info.DirectoryName;

            long len = info.Length;
            StringBuilder builder = new StringBuilder();
            if (len >= 1073741824)
            {
                builder.Append(info.Length / 1073741824);
                builder.Append("GB");
            }
            else if (len >= 1048576)
            {
                builder.Append(info.Length / 1048576);
                builder.Append("MB");
            }
            else if (len >= 1024)
            {
                builder.Append(info.Length / 1024);
                builder.Append("KB");
            }
            else
            {
                builder.Append(info.Length);
                builder.Append("B");
            }
            TbSize.Text = builder.Append('（').Append(len).Append("字节）").ToString();

            DateTime time = info.CreationTime;
            TbCreateTime.Text = time.ToLongDateString() + ' ' + time.ToLongTimeString();
            time = info.LastWriteTime;
            TbModifyTime.Text = time.ToLongDateString() + ' ' + time.ToLongTimeString();
            time = info.LastAccessTime;
            TbAccessTime.Text = time.ToLongDateString() + ' ' + time.ToLongTimeString();
        }
    }
}
