using System.ComponentModel;
using System.Windows.Forms;
using Me.Amon.Open;
using Me.Amon.Pcs.C;

namespace Me.Amon.Pcs.V
{
    public partial class TaskList : UserControl, ITaskViewer
    {
        public TaskList()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        public void Init(PcsClient client, NddEngine engine)
        {
        }

        public void LoadTask()
        {
        }

        public void SaveTask()
        {
            //removetpath=status
        }

        #region 接口实现
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thread"></param>
        public void UpdateTask(TaskThread thread)
        {
        }
        #endregion

        #region 公共函数
        public void AddTask(TaskThread thread, bool upload)
        {
            var item = new ListViewItem();
            item.Text = "name";

            var task = new ListViewItem.ListViewSubItem();
            task.Name = "task";
            task.Text = upload ? "上传" : "下载";
            item.SubItems.Add(task);

            var status = new ListViewItem.ListViewSubItem();
            status.Name = "status";
            status.Text = "等待中";
            item.SubItems.Add(status);

            var progress = new ListViewItem.ListViewSubItem();
            progress.Text = "";
            progress.Tag = 0d;
            item.SubItems.Add(progress);

            //LvTask.Items.Add(item);
        }

        public void StartAll()
        {
        }

        public void SuspendAll()
        {
        }

        public void StopAll()
        {
        }
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
    }
}
