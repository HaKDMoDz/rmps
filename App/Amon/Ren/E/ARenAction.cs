using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Ren.E
{
    public abstract class ARenAction : IAction<ARen>
    {
        protected List<ToolStripItem> _Items;

        public ARen IApp { get; set; }

        public virtual void DoInit() { }

        public abstract void EventHandler(object sender, System.EventArgs e);

        public virtual void ReInit() { }

        public virtual void Add(ToolStripItem item, ViewModel viewModel)
        {
            if (_Items == null)
            {
                _Items = new List<ToolStripItem>();
            }

            _Items.Add(item);
        }
    }
}
