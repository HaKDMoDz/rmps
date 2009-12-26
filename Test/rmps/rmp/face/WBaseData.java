/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.face;

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
public abstract class WBaseData implements WData
{
    /** 符合条件的数据是否存在 */
    private boolean metaExist = false;

    /**
     * 重新设置数据库数据的初始状态
     * 
     * @return 重设是否成功:true表示成功
     */
    public boolean reset()
    {
        return wInit();
    }

    /**
     * @return the metaExist
     */
    public boolean isMetaExist()
    {
        return metaExist;
    }

    /**
     * @param metaExist
     *            the metaExist to set
     */
    public void setMetaExist(boolean metaExist)
    {
        this.metaExist = metaExist;
    }

    @Override
    public int wCode()
    {
        return 0;
    }
}
