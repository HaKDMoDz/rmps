using System;
using System.Collections.Generic;
using System.Threading;
using Me.Amon.C;
using Me.Amon.Da;
using Me.Amon.Da.Db;
using Me.Amon.Gtd;
using Me.Amon.Gtd.M;
using Me.Amon.Util;

namespace Me.Amon.M
{
    public class ADataModel
    {
        protected Main _Main;
        protected AUserModel _UserModel;
        protected DBA _DbEngine;
        private bool IsStartup;

        public ADataModel()
        {
        }

        public ADataModel(AUserModel userModel)
        {
            _UserModel = userModel;
        }

        public void Init()
        {
            _DbEngine = new ODBEngine();
            _DbEngine.DbInit(_UserModel);

            UdcList = new List<Udc>();
            UdcList.Add(new Udc { IsSys = true, Id = "AUDC000000000001", Name = "仅数字", Tips = "仅数字", Data = "0123456789" });
            UdcList.Add(new Udc { IsSys = true, Id = "AUDC000000000002", Name = "大写字母", Tips = "大写字母", Data = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            UdcList.Add(new Udc { IsSys = true, Id = "AUDC000000000003", Name = "小写字母", Tips = "小写字母", Data = "abcdefghijklmnopqrstuvwxyz" });
            UdcList.Add(new Udc { IsSys = true, Id = "AUDC000000000004", Name = "大小写字母", Tips = "大小写字母", Data = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            UdcList.Add(new Udc { IsSys = true, Id = "AUDC000000000005", Name = "数字及字母", Tips = "数字及字母", Data = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            UdcList.Add(new Udc { IsSys = true, Id = "AUDC000000000006", Name = "可输入英文符号", Tips = "可输入英文符号", Data = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~" });
            foreach (Udc udc in _DbEngine.Query<Udc>())
            {
                UdcList.Add(udc);
            }

            string _UdcKey = "AUDC000000000005";
            foreach (Udc item in UdcList)
            {
                if (item.Id == _UdcKey)
                {
                    DefaultUdc = item;
                }
            }

            UdcModified = 0x7FFFFFFF;
        }

        #region 数据更新
        public void Save(object obj)
        {
            _DbEngine.Save(obj);
        }

        public void SaveVcs(Vcs vcs)
        {
            if (vcs.Operate == DBConst.OPT_DEFAULT)
            {
                vcs.Version += 1;
            }

            if (vcs.Operate > DBConst.OPT_INSERT)
            {
                vcs.Operate += 1;
            }

            vcs.UserCode = _UserModel.Code;
            vcs.UpdateTime = DateTime.Now;
            if (!CharUtil.IsValidateHash(vcs.Id))
            {
                vcs.Id = HashUtil.UtcTimeInEnc(false);
                vcs.CreateTime = vcs.UpdateTime;
            }
            _DbEngine.Save(vcs);
        }

        public void SaveLog(Log log)
        {
            log.Id = HashUtil.UtcTimeInEnc(false);
            log.LogTime = DateTime.Now;
            _DbEngine.Save(log);
        }
        #endregion

        #region 数据删除
        public void RemoveVcs(Vcs vcs)
        {
            vcs.Operate = DBConst.OPT_DELETE;
            vcs.Version += 1;
            _DbEngine.Save(vcs);
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="vcs"></param>
        public void DeleteVcs(Vcs vcs)
        {
            _DbEngine.Delete(vcs);
        }

        public void DeleteLog(Log log)
        {
            _DbEngine.Delete(log);
        }
        #endregion

        #region 连接管理
        public void Suspend()
        {
            Monitor.Enter(_SyncObj);
            _MGtds = null;
            _DbEngine.Suspend();
        }

        public void Resume()
        {
            _DbEngine.Resume();
            Monitor.Exit(_SyncObj);
        }

        public void Dispose()
        {
            _DbEngine.CloseConnect();
        }
        #endregion

        #region 任务提醒
        public void Start()
        {
            if (_Timer == null)
            {
                _Timer = new Timer(Timer_Callback);
            }
            _Timer.Change(5000, 1000);
        }

        public void Stop()
        {
        }

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
            if (_DbEngine.Suspended)
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
                    _MGtds = ListGtdWithRef();
                    _Delay = _UserModel.NoticeInterval;

                    // 启动事件
                    if (IsStartup)
                    {
                        foreach (Gtd.M.MGtd gtd in _MGtds)
                        {
                            if (gtd.NextEvent(now, Gtd.CGtd.EVENT_LOAD))
                            {
                                SaveVcs(gtd);
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
                        SaveVcs(gtd);
                    }
                    if (gtd.Status == Gtd.CGtd.STATUS_ONTIME)
                    {
                        _TodoCnt += 1;
                        if (_Main != null)
                        {
                            _Main.ShowFlicker();
                            _Main.ShowBubbleTips(gtd.Title);
                        }
                        continue;
                    }
                    if (gtd.Status == Gtd.CGtd.STATUS_NOTICE)
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

        #region 类别操作
        public Cat ReadCat(string catId)
        {
            IList<Cat> cats = _DbEngine.Query<Cat>(delegate(Cat cat)
            {
                return cat.Id == catId;
            });

            return cats.Count > 0 ? cats[0] : null;
        }

        public IList<Cat> FindCat(string appId, string catMeta)
        {
            if (string.IsNullOrEmpty(catMeta))
            {
                return null;
            }
            string[] arr = catMeta.ToLower().Split(' ', ',', ';');
            IList<Cat> cats = _DbEngine.Query<Cat>(
                delegate(Cat cat)
                {
                    return cat.AppId == appId && Contains(cat.Meta.ToLower(), arr);
                },
                delegate(Cat a, Cat b)
                {
                    return a.Order.CompareTo(b.Order);
                });
            return cats;
        }

        public IList<Cat> ListCat(string appId, string parentId)
        {
            if (string.IsNullOrWhiteSpace(parentId))
            {
                return _DbEngine.Query<Cat>();
            }

            return _DbEngine.Query<Cat>(
                delegate(Cat cat)
                {
                    return cat.AppId == appId && cat.Parent == parentId;
                },
                delegate(Cat a, Cat b)
                {
                    return a.Order.CompareTo(b.Order);
                });
        }
        #endregion

        #region 字符操作
        /// <summary>
        /// 字符集列表
        /// </summary>
        public IList<Udc> UdcList { get; private set; }

        /// <summary>
        /// 字符集长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 字符集状态
        /// </summary>
        public int UdcModified { get; set; }

        /// <summary>
        /// 默认字符集
        /// </summary>
        public Udc DefaultUdc { get; set; }
        #endregion

        #region 私有函数
        protected bool Contains(string src, string[] arr)
        {
            foreach (string tmp in arr)
            {
                if (!src.Contains(tmp))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        public IList<MGtd> ListGtdWithRef()
        {
            IList<MGtd> gtds = _DbEngine.Query<MGtd>(
                delegate(MGtd gtd)
                {
                    if (gtd.UserCode != _UserModel.Code)
                    {
                        return false;
                    }
                    return gtd.Status > CGtd.STATUS_SUSPEND && CharUtil.IsValidateHash(gtd.RefId);
                });
            return gtds;
        }
    }
}
