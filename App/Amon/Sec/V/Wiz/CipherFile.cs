using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class CipherFile : UserControl, IView
    {
        private List<Item> _FileList = new List<Item>();

        #region 构造函数
        public CipherFile()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }
        #endregion

        #region 事件处理
        private void GvFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

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
        #endregion

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
    }
}
