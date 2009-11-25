/*
 * FileName:       IdioBaseData.java
 * CreateDate:     Jul 4, 2007 2:40:39 PM
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.m;

import java.util.Date;

import rmp.face.WBaseData;
import cons.prp.aide.extparse.ConstUI;

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
 * 日期： Jul 4, 2007 2:40:39 PM
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class IdioBaseData extends WBaseData
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
        this.idioIndx = ConstUI.DEF_IDIOHASH;
        this.idioLogo = ConstUI.DEF_IDIOICON;
        this.idioMail = "Amon.CT@163.com";
        this.nickName = "Amon";
        this.idioSign = "Amon软件为您服务！";
        this.homePage = "http://www.amonsoft.cn";
        this.idioDesp = "";

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
    public void setHomePage(String homePage)
    {
        this.homePage = homePage;
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
    public void setIdioDesp(String idioDesp)
    {
        this.idioDesp = idioDesp;
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
    public void setIdioIndx(String idioIndx)
    {
        this.idioIndx = idioIndx;
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
    public void setIdioLogo(String idioLogo)
    {
        this.idioLogo = idioLogo;
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
    public void setIdioMail(String idioMail)
    {
        this.idioMail = idioMail;
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
    public void setIdioSign(String idioSign)
    {
        this.idioSign = idioSign;
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
    public void setNickName(String nickName)
    {
        this.nickName = nickName;
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
}
