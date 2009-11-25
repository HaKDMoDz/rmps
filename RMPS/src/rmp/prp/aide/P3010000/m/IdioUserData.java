/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.m;

import rmp.face.WUserData;
import rmp.util.CheckUtil;
import rmp.util.StringUtil;
import cons.prp.aide.P3010000.ConstUI;
import cons.prp.aide.P3010000.LangRes;
import cons.prp.aide.extparse.DB0008;

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
public class IdioUserData extends WUserData
{
    /** 人员索引 */
    private String idioIndx;
    /** 个性图标 */
    private String idioLogo;
    /** 联系邮件 */
    private String idioMail;
    /** 昵称 */
    private String nickName;
    /** 个性签名 */
    private String idioSign;
    /** 个人主页 */
    private String homePage;
    /** 相关说明 */
    private String idioDesp;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    public boolean wInit()
    {
        this.idioIndx = ConstUI.DEF_IDIOHASH;
        this.idioLogo = ConstUI.DEF_IDIOICON;
        this.idioMail = "Amon.CT@163.com";
        this.nickName = "Amon";
        this.idioSign = "Amon软件为您服务！";
        this.homePage = "http://www.winshine.net.cn/";
        this.idioDesp = "";

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
        idioMail = StringUtil.toDBText(idioMail);
        nickName = StringUtil.toDBText(nickName);
        idioSign = StringUtil.toDBText(idioSign);
        homePage = StringUtil.toDBText(homePage);
        idioDesp = StringUtil.toDBText(idioDesp);

        return true;
    }

    /**
     * @return the homePage
     */
    public String getHomePage()
    {
        return homePage;
    }

    /**
     * @param homePage the homePage to set
     */
    public boolean setHomePage(String homePage)
    {
        validate = CheckUtil.isValidateUrl(homePage);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0004, "LangRes.TEXT_HOMEPAGE");
            return false;
        }

        validate = CheckUtil.isValidateLength(homePage, DB0008.IDIODATA_HOMEPAGE_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, "LangRes.TEXT_SOFTSITE", "" + DB0008.IDIODATA_HOMEPAGE_SIZE);
            return false;
        }
        this.homePage = homePage;
        return true;
    }

    /**
     * @return the idioDesp
     */
    public String getIdioDesp()
    {
        return idioDesp;
    }

    /**
     * @param idioDesp the idioDesp to set
     */
    public boolean setIdioDesp(String idioDesp)
    {
        validate = CheckUtil.isValidateLength(idioDesp, DB0008.IDIODATA_IDIODESP_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, "LangRes.TEXT_IDIODESP", "" + DB0008.IDIODATA_IDIODESP_SIZE);
            return false;
        }
        this.idioDesp = idioDesp;
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
     * @return the idioLogo
     */
    public String getIdioLogo()
    {
        return idioLogo;
    }

    /**
     * @param idioLogo the idioLogo to set
     */
    public boolean setIdioLogo(String idioLogo)
    {
        this.idioLogo = idioLogo;
        return true;
    }

    /**
     * @return the idioMail
     */
    public String getIdioMail()
    {
        return idioMail;
    }

    /**
     * @param idioMail the idioMail to set
     */
    public boolean setIdioMail(String idioMail)
    {
        validate = CheckUtil.isValidate(idioMail);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0001, LangRes.IDIO_COMN_TEXT_IDIOMAIL);
            return false;
        }

        validate = CheckUtil.isValidateMail(idioMail);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0003, LangRes.IDIO_COMN_TEXT_IDIOMAIL);
            return false;
        }

        validate = CheckUtil.isValidateLength(idioMail, DB0008.IDIODATA_IDIOMAIL_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.IDIO_COMN_TEXT_IDIOMAIL, "" + DB0008.IDIODATA_IDIOMAIL_SIZE);
            return false;
        }
        this.idioMail = idioMail;
        return true;
    }

    /**
     * @return the idioSign
     */
    public String getIdioSign()
    {
        return idioSign;
    }

    /**
     * @param idioSign the idioSign to set
     */
    public boolean setIdioSign(String idioSign)
    {
        validate = CheckUtil.isValidateLength(idioSign, DB0008.IDIODATA_IDIOSIGN_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.IDIO_COMN_TEXT_IDIOSIGN, "" + DB0008.IDIODATA_IDIOSIGN_SIZE);
            return false;
        }
        this.idioSign = idioSign;
        return true;
    }

    /**
     * @return the nickName
     */
    public String getNickName()
    {
        return nickName;
    }

    /**
     * @param nickName the nickName to set
     */
    public boolean setNickName(String nickName)
    {
        validate = CheckUtil.isValidateLength(nickName, DB0008.IDIODATA_NICKNAME_SIZE);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0002, LangRes.IDIO_COMN_TEXT_NICKNAME, "" + DB0008.IDIODATA_NICKNAME_SIZE);
            return false;
        }
        this.nickName = nickName;
        return true;
    }
}
