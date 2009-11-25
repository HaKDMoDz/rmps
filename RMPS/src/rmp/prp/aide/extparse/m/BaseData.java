/*
 * FileName:       BaseData.java
 * CreateDate:     2007-9-3 下午08:07:45
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.m;

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
 * 日期： 2007-9-3 下午08:07:45
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class BaseData extends WBaseData
{
    /** 后缀索引 */
    private String extsIndx;
    /** 后缀名称 */
    private String extsName;
    /** 软件索引 */
    private String softIndx;
    /** 软件名称 */
    private String softName;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        this.extsIndx = ConstUI.DEF_EXTSHASH;
        this.extsName = "";
        this.softIndx = ConstUI.DEF_SOFTHASH;
        this.softName = "";

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#toString()
     */
    public String toString()
    {
        return "(" + extsName + ") " + softName;
    }

    /**
     * @return the extsName
     */
    public String getExtsName()
    {
        return extsName;
    }

    /**
     * @param extsName the extsName to set
     */
    public void setExtsName(String extsName)
    {
        this.extsName = extsName;
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
     * @return the extsIndx
     */
    public String getExtsIndx()
    {
        return extsIndx;
    }

    /**
     * @param extsIndx the extsIndx to set
     */
    public void setExtsIndx(String extsIndx)
    {
        this.extsIndx = extsIndx;
    }

}
