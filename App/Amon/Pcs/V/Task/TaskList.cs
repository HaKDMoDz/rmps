using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Pcs.V.Task
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
            foreach (TaskThread thread in threads)
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
            DataGridViewRow row = GvTask.Rows[index];

            var cell = row.Cells[2];
            if (cell != null)
            {
                cell.Value = thread.Message;
            }

            cell = row.Cells[3];
            if (cell != null)
            {
                cell.Value = thread.Progress;
            }
        }

        public void AppendTask(TaskThread thread)
        {
            GvTask.Rows.Add(thread.MetaName, "", thread.Message);
        }

        public void RemoveTask(TaskThread thread, int index)
        {
            GvTask.Rows.RemoveAt(index);
        }
        #endregion

        #region 公共函数
        #endregion

        #region 事件处理
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
        #endregion

        private void GvTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            GvTask.Rows[idx].Selected = true;
        }

        private void GvTask_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                CmMenu.Show(GvTask, e.Location);
            }
        }
    }
}
