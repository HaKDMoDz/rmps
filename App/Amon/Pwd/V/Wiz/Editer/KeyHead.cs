using System;
using System.Windows.Forms;
using Me.Amon.C;
using Me.Amon.Gtd.V;
using Me.Amon.Properties;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Wiz.Editer
{
    public partial class KeyHead : UserControl, IKeyEditer
    {
        private WWiz _AWiz;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private Lib _DefLib;
        private TextBox _TBox;

        #region 构造函数
        public KeyHead()
        {
            InitializeComponent();
        }

        public KeyHead(WWiz awiz, UserModel userModel, SafeModel safeModel)
        {
            _AWiz = awiz;
            _UserModel = userModel;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            TbName.GotFocus += new EventHandler(TbName_GotFocus);
            TbMeta.GotFocus += new EventHandler(TbMeta_GotFocus);
            TbAuto.GotFocus += new EventHandler(TbMemo_GotFocus);

            _DefLib = new Lib { Id = "", Text = "请选择", Target = "", Script = "" };
        }
        #endregion

        #region 接口实现
        public void InitView(Panel panel)
        {
            panel.Controls.Add(this);
            Dock = DockStyle.Fill;
            TabIndex = 0;
        }

        public void HideView(Panel panel)
        {
            panel.Controls.Remove(this);
        }

        public void ShowData()
        {
            if ((_DataModel.LibModified & CPwd.KEY_AWIZ) > 0)
            {
                CbLib.Items.Clear();
                CbLib.Items.Add(_DefLib);
                foreach (Lib header in _DataModel.LibList)
                {
                    CbLib.Items.Add(header);
                }
                _DataModel.LibModified &= ~CPwd.KEY_AWIZ;
            }

            GuidAtt guid = _SafeModel.Guid;
            if (guid == null)
            {
                CbLib.Enabled = true;
                return;
            }
            CbLib.SelectedItem = new Lib { Id = guid.Data ?? "" };

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
            if (auto == null)
            {
                return;
            }
            TbAuto.Text = auto.Data;

            Focus();
        }

        public bool SaveData()
        {
            if (_SafeModel.Key == null)
            {
                return false;
            }

            Lib lib = CbLib.SelectedItem as Lib;
            if (lib == null || !CharUtil.IsValidateHash(lib.Id))
            {
                Main.ShowAlert("请选择您要使用的模板！");
                CbLib.Focus();
                return false;
            }

            string text = TbName.Text;
            if (!CharUtil.IsValidate(text))
            {
                Main.ShowAlert("请输入记录标题！");
                TbName.Focus();
                return false;
            }

            GuidAtt guid = _SafeModel.Guid;
            if (lib.Id != guid.Data)
            {
                guid.Data = lib.Id;
                if (!_SafeModel.IsUpdate)
                {
                    _SafeModel.InitData(lib);
                }
                guid.Modified = true;
                _SafeModel.Modified |= guid.Modified;
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

            AutoAtt auto = _SafeModel.Auto;
            if (auto.Data != TbAuto.Text)
            {
                auto.Text = "";
                auto.Data = TbAuto.Text;
                auto.Modified = true;
            }
            _SafeModel.Modified |= auto.Modified;

            //if (_SafeModel.Key.Memo != TbAuto.Text)
            //{
            //    _SafeModel.Key.Memo = TbAuto.Text;
            //    _SafeModel.Modified = true;
            //}

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
            if (_SafeModel.IsUpdate)
            {
                return;
            }
            var lib = CbLib.SelectedItem as Lib;
            if (lib != null)
            {
                TbAuto.Text = lib.Script;
            }
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

            Gtd.M.MGtd gtd = editor.MGtd;
            HintAtt hint = _SafeModel.Hint;
            hint.Gtd = gtd;
            hint.Text = gtd.Title;
            hint.Icon = Resources.Hint;
            _SafeModel.Modified = true;

            TbHint.Text = hint.Text;
            PbHint.Image = hint.Icon;
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
