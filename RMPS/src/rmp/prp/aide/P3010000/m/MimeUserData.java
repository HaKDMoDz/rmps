/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.m;

import rmp.face.WUserData;
import rmp.prp.aide.extparse.Extparse;
import rmp.util.CheckUtil;
import rmp.util.StringUtil;
import cons.prp.aide.P3010000.ConstUI;
import cons.prp.aide.P3010000.LangRes;

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
public class MimeUserData extends WUserData
{
    /** MIME数据索引 */
    private String mimeIndx;
    /** MIME类型索引 */
    private String mimeType;
    /** MIME类型名称 */
    private String mimeName;
    /** MIME类型说明 */
    private String mimeDesp;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        mimeType = ConstUI.DEF_MIMEHASH;
        mimeName = "";
        mimeDesp = "";

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WUserData#t2db()
     */
    @Override
    public boolean t2db()
    {
        mimeName = StringUtil.toDBText(mimeName);
        mimeDesp = StringUtil.toDBText(mimeDesp);

        return true;
    }

    /**
     * @return the mimeDesp
     */
    public String getMimeDesp()
    {
        return mimeDesp;
    }

    /**
     * @param mimeDesp the mimeDesp to set
     */
    public boolean setMimeDesp(String mimeDesp)
    {
        this.mimeDesp = mimeDesp;
        return true;
    }

    /**
     * @return the mimeIndx
     */
    public String getMimeIndx()
    {
        return mimeIndx;
    }

    /**
     * @param mimeIndx the mimeIndx to set
     */
    public void setMimeIndx(String mimeIndx)
    {
        this.mimeIndx = mimeIndx;
    }

    /**
     * @return the mimeName
     */
    public String getMimeName()
    {
        return mimeName;
    }

    /**
     * @param mimeName the mimeName to set
     */
    public boolean setMimeName(String mimeName)
    {
        validate = CheckUtil.isValidate(mimeName);
        if (!validate)
        {
            errMsg = Extparse.getMesg(LangRes.MIME_MESG_CHCK_0001);
            return false;
        }
        this.mimeName = mimeName;
        return true;
    }

    /**
     * @return the mimeType
     */
    public String getMimeType()
    {
        return mimeType;
    }

    /**
     * @param mimeType the mimeType to set
     */
    public boolean setMimeType(String mimeType)
    {
        this.mimeType = mimeType;
        return true;
    }
}
