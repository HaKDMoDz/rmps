/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.m;

import java.util.Date;

import rmp.face.WBaseData;

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
public class CorpBaseData extends WBaseData
{
    /** 公司索引 */
    private String corpIndx;
    /** 国别信息 */
    private String natnIndx;
    /** 国别名称 */
    private String natnName;
    /** 公司徽标 */
    private String corpLogo;
    /** 本语名称 */
    private String corpLcNm;
    /** 英文名称 */
    private String corpEnNm;
    /** 公司网址 */
    private String corpSite;
    /** 公司描述 */
    private String corpDesp;
    /** 更新日期 */
    private Date updtDate;
    /** 提交日期 */
    private Date makeDate;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        // AMON Auto-generated method stub
        return false;
    }

    /**
     * @return the corpDesp
     */
    public String getCorpDesp()
    {
        return corpDesp;
    }

    /**
     * @param corpDesp the corpDesp to set
     */
    public void setCorpDesp(String corpDesp)
    {
        this.corpDesp = corpDesp;
    }

    /**
     * @return the corpEnNm
     */
    public String getCorpEnNm()
    {
        return corpEnNm;
    }

    /**
     * @param corpEnNm the corpEnNm to set
     */
    public void setCorpEnNm(String corpEnNm)
    {
        this.corpEnNm = corpEnNm;
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
     * @return the corpLcNm
     */
    public String getCorpLcNm()
    {
        return corpLcNm;
    }

    /**
     * @param corpLcNm the corpLcNm to set
     */
    public void setCorpLcNm(String corpLcNm)
    {
        this.corpLcNm = corpLcNm;
    }

    /**
     * @return the corpLogo
     */
    public String getCorpLogo()
    {
        return corpLogo;
    }

    /**
     * @param corpLogo the corpLogo to set
     */
    public void setCorpLogo(String corpLogo)
    {
        this.corpLogo = corpLogo;
    }

    /**
     * @return the corpSite
     */
    public String getCorpSite()
    {
        return corpSite;
    }

    /**
     * @param corpSite the corpSite to set
     */
    public void setCorpSite(String corpSite)
    {
        this.corpSite = corpSite;
    }

    /**
     * @return the natnIndx
     */
    public String getNatnIndx()
    {
        return natnIndx;
    }

    /**
     * @param natnIndx the natnIndx to set
     */
    public void setNatnIndx(String natnIndx)
    {
        this.natnIndx = natnIndx;
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
     * @return the natnName
     */
    public String getNatnName()
    {
        return natnName;
    }

    /**
     * @param natnName the natnName to set
     */
    public void setNatnName(String natnName)
    {
        this.natnName = natnName;
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
