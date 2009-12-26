/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3060000.b;

import cons.prp.aide.P3060000.ConstUI;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 运算符级别类
 * <li>使用说明：</li>
 * <br />
 * 本类用于封装各个运算符及其级别信息，用户只需要指定运算符，系统会根据内部设定的运算符优先级对其进行封装。
 * </ul>
 * @author Amon
 */
public class WOperator
{
    /** 运算符 */
    private String s;
    /** 运算符级别 */
    private int l;

    /**
     * 
     */
    public WOperator()
    {
        this(ConstUI.OPR_ADD_EXP, ConstUI.OPR_ADD_INT);
    }

    /**
     * @param s
     * @param l
     */
    public WOperator(String s, int l)
    {
        this.s = s;
        this.l = l;
    }

    /**
     * 获取运算符
     * 
     * @return the s
     */
    public String getS()
    {
        return s;
    }

    /**
     * 设置运算符
     * 
     * @param s the s to set
     */
    public void setS(String s)
    {
        this.s = s;
    }

    /**
     * 获取运算符级别
     * 
     * @return the l
     */
    public int getL()
    {
        return l;
    }
}
