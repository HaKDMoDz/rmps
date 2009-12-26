/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P3010000;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 后缀解析系统多国语言资源
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public interface LangRes
{
    /** 数据库数据：已删除 */
    String DBCD_DELETEED = "<已删除>";
    /** 数据库数据：默认 */
    String DBCD_DEFAULT = "<默认>";
    /** 数据库数据：不存在 */
    String DBCD_NOTEXIST = "<不存在>";
    /** 数据库数据：未知 */
    String DBCD_UNKNOWN = "<未知>";
    // ////////////////////////////////////////////////////////////////////////
    // 复用资源常量
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////
    // 窗口标题资源常量
    // ////////////////////////////////////////////////////////////////////////
    /** 主窗口标题信息 */
    String TITLE_FRAME = "13010001";
    // 后缀解析";
    /** 对话框标题信息 */
    String TITLE_MESSAGE = "13010002";
    // 温馨提示";
    /** 迷你模式窗口标题 */
    String TITLE_MINIFORM = "13010003";
    // 迷你模式";
    /** 正常模式窗口标题 */
    String TITLE_MAINFORM = "13010004";
    // 正常模式";
    /** 高级模式窗口标题 */
    String TITLE_CPLXFORM = "13010005";
    // 高级模式";
    /** 后缀管理窗口标题 */
    String TITLE_EXTSFORM = "13010006";
    // 后缀管理";
    /** 公司信息窗口标题 */
    String TITLE_CORPFORM = "13010007";
    // 公司信息";
    /** 软件信息窗口标题 */
    String TITLE_SOFTFORM = "13010008";
    // 软件信息";
    /** 文件信息窗口标题 */
    String TITLE_FILEFORM = "13010009";
    // 文件信息";
    /** 个人信息窗口标题 */
    String TITLE_IDIOFORM = "1301000A";
    // 特别致谢";
    /** 描述信息窗口标题 */
    String TITLE_DESPFORM = "1301000B";
    // 描述信息";
    /** MIME类型窗口标题 */
    String TITLE_MIMEFORM = "1301000C";
    // MIME类型
    /** 备选软件信息窗口标题 */
    String TITLE_ASOCFORM = "1301000D";
    // 备选软件";
    /**  */
    String TITLE_INSERT = " - 新增";
    /**  */
    String TITLE_UPDATE = " - 更新";
    // ----------------------------------------------------
    // 系统初始化
    // ----------------------------------------------------
    /** 系统初始化语言资源 */
    String MESG_INIT_0000 = "13010100";
    // 系统共用语言资源区域";
    /** 联系作者1 */
    String MESG_INIT_0001 = "13010101";
    // 后缀解析";
    /** 联系作者2 */
    String MESG_INIT_0002 = "13010102";
    // Amon";
    /** 联系作者3 */
    String MESG_INIT_0003 = "13010103";
    // AmonSoft";
    /** 联系作者4 */
    String MESG_INIT_0004 = "13010104";
    // http://www.amonsoft.cn/";
    /** 联系作者5 */
    String MESG_INIT_0005 = "13010105";
    // http://www.amonsoft.com/";
    /** 联系作者6 */
    String MESG_INIT_0006 = "13010106";
    // 联系作者";
    /** 联系作者7 */
    String MESG_INIT_0007 = "13010107";
    // 联系作者：Amonsoft@gmail.com";
    /** 联系作者8 */
    String MESG_INIT_0008 = "13010108";
    // 如果您有什么好的意见或建议，欢迎与作者联系！";
    /** 联系作者9 */
    String MESG_INIT_0009 = "13010109";
    // 如果您有什么问题，请与作者联系！";
    /** 联系作者10 */
    String MESG_INIT_0010 = "1301010A";
    // 对此引起的不便作者深表歉意，如果您有什么问题请与作者联系！";
    /** 联系作者11 */
    String MESG_INIT_0011 = "1301010B";
    /** 联系作者12 */
    String MESG_INIT_0012 = "1301010C";
    /** 联系作者13 */
    String MESG_INIT_0013 = "1301010D";
    /** 联系作者14 */
    String MESG_INIT_0014 = "1301010E";
    /** 联系作者15 */
    String MESG_INIT_0015 = "1301010F";
    // ----------------------------------------------------
    // 数据检测
    // ----------------------------------------------------
    /** 数据合法性检测 */
    String MESG_CHCK_0000 = "MSGC0000";
    // 后缀解析窗口数据合法性检测语言资源
    /** 数据不能为空 */
    String MESG_CHCK_0001 = "13010301";
    // “{0}” 数据不能为空，请重新输入！";
    /** 输入数据字符长度超限 */
    String MESG_CHCK_0002 = "13010302";
    // {0} 允许最大字符个数为 {1}，请适当减少您的输入字符个数！";
    /** 电子邮件格式不正确 */
    String MESG_CHCK_0003 = "13010303";
    // “{0}” 不是有效的电子邮件格式，请确认您的输入格式为：“someone@hostname.com”！";
    /** 链接地址格式不正确 */
    String MESG_CHCK_0004 = "13010304";
    // “{0}” 不是有效的网络地址格式，请确认您的输入格式为：“http://www.hostname.com/”！";
    // ----------------------------------------------------
    // 数据查询
    // ----------------------------------------------------
    /** 数据查询成功！ */
    String MESG_SELT_0001 = "13010401";
    // 数据查询成功！";
    /** 数据查询失败! */
    String MESG_SELT_0002 = "13010402";
    // 数据查询失败！";
    /** 数据不存在 */
    String MESG_SELT_0003 = "13010403";
    // 您要查询的数据信息不存在！";
    /** 未知错误 */
    String MESG_SELT_0004 = "13010404";
    // 数据库操作出现未知错误，{0}";
    /** 数据查询成功 */
    String MESG_SELT_0005 = "13010405";
    // {0}查询成功！";
    /** 数据不存在 */
    String MESG_SELT_0006 = "13010406";
    // {0}为 {1} 的{2}不存在！";
    /** 数据查询失败 */
    String MESG_SELT_0007 = "13010407";
    // {0}查询出现未知错误，{1}";
    /** 数据不存在，询问是否添加 */
    String MESG_SELT_0008 = "13010408";
    // 您要查询的{0}为 “{1}” 的{2}不存在，要添加此数据么？";
    // ----------------------------------------------------
    // 数据更新
    // ----------------------------------------------------
    /** 数据更新成功！ */
    String MESG_UPDT_0001 = "13010501";
    // 数据更新成功！";
    /** 数据更新失败！ */
    String MESG_UPDT_0002 = "13010502";
    // 数据更新失败！";
    /** 数据更新出现未知错误，{0} */
    String MESG_UPDT_0003 = "13010503";
    // 数据更新出现未知错误，{0}";
    /** 数据更新成功 */
    String MESG_UPDT_0004 = "13010504";
    // {0}数据更新成功！";
    /** 数据更新错误 */
    String MESG_UPDT_0005 = "13010505";
    // {0}数据更新出现未知错误，{1}";
    /** 您要添加的数据已存在 */
    String MESG_UPDT_0006 = "13010506";
    // 您要添加的数据已存在！";
    // ----------------------------------------------------
    // 数据删除
    // ----------------------------------------------------
    /** 数据删除成功！ */
    String MESG_DELT_0001 = "13010601";
    // 数据删除成功！";
    /** 数据删除失败！ */
    String MESG_DELT_0002 = "13010602";
    // 数据删除失败！";
    /** 数据删除出现未知错误，{0} */
    String MESG_DELT_0003 = "13010603";
    // 数据删除出现未知错误，{0}";
    /** 选择删除数据提示 */
    String MESG_DELT_0004 = "13010604";
    // 请选择您要删除的数据！";
    /** 数据删除成功 */
    String MESG_DELT_0005 = "13010605";
    // {0}为 {1} 的{2}数据已删除！";
    /** 数据删除错误 */
    String MESG_DELT_0006 = "13010606";
    // {0}删除出现未知错误，{1}";
    /** 数据删除确认 */
    String MESG_DELT_0007 = "13010607";
    // 确认要删除{0}为 “{1}” 的{2}数据吗？";
    // ----------------------------------------------------
    // 其它提示
    // ----------------------------------------------------
    /** 系统界面风格更新，提示重新启动 */
    String MESG_OTHR_0001 = "13010701";
    // 一些高级界面风格需要重新启动应用程序，并在下一次启动应用程序时生效。";
    /** 界面语言更新 */
    String MESG_OTHR_0002 = "13010702";
    // 界面语言已更新，请重新启动应用程序！";
    /** 文件后缀信息不存在 */
    String MESG_OTHR_0003 = "13010703";
    // 指定文件 “<font color=\"#FF0000\">{0}</font>” 后缀不存在！";
    /** 语言列表读取错误 */
    String MESG_OTHR_0004 = "13010704";
    // 语言列表读取错误，{0}";
    /** 配置文件读取错误 */
    String MESG_OTHR_0005 = "13010705";
    // 配置文件读取错误，远程文件不是一个合法的文件。";
    /** 网络连接错误 */
    String MESG_OTHR_0006 = "13010706";
    // 网络连接错误，无法读取服务器配置文件，请检测您的网络配置是否正确后重试！";
    /** 已是最新版本 */
    String MESG_OTHR_0007 = "13010707";
    // 您的当前版本已经是最新版本，无需升级操作，感谢您对此软件的关注。";
    /** 已有新版本 */
    String MESG_OTHR_0008 = "13010708";
    // 发现新的版本，请到软件首页下载最新版本的软件，感谢您对此软件的关注。";
    // ----------------------------------------------------
    // 其它常量
    // ----------------------------------------------------
    /** 文件打开保存对话框后缀类型：所有文件 */
    String FILE_FILTER_ALL = "13010F01";
    // 所有(*.*)|*.*";
    String FILE_FILTER_ALL_DSP = "13010F02";
    // 所有(*.*)";
    String FILE_FILTER_ALL_REG = "13010F03";
    /** 文件打开保存对话框后缀类型：仅网页格式文件 */
    String FILE_FILTER_HTM = "13010F04";
    // HTM网页文件(*.HTML)|*.html";
    String FILE_FILTER_HTM_DSP = "13010F05";
    // HTM网页文件(*.HTML)";
    String FILE_FILTER_HTM_REG = "13010F06";
    // .html";
    /** 文件打开保存对话框后缀类型：仅PNG格式文件 */
    String[] FILE_FILTER_IMG =
    {
        "13010F07"
    };
    String[] FILE_FILTER_IMG_DSP =
    {
        "13010F08"
    };
    String[] FILE_FILTER_IMG_REG =
    {
        "13010F09"
    };
    // .png";
    /** 文件打开保存对话框后缀类型：仅PNG格式文件 */
    String FILE_FILTER_PNG = "13010F0A";
    // PNG文件(*.PNG)|*.png";
    String FILE_FILTER_PNG_DSP = "13010F0B";
    // PNG文件(*.PNG)";
    String FILE_FILTER_PNG_REG = "13010F0C";
    // .png";
    /** 文件打开保存对话框后缀类型：仅文本格式文件 */
    String FILE_FILTER_TXT = "13010F0D";
    // TXT文本文件(*.TXT)|*.txt";
    String FILE_FILTER_TXT_DSP = "13010F0E";
    // TXT文本文件(*.TXT)";
    String FILE_FILTER_TXT_REG = "13010F0F";
    // .txt";
    /** 名值分隔符Key-Value */
    String TEXT_CTRLSPKV = "13010F10";
    // ：";
    /** 值值分隔符Value-Value */
    String TEXT_CTRLSPVV = "13010F11";
    // 、";
    // ////////////////////////////////////////////////////////////////////////
    // 界面标签资源常量
    // ////////////////////////////////////////////////////////////////////////
    // ==============================================================
    // 备选软件
    // ==============================================================
    // ----------------------------------------------------
    // 公共常量
    // ----------------------------------------------------
    /** 所属公司 */
    String ASOC_COMN_TEXT_ASOCCORP = "1301B101";
    // 所属公司";
    /** 相关说明 */
    String ASOC_COMN_TEXT_ASOCDESP = "1301B102";
    // 相关说明";
    /** 支持格式 */
    String ASOC_COMN_TEXT_ASOCEXTS = "1301B103";
    // 支持格式";
    /** 链接地址 */
    String ASOC_COMN_TEXT_ASOCSITE = "1301B104";
    // 链接地址";
    /** 备选软件 */
    String ASOC_COMN_TEXT_ASOCSOFT = "1301B105";
    // 备选软件";
    // ----------------------------------------------------
    // 标签常量
    // ----------------------------------------------------
    /** 相关说明 */
    String ASOC_LABL_TEXT_ASOCDESP = "1301B801";
    // ASOC_COMN_TEXT_ASOCDESP + "(&P)";
    String ASOC_LABL_TIPS_ASOCDESP = "1301B802";
    // 相关说明";
    /** 备选软件 */
    String ASOC_LABL_TEXT_ASOCSOFT = "1301B803";
    // ASOC_COMN_TEXT_ASOCSOFT + "(&A)";
    String ASOC_LABL_TIPS_ASOCSOFT = "1301B804";
    // 备选软件";
    // ----------------------------------------------------
    // 文本常量
    // ----------------------------------------------------
    /** 所属公司 */
    String ASOC_AREA_TEXT_ASOCDESP = "1301B901";
    // 所属公司";
    String ASOC_AREA_TIPS_ASOCDESP = "1301B902";
    // 所属公司";
    /** 备选软件 */
    String ASOC_FILD_TEXT_ASOCSOFT = "1301B903";
    // 备选软件";
    String ASOC_FILD_TIPS_ASOCSOFT = "1301B904";
    // 备选软件";
    // ----------------------------------------------------
    // 按钮常量
    // ----------------------------------------------------
    /** 取消（备选软件） */
    String ASOC_BUTN_TEXT_CANCEL = "1301BA01";
    // 取消(&C)";
    String ASOC_BUTN_TIPS_CANCEL = "1301BA02";
    // 取消";
    /** 新增（备选软件） */
    String ASOC_BUTN_TEXT_CREATE = "1301BA03";
    // 新增(&N)";
    String ASOC_BUTN_TIPS_CREATE = "1301BA04";
    // 显示新增界面";
    /** 删除（备选软件） */
    String ASOC_BUTN_TEXT_DELETE = "1301BA05";
    // 删除(&D)";
    String ASOC_BUTN_TIPS_DELETE = "1301BA06";
    // 删除";
    /** 保存（备选软件） */
    String ASOC_BUTN_TEXT_INSERT = "1301BA07";
    // 保存(&S)";
    String ASOC_BUTN_TIPS_INSERT = "1301BA08";
    // 保存";
    /** 更新（备选软件） */
    String ASOC_BUTN_TEXT_UPDATE = "1301BA09";
    // 更新(&U)";
    String ASOC_BUTN_TIPS_UPDATE = "1301BA0A";
    // 添加新数据或更新已有数据";
    /** 软件参照 */
    String ASOC_BUTN_TEXT_ASOCVIEW = "1301BA0B";
    // V(&V)";
    String ASOC_BUTN_TIPS_ASOCVIEW = "1301BA0C";
    // 参照已有软件";
    /** 软件信息 */
    String ASOC_BUTN_TEXT_ASOCINFO = "1301BA0D";
    // I(&I)";
    String ASOC_BUTN_TIPS_ASOCINFO = "1301BA0E";
    // 查看软件的详细信息";
    // ----------------------------------------------------
    // 其它常量
    // ----------------------------------------------------
    /** 备选软件 */
    String ASOC_LIST_TEXT_ASOCSOFT = "1301BF01";
    String ASOC_LIST_TIPS_ASOCSOFT = "1301BF02";
    // 已有备选软件列表";
    // ----------------------------------------------------
    // 提示常量
    // ----------------------------------------------------
    /** 备选软件查询语言资源 */
    String ASOC_MESG_SELT_0000 = "1301B400";
    // 备选软件查询语言资源区域";
    /** 备选软件更新语言资源 */
    String ASOC_MESG_UPDT_0000 = "1301B500";
    // 备选软件更新语言资源区域";
    /** 更新成功 */
    String ASOC_MESG_UPDT_0001 = "1301B501";
    // 更新成功！";
    /** 更新失败 */
    String ASOC_MESG_UPDT_0002 = "1301B502";
    // 更新失败！";
    /** 备选软件已存在 */
    String ASOC_MESG_UPDT_0003 = "1301B503";
    // 备选软件 “{0}” 已存在，确定用新数据覆盖已有数据吗？";
    /** 备选软件删除语言资源 */
    String ASOC_MESG_DELT_0000 = "1301B600";
    // 备选软件删除语言资源区域";
    // ==============================================================
    // 公司信息
    // ==============================================================
    // ----------------------------------------------------
    // 公共常量
    // ----------------------------------------------------
    /** 相关说明（公司信息） */
    String CORP_COMN_TEXT_CORPDESP = "13015101";
    // 相关说明";
    /** 英语名称 */
    String CORP_COMN_TEXT_CORPENNM = "13015102";
    // 英语名称";
    /** 本语名称 */
    String CORP_COMN_TEXT_CORPLCNM = "13015103";
    // 本语名称";
    /** 公司网址 */
    String CORP_COMN_TEXT_CORPSITE = "13015104";
    // 公司网址";
    /** 国别信息 */
    String CORP_COMN_TEXT_CORPNATN = "13015105";
    // 国别信息";
    // ----------------------------------------------------
    // 标签常量
    // ----------------------------------------------------
    /** 相关说明（公司信息） */
    String CORP_LABL_TEXT_CORPDESP = "13015801";
    // TEXT_CORPDESP + "(&P)";
    String CORP_LABL_TIPS_CORPDESP = "13015802";
    // 相关说明";
    /** 英语名称 */
    String CORP_LABL_TEXT_CORPENNM = "13015803";
    // TEXT_CORPENNM + "(&E)";
    String CORP_LABL_TIPS_CORPENNM = "13015804";
    // 英语名称";
    /** 本语名称 */
    String CORP_LABL_TEXT_CORPLCNM = "13015805";
    // TEXT_CORPLCNM + "(&L)";
    String CORP_LABL_TIPS_CORPLCNM = "13015806";
    // 本语名称";
    /** 国别信息 */
    String CORP_LABL_TEXT_CORPNATN = "13015807";
    // TEXT_CORPNATN + "(&A)";
    String CORP_LABL_TIPS_CORPNATN = "13015808";
    // 国别信息";
    /** 公司网址 */
    String CORP_LABL_TEXT_CORPSITE = "13015809";
    // TEXT_CORPSITE + "(&W)";
    String CORP_LABL_TIPS_CORPSITE = "1301580A";
    // 公司网址";
    // ----------------------------------------------------
    // 文本常量
    // ----------------------------------------------------
    /** 相关说明（公司信息） */
    String CORP_AREA_TEXT_CORPDESP = "13015901";
    // 相关说明";
    String CORP_AREA_TIPS_CORPDESP = "13015902";
    // 相关说明";
    /** 英语名称 */
    String CORP_FILD_TEXT_CORPENNM = "13015903";
    // 英语名称";
    String CORP_FILD_TIPS_CORPENNM = "13015904";
    // 英语名称";
    /** 本语名称 */
    String CORP_FILD_TEXT_CORPLCNM = "13015905";
    // 本语名称";
    String CORP_FILD_TIPS_CORPLCNM = "13015906";
    // 本语名称";
    /** 公司网址 */
    String CORP_FILD_TEXT_CORPSITE = "13015907";
    // 公司网址";
    String CORP_FILD_TIPS_CORPSITE = "13015908";
    // 公司网址";
    // ----------------------------------------------------
    // 按钮常量
    // ----------------------------------------------------
    /** 取消（公司信息） */
    String CORP_BUTN_TEXT_CANCEL = "13015A01";
    // 取消(&C)";
    String CORP_BUTN_TIPS_CANCEL = "13015A02";
    // 取消";
    /** 新增（公司信息） */
    String CORP_BUTN_TEXT_CREATE = "13015A03";
    // 新增(&N)";
    String CORP_BUTN_TIPS_CREATE = "13015A04";
    // 新增";
    /** 删除（公司信息） */
    String CORP_BUTN_TEXT_DELETE = "13015A05";
    // 删除(&D)";
    String CORP_BUTN_TIPS_DELETE = "13015A06";
    // 删除";
    /** 新增（公司信息） */
    String CORP_BUTN_TEXT_INSERT = "13015A07";
    // 保存(&S)";
    String CORP_BUTN_TIPS_INSERT = "13015A08";
    // 保存";
    /** 更新（公司信息） */
    String CORP_BUTN_TEXT_UPDATE = "13015A09";
    // 更新(&U)";
    String CORP_BUTN_TIPS_UPDATE = "13015A0A";
    // 更新";
    /** 公司参照 */
    String CORP_BUTN_TEXT_CORPVIEW = "13015A0B";
    // &V;
    String CORP_BUTN_TIPS_CORPVIEW = "13015A0C";
    // 参照已有公司";
    // ----------------------------------------------------
    // 组合框常量
    // ----------------------------------------------------
    /** 国别信息 */
    String CORP_COMB_TEXT_CORPNATN = "13015B01";
    // null;
    String CORP_COMB_TIPS_CORPNATN = "13015B02";
    // 国别信息";
    // ----------------------------------------------------
    // 图标语言资源常量
    // ----------------------------------------------------
    /** 公司徽标 */
    String CORP_IMLB_TEXT_CORPICON = "13015E01";
    // null;
    String CORP_IMLB_TIPS_CORPICON = "13015E02";
    // 公司徽标";
    /** 公司信息 */
    String CORP_MESG_CHCK_0000 = "13015300";
    /** 公司信息查询语言资源 */
    String CORP_MESG_SELT_0000 = "13015400";
    // 公司信息查询语言资源区域";
    /** 公司信息更新语言资源 */
    String CORP_MESG_UPDT_0000 = "13015500";
    // 公司信息更新语言资源区域";
    /** 公司信息删除语言资源 */
    String CORP_MESG_DELT_0000 = "13015600";
    // 公司信息删除语言资源区域";
    /** 公司徽标读取错误 */
    String CORP_MESG_OTHR_0000 = "13015700";
    // 公司徽标读取错误！";
    /** 公司徽标保存错误 */
    String CORP_MESG_OTHR_0001 = "13015701";
    // 公司徽标保存错误！";
    // ==============================================================
    // 描述信息
    // ==============================================================
    // ----------------------------------------------------
    // 公共常量
    // ----------------------------------------------------
    /** 描述语言 */
    String DESP_COMN_TEXT_DESPLANG = "13019101";
    // 语言列表";
    /** 后缀描述 */
    String DESP_COMN_TEXT_EXTSDESP = "13019102";
    // 后缀说明";
    // ----------------------------------------------------
    // 标签常量
    // ----------------------------------------------------
    /** 描述语言 */
    String DESP_LABL_TEXT_DESPLANG = "13019801";
    // DESP_COMN_TEXT_DESPLANG + "(&L)";
    String DESP_LABL_TIPS_DESPLANG = "13019802";
    // 语言列表";
    /** 后缀说明 */
    String DESP_LABL_TEXT_EXTSDESP = "13019803";
    // DESP_COMN_TEXT_EXTSDESP + "(&P)";
    String DESP_LABL_TIPS_EXTSDESP = "13019804";
    // 后缀说明";
    // ----------------------------------------------------
    // 文本常量
    // ----------------------------------------------------
    /** 后缀说明 */
    String DESP_AREA_TEXT_EXTSDESP = "13019901";
    String DESP_AREA_TIPS_EXTSDESP = "13019902";
    // 后缀说明";
    // ----------------------------------------------------
    // 按钮常量
    // ----------------------------------------------------
    /** 删除（描述信息） */
    String DESP_BUTN_TEXT_DELETE = "13019A01";
    // 删除(&D)";
    String DESP_BUTN_TIPS_DELETE = "13019A02";
    // 删除";
    /** 更新（描述信息） */
    String DESP_BUTN_TEXT_UPDATE = "13019A03";
    // 更新(&U)";
    String DESP_BUTN_TIPS_UPDATE = "13019A04";
    // 更新";
    // ----------------------------------------------------
    // 其它常量
    // ----------------------------------------------------
    String DESP_COMB_TIPS_DESPLANG = "13019F01";
    // 后缀说明";
    // ----------------------------------------------------
    // 数据检测
    // ----------------------------------------------------
    /** 后缀描述数据检测语言资源区域 */
    String DESP_MESG_CHCK_0000 = "13019300";
    /** 请选择目标语言！ */
    String DESP_MESG_CHCK_0001 = "13019301";
    // 请选择目标语言！";
    // ----------------------------------------------------
    // 数据查询
    // ----------------------------------------------------
    /** 后缀描述查询语言资源 */
    String DESP_MESG_SELT_0000 = "13019400";
    // ----------------------------------------------------
    // 数据更新
    // ----------------------------------------------------
    /** 后缀描述更新语言资源 */
    String DESP_MESG_UPDT_0000 = "13019500";
    // ----------------------------------------------------
    // 数据删除
    // ----------------------------------------------------
    /** 后缀描述删除语言资源 */
    String DESP_MESG_DELT_0000 = "13019600";
    /** 数据删除确认 */
    String DESP_MESG_DELT_0001 = "13019601";
    // 确认要删除此描述信息吗，此操作将不可恢复？";
    // ==============================================================
    // 后缀信息
    // ==============================================================
    // ----------------------------------------------------
    // 公共常量
    // ----------------------------------------------------
    /** 系统架构 */
    String EXTS_COMN_TEXT_ARCHBITS = "13014101";
    // CPU 架构";
    /** 所属公司 */
    String EXTS_COMN_TEXT_CORPLCNM = "13014102";
    // 所属公司";
    /** 后缀描述 */
    String EXTS_COMN_TEXT_EXTSDESP = "13014103";
    // 后缀描述";
    /** 文件签名 */
    String EXTS_COMN_TEXT_EXTSFILE = "13014104";
    // 文件签名";
    /** 特别致谢 */
    String EXTS_COMN_TEXT_EXTSIDIO = "13014105";
    // 特别致谢";
    /** 后缀名称 */
    String EXTS_COMN_TEXT_EXTSNAME = "13014106";
    // 后缀名称";
    /** 应用平台 */
    String EXTS_COMN_TEXT_EXTSPLAT = "13014107";
    // 应用平台";
    /** 直属软件 */
    String EXTS_COMN_TEXT_EXTSSOFT = "13014108";
    // 直属软件";
    /** 所属类别 */
    String EXTS_COMN_TEXT_EXTSTYPE = "13014109";
    // 所属类别";
    /** 相关说明 */
    String EXTS_COMN_TEXT_IDIOMARK = "1301410A";
    // 相关说明";
    // ----------------------------------------------------
    // 标签常量
    // ----------------------------------------------------
    /** CPU 架构 */
    String EXTS_LABL_TEXT_ARCHBITS = "13014801";
    // EXTS_COMN_TEXT_ARCHBITS;
    String EXTS_LABL_TIPS_ARCHBITS = "13014802";
    // CPU 架构";
    /** 所属公司 */
    String EXTS_LABL_TEXT_CORPLCNM = "13014803";
    // EXTS_COMN_TEXT_CORPLCNM + "(&I)";
    String EXTS_LABL_TIPS_CORPLCNM = "13014804";
    // 所属公司";
    /** 后缀名称 */
    String EXTS_LABL_TEXT_EXTSNAME = "13014805";
    // EXTS_COMN_TEXT_EXTSNAME + "(&E)";
    String EXTS_LABL_TIPS_EXTSNAME = "13014806";
    // 后缀名称";
    /** 所属类别 */
    String EXTS_LABL_TEXT_EXTSTYPE = "13014807";
    // EXTS_COMN_TEXT_EXTSTYPE + "(&K)";
    String EXTS_LABL_TIPS_EXTSTYPE = "13014808";
    // 所属类别";
    /** 特别致谢 */
    String EXTS_LABL_TEXT_IDIOMAIL = "13014809";
    // EXTS_COMN_TEXT_EXTSIDIO + "(&T)";
    String EXTS_LABL_TIPS_IDIOMAIL = "1301480A";
    // 特别致谢";
    /** 相关说明 */
    String EXTS_LABL_TEXT_IDIOMARK = "1301480B";
    // EXTS_COMN_TEXT_EXTSDESP + "(&P)";
    String EXTS_LABL_TIPS_IDIOMARK = "1301480C";
    // 相关说明";
    /** 国别信息 */
    String EXTS_LABL_TEXT_NATNINDX = "1301480D";
    // EXTS_COMN_TEXT_EXTSTYPE + "(&A)";
    String EXTS_LABL_TIPS_NATNINDX = "1301480E";
    // 国别信息";
    /** 应用平台 */
    String EXTS_LABL_TEXT_PLATFORM = "1301480F";
    // EXTS_COMN_TEXT_EXTSPLAT + "(&R)";
    String EXTS_LABL_TIPS_PLATFORM = "13014810";
    // 应用平台";
    /** 文件签名 */
    String EXTS_LABL_TEXT_SIGNCHAR = "13014811";
    // EXTS_COMN_TEXT_EXTSFILE + "(&F)";
    String EXTS_LABL_TIPS_SIGNCHAR = "13014812";
    // 文件签名";
    /** 直属软件 */
    String EXTS_LABL_TEXT_SOFTNAME = "13014813";
    // EXTS_COMN_TEXT_EXTSSOFT + "(&S)";
    String EXTS_LABL_TIPS_SOFTNAME = "13014814";
    // 直属软件";
    // ----------------------------------------------------
    // 文本框资源
    // ----------------------------------------------------
    /** 个人说明 */
    String EXTS_AREA_TEXT_IDIOMARK = "13014901";
    String EXTS_AREA_TIPS_IDIOMARK = "13014902";
    // 个人说明";
    /** 后缀名称 */
    String EXTS_FILD_TEXT_EXTSNAME = "13014903";
    String EXTS_FILD_TIPS_EXTSNAME = "13014904";
    // 后缀名称";
    // ----------------------------------------------------
    // 按钮资源
    // ----------------------------------------------------
    /** 取消（后缀信息） */
    String EXTS_BUTN_TEXT_CANCEL = "13014A01";
    // 取消(&C)";
    String EXTS_BUTN_TIPS_CANCEL = "13014A02";
    // 取消";
    /** 新增（后缀信息） */
    String EXTS_BUTN_TEXT_CREATE = "13014A03";
    // 新增(&N)";
    String EXTS_BUTN_TIPS_CREATE = "13014A04";
    // 新增";
    /** 删除（后缀信息） */
    String EXTS_BUTN_TEXT_DELETE = "13014A05";
    // 删除(&D)";
    String EXTS_BUTN_TIPS_DELETE = "13014A06";
    // 删除";
    /** 保存（后缀信息） */
    String EXTS_BUTN_TEXT_INSERT = "13014A07";
    // 保存(&S)";
    String EXTS_BUTN_TIPS_INSERT = "13014A08";
    // 保存";
    /** 更新（后缀信息） */
    String EXTS_BUTN_TEXT_UPDATE = "13014A09";
    // 更新(&U)";
    String EXTS_BUTN_TIPS_UPDATE = "13014A0A";
    // 更新";
    // ----------------------------------------------------
    // 组合框资源
    // ----------------------------------------------------
    /** 所属类别 */
    String EXTS_COMB_TEXT_EXTSTYPE = "13014B01";
    String EXTS_COMB_TIPS_EXTSTYPE = "13014B02";
    // 所属类别";
    /** 文件信息 */
    String EXTS_COMB_TEXT_SIGNCHAR = "13014B03";
    String EXTS_COMB_TIPS_SIGNCHAR = "13014B04";
    // 文件信息";
    /** 直属软件 */
    String EXTS_COMB_TEXT_SOFTNAME = "13014B05";
    String EXTS_COMB_TIPS_SOFTNAME = "13014B06";
    // 直属软件";
    /** 所属公司 */
    String EXTS_COMB_TEXT_CORPLCNM = "13014B07";
    String EXTS_COMB_TIPS_CORPLCNM = "13014B08";
    // 所属公司";
    /** 国别信息 */
    String EXTS_COMB_TEXT_NATNINDX = "13014B09";
    String EXTS_COMB_TIPS_NATNINDX = "13014B0A";
    // 国别信息";
    /** 特别致谢 */
    String EXTS_COMB_TEXT_IDIOMAIL = "13014B0B";
    String EXTS_COMB_TIPS_IDIOMAIL = "13014B0C";
    // 特别致谢";
    // ----------------------------------------------------
    // 复选框资源
    // ----------------------------------------------------
    /** 架构：其它 */
    String EXTS_CHCK_TEXT_BITS00 = "13014C01";
    // TEXT_AB00 + "(&3)";
    String EXTS_CHCK_TIPS_BITS00 = "13014C02";
    // 其它";
    /** 架构：16位 */
    String EXTS_CHCK_TEXT_BITS16 = "13014C03";
    // TEXT_AB16 + "(&2)";
    String EXTS_CHCK_TIPS_BITS16 = "13014C04";
    // 16位";
    /** 架构：32位 */
    String EXTS_CHCK_TEXT_BITS32 = "13014C05";
    // TEXT_AB32 + "(&1)";
    String EXTS_CHCK_TIPS_BITS32 = "13014C06";
    // 32位";
    /** 架构：64位 */
    String EXTS_CHCK_TEXT_BITS64 = "13014C07";
    // TEXT_AB64 + "(&0)";
    String EXTS_CHCK_TIPS_BITS64 = "13014C08";
    // 64位";
    /** 平台通用 */
    String EXTS_CHCK_TEXT_PFALL = "13014C09";
    // TEXT_PFALL + "(&G)";
    String EXTS_CHCK_TIPS_PFALL = "13014C0A";
    // 平台通用";
    /** Linux平台 */
    String EXTS_CHCK_TEXT_PFLNX = "13014C0B";
    // TEXT_PFLNX + "(&L)";
    String EXTS_CHCK_TIPS_PFLNX = "13014C0C";
    // Linux平台";
    /** Mac平台 */
    String EXTS_CHCK_TEXT_PFMAC = "13014C0D";
    // TEXT_PFMAC + "(&M)";
    String EXTS_CHCK_TIPS_PFMAC = "13014C0E";
    // Macintosh平台";
    /** 移动平台 */
    String EXTS_CHCK_TEXT_PFMBL = "13014C0F";
    // TEXT_PFMBL + "(&V)";
    String EXTS_CHCK_TIPS_PFMBL = "13014C10";
    // 移动平台";
    /** 其它平台 */
    String EXTS_CHCK_TEXT_PFSPC = "13014C11";
    // TEXT_PFSPC + "(&O)";
    String EXTS_CHCK_TIPS_PFSPC = "13014C12";
    // 其它平台";
    /** Unix平台 */
    String EXTS_CHCK_TEXT_PFUNX = "13014C13";
    // TEXT_PFUNX + "(&X)";
    String EXTS_CHCK_TIPS_PFUNX = "13014C14";
    // Unix平台";
    /** Windows平台 */
    String EXTS_CHCK_TEXT_PFWIN = "13014C15";
    // TEXT_PFWIN + "(&W)";
    String EXTS_CHCK_TIPS_PFWIN = "13014C16";
    // Windows平台";
    /** 后缀管理查询语言资源 */
    String EXTS_MESG_CHCK_0000 = "13014300";
    // 后缀管理检测语言资源区域";
    /** 后缀管理查询语言资源 */
    String EXTS_MESG_SELT_0000 = "13014400";
    // 后缀管理查询语言资源区域";
    /** 后缀管理更新语言资源 */
    String EXTS_MESG_UPDT_0000 = "13014500";
    // 后缀管理更新语言资源区域";
    /** 数据新增成功 */
    String EXTS_MESG_UPDT_0001 = "13014501";
    // 数据添加成功！";
    /** 更新提示 */
    String EXTS_MESG_UPDT_0002 = "13014502";
    // 进行数据更新操作前，请先查询并选择您要更新的数据！";
    /** 后缀管理删除语言资源 */
    String EXTS_MESG_DELT_0000 = "13014600";
    // 后缀管理删除语言资源区域";
    /** 数据删除确认 */
    String EXTS_MESG_DELT_0001 = "13014601";
    // 确认要删除此后缀数据信息么？此操作将不可恢复，但不会对公司、软件、文件等信息造成任何影响。";
    // ==============================================================
    // 文件信息
    // ==============================================================
    // ----------------------------------------------------
    // 文件信息
    // ----------------------------------------------------
    /** 加密算法 */
    String FILE_COMN_TEXT_CIPHERSN = "13017101";
    // 加密算法";
    /** 相关说明（文件信息） */
    String FILE_COMN_TEXT_FILEDESP = "13017102";
    // 相关说明";
    /** 直属软件 */
    String FILE_COMN_TEXT_FILESOFT = "13017103";
    // 直属软件";
    /** 偏移位置 */
    String FILE_COMN_TEXT_MSOFFSET = "13017104";
    // 偏移位置";
    /** 魔术签名 */
    String FILE_COMN_TEXT_SIGNCHAR = "13017105";
    // 字符签名";
    /** 数值签名 */
    String FILE_COMN_TEXT_SIGNCODE = "13017106";
    // 数值签名";
    // ----------------------------------------------------
    // 标签资源
    // ----------------------------------------------------
    /** 加密算法 */
    String FILE_LABL_TEXT_CIPHERSN = "13017801";
    // FILE_TEXT_CIPHERSN + "(&M)";
    String FILE_LABL_TIPS_CIPHERSN = "13017802";
    // 加密算法";
    /** 相关说明（文件信息） */
    String FILE_LABL_TEXT_FILEDESP = "13017803";
    // FILE_TEXT_FILEDESP + "(&P)";
    String FILE_LABL_TIPS_FILEDESP = "13017804";
    // 相关说明";
    /** 直属软件 */
    String FILE_LABL_TEXT_FILESOFT = "13017805";
    // FILE_TEXT_FILESOFT + "(&A)";
    String FILE_LABL_TIPS_FILESOFT = "13017806";
    // 直属软件";
    /** 偏移位置 */
    String FILE_LABL_TEXT_MSOFFSET = "13017807";
    // FILE_TEXT_MSOFFSET + "(&O)";
    String FILE_LABL_TIPS_MSOFFSET = "13017808";
    // 偏移位置";
    /** 字符签名 */
    String FILE_LABL_TEXT_SIGNCHAR = "13017809";
    // FILE_TEXT_SIGNCHAR + "(&H)";
    String FILE_LABL_TIPS_SIGNCHAR = "1301780A";
    // 字符签名";
    /** 数值签名 */
    String FILE_LABL_TEXT_SIGNCODE = "1301780B";
    // FILE_TEXT_SIGNCHAR + "(&E)";
    String FILE_LABL_TIPS_SIGNCODE = "1301780C";
    // 数值签名";
    // ----------------------------------------------------
    // 文本资源
    // ----------------------------------------------------
    /** 相关说明（文件信息） */
    String FILE_AREA_TEXT_FILEDESP = "13017901";
    String FILE_AREA_TIPS_FILEDESP = "13017902";
    // 相关说明";
    /** 加密算法 */
    String FILE_FILD_TEXT_CIPHERSN = "13017903";
    String FILE_FILD_TIPS_CIPHERSN = "13017904";
    // 加密算法";
    /** 字符签名 */
    String FILE_FILD_TEXT_SIGNCHAR = "13017905";
    String FILE_FILD_TIPS_SIGNCHAR = "13017906";
    // 字符签名";
    /** 数值签名 */
    String FILE_FILD_TEXT_SIGNCODE = "13017907";
    String FILE_FILD_TIPS_SIGNCODE = "13017908";
    // 数值签名";
    /** 偏移位置 */
    String FILE_FILD_TEXT_MSOFFSET = "13017909";
    String FILE_FILD_TIPS_MSOFFSET = "1301790A";
    // 偏移位置";
    // ----------------------------------------------------
    // 按钮资源
    // ----------------------------------------------------
    /** 取消（文件信息） */
    String FILE_BUTN_TEXT_CANCEL = "13017A01";
    // 取消(&C)";
    String FILE_BUTN_TIPS_CANCEL = "13017A02";
    // 取消";
    /** 新增（文件信息） */
    String FILE_BUTN_TEXT_CREATE = "13017A03";
    // 新增(&N)";
    String FILE_BUTN_TIPS_CREATE = "13017A04";
    // 新增";
    /** 删除（文件信息） */
    String FILE_BUTN_TEXT_DELETE = "13017A05";
    // 删除(&D)";
    String FILE_BUTN_TIPS_DELETE = "13017A06";
    // 删除";
    /** 保存（文件信息） */
    String FILE_BUTN_TEXT_INSERT = "13017A07";
    // 保存(&S)";
    String FILE_BUTN_TIPS_INSERT = "13017A08";
    // 保存";
    /** 更新（文件信息） */
    String FILE_BUTN_TEXT_UPDATE = "13017A09";
    // 更新(&U)";
    String FILE_BUTN_TIPS_UPDATE = "13017A0A";
    // 更新";
    /** 参照 */
    String FILE_BUTN_TEXT_FILEVIEW = "13017A0B";
    String FILE_BUTN_TIPS_FILEVIEW = "13017A0C";
    // 参照已有文件信息";
    // ----------------------------------------------------
    // 组合框资源
    // ----------------------------------------------------
    /** 软件列表 */
    String FILE_COMB_TEXT_FILESOFT = "13017B01";
    String FILE_COMB_TIPS_FILESOFT = "13017B02";
    // 直属软件";
    // ----------------------------------------------------
    // 图标语言资源常量
    // ----------------------------------------------------
    /** 文件图标 */
    String FILE_IMLB_TEXT_FILEICON = "13017E01";
    String FILE_IMLB_TIPS_FILEICON = "13017E02";
    // 文件图标";
    // ----------------------------------------------------
    // 数据检测
    // ----------------------------------------------------
    /**  */
    String FILE_MESG_CHCK_0000 = "13017300";
    /** 数据类型不合法 */
    String FILE_MESG_CHCK_0001 = "13017301";
    // {0} 为数值型数据，请确认您的输入是否正确！";
    // ----------------------------------------------------
    // 数据查询
    // ----------------------------------------------------
    /** 文件信息查询语言资源 */
    String FILE_MESG_SELT_0000 = "13017400";
    // 文件信息查询语言资源";
    // ----------------------------------------------------
    // 数据更新
    // ----------------------------------------------------
    /** 文件信息更新语言资源 */
    String FILE_MESG_UPDT_0000 = "13017500";
    // 文件信息更新语言资源！";
    /** 文件信息更新成功！ */
    String FILE_MESG_UPDT_0001 = "13017501";
    // 文件信息更新成功！";
    // ----------------------------------------------------
    // 数据删除
    // ----------------------------------------------------
    /** 文件信息删除语言资源 */
    String FILE_MESG_DELT_0000 = "13017600";
    // 文件信息删除语言资源";
    // ==============================================================
    // 个人信息
    // ==============================================================
    // ----------------------------------------------------
    // 公共常量
    // ----------------------------------------------------
    /** 个人首页 */
    String IDIO_COMN_TEXT_HOMEPAGE = "13018101";
    // 个人首页";
    /** 相关说明 */
    String IDIO_COMN_TEXT_IDIODESP = "13018102";
    // 相关说明";
    /** 邮件 */
    String IDIO_COMN_TEXT_IDIOMAIL = "13018103";
    // 电子邮件";
    /** 签名 */
    String IDIO_COMN_TEXT_IDIOSIGN = "13018104";
    // 签名";
    /** 昵称 */
    String IDIO_COMN_TEXT_NICKNAME = "13018105";
    // 昵称";
    // ----------------------------------------------------
    // 标签资源
    // ----------------------------------------------------
    /** 个人首页 */
    String IDIO_LABL_TEXT_HOMEPAGE = "13018801";
    // IDIO_COMN_TEXT_HOMEPAGE + "(&W)";
    String IDIO_LABL_TIPS_HOMEPAGE = "13018802";
    // 个人首页";
    /** 相关说明 */
    String IDIO_LABL_TEXT_IDIODESP = "13018803";
    // IDIO_COMN_TEXT_IDIODESP + "(&P)";
    String IDIO_LABL_TIPS_IDIODESP = "13018804";
    // 相关说明";
    /** 邮件（特别致谢） */
    String IDIO_LABL_TEXT_IDIOMAIL = "13018804";
    // IDIO_COMN_TEXT_IDIOMAIL + "(&M)";
    String IDIO_LABL_TIPS_IDIOMAIL = "13018805";
    // 邮件";
    /** 签名 */
    String IDIO_LABL_TEXT_IDIOSIGN = "13018806";
    // IDIO_COMN_TEXT_IDIOSIGN + "(&G)";
    String IDIO_LABL_TIPS_IDIOSIGN = "13018807";
    // 签名";
    /** 昵称 */
    String IDIO_LABL_TEXT_NICKNAME = "13018808";
    // IDIO_COMN_TEXT_NICKNAME + "(&I)";
    String IDIO_LABL_TIPS_NICKNAME = "13018809";
    // 昵称";
    // ----------------------------------------------------
    // 文本框资源
    // ----------------------------------------------------
    /** 相关说明 */
    String IDIO_AREA_TEXT_IDIODESP = "13018901";
    String IDIO_AREA_TIPS_IDIODESP = "13018902";
    // 相关说明";
    /** 个人首页 */
    String IDIO_FILD_TEXT_HOMEPAGE = "13018903";
    String IDIO_FILD_TIPS_HOMEPAGE = "13018904";
    // 个人首页";
    /** 邮件 */
    String IDIO_FILD_TEXT_IDIOMAIL = "13018905";
    String IDIO_FILD_TIPS_IDIOMAIL = "13018906";
    // 邮件";
    /** 签名 */
    String IDIO_FILD_TEXT_IDIOSIGN = "13018907";
    String IDIO_FILD_TIPS_IDIOSIGN = "13018908";
    // 签名";
    /** 昵称 */
    String IDIO_FILD_TEXT_NICKNAME = "13018909";
    String IDIO_FILD_TIPS_NICKNAME = "1301890A";
    // 昵称";
    // ----------------------------------------------------
    // 按钮资源
    // ----------------------------------------------------
    /** 取消（个人信息） */
    String IDIO_BUTN_TEXT_CANCEL = "13018A01";
    // 取消(&C)";
    String IDIO_BUTN_TIPS_CANCEL = "13018A02";
    // 取消";
    /** 新增（个人信息） */
    String IDIO_BUTN_TEXT_CREATE = "13018A03";
    // 新增(&N)";
    String IDIO_BUTN_TIPS_CREATE = "13018A04";
    // 新增";
    /** 删除（个人信息） */
    String IDIO_BUTN_TEXT_DELETE = "13018A05";
    // 删除(&D)";
    String IDIO_BUTN_TIPS_DELETE = "13018A06";
    // 删除";
    /** 新增（个人信息） */
    String IDIO_BUTN_TEXT_INSERT = "13018A07";
    // 保存(&S)";
    String IDIO_BUTN_TIPS_INSERT = "13018A08";
    // 保存";
    /** 更新（个人信息） */
    String IDIO_BUTN_TEXT_UPDATE = "13018A09";
    // 更新(&U)";
    String IDIO_BUTN_TIPS_UPDATE = "13018A0A";
    // 更新";
    /** 参照 */
    String IDIO_BUTN_TEXT_IDIOVIEW = "13018A0B";
    String IDIO_BUTN_TIPS_IDIOVIEW = "13018A0C";
    // 参照已有人员信息";
    // ----------------------------------------------------
    // 图标语言资源常量
    // ----------------------------------------------------
    /** 个性图标 */
    String IDIO_IMLB_TEXT_IDIOICON = "13018E01";
    String IDIO_IMLB_TIPS_IDIOICON = "13018E02";
    // 个性图标";
    /** 个性图标文件读取错误 */
    String IDIO_MESG_ICON_0001 = "13018701";
    // 图像文件 “{0}” 读取错误，{1}";
    // ==============================================================
    // 主窗口
    // ==============================================================
    // ----------------------------------------------------
    // 公共语言资源
    // ----------------------------------------------------
    /** 系统架构 */
    String MAIN_COMN_TEXT_ARCHBITS = "13013101";
    // 系统架构";
    /** 备选软件 */
    String MAIN_COMN_TEXT_ASOCSOFT = "13013102";
    // 备选软件";
    /** 后缀描述 */
    String MAIN_COMN_TEXT_EXTSDESP = "13013103";
    // 后缀描述";
    /** 描述语言 */
    String MAIN_COMN_TEXT_EXTSLANG = "13013104";
    // 描述语言";
    /** MIME类型 */
    String MAIN_COMN_TEXT_EXTSMIME = "13013105";
    // MIME类型";
    /** 后缀名称 */
    String MAIN_COMN_TEXT_EXTSNAME = "13013106";
    // 后缀名称";
    /** 软件名称 */
    String MAIN_COMN_TEXT_EXTSSOFT = "13013107";
    // 软件名称";
    /** 使用平台 */
    String MAIN_COMN_TEXT_EXTSPLAT = "13013108";
    // 使用平台";
    /** 所属类别 */
    String MAIN_COMN_TEXT_EXTSTYPE = "13013109";
    // 所属类别";
    // ----------------------------------------------------
    // 其它常量
    // ----------------------------------------------------
    /** 平台通用 */
    String MAIN_COMN_TEXT_PFALL = "1301310A";
    // 平台通用";
    /** Linux */
    String MAIN_COMN_TEXT_PFLNX = "1301310B";
    // Linux";
    /** Mac */
    String MAIN_COMN_TEXT_PFMAC = "1301310C";
    // Macintosh";
    /** 移动平台 */
    String MAIN_COMN_TEXT_PFMBL = "1301310D";
    // 移动平台";
    /** 其它平台 */
    String MAIN_COMN_TEXT_PFSPC = "1301310E";
    // 其它平台";
    /** Unix */
    String MAIN_COMN_TEXT_PFUNX = "1301310F";
    // Unix";
    /** Windows */
    String MAIN_COMN_TEXT_PFWIN = "13013110";
    // Windows";
    /** 未知 */
    String MAIN_COMN_TEXT_AB00 = "13013111";
    // 其它";
    /** 1位 */
    String MAIN_COMN_TEXT_AB01 = "13013112";
    // 1位";
    /** 2位 */
    String MAIN_COMN_TEXT_AB02 = "13013113";
    // 2位";
    /** 4位 */
    String MAIN_COMN_TEXT_AB04 = "13013114";
    // 4位";
    /** 8位 */
    String MAIN_COMN_TEXT_AB08 = "13013115";
    // 8位";
    /** 16位 */
    String MAIN_COMN_TEXT_AB16 = "13013116";
    // 16位";
    /** 32位 */
    String MAIN_COMN_TEXT_AB32 = "13013117";
    // 32位";
    /** 64位 */
    String MAIN_COMN_TEXT_AB64 = "13013118";
    // 64位";
    // ----------------------------------------------------
    // 其它信息
    // ----------------------------------------------------
    /** CPU 架构 */
    String MAIN_LABL_TEXT_ARCHBITS = "13013801";
    // CPU 架构";
    String MAIN_LABL_TIPS_ARCHBITS = "13013802";
    // CPU 架构";
    /** 备选软件 */
    String MAIN_LABL_TEXT_ASOCSOFT = "13013803";
    // MAIN_TEXT_ASOCSOFT + "(&A)";
    String MAIN_LABL_TIPS_ASOCSOFT = "13013804";
    // 备选软件";
    /** 后缀描述 */
    String MAIN_LABL_TEXT_EXTSDESP = "13013805";
    // MAIN_TEXT_EXTSDESP + "(&P)";
    String MAIN_LABL_TIPS_EXTSDESP = "13013806";
    // 后缀描述";
    /** 后缀名称 */
    String MAIN_LABL_TEXT_EXTSNAME = "13013807";
    // 后缀名称(&E)";
    String MAIN_LABL_TIPS_EXTSNAME = "13013808";
    // 后缀名称";
    /** 所属类别 */
    String MAIN_LABL_TEXT_EXTSTYPE = "13013809";
    // MAIN_TEXT_EXTSTYPE + "(&K)";
    String MAIN_LABL_TIPS_EXTSTYPE = "1301380A";
    // 所属类别";
    /** MIME类型 */
    String MAIN_LABL_TEXT_MIMETYPE = "1301380B";
    // MAIN_TEXT_EXTSMIME + "(&T)";
    String MAIN_LABL_TIPS_MIMETYPE = "1301380C";
    // MIME类型";
    /** 应用平台 */
    String MAIN_LABL_TEXT_PLATFORM = "1301380D";
    // 应用平台";
    String MAIN_LABL_TIPS_PLATFORM = "1301380E";
    // 应用平台";
    /** 所属软件 */
    String MAIN_LABL_TEXT_SOFTNAME = "1301380F";
    // 所属软件(&S)";
    String MAIN_LABL_TIPS_SOFTNAME = "13013810";
    // 所属软件";
    /** 状态提示 */
    String MAIN_LABL_TEXT_NOTEINFO = "13013811";
    // 温馨提示：";
    String MAIN_LABL_TIPS_NOTEINFO = "13013812";
    // 状态提示";
    /** 公益广告 */
    String MAIN_ROLL_TEXT_PUBLICAD = "13013813";
    // 公益广告";
    String MAIN_ROLL_TIPS_PUBLICAD = "13013814";
    // 公益广告";
    // ----------------------------------------------------
    // 文本框资源常量
    // ----------------------------------------------------
    /** 后缀描述 */
    String MAIN_AREA_TEXT_EXTSDESP = "13013901";
    String MAIN_AREA_TIPS_EXTSDESP = "13013902";
    // 后缀描述";
    /** 后缀名称 */
    String MAIN_FILD_TEXT_EXTSNAME = "13013903";
    String MAIN_FILD_TIPS_EXTSNAME = "13013904";
    // 后缀名称";
    /** 所属类别 */
    String MAIN_FILD_TEXT_EXTSTYPE = "13013905";
    String MAIN_FILD_TIPS_EXTSTYPE = "13013906";
    // 所属类别";
    // ----------------------------------------------------
    // 按钮资源
    // ----------------------------------------------------
    /** 查询 */
    String MAIN_BUTN_TEXT_EXTSNAME = "13013A01";
    // 查询(&Q)";
    String MAIN_BUTN_TIPS_EXTSNAME = "13013A02";
    // 查询";
    /** 查看 */
    String MAIN_BUTN_TEXT_FILEVIEW = "13013A03";
    // 查看(&V)";
    String MAIN_BUTN_TIPS_FILEVIEW = "13013A04";
    // 查看";
    /** 开始菜单 */
    String MAIN_BUTN_TEXT_MAINMENU = "13013A05";
    // 菜单(&M)";
    String MAIN_BUTN_TIPS_MAINMENU = "13013A06";
    // 系统菜单";
    // ----------------------------------------------------
    // 组合框资源常量
    // ----------------------------------------------------
    /** 语言列表 */
    String MAIN_COMB_TEXT_LANGLIST = "13013B01";
    String MAIN_COMB_TIPS_LANGLIST = "13013B02";
    // 语言列表";
    /** 所属软件 */
    String MAIN_COMB_TEXT_SOFTNAME = "13013B03";
    String MAIN_COMB_TIPS_SOFTNAME = "13013B04";
    // 所属软件";
    // ----------------------------------------------------
    // 复选按钮资源常量
    // ----------------------------------------------------
    /** 架构：其它 */
    String MAIN_CHCK_TEXT_AB00 = "13013C01";
    // TEXT_AB00 + "(&3)";
    String MAIN_CHCK_TIPS_AB00 = "13013C02";
    // 其它";
    /** 架构：16位 */
    String MAIN_CHCK_TEXT_AB16 = "13013C03";
    // TEXT_AB16 + "(&2)";
    String MAIN_CHCK_TIPS_AB16 = "13013C04";
    // 16位";
    /** 架构：32位 */
    String MAIN_CHCK_TEXT_AB32 = "13013C05";
    // TEXT_AB32 + "(&1)";
    String MAIN_CHCK_TIPS_AB32 = "13013C06";
    // 32位";
    /** 架构：64位 */
    String MAIN_CHCK_TEXT_AB64 = "13013C07";
    // TEXT_AB64 + "(&0)";
    String MAIN_CHCK_TIPS_AB64 = "13013C08";
    // 64位";
    /** Linux平台 */
    String MAIN_CHCK_TEXT_PFLNX = "13013C09";
    // TEXT_PFLNX + "(&L)";
    String MAIN_CHCK_TIPS_PFLNX = "13013C0A";
    // Linux平台";
    /** Mac平台 */
    String MAIN_CHCK_TEXT_PFMAC = "13013C0B";
    // TEXT_PFMAC + "(&M)";
    String MAIN_CHCK_TIPS_PFMAC = "13013C0C";
    // Macintosh平台";
    /** 移动平台 */
    String MAIN_CHCK_TEXT_PFMBL = "13013C0D";
    // TEXT_PFMBL + "(&V)";
    String MAIN_CHCK_TIPS_PFMBL = "13013C0E";
    // 移动平台";
    /** 平台通用 */
    String MAIN_CHCK_TEXT_PFALL = "13013C0F";
    // TEXT_PFALL + "(&G)";
    String MAIN_CHCK_TIPS_PFALL = "13013C10";
    // 平台通用";
    /** 其它平台 */
    String MAIN_CHCK_TEXT_PFSPC = "13013C11";
    // TEXT_PFSPC + "(&O)";
    String MAIN_CHCK_TIPS_PFSPC = "13013C12";
    // 其它平台";
    /** Unix平台 */
    String MAIN_CHCK_TEXT_PFUNX = "13013C13";
    // TEXT_PFUNX + "(&X)";
    String MAIN_CHCK_TIPS_PFUNX = "13013C14";
    // Unix平台";
    /** Windows平台 */
    String MAIN_CHCK_TEXT_PFWIN = "13013C15";
    // TEXT_PFWIN + "(&W)";
    String MAIN_CHCK_TIPS_PFWIN = "13013C16";
    // Windows平台";
    // ----------------------------------------------------
    // 单选按钮资源常量
    // ----------------------------------------------------
    /** 小写 */
    String MAIN_RBTN_TEXT_CASELOWS = "13013D01";
    // 小写(&L)";
    String MAIN_RBTN_TIPS_CASELOWS = "13013D02";
    // 小写";
    /** 大小敏感 */
    String MAIN_RBTN_TEXT_CASESENS = "13013D03";
    // 大小敏感(&C)";
    String MAIN_RBTN_TIPS_CASESENS = "13013D04";
    // 大小敏感";
    /** 大写 */
    String MAIN_RBTN_TEXT_CASEUPRS = "13013D05";
    // 大写(&U)";
    String MAIN_RBTN_TIPS_CASEUPRS = "13013D06";
    // 大写";
    // ----------------------------------------------------
    // 其它语言资源常量
    // ----------------------------------------------------
    /** 公司徽标 */
    String MAIN_IMLB_TEXT_CORPICON = "13013E01";
    String MAIN_IMLB_TIPS_CORPICON = "13013E02";
    // 公司徽标";
    /** 文件图标 */
    String MAIN_IMLB_TEXT_FILEICON = "13013E03";
    String MAIN_IMLB_TIPS_FILEICON = "13013E04";
    // 文件图标";
    /** 个性图标 */
    String MAIN_IMLB_TEXT_IDIOICON = "13013E05";
    String MAIN_IMLB_TIPS_IDIOICON = "13013E06";
    // 个性图标";
    /** 软件图标 */
    String MAIN_IMLB_TEXT_SOFTICON = "13013E07";
    String MAIN_IMLB_TIPS_SOFTICON = "13013E08";
    // 软件图标";
    /** 备选软件 */
    String MAIN_LIST_TEXT_ASOCSOFT = "13013F01";
    String MAIN_LIST_TIPS_ASOCSOFT = "13013F02";
    // 备选软件";
    /** MIME类型 */
    String MAIN_LIST_TEXT_MIMETYPE = "13013F03";
    String MAIN_LIST_TIPS_MIMETYPE = "13013F04";
    // MIME类型";
    // ----------------------------------------------------
    // 数据检测
    // ----------------------------------------------------
    /** 高级模式数据检测语言资源区域 */
    String MAIN_MESG_CHCK_0000 = "13013300";
    // 高级模式数据检测语言资源区域";
    /** 查询内容为空性判断 */
    String MAIN_MESG_CHCK_0001 = "13013301";
    // {0} 不是有效的后缀，请重新输入！";
    /** 后缀所属软件信息不能为空！ */
    String MAIN_MESG_CHCK_0002 = "13013302";
    // 后缀所属软件信息不能为空！";
    // ----------------------------------------------------
    // 数据查询
    // ----------------------------------------------------
    /** 高级模式数据查询语言资源区域 */
    String MAIN_MESG_SELT_0000 = "13013400";
    // 高级模式数据查询语言资源区域";
    // ----------------------------------------------------
    // 数据更新
    // ----------------------------------------------------
    /** 高级模式数据更新语言资源区域 */
    String MAIN_MESG_UPDT_0000 = "13013500";
    // 高级模式数据更新语言资源区域";
    // ----------------------------------------------------
    // 数据删除
    // ----------------------------------------------------
    /** 高级模式数据删除语言资源区域 */
    String MAIN_MESG_DELT_0000 = "13013600";
    // 高级模式数据删除语言资源区域";
    // ----------------------------------------------------
    // 状态提示
    // ----------------------------------------------------
    /** 状态提示 */
    String NOTE_STAT_0000 = "13013700";
    /**  */
    String NOTE_STAT_0001 = "13013701";
    /** 查询结果数据显示 */
    String NOTE_STAT_0002 = "13013702";
    // {0}您当前的查询结果共 {1} 条。";
    /** 查询结果为空 */
    String NOTE_STAT_0003 = "13013703";
    // {0}您查询的后缀数据不存在！";
    /** 数据更新成功 */
    String NOTE_STAT_0004 = "13013704";
    // {0}后缀数据保存成功！";
    String NOTE_STAT_0005 = "13013705";
    // ==============================================================
    // MIME类型
    // ==============================================================
    // ----------------------------------------------------
    // MIME类型
    // ----------------------------------------------------
    /** MIME类型 */
    String MIME_COMN_TEXT_MIMENAME = "1301A101";
    // MIME类型";
    /** 相关说明 */
    String MIME_COMN_TEXT_MIMEDESP = "1301A102";
    // 相关说明";
    // ----------------------------------------------------
    // 标签资源
    // ----------------------------------------------------
    /** MIME类型 */
    String MIME_LABL_TEXT_MIMENAME = "1301A801";
    // MIME类型(&K)";
    String MIME_LABL_TIPS_MIMENAME = "1301A802";
    // MIME类型";
    /** 相关说明 */
    String MIME_LABL_TEXT_MIMEDESP = "1301A803";
    // 相关说明(&P)";
    String MIME_LABL_TIPS_MIMEDESP = "1301A804";
    // 相关说明";
    // ----------------------------------------------------
    // 文本框资源
    // ----------------------------------------------------
    /** MIME类型 */
    String MIME_AREA_TEXT_MIMEDESP = "1301A901";
    String MIME_AREA_TIPS_MIMEDESP = "1301A902";
    // MIME类型";
    /** 相关说明 */
    String MIME_FILD_TEXT_MIMENAME = "1301A903";
    String MIME_FILD_TIPS_MIMENAME = "1301A904";
    // 相关说明";
    // ----------------------------------------------------
    // 按钮资源
    // ----------------------------------------------------
    /** 取消（MIME类型） */
    String MIME_BUTN_TEXT_CANCEL = "1301AA01";
    // 取消(&C)";
    String MIME_BUTN_TIPS_CANCEL = "1301AA02";
    // 取消";
    /** 新增（MIME类型） */
    String MIME_BUTN_TEXT_CREATE = "1301AA03";
    // 新增(&N)";
    String MIME_BUTN_TIPS_CREATE = "1301AA04";
    // 新增";
    /** 删除（MIME类型） */
    String MIME_BUTN_TEXT_DELETE = "1301AA05";
    // 删除(&D)";
    String MIME_BUTN_TIPS_DELETE = "1301AA06";
    // 删除";
    /** 新增（MIME类型） */
    String MIME_BUTN_TEXT_INSERT = "1301AA07";
    // 保存(&S)";
    String MIME_BUTN_TIPS_INSERT = "1301AA08";
    // 保存";
    /** 更新（MIME类型） */
    String MIME_BUTN_TEXT_UPDATE = "1301AA09";
    // 更新(&U)";
    String MIME_BUTN_TIPS_UPDATE = "1301AA0A";
    // 更新";
    /** 参照 */
    String MIME_BUTN_TEXT_MIMEVIEW = "1301AA0B";
    String MIME_BUTN_TIPS_MIMEVIEW = "1301AA0C";
    // 参照已有MIME类型";
    // ----------------------------------------------------
    // 其它语言资源常量
    // ----------------------------------------------------
    /** MIME类型 */
    String MIME_LIST_TEXT_MIMETYPE = "1301AF01";
    String MIME_LIST_TIPS_MIMETYPE = "1301AF02";
    // 已有MIME类型列表";
    /** MIME类型数据检测语言资源区域 */
    String MIME_MESG_CHCK_0000 = "1301A300";
    /** MIME类型不能为空 */
    String MIME_MESG_CHCK_0001 = "1301A301";
    // MIME类型不能为空，请重新输入。";
    /** MIME类型查询语言资源 */
    String MIME_MESG_SELT_0000 = "1301A400";
    /** MIME类型更新语言资源 */
    String MIME_MESG_UPDT_0000 = "1301A500";
    // MIME类型数据更新语言资源区域";
    /** MIME类型已存在 */
    String MIME_MESG_UPDT_0001 = "1301A503";
    // MIME类型 “{0}” 已存在，确定用新数据覆盖已有数据吗？";
    /** MIME类型删除语言资源 */
    String MIME_MESG_DELT_0000 = "1301A600";
    // MIME类型数据删除语言资源区域";
    // ==============================================================
    // 迷你模式
    // ==============================================================
    // ----------------------------------------------------
    // 标签常量
    // ----------------------------------------------------
    /** 备选软件 */
    String MINI_LABL_TEXT_ASOCINFO = "13011801";
    // A";
    String MINI_LABL_TEXT_CORPINFO = "13011802";
    // C";
    String MINI_LABL_TEXT_DESPINFO = "13011803";
    // D";
    String MINI_LABL_TEXT_FILEINFO = "13011804";
    // F";
    String MINI_LABL_TEXT_IDIOINFO = "13011805";
    // I";
    String MINI_LABL_TEXT_MIMEINFO = "13011806";
    // M";
    String MINI_LABL_TEXT_SOFTINFO = "13011807";
    // S";
    String MINI_LABL_TEXT_NICKNAME = "13011808";
    // 昵 称";
    String MINI_LABL_TIPS_NICKNAME = "13011809";
    // 昵称";
    // ----------------------------------------------------
    // 按钮常量
    // ----------------------------------------------------
    /** 多件查询结果按钮 */
    String MINI_BUTN_TEXT_SOFTLIST = "13011A01";
    // &L";
    String MINI_BUTN_TIPS_SOFTLIST = "13011A02";
    // 查询结果
    String MINI_BUTN_NOTE_SOFTLIST = "13011A03";
    // 查询结果：共{0}件！";
    // ==============================================================
    // 软件信息
    // ==============================================================
    // ----------------------------------------------------
    // 共用常量
    // ----------------------------------------------------
    /** 所属公司 */
    String SOFT_COMN_TEXT_SOFTCORP = "13016101";
    // 所属公司";
    /** 相关说明（软件信息） */
    String SOFT_COMN_TEXT_SOFTDESP = "13016102";
    // 相关说明";
    /** 支持格式 */
    String SOFT_COMN_TEXT_SOFTEXTS = "13016103";
    // 支持格式";
    /** 软件列表 */
    String SOFT_COMN_TEXT_SOFTMETA = "13016104";
    // 软件列表";
    /** 软件名称 */
    String SOFT_COMN_TEXT_SOFTNAME = "13016105";
    // 软件名称";
    /** 链接地址（软件信息） */
    String SOFT_COMN_TEXT_SOFTSITE = "13016106";
    // 链接地址";
    // ----------------------------------------------------
    // 标签资源
    // ----------------------------------------------------
    /** 所属公司 */
    String SOFT_LABL_TEXT_SOFTCORP = "13016801";
    // SOFT_TEXT_SOFTCORP + "(&I)";
    String SOFT_LABL_TIPS_SOFTCORP = "13016802";
    // 所属公司";
    /** 相关说明（软件信息） */
    String SOFT_LABL_TEXT_SOFTDESP = "13016803";
    // SOFT_TEXT_SOFTDESP + "(&P)";
    String SOFT_LABL_TIPS_SOFTDESP = "13016804";
    // 相关说明";
    /** 支持格式 */
    String SOFT_LABL_TEXT_SOFTEXTS = "13016805";
    // SOFT_TEXT_SOFTEXTS + "(&F)";
    String SOFT_LABL_TIPS_SOFTEXTS = "13016806";
    // 支持格式";
    /** 软件名称 */
    String SOFT_LABL_TEXT_SOFTNAME = "13016807";
    // SOFT_TEXT_SOFTNAME + "(&A)";
    String SOFT_LABL_TIPS_SOFTNAME = "13016808";
    // 软件名称";
    /** 链接地址（软件信息） */
    String SOFT_LABL_TEXT_SOFTSITE = "13016809";
    // SOFT_TEXT_SOFTSITE + "(&W)";
    String SOFT_LABL_TIPS_SOFTSITE = "1301680A";
    // 软件首页";
    // ----------------------------------------------------
    // 文本框资源常量
    // ----------------------------------------------------
    /** 相关说明（软件信息） */
    String SOFT_AREA_TEXT_SOFTDESP = "13016901";
    String SOFT_AREA_TIPS_SOFTDESP = "13016902";
    // 相关说明";
    /** 支持格式 */
    String SOFT_FILD_TEXT_SOFTEXTS = "13016903";
    String SOFT_FILD_TIPS_SOFTEXTS = "13016904";
    // 支持格式";
    /** 软件名称 */
    String SOFT_FILD_TEXT_SOFTNAME = "13016905";
    String SOFT_FILD_TIPS_SOFTNAME = "13016906";
    // 软件名称";
    /** 链接地址（软件信息） */
    String SOFT_FILD_TEXT_SOFTSITE = "13016907";
    String SOFT_FILD_TIPS_SOFTSITE = "13016908";
    // 链接地址";
    // ----------------------------------------------------
    // 按钮资源常量
    // ----------------------------------------------------
    /** 取消（软件信息） */
    String SOFT_BUTN_TEXT_CANCEL = "13016A01";
    // 取消(&C)";
    String SOFT_BUTN_TIPS_CANCEL = "13016A02";
    // 取消";
    /** 新增（软件信息） */
    String SOFT_BUTN_TEXT_CREATE = "13016A03";
    // 新增(&N)";
    String SOFT_BUTN_TIPS_CREATE = "13016A04";
    // 新增";
    /** 删除（软件信息） */
    String SOFT_BUTN_TEXT_DELETE = "13016A05";
    // 删除(&D)";
    String SOFT_BUTN_TIPS_DELETE = "13016A06";
    // 删除";
    /** 新增（软件信息） */
    String SOFT_BUTN_TEXT_INSERT = "13016A07";
    // 保存(&S)";
    String SOFT_BUTN_TIPS_INSERT = "13016A08";
    // 保存";
    /** 更新（软件信息） */
    String SOFT_BUTN_TEXT_UPDATE = "13016A09";
    // 更新(&U)";
    String SOFT_BUTN_TIPS_UPDATE = "13016A0A";
    // 更新";
    /** 参照 */
    String SOFT_BUTN_TEXT_SOFTVIEW = "13016A0B";
    String SOFT_BUTN_TIPS_SOFTVIEW = "13016A0C";
    // 参照已有软件";
    /** 软件列表 */
    String SOFT_COMB_TEXT_SOFTNAME = "13016B01";
    String SOFT_COMB_TIPS_SOFTNAME = "13016B02";
    // 软件列表";
    // ----------------------------------------------------
    // 图标资源常量
    // ----------------------------------------------------
    /** 软件图标 */
    String SOFT_IMLB_TEXT_SOFTICON = "13016E01";
    String SOFT_IMLB_TIPS_SOFTICON = "13016E02";
    // 软件图标";
    /** 软件信息查询语言资源 */
    String SOFT_MESG_SELT_0000 = "13016400";
    // 软件信息数据查询语言资源区域";
    /** 软件信息更新语言资源 */
    String SOFT_MESG_UPDT_0000 = "13016500";
    // 软件信息数据更新语言资源区域";
    /** 软件信息删除语言资源 */
    String SOFT_MESG_DELT_0000 = "13016600";
    // 软件信息数据删除语言资源区域";
    // ////////////////////////////////////////////////////////////////////////
    // 向导面板资源常量
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 按钮资源
    // ----------------------------------------------------
    /** 上一步 */
    String STEP_BUTN_TEXT_LASTBUTN = "1301DA01";
    // 上一步(&L)";
    String STEP_BUTN_TIPS_LASTBUTN = "1301DA02";
    // 取消操作，返回上一步";
    /** 下一步 */
    String STEP_BUTN_TEXT_NEXTBUTN = "1301DA03";
    // 下一步(&N)";
    String STEP_BUTN_TIPS_NEXTBUTN = "1301DA04";
    // 保存操作，继续下一步";
    /** 取消 */
    String STEP_BUTN_TEXT_STOPBUTN = "1301DA05";
    // 取消(&C)";
    String STEP_BUTN_TIPS_STOPBUTN = "1301DA06";
    // 取消操作并退出";
    /** 继续 */
    String STEP_BUTN_TEXT_MOREBUTN = "1301DA07";
    // 继续(&M)";
    String STEP_BUTN_TIPS_MOREBUTN = "1301DA08";
    // 继续添加新的后缀";
    /** 退出 */
    String STEP_BUTN_TEXT_EXITBUTN = "1301DA09";
    // 退出(&X)";
    String STEP_BUTN_TIPS_EXITBUTN = "1301DA0A";
    // 退出";
    /** 新增数据 */
    String STEP_BUTN_TEXT_INSTBUTN = "1301DA0B";
    // &I";
    String STEP_BUTN_TIPS_INSTBUTN = "1301DA0C";
    // 添加数据";
    /** 开始按钮 */
    String STEP_BUTN_TEXT_STATBUTN = "1301DA0D";
    String STEP_BUTN_TIPS_STATBUTN = "1301DA0E";
    // 开始尝试添加新的后缀数据";
    // ----------------------------------------------------
    // 其它资源
    // ----------------------------------------------------
    /**  */
    String STEP_OTHR_STEP_0000 = "1301DF00";
    /** 欢迎信息 */
    String STEP_OTHR_STEP_0001 = "1301DF01";
    /** 键入后缀名称 */
    String STEP_OTHR_STEP_0002 = "1301DF02";
    /** 选择国别信息 */
    String STEP_OTHR_STEP_0003 = "1301DF03";
    /** 选择公司信息 */
    String STEP_OTHR_STEP_0004 = "1301DF04";
    /** 选择软件信息 */
    String STEP_OTHR_STEP_0005 = "1301DF05";
    /** 选择文件信息 */
    String STEP_OTHR_STEP_0006 = "1301DF06";
    /** 选择类别信息 */
    String STEP_OTHR_STEP_0007 = "1301DF07";
    /** 选择人员信息 */
    String STEP_OTHR_STEP_0008 = "1301DF08";
    /** 选择平台信息 */
    String STEP_OTHR_STEP_0009 = "1301DF09";
    /** 选择构架信息 */
    String STEP_OTHR_STEP_0010 = "1301DF0A";
    /** 输入个人说明 */
    String STEP_OTHR_STEP_0011 = "1301DF0B";
    /** 数据添加成功 */
    String STEP_OTHR_STEP_0012 = "1301DF0C";
    // ////////////////////////////////////////////////////////////////////////
    // 界面菜单资源常量
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 菜单资源常量
    // ----------------------------------------------------
    /** 我有Bug */
    String MENU_TEXT_HAVEBUGS = "1301C701";
    // 我有 Bug";
    String MENU_TIPS_HAVEBUGS = "1301C702";
    // 我有 Bug";
    /** 我有建议 */
    String MENU_TEXT_HAVEIDEA = "1301C749";
    // 我有建议";
    String MENU_TIPS_HAVEIDEA = "1301C74A";
    // 我有建议";
    /** 联系作者 */
    String MENU_TEXT_HELPAMON = "1301C74B";
    // 联系作者(&C)";
    String MENU_TIPS_HELPAMON = "1301C74C";
    // 联系作者";
    /** 备选软件 */
    String MENU_TEXT_ASOCFORM = "1301C703";
    // 备选软件(&A)";
    String MENU_TIPS_ASOCFORM = "1301C704";
    // 显示备选软件窗口";
    /** 公司信息 */
    String MENU_TEXT_CORPFORM = "1301C705";
    // 公司信息(&C)";
    String MENU_TIPS_CORPFORM = "1301C706";
    // 显示公司信息窗口";
    /** 描述信息 */
    String MENU_TEXT_DESPFORM = "1301C707";
    // 描述信息(&D)";
    String MENU_TIPS_DESPFORM = "1301C708";
    // 显示描述信息窗口";
    /** 数据管理 */
    String MENU_TEXT_EXTSFORM = "1301C709";
    // 数据管理(&E)";
    String MENU_TIPS_EXTSFORM = "1301C70A";
    // 显示数据管理窗口";
    /** 文件信息 */
    String MENU_TEXT_FILEFORM = "1301C70B";
    // 文件信息(&F)";
    String MENU_TIPS_FILEFORM = "1301C70C";
    // 显示文件信息窗口";
    /** 特别致谢 */
    String MENU_TEXT_IDIOFORM = "1301C70D";
    // 特别致谢(&I)";
    String MENU_TIPS_IDIOFORM = "1301C70E";
    // 显示特别致谢窗口";
    /** MIME类型 */
    String MENU_TEXT_MIMEFORM = "1301C70F";
    // MIME类型(&M)";
    String MENU_TIPS_MIMEFORM = "1301C710";
    // 显示MIME类型窗口";
    /** 软件信息 */
    String MENU_TEXT_SOFTFORM = "1301C711";
    // 软件信息(&S)";
    String MENU_TIPS_SOFTFORM = "1301C712";
    // 显示软件信息窗口";
    /** 检测更新 */
    String MENU_TEXT_CHCKUPDT = "1301C713";
    // 检测更新";
    String MENU_TIPS_CHCKUPDT = "1301C714";
    // 检测更新";
    /** 运行 */
    String MENU_TEXT_ICOMMAND = "1301C715";
    // 运行(&R)";
    String MENU_TIPS_ICOMMAND = "1301C716";
    // 运行";
    /** 数据删除 */
    String MENU_TEXT_DATADELT = "1301C717";
    // 数据删除";
    String MENU_TIPS_DATADELT = "1301C718";
    // 数据删除";
    /** 数据编辑 */
    String MENU_TEXT_DATAEDIT = "1301C719";
    // 数据编辑(&E)";
    String MENU_TIPS_DATAEDIT = "1301C71A";
    // 数据编辑";
    /** 数据新增 */
    String MENU_TEXT_INSTUSER = "1301C71B";
    // 数据新增（快速）";
    String MENU_TIPS_INSTUSER = "1301C71C";
    // 数据新增（快速）";
    /** 数据新增 */
    String MENU_TEXT_INSTSTEP = "1301C74D";
    // 数据新增（向导）";
    String MENU_TIPS_INSTSTEP = "1301C74E";
    // 数据新增（向导）";
    /** 数据更新 */
    String MENU_TEXT_UPDTUSER = "1301C71D";
    // 数据更新（快速）";
    String MENU_TIPS_UPDTUSER = "1301C71E";
    // 数据更新（快速）";
    /** 数据更新 */
    String MENU_TEXT_UPDTSTEP = "1301C74F";
    // 数据更新（向导）";
    String MENU_TIPS_UPDTSTEP = "1301C750";
    // 数据更新（向导）";
    /** 数据导出 */
    String MENU_TEXT_DATAEXPT = "1301C71F";
    // 数据导出(&P)";
    String MENU_TIPS_DATAEXPT = "1301C720";
    // 数据导出";
    /** 数据安全 */
    String MENU_TEXT_DATASAFE = "1301C721";
    // 数据安全(&S)";
    String MENU_TIPS_DATASAFE = "1301C722";
    // 数据安全";
    /** 数据备份 */
    String MENU_TEXT_DBBACKUP = "1301C723";
    // 数据备份";
    String MENU_TIPS_DBBACKUP = "1301C724";
    // 数据备份";
    /** 数据恢复 */
    String MENU_TEXT_DBPICKUP = "1301C725";
    // 数据恢复";
    String MENU_TIPS_DBPICKUP = "1301C726";
    // 数据恢复";
    /** 新后缀提交 */
    String MENU_TEXT_EXTSUBMIT = "1301C727";
    // 新后缀提交";
    String MENU_TIPS_EXTSUBMIT = "1301C728";
    // 新后缀提交";
    /** 使用帮助 */
    String MENU_TEXT_HELPTOPS = "1301C729";
    // 使用帮助(&H)";
    String MENU_TIPS_HELPTOPS = "1301C72A";
    // 使用帮助";
    /** 软件首页 */
    String MENU_TEXT_HOMEPAGE = "1301C72B";
    // 软件首页(&W)";
    String MENU_TIPS_HOMEPAGE = "1301C72C";
    // 软件首页";
    /** 所有语言 */
    String MENU_TEXT_LANG_ALL = "1301C72D";
    // 所有语言...";
    String MENU_TIPS_LANG_ALL = "1301C72E";
    // 所有语言";
    /** 语言资源编辑 */
    String MENU_TEXT_LANGEDIT = "1301C72F";
    // 语言资源编辑";
    String MENU_TIPS_LANGEDIT = "1301C730";
    // 启动语言资源编辑器，添加或更新界面语言资源";
    /** 语言列表 */
    String MENU_TEXT_LANGLIST = "1301C731";
    // 界面语言(&L)";
    String MENU_TIPS_LANGLIST = "1301C732";
    // 界面语言";
    /** 人气支持 */
    String MENU_TEXT_PICKRANK = "1301C733";
    // 人气支持";
    String MENU_TIPS_PICKRANK = "1301C734";
    // 人气支持";
    /** 界面皮肤 */
    String MENU_TEXT_SKINLIST = "1301C735";
    // 界面皮肤(&U)";
    String MENU_TIPS_SKINLIST = "1301C736";
    // 界面皮肤";
    /** 系统界面 */
    String MENU_TEXT_SKINSYSTEM = "1301C737";
    // System";
    String MENU_TIPS_SKINSYSTEM = "1301C738";
    // 当前操作系统界面风格";
    /** METAL 界面 */
    String MENU_TEXT_SKINMETAL = "1301C739";
    // Metal";
    String MENU_TIPS_SKINMETAL = "1301C73A";
    // Metal界面风格";
    /** MOTIF界面 */
    String MENU_TEXT_SKINMOTIF = "1301C73B";
    // Motif";
    String MENU_TIPS_SKINMOTIF = "1301C73C";
    // Motif界面风格";
    /** Windows XP界面风格 */
    String MENU_TEXT_SKINWINXP = "1301C73D";
    // Windows XP";
    String MENU_TIPS_SKINWINXP = "1301C73E";
    // Windows XP界面风格";
    /** Windows 经典风格 */
    String MENU_TEXT_SKINWINME = "1301C73F";
    // Windows Classic";
    String MENU_TIPS_SKINWINME = "1301C740";
    // Windows 经典风格";
    /** 关于软件 */
    String MENU_TEXT_SOFTINFO = "1301C741";
    // 关于软件(&A)";
    String MENU_TIPS_SOFTINFO = "1301C742";
    // 关于软件";
    /** 系统退出 */
    String MENU_TEXT_HIDEFORM = "1301C743";
    // 系统退出(&X)";
    String MENU_TIPS_HIDEFORM = "1301C744";
    // 系统退出";
    /** 界面视图 */
    String MENU_TEXT_VIEWFORM = "1301C745";
    // 界面视图(&V)";
    String MENU_TIPS_VIEWFORM = "1301C746";
    // 界面视图";
    /** 在线搜索 */
    String MENU_TEXT_OLSEARCH = "1301C747";
    // 在线搜索(&O)";
    String MENU_TIPS_OLSEARCH = "1301C748";
    // 在线搜索";
    /** Amon在线 */
    String MENU_TEXT_AMONSOFT = "1301C75B";
    // Amon在线";
    String MENU_TIPS_AMONSOFT = "1301C75C";
    // Amon在线";
    /** 新后缀提交 */
    String MENU_TEXT_EXTONLINE = "1301C75D";
    // 在线查询";
    String MENU_TIPS_EXTONLINE = "1301C75E";
    // 在线查询";
    // ////////////////////////////////////////////////////////////////////////
    // 消息提示资源常量
    // ////////////////////////////////////////////////////////////////////////
    // ----------------------------------------------------
    // 数据导出
    // ----------------------------------------------------
    /** 数据导出成功 */
    String MESG_EXPT_0001 = "13010801";
    // 数据导出成功！";
    /** 数据导出失败 */
    String MESG_EXPT_0002 = "13010802";
    // 数据导出失败：无法正常导出数据，{0}";
    /** 模板文件不存在 */
    String MESG_EXPT_0003 = "13010803";
    // 模板文件 “{0}” 不存在！";
    /** 不是有效文件 */
    String MESG_EXPT_0004 = "13010804";
    // 模板文件 “{0}” 不是有效的文件！";
    /** 无法读取模板文件 */
    String MESG_EXPT_0005 = "13010805";
    // 不能正常读取模板文件 “{0}”，请确认您是否有足够的权限或其它原因。";
    /** 不是有效文件 */
    String MESG_EXPT_0006 = "13010806";
    // 您选择的文件 “{0}” 已在，但不是有效的文件！";
    /** 无法写入目标文件 */
    String MESG_EXPT_0007 = "13010807";
    // 输出文件 “{0}” 不能正常写入数据，请确认您是否有足够的权限或其它原因。";
    // ----------------------------------------------------
    // 数据安全
    // ----------------------------------------------------
    /** 备份提示 */
    String MESG_SAFE_0001 = "13010901";
    // 执行此操作后，您上一次的备份数据将被更新覆盖，确认要执行数据备份操作么？";
    /** 数据恢复确认 */
    String MESG_SAFE_0002 = "13010902";
    // 您的数据将会被恢复到最近一次的备份状态，确认要执行数据恢复操作吗？";
}
