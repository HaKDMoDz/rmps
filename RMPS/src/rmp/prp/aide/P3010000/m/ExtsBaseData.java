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
import cons.prp.aide.P3010000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 后缀更新面板数据库对象
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class ExtsBaseData extends WBaseData
{
    /** 文件后缀 */
    private String extsName;
    /** 访问频率 */
    private int acsTimes;
    /** 应用平台 */
    private int platIndx;
    /** 处理字长 */
    private int archBits;
    /** 后缀索引 */
    private String extsIndx;
    /** 公司索引 */
    private String corpIndx;
    /** 软件索引 */
    private String softIndx;
    /** 文件索引 */
    private String fileIndx;
    /** 描述索引 */
    private String despIndx;
    /** 备选索引 */
    private String asocIndx;
    /** MIME类型 */
    private String mimeIndx;
    /** 类别索引 */
    private String typeIndx;
    /** 人员索引 */
    private String idioIndx;
    /** 更新日期 */
    private Date updtDate;
    /** 提交日期 */
    private Date makeDate;
    /** 个人说明 */
    private String idioMark;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        this.extsName = "";
        this.acsTimes = 0;
        this.platIndx = 0;
        this.archBits = 0;
        this.extsIndx = ConstUI.DEF_EXTSHASH;
        this.corpIndx = ConstUI.DEF_CORPHASH;
        this.softIndx = ConstUI.DEF_SOFTHASH;
        this.fileIndx = ConstUI.DEF_FILEHASH;
        this.despIndx = ConstUI.DEF_DESPHASH;
        this.asocIndx = ConstUI.DEF_ASOCHASH;
        this.mimeIndx = ConstUI.DEF_MIMEHASH;
        this.typeIndx = ConstUI.DEF_TYPEHASH;
        this.idioIndx = ConstUI.DEF_IDIOHASH;
        this.idioMark = "";

        return true;
    }

    public String getExtsName()
    {
        return extsName;
    }

    public void setExtsName(String extsName)
    {
        this.extsName = extsName;
    }

    public int getAcsTimes()
    {
        return acsTimes;
    }

    public void setAcsTimes(int acsTimes)
    {
        this.acsTimes = acsTimes;
    }

    public int getPlatIndx()
    {
        return platIndx;
    }

    public void setPlatIndx(int platIndx)
    {
        this.platIndx = platIndx;
    }

    public int getArchBits()
    {
        return archBits;
    }

    public void setArchBits(int archBits)
    {
        this.archBits = archBits;
    }

    public String getExtsIndx()
    {
        return extsIndx;
    }

    public void setExtsIndx(String extsIndx)
    {
        this.extsIndx = extsIndx;
    }

    public String getCorpIndx()
    {
        return corpIndx;
    }

    public void setCorpIndx(String corpIndx)
    {
        this.corpIndx = corpIndx;
    }

    public String getSoftIndx()
    {
        return softIndx;
    }

    public void setSoftIndx(String softIndx)
    {
        this.softIndx = softIndx;
    }

    public String getFileIndx()
    {
        return fileIndx;
    }

    public void setFileIndx(String fileIndx)
    {
        this.fileIndx = fileIndx;
    }

    public String getDespIndx()
    {
        return despIndx;
    }

    public void setDespIndx(String despIndx)
    {
        this.despIndx = despIndx;
    }

    public String getAsocIndx()
    {
        return asocIndx;
    }

    public void setAsocIndx(String asocIndx)
    {
        this.asocIndx = asocIndx;
    }

    public String getMimeIndx()
    {
        return mimeIndx;
    }

    public void setMimeIndx(String mimeIndx)
    {
        this.mimeIndx = mimeIndx;
    }

    public String getTypeIndx()
    {
        return typeIndx;
    }

    public void setTypeIndx(String typeIndx)
    {
        this.typeIndx = typeIndx;
    }

    public String getIdioIndx()
    {
        return idioIndx;
    }

    public void setIdioIndx(String idioIndx)
    {
        this.idioIndx = idioIndx;
    }

    public Date getUpdtDate()
    {
        return updtDate;
    }

    public void setUpdtDate(Date updtDate)
    {
        this.updtDate = updtDate;
    }

    public Date getMakeDate()
    {
        return makeDate;
    }

    public void setMakeDate(Date makeDate)
    {
        this.makeDate = makeDate;
    }

    public String getIdioMark()
    {
        return idioMark;
    }

    public void setIdioMark(String idioMark)
    {
        this.idioMark = idioMark;
    }
}
