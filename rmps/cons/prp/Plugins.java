/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public interface Plugins
{
    /** 根节点 */
    String ROOT_NAME = "plugin";
    /** 插件ID */
    String ATTR_ID = "id";
    /** 程序类型 */
    String ATTR_TYPE = "type";
    // ----------------------------------------------------
    // 插件程序节点
    // ----------------------------------------------------
    /** 插件根节点 */
    String NODE_PLUS = "plus";
    /** 插件从属模块 */
    String NODE_PLUS_PART = "part";
    /** 插件主程序路径 */
    String NODE_PLUS_PATH = "path";
    /** 插件实现接口 */
    String NODE_PLUS_IMPLEMENTATION = "implementation";
    /** 插件继承的类 */
    String NODE_PLUS_EXTENSION = "extension";
    // ----------------------------------------------------
    // 独立程序节点
    // ----------------------------------------------------
    /** 程序根节点 */
    String NODE_EXEC = "exec";
    /** 程序图标 */
    String NODE_EXEC_ICON = "icon";
    /** 程序名称 */
    String NODE_EXEC_NAME = "name";
    /** 程序说明 */
    String NODE_EXEC_DESCRIPTION = "description";
    /** 执行主程序 */
    String NODE_EXEC_EXECUTION = "execution";
    /** 启动参数 */
    String NODE_EXEC_PARAMETER = "parameter";
    // ----------------------------------------------------
    // 网络程序节点
    // ----------------------------------------------------
    /** 程序根节点 */
    String NODE_JNLP = "jnlp";
    /** 文件路径 */
    String NODE_JNLP_HREF = "href";
    /** 程序图标 */
    String NODE_JNLP_ICON = "icon";
    /** 程序名称 */
    String NODE_JNLP_NAME = "name";
    /** 显示标题 */
    String NODE_JNLP_TITLE = "title";
    /** 软件厂商 */
    String NODE_JNLP_VENDOR = "vendor";
    /** 程序说明 */
    String NODE_JNLP_DESCRIPTION = "description";
    // ----------------------------------------------------
    // 类库节点
    // ----------------------------------------------------
    String NODE_LIBS = "libs";
    String NODE_LIBS_LIB = "lib";
}
