using System.IO;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Pwd._Att;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanLogo : UserControl, IAttEdit
    {
        private LogoAtt _Att;
        private Pwd.Ico _AIco;
        private APro _APro;
        private DataModel _DataModel;

        #region 构造函数
        public BeanLogo()
        {
            InitializeComponent();
        }

        public BeanLogo(APro apro)
        {
            _APro = apro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;
            _AIco = new Pwd.Ico();
        }

        public Control Control { get { return this; } }

        public string Title { get { return "徽标"; } }

        public bool ShowData(Att att)
        {
            _Att = att as LogoAtt;

            if (_Att != null)
            {
                _AIco.File = _Att.Text;
                _AIco.Path = _Att.Path;

                TbData.Text = _Att.Data;

                if (!CharUtil.IsValidateHash(_Att.Text))
                {
                    PbLogo.Image = BeanUtil.NaN16;
                }
                else
                {
                    string path = _DataModel.KeyDir;
                    if (CharUtil.IsValidateHash(_Att.Path))
                    {
                        path = Path.Combine(path, _Att.Path, _Att.Text + IEnv.IMG_KEY_EDIT_EXT);
                    }
                    else
                    {
                        path = Path.Combine(path, _Att.Text + IEnv.IMG_KEY_EDIT_EXT);
                    }
                    PbLogo.Image = BeanUtil.ReadImage(path, BeanUtil.NaN16);
                }
            }

            TbData.Focus();
            return true;
        }

        public void Cut()
        {
            TbData.Cut();
        }

        public void Copy()
        {
            TbData.Copy();
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

            if (_Att.Text != _AIco.File)
            {
                _Att.Text = _AIco.File;
                _Att.Path = _AIco.Path;
                _Att.Modified = true;
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
            _APro.ShowIcoSeeker(new AmonHandler<Pwd.Ico>(ChangeImgByKey));
        }
        #endregion

        private void ChangeImgByKey(Pwd.Ico ico)
        {
            _AIco = ico;
            string path;
            if (CharUtil.IsValidateHash(ico.Path))
            {
                path = Path.Combine(_DataModel.KeyDir, ico.Path, ico.File + IEnv.IMG_KEY_EDIT_EXT);
            }
            else
            {
                path = Path.Combine(_DataModel.KeyDir, ico.File + IEnv.IMG_KEY_EDIT_EXT);
            }
            PbLogo.Image = BeanUtil.ReadImage(path, BeanUtil.NaN16);
        }
    }
}
