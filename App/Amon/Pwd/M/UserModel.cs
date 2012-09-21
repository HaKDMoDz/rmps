using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using Me.Amon.C;
using Me.Amon.Da;
using Me.Amon.Da.Db;
using Me.Amon.Da.Df;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.M
{
    public sealed class UserModel : AUserModel
    {
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
        }

        public override void Load()
        {
            ODBEngine dba = new ODBEngine();
            dba.Init(this);
            DBA = dba;

            DFEngine dfa = new DFEngine();
            //dfa.Init(this);
            DFA = dfa;

            _Timer = new Timer(new TimerCallback(Timer_Callback), null, 5000, 1000);
        }

        /// <summary>
        /// 
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
            DBA.CloseConnect();
        }

        public void Resuma()
        {
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
        private IList<Gtd.MGtd> _MGtds;
        private int _TodoCnt = 0;
        private int _PastCnt = 0;
        private int _Delay = 5;
        private string _SyncObj = "";
        private void Timer_Callback(object state)
        {
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

                if (_MGtds == null)
                {
                    _MGtds = DBA.ListGtdWithRef();
                    foreach (Gtd.MGtd gtd in _MGtds)
                    {
                        if (gtd.NextEvent(now, Gtd.CGtd.EVENT_LOAD))
                        {
                            DBA.SaveVcs(gtd);
                        }
                    }
                }

                if (_Delay < 1)
                {
                    // 启动
                    _MGtds = DBA.ListGtdWithRef();
                    _Delay = 5;
                }

                _TodoCnt = 0;
                _PastCnt = 0;

                foreach (Gtd.MGtd gtd in _MGtds)
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
