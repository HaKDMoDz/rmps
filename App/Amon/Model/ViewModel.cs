using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Model
{
    public sealed class ViewModel
    {
        private UserModel _UserModel;
        private string _LookPath;
        private Uc.Properties _LookProp;
        private string _FeelPath;
        private Uc.Properties _FeelProp;
        private Uc.Properties _UserProp;

        public ViewModel(UserModel userModel)
        {
            _UserModel = userModel;
        }

        #region 视图数据
        public string Skin { get; set; }

        public bool MenuBarVisible { get; set; }

        public bool ToolBarVisible { get; set; }

        public bool FindBarVisible { get; set; }

        public bool EchoBarVisible { get; set; }

        public bool CatTreeVisible { get; set; }

        public bool KeyListVisible { get; set; }

        public bool NavPaneVisible { get; set; }

        private int _HSplitDistance = 200;
        public int HSplitDistance
        {
            get
            {
                return _HSplitDistance;
            }
            set
            {
                _HSplitDistance = value < 0 ? 200 : value;
            }
        }

        private int _VSplitDistance = 160;
        public int VSplitDistance
        {
            get
            {
                return _VSplitDistance;
            }
            set
            {
                _VSplitDistance = value < 0 ? 160 : value;
            }
        }

        public int WindowLocX { get; set; }
        public int WindowLocY { get; set; }
        public int WindowDimW { get; set; }
        public int WindowDimH { get; set; }

        private Dictionary<string, Image> _Imgs;
        public Image GetImage(string key)
        {
            key = _FeelProp.Get(key);
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
        #endregion

        public void Load()
        {
            #region Look
            _LookPath = string.Format("Skin{1}Look{1}{0}{1}", _UserModel.Feel, Path.DirectorySeparatorChar);
            _LookProp = new Uc.Properties();
            _LookProp.Load(_LookPath + IEnv.FILE_LOOK);
            #endregion

            #region Feel
            _FeelPath = string.Format("Skin{1}Feel{1}{0}{1}", _UserModel.Feel, Path.DirectorySeparatorChar);
            _FeelProp = new Uc.Properties();
            _FeelProp.Load(_FeelPath + IEnv.FILE_FEEL);

            if (_Imgs == null)
            {
                _Imgs = new Dictionary<string, Image>();
            }
            else
            {
                _Imgs.Clear();
            }
            #endregion

            #region 视图
            _UserProp = new Uc.Properties();
            _UserProp.Load(_UserModel.Home + IEnv.USER_CFG);
            MenuBarVisible = IEnv.VALUE_TRUE == _UserProp.Get("MenuBar", IEnv.VALUE_TRUE).ToLower();
            ToolBarVisible = IEnv.VALUE_TRUE == _UserProp.Get("ToolBar", IEnv.VALUE_TRUE).ToLower();
            FindBarVisible = IEnv.VALUE_TRUE == _UserProp.Get("FindBar", IEnv.VALUE_TRUE).ToLower();
            EchoBarVisible = IEnv.VALUE_TRUE == _UserProp.Get("EchoBar", IEnv.VALUE_TRUE).ToLower();
            CatTreeVisible = IEnv.VALUE_TRUE == _UserProp.Get("CatTree", IEnv.VALUE_TRUE).ToLower();
            KeyListVisible = IEnv.VALUE_TRUE == _UserProp.Get("KeyList", IEnv.VALUE_TRUE).ToLower();
            NavPaneVisible = IEnv.VALUE_TRUE == _UserProp.Get("KeyGuid", IEnv.VALUE_TRUE).ToLower();

            string tmp = _UserProp.Get("HSplitDistance", "200");
            if (CharUtil.IsValidateLong(tmp))
            {
                HSplitDistance = int.Parse(tmp);
            }
            tmp = _UserProp.Get("VSplitDistance", "160");
            if (CharUtil.IsValidateLong(tmp))
            {
                VSplitDistance = int.Parse(tmp);
            }

            tmp = _UserProp.Get("DimW", "600");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowDimW = int.Parse(tmp);
            }
            tmp = _UserProp.Get("DimH", "450");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowDimH = int.Parse(tmp);
            }
            tmp = _UserProp.Get("LocX", "");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowLocX = int.Parse(tmp);
            }
            else
            {
                WindowLocX = (SystemInformation.WorkingArea.Width - WindowDimW) >> 1;
            }
            tmp = _UserProp.Get("LocY", "");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowLocY = int.Parse(tmp);
            }
            else
            {
                WindowLocY = (SystemInformation.WorkingArea.Height - WindowDimH) >> 1;
            }
            #endregion
        }

        public void Save()
        {
            _UserProp.Set("MenuBar", MenuBarVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _UserProp.Set("ToolBar", ToolBarVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _UserProp.Set("FindBar", FindBarVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _UserProp.Set("EchoBar", EchoBarVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _UserProp.Set("CatTree", CatTreeVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _UserProp.Set("KeyList", KeyListVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);
            _UserProp.Set("KeyGuid", NavPaneVisible ? IEnv.VALUE_TRUE : IEnv.VALUE_FALSE);

            _UserProp.Set("HSplitDistance", _HSplitDistance.ToString());
            _UserProp.Set("VSplitDistance", _VSplitDistance.ToString());

            _UserProp.Set("LocX", WindowLocX.ToString());
            _UserProp.Set("LocY", WindowLocY.ToString());
            _UserProp.Set("DimW", WindowDimW.ToString());
            _UserProp.Set("DimH", WindowDimH.ToString());
            _UserProp.Save(_UserModel.Home + IEnv.USER_CFG);
        }
    }
}
