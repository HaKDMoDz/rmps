using System;
using System.IO;
using System.Windows.Forms;
using Me.Amon.C;
using Me.Amon.Gtd.V;
using Me.Amon.M;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Wiz
{
    public partial class BeanHead : UserControl, IWizView
    {
        private AWiz _AWiz;
        private Png _APng;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private TableLayoutPanel _TlPanel;
        private TextBox _TBox;

        #region 构造函数
        public BeanHead()
        {
            InitializeComponent();
        }

        public BeanHead(AWiz awiz, UserModel userModel, SafeModel safeModel)
        {
            _AWiz = awiz;
            _UserModel = userModel;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(TableLayoutPanel grid, DataModel dataModel, ViewModel viewModel)
        {
            _TlPanel = grid;
            _DataModel = dataModel;
            _APng = new Png();

            TbName.GotFocus += new EventHandler(TbName_GotFocus);
            TbMeta.GotFocus += new EventHandler(TbMeta_GotFocus);
            TbMemo.GotFocus += new EventHandler(TbMemo_GotFocus);
        }
        #endregion

        #region 接口实现
        public void InitView()
        {
            _TlPanel.Controls.Add(this, 0, 0);
            Dock = DockStyle.Fill;
            TabIndex = 0;
        }

        public void HideView()
        {
            _TlPanel.Controls.Remove(this);
        }

        public void ShowData()
        {
            _TlPanel.RowStyles[1].Height = 32;

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
            string temp = logo.GetSpec(LogoAtt.SPEC_LOGO_DIR);
            _APng.File = logo.Text;
            _APng.Path = temp;
            if (!CharUtil.IsValidateHash(logo.Text))
            {
                PbLogo.Image = BeanUtil.NaN16;
            }
            else
            {
                PbLogo.Image = _APng.LoadImage(_DataModel.KeyDir, CApp.IMG_KEY_EDIT_EXT, BeanUtil.NaN16);
            }

            HintAtt hint = _SafeModel.Hint;
            if (hint == null)
            {
                return;
            }
            TbHint.Text = hint.Text;

            Focus();
        }

        public bool SaveData()
        {
            if (_SafeModel.Key == null)
            {
                return false;
            }

            string text = TbName.Text;
            if (!CharUtil.IsValidate(text))
            {
                Main.ShowAlert("请输入记录标题！");
                TbName.Focus();
                return false;
            }

            MetaAtt meta = _SafeModel.Meta;
            if (meta.Text != text)
            {
                meta.Text = text;
                meta.Modified = true;
            }
            if (meta.Data != TbMeta.Text)
            {
                meta.Data = TbMeta.Text;
                meta.Modified = true;
            }
            _SafeModel.Modified |= meta.Modified;

            LogoAtt logo = _SafeModel.Logo;
            if (logo.Text != _APng.File)
            {
                logo.Text = _APng.File;
                logo.SetSpec(LogoAtt.SPEC_LOGO_DIR, _APng.Path);
                logo.MaxIcon = _APng.LoadImage(_DataModel.KeyDir, CApp.IMG_KEY_LIST_EXT, BeanUtil.NaN24);
                logo.Modified = true;
            }
            _SafeModel.Modified |= logo.Modified;

            HintAtt hint = _SafeModel.Hint;
            if (hint.Text != TbHint.Text)
            {
                hint.Text = TbHint.Text;
                hint.Modified = true;
            }
            _SafeModel.Modified |= hint.Modified;

            return true;
        }

        public void CutData()
        {
            if (_TBox != null)
            {
                _TBox.Cut();
            }
        }

        public void CopyData()
        {
            if (_TBox != null)
            {
                _TBox.Copy();
            }
        }

        public void PasteData()
        {
            if (_TBox != null)
            {
                _TBox.Paste();
            }
        }

        public void ClearData()
        {
            if (_TBox != null)
            {
                _TBox.Clear();
            }
        }
        #endregion

        #region 事件处理
        private void CbLib_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void PbLogo_Click(object sender, EventArgs e)
        {
            _AWiz.ShowIcoSeeker(_DataModel.KeyDir, new AmonHandler<Png>(ChangeImgByKey));
        }

        private void BtHint_Click(object sender, EventArgs e)
        {
            GtdEditor editor = new GtdEditor(true);
            editor.MGtd = _SafeModel.Hint.Gtd;
            if (DialogResult.OK != editor.ShowDialog())
            {
                return;
            }

            Gtd.MGtd gtd = editor.MGtd;
            TbHint.Text = gtd.Title;
            _SafeModel.Hint.Text = gtd.Title;
            _SafeModel.Modified = true;
            _SafeModel.Hint.Gtd = gtd;
        }

        private void TbName_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbName;
        }

        private void TbMeta_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbMeta;
        }

        private void TbMemo_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbMemo;
        }
        #endregion

        #region 私有函数
        private void ChangeImgByKey(Png png)
        {
            _APng = png;
            png.SmallImage = png.LoadImage(_DataModel.KeyDir, CApp.IMG_KEY_EDIT_EXT, BeanUtil.NaN16);
            PbLogo.Image = png.SmallImage;
        }
        #endregion
    }
}
