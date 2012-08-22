
namespace Me.Amon.Gtd
{
    public class CGtd
    {
        #region 类型
        #region 主类型
        /// <summary>
        /// 时间型
        /// </summary>
        public const int TYPE_MAJOR_DATES = 1;
        /// <summary>
        /// 事件型
        /// </summary>
        public const int TYPE_MAJOR_EVENT = 2;
        /// <summary>
        /// 公式型
        /// </summary>
        public const int TYPE_MAJOR_MATHS = 3;
        #endregion

        #region 辅类型
        /// <summary>
        /// 每隔
        /// </summary>
        public const int TYPE_MINOR_EACH = 1;
        /// <summary>
        /// 每到
        /// </summary>
        public const int TYPE_MINOR_WHEN = 2;
        #endregion
        #endregion

        #region 单位
        #region 主单位
        /// <summary>
        /// 无
        /// </summary>
        public const int UNIT_MAJOR_NONE = 0;
        /// <summary>
        /// 秒
        /// </summary>
        public const int UNIT_MAJOR_SECOND = 1;
        /// <summary>
        /// 分
        /// </summary>
        public const int UNIT_MAJOR_MINUTE = 2;
        /// <summary>
        /// 时
        /// </summary>
        public const int UNIT_MAJOR_HOUR = 3;
        /// <summary>
        /// 日
        /// </summary>
        public const int UNIT_MAJOR_DAY = 4;
        /// <summary>
        /// 周
        /// </summary>
        public const int UNIT_MAJOR_WEEK = 5;
        /// <summary>
        /// 月
        /// </summary>
        public const int UNIT_MAJOR_MONTH = 6;
        /// <summary>
        /// 季
        /// </summary>
        public const int UNIT_MAJOR_SEASON = 7;
        /// <summary>
        /// 年
        /// </summary>
        public const int UNIT_MAJOR_YEAR = 8;
        /// <summary>
        /// 月周
        /// </summary>
        public const int UNIT_MAJOR_WEEKOFMONTH = 9;
        /// <summary>
        /// 年周
        /// </summary>
        public const int UNIT_MAJOR_WEEKOFYEAR = 10;
        #endregion

        #region 辅单位
        /// <summary>
        /// 按月
        /// </summary>
        public const int UNIT_MINOR_BYMONTH = 1;
        /// <summary>
        /// 按季
        /// </summary>
        public const int UNIT_MINOR_BYSEASON = 2;
        /// <summary>
        /// 按年
        /// </summary>
        public const int UNIT_MINOR_BYYEAR = 3;
        #endregion
        #endregion

        #region 重复
        /// <summary>
        /// 重复
        /// </summary>
        public const int LIMIT_REPEAT = 1;
        /// <summary>
        /// 结束
        /// </summary>
        public const int LIMIT_ENDING = 2;
        #endregion

        #region 重复
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

        #region 状态
        /// <summary>
        /// 过期
        /// </summary>
        public const int GTD_STAT_EXPIRED = 2;
        /// <summary>
        /// 到点
        /// </summary>
        public const int GTD_STAT_ONTIME = 1;
        /// <summary>
        /// 未到
        /// </summary>
        public const int GTD_STAT_NORMAL = 0;
        /// <summary>
        /// 暂停
        /// </summary>
        public const int GTD_STAT_SUSPEND = -1;
        /// <summary>
        /// 完成
        /// </summary>
        public const int GTD_STAT_FINISHED = -2;
        #endregion

        #region 事件
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

        #region 结束
        /// <summary>
        /// 无效
        /// </summary>
        public const int END_TYPE_NONE = 0;
        /// <summary>
        /// 永远
        /// </summary>
        public const int END_TYPE_EVER = 1;
        /// <summary>
        /// 重复
        /// </summary>
        public const int END_TYPE_LOOP = 2;
        /// <summary>
        /// 定时
        /// </summary>
        public const int END_TYPE_TIME = 3;
        #endregion
    }
}
