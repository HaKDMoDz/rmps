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
    String URI_DEFAULT = "";

    String OPT_SEARCH = "q";
    String OPT_SELECT = "l";
    String OPT_APPEND = "a";
    String OPT_REMOVE = "r";
    String OPT_DETAIL = "d";

    String ITEM_SEARCH = "0";
    String ITEM_SELECT = "1";

    int EDIT_DEFAULT = 0;
    int EDIT_APPEND_KIND = 1;
    int EDIT_APPEND_LINK = 2;
    int EDIT_UPDATE = 3;
    int EDIT_DELETE = 4;
    int EDIT_DETAIL = 5;

    int STEP_APPEND_KIND = IProcess.STEP_DEFAULT;
    int STEP_APPEND_LINK = STEP_APPEND_KIND + 1;
    int STEP_APPEND_NAME = STEP_APPEND_LINK + 1;

    /**
     * 不显示菜单
     */
    int MENU_NONE = 0;
    /**
     * 模式选择菜单（搜索/查看模式等）
     */
    int MENU_MODE = 1;
    /**
     * 数据搜索菜单（目录模式）
     */
    int MENU_SRCH = 2;
    /**
     * 数据查看菜单（搜索模式、新增类别、新增链接）
     */
    int MENU_LIST = 3;
    /**
     * 数据管理菜单（编辑、删除、复制、移动、返回等）
     */
    int MENU_EIDT = 4;

    /**
     * 流程控制对象
     */
    String SESSION_PROFILES = "_p";

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
