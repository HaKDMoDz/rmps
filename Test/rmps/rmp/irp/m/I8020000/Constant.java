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
package rmp.irp.m.I8020000;

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
    /**
     * 支持的验证方法：test
     */
    String MATCHER_TEST = "test";
    /**
     * 支持的验证方法：match
     */
    String MATCHER_MATCH = "match";
    /**
     * 支持的验证方法：split
     */
    String MATCHER_SPLIT = "split";
    /**
     * 支持的验证方法：search
     */
    String MATCHER_SEARCH = "search";
    /**
     * 支持的验证方法：replace
     */
    String MATCHER_REPLACE = "replace";

    /**
     * 会话保存变量：匹配模式
     */
    String SESSION_PATTERN = "_p";
    /**
     * 会话保存变量：验证方式
     */
    String SESSION_MATCHER = "_m";
    /**
     * 会话保存变量：验证数据
     */
    String SESSION_CHARSET = "_c";

    /**
     * 操作步骤：输入匹配模式
     */
    int STEP_PATTERN = 1;
    /**
     * 操作步骤：选择验证方式
     */
    int STEP_MATCHER = 2;
    /**
     * 操作步骤：单验证数据
     */
    int STEP_CHARONE = 3;
    /**
     * 操作步骤：多验证数据
     */
    int STEP_CHARSET = 4;
}
