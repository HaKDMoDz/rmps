using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Auth;
using Me.Amon.Da.Df;
using Me.Amon.M;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.User.Uc
{
    /// <summary>
    /// 单机注册
    /// </summary>
    public partial class SignPc : UserControl, ISignAc
    {
        private AUserModel _UserModel;
        private ADataModel _DataModel;
        private DFEngine _Prop;
        private SignAc _SignAc;

        #region 构造函数
        public SignPc()
        {
            InitializeComponent();
        }

        public SignPc(SignAc signAc, AUserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();

            TbPath.Text = Path.Combine(_UserModel.SysHome, CApp.DIR_DATA);
            _SignAc.ShowTips(BtPath, "选择目录");
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
                Main.ShowAlert("请输入用户名！");
                TbName.Focus();
                return;
            }

            if (name.Length < 5)
            {
                Main.ShowAlert("用户名不能少于5个字符！");
                TbName.Focus();
                return;
            }

            if (!Regex.IsMatch(name, "^\\w{5,}$"))
            {
                Main.ShowAlert("用户名中含有非法字符！");
                TbName.Focus();
                return;
            }

            name = name.ToLower();
            string sysFile = Path.Combine(_UserModel.SysHome, CApp.AMON_SYS);
            _Prop = new DFEngine();
            _Prop.Load(sysFile);
            string home = _Prop.Get(string.Format(CApp.AMON_SYS_HOME, name));
            if (!string.IsNullOrEmpty(home))
            {
                Main.ShowAlert(string.Format("已存在名为 {0} 的用户，请尝试其它用户名！", name));
                return;
            }
            #endregion

            #region 口令判断
            string pass = TbPass1.Text;
            TbPass1.Text = "";
            if (string.IsNullOrEmpty(pass))
            {
                Main.ShowAlert("请输入登录口令！");
                TbPass1.Focus();
                return;
            }

            if (pass.Length < 4)
            {
                Main.ShowAlert("登录口令不能少于4个字符！");
                TbPass1.Text = "";
                TbPass2.Text = "";
                TbPass1.Focus();
                return;
            }

            if (pass != TbPass2.Text)
            {
                TbPass2.Text = "";
                Main.ShowAlert("您两次输入的口令不一致！");
                TbPass1.Focus();
                return;
            }
            TbPass2.Text = "";
            #endregion

            #region 路径判断
            home = TbPath.Text;
            if (string.IsNullOrEmpty(home))
            {
                Main.ShowAlert("请选择您的数据存放目录！");
                BtPath.Focus();
                return;
            }
            #endregion

            #region 代码
            string code = CApp.USER_AMON;
            if (Directory.Exists(Path.Combine(home, code)))
            {
                Main.ShowAlert(string.Format("指定路径下已存在名为 {0} 的目录！", code));
                return;
            }
            #endregion

            _SignAc.ShowWaiting();

            try
            {
                // 本地注册
                if (!_UserModel.CaSignUp(home, code, name, pass))
                {
                    pass = null;
                    _SignAc.HideWaiting();
                    Main.ShowAlert("系统异常，请稍后重试！");
                    return;
                }

                _Prop.Set(string.Format(CApp.AMON_SYS_CODE, name), _UserModel.Code);
                home = _UserModel.DatHome;
                if (home.StartsWith(Application.StartupPath))
                {
                    home = home.Substring(Application.StartupPath.Length + 1);
                }
                _Prop.Set(string.Format(CApp.AMON_SYS_HOME, name), home);
                _Prop.Save(sysFile);

                InitDat();
            }
            catch (Exception exp)
            {
                _SignAc.HideWaiting();
                Main.ShowAlert(exp.Message);
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
            fd.Description = "请选择您要存放数据的目录：";
            fd.SelectedPath = TbPath.Text;
            if (DialogResult.OK != fd.ShowDialog())
            {
                return;
            }
            string path = fd.SelectedPath;
            if (string.IsNullOrEmpty(path))
            {
                Main.ShowAlert("请选择数据存放目录！");
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
                    Main.ShowAlert(exp.Message);
                    BtPath.Focus();
                    return;
                }
            }
            TbPath.Text = path;
        }
        #endregion

        #region 私有函数
        private void InitDat()
        {
            _UserModel.Load();
            BeanUtil.UnZip(CApp.FILE_DAT, _UserModel.DatHome);
            _DataModel = new ADataModel(_UserModel);
            _DataModel.Init();

            string file;
            StreamReader stream;
            XmlReaderSettings setting = new XmlReaderSettings { IgnoreWhitespace = true };

            #region 字符
            file = Path.Combine(_UserModel.DatHome, "App-Udc.xml");
            if (File.Exists(file))
            {
                stream = new StreamReader(file);
                using (XmlReader reader = XmlReader.Create(stream, setting))
                {
                    Udc udc;
                    while (reader.Name == "Udc" || reader.ReadToFollowing("Udc"))
                    {
                        udc = new Udc();
                        if (!udc.FromXml(reader))
                        {
                            continue;
                        }
                        _DataModel.SaveVcs(udc);
                    }
                }
                stream.Close();
            }
            #endregion

            #region 类别
            file = Path.Combine(_UserModel.DatHome, "App-Cat.xml");
            if (File.Exists(file))
            {
                stream = new StreamReader(file);
                using (XmlReader reader = XmlReader.Create(stream, setting))
                {
                    Cat cat;
                    while (reader.Name == "Cat" || reader.ReadToFollowing("Cat"))
                    {
                        cat = new Cat();
                        if (!cat.FromXml(reader))
                        {
                            continue;
                        }
                        _DataModel.SaveVcs(cat);
                    }
                }
                stream.Close();
            }
            #endregion

            #region 模板
            file = Path.Combine(_UserModel.DatHome, "WPwd-Lib.xml");
            if (File.Exists(file))
            {
                stream = new StreamReader(file);
                using (XmlReader reader = XmlReader.Create(stream, setting))
                {
                    Lib header;
                    while (reader.Name == "Lib" || reader.ReadToFollowing("Lib"))
                    {
                        header = new Lib();
                        if (!header.FromXml(reader))
                        {
                            continue;
                        }
                        _DataModel.SaveVcs(header);
                    }
                }
                stream.Close();
            }
            #endregion

            #region 目录
            file = Path.Combine(_UserModel.DatHome, "WPwd-Dir.xml");
            if (File.Exists(file))
            {
                stream = new StreamReader(file);
                using (XmlReader reader = XmlReader.Create(stream, setting))
                {
                    Dir dir;
                    while (reader.Name == "Dir" || reader.ReadToFollowing("Dir"))
                    {
                        dir = new Dir();
                        if (!dir.FromXml(reader))
                        {
                            continue;
                        }
                        _DataModel.SaveVcs(dir);
                    }
                }
                stream.Close();
            }
            #endregion

            _DataModel.Dispose();
            _SignAc.CallBack(CApp.IAPP_WPWD);
        }
        #endregion
    }
}
