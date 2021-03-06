﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Auth;
using Me.Amon.Da.Df;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.User.Uc
{
    /// <summary>
    /// 脱机注册
    /// </summary>
    public partial class SignUl : UserControl, ISignAc
    {
        private AUserModel _UserModel;
        private SignAc _SignAc;

        #region 构造函数
        public SignUl()
        {
            InitializeComponent();
        }

        public SignUl(SignAc signAc, AUserModel userModel)
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
                Main.ShowAlert("请输入【登录用户】！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 登录口令
            string pass = TbPass.Text;
            if (string.IsNullOrEmpty(pass))
            {
                Main.ShowAlert("请输入【登录口令】！");
                TbPass.Focus();
                return;
            }
            if (pass.Length < 4)
            {
                Main.ShowAlert("【登录口令】不能少于 4 个字符！");
                TbPass.Focus();
                return;
            }
            #endregion

            #region 路径判断
            string path = TbPath.Text;
            if (string.IsNullOrEmpty(path))
            {
                path = CApp.DIR_DATA;
            }
            if (!Directory.Exists(path))
            {
                Main.ShowAlert("无法访问路径！");
                BtPath.Focus();
                return;
            }
            #endregion

            #region 认证信息
            string text = TbText.Text;
            if (string.IsNullOrEmpty(text))
            {
                Main.ShowAlert("请输入认证数据！");
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
                    path = Path.Combine(path, code);
                    if (Directory.Exists(path))
                    {
                        _SignAc.HideWaiting();
                        Main.ShowAlert(string.Format("指定路径下已存在名为 {0} 的目录！", code));
                        return;
                    }
                    Directory.CreateDirectory(path);

                    if (!_UserModel.WsSignIn(path, code, name, pass, reader))
                    {
                        Main.ShowAlert("请确认您输入的令牌数据是否有效！");
                        TbPath.Focus();
                        return;
                    }
                }

                string sysFile = Path.Combine(_UserModel.SysHome, CApp.AMON_SYS);
                DFEngine prop = new DFEngine();
                prop.Load(sysFile);
                prop.Set(string.Format(CApp.AMON_SYS_CODE, name), _UserModel.Code);
                path = _UserModel.DatHome;
                if (path.StartsWith(Application.StartupPath))
                {
                    path = path.Substring(Application.StartupPath.Length + 1);
                }
                prop.Set(string.Format(CApp.AMON_SYS_HOME, name), _UserModel.DatHome);
                prop.Save(sysFile);

                InitDat();
            }
            catch (Exception exp)
            {
                _SignAc.HideWaiting();
                Main.ShowAlert(exp.Message);
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

        private void InitDat()
        {
            _UserModel.Load();
            BeanUtil.UnZip(CApp.FILE_DAT, _UserModel.DatHome);

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

            _SignAc.CallBack(CApp.IAPP_WPWD);
        }
    }
}
