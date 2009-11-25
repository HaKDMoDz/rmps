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
public class DespUserData extends WUserData
{
    /** 描述索引 */
    private String despIndx;
    /** 语言索引 */
    private String langIndx;
    /** 描述内容 */
    private String extsDesp;
    /** 个人说明 */
    private String idioMark;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        this.despIndx = ConstUI.DEF_DESPHASH;
        this.langIndx = ConstUI.DEF_DESPLANG;
        this.extsDesp = "";
        this.idioMark = "";

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
        extsDesp = StringUtil.toDBText(extsDesp);
        idioMark = StringUtil.toDBText(idioMark);

        return true;
    }

    /**
     * @return the despIndx
     */
    public String getDespIndx()
    {
        return despIndx;
    }

    /**
     * @param despIndx the despIndx to set
     */
    public boolean setDespIndx(String despIndx)
    {
        this.despIndx = despIndx;
        return true;
    }

    /**
     * @return the extsDesp
     */
    public String getExtsDesp()
    {
        return extsDesp;
    }

    /**
     * @param extsDesp the extsDesp to set
     */
    public boolean setExtsDesp(String extsDesp)
    {
        validate = CheckUtil.isValidateLength(extsDesp, DB0008.DESPDATA_EXTSDESP_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.DESP_COMN_TEXT_EXTSDESP, "" + DB0008.DESPDATA_EXTSDESP_SIZE);
            return false;
        }

        this.extsDesp = extsDesp;
        return true;
    }

    /**
     * @return the idioMark
     */
    public String getIdioMark()
    {
        return idioMark;
    }

    /**
     * @param idioMark the idioMark to set
     */
    public boolean setIdioMark(String idioMark)
    {
        validate = CheckUtil.isValidateLength(extsDesp, DB0008.DESPDATA_IDIOMARK_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, "LangRes.TEXT_EXTSDESP", "" + DB0008.DESPDATA_IDIOMARK_SIZE);
            return false;
        }

        this.idioMark = idioMark;
        return true;
    }

    /**
     * @return the langIndx
     */
    public String getLangIndx()
    {
        return langIndx;
    }

    /**
     * @param langIndx the langIndx to set
     */
    public boolean setLangIndx(String langIndx)
    {
        this.langIndx = langIndx;
        return true;
    }
}
