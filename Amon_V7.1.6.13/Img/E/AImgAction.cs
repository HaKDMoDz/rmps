using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Img.E
{
    public abstract class AImgAction : IAction<AImg>
    {
        protected List<ToolStripItem> _Items;

        public AImg IApp { get; set; }

        public virtual void DoInit() { }

        public abstract void EventHandler(object sender, System.EventArgs e);

        public virtual void ReInit() { }

        public void Add(ToolStripItem item, ViewModel viewModel)
        {
            if (_Items == null)
            {
                _Items = new List<ToolStripItem>();
            }

            _Items.Add(item);
        }
    }
}
