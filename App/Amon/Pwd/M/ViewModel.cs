using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Da.Df;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.M
{
    public sealed class ViewModel : IViewModel
    {
        #region 全局变量
        private UserModel _UserModel;
        private string _Pattern;
        private string _LookPath;
        private DFEngine _LookProp;
        private string _FeelPath;
        private DFEngine _FeelProp;
        private DFEngine _UserProp;
        #endregion

        #region 构造函数
        public ViewModel(UserModel userModel)
        {
            _UserModel = userModel;
        }

        public void Init()
        {
        }
        #endregion

        #region 接口实现
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

            Image img = BeanUtil.ReadImage(Path.Combine(_FeelPath, key), BeanUtil.NaN16);
            _Imgs[key] = img;
            return img;
        }

        public Image GetImage(string key, string file)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                return BeanUtil.NaN16;
            }

            if (Path.IsPathRooted(file))
            {
                file = Path.Combine(Application.StartupPath, file);
            }

            if (!string.IsNullOrEmpty(key))
            {
                if (_Imgs.ContainsKey(key))
                {
                    return _Imgs[key];
                }

                Image img = BeanUtil.ReadImage(file, BeanUtil.NaN16);
                _Imgs[key] = img;
                return img;
            }

            return BeanUtil.ReadImage(file, BeanUtil.NaN16);
        }

        /// <summary>
        /// 布局存储
        /// </summary>
        public void LoadLayout()
        {
            #region Look
            _LookPath = Path.Combine(_UserModel.ResHome, "Skin", "Look", _UserModel.Look);
            _LookProp = new DFEngine();
            _LookProp.Load(Path.Combine(_LookPath, CApp.FILE_LOOK));
            #endregion

            #region Feel
            _FeelPath = Path.Combine(_UserModel.ResHome, "Skin", "Feel", _UserModel.Feel);
            _FeelProp = new DFEngine();
            _FeelProp.Load(Path.Combine(_FeelPath, CApp.FILE_FEEL));

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
            _UserProp = new DFEngine();
            _UserProp.Load(Path.Combine(_UserModel.DatHome, CApp.USER_CFG));
            Pattern = _UserProp.Get("Pattern", "");
            string tmp = _UserProp.Get("WindowState", "0");
            if (CharUtil.IsValidateLong(tmp))
            {
                WindowState = int.Parse(tmp);
            }
            MenuBarVisible = CApp.VALUE_TRUE == _UserProp.Get("MenuBar", CApp.VALUE_TRUE).ToLower();
            ToolBarVisible = CApp.VALUE_TRUE == _UserProp.Get("ToolBar", CApp.VALUE_TRUE).ToLower();
            EchoBarVisible = CApp.VALUE_TRUE == _UserProp.Get("EchoBar", CApp.VALUE_TRUE).ToLower();
            FindBarVisible = CApp.VALUE_TRUE == _UserProp.Get("FindBar", CApp.VALUE_TRUE).ToLower();
            KeyGuidVisible = CApp.VALUE_TRUE == _UserProp.Get("NavPane", CApp.VALUE_TRUE).ToLower();
            CatTreeVisible = CApp.VALUE_TRUE == _UserProp.Get("CatTree", CApp.VALUE_TRUE).ToLower();
            KeyListVisible = CApp.VALUE_TRUE == _UserProp.Get("KeyList", CApp.VALUE_TRUE).ToLower();

            tmp = _UserProp.Get("HSplitDistance", "200");
            if (CharUtil.IsValidateLong(tmp))
            {
                KeyGuidWidth = int.Parse(tmp);
            }
            tmp = _UserProp.Get("VSplitDistance", "160");
            if (CharUtil.IsValidateLong(tmp))
            {
                CatTreeHeight = int.Parse(tmp);
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

        /// <summary>
        /// 布局加载
        /// </summary>
        public void SaveLayout()
        {
            _UserProp.Set("Pattern", Pattern);

            _UserProp.Set("WindowState", WindowState.ToString());

            _UserProp.Set("LocX", WindowLocX.ToString());
            _UserProp.Set("LocY", WindowLocY.ToString());
            _UserProp.Set("DimW", WindowDimW.ToString());
            _UserProp.Set("DimH", WindowDimH.ToString());

            _UserProp.Set("MenuBar", MenuBarVisible ? CApp.VALUE_TRUE : CApp.VALUE_FALSE);
            _UserProp.Set("ToolBar", ToolBarVisible ? CApp.VALUE_TRUE : CApp.VALUE_FALSE);
            _UserProp.Set("EchoBar", EchoBarVisible ? CApp.VALUE_TRUE : CApp.VALUE_FALSE);
            _UserProp.Set("FindBar", FindBarVisible ? CApp.VALUE_TRUE : CApp.VALUE_FALSE);

            _UserProp.Set("NavPane", KeyGuidVisible ? CApp.VALUE_TRUE : CApp.VALUE_FALSE);
            _UserProp.Set("CatTree", CatTreeVisible ? CApp.VALUE_TRUE : CApp.VALUE_FALSE);
            _UserProp.Set("KeyList", KeyListVisible ? CApp.VALUE_TRUE : CApp.VALUE_FALSE);

            _UserProp.Set("HSplitDistance", _KeyGuidWidth.ToString());
            _UserProp.Set("VSplitDistance", _CatTreeHeight.ToString());

            _UserProp.Save(Path.Combine(_UserModel.DatHome, CApp.USER_CFG));
        }
        #endregion

        #region 视图数据
        public string Pattern
        {
            get
            {
                return _Pattern;
            }
            set
            {
                value = value.ToLower();
                if (value == CPwd.PATTERN_PRO || value == CPwd.PATTERN_WIZ || value == CPwd.PATTERN_PAD)
                {
                    _Pattern = value;
                }
                else
                {
                    _Pattern = CPwd.PATTERN_WIZ;
                }
            }
        }

        public string Skin { get; set; }

        public int WindowState { get; set; }

        public bool MenuBarVisible { get; set; }

        public bool ToolBarVisible { get; set; }

        public bool FindBarVisible { get; set; }

        public bool EchoBarVisible { get; set; }

        public int LayoutStyle { get; set; }

        public bool KeyGuidVisible { get; set; }

        public int KeyGuidWidth
        {
            get
            {
                return _KeyGuidWidth;
            }
            set
            {
                _KeyGuidWidth = value < 0 ? 188 : value;
            }
        }
        private int _KeyGuidWidth = 188;

        public bool CatTreeVisible { get; set; }

        public int CatTreeHeight
        {
            get
            {
                return _CatTreeHeight;
            }
            set
            {
                _CatTreeHeight = value < 0 ? 152 : value;
            }
        }
        private int _CatTreeHeight = 152;
        public int CatTreeWidth
        {
            get
            {
                return _CatTreeWidth;
            }
            set
            {
                _CatTreeWidth = value < 0 ? 120 : value;
            }
        }
        private int _CatTreeWidth = 120;

        public bool KeyListVisible { get; set; }
        public int KeyListHeight
        {
            get
            {
                return _KeyListHeight;
            }
            set
            {
                _KeyListHeight = value < 0 ? 60 : value;
            }
        }
        private int _KeyListHeight = 60;
        public int KeyListWidth
        {
            get
            {
                return _KeyListWidth;
            }
            set
            {
                _KeyListWidth = value < 0 ? 188 : value;
            }
        }
        private int _KeyListWidth = 188;

        public bool AttViewVisible { get; set; }

        public int WindowLocX { get; set; }
        public int WindowLocY { get; set; }

        public int WindowDimW
        {
            get
            {
                return _WindowDimW;
            }
            set
            {
                _WindowDimW = value < 1 ? 584 : value;
            }
        }
        private int _WindowDimW = 584;

        public int WindowDimH
        {
            get
            {
                return _WindowDimH;
            }
            set
            {
                _WindowDimH = value < 1 ? 412 : value;
            }
        }
        private int _WindowDimH = 412;
        #endregion
    }
}
