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

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 用户交互数据
 * <li>使用说明：</li>
 * <br />
 * 此数据结构仅用于记录用户输入的后缀及软件信息<br />
 * 1、后缀名称由用户输入确定；<br />
 * 2、后缀索引由指定的算法根据后缀名称直接计算而来；<br />
 * 3、软件名称由用户通过下拉框选择确定，可以为空，此数据仅用于显示提示性信息；<br />
 * 4、软件索引由用户通过下拉框选择确定，可以为空，用于确定后缀数据的唯一性。<br />
 * </ul>
 * @author Amon
 */
public class UserData extends WUserData
{
    /** 后缀索引 */
    private String extsHash;
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
    @Override
    public boolean wInit()
    {
        extsName = ConstUI.DEF_EXTSNAME;
        extsHash = ConstUI.DEF_EXTSHASH;

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
    public String getExtsHash()
    {
        return extsHash;
    }

    /**
     * @param extsHash
     */
    public void setExtsHash(String extsHash)
    {
        this.extsHash = extsHash;
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
