/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
/*
 * 
 */
package rmp.irp.m.I2070000;

import com.amonsoft.rmps.irp.b.IProcess;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 * 
 */
public interface Constant
{
    String OPT_SEARCH = "q";
    String OPT_SELECT = "l";
    String OPT_APPEND = "a";
    String OPT_REMOVE = "r";
    String OPT_DETAIL = "i";

    String ITEM_SEARCH = "0";
    String ITEM_SELECT = "1";
    String ITEM_APPEND = "2";
    String ITEM_UPDATE = "3";
    String ITEM_DETAIL = "4";

    int STEP_CONFIG = 1;

    int STEP_APPEND_LINK = IProcess.STEP_DEFAULT;
    int STEP_APPEND_NAME = STEP_APPEND_LINK + 1;

    /**
     * 显示配置
     */
    String SESSION_SHOWMENU = "_m";
    /**
     * 数据管理菜单（搜索/查看模式、添加类别、添加链接等）
     */
    String SESSION_MENU_SUB = "1";
    /**
     * 数据操作菜单（编辑、删除、复制、移动、返回等）
     */
    String SESSION_MENU_MGR = "2";

    /**
     * 链接搜索：数据列表
     */
    String SESSION_ITEMLIST_K = "_i";
    /**
     * 级联查询：类别列表
     */
    String SESSION_KINDLIST_K = "_k";
    /**
     * 级联查询：链接列表
     */
    String SESSION_LINKLIST_K = "_l";
    /**
     * 级联查询：上级类别索引
     */
    String SESSION_KINDHASH_K = "_h";
    /**
     * 新增数据：类别名称
     */
    String SESSION_KINDNAME_K = "_c";
    /**
     * 新增数据：链接地址
     */
    String SESSION_LINKPATH_K = "_u";
    /**
     * 新增数据：链接名称
     */
    String SESSION_LINKNAME_K = "_n";
}
