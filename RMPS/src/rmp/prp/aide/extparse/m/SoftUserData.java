/*
 * FileName:       SoftUserData.java
 * CreateDate:     Jul 4, 2007 2:43:02 PM
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.m;

import rmp.face.WUserData;
import rmp.util.CheckUtil;
import rmp.util.StringUtil;
import cons.prp.aide.extparse.ConstUI;
import cons.prp.aide.extparse.DB0008;
import cons.prp.aide.extparse.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br>
 * TODO: 使用说明
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： Jul 4, 2007 2:43:02 PM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class SoftUserData extends WUserData
{
    /** 软件索引 */
    private String softIndx;
    /** 公司索引 */
    private String corpIndx;
    /** 软件图标 */
    private String softIcon;
    /** 软件名称 */
    private String softName;
    /** 服务邮件 */
    private String softMail;
    /** 链接地址 */
    private String softSite;
    /** 支持格式 */
    private String extsList;
    /** 相关说明 */
    private String softDesp;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        this.softIndx = ConstUI.DEF_SOFTHASH;
        this.corpIndx = ConstUI.DEF_CORPHASH;
        this.softIcon = ConstUI.DEF_SOFTICON;
        this.softName = "";
        this.softMail = "";
        this.softSite = "";
        this.extsList = "";
        this.softDesp = "";

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WUserData#t2db()
     */
    @ Override
    public boolean t2db()
    {
        softName = StringUtil.toDBText(softName);
        softMail = StringUtil.toDBText(softMail);
        softSite = StringUtil.toDBText(softSite);
        extsList = StringUtil.toDBText(extsList);
        softDesp = StringUtil.toDBText(softDesp);

        return true;
    }

    /**
     * @return the corpIndx
     */
    public String getCorpIndx()
    {
        return corpIndx;
    }

    /**
     * @param corpIndx the corpIndx to set
     */
    public boolean setCorpIndx(String corpIndx)
    {
        this.corpIndx = corpIndx;
        return true;
    }

    /**
     * @return the extsList
     */
    public String getExtsList()
    {
        return extsList;
    }

    /**
     * @param extsList the extsList to set
     */
    public boolean setExtsList(String extsList)
    {
        validate = CheckUtil.isValidateLength(extsList, DB0008.SOFTDATA_EXTSLIST_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.SOFT_COMN_TEXT_SOFTEXTS, ""
                + DB0008.SOFTDATA_EXTSLIST_SIZE);
            return false;
        }
        this.extsList = extsList;
        return true;
    }

    /**
     * @return the softDesp
     */
    public String getSoftDesp()
    {
        return softDesp;
    }

    /**
     * @param softDesp the softDesp to set
     */
    public boolean setSoftDesp(String softDesp)
    {
        validate = CheckUtil.isValidateLength(softDesp, DB0008.SOFTDATA_SOFTDESP_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.SOFT_COMN_TEXT_SOFTDESP, ""
                + DB0008.SOFTDATA_SOFTDESP_SIZE);
            return false;
        }
        this.softDesp = softDesp;
        return true;
    }

    /**
     * @return the softIcon
     */
    public String getSoftIcon()
    {
        return softIcon;
    }

    /**
     * @param softIcon the softIcon to set
     */
    public boolean setSoftIcon(String softIcon)
    {
        this.softIcon = softIcon;
        return true;
    }

    /**
     * @return the softIndx
     */
    public String getSoftIndx()
    {
        return softIndx;
    }

    /**
     * @param softIndx the softIndx to set
     */
    public boolean setSoftIndx(String softIndx)
    {
        this.softIndx = softIndx;
        return true;
    }

    /**
     * @return the softMail
     */
    public String getSoftMail()
    {
        return softMail;
    }

    /**
     * @param softMail the softMail to set
     */
    public boolean setSoftMail(String softMail)
    {
        // 邮件格式检查
        validate = CheckUtil.isValidateMail(softMail);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0003, "LangRes.TEXT_SOFTMAIL");
            return false;
        }

        // 长度信息判断
        validate = CheckUtil.isValidateLength(softMail, DB0008.SOFTDATA_SOFTMAIL_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, "LangRes.TEXT_SOFTMAIL", ""
                + DB0008.SOFTDATA_SOFTMAIL_SIZE);
            return false;
        }

        this.softMail = softMail;
        return true;
    }

    /**
     * @return the softName
     */
    public String getSoftName()
    {
        return softName;
    }

    /**
     * @param softName the softName to set
     */
    public boolean setSoftName(String softName)
    {
        softName = softName.trim();

        validate = CheckUtil.isValidate(softName);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0001, LangRes.SOFT_COMN_TEXT_SOFTNAME);
            return false;
        }

        validate = CheckUtil.isValidateLength(softName, DB0008.SOFTDATA_SOFTNAME_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, "LangRes.TEXT_SOFTNAME", ""
                + DB0008.SOFTDATA_SOFTNAME_SIZE);
            return false;
        }
        this.softName = softName;
        return true;
    }

    /**
     * @return the softSite
     */
    public String getSoftSite()
    {
        return softSite;
    }

    /**
     * @param softSite the softSite to set
     */
    public boolean setSoftSite(String softSite)
    {
        // 链接地址检测
        validate = CheckUtil.isValidateUrl(softSite);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0004, LangRes.SOFT_COMN_TEXT_SOFTSITE);
            return false;
        }

        // 文本长度检测
        validate = CheckUtil.isValidateLength(softSite, DB0008.SOFTDATA_SOFTSITE_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.SOFT_COMN_TEXT_SOFTSITE, ""
                + DB0008.SOFTDATA_SOFTSITE_SIZE);
            return false;
        }

        this.softSite = softSite;
        return true;
    }
}
