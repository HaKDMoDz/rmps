using System.Collections.Generic;
using System.Windows.Forms;

namespace Me.Amon.Pwd.E
{
    public abstract class APwdAction : IAction<APwd>
    {
        protected List<ToolStripItem> _Items;

        public APwd IApp { get; set; }

        public virtual void DoInit() { }

        public abstract void EventHandler(object sender, System.EventArgs e);

        public virtual void ReInit() { }

        public void Add(ToolStripItem item)
        {
            if (_Items == null)
            {
                _Items = new List<ToolStripItem>();
            }

            _Items.Add(item);
        }
    }
}
