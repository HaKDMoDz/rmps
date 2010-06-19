using System;

namespace cons.io.db.wrp
{
    /// <summary>
    /// AmonWeb 的摘要说明
    /// </summary>
    public class WrpCons
    {
        private WrpCons()
        {
        }

        #region 控制模块
        // ////////////////////////////////////////////////////////////////////
        // 首页控制模块
        // ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 首页控制模块
        /// </summary>
        public const String WRP_HOME = "W0000000";
        public const String WRP_LISTITEM = "W0010100";
        public const String LISTITEM_ITEMINDX = "W0010101";
        public const String LISTITEM_LANGINDX = "W0010102";
        public const String LISTITEM_LINKRANK = "W0010103";
        public const String LISTITEM_ITEMTEXT = "W0010104";
        public const String LISTITEM_ITEMTIPS = "W0010105";
        public const String LISTITEM_ITEMLINK = "W0010106";
        public const String LISTITEM_UPDTDATE = "W0010107";
        public const String LISTITEM_MAKEDATE = "W0010108";
        #endregion

        #region 爱问模块
        // ////////////////////////////////////////////////////////////////////
        // 爱问模块
        // ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 爱问模块
        /// </summary>
        public const String WRP_IASK = "W1000000";
        #endregion

        #region 软件模块
        // ////////////////////////////////////////////////////////////////////
        // 软件模块
        // ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 软件模块
        /// </summary>
        public const String WRP_SOFT = "W2000000";

        #region 网页精灵
        // ////////////////////////////////////////////////////////////////////
        // 网页精灵
        // ////////////////////////////////////////////////////////////////////
        #region 用户配置
        // ////////////////////////////////////////////////
        // 用户配置
        // ////////////////////////////////////////////////
        /// <summary>
        /// 用户配置
        /// </summary>
        public const String W2011100 = "W2011100";

        /// <summary>
        /// 显示排序 
        /// </summary>
        public const String W2011101 = "W2011101";

        /// <summary>
        /// 类别索引
        /// </summary>
        public const String W2011102 = "W2011102";

        /// <summary>
        /// 偏好索引
        /// </summary> 
        public const String W2011103 = "W2011103";
        public const int W2011103_SIZE = 16;

        /// <summary>
        /// 元素索引
        /// </summary> 
        public const String W2011104 = "W2011104";
        public const int W2011104_SIZE = 16;

        /// <summary>
        /// 用户索引
        /// </summary> 
        public const String W2011105 = "W2011105";
        public const int W2011105_SIZE = 16;

        /// <summary>
        /// 附注信息
        /// </summary> 
        public const String W2011106 = "W2011106";
        public const int W2011106_SIZE = 2048;

        /// <summary>
        /// 更新日期
        /// </summary>
        public const String W2011107 = "W2011107";

        /// <summary>
        /// 创建日期
        /// </summary> 
        public const String W2011108 = "W2011108";
        #endregion

        #region 使用统计
        // ////////////////////////////////////////////////
        // 使用统计
        // ////////////////////////////////////////////////
        /// <summary>
        /// 用户统计
        /// </summary>
        public const String W2012100 = "W2012100";

        /// <summary>
        /// 统计ID
        /// </summary>
        public const String W2012101 = "W2012101";
        public const int W2012101_SIZE = 16;
        /// <summary>
        /// 用户编码
        /// </summary>
        public const String W2012102 = "W2012102";
        public const int W2012102_SIZE = 8;
        /// <summary>
        /// 访问时间
        /// </summary>
        public const String W2012103 = "W2012103";
        /// <summary>
        /// 访问元素
        /// </summary>
        public const String W2012104 = "W2012104";
        public const int W2012104_SIZE = 16;
        /// <summary>
        /// 页面标题
        /// </summary>
        public const String W2012105 = "W2012105";
        public const int W2012105_SIZE = 1024;
        /// <summary>
        /// 页面地址
        /// </summary>
        public const String W2012106 = "W2012106";
        public const int W2012106_SIZE = 1024;
        /// <summary>
        /// 页面说明
        /// </summary>
        public const String W2012107 = "W2012107";
        public const int W2012107_SIZE = 4096;
        /// <summary>
        /// 用户地址
        /// </summary>
        public const String W2012108 = "W2012108";
        public const int W2012108_SIZE = 48;
        /// <summary>
        /// 用户浏览器
        /// </summary>
        public const String W2012109 = "W2012109";
        public const int W2012109_SIZE = 256;
        /// <summary>
        /// 浏览器名称
        /// </summary>
        public const String W201210A = "W201210A";
        public const int W201210A_SIZE = 32;
        /// <summary>
        /// 应用平台
        /// </summary>
        public const String W201210B = "W201210B";
        public const int W201210B_SIZE = 32;
        #endregion

        #region 元记录
        // ////////////////////////////////////////////////
        // 元记录数据
        // ////////////////////////////////////////////////
        /// <summary>
        /// 链接模板
        /// </summary>
        public const String W2019100 = "W2019100";

        /// <summary>
        /// 显示排序
        /// </summary> 
        public const String W2019101 = "W2019101";

        /// <summary>
        /// 主键索引
        /// </summary> 
        public const String W2019102 = "W2019102";
        public const int W2019102_SIZE = 16;

        /// <summary>
        /// 语言索引
        /// </summary> 
        public const String W2019103 = "W2019103";
        public const int W2019103_SIZE = 16;

        /// <summary>
        /// 链接类别
        /// </summary> 
        public const String W2019104 = "W2019104";
        public const int W2019104_SIZE = 16;

        /// <summary>
        /// 显示图标
        /// </summary> 
        public const String W2019105 = "W2019105";
        public const int W2019105_SIZE = 32;

        /// <summary>
        /// 显示文本
        /// </summary> 
        public const String W2019106 = "W2019106";
        public const int W2019106_SIZE = 128;

        /// <summary>
        /// 快捷提示
        /// </summary> 
        public const String W2019107 = "W2019107";
        public const int W2019107_SIZE = 256;

        /// <summary>
        /// 链接地址
        /// </summary> 
        public const String W2019108 = "W2019108";
        public const int W2019108_SIZE = 1024;

        /// <summary>
        /// 转换方案
        /// </summary> 
        public const String W2019109 = "W2019109";
        public const int W2019109_SIZE = 32;

        /// <summary>
        /// 窗口宽度
        /// </summary> 
        public const String W201910A = "W201910A";

        /// <summary>
        /// 窗口高度
        /// </summary> 
        public const String W201910B = "W201910B";

        /// <summary>
        /// 附注信息
        /// </summary> 
        public const String W201910C = "W201910C";
        public const int W201910C_SIZE = 2048;

        /// <summary>
        /// 更新日期
        /// </summary>
        public const String W201910D = "W201910D";

        /// <summary>
        /// 创建日期
        /// </summary>
        public const String W201910E = "W201910E";
        #endregion
        #endregion

        #region 网页五笔
        // ////////////////////////////////////////////////////////////////////
        // 网页五笔
        // ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 网页五笔
        /// </summary>
        public const String W2020100 = "W2020100";
        /// <summary>
        /// 使用频率
        /// </summary>
        public const String W2020101 = "W2020101";
        /// <summary>
        /// 字库类型
        /// </summary>
        public const String W2020102 = "W2020102";
        /// <summary>
        /// 编码索引
        /// </summary>
        public const String W2020103 = "W2020103";
        public const int W2020103_SIZE = 16;
        /// <summary>
        /// 用户编码
        /// </summary>
        public const String W2020104 = "W2020104";
        public const int W2020104_SIZE = 8;
        /// <summary>
        /// 词组编码
        /// </summary>
        public const String W2020105 = "W2020105";
        public const int W2020105_SIZE = 64;
        /// <summary>
        /// 词组内容
        /// </summary>
        public const String W2020106 = "W2020106";
        public const int W2020106_SIZE = 512;
        /// <summary>
        /// 说明信息
        /// </summary>
        public const String W2020107 = "W2020107";
        public const int W2020107_SIZE = 1024;
        /// <summary>
        /// 更新日期
        /// </summary>
        public const String W2020108 = "W2020108";
        /// <summary>
        /// 创建日期
        /// </summary>
        public const String W2020109 = "W2020109";
        #endregion

        #region 全能搜索
        // ////////////////////////////////////////////////////////////////////
        // 全能搜索
        // ////////////////////////////////////////////////////////////////////
        #region 用户配置
        // ////////////////////////////////////////////////
        // 用户配置
        // ////////////////////////////////////////////////
        /// <summary>
        /// 用户配置
        /// </summary>
        public const String W2031100 = "W2031100";

        /// <summary>
        /// 显示排序 
        /// </summary>
        public const String W2031101 = "W2031101";

        /// <summary>
        /// 数据类别
        /// </summary>
        public const String W2031102 = "W2031102";

        /// <summary>
        /// 偏好索引
        /// </summary> 
        public const String W2031103 = "W2031103";
        public const int W2031103_SIZE = 16;

        /// <summary>
        /// 元素索引
        /// </summary> 
        public const String W2031104 = "W2031104";
        public const int W2031104_SIZE = 16;

        /// <summary>
        /// 用户代码
        /// </summary> 
        public const String W2031105 = "W2031105";
        public const int W2031105_SIZE = 16;

        /// <summary>
        /// 附注信息
        /// </summary> 
        public const String W2031106 = "W2031106";
        public const int W2031106_SIZE = 2048;

        /// <summary>
        /// 更新日期
        /// </summary>
        public const String W2031107 = "W2031107";

        /// <summary>
        /// 创建日期
        /// </summary> 
        public const String W2031108 = "W2031108";
        #endregion

        #region 元记录

        // ////////////////////////////////////////////////
        // 元记录数据
        // ////////////////////////////////////////////////
        /// <summary>
        /// 基本数据
        /// </summary>
        public const String W2039100 = "W2039100";

        /// <summary>
        /// 显示排序
        /// </summary> 
        public const String W2039101 = "W2039101";

        /// <summary>
        /// 主键索引
        /// </summary> 
        public const String W2039102 = "W2039102";
        public const int W2039102_SIZE = 16;

        /// <summary>
        /// 语言索引
        /// </summary> 
        public const String W2039103 = "W2039103";
        public const int W2039103_SIZE = 16;

        /// <summary>
        /// 从属门户
        /// </summary> 
        public const String W2039104 = "W2039104";
        public const int W2039104_SIZE = 16;

        /// <summary>
        /// 链接类别
        /// </summary> 
        public const String W2039105 = "W2039105";
        public const int W2039105_SIZE = 16;

        /// <summary>
        /// 显示图标
        /// </summary> 
        public const String W2039106 = "W2039106";
        public const int W2039106_SIZE = 32;

        /// <summary>
        /// 显示文本
        /// </summary> 
        public const String W2039107 = "W2039107";
        public const int W2039107_SIZE = 64;

        /// <summary>
        /// 功能名称
        /// </summary>
        public const String W2039108 = "W2039108";
        public const int W2039108_SIZE = 32;

        /// <summary>
        /// 快捷提示
        /// </summary>
        public const String W2039109 = "W2039109";
        public const int W2039109_SIZE = 256;

        /// <summary>
        /// 链接地址
        /// </summary>
        public const String W203910A = "W203910A";
        public const int W203910A_SIZE = 1024;

        /// <summary>
        /// 转换方案
        /// </summary>
        public const String W203910B = "W203910B";
        public const int W203910B_SIZE = 32;

        /// <summary>
        /// 窗口模式
        /// </summary> 
        public const String W203910C = "W203910C";
        public const int W203910C_SIZE = 512;

        /// <summary>
        /// 附注信息
        /// </summary> 
        public const String W203910D = "W203910D";
        public const int W203910D_SIZE = 2048;

        /// <summary>
        /// 更新日期
        /// </summary>
        public const String W203910E = "W203910E";

        /// <summary>
        /// 创建日期
        /// </summary>
        public const String W203910F = "W203910F";
        #endregion
        #endregion

        #region 个性卡片
        // ////////////////////////////////////////////////////////////////////
        // 个性卡片
        // ////////////////////////////////////////////////////////////////////
        #region 用户配置
        // ////////////////////////////////////////////////
        // 功能配置
        // ////////////////////////////////////////////////
        /// <summary>
        /// 功能配置
        /// </summary>
        public const String W2040100 = "W2040100";
        /// <summary>
        /// 访问频率
        /// </summary>
        public const String W2040101 = "W2040101";
        /// <summary>
        /// 文本数量
        /// </summary> 
        public const String W2040102 = "W2040102";
        /// <summary>
        /// 功能索引
        /// </summary> 
        public const String W2040103 = "W2040103";
        public const int W2040103_SIZE = 16;
        /// <summary>
        /// 用户编码
        /// </summary>
        public const String W2040104 = "W2040104";
        public const int W2040104_SIZE = 8;
        /// <summary>
        /// 卡片类别
        /// </summary>
        public const String W2040105 = "W2040105";
        public const int W2040105_SIZE = 16;
        /// <summary>
        /// 功能键值
        /// </summary>
        public const String W2040106 = "W2040106";
        public const int W2040106_SIZE = 64;
        /// <summary>
        /// 功能名称
        /// </summary>
        public const String W2040107 = "W2040107";
        public const int W2040107_SIZE = 16;
        /// <summary>
        /// 默认标题
        /// </summary>
        public const String W2040108 = "W2040108";
        public const int W2040108_SIZE = 128;
        /// <summary>
        /// 默认文本1
        /// </summary>
        public const String W2040109 = "W2040109";
        public const int W2040109_SIZE = 256;
        /// <summary>
        /// 默认文本2
        /// </summary>
        public const String W204010A = "W204010A";
        public const int W204010A_SIZE = 256;
        /// <summary>
        /// 默认文本3
        /// </summary>
        public const String W204010B = "W204010B";
        public const int W204010B_SIZE = 256;
        /// <summary>
        /// 字体名称
        /// </summary>
        public const String W204010C = "W204010C";
        public const int W204010C_SIZE = 32;
        /// <summary>
        /// 字体大小
        /// </summary>
        public const String W204010D = "W204010D";
        /// <summary>
        /// 字体颜色
        /// </summary>
        public const String W204010E = "W204010E";
        public const int W204010E_SIZE = 8;
        /// <summary>
        /// 字体风格
        /// </summary>
        public const String W204010F = "W204010F";
        /// <summary>
        /// 横向坐标
        /// </summary>
        public const String W2040110 = "W2040110";
        /// <summary>
        /// 竖向坐标
        /// </summary>
        public const String W2040111 = "W2040111";
        /// <summary>
        /// 相关说明
        /// </summary>
        public const String W2040112 = "W2040112";
        public const int W2040112_SIZE = 1024;
        /// <summary>
        /// 更新日期
        /// </summary>
        public const String W2040113 = "W2040113";
        /// <summary>
        /// 创建日期
        /// </summary>
        public const String W2040114 = "W2040114";
        #endregion
        #endregion

        #endregion

        #region 博客模块
        // ////////////////////////////////////////////////////////////////////
        // 博客模块
        // ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 博客模块
        /// </summary>
        public const String WRP_BLOG = "W3000000";
        #endregion

        #region 论坛模块
        // ////////////////////////////////////////////////////////////////////
        // 论坛模块
        // ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 论坛模块
        /// </summary>
        public const String WRP_IBBS = "W4000000";
        #endregion

        #region 意见模块
        // ////////////////////////////////////////////////////////////////////
        // 意见模块
        // ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 意见模块
        /// </summary>
        public const String WRP_IDEA = "W9000000";

        /// <summary>
        /// 留言模块
        /// </summary>
        public const String WRP_IDEA_IDEADATA = "W9010100";
        /// <summary>
        /// 留言索引
        /// </summary>
        public const String IDEADATA_IDEAINDX = "W9010101";
        /// <summary>
        /// 软件索引
        /// </summary>
        public const String IDEADATA_SOFTINDX = "W9010102";
        /// <summary>
        /// 意见类别
        /// </summary>
        public const String IDEADATA_IDEATYPE = "W9010103";
        /// <summary>
        /// 用户昵称
        /// </summary>
        public const String IDEADATA_NICKNAME = "W9010104";
        /// <summary>
        /// 电子邮件
        /// </summary>
        public const String IDEADATA_USERMAIL = "W9010105";
        /// <summary>
        /// 个人首页
        /// </summary>
        public const String IDEADATA_HOMEPAGE = "W9010106";
        /// <summary>
        /// 日期
        /// </summary>
        public const String IDEADATA_DATETIME = "W9010107";
        /// <summary>
        /// 留言内容
        /// </summary>
        public const String IDEADATA_IDEATEXT = "W9010108";
        #endregion

        #region 帮助模块
        // ////////////////////////////////////////////////////////////////////
        // 帮助模块
        // ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 帮助模块
        /// </summary>
        public const String WRP_HELP = "WE000000";
        #endregion

        #region 关于模块
        // ////////////////////////////////////////////////////////////////////
        // 关于模块
        // ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 关于模块
        /// </summary>
        public const String WRP_TEAM = "WF000000";
        #endregion
    }
}