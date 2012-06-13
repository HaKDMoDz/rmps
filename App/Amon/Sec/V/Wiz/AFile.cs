using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class AFile : UserControl
    {
        private ASec _ASec;
        public List<Item> FileList = new List<Item>();

        public AFile()
        {
            InitializeComponent();

            GvFile.AutoGenerateColumns = false;
        }

        #region 事件处理
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

                AddFiles(arr);
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

        private void GvFile_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            if (e.RowIndex > -1 && e.RowIndex < GvFile.Rows.Count)
            {
                GvFile.Rows[e.RowIndex].Selected = true;
            }
            CmMenu.Show(MousePosition);
        }

        private void MiAppendFile_Click(object sender, EventArgs e)
        {
            Main.OpenFileDialog.Filter = EApp.FILE_OPEN_ALL;
            Main.OpenFileDialog.Multiselect = true;
            if (DialogResult.OK != Main.OpenFileDialog.ShowDialog())
            {
                return;
            }

            AddFiles(Main.OpenFileDialog.FileNames);
        }

        private void MiRemoveFile_Click(object sender, EventArgs e)
        {
            if (GvFile.SelectedRows.Count < 1)
            {
                return;
            }

            DataGridViewRow row = GvFile.SelectedRows[0];
            GvFile.Rows.Remove(row);
            FileList.RemoveAt(row.Index);
        }
        #endregion

        #region 私有函数
        private void AddFiles(string[] files)
        {
            if (files == null)
            {
                return;
            }

            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    continue;
                }

                if (GetDup(file) != null)
                {
                    continue;
                }

                Item item = new Item { K = file, V = Path.GetFileName(file) };
                FileList.Add(item);
                GvFile.Rows.Add(item);
            }
        }

        private Item GetDup(string file)
        {
            foreach (Item item in FileList)
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
