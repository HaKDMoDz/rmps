using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using Me.Amon.C;
using Me.Amon.Da;
using Me.Amon.Da.Db;
using Me.Amon.Da.Df;
using Me.Amon.Gtd.M;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.M
{
    public sealed class UserModel : AUserModel
    {
        #region 用户配置
        /// <summary>
        /// 剪贴板驻留时间
        /// </summary>
        public int ResidenceDuration { get; set; }
        /// <summary>
        /// 备份文件数量
        /// </summary>
        public int BackFileCount { get; set; }
        /// <summary>
        /// 自动填充快捷键
        /// </summary>
        public string AutoFillKey { get; set; }
        /// <summary>
        /// 口令长度
        /// </summary>
        public int PasswordLength { get; set; }
        /// <summary>
        /// 默认字符空间
        /// </summary>
        public string PasswordUdc { get; set; }
        /// <summary>
        /// 提醒检测间隔
        /// </summary>
        public int NoticeInterval { get; set; }

        #endregion

        private bool IsStartup;

        #region 数据初始化
        public override void Init()
        {
            if (File.Exists("Amon.tag"))
            {
                SysHome = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "阿木密码箱");
                if (!Directory.Exists(SysHome))
                {
                    Directory.CreateDirectory(SysHome);
                }
            }
            else
            {
                SysHome = Environment.CurrentDirectory;
            }

            ResHome = SysHome;
            BakHome = Path.Combine(SysHome, CApp.DIR_BACK);

            if (File.Exists(CApp.FILE_VER))
            {
                BeanUtil.UnZip(CApp.FILE_RES, ResHome);
                BeanUtil.UnZip("Amon.lib", "Lib");
                File.Delete(CApp.FILE_VER);
            }
            if (!Directory.Exists(Path.Combine(SysHome, "Skin")))
            {
                BeanUtil.UnZip(CApp.FILE_RES, ResHome);
            }

            IsStartup = true;
        }

        public override void Load()
        {
            ODBEngine dba = new ODBEngine();
            dba.DbInit(this);
            if (dba.DbVersion.Version != 2)
            {
                dba.Upgrade();
            }
            DBA = dba;

            DFEngine dfa = new DFEngine();
            //dfa.Init(this);
            DFA = dfa;

            BackFileCount = 3;
            NoticeInterval = 5;
            //_Timer = new Timer(new TimerCallback(Timer_Callback), null, 5000, 1000);
        }
        #endregion

        /// <summary>
        /// 网络访问
        /// </summary>
        /// <param name="data"></param>
        public void Post(string data)
        {
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            //client.UploadStringAsync(new Uri(EnvConst.SERVER_PATH), "POST", "c=" + Code + "&t=" + _Token + data);
        }

        public void Suspend()
        {
            Monitor.Enter(_SyncObj);
            _MGtds = null;
            DBA.Suspend();
        }

        public void Resume()
        {
            DBA.Resume();
            Monitor.Exit(_SyncObj);
        }

        #region 任务提醒
        private List<AmonHandler<string>> _Hints = new List<AmonHandler<string>>();
        public void AppendHandler(AmonHandler<string> handler)
        {
            foreach (AmonHandler<string> h in _Hints)
            {
                if (h == handler)
                {
                    return;
                }
            }
            _Hints.Add(handler);
        }

        public void RemoveHandler(AmonHandler<string> handler)
        {
            _Hints.Remove(handler);
        }

        private Timer _Timer;
        private IList<MGtd> _MGtds;
        private int _TodoCnt;
        private int _PastCnt;
        private int _Delay;
        private string _SyncObj = "";
        private void Timer_Callback(object state)
        {
            if (DBA.Suspended)
            {
                return;
            }

            bool locked = false;

            Monitor.TryEnter(_SyncObj, ref locked);
            if (!locked)
            {
                return;
            }
            //Monitor.Enter(_SyncObj);

            try
            {
                DateTime now = DateTime.Now;

                if (_Delay < 1 || _MGtds == null)
                {
                    _MGtds = DBA.ListGtdWithRef();
                    _Delay = NoticeInterval;

                    // 启动事件
                    if (IsStartup)
                    {
                        foreach (Gtd.M.MGtd gtd in _MGtds)
                        {
                            if (gtd.NextEvent(now, Gtd.CGtd.EVENT_LOAD))
                            {
                                DBA.SaveVcs(gtd);
                            }
                        }
                        IsStartup = false;
                    }
                }

                _TodoCnt = 0;
                _PastCnt = 0;

                foreach (Gtd.M.MGtd gtd in _MGtds)
                {
                    if (gtd.Test(now, 43200))//12 * 60 * 60
                    {
                        DBA.SaveVcs(gtd);
                    }
                    if (gtd.Status == Gtd.CGtd.STATUS_ONTIME)
                    {
                        _TodoCnt += 1;
                        continue;
                    }
                    if (gtd.Status == Gtd.CGtd.STATUS_EXPIRED)
                    {
                        _PastCnt += 1;
                        continue;
                    }
                }

                string info;
                if (_PastCnt > 0 && _TodoCnt > 0)
                {
                    info = string.Format("您有 {0} 个过期事项及 {1} 个待办事项！", _PastCnt, _TodoCnt);
                }
                else if (_PastCnt > 0)
                {
                    info = string.Format("您有 {0} 个过期事项", _PastCnt);
                }
                else if (_TodoCnt > 0)
                {
                    info = string.Format("您有 {0} 个待办事项", _TodoCnt);
                }
                else
                {
                    info = "您目前没有需要提醒的事项。";
                }

                foreach (AmonHandler<string> hint in _Hints)
                {
                    hint(info);
                }
                _Delay -= 1;

                //Monitor.Pulse(_SyncObj);
            }
            finally
            {
                Monitor.Exit(_SyncObj);
            }
        }

        public void ReloadGtds()
        {
            try
            {
                Monitor.Enter(_SyncObj);
                _Delay = 0;
            }
            finally
            {
                Monitor.Exit(_SyncObj);
            }
        }
        #endregion
    }
}
