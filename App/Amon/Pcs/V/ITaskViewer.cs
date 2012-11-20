using System.Collections.Generic;
using Me.Amon.Pcs.C;

namespace Me.Amon.Pcs.V
{
    public interface ITaskViewer
    {
        void ShowTask(List<TaskThread> tasks);

        void UpdateTask(TaskThread task, int index);

        void AppendTask(TaskThread task);

        void RemoveTask(TaskThread task);

        void Refresh();
    }
}
