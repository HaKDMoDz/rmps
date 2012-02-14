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
        public const string APWD0000 = "APWD0000";
        /// <summary>
        /// 一级索引
        /// </summary>
        public const string APWD0001 = "APWD0001";
        public const int APWD0001_SIZE = 16;
        /// <summary>
        /// 二级索引
        /// </summary>
        public const string APWD0002 = "APWD0002";
        public const int APWD0002_SIZE = 16;
        /// <summary>
        /// 配置信息
        /// </summary>
        public const string APWD0003 = "APWD0003";
        public const int APWD0003_SIZE = 1024;
        /// <summary>
        /// 配置时间
        /// </summary>
        public const string APWD0004 = "APWD0004";
        #endregion

        #region 口令信息表格
        /// <summary>
        /// 口令信息表格
        /// </summary>
        public const string APWD0100 = "APWD0100";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string APWD0101 = "APWD0101";
        /// <summary>
        /// 使用状态
        /// </summary>
        public const string APWD0102 = "APWD0102";
        /// <summary>
        /// 紧要程度
        /// </summary>
        public const string APWD0103 = "APWD0103";
        /// <summary>
        /// 用户索引
        /// </summary>
        public const string APWD0104 = "APWD0104";
        public const int APWD0104_SIZE = 8;
        /// <summary>
        /// 口令索引
        /// </summary>
        public const string APWD0105 = "APWD0105";
        public const int APWD0105_SIZE = 16;
        /// <summary>
        /// 所属类别
        /// </summary>
        public const string APWD0106 = "APWD0106";
        public const int APWD0106_SIZE = 16;
        /// <summary>
        /// 注册日期
        /// </summary>
        public const string APWD0107 = "APWD0107";
        public const int APWD0107_SIZE = 24;
        /// <summary>
        /// 模板索引
        /// </summary>
        public const string APWD0108 = "APWD0108";
        public const int APWD0108_SIZE = 16;
        /// <summary>
        /// 口令标题
        /// </summary>
        public const string APWD0109 = "APWD0109";
        public const int APWD0109_SIZE = 256;
        /// <summary>
        /// 关键搜索
        /// </summary>
        public const string APWD010A = "APWD010A";
        public const int APWD010A_SIZE = 1024;
        /// <summary>
        /// 口令图标
        /// </summary>
        public const string APWD010B = "APWD010B";
        public const int APWD010B_SIZE = 16;
        /// <summary>
        /// 图标路径
        /// </summary>
        public const string APWD010C = "APWD010C";
        public const int APWD010C_SIZE = 64;
        /// <summary>
        /// 图标说明
        /// </summary>
        public const string APWD010D = "APWD010D";
        public const int APWD010D_SIZE = 1024;
        /// <summary>
        /// 提醒索引
        /// </summary>
        public const string APWD010E = "APWD010E";
        public const int APWD010E_SIZE = 16;
        /// <summary>
        /// 提醒备注
        /// </summary>
        public const string APWD010F = "APWD010F";
        public const int APWD010F_SIZE = 1024;
        /// <summary>
        /// 相关说明
        /// </summary>
        public const string APWD0110 = "APWD0110";
        public const int APWD0110_SIZE = 2048;
        /// <summary>
        /// 访问日期
        /// </summary>
        public const string APWD0111 = "APWD0111";
        public const int APWD0111_SIZE = 24;
        /// <summary>
        /// 是否备份
        /// </summary>
        public const string APWD0112 = "APWD0112";
        /// <summary>
        /// 加密版本
        /// </summary>
        public const string APWD0113 = "APWD0113";
        /// <summary>
        /// 版本控制
        /// </summary>
        public const string APWD0114 = "APWD0114";
        /// <summary>
        /// 操作状态：0删除、1默认、2新增、3更新
        /// </summary>
        public const string APWD0115 = "APWD0115";
        #endregion

        #region 口令内容表格
        /// <summary>
        /// 口令内容表格
        /// </summary>
        public const string APWD0200 = "APWD0200";
        /// <summary>
        /// 内容索引
        /// </summary>
        public const string APWD0201 = "APWD0201";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const string APWD0202 = "APWD0202";
        public const int APWD0202_SIZE = 8;
        /// <summary>
        /// 口令索引
        /// </summary>
        public const string APWD0203 = "APWD0203";
        public const int APWD0203_SIZE = 16;
        /// <summary>
        /// 口令内容
        /// </summary>
        public const string APWD0204 = "APWD0204";
        public const int APWD0204_SIZE = 4096;
        #endregion

        #region 口令模板表格
        /// <summary>
        /// 口令模板
        /// </summary>
        public const string APWD0300 = "APWD0300";
        /// <summary>
        /// 排序依据
        /// </summary>
        public const string APWD0301 = "APWD0301";
        /// <summary>
        /// 属性类别
        /// </summary>
        public const string APWD0302 = "APWD0302";
        /// <summary>
        /// 所属用户
        /// </summary>
        public const string APWD0303 = "APWD0303";
        public const int APWD0303_SIZE = 8;
        /// <summary>
        /// 属性索引
        /// </summary>
        public const string APWD0304 = "APWD0304";
        public const int APWD0304_SIZE = 16;
        /// <summary>
        /// 类别索引
        /// </summary>
        public const string APWD0305 = "APWD0305";
        public const int APWD0305_SIZE = 16;
        /// <summary>
        /// 属性名称
        /// </summary>
        public const string APWD0306 = "APWD0306";
        public const int APWD0306_SIZE = 256;
        /// <summary>
        /// 默认数据
        /// </summary>
        public const string APWD0307 = "APWD0307";
        public const int APWD0307_SIZE = 256;
        /// <summary>
        /// 属性说明
        /// </summary>
        public const string APWD0308 = "APWD0308";
        public const int APWD0308_SIZE = 2048;
        /// <summary>
        /// 更新日期
        /// </summary>
        public const string APWD0309 = "APWD0309";
        /// <summary>
        /// 创建日期
        /// </summary>
        public const string APWD030A = "APWD030A";
        /// <summary>
        /// 版本控制
        /// </summary>
        public const string APWD030B = "APWD030B";
        /// <summary>
        /// 操作状态：0删除、1默认、2新增、3更新
        /// </summary>
        public const string APWD030C = "APWD030C";
        #endregion

        #region 选项列表表格
        /// <summary>
        /// 模板选项
        /// </summary>
        public const string APWD0400 = "APWD0400";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string APWD0401 = "APWD0401";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const string APWD0402 = "APWD0402";
        public const int APWD0402_SIZE = 8;
        /// <summary>
        /// 属性索引
        /// </summary>
        public const string APWD0403 = "APWD0403";
        public const int APWD0403_SIZE = 16;
        /// <summary>
        /// 模板索引
        /// </summary>
        public const string APWD0404 = "APWD0404";
        public const int APWD0404_SIZE = 16;
        /// <summary>
        /// 选项名称
        /// </summary>
        public const string APWD0405 = "APWD0405";
        public const int APWD0405_SIZE = 64;
        /// <summary>
        /// 选项提示
        /// </summary>
        public const string APWD0406 = "APWD0406";
        public const int APWD0406_SIZE = 256;
        /// <summary>
        /// 选项说明
        /// </summary>
        public const string APWD0407 = "APWD0407";
        public const int APWD0407_SIZE = 2048;
        /// <summary>
        /// 版本控制
        /// </summary>
        public const string APWD0408 = "APWD0408";
        /// <summary>
        /// 操作状态：0删除、1默认、2新增、3更新
        /// </summary>
        public const string APWD0409 = "APWD0409";
        #endregion

        #region 历史信息表格
        /// <summary>
        /// 历史信息表格
        /// </summary>
        public const string APWD0A00 = "APWD0A00";
        /// <summary>
        /// 日志索引
        /// </summary>
        public const string APWD0A01 = "APWD0A01";
        public const int APWD0A01_SIZE = 16;
        /// <summary>
        /// 使用状态
        /// </summary>
        public const string APWD0A02 = "APWD0A02";
        /// <summary>
        /// 紧要程度
        /// </summary>
        public const string APWD0A03 = "APWD0A03";
        /// <summary>
        /// 用户索引
        /// </summary>
        public const string APWD0A04 = "APWD0A04";
        public const int APWD0A04_SIZE = APWD0104_SIZE;
        /// <summary>
        /// 口令索引
        /// </summary>
        public const string APWD0A05 = "APWD0A05";
        public const int APWD0A05_SIZE = APWD0105_SIZE;
        /// <summary>
        /// 所属类别
        /// </summary>
        public const string APWD0A06 = "APWD0A06";
        public const int APWD0A06_SIZE = APWD0106_SIZE;
        /// <summary>
        /// 注册日期
        /// </summary>
        public const string APWD0A07 = "APWD0A07";
        public const int APWD0A07_SIZE = APWD0107_SIZE;
        /// <summary>
        /// 模板索引
        /// </summary>
        public const string APWD0A08 = "APWD0A08";
        public const int APWD0A08_SIZE = APWD0108_SIZE;
        /// <summary>
        /// 口令标题
        /// </summary>
        public const string APWD0A09 = "APWD0A09";
        public const int APWD0A09_SIZE = APWD0109_SIZE;
        /// <summary>
        /// 关键搜索
        /// </summary>
        public const string APWD0A0A = "APWD0A0A";
        public const int APWD0A0A_SIZE = APWD010A_SIZE;
        /// <summary>
        /// 口令图标
        /// </summary>
        public const string APWD0A0B = "APWD0A0B";
        public const int APWD0A0B_SIZE = APWD010B_SIZE;
        /// <summary>
        /// 图标路径
        /// </summary>
        public const string APWD0A0C = "APWD0A0C";
        public const int APWD0A0C_SIZE = APWD010C_SIZE;
        /// <summary>
        /// 图标说明
        /// </summary>
        public const string APWD0A0D = "APWD0A0D";
        public const int APWD0A0D_SIZE = APWD010D_SIZE;
        /// <summary>
        /// 提醒索引
        /// </summary>
        public const string APWD0A0E = "APWD0A0E";
        public const int APWD0A0E_SIZE = APWD010E_SIZE;
        /// <summary>
        /// 提醒备注
        /// </summary>
        public const string APWD0A0F = "APWD0A0F";
        public const int APWD0A0F_SIZE = APWD010F_SIZE;
        /// <summary>
        /// 相关说明
        /// </summary>
        public const string APWD0A10 = "APWD0A10";
        public const int APWD0A10_SIZE = APWD0110_SIZE;
        /// <summary>
        /// 访问日期
        /// </summary>
        public const string APWD0A11 = "APWD0A11";
        public const int APWD0A11_SIZE = APWD0111_SIZE;
        /// <summary>
        /// 是否备份
        /// </summary>
        public const string APWD0A12 = "APWD0A12";
        /// <summary>
        /// 加密版本
        /// </summary>
        public const string APWD0A13 = "APWD0A13";
        #endregion

        #region 历史数据表格
        /// <summary>
        /// 历史数据表格
        /// </summary>
        public const string APWD0B00 = "APWD0B00";
        /// <summary>
        /// 日志索引
        /// </summary>
        public const string APWD0B01 = "APWD0B01";
        /// <summary>
        /// 内容索引
        /// </summary>
        public const string APWD0B02 = "APWD0B02";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const string APWD0B03 = "APWD0B03";
        public const int APWD0B03_SIZE = APWD0202_SIZE;
        /// <summary>
        /// 口令索引
        /// </summary>
        public const string APWD0B04 = "APWD0B04";
        public const int APWD0B04_SIZE = APWD0203_SIZE;
        /// <summary>
        /// 口令内容
        /// </summary>
        public const string APWD0B05 = "APWD0B05";
        public const int APWD0B05_SIZE = APWD0204_SIZE;
        #endregion
        #endregion

        #region 图标分类表格
        /// <summary>
        /// 图标分类表格
        /// </summary>
        public const string AICO0100 = "AICO0100";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string AICO0101 = "AICO0101";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const string AICO0102 = "AICO0102";
        public const int AICO0102_SIZE = 16;
        /// <summary>
        /// 类别索引
        /// </summary>
        public const string AICO0103 = "AICO0103";
        public const int AICO0103_SIZE = 16;
        /// <summary>
        /// 类别名称
        /// </summary>
        public const string AICO0104 = "AICO0104";
        public const int AICO0104_SIZE = 32;
        /// <summary>
        /// 类别提示
        /// </summary>
        public const string AICO0105 = "AICO0105";
        public const int AICO0105_SIZE = 256;
        /// <summary>
        /// 类别目录
        /// </summary>
        public const string AICO0106 = "AICO0106";
        public const int AICO0106_SIZE = 64;
        /// <summary>
        /// 类别备注
        /// </summary>
        public const string AICO0107 = "AICO0107";
        public const int AICO0107_SIZE = 2048;
        /// <summary>
        /// 版本控制
        /// </summary>
        public const string AICO0108 = "AICO0108";
        /// <summary>
        /// 操作状态：0删除、1默认、2新增、3更新
        /// </summary>
        public const string AICO0109 = "AICO0109";
        #endregion

        #region 字符空间表格
        /// <summary>
        /// 字符空间表格
        /// </summary>
        public const string AUCS0100 = "AUCS0100";
        /// <summary>
        /// 排序依据
        /// </summary>
        public const string AUCS0101 = "AUCS0101";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const string AUCS0102 = "AUCS0102";
        public const int AUCS0102_SIZE = 8;
        /// <summary>
        /// 空间索引
        /// </summary>
        public const string AUCS0103 = "AUCS0103";
        public const int AUCS0103_SIZE = 16;
        /// <summary>
        /// 空间名称
        /// </summary>
        public const string AUCS0104 = "AUCS0104";
        public const int AUCS0104_SIZE = 256;
        /// <summary>
        /// 空间提示
        /// </summary>
        public const string AUCS0105 = "AUCS0105";
        public const int AUCS0105_SIZE = 256;
        /// <summary>
        /// 空间字符
        /// </summary>
        public const string AUCS0106 = "AUCS0106";
        public const int AUCS0106_SIZE = 512;
        /// <summary>
        /// 相关说明
        /// </summary>
        public const string AUCS0107 = "AUCS0107";
        public const int AUCS0107_SIZE = 2048;
        /// <summary>
        /// 更新日期
        /// </summary>
        public const string AUCS0108 = "AUCS0108";
        /// <summary>
        /// 创建日期
        /// </summary>
        public const string AUCS0109 = "AUCS0109";
        /// <summary>
        /// 版本控制
        /// </summary>
        public const string AUCS010A = "AUCS010A";
        /// <summary>
        /// 操作状态：0删除、1默认、2新增、3更新
        /// </summary>
        public const string AUCS010B = "AUCS010B";
        #endregion

        #region 计划任务
        #region 任务信息
        /// <summary>
        /// 任务信息
        /// </summary>
        public const string AGTD0100 = "AGTD0100";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string AGTD0101 = "AGTD0101";
        /// <summary>
        /// 任务类型
        /// </summary>
        public const string AGTD0102 = "AGTD0102";
        /// <summary>
        /// 任务状态
        /// </summary>
        public const string AGTD0103 = "AGTD0103";
        /// <summary>
        /// 任务级别
        /// </summary>
        public const string AGTD0104 = "AGTD0104";
        /// <summary>
        /// 提醒周期
        /// </summary>
        public const string AGTD0105 = "AGTD0105";
        /// <summary>
        /// 提示方式
        /// </summary>
        public const string AGTD0106 = "AGTD0106";
        /// <summary>
        /// 可否共用
        /// </summary>
        public const string AGTD0107 = "AGTD0107";
        /// <summary>
        /// 完成度
        /// </summary>
        public const string AGTD0108 = "AGTD0108";
        /// <summary>
        /// 任务索引
        /// </summary>
        public const string AGTD0109 = "AGTD0109";
        public const int AGTD0109_SIZE = 16;
        /// <summary>
        /// 上级任务
        /// </summary>
        public const string AGTD010A = "AGTD010A";
        public const int AGTD010A_SIZE = 16;
        /// <summary>
        /// 前置任务
        /// </summary>
        public const string AGTD010B = "AGTD010B";
        public const int AGTD010B_SIZE = 16;
        /// <summary>
        /// 任务名称
        /// </summary>
        public const string AGTD010C = "AGTD010C";
        public const int AGTD010C_SIZE = 256;
        /// <summary>
        /// 起始时间
        /// </summary>
        public const string AGTD010D = "AGTD010D";
        /// <summary>
        /// 结束时间
        /// </summary>
        public const string AGTD010E = "AGTD010E";
        /// <summary>
        /// 执行时间
        /// </summary>
        public const string AGTD010F = "AGTD010F";
        /// <summary>
        /// 附加参数
        /// </summary>
        public const string AGTD0110 = "AGTD0110";
        public const int AGTD0110_SIZE = 1024;
        /// <summary>
        /// 执行参数
        /// </summary>
        public const string AGTD0111 = "AGTD0111";
        public const int AGTD0111_SIZE = 1024;
        /// <summary>
        /// 是否提前
        /// </summary>
        public const string AGTD0112 = "AGTD0112";
        /// <summary>
        /// 提前间隔
        /// </summary>
        public const string AGTD0113 = "AGTD0113";
        /// <summary>
        /// 相关说明
        /// </summary>
        public const string AGTD0114 = "AGTD0114";
        public const int AGTD0114_SIZE = 2048;
        #endregion

        #region 执行时间
        /// <summary>
        /// 执行时间
        /// </summary>
        public const string AGTD0200 = "AGTD0200";
        /// <summary>
        /// 显示排序
        /// </summary>
        public const string AGTD0201 = "AGTD0201";
        /// <summary>
        /// 计划索引
        /// </summary>
        public const string AGTD0202 = "AGTD0202";
        public const int AGTD0202_SIZE = 16;
        /// <summary>
        /// 指定时间
        /// </summary>
        public const string AGTD0203 = "AGTD0203";
        /// <summary>
        /// 时间单位
        /// </summary>
        public const string AGTD0204 = "AGTD0204";
        /// <summary>
        /// 间隔时间
        /// </summary>
        public const string AGTD0205 = "AGTD0205";
        /// <summary>
        /// 表达式
        /// </summary>
        public const string AGTD0206 = "AGTD0206";
        public const int AGTD0206_SIZE = 512;
        #endregion
        #endregion
    }
}
