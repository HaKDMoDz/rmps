/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3060000.t;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.math.MathContext;
import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

import rmp.bean.K1SV2S;
import rmp.prp.aide.P3060000.b.WOperator;
import rmp.util.LogUtil;

import com.amonsoft.util.CharUtil;

import cons.prp.aide.P3060000.ConstUI;
import cons.prp.aide.P3060000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 表达式计算工具，用于计算用户给定表达式的值，并根据需要返回每一步的计算结果。
 * <li>使用说明：</li>
 * <br />
 * 流程说明：<br />
 * 本计算流程采用如下计算方式：<br />
 * 1、去除原计算表达式结尾的等号“=”；<br />
 * 2、把原表达式放置在小括号“()”内，以进行相同的算法处理；<br />
 * 3、记录每一步的运算结果，并保存在K1SV2S对象内；<br />
 * K1SV2S对象存储结构如下：<br />
 * k:上一步计算表达式；<br />
 * v1：当前步骤待进行计算的操作子；<br />
 * v2：当前运算结果；<br />
 * 4、返回运算结果。<br />
 * <br />
 * 使用说明：<br />
 * 1、用户表达式为空的情况下，系抛出异常；<br />
 * 2、步骤列表为NULL的情况下，不进行运算步骤的记录；<br />
 * 3、运算结果可以直接返回；<br />
 * 4、运算步骤的最后一步用户可以根据需要选择是否显示，原因：<br />
 * 在运算过程中额外添加了一对小括号“”，见流程说明2，此步骤是否存在不影响结果的显示。<br />
 * </ul>
 * 
 * @author Amon
 */
public final class Util
{
    /** 操作数堆栈 */
    private static Stack<String> numStack;
    /** 操作符堆栈 */
    private static Stack<WOperator> oprStack;

    /**
     * 仅支持小括号及 + - * / % 运算的方法
     * 
     * @param exps
     * @return
     */
    public static int calculate(String exps) throws Exception
    {
        if (!CharUtil.isValidate(exps))
        {
            return 0;
        }

        exps = exps.trim();
        exps = '(' + exps + ')';

        Stack<Integer> numStack = new Stack<Integer>();
        Stack<Character> oprStack = new Stack<Character>();

        StringBuffer sb = new StringBuffer();
        char[] a = exps.toCharArray();
        char t;
        boolean b = false;
        for (char c : a)
        {
            if (c == '(')
            {
                oprStack.push(c);
                b = true;
                continue;
            }
            if (c == ')')
            {
                if (sb.length() > 0)
                {
                    numStack.push(Integer.parseInt(sb.toString()));
                    sb.delete(0, sb.length());
                }
                while (!oprStack.isEmpty())
                {
                    t = oprStack.peek();
                    if (t == '(')
                    {
                        break;
                    }
                    numStack.push(calculate(numStack.pop(), oprStack.pop(), numStack.pop()));
                }
                oprStack.pop();
                b = false;
                continue;
            }
            if (c == '-')
            {
                if (b)
                {
                    sb.append(c);
                    b = false;
                    continue;
                }

                if (sb.length() > 0)
                {
                    numStack.push(Integer.parseInt(sb.toString()));
                    sb.delete(0, sb.length());
                }
                oprStack.push(c);
                b = true;
                continue;
            }
            if (c == '+')
            {
                if (b)
                {
                    sb.append(c);
                    b = false;
                    continue;
                }

                if (sb.length() > 0)
                {
                    numStack.push(Integer.parseInt(sb.toString()));
                    sb.delete(0, sb.length());
                }
                oprStack.push(c);
                b = true;
                continue;
            }
            if (c == '*' || c == '/' || c == '%')
            {
                if (sb.length() > 0)
                {
                    numStack.push(Integer.parseInt(sb.toString()));
                    sb.delete(0, sb.length());
                }
                while (!oprStack.isEmpty())
                {
                    t = oprStack.peek();
                    if (t == '(' || t == '+' || t == '-')
                    {
                        break;
                    }
                    numStack.push(calculate(numStack.pop(), oprStack.pop(), numStack.pop()));
                }
                oprStack.push(c);
                b = true;
                continue;
            }
            if (c >= '0' && c <= '9')
            {
                sb.append(c);
                b = false;
                continue;
            }
            throw new Exception("表达式中存在未知字符" + c);
        }
        return numStack.pop();
    }

    /**
     * @param numStack
     * @param c
     */
    private static final int calculate(int r, char c, int l)
    {
        switch (c)
        {
            case '+':
                return (l + r);
            case '-':
                return (l - r);
            case '*':
                return (l * r);
            case '/':
                return (l / r);
            case '%':
                return (l % r);
            default:
                return (0);
        }
    }

    /**
     * 计算指定表格式的值
     * 
     * @param exps
     *            表达式
     * @param scale
     *            计算精度
     * @param stepList
     *            计算步骤列表，记录每一步的计算方法，为NULL时表示不记录运算步骤。<br />
     *            k:当前要进行计算的步骤；<br />
     *            v1:将进行计算的运算单元；<br />
     *            v2:单元运算结果；<br />
     * @return
     */
    public static String calculate(String exps, int scale, List<K1SV2S> stepList) throws Exception
    {
        if (exps == null)
        {
            throw new Exception("表达式为空！");
        }
        exps = exps.trim();
        if (exps.endsWith("="))
        {
            exps = exps.substring(0, exps.length() - 1);
        }
        if (exps.length() < 1)
        {
            throw new Exception("表达式为空！");
        }

        // 去除表达式中所有空格
        exps = exps.replace(" ", "").toLowerCase();

        // 是否需要记录运算步骤
        boolean recSteps = stepList != null;

        // 操作数堆栈
        numStack = new Stack<String>();
        // numStack.push("0");
        // 操作符堆栈
        oprStack = new Stack<WOperator>();
        // oprStack.push(new WOperator());

        // 操作数缓冲区
        StringBuffer numBuf = new StringBuffer();
        // 操作符缓冲区
        StringBuffer oprBuf = new StringBuffer();
        // 表达式字符串
        char[] expBuf = ('(' + exps + ')').toCharArray();
        // 临时字符串
        String tmpOpr;
        // 上一个字符（串）是否为操作符，true表示是；false表示否
        boolean lastIsOpr = false;

        // 左括号
        final String[] LBT_EXP =
        {
        //
                ConstUI.OPR_SLB_EXP,//
                ConstUI.OPR_MLB_EXP,//
                ConstUI.OPR_LLB_EXP,//
        };
        final int[] LBT_INT =
        {
        //
                ConstUI.OPR_SLB_INT,//
                ConstUI.OPR_MLB_INT,//
                ConstUI.OPR_LLB_INT,//
        };
        // 右括号
        final String[] RBT_EXP =
        {
        //
                ConstUI.OPR_SRB_EXP,//
                ConstUI.OPR_MRB_EXP,//
                ConstUI.OPR_LRB_EXP,//
        };
        final int[] RBT_INT =
        {
        //
                ConstUI.OPR_SRB_INT,//
                ConstUI.OPR_MRB_INT,//
                ConstUI.OPR_LRB_INT,//
        };

        // 操作符
        final String[] OPR_EXP =
        {
        //
                ConstUI.OPR_ADD_EXP,// 加
                ConstUI.OPR_SUB_EXP,// 减
                ConstUI.OPR_MUL_EXP,// 乘
                ConstUI.OPR_DIV_EXP,// 除
                ConstUI.OPR_MOD_EXP,// 取模
                ConstUI.OPR_POW_EXP,// 次幂
                ConstUI.OPR_ROT_EXP,// 方根
                ConstUI.OPR_LOG_EXP,// 10对数
                ConstUI.OPR_LNE_EXP,// 自然对数
                ConstUI.OPR_FAC_EXP,// 阶乘
                ConstUI.OPR_SIN_EXP,//
                ConstUI.OPR_COS_EXP,//
                ConstUI.OPR_TAN_EXP,//
                ConstUI.OPR_SEC_EXP,//
                ConstUI.OPR_CSC_EXP,//
                ConstUI.OPR_COT_EXP,//
        };
        final int[] OPR_INT =
        {
        //
                ConstUI.OPR_ADD_INT,// 加
                ConstUI.OPR_SUB_INT,// 减
                ConstUI.OPR_MUL_INT,// 乘
                ConstUI.OPR_DIV_INT,// 除
                ConstUI.OPR_MOD_INT,// 取模
                ConstUI.OPR_POW_INT,// 次幂
                ConstUI.OPR_ROT_INT,// 方根
                ConstUI.OPR_LOG_INT,// 10对数
                ConstUI.OPR_LNE_INT,// 自然对数
                ConstUI.OPR_FAC_INT,// 阶乘
                ConstUI.OPR_SIN_INT,//
                ConstUI.OPR_COS_INT,//
                ConstUI.OPR_TAN_INT,//
                ConstUI.OPR_SEC_INT,//
                ConstUI.OPR_CSC_INT,//
                ConstUI.OPR_COT_INT,//
        };

        // 循环处理每一个表达式字符
        NEXT_O: for (char c : expBuf)
        {
            // 负号
            if (lastIsOpr && (c == '-' || c == '+'))
            {
                if (oprBuf.length() != 0)
                {
                    throw new Exception(CharUtil.format(LangRes.P3061A01, oprBuf.toString()));
                }
                lastIsOpr = false;
                numBuf.append(c);
                continue;
            }

            // 操作数
            if ((c >= '0' && c <= '9') || c == '.')
            {
                if (oprBuf.length() != 0)
                {
                    throw new Exception(CharUtil.format(LangRes.P3061A01, oprBuf.toString()));
                }
                lastIsOpr = false;
                numBuf.append(c);
                continue;
            }

            // e
            if (c == 'e' || c == 'E')
            {
                if (oprBuf.length() != 0)
                {
                    throw new Exception(CharUtil.format(LangRes.P3061A01, oprBuf.toString()));
                }
                lastIsOpr = false;
                BigDecimal e = new BigDecimal(Math.E).setScale(scale, BigDecimal.ROUND_HALF_UP).stripTrailingZeros();
                String ep = e.toPlainString();
                numBuf.append(ep);
                exps = exps.replace("e", ep);
                exps = exps.replace("E", ep);
                continue;
            }

            // π
            if (c == 'π')
            {
                if (oprBuf.length() != 0)
                {
                    throw new Exception(CharUtil.format(LangRes.P3061A01, oprBuf.toString()));
                }
                lastIsOpr = false;
                BigDecimal e = new BigDecimal(Math.PI).setScale(scale, BigDecimal.ROUND_HALF_UP).stripTrailingZeros();
                String ep = e.toPlainString();
                numBuf.append(ep);
                exps = exps.replace("π", ep);
                continue;
            }

            // 操作符
            tmpOpr = oprBuf.append(c).toString();

            // 左括号
            for (int i = 0, j = LBT_EXP.length; i < j; i += 1)
            {
                if (LBT_EXP[i].equals(tmpOpr))
                {
                    lastIsOpr = true;
                    // 清除当前操作符
                    oprBuf.delete(0, oprBuf.length());

                    // 左操作数不为空的情况下，左操作数入栈
                    if (numBuf.length() > 0)
                    {
                        numStack.push(numBuf.toString());
                        numBuf.delete(0, numBuf.length());
                    }

                    // 操作符入栈
                    oprStack.push(new WOperator(tmpOpr, LBT_INT[i]));

                    continue NEXT_O;
                }
            }

            // 右括号
            for (int i = 0, j = RBT_EXP.length; i < j; i += 1)
            {
                if (RBT_EXP[i].equals(tmpOpr))
                {
                    if (lastIsOpr)
                    {
                        throw new Exception("缺少操作数，请确认您输入表达式的是否正确！");
                    }

                    lastIsOpr = false;
                    // 清除当前操作符
                    oprBuf.delete(0, oprBuf.length());

                    if (numBuf.length() > 0)
                    {
                        numStack.push(numBuf.toString());
                        numBuf.delete(0, numBuf.length());
                    }

                    K1SV2S kvItem;
                    WOperator o;

                    // 循环处理每一个操作符
                    NEXT_I: while (true)
                    {
                        o = oprStack.peek();
                        for (int m = 0, n = LBT_EXP.length; m < n; m += 1)
                        {
                            if (LBT_EXP[m].equals(o.getS()))
                            {
                                // 操作符级别判断
                                if (LBT_INT[m] + 7 == RBT_INT[i])
                                {
                                    oprStack.pop();
                                    if (recSteps)
                                    {
                                        String t = numStack.peek();
                                        String p = LBT_EXP[m] + t + RBT_EXP[m];
                                        stepList.add(new K1SV2S(exps, p, t));
                                        exps = exps.replace(p, t);
                                    }
                                    break NEXT_I;
                                }
                                throw new Exception(CharUtil.format("您输入的表达式不正确：{0}与{1}不匹配！", LBT_EXP[m], tmpOpr));
                            }
                        }

                        // 运算结果
                        kvItem = calculate(exps, scale);
                        // 统计运算步骤
                        if (recSteps)
                        {
                            stepList.add(kvItem);
                            exps = exps.replace(kvItem.getV1(), kvItem.getV2());
                        }
                    }
                    continue NEXT_O;
                }
            }

            // 运算符运算
            for (int i = 0, j = OPR_EXP.length; i < j; i += 1)
            {
                if (OPR_EXP[i].equalsIgnoreCase(tmpOpr))
                {
                    lastIsOpr = ConstUI.OPR_FAC_EXP.equals(tmpOpr) ? false : true;
                    // 清除当前操作符
                    oprBuf.delete(0, oprBuf.length());

                    // 左操作数不为空的情况下，左操作数入栈
                    if (numBuf.length() > 0)
                    {
                        numStack.push(numBuf.toString());
                        numBuf.delete(0, numBuf.length());
                    }

                    K1SV2S kvItem = null;
                    // 当前运算符
                    WOperator newOpr = new WOperator(tmpOpr, OPR_INT[i]);

                    // 循环处理每一个操作符
                    while (true)
                    {
                        // 操作符级别判断
                        if (newOpr.getL() > oprStack.peek().getL())
                        {
                            oprStack.push(newOpr);
                            break;
                        }

                        // 运算结果
                        kvItem = calculate(exps, scale);
                        // 统计运算步骤
                        if (recSteps)
                        {
                            stepList.add(kvItem);
                            exps = exps.replace(kvItem.getV1(), kvItem.getV2());
                        }
                    }
                    break;
                }
            }
        }

        if (oprStack.size() > 0)
        {
            throw new Exception("表达式存在错误，系统无法计算！");
        }

        return numStack.size() != 0 ? numStack.pop() : "";
    }

    /**
     * 双目运算符运算
     * 
     * @param opr
     *            操作符
     * @param scale
     *            计算精度
     * @param opds
     *            操作数
     * @return
     */
    private static K1SV2S calculate(String exps, int scale) throws Exception
    {
        String lOpd = null;
        String mOpr = oprStack.pop().getS();
        String rOpd = numStack.pop();
        String tNum;

        K1SV2S kvItem = new K1SV2S();

        // 加
        if (ConstUI.OPR_ADD_EXP.equals(mOpr))
        {
            lOpd = numStack.pop();
            LogUtil.log("运算：" + lOpd + mOpr + rOpd);
            tNum = new BigDecimal(lOpd).add(new BigDecimal(rOpd)).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(lOpd + mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 减
        if (ConstUI.OPR_SUB_EXP.equals(mOpr))
        {
            lOpd = numStack.pop();
            LogUtil.log("运算：" + lOpd + mOpr + rOpd);
            tNum = new BigDecimal(lOpd).subtract(new BigDecimal(rOpd)).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(lOpd + mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 乘
        if (ConstUI.OPR_MUL_EXP.equals(mOpr))
        {
            lOpd = numStack.pop();
            LogUtil.log("运算：" + lOpd + mOpr + rOpd);
            tNum = new BigDecimal(lOpd).multiply(new BigDecimal(rOpd)).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(lOpd + mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 除
        if (ConstUI.OPR_DIV_EXP.equals(mOpr))
        {
            BigDecimal t = new BigDecimal(rOpd);
            if (t.compareTo(new BigDecimal(0)) == 0)
            {
                throw new Exception("除数为0");
            }
            lOpd = numStack.pop();
            LogUtil.log("运算：" + lOpd + mOpr + rOpd);
            tNum = new BigDecimal(lOpd).divide(t, scale, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(lOpd + mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 取模
        if (ConstUI.OPR_MOD_EXP.equals(mOpr))
        {
            BigDecimal t = new BigDecimal(rOpd);
            if (t.compareTo(new BigDecimal(0)) == 0)
            {
                throw new Exception("除数为0");
            }
            lOpd = numStack.pop();
            LogUtil.log("运算：" + lOpd + mOpr + rOpd);
            tNum = new BigDecimal(lOpd).remainder(t).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(lOpd + mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 次幂
        if (ConstUI.OPR_POW_EXP.equals(mOpr))
        {
            try
            {
                int t = new BigDecimal(rOpd).intValueExact();
                lOpd = numStack.pop();
                tNum = new BigDecimal(lOpd).pow(t).stripTrailingZeros().toPlainString();
                numStack.push(tNum);
                kvItem.setK(exps);
                kvItem.setV1(lOpd + mOpr + rOpd);
                kvItem.setV2(tNum);
                return kvItem;
            }
            catch (ArithmeticException exp)
            {
                LogUtil.exception(exp);
                throw new Exception(CharUtil.format("次幂时，指数{0}应为一个整数！", rOpd.toString()));
            }
        }

        // 方根
        if (ConstUI.OPR_ROT_EXP.equals(mOpr))
        {
            lOpd = numStack.pop();
            BigDecimal tl = new BigDecimal(rOpd);
            BigInteger tr = new BigInteger(lOpd);
            tNum = root(tl, tr.intValue(), scale).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(lOpd + mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 正弦
        if (ConstUI.OPR_SIN_EXP.equalsIgnoreCase(mOpr))
        {
            BigDecimal t = new BigDecimal(rOpd);
            t = new BigDecimal(Math.sin(t.doubleValue()));
            tNum = t.setScale(scale, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 余弦
        if (ConstUI.OPR_COS_EXP.equalsIgnoreCase(mOpr))
        {
            BigDecimal t = new BigDecimal(rOpd);
            t = new BigDecimal(Math.cos(t.doubleValue()));
            tNum = t.setScale(scale, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 正切
        if (ConstUI.OPR_TAN_EXP.equalsIgnoreCase(mOpr))
        {
            BigDecimal t = new BigDecimal(rOpd);
            t = new BigDecimal(Math.tan(t.doubleValue()));
            tNum = t.setScale(scale, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 正割
        if (ConstUI.OPR_SEC_EXP.equalsIgnoreCase(mOpr))
        {
            BigDecimal t = new BigDecimal(rOpd);
            t = new BigDecimal(Math.asin(t.doubleValue()));
            tNum = t.setScale(scale, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 余割
        if (ConstUI.OPR_CSC_EXP.equalsIgnoreCase(mOpr))
        {
            BigDecimal t = new BigDecimal(rOpd);
            t = new BigDecimal(Math.acos(t.doubleValue()));
            tNum = t.setScale(scale, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 反正切
        if (ConstUI.OPR_COT_EXP.equalsIgnoreCase(mOpr))
        {
            BigDecimal t = new BigDecimal(rOpd);
            t = new BigDecimal(Math.atan(t.doubleValue()));
            tNum = t.setScale(scale, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 阶乘
        if (ConstUI.OPR_FAC_EXP.equals(mOpr))
        {
            BigInteger t = null;
            try
            {
                t = new BigInteger(rOpd);
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
                throw new Exception("阶乘数值只能为正整数！");
            }

            if (t.intValue() <= 0)
            {
                throw new Exception("阶乘值不能小于1！");
            }

            int i = t.intValue();
            while (--i > 1)
            {
                t = t.multiply(BigInteger.valueOf(i));
            }
            tNum = t.toString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(rOpd + mOpr);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // 10的对数
        if (ConstUI.OPR_LOG_EXP.equalsIgnoreCase(mOpr))
        {
            BigDecimal t = new BigDecimal(rOpd);
            t = new BigDecimal(Math.log10(t.doubleValue()));
            tNum = t.setScale(scale, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        // e的对数
        if (ConstUI.OPR_LNE_EXP.equalsIgnoreCase(mOpr))
        {
            BigDecimal t = new BigDecimal(rOpd);
            t = new BigDecimal(Math.log(t.doubleValue()));
            tNum = t.setScale(scale, BigDecimal.ROUND_HALF_EVEN).stripTrailingZeros().toPlainString();
            numStack.push(tNum);
            kvItem.setK(exps);
            kvItem.setV1(mOpr + rOpd);
            kvItem.setV2(tNum);
            return kvItem;
        }

        return null;
    }

    /**
     * @param num
     * @param radix
     * @param precision
     * @return
     */
    private static BigDecimal root(BigDecimal num, int radix, int precision)
    {
        BigDecimal t = BigDecimal.ONE;
        BigDecimal r = BigDecimal.ONE;
        BigDecimal e = t.subtract(num);
        BigDecimal a = new BigDecimal(radix);
        MathContext c = new MathContext(precision);
        BigDecimal p = new BigDecimal(45).pow(-precision, c);
        BigDecimal w;
        while (e.abs().compareTo(p) > 0)
        {
            t = t.subtract(e.divide(r.multiply(a), c));
            w = t;
            int k = 1;
            while (k++ < radix)
            {
                w = w.multiply(t);
            }
            r = w.divide(t);
            e = w.subtract(num);
        }
        return t;
    }

    /**
     * 算法测试方式
     * 
     * @param args
     */
    public static void main(String[] args)
    {
        try
        {
            List<K1SV2S> list = new ArrayList<K1SV2S>();
            Util.calculate("(2+3)*(3-(2+1))", 10, list);
            K1SV2S kv;
            for (int i = 0; i < list.size(); i += 1)
            {
                kv = list.get(i);
                System.out.println("=" + kv.getK());
                System.out.println("~~" + kv.getV1() + " --> " + kv.getV2());
                System.out.println();
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
