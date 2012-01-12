using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.User
{
    public partial class SignUp : Form
    {
        private string _Name;
        private string _Pass;
        private string _Code;
        private SafeModel _SafeModel;
        private Uc.Properties _Prop;

        public SignUp()
        {
            InitializeComponent();
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
                    reader.ReadToFollowing("error");
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
            }
        }

        private void BtOk_Click(object sender, System.EventArgs e)
        {

        }

        private void BtNo_Click(object sender, System.EventArgs e)
        {

        }

        private void ShowAlert(string alert)
        {
        }

        private void DoSignUp()
        {
            _Name = TbName.Text;

            #region 用户名判断
            if (string.IsNullOrEmpty(_Name))
            {
                ShowAlert("请输入用户名！");
                TbName.Focus();
                return;
            }

            if (_Name.Length < 5)
            {
                ShowAlert("用户名不能少于5个字符！");
                TbName.Focus();
                return;
            }

            if (!Regex.IsMatch(_Name, "^\\w{5,}$"))
            {
                ShowAlert("用户名中含有非法字符！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 口令判断
            _Pass = TbPass1.Text;
            if (string.IsNullOrEmpty(_Pass))
            {
                ShowAlert("请输入登录口令！");
                TbPass1.Focus();
                return;
            }

            if (_Pass.Length < 4)
            {
                ShowAlert("登录口令不能少于4个字符！");
                TbPass1.Text = "";
                TbPass2.Text = "";
                TbPass1.Focus();
                return;
            }

            if (_Pass != TbPass2.Text)
            {
                ShowAlert("您两次输入的口令不一致！");
                TbPass1.Text = "";
                TbPass2.Text = "";
                TbPass1.Focus();
                return;
            }
            #endregion

            // 口令散列
            _Pass = SafeUtil.EncryptPass(_Pass);

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignUp_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=sup&n=" + _Name + "&k=" + _Pass);
        }

        private void SignUp_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            string xml = e.Result;
            int view = 0;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<error>") > 0)
                {
                    reader.ReadToFollowing("error");
                    return;
                }

                reader.ReadToFollowing("code");
                _Code = reader.ReadElementContentAsString();

                _Pass = reader.ReadElementContentAsString();

                view = reader.ReadElementContentAsInt();
            }

            UserModel userModel = new UserModel();
            if (userModel.SignUp(_Name, _Pass, _Code))
            {
                userModel.Init();
                userModel.View = view;
            }
        }
    }
}
