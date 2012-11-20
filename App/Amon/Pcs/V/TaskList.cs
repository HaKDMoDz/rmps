using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pcs.C;

namespace Me.Amon.Pcs.V
{
    public partial class TaskList : UserControl, ITaskViewer
    {
        private StringFormat _Format;
        private Color _ProgressBackColor;
        private Brush _ProgressBackBrush;
        private Color _ProgressForeColor;
        private Brush _ProgressForeBrush;

        public TaskList()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        public void Init()
        {
            ProgressBackColor = Color.Green;
            ProgressForeColor = Color.Black;

            _Format = new StringFormat();
            _Format.Alignment = StringAlignment.Center;
            _Format.LineAlignment = StringAlignment.Center;
            _Format.Trimming = StringTrimming.EllipsisCharacter;
        }

        public Color ProgressBackColor
        {
            get
            {
                return _ProgressBackColor;
            }
            set
            {
                _ProgressBackColor = value;
                _ProgressBackBrush = new SolidBrush(value);
            }
        }

        public Color ProgressForeColor
        {
            get
            {
                return _ProgressForeColor;
            }
            set
            {
                _ProgressForeColor = value;
                _ProgressForeBrush = new SolidBrush(value);
            }
        }

        public void LoadTask()
        {
        }

        public void SaveTask()
        {
            //removetpath=status
        }

        #region 接口实现
        public void ShowTask(List<TaskThread> threads)
        {
            foreach (var thread in threads)
            {
                GvTask.Rows.Add(thread.MetaName, "", thread.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thread"></param>
        public void UpdateTask(TaskThread thread, int index)
        {
            if (GvTask.Rows.Count < 1)
            {
                return;
            }
            var cell = GvTask[2, index];
            if (cell == null)
            {
                return;
            }
            cell.Value = thread.Message;

            cell = GvTask[3, index] as DataGridViewImageCell;
            if (cell == null)
            {
                return;
            }
            cell.Value = GenProgress(thread, cell.Size, cell.Value as Image);
        }

        public void AppendTask(TaskThread thread)
        {
            GvTask.Rows.Add(thread.MetaName, "", thread.Message);
        }

        public void RemoveTask(TaskThread thread)
        {
        }
        #endregion

        #region 公共函数
        #endregion

        #region 事件处理
        private void BwWork_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void LvTask_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        private void MiSuspend_Click(object sender, System.EventArgs e)
        {
            //var item = GetSelectedItem();
            //if (item == null)
            //{
            //    return;
            //}
            //var thread = item.Tag as TaskThread;
            //if (thread == null)
            //{
            //    return;
            //}
            //thread.Status = 1;
            //thread.StatusItem.Text = "处理中";
        }

        private void MiContinue_Click(object sender, System.EventArgs e)
        {
            //var item = GetSelectedItem();
            //if (item == null)
            //{
            //    return;
            //}
            //var thread = item.Tag as TaskThread;
            //if (thread == null)
            //{
            //    return;
            //}
            //thread.Status = 1;
            //thread.StatusItem.Text = "等待中";
        }

        private void MiCancel_Click(object sender, System.EventArgs e)
        {
            //var item = GetSelectedItem();
            //if (item == null)
            //{
            //    return;
            //}
            //var thread = item.Tag as TaskThread;
            //if (thread == null)
            //{
            //    return;
            //}
            //thread.Status = 1;
            //thread.StatusItem.Text = "处理中";
        }

        private void 优先处理ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void 延后处理ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region 私有函数
        private Image GenProgress(TaskThread thread, Size size, Image image)
        {
            if (size.Width < 1 || size.Height < 1)
            {
                return null;
            }
            if (image == null || image.Width != size.Width)
            {
                image = new Bitmap(size.Width, size.Height);
            }

            double rate = thread.Progress;
            using (Graphics g = Graphics.FromImage(image))
            {
                g.FillRectangle(Brushes.White, 0, 0, image.Width, image.Height);

                int x = 1;
                int y = 1;
                if (rate > 0)
                {
                    int width = (int)(image.Width * rate);
                    g.FillRectangle(_ProgressBackBrush, x, y, width - 4, image.Height - 4);
                }
                g.DrawRectangle(Pens.RoyalBlue, x, y, image.Width - 4, image.Height - 4);
                x += image.Width >> 1;
                y += image.Height >> 1;
                g.DrawString(rate.ToString("p1"), Font, _ProgressForeBrush, x, y, _Format);
                g.Save();
            }
            return image;
        }
        #endregion
    }
}
