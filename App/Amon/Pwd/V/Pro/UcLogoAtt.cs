using System.Windows.Forms;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class UcLogoAtt : UserControl, IAttEditer
    {
        private APro _APro;
        private LogoAtt _Att;
        private DataModel _DataModel;

        #region 构造函数
        public UcLogoAtt()
        {
            InitializeComponent();
        }

        public UcLogoAtt(APro aPro)
        {
            _APro = aPro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            _APro.ShowTips(PbLogo, "点击选择徽标");
        }

        public Control Control { get { return this; } }

        public string Title { get { return "徽标"; } }

        public bool ShowData(Att att)
        {
            _Att = att as LogoAtt;

            if (_Att != null)
            {
                TbData.Text = _Att.Data;
                if (_Att.SmallIcon == null)
                {
                    if (!CharUtil.IsValidateHash(_Att.Text))
                    {
                        _Att.SmallIcon = BeanUtil.NaN16;
                    }
                    else
                    {
                        _Att.SmallIcon = _Att.LoadImage(_DataModel.KeyDir, _Att.GetSpec(LogoAtt.SPEC_LOGO_DIR), _Att.Text, CApp.IMG_KEY_EDIT_EXT, BeanUtil.NaN16);
                    }
                }
                PbLogo.Image = _Att.SmallIcon;
            }

            return true;
        }

        public new bool Focus()
        {
            return TbData.Focus();
        }

        public void Cut()
        {
            TbData.Cut();
        }

        public void Copy()
        {
            if (!string.IsNullOrEmpty(TbData.SelectedText))
            {
                TbData.Copy();
                return;
            }
            if (!string.IsNullOrEmpty(TbData.Text))
            {
                Clipboard.SetText(TbData.Text);
            }
        }

        public void Paste()
        {
            TbData.Paste();
        }

        public void Clear()
        {
            TbData.Clear();
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (TbData.Text != _Att.Data)
            {
                _Att.Data = TbData.Text;
                _Att.Modified = true;
            }

            return true;
        }
        #endregion

        #region 事件处理
        private void PbName_Click(object sender, System.EventArgs e)
        {
            //_Editer.ShowIcoSeeker(new AmonHandler<Png>(ChangeImgByKey));
        }
        #endregion

        private void ChangeImgByKey(Png png)
        {
            if (png != null && _Att.Text != png.File)
            {
                _Att.Text = png.File;
                _Att.SetSpec(LogoAtt.SPEC_LOGO_DIR, png.Path);
                _Att.LargeIcon = png.LargeImage ?? BeanUtil.NaN24;
                _Att.SmallIcon = _Att.LoadImage(_DataModel.KeyDir, png.Path, png.File, CApp.IMG_KEY_EDIT_EXT, BeanUtil.NaN16);
                _Att.Modified = true;
            }
            PbLogo.Image = _Att.SmallIcon;
        }
    }
}
