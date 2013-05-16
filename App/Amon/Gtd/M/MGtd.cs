using System;
using System.Collections.Generic;
using Me.Amon.M;

namespace Me.Amon.Gtd.M
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public class MGtd : Vcs
    {
        #region 基本信息
        /// <summary>
        /// 显示排序
        /// </summary>
        public int Order;
        /// <summary>
        /// 任务类型
        /// </summary>
        public int Type;
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Subject;
        /// <summary>
        /// 相关说明
        /// </summary>
        public string Content;
        /// <summary>
        /// 项目
        /// </summary>
        public string Project;
        /// <summary>
        /// 任务级别
        /// </summary>
        public int Priority;
        /// <summary>
        /// 任务状态
        /// </summary>
        public int Status;
        /// <summary>
        /// 完成度
        /// </summary>
        public int Percent;
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartTime;
        /// <summary>
        /// 备注
        /// </summary>
        public List<Memo> Memos;
        /// <summary>
        /// 相关标签
        /// </summary>
        public string[] Tags;
        #endregion

        #region 重复控制
        /// <summary>
        /// 重复方式
        /// </summary>
        public int EndType;
        /// <summary>
        /// 执行次数
        /// </summary>
        public int ExeCount;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime;
        /// <summary>
        /// 上次时间
        /// </summary>
        public DateTime LastTime;
        #endregion

        #region 提醒方式
        /// <summary>
        /// 提示方式
        /// </summary>
        public int HintType;
        /// <summary>
        /// 执行参数
        /// </summary>
        public string Command;
        /// <summary>
        /// 附加参数
        /// </summary>
        public string Params;
        #endregion

        #region 高级特性
        /// <summary>
        /// 可否共用
        /// </summary>
        public bool Shared;
        /// <summary>
        /// 上级任务
        /// </summary>
        public string SupGtd;
        /// <summary>
        /// 前置任务
        /// </summary>
        public string PreGtd;
        /// <summary>
        /// 相关引用
        /// </summary>
        public string RefId;
        #endregion

        public MGtd()
        {
            Dates = new List<ADates>();

            Events = new List<int>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="opt"></param>
        /// <returns>状态是否发生改变：true是，false否</returns>
        public bool Test(DateTime time, int opt)
        {
            if (Status != CGtd.STATUS_NORMAL && Status != CGtd.STATUS_NOTICE)
            {
                return false;
            }

            if (Type == CGtd.TYPE_DATES)
            {
                return TestDates(time, opt);
            }
            if (Type == CGtd.TYPE_MATHS)
            {
                return TestMaths(time);
            }
            if (Type == CGtd.TYPE_EVENT)
            {
                return TestEvent(time);
            }
            return false;
        }

        public bool Next(DateTime time, int opt)
        {
            if (Status < CGtd.STATUS_NOTICE)
            {
                return false;
            }

            if (Type == CGtd.TYPE_DATES)
            {
                return NextDates(time);
            }
            if (Type == CGtd.TYPE_MATHS)
            {
                return NextMaths(time);
            }
            if (Type == CGtd.TYPE_EVENT)
            {
                return NextEvent(time, opt);
            }
            return false;
        }

        #region 时间型
        /// <summary>
        /// 下次时间
        /// </summary>
        public DateTime NextTime;
        /// <summary>
        /// 是否提前
        /// </summary>
        public int PrePose;
        /// <summary>
        /// 提前间隔
        /// </summary>
        public int PreTime;
        /// <summary>
        /// 数值列表
        /// </summary>
        public List<ADates> Dates { get; private set; }

        private bool TestDates(DateTime time, int length)
        {
            // 计算下次提醒时间
            //if (NextTime == DateTime.MinValue)
            if (NextTime < StartTime)
            {
                NextTime = StartTime;
            }

            // 判断是否过期
            if (Status == CGtd.STATUS_NOTICE)
            {
                if (time > NextTime)
                {
                    Status = CGtd.STATUS_EXPIRED;
                    return true;
                }
                return false;
            }

            #region 提前
            switch (PrePose)
            {
                case CGtd.UNIT_SECOND:
                    time = time.AddSeconds(PreTime);
                    break;
                case CGtd.UNIT_MINUTE:
                    time = time.AddMinutes(PreTime);
                    break;
                case CGtd.UNIT_HOUR:
                    time = time.AddHours(PreTime);
                    break;
                case CGtd.UNIT_DAY:
                    time = time.AddDays(PreTime);
                    break;
                case CGtd.UNIT_WEEK:
                    time = time.AddDays(PreTime * 7);
                    break;
                case CGtd.UNIT_MONTH:
                    time = time.AddMonths(PreTime);
                    break;
                case CGtd.UNIT_YEAR:
                    time = time.AddYears(PreTime);
                    break;
            }
            #endregion

            if (time >= NextTime)
            {
                Status = CGtd.STATUS_ONTIME;
                return true;
            }
            if (time >= NextTime.AddSeconds(-length))
            {
                Status = CGtd.STATUS_NOTICE;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 计算下次时间
        /// </summary>
        /// <param name="time">当前时间</param>
        /// <returns></returns>
        private bool NextDates(DateTime time)
        {
            // 没有重复
            if (EndType == CGtd.END_TYPE_NONE)
            {
                Status = CGtd.STATUS_FINISHED;
                return true;
            }

            // 计数
            if (EndType == CGtd.END_TYPE_LOOP)
            {
                ExeCount -= 1;
                if (ExeCount < 1)
                {
                    Status = CGtd.STATUS_FINISHED;
                    return true;
                }
            }

            // 定时
            if (EndType == CGtd.END_TYPE_TIME)
            {
                if (time > EndTime)
                {
                    Status = CGtd.STATUS_FINISHED;
                    return true;
                }
            }

            // 到点，取下次时间
            if (Status == CGtd.STATUS_NOTICE)
            {
                time = NextTime;
            }

            bool changed = false;
            foreach (ADates date in Dates)
            {
                NextTime = date.Next(time, out changed);
                if (!changed)
                {
                    break;
                }
            }

            // 定时
            if (EndType == CGtd.END_TYPE_TIME)
            {
                if (NextTime > EndTime)
                {
                    Status = CGtd.STATUS_FINISHED;
                    return true;
                }
            }

            Status = CGtd.STATUS_NORMAL;
            return true;
        }
        #endregion

        #region 事件型
        /// <summary>
        /// 事件列表
        /// </summary>
        public List<int> Events { get; private set; }

        private bool TestEvent(DateTime time)
        {
            return false;
        }

        /// <summary>
        /// 计算下次时间
        /// </summary>
        /// <param name="time"></param>
        public bool NextEvent(DateTime time, int type)
        {
            foreach (int evt in Events)
            {
                if (evt != type)
                {
                    continue;
                }

                if (EndType == CGtd.END_TYPE_EVER)
                {
                    NextTime = time;
                    Status = CGtd.STATUS_NOTICE;
                    return true;
                }
                if (EndType == CGtd.END_TYPE_LOOP)
                {
                    ExeCount -= 1;
                    NextTime = time;
                    Status = ExeCount < 0 ? CGtd.STATUS_FINISHED : CGtd.STATUS_NOTICE;
                    return true;
                }
                if (EndType == CGtd.END_TYPE_TIME)
                {
                    NextTime = time;
                    Status = time > EndTime ? CGtd.STATUS_FINISHED : CGtd.STATUS_NOTICE;
                    return true;
                }
            }

            Status = CGtd.STATUS_NORMAL;
            return true;
        }
        #endregion

        #region 公式型
        /// <summary>
        /// 计算公式 
        /// </summary>
        public string Maths;

        private bool TestMaths(DateTime time)
        {
            return false;
        }

        private bool NextMaths(DateTime time)
        {
            return false;
        }
        #endregion

        public override bool FromXml(System.Xml.XmlReader reader)
        {
            return true;
        }

        public override bool ToXml(System.Xml.XmlWriter writer)
        {
            return true;
        }

        public override string ToString()
        {
            return Subject;
        }
    }
}