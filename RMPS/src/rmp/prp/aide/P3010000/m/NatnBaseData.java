/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.m;

import rmp.face.WBaseData;
import cons.prp.aide.P3010000.ConstUI;

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
    @Override
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
