﻿using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Auth;
using Me.Amon.Da.Df;
using Me.Amon.Http;
using Me.Amon.M;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.User.Uc
{
    /// <summary>
    /// 联机注册
    /// </summary>
    public partial class SignOl : UserControl, ISignAc
    {
        private string _Name;
        private string _Mail;
        private string _Pass;
        private string _Root;
        private AUserModel _UserModel;
        private DataModel _DataModel;
        private DFEngine _Prop;
        private SignAc _SignAc;

        #region 构造函数
        public SignOl()
        {
            InitializeComponent();
        }

        public SignOl(SignAc signAc, AUserModel userModel)
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
            _Name = TbName.Text;
            if (string.IsNullOrEmpty(_Name))
            {
                Main.ShowAlert("请输入【登录用户】！");
                TbName.Focus();
                return;
            }
            if (!CharUtil.IsValidateName(_Name))
            {
                Main.ShowAlert("【登录用户】应在 4 到 32 个字符之间，且仅能为大小写字母、下划线及英文点号！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 用户邮件
            _Mail = TbMail.Text;
            if (string.IsNullOrEmpty(_Mail))
            {
                Main.ShowAlert("请输入【电子邮件】！");
                TbMail.Focus();
                return;
            }
            if (!CharUtil.IsValidateMail(_Mail))
            {
                Main.ShowAlert("请输入一个有效的【电子邮件】！");
                TbMail.Focus();
                return;
            }
            #endregion

            #region 口令判断
            _Pass = TbPass1.Text;
            TbPass1.Text = "";
            if (string.IsNullOrEmpty(_Pass))
            {
                Main.ShowAlert("请输入【登录口令】！");
                TbPass1.Focus();
                return;
            }

            if (_Pass.Length < 4)
            {
                Main.ShowAlert("【登录口令】不能少于 4 个字符！");
                TbPass1.Text = "";
                TbPass2.Text = "";
                TbPass1.Focus();
                return;
            }

            if (_Pass != TbPass2.Text)
            {
                TbPass2.Text = "";
                Main.ShowAlert("您两次输入的口令不一致！");
                TbPass1.Focus();
                return;
            }
            TbPass2.Text = "";
            #endregion

            #region 路径判断
            _Root = TbPath.Text;
            if (string.IsNullOrEmpty(_Root))
            {
                _Root = CApp.DIR_DATA;
            }
            #endregion

            _SignAc.ShowWaiting();

            #region 本地用户判断
            _Name = _Name.ToLower();
            _Prop = new DFEngine();
            _Prop.Load(Path.Combine(_UserModel.SysHome, CApp.AMON_SYS));
            string home = _Prop.Get(string.Format(CApp.AMON_SYS_HOME, _Name));
            if (!string.IsNullOrEmpty(home))
            {
                _SignAc.HideWaiting();
                Main.ShowAlert(string.Format("已存在名为 {0} 的用户，请尝试其它用户名！", _Name));
                TbName.Focus();
                return;
            }
            #endregion

            // 在线注册
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignUpV_UploadStringCompleted);
            client.UploadStringAsync(new Uri(CApp.SERVER_PATH), "POST", "&o=rsa&m=0");
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
        private void SignUpV_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                Main.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            string t = null;
            string d = null;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    Main.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                if (reader.Name == "t" || reader.ReadToFollowing("t"))
                {
                    t = reader.ReadElementContentAsString();
                }

                if (reader.Name == "k" || reader.ReadToFollowing("k"))
                {
                    d = reader.ReadElementContentAsString();
                }
            }

            d = Net(d);

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignUpS_UploadStringCompleted);
            client.UploadStringAsync(new Uri(CApp.SERVER_PATH), "POST", "&o=sup&t=" + t + "&d=" + d);
        }

        private void SignUpS_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                Main.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    Main.ShowAlert(reader.ReadElementContentAsString());
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
                    Main.ShowAlert("注册用户失败，请稍后重试！");
                    return;
                }
                _Root = Path.Combine(_Root, code);
                if (Directory.Exists(_Root))
                {
                    _SignAc.HideWaiting();
                    Main.ShowAlert(string.Format("指定路径下已存在名为 {0} 的目录！", code));
                    return;
                }
                Directory.CreateDirectory(_Root);

                if (!_UserModel.WsSignIn(_Root, code, _Name, _Pass, reader))
                {
                    _SignAc.HideWaiting();
                    Main.ShowAlert("注册用户失败，请稍后重试！");
                    TbName.Focus();
                }
                else
                {
                    string sysFile = Path.Combine(_UserModel.SysHome, CApp.AMON_SYS);
                    DFEngine prop = new DFEngine();
                    prop.Load(sysFile);
                    prop.Set(string.Format(CApp.AMON_SYS_CODE, _Name), _UserModel.Code);
                    prop.Set(string.Format(CApp.AMON_SYS_HOME, _Name), _UserModel.DatHome);
                    prop.Save(sysFile);

                    InitDat();
                }
            }

            _Pass = null;
        }

        private string Net(string t)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(t);

            byte[] b = Encoding.UTF8.GetBytes(_Name + '\n' + _Mail + '\n' + _Pass);
            b = rsa.Encrypt(b, false);
            return HttpUtil.ToBase64String(b);
        }

        private void InitDat()
        {
            _UserModel.Load();

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(InitCat_UploadStringCompleted);
            client.UploadStringAsync(new Uri(CApp.SERVER_PATH), "POST", "&o=cat&c=" + _UserModel.Code);
        }

        private void InitCat_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                Main.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    Main.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                Cat cat = new Cat();
                cat.UserCode = _UserModel.Code;
                while (reader.ReadToFollowing("Cat"))
                {
                    if (!cat.FromXml(reader))
                    {
                        continue;
                    }
                    _DataModel.SaveVcs(cat);
                }
            }

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(InitLib_UploadStringCompleted);
            client.UploadStringAsync(new Uri(CApp.SERVER_PATH), "POST", "&o=lib&c=" + _UserModel.Code);
        }

        private void InitLib_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                Main.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    Main.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                Lib header = new Lib();
                header.Order = 0;
                header.UserCode = _UserModel.Code;
                while (reader.ReadToFollowing("Lib"))
                {
                    if (!header.FromXml(reader))
                    {
                        continue;
                    }
                    _DataModel.SaveVcs(header);
                    header.Order += 1;
                }
            }

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(InitUdc_UploadStringCompleted);
            client.UploadStringAsync(new Uri(CApp.SERVER_PATH), "POST", "&o=udc&c=" + _UserModel.Code);
        }

        private void InitUdc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                Main.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    Main.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                Udc udc = new Udc();
                udc.UserCode = _UserModel.Code;
                while (reader.ReadToFollowing("Udc"))
                {
                    if (!udc.FromXml(reader))
                    {
                        continue;
                    }
                    _DataModel.SaveVcs(udc);
                }
            }

            BeanUtil.UnZip(CApp.FILE_DAT, _UserModel.DatHome);
            _SignAc.CallBack(CApp.IAPP_WPWD);
        }
        #endregion
    }
}
