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
    public partial class SignPc : UserControl, ISignAc
    {
        private UserModel _UserModel;
        private SignAc _SignAc;

        public SignPc()
        {
            InitializeComponent();
        }

        public SignPc(SignAc signAc, UserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();
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

            string code;
            string info;
            string data;
            try
            {
                string msg = "无效的认证数据！";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(text);
                XmlNode node = doc.SelectSingleNode("/Amon/User/Code");
                if (node == null)
                {
                    _SignAc.ShowAlert(msg);
                    TbInfo.Focus();
                    return;
                }
                code = node.Value;
                if (!Regex.IsMatch(code, "^[A-Z0-9]{8}$"))
                {
                    _SignAc.ShowAlert(msg);
                    TbInfo.Focus();
                    return;
                }

                node = doc.SelectSingleNode("/Amon/User/Info");
                if (node == null)
                {
                    _SignAc.ShowAlert(msg);
                    TbInfo.Focus();
                    return;
                }
                info = node.Value;
                if (!Regex.IsMatch(info, "^[A-Za-z0-9+/]{44}$"))
                {
                    _SignAc.ShowAlert(msg);
                    TbInfo.Focus();
                    return;
                }

                node = doc.SelectSingleNode("/Amon/User/Data");
                if (node == null)
                {
                    _SignAc.ShowAlert(msg);
                    TbInfo.Focus();
                    return;
                }
                data = node.Value;
                if (!Regex.IsMatch(data, "^[A-Za-z0-9+/]{108}$"))
                {
                    _SignAc.ShowAlert(msg);
                    TbInfo.Focus();
                    return;
                }
            }
            catch (Exception exp)
            {
                _SignAc.ShowAlert(exp.Message);
                TbInfo.Focus();
                return;
            }
            #endregion

            _UserModel.SignNw(path, code, info, data);

            Uc.Properties prop = new Uc.Properties();
            prop.Load(IEnv.AMON_CFG);
            prop.Set(string.Format("amon.{0}.code", name), path);
            prop.Set(string.Format("amon.{0}.code", name), code);
            prop.Save(IEnv.AMON_CFG);
        }

        public void DoCancel()
        {
            _SignAc.ShowView(ESignAc.SignIn);
        }
        #endregion

        private void BtPath_Click(object sender, EventArgs e)
        {

        }
    }
}
