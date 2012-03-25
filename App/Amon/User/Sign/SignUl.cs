using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.User.Sign
{
    /// <summary>
    /// 脱机注册
    /// </summary>
    public partial class SignUl : UserControl, ISignAc
    {
        private UserModel _UserModel;
        private SignAc _SignAc;

        #region 构造函数
        public SignUl()
        {
            InitializeComponent();
        }

        public SignUl(SignAc signAc, UserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();

            TbPath.Text = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), IEnv.DIR_DATA);
        }
        #endregion

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
                _SignAc.ShowAlert("请输入【登录用户】！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 登录口令
            string pass = TbPass.Text;
            if (string.IsNullOrEmpty(pass))
            {
                _SignAc.ShowAlert("请输入【登录口令】！");
                TbPass.Focus();
                return;
            }
            if (pass.Length < 4)
            {
                _SignAc.ShowAlert("【登录口令】不能少于 4 个字符！");
                TbPass.Focus();
                return;
            }
            #endregion

            #region 路径判断
            string path = TbPath.Text;
            if (string.IsNullOrEmpty(path))
            {
                path = IEnv.DIR_DATA;
            }
            if (!Directory.Exists(path))
            {
                _SignAc.ShowAlert("无法访问路径！");
                BtPath.Focus();
                return;
            }
            #endregion

            #region 认证信息
            string text = TbText.Text;
            if (string.IsNullOrEmpty(text))
            {
                _SignAc.ShowAlert("请输入认证数据！");
                TbPath.Focus();
                return;
            }
            #endregion

            try
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(text)))
                {
                    if (text.IndexOf("<Error>") > 0)
                    {
                        _SignAc.HideWaiting();
                        reader.ReadToFollowing("Error");
                        _SignAc.ShowAlert(reader.ReadElementContentAsString());
                        return;
                    }

                    string code = null;
                    if (reader.Name == "Code" || reader.ReadToFollowing("Code"))
                    {
                        code = reader.ReadElementContentAsString();
                    }
                    if (!CharUtil.IsValidateCode(code))
                    {
                        _SignAc.HideWaiting();
                        _SignAc.ShowAlert("注册用户失败，请稍后重试！");
                        return;
                    }
                    path = Path.Combine(path, code);
                    if (Directory.Exists(path))
                    {
                        _SignAc.HideWaiting();
                        _SignAc.ShowAlert(string.Format("指定路径下已存在名为 {0} 的目录！", code));
                        return;
                    }
                    Directory.CreateDirectory(path);

                    if (!_UserModel.WsSignIn(path, code, name, pass, reader))
                    {
                        _SignAc.ShowAlert("请确认您输入的令牌数据是否有效！");
                        TbPath.Focus();
                        return;
                    }
                }

                DFAccess prop = new DFAccess();
                prop.Load(IEnv.AMON_SYS);
                prop.Set(string.Format(IEnv.AMON_SYS_CODE, name), _UserModel.Code);
                prop.Set(string.Format(IEnv.AMON_SYS_HOME, name), _UserModel.Home);
                prop.Save(IEnv.AMON_SYS);

                InitDat();
            }
            catch (Exception exp)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(exp.Message);
                TbPath.Focus();
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

        #region 事件处理
        private void BtPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.SelectedPath = TbPass.Text;
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
            TbPath.Text = path;
        }
        #endregion

        private void InitDat()
        {
            _UserModel.Init();
            BeanUtil.UnZip("Amon.dat", _UserModel.Home);

            //var tmp = '\'' + _UserModel.Code + '\'';
            //var dba = _UserModel.DBObject;

            //string file = Path.Combine(_UserModel.Home, "dat.sql");
            //StreamReader reader = File.OpenText(file);
            //string line = reader.ReadLine();
            //while (line != null)
            //{
            //    dba.AddBatch(line.Replace("'A0000000'", tmp));
            //    line = reader.ReadLine();
            //}
            //reader.Close();
            //File.Delete(file);

            //dba.ExecuteBatch();

            _SignAc.CallBack(IEnv.IAPP_APWD);
        }
    }
}
