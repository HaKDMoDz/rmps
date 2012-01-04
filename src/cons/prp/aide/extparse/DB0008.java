/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.extparse;

import cons.SysCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 数据库定义常量
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public interface DB0008
{
    // -----------------------------------------------------
    // 数据库常量数据(DataBase Const String)
    // -----------------------------------------------------
    /** HSQLDB 用JDBC连接驱动 */
    String DBCS_JDBC_DRV = "org.hsqldb.jdbcDriver";
    /** HSQLDB 用FILE文件数据库 */
    String DBCS_CONN_STR = "jdbc:hsqldb:file:";
    /** 数据排序：升序排列 */
    String DBCS_SORT_ASC = "ASC";
    /** 数据排序：降序排列 */
    String DBCS_SORT_DESC = "DESC";
    /** 数据库当前时间 */
    String DBCS_DATE_NOW = "NOW";
    /** 连接查询：交差连接 */
    String DBCS_JOIN_CROSS = "CROSS JOIN";
    /** 连接查询：全连接 */
    String DBCS_JOIN_FULL = "FULL JOIN";
    /** 连接查询：内连接 */
    String DBCS_JOIN_INNER = "INNER JOIN";
    /** 连接查询：左连接 */
    String DBCS_JOIN_LEFT = "LEFT JOIN";
    /** 连接查询：右连接 */
    String DBCS_JOIN_RIGHT = "RIGHT JOIN";
    // -----------------------------------------------------
    // 数据库常量数据(DataBase Const Data)
    // -----------------------------------------------------
    /**
     * 数据配置表格：数据版本标记
     */
    String DBCD_BASE_VERSION = "1";
    /**
     * 数据配置表格：语言配置信息
     */
    String DBCD_BASE_LANGID = "2";
    /**
     * 数据配置表格：界面皮肤信息
     */
    String DBCD_BASE_UILOOK = "3";
    /**
     * 常用语言资源区分标记
     */
    String DBCD_LANG_COMM = "00000008";
    /**
     * 其它语言资源区分标记
     */
    String DBCD_LANG_REST = "00000009";
    /**
     * 链接数据中搜索引擎类别
     */
    String DBCD_LINK_SRCHTYPE = "0";
    // -----------------------------------------------------
    // ExtsData数据表
    // -----------------------------------------------------
    /**
     * 数据库表格名称
     * 
     * @since DBV:6
     */
    String TABLE_EXTSDATA = "Aide_TDA";
    /**
     * 频率区分，用于区分当前后缀信息的使用频率
     * 
     * @since DBV:6
     */
    String EXTSDATA_ACSTIMES = "DAA";
    /**
     * 应用平台列名称
     * 
     * @since DBV:6
     */
    String EXTSDATA_PLATINDX = "DAB";
    /**
     * 处理字长列名称
     * 
     * @since DBV:7
     */
    String EXTSDATA_XCPUBITS = "DAC";
    /**
     * 后缀名称Hash值
     * 
     * @since DBV:6
     */
    String EXTSDATA_EXTSINDX = "DAD";
    int EXTSDATA_EXTSINDX_SIZE = 32;
    /**
     * 公司索引列名称
     * 
     * @since DBV:7
     */
    String EXTSDATA_CORPINDX = "DAE";
    int EXTSDATA_CORPINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 软件索引列名称（外键）
     * 
     * @since DBV:6
     */
    String EXTSDATA_SOFTINDX = "DAF";
    int EXTSDATA_SOFTINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 文件索引列名称（外键）
     * 
     * @since DBV:6
     */
    String EXTSDATA_FILEINDX = "DAG";
    int EXTSDATA_FILEINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 后缀描述列名称（外键）
     * 
     * @since DBV:6
     */
    String EXTSDATA_DESPINDX = "DAH";
    int EXTSDATA_DESPINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 备选软件列表名称（外键）
     * 
     * @since DBV:7
     */
    String EXTSDATA_ASOCINDX = "DAI";
    int EXTSDATA_ASOCINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * MIME类型列名称（外键）
     * 
     * @since DBV:8
     */
    String EXTSDATA_MIMEINDX = "DAJ";
    int EXTSDATA_MIMEINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 所属类别列名称（外键）
     * 
     * @since DBV:6
     */
    String EXTSDATA_TYPEINDX = "DAK";
    int EXTSDATA_TYPEINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 贡献人员索引列名称（外键）
     * 
     * @since DBV:6
     */
    String EXTSDATA_IDIOINDX = "DAL";
    int EXTSDATA_IDIOINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 后缀更新日期列名称
     * 
     * @since DBV:6
     */
    String EXTSDATA_UPDTDATE = "DAM";
    /**
     * 后缀提交日期列名称
     * 
     * @since DBV:7
     */
    String EXTSDATA_MAKEDATE = "DAN";
    /**
     * 后缀名称列名称
     * 
     * @since DBV:6
     */
    String EXTSDATA_EXTSNAME = "DAO";
    int EXTSDATA_EXTSNAME_SIZE = 256;
    /**
     * 个人说明列名称
     * 
     * @since DBV:8
     */
    String EXTSDATA_IDIOMARK = "DAP";
    int EXTSDATA_IDIOMARK_SIZE = SysCons.DBCD_DESP_SIZE;
    // -----------------------------------------------------
    // DespData数据表格
    // -----------------------------------------------------
    /**
     * DespData数据表格名称
     * 
     * @since DBV:6
     */
    String TABLE_DESPDATA = "Aide_TDB";
    /**
     * 描述索引列名称
     * 
     * @since DBV:6
     */
    String DESPDATA_DESPINDX = "DBA";
    int DESPDATA_DESPINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 语言索引列名称
     * 
     * @since DBV:6
     */
    String DESPDATA_LANGINDX = "DBB";
    int DESPDATA_LANGINDX_SIZE = 8;
    /**
     * 后缀描述列名称
     * 
     * @since DBV:6
     */
    String DESPDATA_EXTSDESP = "DBC";
    int DESPDATA_EXTSDESP_SIZE = 2048;
    /**
     * 相关说明列名称
     * 
     * @since DBV:6
     */
    String DESPDATA_IDIOMARK = "DBD";
    int DESPDATA_IDIOMARK_SIZE = SysCons.DBCD_DESP_SIZE;
    /**
     * 更新日期列名称
     * 
     * @since DBV:7
     */
    String DESPDATA_UPDTDATE = "DBE";
    /**
     * 创建日期列名称
     * 
     * @since DBV:7
     */
    String DESPDATA_MAKEDATE = "DBF";
    // -----------------------------------------------------
    // FileData数据表格
    // -----------------------------------------------------
    /**
     * 文件信息数据表格名称
     * 
     * @since DBV:6
     */
    String TABLE_FILEDATA = "Aide_TDC";
    /**
     * 显示排序
     * 
     * @since DBV:7
     */
    String FILEDATA_DISPORDR = "DCA";
    /**
     * 文件索引
     * 
     * @since DBV:6
     */
    String FILEDATA_FILEINDX = "DCB";
    int FILEDATA_FILEINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 直属软件
     * 
     * @since DBV:7
     */
    String FILEDATA_SOFTINDX = "DCC";
    int FILEDATA_SOFTINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 文件图标
     * 
     * @since DBV:6
     */
    String FILEDATA_FILEICON = "DCD";
    int FILEDATA_FILEICON_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 字符签名
     * 
     * @since DBV:6
     */
    String FILEDATA_SIGNCHAR = "DCE";
    int FILEDATA_SIGNCHAR_SIZE = 128;
    /**
     * 数字签名
     * 
     * @since DBV:8
     */
    String FILEDATA_SIGNCODE = "DCF";
    int FILEDATA_SIGNCODE_SIZE = 128;
    /**
     * 偏移位置
     * 
     * @since DBV:6
     */
    String FILEDATA_MSOFFSET = "DCG";
    /**
     * 加密算法
     * 
     * @since DBV:6
     */
    String FILEDATA_CIPHERSN = "DCH";
    int FILEDATA_CIPHERSN_SIZE = 256;
    /**
     * 起始数据
     * 
     * @since DBV:6
     */
    String FILEDATA_HEADDATA = "DCI";
    int FILEDATA_HEADDATA_SIZE = 256;
    /**
     * 结束数据
     * 
     * @since DBV:6
     */
    String FILEDATA_FOOTDATA = "DCJ";
    int FILEDATA_FOOTDATA_SIZE = 256;
    /**
     * 文档格式
     * 
     * @since DBV:6
     */
    String FILEDATA_FORMATDT = "DCK";
    int FILEDATA_FORMATDT_SIZE = 16;
    /**
     * 附注信息
     * 
     * @since DBV:6
     */
    String FILEDATA_FILEDESP = "DCL";
    int FILEDATA_FILEDESP_SIZE = SysCons.DBCD_DESP_SIZE;
    /**
     * 更新日期列名称
     * 
     * @since DBV:7
     */
    String FILEDATA_UPDTDATE = "DCM";
    /**
     * 创建日期列名称
     * 
     * @since DBV:7
     */
    String FILEDATA_MAKEDATE = "DCN";
    // -----------------------------------------------------
    // SoftData数据表格
    // -----------------------------------------------------
    /**
     * 所属软件表格名称
     * 
     * @since DBV:3
     */
    String TABLE_SOFTDATA = "Aide_TDD";
    /**
     * 显示排序
     * 
     * @since DBV:6
     */
    String SOFTDATA_DISPORDR = "DDA";
    /**
     * 软件标记列名称
     * 
     * @since DBV:6
     */
    String SOFTDATA_SOFTINDX = "DDB";
    int SOFTDATA_SOFTINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 公司标记列名称
     * 
     * @since DBV:6
     */
    String SOFTDATA_CORPINDX = "DDC";
    int SOFTDATA_CORPINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 软件图标列名称
     * 
     * @since DBV:6
     */
    String SOFTDATA_SOFTICON = "DDD";
    int SOFTDATA_SOFTICON_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 软件名称列名称
     * 
     * @since DBV:6
     */
    String SOFTDATA_SOFTNAME = "DDE";
    int SOFTDATA_SOFTNAME_SIZE = 128;
    /**
     * 电子邮件
     * 
     * @since DBV:6
     */
    String SOFTDATA_SOFTMAIL = "DDF";
    int SOFTDATA_SOFTMAIL_SIZE = 128;
    /**
     * 链接地址
     * 
     * @since DBV:6
     */
    String SOFTDATA_SOFTSITE = "DDG";
    int SOFTDATA_SOFTSITE_SIZE = SysCons.DBCD_LINK_SIZE;
    /**
     * 兼容后缀
     * 
     * @since DBV:6
     */
    String SOFTDATA_EXTSLIST = "DDH";
    int SOFTDATA_EXTSLIST_SIZE = SysCons.DBCD_DESP_SIZE;
    /**
     * 软件描述列名称
     * 
     * @since DBV:6
     */
    String SOFTDATA_SOFTDESP = "DDI";
    int SOFTDATA_SOFTDESP_SIZE = SysCons.DBCD_DESP_SIZE;
    /**
     * 更新日期列名称
     * 
     * @since DBV:7
     */
    String SOFTDATA_UPDTDATE = "DDJ";
    /**
     * 创建日期列名称
     * 
     * @since DBV:7
     */
    String SOFTDATA_MAKEDATE = "DDK";
    // -----------------------------------------------------
    // CorpData数据表格
    // -----------------------------------------------------
    /**
     * 所属公司数据表格名称
     * 
     * @since DBV:6
     */
    String TABLE_CORPDATA = "Aide_TDE";
    /**
     * 显示排序列名称
     * 
     * @since DBV:7
     */
    String CORPDATA_DISPORDR = "DEA";
    /**
     * 公司标记列名称
     * 
     * @since DBV:6
     */
    String CORPDATA_CORPINDX = "DEB";
    int CORPDATA_CORPINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 公司国别索引列名称
     * 
     * @since DBV:6
     */
    String CORPDATA_NATNINDX = "DEC";
    int CORPDATA_NATNINDX_SIZE = 8;
    /**
     * 公司徽标列名称
     * 
     * @since DBV:6
     */
    String CORPDATA_CORPLOGO = "DED";
    int CORPDATA_CORPLOGO_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 公司本语名称列名称
     * 
     * @since DBV:6
     */
    String CORPDATA_CORPLCNM = "DEE";
    int CORPDATA_CORPLCNM_SIZE = 128;
    /**
     * 公司英语名称列名称
     * 
     * @since DBV:6
     */
    String CORPDATA_CORPENNM = "DEF";
    int CORPDATA_CORPENNM_SIZE = 128;
    /**
     * 公司网址列名称
     * 
     * @since DBV:6
     */
    String CORPDATA_CORPSITE = "DEG";
    int CORPDATA_CORPSITE_SIZE = SysCons.DBCD_LINK_SIZE;
    /**
     * 公司描述列名称
     * 
     * @since DBV:6
     */
    String CORPDATA_CORPDESP = "DEH";
    int CORPDATA_CORPDESP_SIZE = SysCons.DBCD_DESP_SIZE;
    /**
     * 更新日期列名称
     * 
     * @since DBV:7
     */
    String CORPDATA_UPDTDATE = "DEI";
    /**
     * 创建日期列名称
     * 
     * @since DBV:7
     */
    String CORPDATA_MAKEDATE = "DEJ";
    // -----------------------------------------------------
    // AsocData数据表格
    // -----------------------------------------------------
    /**
     * 备选软件表格名称
     * 
     * @since DBV:6
     */
    String TABLE_ASOCDATA = "Aide_TDF";
    /**
     * 显示排序
     * 
     * @since DBV:7
     */
    String ASOCDATA_DISPORDR = "DFA";
    /**
     * 后缀区分
     * 
     * @since DBV:6
     */
    String ASOCDATA_ASOCINDX = "DFB";
    int ASOCDATA_ASOCINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 软件区分
     * 
     * @since DBV:6
     */
    String ASOCDATA_SOFTINDX = "DFC";
    int ASOCDATA_SOFTINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 相差附注
     * 
     * @since DBV:8
     */
    String ASOCDATA_ASOCDESP = "DFD";
    int ASOCDATA_ASOCDESP_SIZE = SysCons.DBCD_DESP_SIZE;
    /**
     * 更新日期
     * 
     * @since DBV:8
     */
    String ASOCDATA_UPDTDATE = "DFE";
    /**
     * 创建日期
     * 
     * @since DBV:8
     */
    String ASOCDATA_MAKEDATE = "DFF";
    // -----------------------------------------------------
    // MimeData数据表格
    // -----------------------------------------------------
    /**
     * MIME类型表格名称
     * 
     * @since DBV:8
     */
    String TABLE_MIMEDATA = "Aide_TDG";
    /**
     * 显示排序
     * 
     * @since DBV:8
     */
    String MIMEDATA_DISPORDR = "DGA";
    /**
     * MIME索引
     * 
     * @since DBV:8
     */
    String MIMEDATA_MIMEINDX = "DGB";
    int MIMEDATA_MIMEINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 类型索引
     * 
     * @since DBV:8
     */
    String MIMEDATA_MIMETYPE = "DGC";
    int MIMEDATA_MIMETYPE_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 类型名称
     * 
     * @since DBV:8
     */
    String MIMEDATA_MIMENAME = "DGD";
    int MIMEDATA_MIMENAME_SIZE = 256;
    /**
     * 类型描述
     * 
     * @since DBV:8
     */
    String MIMEDATA_MIMEDESP = "DGE";
    int MIMEDATA_MIMEDESP_SIZE = SysCons.DBCD_DESP_SIZE;
    /**
     * 更新时间
     * 
     * @since DBV:8
     */
    String MIMEDATA_UPDTDATE = "DGF";
    /**
     * 创建时间
     * 
     * @since DBV:8
     */
    String MIMEDATA_MAKEDATE = "DGG";
    // -----------------------------------------------------
    // LinkData数据表格
    // -----------------------------------------------------
    /**
     * 网络收藏表格名称
     * 
     * @since DBV:5
     */
    String TABLE_LINKDATA = "Aide_TDH";
    /**
     * 排序依据
     * 
     * @since DBV:5
     */
    String LINKDATA_DISPORDR = "DHA";
    /**
     * 链接索引
     * 
     * @since DBV:5
     */
    String LINKDATA_LINKINDX = "DHB";
    int LINKDATA_LINKINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 类别索引
     * 
     * @since DBV:5
     */
    String LINKDATA_TYPEINDX = "DHC";
    int LINKDATA_TYPEINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 链接名称
     * 
     * @since DBV:5
     */
    String LINKDATA_LINKNAME = "DHD";
    int LINKDATA_LINKNAME_SIZE = 128;
    /**
     * 链接路径
     * 
     * @since DBV:5
     */
    String LINKDATA_LINKURLS = "DHE";
    int LINKDATA_LINKURLS_SIZE = SysCons.DBCD_LINK_SIZE;
    /**
     * 关键搜索
     * 
     * @since DBV:5
     */
    String LINKDATA_METAKEYS = "DHF";
    int LINKDATA_METAKEYS_SIZE = 256;
    /**
     * 网站描述
     * 
     * @since DBV:5
     */
    String LINKDATA_METADESP = "DHG";
    int LINKDATA_METADESP_SIZE = 1024;
    /**
     * 链接描述
     * 
     * @since DBV:5
     */
    String LINKDATA_LINKDESP = "DHH";
    int LINKDATA_LINKDESP_SIZE = SysCons.DBCD_DESP_SIZE;
    /**
     * 更新日期列名称
     * 
     * @since DBV:7
     */
    String LINKDATA_UPDTDATE = "DHI";
    /**
     * 创建日期列名称
     * 
     * @since DBV:7
     */
    String LINKDATA_MAKEDATE = "DHJ";
    // -----------------------------------------------------
    // NoteData数据表格
    // -----------------------------------------------------
    /**
     * 迷你日历数据表格
     * 
     * @since DBV:7
     */
    String TABLE_NOTEDATA = "Aide_TDJ";
    /**
     * 排序依据
     * 
     * @since DBV:7
     */
    String NOTEDATA_DISPORDR = "DJA";
    /**
     * 提示索引列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_NOTEINDX = "DJB";
    int NOTEDATA_NOTEINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 语言索引列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_LANGINDX = "DJC";
    int NOTEDATA_LANGINDX_SIZE = 8;
    /**
     * 提示种类列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_NOTETYPE = "DJD";
    int NOTEDATA_NOTETYPE_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 提示方式列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_MINDMODE = "DJE";
    /**
     * 提示年份列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_DATESTTY = "DJF";
    /**
     * 提示月份列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_DATESTTM = "DJG";
    /**
     * 提示日期列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_DATESTTD = "DJH";
    /**
     * 提示时间列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_DATESTTT = "DJI";
    /**
     * 提示结束年份列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_DATEENDY = "DJJ";
    /**
     * 提示结束月份列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_DATEENDM = "DJK";
    /**
     * 提示结束日期列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_DATEENDD = "DJL";
    /**
     * 提示结束时间列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_DATEENDT = "DJM";
    /**
     * 提示标题列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_NOTEHEAD = "DJN";
    int NOTEDATA_NOTEHEAD_SIZE = 128;
    /**
     * 提示内容列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_NOTEBODY = "DJO";
    int NOTEDATA_NOTEBODY_SIZE = 512;
    /**
     * 起源时间列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_ORIGINDT = "DJP";
    int NOTEDATA_ORIGINDT_SIZE = 32;
    /**
     * 起源国度列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_ORIGINNT = "DJQ";
    int NOTEDATA_ORIGINNT_SIZE = 128;
    /**
     * 详细链接列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_NOTELINK = "DJR";
    int NOTEDATA_NOTELINK_SIZE = SysCons.DBCD_LINK_SIZE;
    /**
     * 附注信息列名称
     * 
     * @since DBV:7
     */
    String NOTEDATA_NOTEDESP = "DJS";
    int NOTEDATA_NOTEDESP_SIZE = SysCons.DBCD_DESP_SIZE;
    // -----------------------------------------------------
    // TypeData数据表格
    // -----------------------------------------------------
    /**
     * 所属类别表格名称
     * 
     * @since DBV:6
     */
    String TABLE_TYPEDATA = "Aide_TGA";
    /**
     * 显示排序列名称
     * 
     * @since DBV:6
     */
    String TYPEDATA_DISPORDR = "GAA";
    /**
     * 系统标记
     * 
     * @since DBV:7
     */
    String TYPEDATA_SYSTEMID = "GAB";
    /**
     * 类别标记列名称
     * 
     * @since DBV:6
     */
    String TYPEDATA_TYPEINDX = "GAC";
    int TYPEDATA_TYPEINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 类别的排序依据，用于类别的排序
     * 
     * @since DBV:6
     */
    String TYPEDATA_TYPENAME = "GAD";
    int TYPEDATA_TYPENAME_SIZE = 128;
    /**
     * 类别描述列名称
     * 
     * @since DBV:6
     */
    String TYPEDATA_TYPEDESP = "GAE";
    int TYPEDATA_TYPEDESP_SIZE = SysCons.DBCD_DESP_SIZE;
    // -----------------------------------------------------
    // 公益广告数据表格
    // -----------------------------------------------------
    /**
     * 公益广告表格
     * 
     * @since DBV:7
     */
    String TABLE_PBADDATA = "Aide_TGB";
    /**
     * 显示排序
     * 
     * @since DBV:7
     */
    String PBADDATA_DISPORDR = "GBA";
    /**
     * 广告索引
     * 
     * @since DBV:7
     */
    String PBADDATA_PBADINDX = "GBB";
    int PBADDATA_PBADINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 类别索引
     * 
     * @since DBV:7
     */
    String PBADDATA_TYPEINDX = "GBC";
    int PBADDATA_TYPEINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 广告内容
     * 
     * @since DBV:7
     */
    String PBADDATA_PBADTEXT = "GBD";
    int PBADDATA_PBADTEXT_SIZE = 256;
    /**
     * 相关说明
     * 
     * @since DBV:7
     */
    String PBADDATA_PBADDESP = "GBE";
    int PBADDATA_PBADDESP_SIZE = SysCons.DBCD_DESP_SIZE;
    /**
     * 更新日期
     * 
     * @since DBV:7
     */
    String PBADDATA_UPDTDATE = "GBF";
    /**
     * 提交日期
     * 
     * @since DBV:7
     */
    String PBADDATA_MAKEDATE = "GBG";
    // -----------------------------------------------------
    // 商业因素数据表格
    // -----------------------------------------------------
    /**
     * 商业因素表格
     * 
     * @since DBV:6
     */
    String TABLE_IDIODATA = "Aide_TUA";
    /**
     * 显示排序列名称
     * 
     * @since DBV:7
     */
    String IDIODATA_DISPORDR = "UAA";
    /**
     * 人员索引列名称
     * 
     * @since DBV:6
     */
    String IDIODATA_IDIOINDX = "UAB";
    int IDIODATA_IDIOINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 个性图标列名称
     * 
     * @since DBV:6
     */
    String IDIODATA_IDIOLOGO = "UAC";
    int IDIODATA_IDIOLOGO_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 电子邮件列名称
     * 
     * @since DBV:6
     */
    String IDIODATA_IDIOMAIL = "UAD";
    int IDIODATA_IDIOMAIL_SIZE = 128;
    /**
     * 昵称列名称
     * 
     * @since DBV:6
     */
    String IDIODATA_NICKNAME = "UAE";
    int IDIODATA_NICKNAME_SIZE = 32;
    /**
     * 个性签名列名称
     * 
     * @since DBV:6
     */
    String IDIODATA_IDIOSIGN = "UAF";
    int IDIODATA_IDIOSIGN_SIZE = 128;
    /**
     * 个人主页列名称
     * 
     * @since DBV:6
     */
    String IDIODATA_HOMEPAGE = "UAG";
    int IDIODATA_HOMEPAGE_SIZE = SysCons.DBCD_LINK_SIZE;
    /**
     * 相关说明列名称
     * 
     * @since DBV:6
     */
    String IDIODATA_IDIODESP = "UAH";
    int IDIODATA_IDIODESP_SIZE = SysCons.DBCD_DESP_SIZE;
    /**
     * 提交日期列名称
     * 
     * @since DBV:6
     */
    String IDIODATA_UPDTDATE = "UAI";
    /**
     * 创建时间列名称
     * 
     * @since DBV:7
     */
    String IDIODATA_MAKEDATE = "UAJ";
    // -----------------------------------------------------
    // 数据配置数据表格
    // -----------------------------------------------------
    /**
     * 版本控制数据表格
     * 
     * @since DBV:6
     */
    String TABLE_BASEDATA = "Aide_TXA";
    /**
     * 系统标记ID列名称
     * 
     * @since DBV:6
     */
    String BASEDATA_SYSTEMID = "XAA";
    /**
     * 系统配置区分列名称
     * 
     * @since DBV:6
     */
    String BASEDATA_APARTKEY = "XAB";
    /**
     * 当前版本列名称
     * 
     * @since DBV:6
     */
    String BASEDATA_CFGVALUE = "XAC";
    int BASEDATA_CFGVALUE_SIZE = 32;
    /**
     * 发布日期列名称
     * 
     * @since DBV:6
     */
    String BASEDATA_PUBSTIME = "XAD";
    /**
     * 个人附注信息列名称
     * 
     * @since DBV:6
     */
    String BASEDATA_IDIOMARK = "XAE";
    int BASEDATA_IDIOMARK_SIZE = SysCons.DBCD_DESP_SIZE;
    // -----------------------------------------------------
    // 语言资源数据表格
    // -----------------------------------------------------
    /**
     * 语言资源表格
     * 
     * @since DBV:6
     */
    String TABLE_MESGDATA = "Aide_TXB";
    /**
     * 系统标记
     * 
     * @since DBV:6
     */
    String MESGDATA_SYSTEMID = "XBA";
    /**
     * 语言索引
     * 
     * @since DBV:6
     */
    String MESGDATA_LANGINDX = "XBB";
    int MESGDATA_LANGINDX_SIZE = 8;
    /**
     * 资源索引
     * 
     * @since DBV:6
     */
    String MESGDATA_MESGINDX = "XBC";
    int MESGDATA_MESGINDX_SIZE = 8;
    /**
     * 资源内容
     * 
     * @since DBV:6
     */
    String MESGDATA_MESGTEXT = "XBD";
    int MESGDATA_MESGTEXT_SIZE = 512;
    /**
     * 附注消息
     * 
     * @since DBV:6
     */
    String MESGDATA_MESGDESP = "XBE";
    int MESGDATA_MESGDESP_SIZE = SysCons.DBCD_DESP_SIZE;
    /**
     * 更新日期
     * 
     * @since DBV:6
     */
    String MESGDATA_UPDTDATE = "XBF";
    /**
     * 创建日期
     * 
     * @since DBV:7
     */
    String MESGDATA_MAKEDATE = "XBG";
    // -----------------------------------------------------
    // 语言资源数据表格
    // -----------------------------------------------------
    /**
     * 语言资源表格
     * 
     * @since DBV:7
     */
    String TABLE_NATNDATA = "Aide_TXC";
    /**
     * 显示排序
     * 
     * @since DBV:7
     */
    String NATNDATA_DISPORDR = "XCA";
    /**
     * 国别索引
     * 
     * @since DBV:7
     */
    String NATNDATA_NATNINDX = "XCB";
    int NATNDATA_NATNINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 语言索引
     * 
     * @since DBV:7
     */
    String NATNDATA_LANGINDX = "XCC";
    int NATNDATA_LANGINDX_SIZE = SysCons.DBCD_HASH_SIZE;
    /**
     * 国家简称
     * 
     * @since DBV:7
     */
    String NATNDATA_NATNSLNM = "XCD";
    int NATNDATA_NATNSLNM_SIZE = 128;
    /**
     * 国家全称
     * 
     * @since DBV:7
     */
    String NATNDATA_NATNFLNM = "XCE";
    int NATNDATA_NATNFLNM_SIZE = 256;
    /**
     * 首都本语名称
     * 
     * @since DBV:7
     */
    String NATNDATA_LCAPITAL = "XCF";
    int NATNDATA_LCAPITAL_SIZE = 128;
    /**
     * 第一语言
     * 
     * @since DBV:7
     */
    String NATNDATA_NATNLNG1 = "XCG";
    int NATNDATA_NATNLNG1_SIZE = 128;
    /**
     * 第二语言
     * 
     * @since DBV:7
     */
    String NATNDATA_NATNLNG2 = "XCH";
    int NATNDATA_NATNLNG2_SIZE = 128;
    /**
     * 货币单位
     * 
     * @since DBV:7
     */
    String NATNDATA_COINUNIT = "XCI";
    int NATNDATA_COINUNIT_SIZE = 64;
    /**
     * 货币辅币
     * 
     * @since DBV:7
     */
    String NATNDATA_COINPLUS = "XCJ";
    int NATNDATA_COINPLUS_SIZE = 256;
    /**
     * 更新日期
     * 
     * @since DBV:7
     */
    String NATNDATA_UPDTDATE = "XCK";
    /**
     * 创建日期
     * 
     * @since DBV:7
     */
    String NATNDATA_MAKEDATE = "XCL";
    // /**
    // * 国别代码
    // *
    // * @since DBV:7
    // */
    // String NATNDATA_ABBRCODE = "XCC";
    // int NATNDATA_ABBRCODE_SIZE = 4;
    // /**
    // * 区域代码
    // *
    // * @since DBV:7
    // */
    // String NATNDATA_ZONECODE = "XCD";
    // int NATNDATA_ZONECODE_SIZE = 4;
    // /**
    // * 货币符号
    // *
    // * @since DBV:7
    // */
    // String NATNDATA_COINSIGN = "XCK";
    // int NATNDATA_COINSIGN_SIZE = 8;
    // /**
    // * 国旗
    // *
    // * @since DBV:7
    // */
    // String NATNDATA_NATNFLAG = "XCM";
    // int NATNDATA_NATNFLAG_SIZE = SysCons.DBCD_HASH_SIZE;
    //
    // /**
    // * 国徽
    // *
    // * @since DBV:7
    // */
    // String NATNDATA_NATNEBLM = "XCN";
    // int NATNDATA_NATNEBLM_SIZE = SysCons.DBCD_HASH_SIZE;
    //
    // /**
    // * 国歌
    // *
    // * @since DBV:7
    // */
    // String NATNDATA_NATNATHM = "XCO";
    // int NATNDATA_NATNATHM_SIZE = 256;
    //
    // /**
    // * 所属洲
    // *
    // * @since DBV:7
    // */
    // String NATNDATA_INTCONTL = "XCP";
    // int NATNDATA_INTCONTL_SIZE = SysCons.DBCD_HASH_SIZE;
}
