/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.comn.amon.data.A2010000;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public interface ConstUI
{
    String HSQLDB_KEY = "HSQLDB";
    String HSQLDB_DRV = "org.hsqldb.jdbcDriver";
    String HSQLDB_URL = "jdbc:hsqldb:file:{0}";
    String ACCESS_KEY = "Access";
    String ACCESS_DRV = "sun.jdbc.odbc.JdbcOdbcDriver";
    String ACCESS_URL = "jdbc:odbc:Driver={Microsoft Access Driver (*.mdb)};DBQ={0}";
    String ORACLE_KEY = "Oracle";
    String ORACLE_DRV = "oracle.jdbc.driver.OracleDriver";
    String ORACLE_URL = "jdbc:oracle:thin:@{0}:{1}:{2}";
    String MYSQL_KEY = "MySQL";
    String MYSQL_DRV = "";
    String MYSQL_URL = "";
    String MSSQL_KEY = "MS SQL";
    String MSSQL_DRV = "";
    String MSSQL_URL = "";
    String DB2_KEY = "DB2";
    String DB2_DRV = "com.ibm.db2.jdbc.app.DB2Driver";
    String DB2_URL = "jdbc:db2://{0}:{1}/{2}";
    String DBCD_IS_PRIMARY_KEY = "1";
    String DBCD_IS_NOT_NULL = "0";
    String DBCD_IS_UNIQUE = "1";
}
