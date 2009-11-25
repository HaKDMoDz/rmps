/*
 * FileName:       RmpsData.java
 * CreateDate:     2007/09/12 12:51:21
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.m;

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
 * 日期： 2007/09/12 12:51:21
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class RmpsData
{
    /** 后缀名称 */
    private String       extsName;

    /** 软件索引 */
    private String       softHash;

    /** 后缀数据 */
    private ExtsBaseData extsMeta;
    /** 公司数据 */
    private CorpBaseData corpMeta;
    /** 软件数据 */
    private SoftBaseData softMeta;
    /** 文件数据 */
    private FileBaseData fileMeta;
    /** 个人数据 */
    private IdioBaseData idioMeta;
    /** 描述数据 */
    private DespBaseData despMeta;
    /** 类别数据 */
    private TypeBaseData typeMeta;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        // TODO Auto-generated method stub
        return false;
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
     * @return the softHash
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
     * @return the softMeta
     */
    public SoftBaseData getSoftMeta()
    {
        return softMeta;
    }

    /**
     * @param softMeta the softMeta to set
     */
    public void setSoftMeta(SoftBaseData softMeta)
    {
        this.softMeta = softMeta;
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
     * @return the typeMeta
     */
    public TypeBaseData getTypeMeta()
    {
        return typeMeta;
    }

    /**
     * @param typeMeta the typeMeta to set
     */
    public void setTypeMeta(TypeBaseData typeMeta)
    {
        this.typeMeta = typeMeta;
    }

}
