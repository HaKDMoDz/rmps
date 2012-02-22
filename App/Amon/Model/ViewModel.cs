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

        public bool EchoBarVisible { get; set; }

        public bool CatTreeVisible { get; set; }

        public bool KeyListVisible { get; set; }

        public bool NavPaneVisible { get; set; }

        public int WindowLocX { get; set; }
        public int WindowLocY { get; set; }
        public int WindowDimW { get; set; }
        public int WindowDimH { get; set; }

        public Image HintImage { get; set; }

        private string _FeelPath;
        private string _LookPath;
        private Uc.Properties _Prop;
        private Dictionary<string, Image> _Imgs;
        public void Load()
        {
            #region Look
            _LookPath = string.Format("Skin{1}Look{1}{0}{1}", _UserModel.Feel, Path.DirectorySeparatorChar);
            _Prop = new Uc.Properties();
            _Prop.Load(_LookPath + IEnv.FILE_LOOK);
            MenuBarVisible = IEnv.VALUE_TRUE == _Prop.Get("MenuBar", IEnv.VALUE_TRUE).ToLower();
            ToolBarVisible = IEnv.VALUE_TRUE == _Prop.Get("ToolBar", IEnv.VALUE_TRUE).ToLower();
            FindBarVisible = IEnv.VALUE_TRUE == _Prop.Get("FindBar", IEnv.VALUE_TRUE).ToLower();
            EchoBarVisible = IEnv.VALUE_TRUE == _Prop.Get("EchoBar", IEnv.VALUE_TRUE).ToLower();
            CatTreeVisible = IEnv.VALUE_TRUE == _Prop.Get("CatTree", IEnv.VALUE_TRUE).ToLower();
            KeyListVisible = IEnv.VALUE_TRUE == _Prop.Get("KeyList", IEnv.VALUE_TRUE).ToLower();
            NavPaneVisible = IEnv.VALUE_TRUE == _Prop.Get("KeyGuid", IEnv.VALUE_TRUE).ToLower();

            string tmp = _Prop.Get("LocX", "");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowLocX = int.Parse(tmp);
            }
            tmp = _Prop.Get("LocY", "");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowLocY = int.Parse(tmp);
            }
            tmp = _Prop.Get("DimW", "");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowDimW = int.Parse(tmp);
            }
            tmp = _Prop.Get("DimH", "");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowDimH = int.Parse(tmp);
            }
            #endregion

            #region Feel
            _FeelPath = string.Format("Skin{1}Feel{1}{0}{1}", _UserModel.Feel, Path.DirectorySeparatorChar);
            _Prop.Clear();
            _Prop.Load(_FeelPath + IEnv.FILE_FEEL);

            if (_Imgs == null)
            {
                _Imgs = new Dictionary<string, Image>();
            }
            else
            {
                _Imgs.Clear();
            }
            #endregion
        }

        public Image GetImage(string key)
        {
            key = _Prop.Get(key);
            if (string.IsNullOrEmpty(key))
            {
                return BeanUtil.NaN16;
            }

            if (_Imgs.ContainsKey(key))
            {
                return _Imgs[key];
            }

            Image img = BeanUtil.ReadImage(_FeelPath + key, BeanUtil.NaN16);
            _Imgs[key] = img;
            return img;
        }

        public void Save()
        {
            _Prop.Set("MenuBar", MenuBarVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _Prop.Set("ToolBar", ToolBarVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _Prop.Set("FindBar", FindBarVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _Prop.Set("EchoBar", EchoBarVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _Prop.Set("CatTree", CatTreeVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _Prop.Set("KeyList", KeyListVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _Prop.Set("KeyGuid", NavPaneVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);

            _Prop.Set("LocX", WindowLocX.ToString());
            _Prop.Set("LocY", WindowLocY.ToString());
            _Prop.Set("DimW", WindowDimW.ToString());
            _Prop.Set("DimH", WindowDimH.ToString());
            _Prop.Save(_LookPath);
        }
    }
}
