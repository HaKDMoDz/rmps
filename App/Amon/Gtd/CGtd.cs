
namespace Me.Amon.Gtd
{
    public class CGtd
    {
        #region 类型
        /// <summary>
        /// 未定义
        /// </summary>
        public const int TYPE_NONE = 0;
        /// <summary>
        /// 事件型
        /// </summary>
        public const int TYPE_EVENT = 1;
        /// <summary>
        /// 公式型
        /// </summary>
        public const int TYPE_MATHS = 2;
        /// <summary>
        /// 时间型
        /// </summary>
        public const int TYPE_DATES = 3;
        #endregion

        #region 单位
        /// <summary>
        /// 无
        /// </summary>
        public const int UNIT_NONE = 0;
        /// <summary>
        /// 秒
        /// </summary>
        public const int UNIT_SECOND = 1;
        /// <summary>
        /// 分
        /// </summary>
        public const int UNIT_MINUTE = 2;
        /// <summary>
        /// 时
        /// </summary>
        public const int UNIT_HOUR = 3;
        /// <summary>
        /// 日
        /// </summary>
        public const int UNIT_DAY = 4;
        /// <summary>
        /// 周
        /// </summary>
        public const int UNIT_WEEK = 5;
        /// <summary>
        /// 月
        /// </summary>
        public const int UNIT_MONTH = 6;
        /// <summary>
        /// 季
        /// </summary>
        public const int UNIT_SEASON = 7;
        /// <summary>
        /// 年
        /// </summary>
        public const int UNIT_YEAR = 8;
        /// <summary>
        /// 月周
        /// </summary>
        public const int UNIT_WEEKOFMONTH = 9;
        /// <summary>
        /// 年周
        /// </summary>
        public const int UNIT_WEEKOFYEAR = 10;
        #endregion

        #region 结束
        /// <summary>
        /// 无效
        /// </summary>
        public const int END_TYPE_NONE = 0;
        /// <summary>
        /// 永远
        /// </summary>
        public const int END_TYPE_EVER = -1;
        /// <summary>
        /// 重复
        /// </summary>
        public const int END_TYPE_LOOP = -2;
        /// <summary>
        /// 定时
        /// </summary>
        public const int END_TYPE_TIME = -3;
        #endregion

        #region 状态
        /// <summary>
        /// 过期
        /// </summary>
        public const int STATUS_EXPIRED = 3;
        /// <summary>
        /// 到点
        /// </summary>
        public const int STATUS_ONTIME = 2;
        /// <summary>
        /// 提示
        /// </summary>
        public const int STATUS_NOTICE = 1;
        /// <summary>
        /// 未到
        /// </summary>
        public const int STATUS_NORMAL = 0;
        /// <summary>
        /// 暂停
        /// </summary>
        public const int STATUS_SUSPEND = -1;
        /// <summary>
        /// 完成
        /// </summary>
        public const int STATUS_FINISHED = -2;
        #endregion

        #region 提示
        /// <summary>
        /// 未知
        /// </summary>
        public const int HINT_TYPE_NONE = 0;
        /// <summary>
        /// 提示
        /// </summary>
        public const int HINT_TYPE_TIPS = 1;
        /// <summary>
        /// 程序
        /// </summary>
        public const int HINT_TYPE_APPS = 2;
        /// <summary>
        /// 邮件
        /// </summary>
        public const int HINT_TYPE_MAIL = 3;
        #endregion

        #region 日期类型
        /// <summary>
        /// 未知
        /// </summary>
        public const int DATES_TYPE_NONE = 0;
        /// <summary>
        /// 每隔
        /// </summary>
        public const int DATES_TYPE_EACH = 1;
        /// <summary>
        /// 每到
        /// </summary>
        public const int DATES_TYPE_WHEN = 2;
        #endregion

        #region 事件类型
        /// <summary>
        /// 未知
        /// </summary>
        public const int EVENT_NONE = 0;
        /// <summary>
        /// 启动后
        /// </summary>
        public const int EVENT_LOAD = 1;
        /// <summary>
        /// 复原后
        /// </summary>
        public const int EVENT_SHOW = 2;
        /// <summary>
        /// 隐藏前
        /// </summary>
        public const int EVENT_HIDE = 3;
        /// <summary>
        /// 退出前
        /// </summary>
        public const int EVENT_EXIT = 4;
        #endregion
    }
}
