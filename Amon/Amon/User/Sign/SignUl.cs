using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Model;

namespace Me.Amon.User.Sign
{
    /// <summary>
    /// 脱机注册
    /// </summary>
    public partial class SignUl : UserControl, ISignAc
    {
        private UserModel _UserModel;
        private SignAc _SignAc;

        public SignUl()
        {
            InitializeComponent();
        }

        public SignUl(SignAc signAc, UserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();

            TbPath.Text = IEnv.DATA_DIR + Path.DirectorySeparatorChar;
        }

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public void DoSignAc()
        {
            #region 用户判断
            string name = TbName.Text;
            if (string.IsNullOrEmpty(name))
            {
                _SignAc.ShowAlert("请输入登录用户！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 登录口令
            string pass = "qqqq";
            #endregion

            #region 路径判断
            string path = TbPath.Text;
            if (string.IsNullOrEmpty(path))
            {
                path = IEnv.DATA_DIR;
            }
            if (!Directory.Exists(path))
            {
                _SignAc.ShowAlert("无法访问路径！");
                BtPath.Focus();
                return;
            }
            #endregion

            #region 认证信息
            string text = TbInfo.Text;
            if (string.IsNullOrEmpty(text))
            {
                _SignAc.ShowAlert("请输入认证数据！");
                TbInfo.Focus();
                return;
            }
            #endregion

            try
            {
                if (!_UserModel.CaSignWs(path, name, pass, text))
                {
                    string msg = "无效的认证数据！";
                    _SignAc.ShowAlert(msg);
                    TbInfo.Focus();
                    return;
                }

                Uc.Properties prop = new Uc.Properties();
                prop.Load(IEnv.AMON_SYS);
                prop.Set(string.Format(IEnv.AMON_SYS_HOME, name), path);
                prop.Set(string.Format(IEnv.AMON_SYS_CODE, name), _UserModel.Code);
                prop.Save(IEnv.AMON_SYS);
            }
            catch (Exception exp)
            {
                _SignAc.ShowAlert(exp.Message);
                TbInfo.Focus();
                return;
            }
        }

        public void DoCancel()
        {
            _SignAc.ShowView(ESignAc.SignIn);
        }

        public void ShowMenu(Control control, int x, int y)
        {
        }
        #endregion

        private void BtPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.SelectedPath = TbPath.Text;
            if (DialogResult.OK != fd.ShowDialog())
            {
                return;
            }
            string path = fd.SelectedPath;
            if (string.IsNullOrEmpty(path))
            {
                _SignAc.ShowAlert("请选择数据存放目录！");
                BtPath.Focus();
                return;
            }
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception exp)
                {
                    _SignAc.ShowAlert(exp.Message);
                    BtPath.Focus();
                    return;
                }
            }
            if (path[path.Length - 1] != Path.DirectorySeparatorChar)
            {
                path += Path.DirectorySeparatorChar;
            }
            TbPath.Text = path;
        }
    }
}
