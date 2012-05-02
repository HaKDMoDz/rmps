using System.Windows.Forms;

namespace Me.Amon
{
    public interface IAction<T>
    {
        T IApp { get; set; }

        void Add(ToolStripItem item);

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
