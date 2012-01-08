using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using Me.Amon.Apwd.Const;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Utils;
using Me.Amon.Apwd.Win;

namespace Me.Amon.Apwd.Views.User
{
    public partial class SignUp : UserControl, IView
    {
        private string _Name;
        private string _Pass;
        private MainPage _Main;

        #region 构造函数
        public SignUp()
        {
            InitializeComponent();
        }

        public SignUp(MainPage main)
        {
            _Main = main;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public string ViewName
        {
            get
            {
                return "User";
            }
        }

        public bool InitView(MainPage main)
        {
            _Main = main;
            _Main.Show(this);
            return true;
        }

        public void InitData()
        {
            TbName.Focus();
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            DoSignUp();
        }

        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btNo_Click(object sender, RoutedEventArgs e)
        {
            Home.Home view = new Home.Home();
            view.InitView(_Main);
            view.InitData();
        }

        private void DoSignUp()
        {
            _Name = TbName.Text;

            #region 用户名判断
            if (string.IsNullOrEmpty(_Name))
            {
                BeanUtil.ShowAlert("请输入用户名！");
                TbName.Focus();
                return;
            }

            if (_Name.Length < 5)
            {
                BeanUtil.ShowAlert("用户名不能少于5个字符！");
                TbName.Focus();
                return;
            }

            if (!Regex.IsMatch(_Name, "^\\w{5,}$"))
            {
                BeanUtil.ShowAlert("用户名中含有非法字符！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 口令判断
            _Pass = tbPass1.Password;
            if (string.IsNullOrEmpty(_Pass))
            {
                BeanUtil.ShowAlert("请输入登录口令！");
                tbPass1.Focus();
                return;
            }

            if (_Pass.Length < 4)
            {
                BeanUtil.ShowAlert("登录口令不能少于4个字符！");
                tbPass1.Password = "";
                tbPass2.Password = "";
                tbPass1.Focus();
                return;
            }

            if (_Pass != tbPass2.Password)
            {
                BeanUtil.ShowAlert("您两次输入的口令不一致！");
                tbPass1.Password = "";
                tbPass2.Password = "";
                tbPass1.Focus();
                return;
            }
            #endregion

            BeanUtil.ShowLoading();

            // 口令散列
            _Pass = SafeUtil.EncryptPass(_Pass);

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignUpDownloadStringCompleted);
            client.UploadStringAsync(new Uri(EnvConst.SERVER_PATH), "POST", "&o=sup&n=" + _Name + "&k=" + _Pass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUpDownloadStringCompleted(object sender, System.Net.UploadStringCompletedEventArgs e)
        {
            string xml = e.Result;
            string code = null;
            string pass = null;
            int view = 0;
            List<LibHeader> libKey = new List<LibHeader>();
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<error>") > 0)
                {
                    BeanUtil.HideLoading();
                    reader.ReadToFollowing("error");
                    BeanUtil.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                reader.ReadToFollowing("code");
                code = reader.ReadElementContentAsString();

                pass = reader.ReadElementContentAsString();

                view = reader.ReadElementContentAsInt();

                if (reader.Name == "libs" || reader.ReadToNextSibling("libs"))
                {
                    while (reader.ReadToFollowing("lib"))
                    {
                        LibHeader header = new LibHeader();
                        header.FromXml(reader);
                        libKey.Add(header);

                        if (reader.Name == "atts" || reader.ReadToNextSibling("atts"))
                        {
                            List<LibDetail> libD = new List<LibDetail>();
                            if (reader.ReadToDescendant("att"))
                            {
                                LibDetail detail = new LibDetail();
                                detail.FromXml(reader);
                                libD.Add(detail);
                            }
                            while (reader.ReadToNextSibling("att"))
                            {
                                LibDetail detail = new LibDetail();
                                detail.FromXml(reader);
                                libD.Add(detail);
                            }
                            header.Details = libD;
                        }
                    }
                }
            }

            UserModel userMdl = new UserModel();
            if (userMdl.SignUp(_Name, pass, code))
            {
                userMdl.View = view;
                userMdl.LibKey = libKey;
                Awin mpwd = new Awin(userMdl);
                mpwd.InitView(_Main);
                mpwd.InitData();
            }
        }
        #endregion

        #region 交互事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbName_GotFocus(object sender, RoutedEventArgs e)
        {
            TbName.SelectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbName_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                tbPass1.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPass1_GotFocus(object sender, RoutedEventArgs e)
        {
            tbPass1.SelectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPass1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                tbPass2.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPass2_GotFocus(object sender, RoutedEventArgs e)
        {
            tbPass2.SelectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPass2_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                DoSignUp();
            }
        }
        #endregion
    }
}
