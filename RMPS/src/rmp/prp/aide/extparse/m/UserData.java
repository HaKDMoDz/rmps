/*
 * FileName:       UserData.java
 * CreateDate:     2007-9-3 下午08:08:02
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.extparse.m;

import rmp.face.WUserData;
import rmp.util.CheckUtil;
import rmp.util.StringUtil;
import cons.prp.aide.extparse.LangRes;

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
 * 日期： 2007-9-3 下午08:08:02
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public class UserData extends WUserData
{
    /** 后缀名称 */
    private String extsName;
    /** 软件索引 */
    private String softHash;
    /** 软件名称 */
    private String softName;

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#init()
     */
    @ Override
    public boolean wInit()
    {
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
        extsName = StringUtil.toDBText(extsName);

        return true;
    }

    /**
     * 返回合法的后缀名称
     * 
     * @return the extsName 返回形如“.abc”格式（带点号）的后缀名称
     */
    public String getExtsName()
    {
        return extsName;
    }

    /**
     * @param extsName the extsName to set
     */
    public boolean setExtsName(String param)
    {
        String t = param;

        // 为空性判断
        validate = CheckUtil.isValidate(t);
        if (!validate)
        {
            errMsg = StringUtil.format(LangRes.MESG_CHCK_0001, LangRes.MAIN_COMN_TEXT_EXTSNAME);
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
     * @return the softHash
     */
    public String getSoftHash()
    {
        return softHash;
    }

    /**
     * @param softHash the softHash to set
     */
    public boolean setSoftHash(String softHash)
    {
        this.softHash = softHash;
        return true;
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
    public boolean setSoftName(String softName)
    {
        this.softName = softName;
        return true;
    }

}
