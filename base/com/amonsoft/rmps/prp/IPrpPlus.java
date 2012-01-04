/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package com.amonsoft.rmps.prp;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * Amon系统标准插件接口
 * <li>使用说明：</li>
 * <br />
 * 每一个应用程序模块都应使用其主程序接口实现此方法，以提供有关此程序的一些基本信息及控制程序的启动与退出。<br />
 * 但主程序接口并不负责界面的布局管理与事件处理等。<br />
 * 
 * <pre>
 * 另：
 * 1）、在每一个主程序接口中，均应默认提供一个方法：public static String getMesg(String mesgId);
 *     此方法用于获取针对每一个应用程序的语言资源信息。
 * 2）、每一个主程序init()启动方法中，应首先处理语言资源信息，以实现程序的本地化。
 * </pre>
 * 
 * </ul>
 * 
 * @author Amon
 */
public interface IPrpPlus
{
    /**
     * 界面布局初始化
     * 
     * @return
     */
    boolean wInitView();

    /**
     * 界面语言初始化
     * 
     * @return
     */
    boolean wInitLang();

    /**
     * 界面数据初始化
     * 
     * @return
     */
    boolean wInitData();

    /**
     * 
     * @return
     */
    int wCode();

    /**
     * 当前系统的代码编码名称
     * 
     * @return 当前系统的代码编码名称
     */
    String wGetName();

    /**
     * 当前系统的显示名称信息
     * 
     * @return 当前系统的名称信息
     */
    String wGetTitle();

    /**
     * 当前系统的Logo图标
     * 
     * @param type
     *            图标文件类型
     * @return
     */
    java.awt.image.BufferedImage wGetIconImage(int type);

    int ICON_LOGO0016 = 0;
    int ICON_LOGO0032 = 1;
    int ICON_LOGO0048 = 2;
    int ICON_LOGO0096 = 3;
    int ICON_LOGO0128 = 4;
    int ICON_LOGO0256 = 5;

    /**
     * 当前系统的简短描述信息
     * 
     * @return
     */
    String wGetDescription();

    /**
     * 当前系统的版本信息
     * 
     * @return 当前系统的版本信息
     */
    String wGetVersion();

    /**
     * 初始化软件快捷式弹出菜单 <br />
     * 说明：系统会在用户每次事件过程中调用一次此方法，以响应不同的用户事件
     * 
     * @param menu
     * @return 菜单初始化结果，系统根据此返回值来决定快捷菜单是否需要显示
     */
    boolean wShowMenu(javax.swing.JMenu menu);

    /**
     * 初始化内嵌式快捷面板 <br />
     * 说明：系统会在用户每次事件过程中调用一次此方法，以响应不同的用户事件
     * 
     * @param view
     * @return
     */
    boolean wShowTail(javax.swing.JPanel view);

    /**
     * 当前系统的网络首页
     * 
     * @return
     */
    String wGetHomepage();

    /**
     * 显示软件帮助信息
     */
    void wShowHelp();

    /**
     * 显示关于软件信息
     */
    void wShowInfo();

    /**
     * 显示软件指定的模式状态，如查寻、新增、更新、删除或者迷你、普通、高级等模式，以供有选择的响应外部调用。
     * 
     * @param modelIdx
     *            要显示的模式状态标记ID，{@link cons.SysCons}
     */
    javax.swing.JPanel wShowView(int modelIdx);

    /** 内嵌面板 */
    int VIEW_TAIL = 0;
    /** 迷你面板 */
    int VIEW_MINI = VIEW_TAIL + 1;
    /** 正常面板 */
    int VIEW_NORM = VIEW_MINI + 1;
    /** 高级面板 */
    int VIEW_MAIN = VIEW_NORM + 1;
    /** 向导面板 */
    int VIEW_STEP = VIEW_MAIN + 1;

    /**
     * 销毁当前构件所占用的内在空间
     * 
     * @return 内在空间是否正常释放：true释放正常；false释放异常
     */
    boolean wClosing();

    /**
     * @return TODO
     */
    boolean wIconified();

    /**
     * @return TODO
     */
    boolean wDeiconified();

    /**
     * 获取RMPS系统运行目录
     */
    String wGetBaseFolder();

    /**
     * 设置RMPS系统运行目录
     * 
     * @param folder
     */
    void wSetBaseFolder(String folder);

    /**
     * 获取插件程序运行目录
     * 
     * @return
     */
    String wGetPlusFolder();

    /**
     * 设置插件程序运行目录
     * 
     * @param folder
     */
    void wSetPlusFolder(String folder);
}
