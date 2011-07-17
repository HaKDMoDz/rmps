using System;

namespace cons.io.db.prp
{
    /// <summary>
    /// PrpCons 的摘要说明
    /// </summary>
    public class PrpCons
    {
        private PrpCons()
        {
        }

        // ========================================================================
        // 辅助模块
        // ========================================================================
        // ----------------------------------------------------
        // 后缀解析
        // ----------------------------------------------------
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 后缀数据
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        /// 后缀数据
        /// </summary>
        public const String P3010000 = "P3010000";
        #region P3010000
        /// <summary> 
        /// 显示排序
        /// </summary>
        public const String P3010001 = "P3010001";
        /// <summary> 
        /// 处理字长
        /// </summary>
        public const String P3010002 = "P3010002";
        /// <summary> 
        /// 后缀索引
        /// </summary>
        public const String P3010003 = "P3010003";
        public const int P3010003_SIZE = 32;
        /// <summary> 
        /// 国别信息
        /// </summary>
        public const String P3010004 = "P3010004";
        public const int P3010004_SIZE = 16;
        /// <summary> 
        /// 公司索引
        /// </summary>
        public const String P3010005 = "P3010005";
        public const int P3010005_SIZE = 16;
        /// <summary> 
        /// 软件索引
        /// </summary>
        public const String P3010006 = "P3010006";
        public const int P3010006_SIZE = 16;
        /// <summary> 
        /// 文件索引
        /// </summary>
        public const String P3010007 = "P3010007";
        public const int P3010007_SIZE = 16;
        /// <summary> 
        /// 文档格式
        /// </summary>
        public const String P3010008 = "P3010008";
        public const int P3010008_SIZE = 16;
        /// <summary> 
        /// 描述索引
        /// </summary>
        public const String P3010009 = "P3010009";
        public const int P3010009_SIZE = 16;
        /// <summary> 
        /// MIME索引
        /// </summary>
        public const String P301000A = "P301000A";
        public const int P301000A_SIZE = 16;
        /// <summary> 
        /// 备选索引
        /// </summary>
        public const String P301000B = "P301000B";
        public const int P301000B_SIZE = 16;
        /// <summary> 
        /// 类别索引
        /// </summary>
        public const String P301000C = "P301000C";
        public const int P301000C_SIZE = 16;
        /// <summary> 
        /// 家族平台
        /// </summary>
        public const String P301000D = "P301000D";
        /// <summary> 
        /// 应用平台
        /// </summary>
        public const String P301000E = "P301000E";
        public const int P301000E_SIZE = 16;
        /// <summary> 
        /// 人员索引
        /// </summary>
        public const String P301000F = "P301000F";
        public const int P301000F_SIZE = 16;
        /// <summary> 
        /// 附注信息
        /// </summary>
        public const String P3010010 = "P3010010";
        public const int P3010010_SIZE = 2048;
        /// <summary> 
        /// 更新日期
        /// </summary>
        public const String P3010011 = "P3010011";
        /// <summary> 
        /// 创建日期
        /// </summary>
        public const String P3010012 = "P3010012";
        /// <summary> 
        /// 文件后缀
        /// </summary>
        public const String P3010013 = "P3010013";
        public const int P3010013_SIZE = 256;
        /// <summary>
        /// 操作流水
        /// </summary>
        public const String P3010014 = "P3010014";
        /// <summary>
        /// 逻辑操作
        /// </summary>
        public const String P3010015 = "P3010015";
        public const int P3010015_SIZE = 1;
        /// <summary>
        /// 用户代码
        /// </summary>
        public const String P3010016 = "P3010016";
        public const int P3010016_SIZE = 8;
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 公司信息
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        /// 公司信息 
        /// </summary>
        public const String P3010100 = "P3010100";
        #region P3010100
        /// <summary>
        /// 公司信息：显示排序 
        /// </summary>
        public const String P3010101 = "P3010101";
        /// <summary>
        /// 公司信息：公司索引 
        /// </summary>
        public const String P3010102 = "P3010102";
        public const int P3010102_SIZE = 16;
        /// <summary>
        /// 公司信息：国别信息 
        /// </summary>
        public const String P3010103 = "P3010103";
        public const int P3010103_SIZE = 8;
        /// <summary>
        /// 公司信息：公司徽标 
        /// </summary>
        public const String P3010104 = "P3010104";
        public const int P3010104_SIZE = 32;
        /// <summary>
        /// 公司信息：本语名称 
        /// </summary>
        public const String P3010105 = "P3010105";
        public const int P3010105_SIZE = 256;
        /// <summary>
        /// 公司信息：英语名称 
        /// </summary>
        public const String P3010106 = "P3010106";
        public const int P3010106_SIZE = 256;
        /// <summary>
        /// 公司信息：公司网址 
        /// </summary>
        public const String P3010107 = "P3010107";
        public const int P3010107_SIZE = SysCons.DBCD_LINK_SIZE;
        /// <summary>
        /// 公司信息：公司描述 
        /// </summary>
        public const String P3010108 = "P3010108";
        public const int P3010108_SIZE = SysCons.DBCD_DESP_SIZE;
        /// <summary>
        /// 公司信息：附注信息 
        /// </summary>
        public const String P3010109 = "P3010109";
        public const int P3010109_SIZE = SysCons.DBCD_DESP_SIZE;
        /// <summary>
        /// 公司信息：更新日期 
        /// </summary>
        public const String P301010A = "P301010A";
        /// <summary>
        /// 公司信息：创建日期 
        /// </summary>
        public const String P301010B = "P301010B";
        /// <summary>
        /// 公司信息：操作流水
        /// </summary>
        public const String P301010C = "P301010C";
        /// <summary>
        /// 公司信息：逻辑操作
        /// </summary>
        public const String P301010D = "P301010D";
        public const int P301010D_SIZE = 1;
        /// <summary>
        /// 公司信息：用户编码
        /// </summary>
        public const String P301010E = "P301010E";
        public const int P301010E_SIZE = 8;
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 软件信息
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        /// 软件信息
        /// </summary>
        public const String P3010200 = "P3010200";
        #region P3010200
        /// <summary> 
        /// 显示排序
        /// </summary>
        public const String P3010201 = "P3010201";
        /// <summary> 
        /// 软件索引
        /// </summary>
        public const String P3010202 = "P3010202";
        public const int P3010202_SIZE = 16;
        /// <summary> 
        /// 公司信息
        /// </summary>
        public const String P3010203 = "P3010203";
        public const int P3010203_SIZE = 16;
        /// <summary> 
        /// 软件图标
        /// </summary>
        public const String P3010204 = "P3010204";
        public const int P3010204_SIZE = 32;
        /// <summary> 
        /// 软件名称
        /// </summary>
        public const String P3010205 = "P3010205";
        public const int P3010205_SIZE = 256;
        /// <summary> 
        /// 英语名称
        /// </summary>
        public const String P3010206 = "P3010206";
        public const int P3010206_SIZE = 256;
        /// <summary> 
        /// 联系邮件
        /// </summary>
        public const String P3010207 = "P3010207";
        public const int P3010207_SIZE = 256;
        /// <summary> 
        /// 链接地址
        /// </summary>
        public const String P3010208 = "P3010208";
        public const int P3010208_SIZE = 1024;
        /// <summary> 
        /// 兼容后缀
        /// </summary>
        public const String P3010209 = "P3010209";
        public const int P3010209_SIZE = 2048;
        /// <summary> 
        /// 运行截图
        /// </summary>
        public const String P301020A = "P301020A";
        public const int P301020A_SIZE = 16;
        /// <summary> 
        /// 软件描述
        /// </summary>
        public const String P301020B = "P301020B";
        public const int P301020B_SIZE = 2048;
        /// <summary> 
        /// 附注信息
        /// </summary>
        public const String P301020C = "P301020C";
        public const int P301020C_SIZE = 2048;
        /// <summary> 
        /// 更新日期
        /// </summary>
        public const String P301020D = "P301020D";
        /// <summary> 
        /// 创建日期
        /// </summary>
        public const String P301020E = "P301020E";
        /// <summary>
        /// 操作流水
        /// </summary>
        public const String P301020F = "P301020F";
        /// <summary>
        /// 逻辑操作
        /// </summary>
        public const String P3010210 = "P3010210";
        public const int P3010210_SIZE = 1;
        /// <summary>
        /// 用户编码
        /// </summary>
        public const String P3010211 = "P3010211";
        public const int P3010211_SIZE = 8;
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 文件信息
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        ///  文件信息 
        /// </summary>
        public const String P3010300 = "P3010300";
        #region P3010300
        /// <summary>
        ///  文件信息：显示排序 
        /// </summary>
        public const String P3010301 = "P3010301";
        /// <summary>
        ///  文件信息：文件索引 
        /// </summary>
        public const String P3010302 = "P3010302";
        public const int P3010302_SIZE = 16;
        /// <summary>
        ///  文件信息：软件索引 
        /// </summary>
        public const String P3010303 = "P3010303";
        public const int P3010303_SIZE = 16;
        /// <summary>
        ///  文件信息：文件图标 
        /// </summary>
        public const String P3010304 = "P3010304";
        public const int P3010304_SIZE = 32;
        /// <summary>
        ///  文件信息：签名字符 
        /// </summary>
        public const String P3010305 = "P3010305";
        public const int P3010305_SIZE = 256;
        /// <summary>
        ///  文件信息：签名数值 
        /// </summary>
        public const String P3010306 = "P3010306";
        public const int P3010306_SIZE = 256;
        /// <summary>
        ///  文件信息：偏移位置 
        /// </summary>
        public const String P3010307 = "P3010307";
        /// <summary>
        ///  文件信息：加密算法 
        /// </summary>
        public const String P3010308 = "P3010308";
        public const int P3010308_SIZE = 256;
        /// <summary>
        ///  文件信息：起始数据 
        /// </summary>
        public const String P3010309 = "P3010309";
        public const int P3010309_SIZE = 512;
        /// <summary>
        ///  文件信息：结束数据 
        /// </summary>
        public const String P301030A = "P301030A";
        public const int P301030A_SIZE = 512;
        /// <summary>
        ///  文件信息：文件描述 
        /// </summary>
        public const String P301030B = "P301030B";
        public const int P301030B_SIZE = 2048;
        /// <summary>
        ///  文件信息：附注信息 
        /// </summary>
        public const String P301030C = "P301030C";
        public const int P301030C_SIZE = 2048;
        /// <summary>
        ///  文件信息：更新日期 
        /// </summary>
        public const String P301030D = "P301030D";
        /// <summary>
        ///  文件信息：创建日期 
        /// </summary>
        public const String P301030E = "P301030E";
        /// <summary>
        /// 文件信息：操作流水
        /// </summary>
        public const String P301030F = "P301030F";
        /// <summary>
        /// 文件信息：逻辑操作
        /// </summary>
        public const String P3010310 = "P3010310";
        public const int P3010310_SIZE = 1;
        /// <summary>
        /// 文件信息：用户代码
        /// </summary>
        public const String P3010311 = "P3010311";
        public const int P3010311_SIZE = 8;
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 文档格式
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        ///  文档格式 
        /// </summary>
        public const String P3010400 = "P3010400";
        #region P3010400
        /// <summary>
        /// 显示排序
        /// </summary>
        public const String P3010401 = "P3010401";
        /// <summary>
        /// 文档索引
        /// </summary>
        public const String P3010402 = "P3010402";
        public const int P3010402_SIZE = 16;
        /// <summary>
        /// 语言索引
        /// </summary>
        public const String P3010403 = "P3010403";
        public const int P3010403_SIZE = 16;
        /// <summary>
        /// 文档路径
        /// </summary>
        public const String P3010404 = "P3010404";
        public const int P3010404_SIZE = 32;
        /// <summary>
        /// 文档名称
        /// </summary>
        public const String P3010405 = "P3010405";
        public const int P3010405_SIZE = 256;
        /// <summary>
        /// 发行版本
        /// </summary>
        public const String P3010406 = "P3010406";
        public const int P3010406_SIZE = 32;
        /// <summary>
        /// 发行日期
        /// </summary>
        public const String P3010407 = "P3010407";
        public const int P3010407_SIZE = 32;
        /// <summary>
        /// 文档摘要
        /// </summary>
        public const String P3010408 = "P3010408";
        public const int P3010408_SIZE = 1024;
        /// <summary>
        /// 附注信息
        /// </summary>
        public const String P3010409 = "P3010409";
        public const int P3010409_SIZE = 2048;
        /// <summary>
        /// 更新日期
        /// </summary>
        public const String P301040A = "P301040A";
        /// <summary>
        /// 创建日期
        /// </summary>
        public const String P301040B = "P301040B";
        /// <summary>
        /// 操作流水
        /// </summary>
        public const String P301040C = "P301040C";
        /// <summary>
        /// 逻辑操作
        /// </summary>
        public const String P301040D = "P301040D";
        public const int P301040D_SIZE = 1;
        /// <summary>
        /// 用户代码
        /// </summary>
        public const String P301040E = "P301040E";
        public const int P301040E_SIZE = 8;
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 描述信息
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        ///  描述信息 
        /// </summary>
        public const String P3010500 = "P3010500";
        #region P3010500
        /// <summary>
        ///  描述信息：描述索引 
        /// </summary>
        public const String P3010501 = "P3010501";
        public const int P3010501_SIZE = 16;
        /// <summary>
        ///  描述信息：语言索引 
        /// </summary>
        public const String P3010502 = "P3010502";
        public const int P3010502_SIZE = 16;
        /// <summary>
        ///  描述信息：描述内容 
        /// </summary>
        public const String P3010503 = "P3010503";
        public const int P3010503_SIZE = 2048;
        /// <summary>
        ///  描述信息：附注信息 
        /// </summary>
        public const String P3010504 = "P3010504";
        public const int P3010504_SIZE = 2048;
        /// <summary>
        ///  描述信息：更新日期 
        /// </summary>
        public const String P3010505 = "P3010505";
        /// <summary>
        ///  描述信息：创建日期 
        /// </summary>
        public const String P3010506 = "P3010506";
        /// <summary>
        /// 操作流水
        /// </summary>
        public const String P3010507 = "P3010507";
        /// <summary>
        /// 逻辑操作
        /// </summary>
        public const String P3010508 = "P3010508";
        public const int P3010508_SIZE = 1;
        /// <summary>
        /// 用户代码
        /// </summary>
        public const String P3010509 = "P3010509";
        public const int P3010509_SIZE = 8;
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // MIME信息
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        ///  MIME信息 
        /// </summary>
        public const String P3010600 = "P3010600";
        #region P3010600
        /// <summary>
        ///  MIME信息：显示排序 
        /// </summary>
        public const String P3010601 = "P3010601";
        /// <summary>
        ///  MIME信息：特别后缀 
        /// </summary>
        public const String P3010602 = "P3010602";
        public const int P3010602_SIZE = 16;
        /// <summary>
        ///  MIME信息：MIME类型 
        /// </summary>
        public const String P3010603 = "P3010603";
        public const int P3010603_SIZE = 16;
        /// <summary>
        ///  MIME信息：附注信息 
        /// </summary>
        public const String P3010604 = "P3010604";
        public const int P3010604_SIZE = 2048;
        /// <summary>
        ///  MIME信息：更新日期 
        /// </summary>
        public const String P3010605 = "P3010605";
        /// <summary>
        ///  MIME信息：创建日期 
        /// </summary>
        public const String P3010606 = "P3010606";
        /// <summary>
        /// 操作流水
        /// </summary>
        public const String P3010607 = "P3010607";
        /// <summary>
        /// 逻辑操作
        /// </summary>
        public const String P3010608 = "P3010608";
        public const int P3010608_SIZE = 1;
        /// <summary>
        /// 用户代码
        /// </summary>
        public const String P3010609 = "P3010609";
        public const int P3010609_SIZE = 8;
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 备选软件
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        /// 备选软件
        /// </summary>
        public const String P3010700 = "P3010700";
        #region P3010700
        /// <summary> 
        /// 显示排序
        /// </summary>
        public const String P3010701 = "P3010701";
        /// <summary> 
        /// 应用平台
        /// </summary>
        public const String P3010702 = "P3010702";
        /// <summary> 
        /// 特别后缀
        /// </summary>
        public const String P3010703 = "P3010703";
        public const int P3010703_SIZE = 16;
        /// <summary> 
        /// 备选软件
        /// </summary>
        public const String P3010704 = "P3010704";
        public const int P3010704_SIZE = 16;
        /// <summary> 
        /// 执行权限
        /// </summary>
        public const String P3010705 = "P3010705";
        public const int P3010705_SIZE = 4;
        /// <summary> 
        /// 附注信息
        /// </summary>
        public const String P3010706 = "P3010706";
        public const int P3010706_SIZE = 2048;
        /// <summary> 
        /// 更新日期
        /// </summary>
        public const String P3010707 = "P3010707";
        /// <summary> 
        /// 创建日期
        /// </summary>
        public const String P3010708 = "P3010708";
        /// <summary>
        /// 操作流水
        /// </summary>
        public const String P3010709 = "P3010709";
        /// <summary>
        /// 逻辑操作
        /// </summary>
        public const String P301070A = "P301070A";
        public const int P301070A_SIZE = 1;
        /// <summary>
        /// 用户代码
        /// </summary>
        public const String P301070B = "P301070B";
        public const int P301070B_SIZE = 8;
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 操作平台
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        ///  操作平台 
        /// </summary>
        public const String P3010800 = "P3010800";
        #region P3010800
        /// <summary>
        /// 显示排序
        /// </summary>
        public const String P3010801 = "P3010801";
        /// <summary>
        /// 平台索引
        /// </summary>
        public const String P3010802 = "P3010802";
        public const int P3010802_SIZE = 16;
        /// <summary>
        /// 操作平台
        /// </summary>
        public const String P3010803 = "P3010803";
        public const int P3010803_SIZE = 16;
        /// <summary>
        /// 附注信息
        /// </summary>
        public const String P3010804 = "P3010804";
        public const int P3010804_SIZE = 2048;
        /// <summary>
        /// 更新日期
        /// </summary>
        public const String P3010805 = "P3010805";
        /// <summary>
        /// 创建日期
        /// </summary>
        public const String P3010806 = "P3010806";
        /// <summary>
        /// 操作流水
        /// </summary>
        public const String P3010807 = "P3010807";
        /// <summary>
        /// 逻辑操作
        /// </summary>
        public const String P3010808 = "P3010808";
        public const int P3010808_SIZE = 1;
        /// <summary>
        /// 用户代码
        /// </summary>
        public const String P3010809 = "P3010809";
        public const int P3010809_SIZE = 8;
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // MIME数据
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        ///  MIME数据 
        /// </summary>
        public const String P301F100 = "P301F100";
        #region P301F100
        /// <summary>
        ///  MIME数据：显示排序 
        /// </summary>
        public const String P301F101 = "P301F101";
        /// <summary>
        ///  MIME数据：MIME索引 
        /// </summary>
        public const String P301F102 = "P301F102";
        public const int P301F102_SIZE = 16;
        /// <summary>
        ///  MIME数据：语言索引 
        /// </summary>
        public const String P301F103 = "P301F103";
        public const int P301F103_SIZE = 16;
        /// <summary>
        ///  MIME数据：MIME名称 
        /// </summary>
        public const String P301F104 = "P301F104";
        public const int P301F104_SIZE = 256;
        /// <summary>
        ///  MIME数据：MIME说明 
        /// </summary>
        public const String P301F105 = "P301F105";
        public const int P301F105_SIZE = 2048;
        /// <summary>
        ///  MIME数据：附注信息 
        /// </summary>
        public const String P301F106 = "P301F106";
        public const int P301F106_SIZE = 2048;
        /// <summary>
        ///  MIME数据：更新日期 
        /// </summary>
        public const String P301F107 = "P301F107";
        /// <summary>
        ///  MIME数据：创建日期 
        /// </summary>
        public const String P301F108 = "P301F108";
        /// <summary>
        /// 操作流水
        /// </summary>
        public const String P301F109 = "P301F109";
        /// <summary>
        /// 逻辑操作
        /// </summary>
        public const String P301F10A = "P301F10A";
        public const int P301F10A_SIZE = 1;
        /// <summary>
        /// 用户代码
        /// </summary>
        public const String P301F10B = "P301F10B";
        public const int P301F10B_SIZE = 8;
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 平台数据
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        /// 平台数据
        /// </summary>
        public const String P301F200 = "P301F200";
        #region P301F200
        /// <summary>
        /// 显示排序
        /// </summary>
        public const String P301F201 = "P301F201";
        /// <summary>
        /// 所属家族
        /// </summary>
        public const String P301F202 = "P301F202";
        /// <summary>
        /// 平台索引
        /// </summary>
        public const String P301F203 = "P301F203";
        public const int P301F203_SIZE = 16;
        /// <summary>
        /// 语言索引
        /// </summary>
        public const String P301F204 = "P301F204";
        public const int P301F204_SIZE = 16;
        /// <summary>
        /// 平台类别
        /// </summary>
        public const String P301F205 = "P301F205";
        public const int P301F205_SIZE = 16;
        /// <summary>
        /// 平台名称
        /// </summary>
        public const String P301F206 = "P301F206";
        public const int P301F206_SIZE = 256;
        /// <summary>
        /// 平台图标
        /// </summary>
        public const String P301F207 = "P301F207";
        public const int P301F207_SIZE = 16;
        /// <summary>
        /// 平台图片
        /// </summary>
        public const String P301F208 = "P301F208";
        public const int P301F208_SIZE = 16;
        /// <summary>
        /// 平台首页
        /// </summary>
        public const String P301F209 = "P301F209";
        public const int P301F209_SIZE = 1024;
        /// <summary>
        /// 平台说明
        /// </summary>
        public const String P301F20A = "P301F20A";
        public const int P301F20A_SIZE = 2048;
        /// <summary>
        /// 附注信息
        /// </summary>
        public const String P301F20B = "P301F20B";
        public const int P301F20B_SIZE = 2048;
        /// <summary>
        /// 更新日期
        /// </summary>
        public const String P301F20C = "P301F20C";
        /// <summary>
        /// 创建日期
        /// </summary>
        public const String P301F20D = "P301F20D";
        /// <summary>
        /// 操作流水
        /// </summary>
        public const String P301F20E = "P301F20E";
        /// <summary>
        /// 逻辑操作
        /// </summary>
        public const String P301F20F = "P301F20F";
        public const int P301F20F_SIZE = 1;
        /// <summary>
        /// 用户代码
        /// </summary>
        public const String P301F210 = "P301F210";
        public const int P301F210_SIZE = 8;
        #endregion

        // ----------------------------------------------------
        // 链接收藏
        // ----------------------------------------------------
        /// <summary>
        /// 链接收藏
        /// </summary>
        public const String P3070100 = "P3070100";
        #region P3070100
        /// <summary>
        /// 排序依据 
        /// </summary>
        public const String P3070101 = "P3070101";
        /// <summary>
        /// 使用状态 
        /// </summary>
        public const String P3070102 = "P3070102";
        /// <summary>
        /// 系统标记
        /// </summary>
        public const String P3070103 = "P3070103";
        public const int P3070103_SIZE = 8;
        /// <summary>
        /// 快捷地址
        /// </summary>
        public const String P3070104 = "P3070104";
        public const int P3070104_SIZE = 16;
        /// <summary>
        /// 链接索引
        /// </summary>
        public const String P3070105 = "P3070105";
        public const int P3070105_SIZE = 16;
        /// <summary>
        /// 门户索引
        /// </summary>
        public const String P3070106 = "P3070106";
        public const int P3070106_SIZE = 16;
        /// <summary>
        /// 网站徽标
        /// </summary>
        public const String P3070107 = "P3070107";
        public const int P3070107_SIZE = 256;
        /// <summary>
        /// 网站标题 
        /// </summary>
        public const String P3070108 = "P3070108";
        public const int P3070108_SIZE = 256;
        /// <summary>
        /// 链接路径 
        /// </summary>
        public const String P3070109 = "P3070109";
        public const int P3070109_SIZE = 1024;
        /// <summary>
        /// 关键搜索 
        /// </summary>
        public const String P307010A = "P307010A";
        public const int P307010A_SIZE = 1024;
        /// <summary>
        /// 网站描述 
        /// </summary>
        public const String P307010B = "P307010B";
        public const int P307010B_SIZE = 2048;
        /// <summary>
        /// 相关说明 
        /// </summary>
        public const String P307010C = "P307010C";
        public const int P307010C_SIZE = 2048;
        /// <summary>
        /// 更新日期 
        /// </summary>
        public const String P307010D = "P307010D";
        /// <summary>
        /// 提交日期 
        /// </summary>
        public const String P307010E = "P307010E";
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 分类链接
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        /// 分类链接
        /// </summary>
        public const String P3070200 = "P3070200";
        #region P3070200
        /// <summary>
        /// 显示排序
        /// </summary>
        public const String P3070201 = "P3070201";
        /// <summary>
        /// 用户代码
        /// </summary>
        public const String P3070202 = "P3070202";
        public const int P3070202_SIZE = 8;
        /// <summary>
        /// 类别索引
        /// </summary>
        public const String P3070203 = "P3070203";
        public const int P3070203_SIZE = 16;
        /// <summary>
        /// 链接索引
        /// </summary>
        public const String P3070204 = "P3070204";
        public const int P3070204_SIZE = 16;
        /// <summary>
        /// 链接名称 
        /// </summary>
        public const String P3070205 = "P3070205";
        public const int P3070205_SIZE = 256;
        /// <summary>
        /// 相关说明
        /// </summary>
        public const String P3070206 = "P3070206";
        public const int P3070206_SIZE = 2048;
        /// <summary>
        /// 更新日期
        /// </summary>
        public const String P3070207 = "P3070207";
        /// <summary>
        /// 创建日期
        /// </summary>
        public const String P3070208 = "P3070208";
        #endregion

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // 链接类别
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        ///// <summary>
        ///// 分类链接 
        ///// </summary>
        //public const String P3070A00 = "P3070A00";

        ///// <summary>
        ///// 排序依据
        ///// </summary>
        //public const String P3070A01 = "P3070A01";

        ///// <summary>
        ///// 使用状态
        ///// </summary>
        //public const String P3070A02 = "P3070A02";

        ///// <summary>
        ///// 用户代码
        ///// </summary>
        //public const String P3070A03 = "P3070A03";
        //public const int P3070A03_SIZE = 8;

        ///// <summary>
        ///// 上级索引
        ///// </summary>
        //public const String P3070A04 = "P3070A04";
        //public const int P3070A04_SIZE = 16;

        ///// <summary>
        ///// 类别索引 
        ///// </summary>
        //public const String P3070A05 = "P3070A05";
        //public const int P3070A05_SIZE = 16;

        ///// <summary>
        ///// 类别名称
        ///// </summary>
        //public const String P3070A06 = "P3070A06";
        //public const int P3070A06_SIZE = 64;

        ///// <summary>
        ///// 相关说明
        ///// </summary>
        //public const String P3070A07 = "P3070A07";
        //public const int P3070A07_SIZE = 2048;

        ///// <summary>
        ///// 更新日期
        ///// </summary>
        //public const String P3070A08 = "P3070A08";

        ///// <summary>
        ///// 创建日期
        ///// </summary>
        //public const String P3070A09 = "P3070A09";

        #region 日历系统
        // ----------------------------------------------------
        // 日历系统
        // ----------------------------------------------------
        /// <summary>
        ///  日历系统 
        /// </summary>
        public const String P3100100 = "P3100100";

        /// <summary>
        /// 鲜花
        /// </summary>
        public const String P3100101 = "P3100101";

        /// <summary>
        /// 鸡蛋
        /// </summary>
        public const String P3100102 = "P3100102";

        /// <summary>
        /// 索引
        /// </summary>
        public const String P3100103 = "P3100103";
        public const int P3100103_SIZE = 16;

        /// <summary>
        /// 日历/时间
        /// </summary>
        public const String P3100104 = "P3100104";
        public const int P3100104_SIZE = 16;

        /// <summary>
        /// 类别
        /// </summary>
        public const String P3100105 = "P3100105";
        public const int P3100105_SIZE = 1;

        /// <summary>
        /// 文件
        /// </summary>
        public const String P3100106 = "P3100106";
        public const int P3100106_SIZE = 256;

        /// <summary>
        /// 简短说明
        /// </summary>
        public const String P3100107 = "P3100107";
        public const int P3100107_SIZE = 256;

        /// <summary>
        /// 概要说明
        /// </summary>
        public const String P3100108 = "P3100108";
        public const int P3100108_SIZE = 2048;

        /// <summary>
        /// 更新时间
        /// </summary>
        public const String P3100109 = "P3100109";

        /// <summary>
        /// 创建时间
        /// </summary>
        public const String P310010A = "P310010A";
        #endregion
    }
}