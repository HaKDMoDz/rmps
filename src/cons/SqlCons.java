/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public interface SqlCons
{
    // -----------------------------------------------------
    // 数据库驱动
    // -----------------------------------------------------
    /** HSQLDB 用JDBC连接驱动 */
    String DBCS_JDBC_DRV = "org.hsqldb.jdbcDriver";
    /** HSQLDB 用FILE文件数据库 */
    String DBCS_CONN_STR = "jdbc:hsqldb:file:";
    // -----------------------------------------------------
    // 数据库常量数据(DataBase Const String)
    // -----------------------------------------------------
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
}
