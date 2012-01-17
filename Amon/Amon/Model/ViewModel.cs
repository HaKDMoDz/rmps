using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Me.Amon.Util;

namespace Me.Amon.Model
{
    public sealed class ViewModel
    {
        private UserModel _UserModel;

        public ViewModel(UserModel userModel)
        {
            _UserModel = userModel;
        }

        public string Skin { get; set; }

        public bool MenuBarVisible { get; set; }

        public bool ToolBarVisible { get; set; }

        public bool FindBarVisible { get; set; }

        public bool InfoBarVisible { get; set; }

        public bool CatTreeVisible { get; set; }

        public bool KeyListVisible { get; set; }

        private List<Image> _LabelImages;
        public List<Image> LabelImages
        {
            get
            {
                return _LabelImages;
            }
        }

        private List<Image> _MajorImages;
        public List<Image> MajorImages
        {
            get
            {
                return _MajorImages;
            }
        }

        public Image HimtImage { get; set; }

        public void Load()
        {
            Skin = "Skin\\Default\\";

            if (_LabelImages == null)
            {
                _LabelImages = new List<Image>(10);
            }
            else
            {
                _LabelImages.Clear();
            }
            for (int i = 0; i < 10; i += 1)
            {
                _LabelImages.Add(BeanUtil.ReadImage(string.Format("{0}key-label{1}.png", Skin, i), BeanUtil.NaN16));
            }

            if (_MajorImages == null)
            {
                _MajorImages = new List<Image>(5);
            }
            else
            {
                _MajorImages.Clear();
            }
            for (int i = -2; i < 3; i += 1)
            {
                _MajorImages.Add(BeanUtil.ReadImage(string.Format("{0}key-major{1}.png", Skin, i > 0 ? "+" + i : i.ToString()), BeanUtil.NaN16));
            }
        }

        public void Save()
        {
        }
    }
}
