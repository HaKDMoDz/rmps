using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class AWiz : UserControl, ISec
    {
        #region 全局变量
        private ASec _ASec;
        private ICrypto _IFile;
        private ICrypto _IText;
        private List<Item> _FileList;
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
            CbDir.Items.Add(new Item { K = "hash", V = "摘要" });
            CbDir.Items.Add(new Item { K = "enc", V = "加密" });
            CbDir.Items.Add(new Item { K = "dec", V = "解密" });
            CbDir.SelectedIndex = 0;
            _FileList = new List<Item>();
        }

        public void InitView()
        {
            Location = new Point(12, 12);
            Size = new Size(356, 207);
            TabIndex = 0;
            _ASec.Controls.Add(this);
            _ASec.ClientSize = new Size(380, 260);
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
        }
        #endregion

        #region 事件处理
        private void CbDir_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Item item = CbDir.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            CbFun.Items.Clear();
            if (item.K == "hash")
            {
                CbFun.Items.Add(new Item { K = "MD5", V = "MD5" });
                CbFun.Items.Add(new Item { K = "SHA1", V = "SHA1" });
                CbFun.Items.Add(new Item { K = "SHA256", V = "SHA256" });
                CbFun.Items.Add(new Item { K = "SHA512", V = "SHA512" });
                CbFun.SelectedIndex = 0;
                return;
            }
            if (item.K == "enc" || item.K == "dec")
            {
                CbFun.Items.Add(new Item { K = "AES", V = "AES" });
                CbFun.Items.Add(new Item { K = "DES", V = "DES" });
                CbFun.Items.Add(new Item { K = "RC4", V = "RC4" });
                CbFun.Items.Add(new Item { K = "RC6", V = "RC6" });
                CbFun.SelectedIndex = 0;
                return;
            }
        }

        private void CbFun_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void CbMod_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
        #endregion

        private void GvFile_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                object obj = e.Data.GetData(DataFormats.FileDrop);
                if (obj == null)
                {
                    return;
                }
                string[] arr = obj as string[];
                if (arr == null)
                {
                    return;
                }

                foreach (string file in arr)
                {
                    if (!File.Exists(file))
                    {
                        continue;
                    }

                    if (GetD(file) != null)
                    {
                        continue;
                    }

                    Item item = new Item { K = file, V = Path.GetFileName(file) };
                    _FileList.Add(item);
                    GvFile.Rows.Add(item.V, "");
                }
            }
            catch (Exception ex)
            {
                Main.ShowError(ex);
            }
        }

        private void GvFile_DragEnter(object sender, DragEventArgs e)
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

        #region 私有函数
        private Item GetD(string file)
        {
            foreach (Item item in _FileList)
            {
                if (item.K == file)
                {
                    return item;
                }
            }
            return null;
        }
        #endregion
    }
}
