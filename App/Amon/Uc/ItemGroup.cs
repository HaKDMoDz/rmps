using System.Collections.Generic;
using System.Windows.Forms;

namespace Me.Amon.Uc
{
    public class ItemGroup
    {
        private ToolStripMenuItem _Last;
        private Dictionary<object, ToolStripMenuItem> _Items;

        public ItemGroup()
        {
            _Items = new Dictionary<object, ToolStripMenuItem>();
        }

        public void Add(object obj, ToolStripMenuItem item)
        {
            if (obj != null)
            {
                _Items[obj] = item;
            }
        }

        public void Checked(object key)
        {
            if (_Last != null)
            {
                _Last.Checked = false;
            }
            if (_Items.ContainsKey(key))
            {
                _Last = _Items[key];
                _Last.Checked = true;
            }
        }
    }
}
