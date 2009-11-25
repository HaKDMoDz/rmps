/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.imp.v.fetion;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
class IDataType
{
    public static final int N_NULL = 0;
    public static final int N_GetPersonalInfo = 1;
    public static final int N_GetContactList = 2;
    public static final int N_GetContactsInfo = 3;
    public static final int N_SubPresence = 4;
    public static final int N_SendMsg = 5;
    public static final int N_SetPersonalInfo = 6;
    public int NType = 0;
    public int seq = 1;

    public IDataType(int type)
    {
        this.NType = type;
    }
}
