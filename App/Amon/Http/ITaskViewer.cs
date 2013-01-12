using System.Collections.Generic;

namespace Me.Amon.Http
{
    public interface ITaskViewer
    {
        void ShowTask(List<TaskInfo> tasks);

        /// <summary>
        /// 更新线程进度
        /// </summary>
        /// <param name="task"></param>
        /// <param name="index"></param>
        void UpdateTask(TaskInfo task, int index);

        void AppendTask(TaskInfo task);

        void RemoveTask(TaskInfo task, int index);

        /// <summary>
        /// 界面强制刷新
        /// </summary>
        void Refresh();
    }
}
