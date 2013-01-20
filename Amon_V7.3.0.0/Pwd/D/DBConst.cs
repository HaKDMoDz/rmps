namespace Me.Amon.Da
{
    public class DBConst
    {
        /// <summary>
        /// 数据库常量：日期
        /// </summary>
        public const string SQL_NOW = "datetime('now')";
        public const string VER_DB = "1";

        public const int OPT_CONFUSE = -2;
        public const int OPT_DELETE = -1;
        public const int OPT_INSERT = 0;
        public const int OPT_DEFAULT = 1;
        public const int OPT_UPDATE = 2;
        public const int OPT_PWD_UPDATE_CAT = 3;
        public const int OPT_PWD_UPDATE_LABEL = 4;
        public const int OPT_PWD_UPDATE_MAJOR = 5;

        #region 类别
        #region 一级类别
        /// <summary>
        /// 一级类别
        /// </summary>
        public const string ACAT0100 = "ACAT0100";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string ACAT0101 = "ACAT0101";
        /// <summary>
        /// 系统索引
        /// </summary>
        public const string ACAT0102 = "ACAT0102";
        public const int ACAT0102_SIZE = 8;
        /// <summary>
        /// 类别索引
        /// </summary>
        public const string ACAT0103 = "ACAT0103";
        public const int ACAT0103_SIZE = 16;
        /// <summary>
        /// 类别名称
        /// </summary>
        public const string ACAT0104 = "ACAT0104";
        public const int ACAT0104_SIZE = 256;
        /// <summary>
        /// 类别提示
        /// </summary>
        public const string ACAT0105 = "ACAT0105";
        public const int ACAT0105_SIZE = 256;
        /// <summary>
        /// 类别键值
        /// </summary>
        public const string ACAT0106 = "ACAT0106";
        public const int ACAT0106_SIZE = 64;
        /// <summary>
        /// 类别描述
        /// </summary>
        public const string ACAT0107 = "ACAT0107";
        public const int ACAT0107_SIZE = 2048;
        /// <summary>
        /// 更新时间
        /// </summary>
        public const string ACAT0108 = "ACAT0108";
        /// <summary>
        /// 创建时间
        /// </summary>
        public const string ACAT0109 = "ACAT0109";
        #endregion

        #region 多级类别
        /// <summary>
        /// 多级类别
        /// </summary>
        public const string ACAT0200 = "ACAT0200";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string ACAT0201 = "ACAT0201";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const string ACAT0202 = "ACAT0202";
        public const int ACAT0202_SIZE = 8;
        /// <summary>
        /// 类别索引
        /// </summary>
        public const string ACAT0203 = "ACAT0203";
        public const int ACAT0203_SIZE = 16;
        /// <summary>
        /// 一级索引
        /// </summary>
        public const string ACAT0204 = "ACAT0204";
        public const int ACAT0204_SIZE = 16;
        /// <summary>
        /// 类别名称
        /// </summary>
        public const string ACAT0205 = "ACAT0205";
        public const int ACAT0205_SIZE = 256;
        /// <summary>
        /// 类别提示
        /// </summary>
        public const string ACAT0206 = "ACAT0206";
        public const int ACAT0206_SIZE = 256;
        /// <summary>
        /// 类别图标
        /// </summary>
        public const string ACAT0207 = "ACAT0207";
        public const int ACAT0207_SIZE = 16;
        /// <summary>
        /// 类别键值
        /// </summary>
        public const string ACAT0208 = "ACAT0208";
        public const int ACAT0208_SIZE = 64;
        /// <summary>
        /// 类别描述
        /// </summary>
        public const string ACAT0209 = "ACAT0209";
        public const int ACAT0209_SIZE = 2048;
        /// <summary>
        /// 更新时间
        /// </summary>
        public const string ACAT020A = "ACAT020A";
        /// <summary>
        /// 创建时间
        /// </summary>
        public const string ACAT020B = "ACAT020B";
        /// <summary>
        /// 版本控制
        /// </summary>
        public const string ACAT020C = "ACAT020C";
        /// <summary>
        /// 操作状态：0删除、1默认、2新增、3更新
        /// </summary>
        public const string ACAT020D = "ACAT020D";
        #endregion
        #endregion

        #region 密码箱
        #region 数据配置表格
        /// <summary>
        /// 数据配置表格
        /// </summary>
        public const string WPWD0000 = "WPWD0000";
        /// <summary>
        /// 一级索引
        /// </summary>
        public const string WPWD0001 = "WPWD0001";
        public const int WPWD0001_SIZE = 16;
        /// <summary>
        /// 二级索引
        /// </summary>
        public const string WPWD0002 = "WPWD0002";
        public const int WPWD0002_SIZE = 16;
        /// <summary>
        /// 配置信息
        /// </summary>
        public const string WPWD0003 = "WPWD0003";
        public const int WPWD0003_SIZE = 1024;
        /// <summary>
        /// 配置时间
        /// </summary>
        public const string WPWD0004 = "WPWD0004";
        #endregion

        #region 口令信息表格
        /// <summary>
        /// 口令信息表格
        /// </summary>
        public const string WPWD0100 = "WPWD0100";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string WPWD0101 = "WPWD0101";
        /// <summary>
        /// 使用状态
        /// </summary>
        public const string WPWD0102 = "WPWD0102";
        /// <summary>
        /// 紧要程度
        /// </summary>
        public const string WPWD0103 = "WPWD0103";
        /// <summary>
        /// 用户索引
        /// </summary>
        public const string WPWD0104 = "WPWD0104";
        public const int WPWD0104_SIZE = 8;
        /// <summary>
        /// 口令索引
        /// </summary>
        public const string WPWD0105 = "WPWD0105";
        public const int WPWD0105_SIZE = 16;
        /// <summary>
        /// 所属类别
        /// </summary>
        public const string WPWD0106 = "WPWD0106";
        public const int WPWD0106_SIZE = 16;
        /// <summary>
        /// 注册日期
        /// </summary>
        public const string WPWD0107 = "WPWD0107";
        public const int WPWD0107_SIZE = 24;
        /// <summary>
        /// 模板索引
        /// </summary>
        public const string WPWD0108 = "WPWD0108";
        public const int WPWD0108_SIZE = 16;
        /// <summary>
        /// 口令标题
        /// </summary>
        public const string WPWD0109 = "WPWD0109";
        public const int WPWD0109_SIZE = 256;
        /// <summary>
        /// 关键搜索
        /// </summary>
        public const string WPWD010A = "WPWD010A";
        public const int WPWD010A_SIZE = 1024;
        /// <summary>
        /// 口令图标
        /// </summary>
        public const string WPWD010B = "WPWD010B";
        public const int WPWD010B_SIZE = 16;
        /// <summary>
        /// 图标路径
        /// </summary>
        public const string WPWD010C = "WPWD010C";
        public const int WPWD010C_SIZE = 64;
        /// <summary>
        /// 图标说明
        /// </summary>
        public const string WPWD010D = "WPWD010D";
        public const int WPWD010D_SIZE = 1024;
        /// <summary>
        /// 提醒索引
        /// </summary>
        public const string WPWD010E = "WPWD010E";
        public const int WPWD010E_SIZE = 16;
        /// <summary>
        /// 提醒备注
        /// </summary>
        public const string WPWD010F = "WPWD010F";
        public const int WPWD010F_SIZE = 1024;
        /// <summary>
        /// 相关说明
        /// </summary>
        public const string WPWD0110 = "WPWD0110";
        public const int WPWD0110_SIZE = 2048;
        /// <summary>
        /// 访问日期
        /// </summary>
        public const string WPWD0111 = "WPWD0111";
        public const int WPWD0111_SIZE = 24;
        /// <summary>
        /// 是否备份
        /// </summary>
        public const string WPWD0112 = "WPWD0112";
        /// <summary>
        /// 加密版本
        /// </summary>
        public const string WPWD0113 = "WPWD0113";
        /// <summary>
        /// 版本控制
        /// </summary>
        public const string WPWD0114 = "WPWD0114";
        /// <summary>
        /// 操作状态：0删除、1默认、2新增、3更新
        /// </summary>
        public const string WPWD0115 = "WPWD0115";
        #endregion

        #region 口令内容表格
        /// <summary>
        /// 口令内容表格
        /// </summary>
        public const string WPWD0200 = "WPWD0200";
        /// <summary>
        /// 内容索引
        /// </summary>
        public const string WPWD0201 = "WPWD0201";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const string WPWD0202 = "WPWD0202";
        public const int WPWD0202_SIZE = 8;
        /// <summary>
        /// 口令索引
        /// </summary>
        public const string WPWD0203 = "WPWD0203";
        public const int WPWD0203_SIZE = 16;
        /// <summary>
        /// 口令内容
        /// </summary>
        public const string WPWD0204 = "WPWD0204";
        public const int WPWD0204_SIZE = 4096;
        #endregion

        #region 口令模板表格
        /// <summary>
        /// 口令模板
        /// </summary>
        public const string WPWD0300 = "WPWD0300";
        /// <summary>
        /// 排序依据
        /// </summary>
        public const string WPWD0301 = "WPWD0301";
        /// <summary>
        /// 属性类别
        /// </summary>
        public const string WPWD0302 = "WPWD0302";
        /// <summary>
        /// 所属用户
        /// </summary>
        public const string WPWD0303 = "WPWD0303";
        public const int WPWD0303_SIZE = 8;
        /// <summary>
        /// 属性索引
        /// </summary>
        public const string WPWD0304 = "WPWD0304";
        public const int WPWD0304_SIZE = 16;
        /// <summary>
        /// 类别索引
        /// </summary>
        public const string WPWD0305 = "WPWD0305";
        public const int WPWD0305_SIZE = 16;
        /// <summary>
        /// 属性名称
        /// </summary>
        public const string WPWD0306 = "WPWD0306";
        public const int WPWD0306_SIZE = 256;
        /// <summary>
        /// 默认数据
        /// </summary>
        public const string WPWD0307 = "WPWD0307";
        public const int WPWD0307_SIZE = 256;
        /// <summary>
        /// 属性说明
        /// </summary>
        public const string WPWD0308 = "WPWD0308";
        public const int WPWD0308_SIZE = 2048;
        /// <summary>
        /// 更新日期
        /// </summary>
        public const string WPWD0309 = "WPWD0309";
        /// <summary>
        /// 创建日期
        /// </summary>
        public const string WPWD030A = "WPWD030A";
        /// <summary>
        /// 版本控制
        /// </summary>
        public const string WPWD030B = "WPWD030B";
        /// <summary>
        /// 操作状态：0删除、1默认、2新增、3更新
        /// </summary>
        public const string WPWD030C = "WPWD030C";
        #endregion

        #region 选项列表表格
        /// <summary>
        /// 模板选项
        /// </summary>
        public const string WPWD0400 = "WPWD0400";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string WPWD0401 = "WPWD0401";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const string WPWD0402 = "WPWD0402";
        public const int WPWD0402_SIZE = 8;
        /// <summary>
        /// 属性索引
        /// </summary>
        public const string WPWD0403 = "WPWD0403";
        public const int WPWD0403_SIZE = 16;
        /// <summary>
        /// 模板索引
        /// </summary>
        public const string WPWD0404 = "WPWD0404";
        public const int WPWD0404_SIZE = 16;
        /// <summary>
        /// 选项名称
        /// </summary>
        public const string WPWD0405 = "WPWD0405";
        public const int WPWD0405_SIZE = 64;
        /// <summary>
        /// 选项提示
        /// </summary>
        public const string WPWD0406 = "WPWD0406";
        public const int WPWD0406_SIZE = 256;
        /// <summary>
        /// 选项说明
        /// </summary>
        public const string WPWD0407 = "WPWD0407";
        public const int WPWD0407_SIZE = 2048;
        /// <summary>
        /// 版本控制
        /// </summary>
        public const string WPWD0408 = "WPWD0408";
        /// <summary>
        /// 操作状态：0删除、1默认、2新增、3更新
        /// </summary>
        public const string WPWD0409 = "WPWD0409";
        #endregion

        #region 历史信息表格
        /// <summary>
        /// 历史信息表格
        /// </summary>
        public const string WPWD0A00 = "WPWD0A00";
        /// <summary>
        /// 日志索引
        /// </summary>
        public const string WPWD0A01 = "WPWD0A01";
        public const int WPWD0A01_SIZE = 16;
        /// <summary>
        /// 使用状态
        /// </summary>
        public const string WPWD0A02 = "WPWD0A02";
        /// <summary>
        /// 紧要程度
        /// </summary>
        public const string WPWD0A03 = "WPWD0A03";
        /// <summary>
        /// 用户索引
        /// </summary>
        public const string WPWD0A04 = "WPWD0A04";
        public const int WPWD0A04_SIZE = WPWD0104_SIZE;
        /// <summary>
        /// 口令索引
        /// </summary>
        public const string WPWD0A05 = "WPWD0A05";
        public const int WPWD0A05_SIZE = WPWD0105_SIZE;
        /// <summary>
        /// 所属类别
        /// </summary>
        public const string WPWD0A06 = "WPWD0A06";
        public const int WPWD0A06_SIZE = WPWD0106_SIZE;
        /// <summary>
        /// 注册日期
        /// </summary>
        public const string WPWD0A07 = "WPWD0A07";
        public const int WPWD0A07_SIZE = WPWD0107_SIZE;
        /// <summary>
        /// 模板索引
        /// </summary>
        public const string WPWD0A08 = "WPWD0A08";
        public const int WPWD0A08_SIZE = WPWD0108_SIZE;
        /// <summary>
        /// 口令标题
        /// </summary>
        public const string WPWD0A09 = "WPWD0A09";
        public const int WPWD0A09_SIZE = WPWD0109_SIZE;
        /// <summary>
        /// 关键搜索
        /// </summary>
        public const string WPWD0A0A = "WPWD0A0A";
        public const int WPWD0A0A_SIZE = WPWD010A_SIZE;
        /// <summary>
        /// 口令图标
        /// </summary>
        public const string WPWD0A0B = "WPWD0A0B";
        public const int WPWD0A0B_SIZE = WPWD010B_SIZE;
        /// <summary>
        /// 图标路径
        /// </summary>
        public const string WPWD0A0C = "WPWD0A0C";
        public const int WPWD0A0C_SIZE = WPWD010C_SIZE;
        /// <summary>
        /// 图标说明
        /// </summary>
        public const string WPWD0A0D = "WPWD0A0D";
        public const int WPWD0A0D_SIZE = WPWD010D_SIZE;
        /// <summary>
        /// 提醒索引
        /// </summary>
        public const string WPWD0A0E = "WPWD0A0E";
        public const int WPWD0A0E_SIZE = WPWD010E_SIZE;
        /// <summary>
        /// 提醒备注
        /// </summary>
        public const string WPWD0A0F = "WPWD0A0F";
        public const int WPWD0A0F_SIZE = WPWD010F_SIZE;
        /// <summary>
        /// 相关说明
        /// </summary>
        public const string WPWD0A10 = "WPWD0A10";
        public const int WPWD0A10_SIZE = WPWD0110_SIZE;
        /// <summary>
        /// 访问日期
        /// </summary>
        public const string WPWD0A11 = "WPWD0A11";
        public const int WPWD0A11_SIZE = WPWD0111_SIZE;
        /// <summary>
        /// 是否备份
        /// </summary>
        public const string WPWD0A12 = "WPWD0A12";
        /// <summary>
        /// 加密版本
        /// </summary>
        public const string WPWD0A13 = "WPWD0A13";
        #endregion

        #region 历史数据表格
        /// <summary>
        /// 历史数据表格
        /// </summary>
        public const string WPWD0B00 = "WPWD0B00";
        /// <summary>
        /// 日志索引
        /// </summary>
        public const string WPWD0B01 = "WPWD0B01";
        /// <summary>
        /// 内容索引
        /// </summary>
        public const string WPWD0B02 = "WPWD0B02";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const string WPWD0B03 = "WPWD0B03";
        public const int WPWD0B03_SIZE = WPWD0202_SIZE;
        /// <summary>
        /// 口令索引
        /// </summary>
        public const string WPWD0B04 = "WPWD0B04";
        public const int WPWD0B04_SIZE = WPWD0203_SIZE;
        /// <summary>
        /// 口令内容
        /// </summary>
        public const string WPWD0B05 = "WPWD0B05";
        public const int WPWD0B05_SIZE = WPWD0204_SIZE;
        #endregion
        #endregion

        #region 图标分类表格
        /// <summary>
        /// 图标分类表格
        /// </summary>
        public const string WICO0100 = "WICO0100";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string WICO0101 = "WICO0101";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const string WICO0102 = "WICO0102";
        public const int WICO0102_SIZE = 16;
        /// <summary>
        /// 类别索引
        /// </summary>
        public const string WICO0103 = "WICO0103";
        public const int WICO0103_SIZE = 16;
        /// <summary>
        /// 类别名称
        /// </summary>
        public const string WICO0104 = "WICO0104";
        public const int WICO0104_SIZE = 32;
        /// <summary>
        /// 类别提示
        /// </summary>
        public const string WICO0105 = "WICO0105";
        public const int WICO0105_SIZE = 256;
        /// <summary>
        /// 类别目录
        /// </summary>
        public const string WICO0106 = "WICO0106";
        public const int WICO0106_SIZE = 64;
        /// <summary>
        /// 类别备注
        /// </summary>
        public const string WICO0107 = "WICO0107";
        public const int WICO0107_SIZE = 2048;
        /// <summary>
        /// 版本控制
        /// </summary>
        public const string WICO0108 = "WICO0108";
        /// <summary>
        /// 操作状态：0删除、1默认、2新增、3更新
        /// </summary>
        public const string WICO0109 = "WICO0109";
        #endregion

        #region 字符空间表格
        /// <summary>
        /// 字符空间表格
        /// </summary>
        public const string WUDC0100 = "WUDC0100";
        /// <summary>
        /// 排序依据
        /// </summary>
        public const string WUDC0101 = "WUDC0101";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const string WUDC0102 = "WUDC0102";
        public const int WUDC0102_SIZE = 8;
        /// <summary>
        /// 空间索引
        /// </summary>
        public const string WUDC0103 = "WUDC0103";
        public const int WUDC0103_SIZE = 16;
        /// <summary>
        /// 空间名称
        /// </summary>
        public const string WUDC0104 = "WUDC0104";
        public const int WUDC0104_SIZE = 256;
        /// <summary>
        /// 空间提示
        /// </summary>
        public const string WUDC0105 = "WUDC0105";
        public const int WUDC0105_SIZE = 256;
        /// <summary>
        /// 空间字符
        /// </summary>
        public const string WUDC0106 = "WUDC0106";
        public const int WUDC0106_SIZE = 512;
        /// <summary>
        /// 相关说明
        /// </summary>
        public const string WUDC0107 = "WUDC0107";
        public const int WUDC0107_SIZE = 2048;
        /// <summary>
        /// 更新日期
        /// </summary>
        public const string WUDC0108 = "WUDC0108";
        /// <summary>
        /// 创建日期
        /// </summary>
        public const string WUDC0109 = "WUDC0109";
        /// <summary>
        /// 版本控制
        /// </summary>
        public const string WUDC010A = "WUDC010A";
        /// <summary>
        /// 操作状态：0删除、1默认、2新增、3更新
        /// </summary>
        public const string WUDC010B = "WUDC010B";
        #endregion

        #region 计划任务
        #region 任务信息
        /// <summary>
        /// 任务信息
        /// </summary>
        public const string WGTD0100 = "WGTD0100";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string WGTD0101 = "WGTD0101";
        /// <summary>
        /// 任务类型
        /// </summary>
        public const string WGTD0102 = "WGTD0102";
        /// <summary>
        /// 任务状态
        /// </summary>
        public const string WGTD0103 = "WGTD0103";
        /// <summary>
        /// 任务级别
        /// </summary>
        public const string WGTD0104 = "WGTD0104";
        /// <summary>
        /// 提醒周期
        /// </summary>
        public const string WGTD0105 = "WGTD0105";
        /// <summary>
        /// 提示方式
        /// </summary>
        public const string WGTD0106 = "WGTD0106";
        /// <summary>
        /// 可否共用
        /// </summary>
        public const string WGTD0107 = "WGTD0107";
        /// <summary>
        /// 完成度
        /// </summary>
        public const string WGTD0108 = "WGTD0108";
        /// <summary>
        /// 任务索引
        /// </summary>
        public const string WGTD0109 = "WGTD0109";
        public const int WGTD0109_SIZE = 16;
        /// <summary>
        /// 上级任务
        /// </summary>
        public const string WGTD010A = "WGTD010A";
        public const int WGTD010A_SIZE = 16;
        /// <summary>
        /// 前置任务
        /// </summary>
        public const string WGTD010B = "WGTD010B";
        public const int WGTD010B_SIZE = 16;
        /// <summary>
        /// 任务名称
        /// </summary>
        public const string WGTD010C = "WGTD010C";
        public const int WGTD010C_SIZE = 256;
        /// <summary>
        /// 起始时间
        /// </summary>
        public const string WGTD010D = "WGTD010D";
        /// <summary>
        /// 结束时间
        /// </summary>
        public const string WGTD010E = "WGTD010E";
        /// <summary>
        /// 执行时间
        /// </summary>
        public const string WGTD010F = "WGTD010F";
        /// <summary>
        /// 附加参数
        /// </summary>
        public const string WGTD0110 = "WGTD0110";
        public const int WGTD0110_SIZE = 1024;
        /// <summary>
        /// 执行参数
        /// </summary>
        public const string WGTD0111 = "WGTD0111";
        public const int WGTD0111_SIZE = 1024;
        /// <summary>
        /// 是否提前
        /// </summary>
        public const string WGTD0112 = "WGTD0112";
        /// <summary>
        /// 提前间隔
        /// </summary>
        public const string WGTD0113 = "WGTD0113";
        /// <summary>
        /// 相关说明
        /// </summary>
        public const string WGTD0114 = "WGTD0114";
        public const int WGTD0114_SIZE = 2048;
        #endregion

        #region 执行时间
        /// <summary>
        /// 执行时间
        /// </summary>
        public const string WGTD0200 = "WGTD0200";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string WGTD0201 = "WGTD0201";
        /// <summary>
        /// 计划索引
        /// </summary>
        public const string WGTD0202 = "WGTD0202";
        public const int WGTD0202_SIZE = 16;
        /// <summary>
        /// 指定时间
        /// </summary>
        public const string WGTD0203 = "WGTD0203";
        /// <summary>
        /// 时间单位
        /// </summary>
        public const string WGTD0204 = "WGTD0204";
        /// <summary>
        /// 间隔时间
        /// </summary>
        public const string WGTD0205 = "WGTD0205";
        /// <summary>
        /// 表达式
        /// </summary>
        public const string WGTD0206 = "WGTD0206";
        public const int WGTD0206_SIZE = 512;
        #endregion
        #endregion
    }
}
