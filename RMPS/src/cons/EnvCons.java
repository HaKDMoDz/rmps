/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons;

import java.io.File;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * RMPS系统环境变量常量类<br>
 * 操作系统平台环境变量的常量类，用于记录与平台相关的一些变量名称。
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public interface EnvCons
{
    // ========================================================================
    // 系统参数变量
    // ========================================================================
    /** 用户信息：所有信息 */
    String USER = "user";
    /** 用户信息：用户名称 */
    String USER_NAME = "user.name";
    /** 用户信息：当前工作目录 */
    String USER_WORKDIR = "user.dir";
    /** 用户信息：用户主目录 */
    String USER_HOMEDIR = "user.home";
    /** 用户信息：用户语言信息 */
    String USER_LANGUAGE = "user.language";
    /** 用户信息：用户国别信息 */
    String USER_COUNTRY = "user.country";
    /** Java环境：所有信息 */
    String JAVA = "java";
    /** Java环境：安装路径 */
    String JAVA_HOME = "java.home";
    /** Java环境：版本信息 */
    String JAVA_VERSION = "java.version";
    /** Java环境：当前使用JDK版本 */
    String JAVA_VM_VERSION = "java.vm.version";
    /** Java环境：当前使用JRE版本 */
    String JAVA_RE_VERSION = "java.runtime.version";
    /** Java环境：临时工作目录 */
    String JAVA_IO_TEMPDIR = "java.io.tmpdir";
    /** Java环境：桌面名称 */
    String JAVA_OS_DESKTOP = "sun.desktop";
    /** 操作系统：所有信息 */
    String OS = "os";
    /** 操作系统：系统名称 */
    String OS_NAME = "os.name";
    /** 操作系统：版本信息 */
    String OS_VERSION = "os.version";
    /** 操作系统：文本换行分隔符 */
    String OS_LINE_SEPARATOR = "line.separator";
    /** 操作系统：环境路径分隔符 */
    String OS_PATH_SEPARATOR = "path.separator";
    /** 操作系统：文件路径分隔符 */
    String OS_FILE_SEPARATOR = "file.separator";
    /** 操作系统：文件编码 */
    String OS_FILE_ENCODING = "file.encoding";
    /** Windows平台：程序安装目录 */
    String WINDOWS_PROGFILE = "ProgramFiles";
    /** Windows平台：系统安装目录 */
    String WINDOWS_SYSDRIVER = "SystemDrive";
    /** Windows平台：系统启动目录 */
    String WINDOWS_SYSROOT = "SystemRoot";
    // ========================================================================
    // 0级：软件运行环境变量
    // ========================================================================
    String FOLDER0_DATA = "dat";
    /** 帮助目录 */
    String FOLDER0_HELP = "help";
    /** 运行时类库目录 */
    String FOLDER0_LIBS = "lib";
    /** 界面皮肤目录 */
    String FOLDER0_SKIN = "skin";
    /** 相关工具目录 */
    String FOLDER0_TOOL = "tool";
    /** 模板文件目录 */
    String FOLDER0_TPLT = "template";
    /** 语言资源目录 */
    String FOLDER0_LANG = "language";
    /** 插件目录 */
    String FOLDER0_PLUS = "plugins";
    // ========================================================================
    // 1级：用户数据文件夹变量
    // ========================================================================
    /** Amon专用目录 */
    String FOLDER1_AMON = "amon";
    /** 数据备份目录 */
    String FOLDER1_BAK = "bak";
    /** INFO系统目录 */
    String FOLDER1_COMN = "comn";
    /** 数据目录 */
    String FOLDER1_DAT = "dat";
    /** ERP系统数据目录 */
    String FOLDER1_ERP = "erp";
    /** IMS系统数据目录 */
    String FOLDER1_IMS = "ims";
    /** 日志输出目录 */
    String FOLDER1_LOG = "log";
    /** MRP系统目录 */
    String FOLDER1_MRP = "mrp";
    /** PRP系统目录 */
    String FOLDER1_PRP = "prp";
    /** 临时目录 */
    String FOLDER1_TMP = "tmp";
    /** 用户目录 */
    String FOLDER1_USER = "user";
    /** WRP系统目录 */
    String FOLDER1_WRP = "wrp";
    // ========================================================================
    // 2级：用户数据文件夹变量
    // ========================================================================
    // ----------------------------------------------------
    // 共用同名二级目录
    // ----------------------------------------------------
    /** info系统目录 */
    String FOLDER2_INFO = "info";
    // ----------------------------------------------------
    // PRP系统二级目录
    // ----------------------------------------------------
    /** Aide系统目录 */
    String FOLDER2_AIDE = "aide";
    /** fanc系统目录 */
    String FOLDER2_FANC = "fanc";
    /** musc系统目录 */
    String FOLDER2_MUSC = "musc";
    /** home系统目录 */
    String FOLDER2_HOME = "home";
    /** work系统目录 */
    String FOLDER2_WORK = "work";
    // ----------------------------------------------------
    // AMON系统二级目录
    // ----------------------------------------------------
    /** code系统目录 */
    String FOLDER2_CODE = "code";
    /** data系统目录 */
    String FOLDER2_DATA = "data";
    String FOLDER2_LANG = "lang";
    String FOLDER2_USER = "user";
    // ----------------------------------------------------
    // COMN系统二级目录
    // ----------------------------------------------------
    String FOLDER2_HELP = "help";
    String FOLDER2_TEST = "test";
    String FOLDER2_TRAY = "tray";
    // ----------------------------------------------------
    // USER系统二级目录
    // ----------------------------------------------------
    String FOLDER2_U0000000 = "U0000000";
    String FOLDER2_U0010000 = "U0010000";
    String FOLDER2_U0020000 = "U0020000";
    String FOLDER2_U0030000 = "U0030000";
    // ========================================================================
    // 3级：用户数据文件夹变量
    // ========================================================================
    // -----------------------------------------------------
    // Amon模块
    /** icodesec系统目录 */
    String FOLDER3_A1010000 = "A1010000";
    /** dbmanage系统目录 */
    String FOLDER3_A2010000 = "A2010000";
    String FOLDER3_A3010000 = "A3010000";
    String FOLDER3_AF010000 = "AF010000";
    // -----------------------------------------------------
    // Comn模块
    /** softinfo系统目录 */
    String FOLDER3_C1010000 = "C1010000";
    /** rmpstray系统目录 */
    String FOLDER3_C3010000 = "C3010000";
    /** PublicAD系统目录 */
    String FOLDER3_C4010000 = "C4010000";
    /** Testsoft系统目录 */
    String FOLDER3_CF010000 = "C0FF0000";
    // -----------------------------------------------------
    // Aide模块
    /** Extparse用户数据目录 */
    String FOLDER3_P3010000 = "P3010000";
    /** IUnicode用户数据目录 */
    String FOLDER3_P3020000 = "P3020000";
    /** IUnicode用户数据目录 */
    String FOLDER3_P3030000 = "P3030000";
    /** IMinical用户数据目录 */
    String FOLDER3_P3040000 = "P3040000";
    /** IDatasec用户数据目录 */
    String FOLDER3_P3050000 = "P3050000";
    /** IMathcal用户数据目录 */
    String FOLDER3_P3060000 = "P3060000";
    /** IMathcal用户数据目录 */
    String FOLDER3_P3070000 = "P3070000";
    /** IMathcal用户数据目录 */
    String FOLDER3_P3080000 = "P3080000";
    /** IMathcal用户数据目录 */
    String FOLDER3_P3090000 = "P3090000";
    /** IMathcal用户数据目录 */
    String FOLDER3_P30A0000 = "P30A0000";
    /** IMathcal用户数据目录 */
    String FOLDER3_P30B0000 = "P30B0000";
    /** IMathcal用户数据目录 */
    String FOLDER3_P30C0000 = "P30C0000";
    /** IMathcal用户数据目录 */
    String FOLDER3_P30D0000 = "P30D0000";
    /** IMathcal用户数据目录 */
    String FOLDER3_P30E0000 = "P30E0000";
    /** IMathcal用户数据目录 */
    String FOLDER3_P30F0000 = "P30F0000";
    // ========================================================================
    // 4级：用户数据文件夹变量
    // ========================================================================
    /** 公司图标目录 */
    String FOLDER4_CORPICON = "corp";
    /** 文件图标目录 */
    String FOLDER4_FILEICON = "file";
    /** 个人图标目录 */
    String FOLDER4_IDIOICON = "idio";
    /** 软件图标目录 */
    String FOLDER4_SOFTICON = "soft";
    // ========================================================================
    // 软件运行变量
    // ========================================================================
    /** 默认数据读取缓冲区大小为8192字节 */
    int COMN_BUFF_SIZE = 8192;
    /** 系统文件路径分隔符 */
    String COMN_SP_FILE = "/";
    /** 系统参数元素分隔符 */
    String COMN_SP_PATH = File.pathSeparator;
    /** 数据存放文件名 */
    String COMN_DATA_BASE = "amon";
    /** 当前数据版本信息 */
    String COMN_DBSVERSION = "8";
    /** JRE版本信息 */
    String COMN_JREVERSION = "1.6";
    /** 日志输出文件名 */
    String COMN_LOGS_FILE = "exception_{0}.log";
    /** RMPS根目录标记 */
    String COMN_PATH_RMPS = "$" + COMN_SP_FILE;
    /** 插件软件目录标记 */
    String COMN_PATH_SOFT = "#" + COMN_SP_FILE;
    /** 当前运行目录标记 */
    String COMN_PATH_HOME = FOLDER0_DATA + COMN_SP_FILE;
    /** 网络加载目录标记 */
    String COMN_PATH_JNLP = SysCons.HOMEPAGE + "jnlp/";
    /** 插件配置文件 */
    String COMN_PLUG_FILE = "plugin.xml";
    /** 系统皮肤配置文件名 */
    String COMN_SKIN_FILE = "skin.xml";
    /** 关于软件资源前缀字符 */
    String COMN_SOFT_INFO = "{0}_info" + SysCons.EXTS_INFO;
    /** 软件语言资源前缀字符 */
    String COMN_SOFT_LANG = "{0}_lang" + SysCons.EXTS_LANG;
    // ========================================================================
    // 软件升级变量
    // ========================================================================
    /**  */
    String PRPS_SOFTNAME = "prp";
    /**  */
    String PRPS_SOFTEDIT = "prp";
    /**  */
    String EXTPARSE_SOFTNAME = "extparse";
    /** 当前软件版本 */
    String EXTPARSE_SOFTEDIT = "extparse";
    // ========================================================================
    // 数据目录变量
    // ========================================================================
    /** 系统资源目录 */
    String PATH_RES = "/res";
    // 公共目录
    String PATH_BAK = COMN_SP_FILE + FOLDER1_BAK;
    String PATH_DAT = COMN_SP_FILE + FOLDER1_DAT;
    String PATH_LOG = COMN_SP_FILE + FOLDER1_LOG;
    String PATH_TMP = COMN_SP_FILE + FOLDER1_TMP;
    // ERP目录
    String PATH_ERP = COMN_SP_FILE + FOLDER1_ERP;
    // MRP目录
    String PATH_MRP = COMN_SP_FILE + FOLDER1_MRP;
    // AMON目录
    String PATH_AMON = COMN_SP_FILE + FOLDER1_AMON;
    String PATH_CODE = PATH_AMON + COMN_SP_FILE + FOLDER2_CODE;
    String PATH_A1010000 = PATH_CODE + COMN_SP_FILE + FOLDER3_A1010000;
    String PATH_A2010000 = PATH_CODE + COMN_SP_FILE + FOLDER3_A2010000;
    String PATH_A3010000 = PATH_CODE + COMN_SP_FILE + FOLDER3_A3010000;
    String PATH_AF010000 = PATH_CODE + COMN_SP_FILE + FOLDER3_AF010000;
    // COMN目录
    String PATH_COMN = COMN_SP_FILE + FOLDER1_COMN;
    String PATH_HELP = PATH_COMN + COMN_SP_FILE + FOLDER2_HELP;
    String PATH_TEST = PATH_COMN + COMN_SP_FILE + FOLDER2_TEST;
    String PATH_TRAY = PATH_COMN + COMN_SP_FILE + FOLDER2_TRAY;
    String PATH_C1010000 = PATH_HELP + COMN_SP_FILE + FOLDER3_C1010000;
    String PATH_C3010000 = PATH_COMN + COMN_SP_FILE + FOLDER3_C3010000;
    String PATH_C4010000 = PATH_COMN + COMN_SP_FILE + FOLDER3_C4010000;
    String PATH_CF010000 = PATH_TEST + COMN_SP_FILE + FOLDER3_CF010000;
    // PRP目录
    String PATH_PRP = COMN_SP_FILE + FOLDER1_PRP;
    String PATH_AIDE = PATH_PRP + COMN_SP_FILE + FOLDER2_AIDE;
    String PATH_FANC = PATH_PRP + COMN_SP_FILE + FOLDER2_FANC;
    String PATH_INFO = PATH_PRP + COMN_SP_FILE + FOLDER2_INFO;
    String PATH_MUSC = PATH_PRP + COMN_SP_FILE + FOLDER2_MUSC;
    String PATH_HOME = PATH_PRP + COMN_SP_FILE + FOLDER2_HOME;
    String PATH_WORK = PATH_PRP + COMN_SP_FILE + FOLDER2_WORK;
    String PATH_P3010000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P3010000;
    String PATH_P3020000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P3020000;
    String PATH_P3030000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P3030000;
    String PATH_P3040000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P3040000;
    String PATH_P3050000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P3050000;
    String PATH_P3060000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P3060000;
    String PATH_P3070000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P3070000;
    String PATH_P3080000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P3080000;
    String PATH_P3090000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P3090000;
    String PATH_P30A0000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P30A0000;
    String PATH_P30B0000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P30B0000;
    String PATH_P30C0000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P30C0000;
    String PATH_P30D0000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P30D0000;
    String PATH_P30E0000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P30E0000;
    String PATH_P30F0000 = PATH_AIDE + COMN_SP_FILE + FOLDER3_P30F0000;
    String PATH_I3010000 = "/ims/a";
    // USER系统二级目录
    String PATH_USER = COMN_SP_FILE + FOLDER1_USER;
    String PATH_U0000000 = PATH_USER + COMN_SP_FILE + FOLDER2_U0000000;
    String PATH_U0010000 = PATH_USER + COMN_SP_FILE + FOLDER2_U0010000;
    String PATH_U0020000 = PATH_USER + COMN_SP_FILE + FOLDER2_U0020000;
    String PATH_U0030000 = PATH_USER + COMN_SP_FILE + FOLDER2_U0030000;
    // WRP目录
    String PATH_WRP = COMN_SP_FILE + FOLDER1_WRP;
}
