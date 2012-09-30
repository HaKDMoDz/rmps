using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Target.Net
{
    public class NetTarget : ITarget
    {
        private NetWindow _NetWindow;

        #region ITarget 成员

        public ETarget Target
        {
            get { return ETarget.Kms; }
        }

        public string TargetName
        {
            get { return "网络消息"; }
        }

        public bool HintByStep
        {
            get;
            set;
        }

        public Main TrayWin
        {
            get;
            set;
        }

        public bool Start()
        {
            if (_NetWindow == null)
            {
                _NetWindow = new NetWindow();
            }
            return false;
        }

        public bool Prepare(List<MFunction> functions)
        {
            return true;
        }

        public void SendMessage(string text)
        {
        }

        public void SendMessage(Image image)
        {
        }

        public void ShowWarning(string text)
        {
            MessageBox.Show(_NetWindow, text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult ShowConfirm(string text)
        {
            return MessageBox.Show(_NetWindow, text, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public bool Confirm(List<MFunction> functions)
        {
            return true;
        }

        public bool Close()
        {
            return false;
        }

        #endregion


        protected void invoke_Click()
        {
            //httpRequest.UserRemoteIP = Request.UserHostAddress;
            //string basic = "http://api.t.sina.com.cn/";
            //string url = "";
            //switch (0)
            //{
            //    case 0:
            //        url += "statuses/public_timeline.xml";
            //        break;
            //    case 1:
            //        url += "statuses/friends_timeline.xml";
            //        break;
            //    case 2:
            //        url += "statuses/user_timeline.xml";
            //        break;
            //    case 3:
            //        url += "statuses/mentions.xml";
            //        break;
            //    case 4:
            //        url += "statuses/comments_timeline.xml";
            //        break;
            //    case 5:
            //        url += "statuses/comments_by_me.xml";
            //        break;
            //    case 6:
            //        url += "statuses/followers.xml";
            //        break;
            //    default:
            //        break;
            //}
            //this.resultText.Text = _HttpGet.Request(url, String.Empty);
        }

        protected void update_Click()
        {
            //var url = "http://api.t.sina.com.cn/statuses/update.xml?";
            //resultTextBox2.Text = httpRequest.Request(url, "status=" + HttpUtility.UrlEncode(statusText.Text));
        }

        private string getIP()
        {
            IPAddress[] ipAddr = Dns.GetHostAddresses(Dns.GetHostName());
            return ipAddr.Length == 1 ? ipAddr[0].ToString() : ipAddr[1].ToString();
        }
    }
}
