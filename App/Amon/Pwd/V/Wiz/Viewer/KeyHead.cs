using System;
using System.Windows.Forms;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    public partial class KeyHead : UserControl, IKeyViewer
    {
        private AWiz _AWiz;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private TextBox _TBox;

        #region 构造函数
        public KeyHead()
        {
            InitializeComponent();
        }

        public void Init(AWiz aWiz, UserModel userModel, SafeModel safeModel, DataModel dataModel, ViewModel viewModel)
        {
            _AWiz = aWiz;
            _UserModel = userModel;
            _SafeModel = safeModel;
            _DataModel = dataModel;

            TbName.GotFocus += new EventHandler(TbName_GotFocus);
            TbMeta.GotFocus += new EventHandler(TbMeta_GotFocus);
            TbAuto.GotFocus += new EventHandler(TbAuto_GotFocus);
        }
        #endregion

        #region 接口实现
        public void ShowData()
        {
            MetaAtt meta = _SafeModel.Meta;
            if (meta == null)
            {
                return;
            }
            TbName.Text = meta.Text;
            TbMeta.Text = meta.Data;

            LogoAtt logo = _SafeModel.Logo;
            if (logo == null)
            {
                return;
            }
            if (logo.SmallIcon == null)
            {
                if (!CharUtil.IsValidateHash(logo.Text))
                {
                    logo.SmallIcon = BeanUtil.NaN16;
                }
                else
                {
                    logo.SmallIcon = logo.LoadImage(_DataModel.KeyDir, logo.GetSpec(LogoAtt.SPEC_LOGO_DIR), logo.Text, CApp.IMG_KEY_EDIT_EXT, BeanUtil.NaN16);
                }
            }
            PbLogo.Image = logo.SmallIcon;

            HintAtt hint = _SafeModel.Hint;
            if (hint == null)
            {
                return;
            }
            TbHint.Text = hint.Text;
            PbHint.Image = hint.Icon;

            AutoAtt auto = _SafeModel.Auto;
            if (auto != null)
            {
                TbAuto.Text = auto.Data;
            }
            Focus();
        }

        public void CopyData()
        {
            if (_TBox != null)
            {
                _TBox.Copy();
            }
        }

        public void FillData()
        {
            if (_TBox != null)
            {
                _TBox.Paste();
            }
        }
        #endregion

        #region 事件处理
        private void TbName_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbName;
        }

        private void TbMeta_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbMeta;
        }

        private void TbAuto_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbAuto;
        }
        #endregion

        #region 私有函数
        private void ChangeImgByKey(Png png)
        {
            LogoAtt logo = _SafeModel.Logo;
            if (png != null && logo.Text != png.File)
            {
                logo.Text = png.File;
                logo.SetSpec(LogoAtt.SPEC_LOGO_DIR, png.Path);
                logo.LargeIcon = png.LargeImage ?? BeanUtil.NaN24;
                logo.SmallIcon = logo.LoadImage(_DataModel.KeyDir, png.Path, png.File, CApp.IMG_KEY_EDIT_EXT, BeanUtil.NaN16);
                logo.Modified = true;
            }
            _SafeModel.Modified |= logo.Modified;
            PbLogo.Image = logo.SmallIcon;
        }
        #endregion
    }
}
