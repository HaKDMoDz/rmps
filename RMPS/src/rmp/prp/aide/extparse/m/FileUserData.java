/*
 * FileName:       FileUserData.java
 * CreateDate:     Jul 4, 2007 2:40:09 PM
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.m;

import rmp.face.WUserData;
import rmp.util.CheckUtil;
import rmp.util.StringUtil;
import cons.prp.aide.extparse.ConstUI;
import cons.prp.aide.extparse.DB0008;
import cons.prp.aide.extparse.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 文件信息用户数据
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
 * 日期： Jul 4, 2007 2:40:09 PM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class FileUserData extends WUserData
{
    /** 文件标记 */
    private String fileIndx;
    /** 直属软件 */
    private String softIndx;
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

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        this.fileIndx = ConstUI.DEF_FILEHASH;
        this.fileIcon = ConstUI.DEF_FILEICON;
        this.signChar = "";
        this.signCode = "";
        this.msOffset = 0;
        this.cipherSn = "";
        this.headData = "";
        this.footData = "";
        this.formatDt = "";
        this.fileDesp = "";

        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WUserData#t2db()
     */
    @ Override
    public boolean t2db()
    {
        signChar = StringUtil.toDBText(signChar);
        signCode = StringUtil.toDBText(signCode);
        cipherSn = StringUtil.toDBText(cipherSn);
        headData = StringUtil.toDBText(headData);
        footData = StringUtil.toDBText(footData);
        formatDt = StringUtil.toDBText(formatDt);
        fileDesp = StringUtil.toDBText(fileDesp);

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
     * @return 错误信息，为NULL时表示正常。
     */
    public boolean setCipherSn(String cipherSn)
    {
        validate = CheckUtil.isValidateLength(cipherSn, DB0008.FILEDATA_CIPHERSN_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.FILE_COMN_TEXT_CIPHERSN, ""
                + DB0008.FILEDATA_CIPHERSN_SIZE);
            return false;
        }
        this.cipherSn = cipherSn;
        return true;
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
     * @return 错误信息，为NULL时表示正常。
     */
    public boolean setFileDesp(String fileDesp)
    {
        validate = CheckUtil.isValidateLength(fileDesp, DB0008.FILEDATA_FILEDESP_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.FILE_COMN_TEXT_FILEDESP, ""
                + DB0008.FILEDATA_FILEDESP_SIZE);
            return false;
        }
        this.fileDesp = fileDesp;
        return true;
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
     * @return 错误信息，为NULL时表示正常。
     */
    public boolean setFileIcon(String fileIcon)
    {
        validate = CheckUtil.isValidateLength(fileIcon, DB0008.FILEDATA_FILEICON_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, "LangRes.TEXT_FILEICON", ""
                + DB0008.FILEDATA_FILEICON_SIZE);
            return true;
        }
        this.fileIcon = fileIcon;
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
     * @return 错误信息，为NULL时表示正常。
     */
    public boolean setFileIndx(String fileIndx)
    {
        this.fileIndx = fileIndx;
        return true;
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
     * @return 错误信息，为NULL时表示正常。
     */
    public boolean setFootData(String footData)
    {
        validate = CheckUtil.isValidateLength(footData, DB0008.FILEDATA_FOOTDATA_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, "LangRes.TEXT_FOOTDATA", ""
                + DB0008.FILEDATA_FOOTDATA_SIZE);
            return false;
        }
        this.footData = footData;
        return true;
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
     * @return 错误信息，为NULL时表示正常。
     */
    public boolean setFormatDt(String formatDt)
    {
        validate = CheckUtil.isValidateLength(formatDt, DB0008.FILEDATA_FORMATDT_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, "LangRes.TEXT_FORMATDT", ""
                + DB0008.FILEDATA_FORMATDT_SIZE);
            return false;
        }
        this.formatDt = formatDt;
        return true;
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
    public boolean setHeadData(String headData)
    {
        validate = CheckUtil.isValidateLength(headData, DB0008.FILEDATA_HEADDATA_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, "LangRes.TEXT_HEADDATA", ""
                + DB0008.FILEDATA_HEADDATA_SIZE);
            return false;
        }
        this.headData = headData;
        return true;
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
     * @return 错误信息，为NULL时表示正常。
     */
    public boolean setMsOffset(String msOffset)
    {
        if (!CheckUtil.isValidate(msOffset))
        {
            this.msOffset = 0;
            return true;
        }

        try
        {
            this.msOffset = Long.parseLong(msOffset);
            return true;
        }
        catch(NumberFormatException nfe)
        {
            errMsg = StringUtil.format(LangRes.FILE_MESG_CHCK_0001, LangRes.FILE_COMN_TEXT_MSOFFSET);
            return false;
        }
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
     * @return 错误信息，为NULL时表示正常。
     */
    public boolean setSignChar(String signChar)
    {
        validate = CheckUtil.isValidate(signChar);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0001, LangRes.FILE_COMN_TEXT_SIGNCHAR);
            return false;
        }

        validate = CheckUtil.isValidateLength(signChar, DB0008.FILEDATA_SIGNCHAR_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.FILE_COMN_TEXT_SIGNCHAR, ""
                + DB0008.FILEDATA_SIGNCHAR_SIZE);
            return false;
        }

        this.signChar = signChar;
        return true;
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
     * @return 错误信息，为NULL时表示正常。
     */
    public boolean setSignCode(String signCode)
    {
        validate = CheckUtil.isValidateLength(signCode, DB0008.FILEDATA_SIGNCODE_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.FILE_COMN_TEXT_SIGNCHAR, ""
                + DB0008.FILEDATA_SIGNCODE_SIZE);
            return false;
        }

        this.signCode = signCode;
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
}