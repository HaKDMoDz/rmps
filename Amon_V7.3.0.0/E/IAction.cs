using Me.Amon.M;

namespace Me.Amon.E
{
    public interface IAction<T>
    {
        T IApp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        void DoInit();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void Add(System.Windows.Forms.ToolStripItem item, IViewModel viewModel);

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
