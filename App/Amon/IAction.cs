using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon
{
    public interface IAction<T>
    {
        T IApp { get; set; }

        void Add(ToolStripItem item, ViewModel viewModel);

        /// <summary>
        /// 
        /// </summary>
        void DoInit();

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void EventHandler(object sender, System.EventArgs e);

        /// <summary>
        /// 
        /// </summary>
        void ReInit();
    }
}
