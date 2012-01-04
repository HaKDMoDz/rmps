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
 * 
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
    /** 数据备份目录 */
    String FOLDER0_BACK = "bak";
    String FOLDER0_CFG = "cfg";
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
    String FOLDER0_PLUS = "plug-ins";
    // ========================================================================
    // 1级：用户数据文件夹变量
    // ========================================================================
    /** Amon专用目录 */
    String FOLDER1_AMON = "amon";
    /** INFO系统目录 */
    String FOLDER1_COMN = "comn";
    /** 数据目录 */
    String FOLDER1_DAT = "dat";
    /** ERP系统数据目录 */
    String FOLDER1_ERP = "erp";
    /** IRP系统数据目录 */
    String FOLDER1_IRP = "irp";
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
    String COMN_SOFT_INFO = "{0}_info.properties";
    /** 软件语言资源前缀字符 */
    String COMN_SOFT_LANG = "{0}_lang.properties";
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
}
