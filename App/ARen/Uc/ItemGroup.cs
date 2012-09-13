using System.Collections.Generic;
using System.Windows.Forms;

namespace Me.Amon.Uc
{
    public class ItemGroup
    {
        private int _Index;
        private ToolStripItem _Last;
        private Dictionary<string, ToolStripItem> _Items;

        public ItemGroup()
        {
            _Items = new Dictionary<string, ToolStripItem>();
        }

        public void Add(string key, ToolStripItem item)
        {
            if (string.IsNullOrEmpty(key))
            {
                key = "_Item" + _Index++;
            }
            _Items[key] = item;

            if (item is ToolStripMenuItem)
            {
                if ((item as ToolStripMenuItem).Checked)
                {
                    _Last = item;
                }
                return;
            }
            if (item is ToolStripButton)
            {
                if ((item as ToolStripButton).Checked)
                {
                    _Last = item;
                }
                return;
            }
        }

        public void Checked(string key)
        {
            DoChecked(false);
            if (_Items.ContainsKey(key))
            {
                _Last = _Items[key];
                DoChecked(true);
            }
        }

        public void Visible(bool visible)
        {
            foreach (ToolStripItem item in _Items.Values)
            {
                item.Visible = visible;
            }
        }

        public void Enabled(bool enabled)
        {
            foreach (ToolStripItem item in _Items.Values)
            {
                item.Enabled = enabled;
            }
        }

        private void DoChecked(bool value)
        {
            if (_Last == null)
            {
                return;
            }
            if (_Last is ToolStripMenuItem)
            {
                (_Last as ToolStripMenuItem).Checked = value;
                return;
            }
            if (_Last is ToolStripButton)
            {
                (_Last as ToolStripButton).Checked = value;
                return;
            }
        }
    }
}
