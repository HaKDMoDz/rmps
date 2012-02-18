using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using Me.Amon.Const;
using Me.Amon.Model;
using Me.Amon.Utils;
using Me.Amon.Win;

namespace Me.Amon.Views.User
{
    public partial class SignIn : UserControl, IView
    {
        private string _Name;
        private string _Pass;
        private MainPage _Main;

        #region 构造函数
        public SignIn()
        {
            InitializeComponent();
        }

        public SignIn(MainPage main)
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
        /// 登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            DoSignIn();
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

        private void DoSignIn()
        {
            _Name = TbName.Text;
            _Pass = tbPass.Password;

            if (string.IsNullOrEmpty(_Name))
            {
                return;
            }

            if (string.IsNullOrEmpty(_Pass))
            {
                return;
            }

            BeanUtil.ShowLoading();

            // 口令散列
            _Pass = SafeUtil.EncryptPass(_Pass);

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignInDownloadStringCompleted);
            client.UploadStringAsync(new Uri(EnvConst.SERVER_PATH), "POST", "&o=sin&n=" + _Name + "&k=" + _Pass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignInDownloadStringCompleted(object sender, System.Net.UploadStringCompletedEventArgs e)
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

                if (!reader.ReadToFollowing("code"))
                {
                    return;
                }
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
            if (userMdl.SignIn(_Name, pass, code))
            {
                userMdl.View = view;
                userMdl.LibKey = libKey;

                _Main.ShowUser();

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
                tbPass.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPass_GotFocus(object sender, RoutedEventArgs e)
        {
            tbPass.SelectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPass_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                DoSignIn();
            }
        }
        #endregion
    }
}
