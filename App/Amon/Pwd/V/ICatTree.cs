﻿using System.Windows.Forms;
using Me.Amon.M;

namespace Me.Amon.Pwd.V
{
    public interface ICatTree
    {
        Control Control { get; }

        ContextMenuStrip PopupMenu { get; set; }

        Cat SelectedCat { get; set; }

        IKeyList KeyList { get; set; }

        ImageList ImageList { get; }

        void AppendCat(Cat cat);

        void UpdateCat(Cat cat);

        void DeleteCat();

        void SortUp();

        void SortDown();

        void CatPromotion();

        void CatDemotion();

        bool Focus();

        void Init(ImageList images);

        void ChangeIcon(Png png);

        void TaskSelected();
    }
}
