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
public class MimeBaseData extends WBaseData
{
    /** MIME类型索引 */
    private String mimeIndx;
    /** MIME列表 */
    private List<K1SV2S> mimeList;
    /** 更新日期 */
    private Date updtDate;
    /** 创建日期 */
    private Date makeDate;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        mimeList = new ArrayList<K1SV2S>();

        return true;
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
     * @return the mimeIndx
     */
    public String getMimeIndx()
    {
        return mimeIndx;
    }

    /**
     * @param mimeIndx the mimeIndx to set
     */
    public void setMimeIndx(String mimeIndx)
    {
        this.mimeIndx = mimeIndx;
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
    public List<K1SV2S> getMimeList()
    {
        return mimeList;
    }

    /**
     * @param mimeList
     */
    public void setMimeList(List<K1SV2S> mimeList)
    {
        this.mimeList = mimeList;
    }

    /**
     * @param index
     * @return
     */
    public String getMimeType(int index)
    {
        return mimeList.get(index).getK();
    }

    /**
     * @param index
     * @return
     */
    public String getMimeName(int index)
    {
        return mimeList.get(index).getV1();
    }

    /**
     * @param index
     * @return
     */
    public String getMimeDesp(int index)
    {
        return mimeList.get(index).getV2();
    }

    /**
     * @param kvItem
     */
    public void addMimeData(K1SV2S kvItem)
    {
        addMimeData(kvItem, mimeList.size());
    }

    /**
     * @param kvItem
     * @param index
     */
    public void addMimeData(K1SV2S kvItem, int index)
    {
        mimeList.add(index, kvItem);
    }

    /**
     * @param kvItem
     * @param index
     */
    public void setMimeData(K1SV2S kvItem, int index)
    {
        mimeList.set(index, kvItem);
    }
}
