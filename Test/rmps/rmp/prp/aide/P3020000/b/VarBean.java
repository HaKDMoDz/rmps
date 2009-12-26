/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3020000.b;

import cons.prp.aide.P3020000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 重命名表达式用户参数对象
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public class VarBean
{
    /** 用户变量标记，可选为：\ / : */
    private char cVar;
    /** 当前取值索引 */
    private int loop = 0;
    /** 变量取值空间 */
    private char[] regn;

    /**
     * 参数数据结构
     * 
     * @param p
     *            用户变量标记，可选为：\ / :
     */
    public VarBean(char p)
    {
        this.cVar = p;
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        if (cVar == '\\')
        {
            regn = new char[]
            { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            return true;
        }
        if (cVar == '/')
        {
            regn = new char[]
            { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            return true;
        }
        if (cVar == ':')
        {
            regn = new char[]
            { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return true;
        }

        return true;
    }

    /**
     * 当前取值字符是否为取值区间的最后一个值，true是；false不是
     * 
     * @return
     */
    public boolean isEnd()
    {
        return loop >= regn.length;
    }

    /**
     * 取得当前取值空间的下一个可取字符
     * 
     * @param next
     * @return
     */
    public char nextChar(boolean next)
    {
        if (regn == null)
        {
            wInit();
        }

        if (loop >= regn.length)
        {
            loop = 0;
        }

        if (!next)
        {
            return regn[loop];
        }
        return regn[loop++];
    }

    /**
     * 设置变量取值字符区域
     * 
     * @param regn
     *            the regn to set
     */
    public void setRegn(String regn) throws Exception
    {
        char[] fbdn = new char[]
        { ConstUI.EXPS_MAT_ALL, ConstUI.EXPS_MAT_ONE, ConstUI.EXPS_VAR_UPP, ConstUI.EXPS_VAR_LOW, ConstUI.EXPS_VAR_NUM, ConstUI.EXPS_CTR_UPP, ConstUI.EXPS_CTR_LOW, ConstUI.EXPS_CTR_FND,
                ConstUI.EXPS_OPT_PMS };
        for (char t : fbdn)
        {
            if (regn.indexOf(t) > 0)
            {
                throw new Exception("表达式错误：文件命名不标记中不能含有字符 ！");
            }
        }
        this.regn = regn.toCharArray();
    }

    /**
     * 获取变量取值空间容量大小
     * 
     * @return
     */
    public int capacity()
    {
        if (regn == null)
        {
            wInit();
        }
        return regn.length;
    }
}
