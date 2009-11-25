/*
 * FileName:       FileBaseData.java
 * CreateDate:     Jul 4, 2007 2:39:38 PM
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.m;

import java.util.Date;

import rmp.face.WBaseData;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 文件信息后缀数据
 * <li>使用说明：</li>
 * <br>
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： Jul 4, 2007 2:39:38 PM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class FileBaseData extends WBaseData
{
    /** 文件标记 */
    private String fileIndx;
    /** 软件索引 */
    private String softIndx;
    /** 软件名称 */
    private String softName;
    /** 文件图标 */
    private String fileIcon;
    /** 字符签名 */
    private String signChar;
    /** 数字签名 */
    private String signCode;
    /** 偏移位置 */
    private long   msOffset;
    /** 加密算法 */
    private String cipherSn;
    /** 起始数据 */
    private String headData;
    /** 结束数据 */
    private String footData;
    /** 文档格式 */
    private String formatDt;
    /** 附注信息 */
    private String fileDesp;
    /** 更新日期 */
    private Date   updtDate;
    /** 提交日期 */
    private Date   makeDate;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        return true;
    }

    /**
     * @return the cipherSn
     */
    public String getCipherSn()
    {
        return cipherSn;
    }

    /**
     * @param cipherSn the cipherSn to set
     */
    public void setCipherSn(String cipherSn)
    {
        this.cipherSn = cipherSn;
    }

    /**
     * @return the fileDesp
     */
    public String getFileDesp()
    {
        return fileDesp;
    }

    /**
     * @param fileDesp the fileDesp to set
     */
    public void setFileDesp(String fileDesp)
    {
        this.fileDesp = fileDesp;
    }

    /**
     * @return the fileIcon
     */
    public String getFileIcon()
    {
        return fileIcon;
    }

    /**
     * @param fileIcon the fileIcon to set
     */
    public void setFileIcon(String fileIcon)
    {
        this.fileIcon = fileIcon;
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
    public void setFileIndx(String fileIndx)
    {
        this.fileIndx = fileIndx;
    }

    /**
     * @return the footData
     */
    public String getFootData()
    {
        return footData;
    }

    /**
     * @param footData the footData to set
     */
    public void setFootData(String footData)
    {
        this.footData = footData;
    }

    /**
     * @return the formatDt
     */
    public String getFormatDt()
    {
        return formatDt;
    }

    /**
     * @param formatDt the formatDt to set
     */
    public void setFormatDt(String formatDt)
    {
        this.formatDt = formatDt;
    }

    /**
     * @return the headData
     */
    public String getHeadData()
    {
        return headData;
    }

    /**
     * @param headData the headData to set
     */
    public void setHeadData(String headData)
    {
        this.headData = headData;
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
     * @return the msOffset
     */
    public long getMsOffset()
    {
        return msOffset;
    }

    /**
     * @param msOffset the msOffset to set
     */
    public void setMsOffset(long msOffset)
    {
        this.msOffset = msOffset;
    }

    /**
     * @return the signChar
     */
    public String getSignChar()
    {
        return signChar;
    }

    /**
     * @param signChar the signChar to set
     */
    public void setSignChar(String signChar)
    {
        this.signChar = signChar;
    }

    /**
     * @return the signCode
     */
    public String getSignCode()
    {
        return signCode;
    }

    /**
     * @param signCode the signCode to set
     */
    public void setSignCode(String signCode)
    {
        this.signCode = signCode;
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
}
