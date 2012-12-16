using Me.Amon.Pcs.V.Task;
using System.Collections.Generic;

namespace Me.Amon.Pcs.V
{
    public interface ITaskViewer
    {
        void ShowTask(List<TaskThread> tasks);

        /// <summary>
        /// 更新线程进度
        /// </summary>
        /// <param name="task"></param>
        /// <param name="index"></param>
        void UpdateTask(TaskThread task, int index);

        void AppendTask(TaskThread task);

        void RemoveTask(TaskThread task, int index);

        /// <summary>
        /// 界面强制刷新
        /// </summary>
        void Refresh();
    }
}
