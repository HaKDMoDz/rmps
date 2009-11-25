/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.m;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import rmp.bean.K1SV2S;
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
public class AsocBaseData extends WBaseData
{
    /** 特别后缀索引 */
    private String asocIndx;
    /** 备选软件列表 */
    private List<K1SV2S> asocList;
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
        this.asocIndx = ConstUI.DEF_ASOCHASH;
        asocList = new ArrayList<K1SV2S>();

        return true;
    }

    /**
     * @return the asocIndx
     */
    public String getAsocIndx()
    {
        return asocIndx;
    }

    /**
     * @param asocIndx the asocIndx to set
     */
    public void setAsocIndx(String asocIndx)
    {
        this.asocIndx = asocIndx;
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

    /**
     * @return
     */
    public List<K1SV2S> getAsocList()
    {
        return this.asocList;
    }

    /**
     * @param asocList
     */
    public void setAsocList(List<K1SV2S> asocList)
    {
        this.asocList = asocList;
    }

    /**
     * @return the softIndx
     */
    public String getSoftIndx(int index)
    {
        return asocList.get(index).getK();
    }

    /**
     * @param index
     * @return
     */
    public String getSoftName(int index)
    {
        return asocList.get(index).getV1();
    }

    /**
     * @param index
     * @return
     */
    public String getAsocDesp(int index)
    {
        return asocList.get(index).getV2();
    }

    /**
     * @param kvItem
     */
    public void addAsocSoft(K1SV2S kvItem)
    {
        addAsocSoft(kvItem, asocList.size());
    }

    /**
     * @param kvItem
     * @param index
     */
    public void addAsocSoft(K1SV2S kvItem, int index)
    {
        asocList.add(index, kvItem);
    }

    /**
     * @return the softName
     */
    public void setAsocSoft(K1SV2S kvItem, int index)
    {
        asocList.set(index, kvItem);
    }
}
