/*
 * FileName:       NatnBaseData.java
 * CreateDate:     2007-9-4 上午07:32:10
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
 * 日期： 2007-9-4 上午07:32:10
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class NatnBaseData extends WBaseData
{
    /** 国别索引 */
    private String natnIndx;
    /** 本语全称 */
    private String natnFlNm;
    /** 本语简称 */
    private String natnSlNm;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    @ Override
    public boolean wInit()
    {
        natnIndx = ConstUI.DEF_NATNHASH;
        natnFlNm = "";
        natnSlNm = "";

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
    public void setNatnIndx(String natnIndx)
    {
        this.natnIndx = natnIndx;
    }

    /**
     * @return the natnFlNm
     */
    public String getNatnFlNm()
    {
        return natnFlNm;
    }

    /**
     * @param natnFlNm the natnFlNm to set
     */
    public void setNatnFlNm(String natnFlNm)
    {
        this.natnFlNm = natnFlNm;
    }

    /**
     * @return the natnSlNm
     */
    public String getNatnSlNm()
    {
        return natnSlNm;
    }

    /**
     * @param natnSlNm the natnSlNm to set
     */
    public void setNatnSlNm(String natnSlNm)
    {
        this.natnSlNm = natnSlNm;
    }

}
