using System.IO;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Bean.Atts;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanLogo : UserControl, IAttEdit
    {
        private LogoAtt _Att;
        private Bean.Ico _AIco;
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
            _AIco = new Bean.Ico();
        }

        public Control Control { get { return this; } }

        public string Title { get { return "徽标"; } }

        public bool ShowData(Att att)
        {
            _Att = att as LogoAtt;

            if (_Att != null)
            {
                _AIco.File = _Att.Name;
                _AIco.Path = _Att.Path;

                TbData.Text = _Att.Data;

                if (!CharUtil.IsValidateHash(_Att.Name))
                {
                    PbName.Image = BeanUtil.NaN16;
                }
                else
                {
                    string path = _DataModel.KeyDir;
                    if (CharUtil.IsValidateHash(_Att.Path))
                    {
                        path = Path.Combine(path, _Att.Path, _Att.Name + IEnv.IMG_KEY_EDIT_EXT);
                    }
                    else
                    {
                        path = Path.Combine(path, _Att.Name + IEnv.IMG_KEY_EDIT_EXT);
                    }
                    PbName.Image = BeanUtil.ReadImage(path, BeanUtil.NaN16);
                }
            }

            TbData.Focus();
            return true;
        }

        public void Copy()
        {
            Clipboard.SetText(TbData.Text);
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (_Att.Name != _AIco.File)
            {
                _Att.Name = _AIco.File;
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
            _APro.ShowIcoSeeker(new AmonHandler<Bean.Ico>(ChangeImgByKey));
        }
        #endregion

        private void ChangeImgByKey(Bean.Ico ico)
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
            PbName.Image = BeanUtil.ReadImage(path, BeanUtil.NaN16);
        }
    }
}
