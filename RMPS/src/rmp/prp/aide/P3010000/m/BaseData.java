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
public class BaseData extends WBaseData
{
    /** 后缀索引 */
    private String extsHash;
    /** 后缀名称 */
    private String extsName;
    /** 软件索引 */
    private String softHash;
    /** 软件名称 */
    private String softName;
    private AsocBaseData asocMeta;
    private CorpBaseData corpMeta;
    private DespBaseData despMeta;
    private DocsBaseData docsMeta;
    private ExtsBaseData extsMeta;
    private FileBaseData fileMeta;
    private IdioBaseData idioMeta;
    private MimeBaseData mimeMeta;
    private SoftBaseData SoftMeta;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        this.extsHash = ConstUI.DEF_EXTSHASH;
        this.extsName = "";
        this.softHash = ConstUI.DEF_SOFTHASH;
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
     * @return the extsHash
     */
    public String getExtsHash()
    {
        return extsHash;
    }

    /**
     * @param extsHash the extsHash to set
     */
    public void setExtsHash(String extsHash)
    {
        this.extsHash = extsHash;
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
     * @return the extsHash
     */
    public String getSoftHash()
    {
        return softHash;
    }

    /**
     * @param softHash the softHash to set
     */
    public void setSoftHash(String softHash)
    {
        this.softHash = softHash;
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
     * @return the asocMeta
     */
    public AsocBaseData getAsocMeta()
    {
        return asocMeta;
    }

    /**
     * @param asocMeta the asocMeta to set
     */
    public void setAsocMeta(AsocBaseData asocMeta)
    {
        this.asocMeta = asocMeta;
    }

    /**
     * @return the corpMeta
     */
    public CorpBaseData getCorpMeta()
    {
        return corpMeta;
    }

    /**
     * @param corpMeta the corpMeta to set
     */
    public void setCorpMeta(CorpBaseData corpMeta)
    {
        this.corpMeta = corpMeta;
    }

    /**
     * @return the despMeta
     */
    public DespBaseData getDespMeta()
    {
        return despMeta;
    }

    /**
     * @param despMeta the despMeta to set
     */
    public void setDespMeta(DespBaseData despMeta)
    {
        this.despMeta = despMeta;
    }

    /**
     * @return the docsMeta
     */
    public DocsBaseData getDocsMeta()
    {
        return docsMeta;
    }

    /**
     * @param docsMeta the docsMeta to set
     */
    public void setDocsMeta(DocsBaseData docsMeta)
    {
        this.docsMeta = docsMeta;
    }

    /**
     * @return the extsMeta
     */
    public ExtsBaseData getExtsMeta()
    {
        return extsMeta;
    }

    /**
     * @param extsMeta the extsMeta to set
     */
    public void setExtsMeta(ExtsBaseData extsMeta)
    {
        this.extsMeta = extsMeta;
    }

    /**
     * @return the fileMeta
     */
    public FileBaseData getFileMeta()
    {
        return fileMeta;
    }

    /**
     * @param fileMeta the fileMeta to set
     */
    public void setFileMeta(FileBaseData fileMeta)
    {
        this.fileMeta = fileMeta;
    }

    /**
     * @return the idioMeta
     */
    public IdioBaseData getIdioMeta()
    {
        return idioMeta;
    }

    /**
     * @param idioMeta the idioMeta to set
     */
    public void setIdioMeta(IdioBaseData idioMeta)
    {
        this.idioMeta = idioMeta;
    }

    /**
     * @return the mimeMeta
     */
    public MimeBaseData getMimeMeta()
    {
        return mimeMeta;
    }

    /**
     * @param mimeMeta the mimeMeta to set
     */
    public void setMimeMeta(MimeBaseData mimeMeta)
    {
        this.mimeMeta = mimeMeta;
    }

    /**
     * @return the softMeta
     */
    public SoftBaseData getSoftMeta()
    {
        return SoftMeta;
    }

    /**
     * @param softMeta the softMeta to set
     */
    public void setSoftMeta(SoftBaseData softMeta)
    {
        SoftMeta = softMeta;
    }
}
