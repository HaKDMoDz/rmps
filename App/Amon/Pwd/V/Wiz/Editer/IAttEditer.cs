﻿using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Wiz.Editer
{
    public interface IAttEditer
    {
        void InitOnce(TableLayoutPanel grid, ViewModel viewModel);

        int InitView(int row);

        bool ShowData(DataModel dataModel, Att att);

        void Cut();

        void Copy(CopyType type);

        void Paste();

        void Clear();

        bool Save();

        int Height { get; }
    }
}
