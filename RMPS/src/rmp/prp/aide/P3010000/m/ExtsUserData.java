/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.m;

import rmp.face.WUserData;
import rmp.prp.aide.extparse.Extparse;
import rmp.util.CheckUtil;
import rmp.util.StringUtil;
import cons.prp.aide.P3010000.ConstUI;
import cons.prp.aide.P3010000.LangRes;
import cons.prp.aide.extparse.DB0008;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 后缀更新面板用户输入数据对象
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * @author Amon
 */
public class ExtsUserData extends WUserData
{
    /** 文件后缀 */
    private String extsName;
    /** 应用平台 */
    private int platIndx;
    /** 处理字长 */
    private int archBits;
    /** 国别索引 */
    private String natnIndx;
    /** 公司索引 */
    private String corpIndx;
    /** 软件索引_现在（新增时用） */
    private String softIndx;
    /** 软件索引_原有（更新时用） */
    private String softIndx_O;
    /** 文件索引 */
    private String fileIndx;
    /** 类别索引 */
    private String typeIndx;
    /** 人员索引 */
    private String idioIndx;
    /** 附注说明 */
    private String idioMark;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        this.extsName = "";
        this.platIndx = 0;
        this.archBits = 0;
        this.natnIndx = ConstUI.DEF_NATNHASH;
        this.corpIndx = ConstUI.DEF_CORPHASH;
        this.softIndx = ConstUI.DEF_SOFTHASH;
        this.softIndx_O = ConstUI.DEF_SOFTHASH;
        this.fileIndx = ConstUI.DEF_FILEHASH;
        this.typeIndx = ConstUI.DEF_TYPEHASH;
        this.idioIndx = ConstUI.DEF_IDIOHASH;
        this.idioMark = "";

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WUserData#t2db()
     */
    @Override
    public boolean t2db()
    {
        extsName = StringUtil.toDBText(extsName);
        return true;
    }

    /**
     * @return
     */
    public int getArchBits()
    {
        return archBits;
    }

    /**
     * @param archBits
     */
    public void setArchBits(int archBits)
    {
        this.archBits = archBits;
    }

    /**
     * @return the corpIndx
     */
    public String getCorpIndx()
    {
        return corpIndx;
    }

    /**
     * @param corpIndx the corpIndx to set
     */
    public String setCorpIndx(String corpIndx)
    {
        this.corpIndx = corpIndx;
        return null;
    }

    /**
     * @return the extsName 形如“.abc”格式的后缀
     */
    public String getExtsName()
    {
        return extsName;
    }

    /**
     * @param param the extsName to set
     */
    public boolean setExtsName(String param)
    {
        String t = param;

        // 为空性判断
        validate = CheckUtil.isValidate(t);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0001, LangRes.EXTS_COMN_TEXT_EXTSNAME);
            return false;
        }

        // 分隔符重复检测
        t = StringUtil.lTrim(t.trim(), ".");
        validate = !".".equals(t);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MAIN_MESG_CHCK_0001, param);
            return false;
        }

        // 后缀标记符校正
        if ('.' != t.charAt(0))
        {
            t = '.' + t;
        }

        extsName = t;
        return true;
    }

    /**
     * @return the fileIndx
     */
    public String getFileIndx()
    {
        return fileIndx;
    }

    /**
     * @param fileIndx the fileIndx to set
     */
    public boolean setFileIndx(String fileIndx)
    {
        this.fileIndx = fileIndx;
        return true;
    }

    /**
     * @return the idioIndx
     */
    public String getIdioIndx()
    {
        return idioIndx;
    }

    /**
     * @param idioIndx the idioIndx to set
     */
    public boolean setIdioIndx(String idioIndx)
    {
        this.idioIndx = idioIndx;
        return true;
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
    public boolean setIdioMark(String idioMark)
    {
        validate = CheckUtil.isValidateLength(idioMark, DB0008.EXTSDATA_IDIOMARK_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.EXTS_COMN_TEXT_IDIOMARK, "" + DB0008.EXTSDATA_IDIOMARK_SIZE);
            return false;
        }

        this.idioMark = idioMark;
        return true;
    }

    /**
     * @return the platIndx
     */
    public int getPlatIndx()
    {
        return platIndx;
    }

    /**
     * @param platIndx the platIndx to set
     */
    public boolean setPlatIndx(int platIndx)
    {
        this.platIndx = platIndx;
        return true;
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
    public boolean setSoftIndx(String softIndx)
    {
        this.softIndx = softIndx;
        return true;
    }

    /**
     * @return the softIndx
     */
    public String getSoftIndx_O()
    {
        return softIndx_O;
    }

    /**
     * @param softIndx_O the softIndx to set
     */
    public boolean setSoftIndx_O(String softIndx_O)
    {
        validate = CheckUtil.isValidate(softIndx_O);
        if (!validate)
        {
            errMsg = Extparse.getMesg(LangRes.EXTS_MESG_UPDT_0002);
            return false;
        }

        this.softIndx_O = softIndx_O;

        return true;
    }

    /**
     * @return the typeIndx
     */
    public String getTypeIndx()
    {
        return typeIndx;
    }

    /**
     * @param typeIndx the typeIndx to set
     */
    public boolean setTypeIndx(String typeIndx)
    {
        this.typeIndx = typeIndx;
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
}
