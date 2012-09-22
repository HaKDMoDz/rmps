using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;
using Me.Amon.Kms.Target;

namespace Me.Amon.Kms.Robot
{
    public class KmsRobot : IRobot
    {
        private DataModel _DataModel;
        #region 全局变量
        /// <summary>
        /// 线程控制：是否运行中
        /// </summary>
        private bool _Running;
        /// <summary>
        /// 线程控制：是否暂停中
        /// </summary>
        private bool _Halted;

        private Random _Random;
        private ITarget _Target;
        private Dictionary<long, MSession> _Sessions;

        private KmsHuman _TxtHuman;
        #endregion

        #region 对外接口

        public AKms TrayPtn { get; set; }

        public EMethod Method { get; set; }

        /// <summary>
        /// 显示逐步提示
        /// </summary>
        public bool HintByStep { get; set; }

        public KmsRobot(DataModel dataModel)
        {
            _DataModel = dataModel;
        }

        public void AppendTarget(ITarget target)
        {
            _Target = target;
        }

        public void RemoveTarget(ITarget target)
        {
            _Target = null;
        }

        /// <summary>
        /// 会话处理
        /// </summary>
        /// <param name="target"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool Deal(ITarget target, MRequest request)
        {
            _Target = target;
            Answer(null, request);
            return true;
        }

        public bool Send(string text)
        {
            _Target.SendMessage(text);
            return true;
        }

        public bool Send(Image image)
        {
            _Target.SendMessage(image);
            return true;
        }

        public bool Work()
        {
            if (_Running)
            {
                return true;
            }

            if (TrayPtn == null)
            {
                return false;
            }

            MSolution sln = TrayPtn.Solution;

            // 方案为空判断
            if (sln == null)
            {
                _Target.ShowWarning("请选择会话方案！");
                return false;
            }

            // 标签资源：不指定标签时，使用所有标签
            if (sln.Category == null)
            {
                _Target.ShowWarning("请选择标签资源！");
                return false;
            }

            // 随机数生成器
            if (_Random == null)
            {
                _Random = new Random();
            }

            EMethod method = (Method == EMethod.None ? sln.Method : Method);
            if (method == EMethod.Active)
            {
                Active();
            }
            else if (method == EMethod.Attack)
            {
                var thread = new Thread(Attack);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }

            _Running = true;
            _Halted = false;
            return true;
        }

        public bool Halt()
        {
            if (!_Running)
            {
                return false;
            }

            _Halted = true;
            if (EMethod.Active == (Method == EMethod.None ? TrayPtn.Solution.Method : Method))
            {
                _TxtHuman.Enabled = false;
            }
            return true;
        }

        public bool Next()
        {
            if (!_Running)
            {
                return false;
            }

            _Halted = false;
            if (EMethod.Active == (Method == EMethod.None ? TrayPtn.Solution.Method : Method))
            {
                _TxtHuman.Enabled = true;
            }
            return true;
        }

        public bool Stop()
        {
            if (!_Running)
            {
                return true;
            }

            _Running = false;
            _Halted = false;
            if (EMethod.Active == (Method == EMethod.None ? TrayPtn.Solution.Method : Method))
            {
                _TxtHuman.Visible = false;
            }
            return true;
        }

        public bool Running
        {
            get
            {
                return _Running;
            }
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 是否随机选取发送
        /// </summary>
        public bool RandomSend { get; set; }

        /// <summary>
        /// 是否允许重复发送
        /// </summary>
        public bool RepeatSend { get; set; }

        #endregion

        #region 私有方法
        private void DoHalt()
        {
            while (_Halted)
            {
                Thread.Sleep(100);
            }
        }

        private void Answer(MSession session, MRequest request)
        {
            if (session.LastInput == request.RawInput)
            {
                session.RIndex += 1;
            }
            else
            {
                session.LastInput = request.RawInput;

                string t = Regex.Replace(request.RawInput, "\\s+", "");
                // 仅数字
                if (Regex.IsMatch(t, "^\\d+$"))
                {
                    return;
                }
                // 数学运算
                t = Regex.Replace(t, "[\\[\\{（【｛]", "(");
                t = Regex.Replace(t, "[\\]\\}）】｝]", ")");
                if (Regex.IsMatch('(' + t + ')', @"^(((?<o>\()[-+]?(\d+[-+*/])*)+\d+((?<-o>\))([-+*/]\d+)*)+($|[-+*/]))*(?(o)(?!))$"))
                {
                    return;
                }

                session.Question.Clear();
                session.QIndex = 0;
                _DataModel.FindQuestion(session.Question, session.LastInput, session.Style, session.Language, session.Category);
                if (session.Question.Count < 1)
                {
                    _Target.SendMessage(session.LastInput);
                    return;
                }

                session.Response.Clear();
                session.RIndex = 0;
                _DataModel.FindResponse(session.Response, session.Question[0].P3100103, session.Style, session.Language, session.Category);
                if (session.Response.Count < 1)
                {
                    _Target.SendMessage(session.LastInput);
                    return;
                }
            }

            _Target.SendMessage(session.Response[session.RIndex].P3100105);
        }

        private void Active()
        {
            if (_TxtHuman == null)
            {
                _TxtHuman = new KmsHuman(TrayPtn, this, _DataModel);
            }
            _TxtHuman.Start();
        }

        private void Attack()
        {
            MSolution sln = TrayPtn.Solution;
            // 语言资源
            sln.Sentence = _DataModel.ListSentence(sln.Category);
            if (sln.Sentence.Count < 1)
            {
                _Target.ShowWarning("大哥，$robot_name$没的可说，给点提示吧！");
                return;
            }

            int cnt = sln.Sentence.Count;
            int idx = 0;
            if (!RandomSend)
            {
                while (_Running && idx < cnt)
                {
                    DoHalt();

                    _Target.SendMessage(sln.Sentence[idx].P3100105);

                    idx += 1;
                    if (sln.Intval > 0)
                    {
                        Thread.Sleep(sln.Intval * 1000);
                    }
                }
            }
            else
            {
                while (_Running && cnt > 0)
                {
                    DoHalt();

                    idx = _Random.Next(cnt);
                    _Target.SendMessage(sln.Sentence[idx].P3100105);
                    if (!RepeatSend)
                    {
                        sln.Sentence.RemoveAt(idx);
                    }

                    cnt -= 1;
                    if (sln.Intval > 0)
                    {
                        Thread.Sleep(sln.Intval * 1000);
                    }
                }
            }

            _Running = false;
            _Halted = false;
            TrayPtn.SessionClose();
        }
        #endregion
    }
}
