/*
 * FileName:       InfoData.java
 * CreateDate:     2007/09/04 10:17:59
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
 * 日期： 2007/09/04 10:17:59
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class InfoData
{
    /** 后缀数据 */
    private ExtsBaseData extsData;
    /** 公司数据 */
    private CorpBaseData corpData;
    /** 软件数据 */
    private SoftBaseData softData;
    /** 文件数据 */
    private FileBaseData fileData;
    /** 描述信息 */
    private DespBaseData despData;
    /** 备选软件 */
    private AsocBaseData asocData;
    /** MIME类型 */
    private MimeBaseData mimeData;
    /** 人员数据 */
    private IdioBaseData idioData;
    /** 国别数据 */
    private NatnBaseData natnData;
    /** 所属类别 */
    private TypeBaseData typeData;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean init()
    {
        return true;
    }

    /**
     * @return the extsData
     */
    public ExtsBaseData getExtsData()
    {
        return extsData;
    }

    /**
     * @param extsData the extsData to set
     */
    public void setExtsData(ExtsBaseData extsData)
    {
        this.extsData = extsData;
    }

    /**
     * @return the corpData
     */
    public CorpBaseData getCorpData()
    {
        return corpData;
    }

    /**
     * @param corpData the corpData to set
     */
    public void setCorpData(CorpBaseData corpData)
    {
        this.corpData = corpData;
    }

    /**
     * @return the softData
     */
    public SoftBaseData getSoftData()
    {
        return softData;
    }

    /**
     * @param softData the softData to set
     */
    public void setSoftData(SoftBaseData softData)
    {
        this.softData = softData;
    }

    /**
     * @return the fileData
     */
    public FileBaseData getFileData()
    {
        return fileData;
    }

    /**
     * @param fileData the fileData to set
     */
    public void setFileData(FileBaseData fileData)
    {
        this.fileData = fileData;
    }

    /**
     * @return the despData
     */
    public DespBaseData getDespData()
    {
        return despData;
    }

    /**
     * @param despData the despData to set
     */
    public void setDespData(DespBaseData despData)
    {
        this.despData = despData;
    }

    /**
     * @return the asocData
     */
    public AsocBaseData getAsocData()
    {
        return asocData;
    }

    /**
     * @param asocData the asocData to set
     */
    public void setAsocData(AsocBaseData asocData)
    {
        this.asocData = asocData;
    }

    /**
     * @return the mimeData
     */
    public MimeBaseData getMimeData()
    {
        return mimeData;
    }

    /**
     * @param mimeData the mimeData to set
     */
    public void setMimeData(MimeBaseData mimeData)
    {
        this.mimeData = mimeData;
    }

    /**
     * @return the idioData
     */
    public IdioBaseData getIdioData()
    {
        return idioData;
    }

    /**
     * @param idioData the idioData to set
     */
    public void setIdioData(IdioBaseData idioData)
    {
        this.idioData = idioData;
    }

    /**
     * @return the natnData
     */
    public NatnBaseData getNatnData()
    {
        return natnData;
    }

    /**
     * @param natnData the natnData to set
     */
    public void setNatnData(NatnBaseData natnData)
    {
        this.natnData = natnData;
    }

    /**
     * @return the typeData
     */
    public TypeBaseData getTypeData()
    {
        return typeData;
    }

    /**
     * @param typeData the typeData to set
     */
    public void setTypeData(TypeBaseData typeData)
    {
        this.typeData = typeData;
    }

}
