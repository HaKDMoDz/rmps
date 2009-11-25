/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.m;

import rmp.face.WUserData;
import rmp.util.CheckUtil;
import rmp.util.StringUtil;
import cons.prp.aide.P3010000.ConstUI;
import cons.prp.aide.P3010000.LangRes;
import cons.prp.aide.extparse.DB0008;

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
public class CorpUserData extends WUserData
{
    /** 公司索引 */
    private String corpIndx;
    /** 国别信息 */
    private String natnIndx;
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

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        this.corpIndx = ConstUI.DEF_CORPHASH;
        this.natnIndx = "0";
        this.corpLogo = ConstUI.DEF_CORPICON;
        this.corpLcNm = "";
        this.corpEnNm = "";
        this.corpSite = "";
        this.corpDesp = "";

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
        corpLcNm = StringUtil.toDBText(corpLcNm);
        corpEnNm = StringUtil.toDBText(corpEnNm);
        corpSite = StringUtil.toDBText(corpSite);
        corpDesp = StringUtil.toDBText(corpDesp);
        return true;
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
    public boolean setCorpDesp(String corpDesp)
    {
        validate = CheckUtil.isValidateLength(corpDesp, DB0008.CORPDATA_CORPDESP_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.CORP_COMN_TEXT_CORPDESP, "" + DB0008.CORPDATA_CORPDESP_SIZE);
            return false;
        }
        this.corpDesp = corpDesp;
        return true;
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
    public boolean setCorpEnNm(String corpEnNm)
    {
        validate = CheckUtil.isValidateLength(corpEnNm, DB0008.CORPDATA_CORPENNM_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.CORP_COMN_TEXT_CORPENNM, "" + DB0008.CORPDATA_CORPENNM_SIZE);
            return false;
        }
        this.corpEnNm = corpEnNm;
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
     * @return the corpLcNm
     */
    public String getCorpLcNm()
    {
        return corpLcNm;
    }

    /**
     * @param corpLcNm the corpLcNm to set
     */
    public boolean setCorpLcNm(String corpLcNm)
    {
        validate = CheckUtil.isValidate(corpLcNm);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0001, LangRes.CORP_COMN_TEXT_CORPLCNM);
            return false;
        }

        validate = CheckUtil.isValidateLength(corpLcNm, DB0008.CORPDATA_CORPLCNM_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.CORP_COMN_TEXT_CORPLCNM, "" + DB0008.CORPDATA_CORPLCNM_SIZE);
            return false;
        }
        this.corpLcNm = corpLcNm;
        return true;
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
    public boolean setCorpLogo(String corpLogo)
    {
        this.corpLogo = corpLogo;
        return true;
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
    public boolean setCorpSite(String corpSite)
    {
        validate = CheckUtil.isValidateUrl(corpSite);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0004, LangRes.CORP_COMN_TEXT_CORPSITE);
            return false;
        }

        validate = CheckUtil.isValidateLength(corpSite, DB0008.CORPDATA_CORPSITE_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.CORP_COMN_TEXT_CORPSITE, "" + DB0008.CORPDATA_CORPSITE_SIZE);
            return false;
        }

        this.corpSite = corpSite;
        return true;
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
    public boolean setNatnIndx(String natnIndx)
    {
        this.natnIndx = natnIndx;
        return true;
    }
}
