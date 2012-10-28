﻿using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.E;
using Me.Amon.M;

namespace Me.Amon.Ico.E
{
    public abstract class WIcoAction : IAction<WIco>
    {
        protected List<ToolStripItem> _Items;

        public WIco IApp { get; set; }

        public virtual void DoInit() { }

        public abstract void EventHandler(object sender, System.EventArgs e);

        public virtual void ReInit() { }

        public virtual void Add(ToolStripItem item, IViewModel viewModel)
        {
            if (_Items == null)
            {
                _Items = new List<ToolStripItem>();
            }

            _Items.Add(item);
        }
    }
}
