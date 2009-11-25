/*
 * FileName:       DespBaseData.java
 * CreateDate:     Jul 4, 2007 2:37:33 PM
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
 * 日期： Jul 4, 2007 2:37:33 PM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class DespBaseData extends WBaseData
{
    /** 描述索引 */
    private String despIndx;
    /** 语言索引 */
    private String langIndx;
    /** 描述内容 */
    private String extsDesp;
    /** 个人说明 */
    private String idioMark;
    /** 更新日期 */
    private Date   updtDate;
    /** 创建日期 */
    private Date   makeDate;

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
    public void setDespIndx(String despIndx)
    {
        this.despIndx = despIndx;
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
    public void setExtsDesp(String extsDesp)
    {
        this.extsDesp = extsDesp;
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
    public void setIdioMark(String idioMark)
    {
        this.idioMark = idioMark;
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
    public void setLangIndx(String langIndx)
    {
        this.langIndx = langIndx;
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
}
