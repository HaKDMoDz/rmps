using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;
using Me.Amon.Kms.Robot.cal;
using Me.Amon.Kms.V;

namespace Me.Amon.Kms.Target.Man
{
    public partial class ManWindow : Form
    {
        private UserModel _UserModel;
        private DataModel _DataModel;

        #region 全局变量
        private MagicPtn _MagicPtn;
        private Main _TrayPtn;
        private MSession _Session;
        private EOptions _Options;
        #endregion

        public ManWindow()
        {
            InitializeComponent();
        }

        public ManWindow(Main trayPtn, DataModel dataModel)
        {
            _TrayPtn = trayPtn;
            _DataModel = dataModel;

            InitializeComponent();
        }

        #region 用户事件
        private void BtSend_Click(object sender, EventArgs e)
        {
            string text = TbText.Text;
            TbText.Focus();
            if (string.IsNullOrEmpty(text))
            {
                ShowNotice("不能发送空的消息！");
                return;
            }
            text = Regex.Replace(text, "\r\n?", "\n");

            #region Append Question
            if (_Options == EOptions.AppendQuestion)
            {
                var question = new MSentence();
                question.P3100102 = _Session.Style;
                question.P3100104 = _Session.Language;
                question.P3100105 = _Session.LastInput;
                question.P3100106 = Trim(_Session.LastInput);
                _DataModel.SaveSentence(question);
                _Session.Question.Add(question);
                _Session.QIndex = _Session.Question.Count - 1;

                MSentence response = _DataModel.FindSentence(text);
                if (response == null)
                {
                    response = new MSentence();
                    response.P3100102 = _Session.Style;
                    response.P3100104 = _Session.Language;
                    response.P3100105 = text;
                    response.P3100106 = Trim(text);
                    _DataModel.SaveSentence(response);
                }
                _Session.Response.Add(response);
                //_session.RIndex = _session.Response.Count - 1;

                _DataModel.AppendResponse(question.P3100103, response.P3100103);
                TbText.Text = "";
                ShowOptions(EOptions.UpdateCategory, "给您的回答加个标签吧！");
                return;
            }
            #endregion

            #region Update Question
            if (_Options == EOptions.UpdateQuestion)
            {
                MSentence question = _Session.Question[_Session.QIndex];
                question.P3100105 = text;
                _DataModel.SaveSentence(question);

                TbText.Text = "";
                ShowOptions(EOptions.Default, "谢谢您的更新，$robot_name$会做得更好！");
                return;
            }
            #endregion

            #region Append Response
            if (_Options == EOptions.AppendResponse)
            {
                MSentence question = _Session.Question[0];

                MSentence response = _DataModel.FindSentence(_UserModel.Encode(text));
                if (response == null)
                {
                    response = new MSentence();
                    response.P3100102 = _Session.Style;
                    response.P3100104 = _Session.Language;
                    response.P3100105 = text;
                    response.P3100106 = Trim(text);
                    _DataModel.SaveSentence(response);
                }
                else
                {
                    _DataModel.RemoveResponse(question.P3100103, response.P3100103);
                }
                _Session.Response.Add(response);
                //_session.RIndex = _session.Response.Count - 1;

                _DataModel.AppendResponse(question.P3100103, response.P3100103);
                TbText.Text = "";
                ShowOptions(EOptions.UpdateCategory, "给您的回答加个标签吧！");
                return;
            }
            #endregion

            #region Update Response
            if (_Options == EOptions.UpdateResponse)
            {
                MSentence response = _Session.Response[_Session.RIndex];
                response.P3100105 = text;
                _DataModel.SaveSentence(response);

                TbText.Text = "";
                ShowOptions(EOptions.Default, "谢谢您的更新，$robot_name$会做得更好！");
                return;
            }
            #endregion

            #region Update Category
            if (_Options == EOptions.UpdateCategory)
            {
                string[] arr = text.Split(' ');
                if (arr.Length < 1)
                {
                    return;
                }

                List<MCategory> catList = _DataModel.SaveCategory(arr);
                _DataModel.SaveTags(_Session.Response[_Session.Response.Count - 1].P3100103, catList);
                TbText.Text = "";
                ShowOptions(EOptions.AppendResponse, "还有其它候选回答吗？您可继续输入哟！");
                return;
            }
            #endregion

            _Session.LastInput = text;
            SetAsnwerText("我：" + text);
            TbText.Text = "";

            // 为空检测
            if (string.IsNullOrEmpty(Trim(text)))
            {
                SendMessage(text);
                return;
            }

            string t = Regex.Replace(text, "\\s+", "");
            // 仅数字
            if (Regex.IsMatch(t, "^\\d+$"))
            {
                SendMessage("你好无聊呀，在这数数呢？");
                return;
            }
            // 数学运算
            if (t[t.Length - 1] == '=')
            {
                t = t.Substring(0, t.Length - 1);
            }
            t = Regex.Replace(t, "[\\[\\{（【｛]", "(");
            t = Regex.Replace(t, "[\\]\\}）】｝]", ")");
            if (Regex.IsMatch('(' + t + ')', @"^(((?<o>\()[-+]?(\d+[-+*/])*)+\d+((?<-o>\))([-+*/]\d+)*)+($|[-+*/]))*(?(o)(?!))$"))
            {
                SendMessage(new Mc(text, 3, null).calculate());
                return;
            }

            #region 正常问答
            // 查询提问
            _Session.Question.Clear();
            _Session.QIndex = 0;
            _DataModel.FindQuestion(_Session.Question, text, _Session.Style, _Session.Language, _Session.Category);
            if (_Session.Question.Count < 1)
            {
                ShowOptions(EOptions.AppendQuestion, "无法回答您的提问，教一下$robot_name$吧？");
                return;
            }

            // 查询应答
            _Session.Response.Clear();
            _Session.RIndex = 0;
            _DataModel.FindResponse(_Session.Response, _Session.Question[0].P3100103, _Session.Style, _Session.Language, _Session.Category);
            if (_Session.Response.Count < 1)
            {
                ShowOptions(EOptions.AppendResponse, "无法回答您的提问，教一下$robot_name$吧？");
                return;
            }
            #endregion

            SendMessage(_Session.Response[_Session.RIndex].P3100105);
            ShowOptions(EOptions.RateInfo, "您觉得这个回答怎么样？");
        }

        public void PrevResponse()
        {
            if (_Session.RIndex < 1)
            {
                ShowNotice("已经是第一个回答了！");
                return;
            }
            ShowNotice("第" + _Session.RIndex + "个回答！");
            _Session.RIndex -= 1;
            SetAsnwerText("$robot_name$：" + _Session.Response[_Session.RIndex].P3100105);
        }

        public void NextResponse()
        {
            if (_Session.RIndex > _Session.Response.Count - 2)
            {
                ShowNotice("已经是最后一个回答了！");
                return;
            }
            _Session.RIndex += 1;
            ShowNotice("第" + _Session.RIndex + "个回答！");
            SetAsnwerText("$robot_name$：" + _Session.Response[_Session.RIndex].P3100105);
        }

        public void RemoveResponse()
        {
            _DataModel.RemoveResponse(_Session.Question[_Session.QIndex].P3100103, _Session.Response[_Session.RIndex].P3100103);
            ShowOptions(EOptions.Default, "输入一个问，看$robot_name$回答的怎么样：");
        }

        public void UpdateResponse(int rate)
        {
            _DataModel.UpdateResponse(_Session.Question[_Session.QIndex].P3100103, _Session.Response[_Session.RIndex].P3100103, rate);
        }

        public void AppendResponse(string qId, string aId)
        {
            _DataModel.AppendResponse(qId, aId);
        }

        public void ChangeLanguage(string lanId)
        {
            _Session.Language = lanId;
        }

        public void ChangeStyle(EStyle style)
        {
            _Session.Style = style;
        }
        #endregion

        #region IManTarget 成员

        public void Start()
        {
            if (_Session == null)
            {
                _Session = new MSession();

                ShowOptions(EOptions.Default, "");
            }

            if (!_MagicPtn.Visible)
            {
                _MagicPtn.Visible = true;
            }
        }

        public new void Close()
        {
            Visible = false;
        }

        public void SendMessage(string text)
        {
            SetAsnwerText("$robot_name$：" + text);
        }

        public void ShowWarning(string text)
        {
            MessageBox.Show(this, text, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public DialogResult ShowConfirm(string text)
        {
            return MessageBox.Show(this, text, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public void ShowNotice(string notice)
        {
            SetNoticeText(notice);
        }

        private Dictionary<EOptions, IOptions> _ucList;
        public void ShowOptions(EOptions options, string notice)
        {
            SetNoticeText(notice);

            if (_ucList == null)
            {
                _ucList = new Dictionary<EOptions, IOptions>();
            }
            IOptions control;
            if (_ucList.ContainsKey(options))
            {
                control = _ucList[options];
            }
            else
            {
                switch (options)
                {
                    case EOptions.Default:
                        control = new BaseInfo(this, _DataModel);
                        _ucList[options] = control;
                        break;
                    case EOptions.Opinions:
                        control = new Opinions(this);
                        _ucList[options] = control;
                        break;
                    case EOptions.RateInfo:
                        control = new RateInfo(this);
                        _ucList[options] = control;
                        break;
                    case EOptions.AppendQuestion:
                        control = new Question(this);
                        _ucList[options] = control;
                        _ucList[EOptions.UpdateQuestion] = control;
                        break;
                    case EOptions.UpdateQuestion:
                        control = new Question(this);
                        _ucList[options] = control;
                        _ucList[EOptions.AppendQuestion] = control;
                        break;
                    case EOptions.AppendResponse:
                        control = new Response(this);
                        _ucList[options] = control;
                        _ucList[EOptions.UpdateResponse] = control;
                        break;
                    case EOptions.UpdateResponse:
                        control = new Response(this);
                        _ucList[options] = control;
                        _ucList[EOptions.AppendResponse] = control;
                        break;
                    case EOptions.UpdateCategory:
                        control = new Category(this, _DataModel);
                        _ucList[options] = control;
                        break;
                    default:
                        return;
                }
                control.Init();
            }

            _Options = options;
            ShowControl(control);

            MSentence question = _Session.Question.Count > 0 ? _Session.Question[_Session.QIndex] : null;
            MSentence response = _Session.Response.Count > 0 ? _Session.Response[_Session.RIndex] : null;
            control.ReInit(question, response);
            if (options == EOptions.Default)
            {
                TbText.Text = "";
                return;
            }
            if (options == EOptions.UpdateQuestion)
            {
                TbText.Text = question != null ? question.P3100105 : "";
                return;
            }
            if (options == EOptions.UpdateResponse)
            {
                TbText.Text = response != null ? response.P3100105 : "";
                return;
            }
        }

        private delegate void SetTextHandler(string text);
        private void SetAsnwerText(string text)
        {
            if (RbText.InvokeRequired)
            {
                RbText.Invoke(new SetTextHandler(SetAsnwerText), new object[] { text });
            }
            else
            {
                if (!string.IsNullOrEmpty(RbText.Text))
                {
                    RbText.AppendText(Environment.NewLine);
                }
                RbText.AppendText(_UserModel.Decode(text));
                RbText.ScrollToCaret();
            }
        }

        private void SetNoticeText(string text)
        {
            if (TbNote.InvokeRequired)
            {
                TbNote.Invoke(new SetTextHandler(SetNoticeText), new object[] { text });
            }
            else
            {
                TbNote.Text = _UserModel.Decode(text);
            }
        }

        private delegate void RelayoutHandler(IOptions options);
        private void ShowControl(IOptions options)
        {
            if (PlMisc.InvokeRequired)
            {
                PlMisc.Invoke(new RelayoutHandler(ShowControl), new object[] { options });
            }
            else
            {
                PlMisc.Controls.Clear();

                UserControl uc = options.GetControl();
                uc.AutoSize = true;
                uc.Dock = DockStyle.Fill;
                uc.Location = new System.Drawing.Point(0, 0);
                uc.Size = new System.Drawing.Size(272, 26);
                uc.TabIndex = 1;
                PlMisc.Controls.Add(uc);
            }
        }

        public bool IsTraining { get; set; }
        #endregion

        public static string Trim(string text)
        {
            return Regex.Replace(Regex.Replace(text, "[^\\w]+", ""), "[_]+", "");
        }
    }
}
