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
package rmp.irp.v.fetion;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Administrator
 * 
 */
public interface Constant
{
    int LOGIN_SUCC = 0;
    int LOGIN_CONN_ERROR = 1;
    int LOGIN_DATAIO_ERROR = 2;
    int LOGIN_FAILED = 3;

    String VER_FETION = "2.3.0210";

    String ENV_BREAKS = "\r\n";

    String N_NULL = "0";
    String N_GetPersonalInfo = "1";
    String N_GetContactList = "2";
    String N_GetContactsInfo = "3";
    String N_SubPresence = "4";
    String N_SendMsg = "5";
    String N_SetPersonalInfo = "6";

    String CNONCE = "7036EA07568E7C4D6D49FD76141062FE";
}
