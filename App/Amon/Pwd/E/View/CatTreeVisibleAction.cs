﻿using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.M;

namespace Me.Amon.Pwd.E.View
{
    public class CatTreeVisibleAction : APwdAction
    {
        public override void Add(ToolStripItem item, IViewModel viewModel)
        {
            if (_Items == null)
            {
                _Items = new List<ToolStripItem>();
            }

            _Items.Add(item);
            Pwd.M.ViewModel model = viewModel as Pwd.M.ViewModel;
            if (model == null)
            {
                return;
            }

            if (item is ToolStripMenuItem)
            {
                (item as ToolStripMenuItem).Checked = model.CatTreeVisible;
                return;
            }
            if (item is ToolStripButton)
            {
                (item as ToolStripButton).Checked = model.CatTreeVisible;
                return;
            }
        }

        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            bool status = !IApp.CatTreeVisible;
            IApp.CatTreeVisible = status;
            foreach (ToolStripItem item in _Items)
            {
                if (item == sender)
                {
                    continue;
                }
                if (item is ToolStripMenuItem)
                {
                    (item as ToolStripMenuItem).Checked = status;
                    continue;
                }
                if (item is ToolStripButton)
                {
                    (item as ToolStripButton).Checked = status;
                    continue;
                }
            }
        }

        public override void ReInit()
        {
            if (_Items == null)
            {
                return;
            }

            foreach (ToolStripItem item in _Items)
            {
                if (item is ToolStripMenuItem)
                {
                    (item as ToolStripMenuItem).Checked = IApp.CatTreeVisible;
                    continue;
                }
                if (item is ToolStripButton)
                {
                    (item as ToolStripButton).Checked = IApp.CatTreeVisible;
                }
            }
        }
    }
}
