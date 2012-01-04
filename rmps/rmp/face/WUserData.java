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
public abstract class WUserData implements WData
{
    /** 检查结果是否合法：true表示数据合法；false表示数据不合法 */
    protected boolean validate = false;
    /** 错误描述信息 */
    protected String errMsg = null;
    /** 数据库对当前数据的操作是为更新操作：true表示数据更新；false表示数据新增。 */
    private boolean isUpdate = false;

    /**
     * 用户数据到合法的数据库数据的转换
     */
    public abstract boolean t2db();

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
     * 用户输入数据的合法性检查。
     * 
     * @return 数据检查结果：true表示数据合法；false表示数据不合法。
     */
    public boolean isValidate()
    {
        return validate;
    }

    /**
     * @return
     */
    public boolean isUpdate()
    {
        return isUpdate;
    }

    /**
     * @param isUpdate
     */
    public void setUpdate(boolean isUpdate)
    {
        this.isUpdate = isUpdate;
    }

    /**
     * @return the errMsg
     */
    public String getErrMsg()
    {
        return errMsg;
    }

    @Override
    public int wCode()
    {
        return 0;
    }
}
