/*
 * FileName:       SoftBaseData.java
 * CreateDate:     Jul 4, 2007 2:42:33 PM
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.m;

import java.util.Date;

import rmp.face.WBaseData;
import cons.prp.aide.extparse.ConstUI;

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
 * 日期： Jul 4, 2007 2:42:33 PM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class SoftBaseData extends WBaseData
{
    /** 软件索引 */
    private String softIndx;
    /** 公司索引 */
    private String corpIndx;
    /** 公司名称 */
    private String corpName;
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
    /** 更新时间 */
    private Date   updtDate;
    /** 提交日期 */
    private Date   makeDate;

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
    public void setCorpIndx(String corpIndx)
    {
        this.corpIndx = corpIndx;
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
    public void setExtsList(String extsList)
    {
        this.extsList = extsList;
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
    public void setSoftDesp(String softDesp)
    {
        this.softDesp = softDesp;
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
    public void setSoftIcon(String softIcon)
    {
        this.softIcon = softIcon;
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
    public void setSoftIndx(String softIndx)
    {
        this.softIndx = softIndx;
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
    public void setSoftMail(String softMail)
    {
        this.softMail = softMail;
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
    public void setSoftName(String softName)
    {
        this.softName = softName;
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
    public void setSoftSite(String softSite)
    {
        this.softSite = softSite;
    }

    /**
     * @return the updtDate
     */
    public Date getUpdtDate()
    {
        return updtDate;
    }

    /**
     * @param updtDate the updtDate to set
     */
    public void setUpdtDate(Date updtDate)
    {
        this.updtDate = updtDate;
    }

    /**
     * @return the corpName
     */
    public String getCorpName()
    {
        return corpName;
    }

    /**
     * @param corpName the corpName to set
     */
    public void setCorpName(String corpName)
    {
        this.corpName = corpName;
    }

    /**
     * @return the makeDate
     */
    public Date getMakeDate()
    {
        return makeDate;
    }

    /**
     * @param makeDate the makeDate to set
     */
    public void setMakeDate(Date makeDate)
    {
        this.makeDate = makeDate;
    }
}
