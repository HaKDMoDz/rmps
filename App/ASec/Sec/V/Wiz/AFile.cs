using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class AFile : UserControl
    {
        private ASec _ASec;
        public List<Items> FileList = new List<Items>();

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
            if (DialogResult.OK != Main.ShowOpenFileDialog(_ASec, CApp.FILE_OPEN_ALL, "", true))
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
            if (row.Index < 0)
            {
                return;
            }
            FileList.RemoveAt(row.Index);
            GvFile.Rows.Remove(row);
        }

        private void MiClearAllFile_Click(object sender, EventArgs e)
        {
            FileList.Clear();
            GvFile.Rows.Clear();
        }

        private void MiCopy_Click(object sender, EventArgs e)
        {
            if (GvFile.SelectedRows.Count < 1)
            {
                return;
            }

            DataGridViewRow row = GvFile.SelectedRows[0];
            if (row.Index < 0)
            {
                return;
            }

            Items item = FileList[row.Index];
            if (item != null)
            {
                if (!string.IsNullOrEmpty(item.D))
                {
                    Clipboard.SetText(item.D);
                }
            }
        }

        private void MiOpen_Click(object sender, EventArgs e)
        {
            if (GvFile.SelectedRows.Count < 1)
            {
                return;
            }

            DataGridViewRow row = GvFile.SelectedRows[0];
            if (row.Index < 0)
            {
                return;
            }

            Items item = FileList[row.Index];
            if (item != null)
            {
                try
                {
                    Process.Start(Directory.GetParent(item.K).FullName);
                }
                catch (Exception exp)
                {
                    Main.ShowError(exp);
                }
            }
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

                Items item = new Items { K = file, V = Path.GetFileName(file) };
                FileList.Add(item);
                GvFile.Rows.Add(item);
            }
        }

        private Items GetDup(string file)
        {
            foreach (Items item in FileList)
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
