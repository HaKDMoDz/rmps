/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P3010000;

import cons.SysCons;
import cons.id.PrpCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 后缀解析系统界面常量
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public interface ConstUI
{
    // ////////////////////////////////////////////////////////////////////////
    // 系统唯一标记
    // ////////////////////////////////////////////////////////////////////////
    /** 后缀解析系统当前使用数据格式版本 */
    String VER_DATA = "8";
    /** 后缀解析系统当前软件版本 */
    String VER_CODE = "2.2.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + PrpCons.P3010000_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "P3010000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "P3010000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "P3010000.description";
    // ////////////////////////////////////////////////////////////////////////
    // 界面显示常量
    // ////////////////////////////////////////////////////////////////////////
    /** 备选软件详细信息面板属性名称 */
    String PROP_ITEM_ASOC = "asocitem";
    /** 公司徽标详细信息面板属性名称 */
    String PROP_ITEM_CORP = "corpitem";
    /** 公司徽标详细信息面板属性名称 */
    String PROP_ITEM_DESP = "despitem";
    /** 文档格式详细信息面板属性名称 */
    String PROP_ITEM_DOCS = "docsitem";
    /** 文件信息详细信息面板属性名称 */
    String PROP_ITEM_FILE = "fileitem";
    /** 贡献人员详细信息面板属性名称 */
    String PROP_ITEM_IDIO = "idioitem";
    /** MIME类型详细信息面板属性名称 */
    String PROP_ITEM_MIME = "mimeitem";
    /** 应用软件详细信息面板属性名称 */
    String PROP_ITEM_SOFT = "softitem";
    // ////////////////////////////////////////////////////////////////////////
    // 构件属性常量
    // ////////////////////////////////////////////////////////////////////////
    /** 备选软件图标标签持有属性名称 */
    String PROP_ICON_ASOC = "asocicon";
    /** 公司徽标标签持有属性名称 */
    String PROP_ICON_CORP = "corpicon";
    /** 文件图标标签持有属性名称 */
    String PROP_ICON_FILE = "fileicon";
    /** 个性图标标签持有属性名称 */
    String PROP_ICON_IDIO = "idioicon";
    /** 软件图标标签持有属性名称 */
    String PROP_ICON_SOFT = "softicon";
    /** 后缀名称文本条持有属性名称 */
    String PROP_HASH_EXTS = "extshash";
    /** 软件名称组合框持有属性名称 */
    String PROP_HASH_SOFT = "softhash";
    /** 界面语言菜单项持有属性名称 */
    String PROP_HASH_LANG = "langhash";
    /** 数据导出菜单项持有属性名称 */
    String PROP_MENU_DATAEXPT = "dataexpt";
    /** 界面皮肤菜单项持有属性名称 */
    String PROP_MENU_SKINNAME = "skinname";
    /** 搜索引擎菜单项持有属性名称 */
    String PROP_MENU_SRCHURLS = "srchurls";
    /** 显示窗口标签持有属性名称 */
    String PROP_MENU_VIEWFORM = "viewform";
    // ////////////////////////////////////////////////////////////////////////
    // 其它常量
    // ////////////////////////////////////////////////////////////////////////
    /** 默认图像宽度 */
    int DEF_IMG_WIDH = 48;
    /** 默认图像高度 */
    int DEF_IMG_HIGH = 48;
    /** 默认备选软件索引 */
    String DEF_ASOCHASH = "0";
    /** 默认备选软件图像 */
    String DEF_ASOCICON = "0";
    /** 默认公司信息索引 */
    String DEF_CORPHASH = "0";
    /** 默认公司徽标文件名 */
    String DEF_CORPICON = "0";
    /** 默认描述索引 */
    String DEF_DESPHASH = "0";
    /** 默认描述语言 */
    String DEF_DESPLANG = SysCons.UI_LANGHASH;
    /** 默认后缀索引 */
    String DEF_EXTSHASH = "0";
    String DEF_EXTSNAME = "";
    /** 默认文件信息索引 */
    String DEF_FILEHASH = "0";
    /** 默认文件图标文件名 */
    String DEF_FILEICON = "0";
    /** 默认个人索引 */
    String DEF_IDIOHASH = "0";
    /** 默认个性图标 */
    String DEF_IDIOICON = "0";
    /** 默认MIME类型索引 */
    String DEF_MIMEHASH = "0";
    /** 默认国别索引 */
    String DEF_NATNHASH = "0";
    /** 默认软件信息索引 */
    String DEF_SOFTHASH = "0";
    /** 默认软件图标文件名 */
    String DEF_SOFTICON = "0";
    /** 默认类别索引 */
    String DEF_TYPEHASH = "0";
    /** 数据导出替换正则表达式 */
    String EXPT_FORMTEXT = "#{0}#";
    /** 图像导出时的默认目录 */
    String EXPT_ICONPATH = "icon";
    /** 图像导出时备选软件图标名称 */
    String EXPT_ASOCICON = "asocicon" + SysCons.EXTS_PICT;
    /** 图像导出时公司图标名称 */
    String EXPT_CORPICON = "corpicon" + SysCons.EXTS_PICT;
    /** 图像导出时文件图标名称 */
    String EXPT_FILEICON = "fileicon" + SysCons.EXTS_PICT;
    /** 图像导出时个性图标名称 */
    String EXPT_IDIOICON = "idioicon" + SysCons.EXTS_PICT;
    /** 图像导出时软件图标名称 */
    String EXPT_SOFTICON = "softicon" + SysCons.EXTS_PICT;
    /** 图像存取顺序 */
    String[] ICON_ORDR =
    { SysCons.ICON_SIZE_0048, SysCons.ICON_SIZE_0032, SysCons.ICON_SIZE_0024, SysCons.ICON_SIZE_0016, SysCons.ICON_SIZE_0256, SysCons.ICON_SIZE_0128, SysCons.ICON_SIZE_0096, SysCons.ICON_SIZE_0080,
            SysCons.ICON_SIZE_0072, SysCons.ICON_SIZE_0064 };
    // ////////////////////////////////////////////////////////////////////////
    // 向导操作步骤
    // ////////////////////////////////////////////////////////////////////////
    /** 第一步：向导说明 */
    int STEP_STT = 0;
    /** 下一步：输入后缀 */
    int STEP_EXTS = STEP_STT + 1;
    /** 下一步：选择国别 */
    int STEP_NATN = STEP_EXTS + 1;
    /** 下一步：选择公司 */
    int STEP_CORP = STEP_NATN + 1;
    /** 下一步：选择软件 */
    int STEP_SOFT = STEP_CORP + 1;
    /** 下一步：选择文件 */
    int STEP_FILE = STEP_SOFT + 1;
    /** 下一步：选择类别 */
    int STEP_TYPE = STEP_FILE + 1;
    /** 下一步：选择人员 */
    int STEP_IDIO = STEP_TYPE + 1;
    /** 下一步：选择平台 */
    int STEP_PLAT = STEP_IDIO + 1;
    /** 下一步：选择架构 */
    int STEP_ARCH = STEP_PLAT + 1;
    /** 下一步：输入附注 */
    int STEP_MARK = STEP_ARCH + 1;
    /** 下一步：添加成功 */
    int STEP_END = STEP_MARK + 1;
}
