using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

using cons.prp.aide.P3060000;
using rmp.bean;
using rmp.prp.aide.P3060000.b;

namespace rmp.prp.aide.P3060000.t
{
    public class Mc
    {
        /// <summary>
        /// 计算公式
        /// </summary>
        private String mathExps;
        /// <summary>
        /// 计算精度
        /// </summary>
        private readonly int decimals;
        /// <summary>
        /// 计算过程
        /// </summary>
        private readonly ArrayList stepList;

        /// <summary>
        /// 操作数堆栈
        /// </summary>
        private Stack numStack;
        /// <summary>
        /// 操作符堆栈
        /// </summary>
        private Stack oprStack;
        /// <summary>
        /// 操作符标记
        /// </summary>
        private bool lastIsOpr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mathExps"></param>
        /// <param name="decimals"></param>
        /// <param name="stepList"></param>
        public Mc(String mathExps, int decimals, ArrayList stepList)
        {
            this.mathExps = mathExps;
            this.decimals = decimals;
            this.stepList = stepList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String calculate()
        {
            if (mathExps == null || mathExps == "")
            {
                throw new Exception("表达式为空！");
            }

            mathExps = mathExps.Replace(" ", "").Trim();
            Regex regex = new Regex("=[=]*=");
            mathExps = regex.Replace(mathExps, "=");
            if (mathExps == "" || mathExps == "=")
            {
                throw new Exception("请输入一个完整的运算表达式！");
            }

            if (mathExps.EndsWith("="))
            {
                mathExps = mathExps.Substring(0, mathExps.Length - 1);
            }

            int edx = mathExps.LastIndexOf('=') + 1;
            mathExps = mathExps.Substring(edx, mathExps.Length - edx);

            // 操作数堆栈
            numStack = new Stack();
            // numStack.Push("0");
            // 操作符堆栈
            oprStack = new Stack();
            // oprStack.Push(new Op());

            // 操作数缓冲区
            StringBuilder numBuf = new StringBuilder();
            // 操作符缓冲区
            StringBuilder oprBuf = new StringBuilder();
            // 表达式字符串
            char[] expBuf = ('(' + mathExps + ')').ToCharArray();
            // 临时字符串
            String tmpOpr;
            // 上一个字符（串）是否为操作符，true表示是；false表示否
            lastIsOpr = false;

            // 循环处理每一个表达式字符
            foreach (char c in expBuf)
            {
                // 负号
                if (lastIsOpr && (c == '-' || c == '+'))
                {
                    if (oprBuf.Length != 0)
                    {
                        throw new Exception(String.Format("计算错误：未知运算符 “{0}”，请确认您输入计算式的正确性！", oprBuf));
                    }
                    lastIsOpr = false;
                    numBuf.Append(c);
                    continue;
                }

                // 操作数
                if ((c >= '0' && c <= '9') || c == '.')
                {
                    if (oprBuf.Length != 0)
                    {
                        throw new Exception(String.Format("计算错误：未知运算符 “{0}”，请确认您输入计算式的正确性！", oprBuf));
                    }
                    lastIsOpr = false;
                    numBuf.Append(c);
                    continue;
                }

                // e
                if (c == 'ê')
                {
                    if (oprBuf.Length != 0)
                    {
                        throw new Exception(String.Format("计算错误：未知运算符 “{0}”，请确认您输入计算式的正确性！", oprBuf));
                    }
                    lastIsOpr = false;
                    String ep = Decimal.Round(new Decimal(Math.E), decimals).ToString();
                    numBuf.Append(ep);
                    mathExps = mathExps.Replace("ê", ep);
                    continue;
                }

                // π
                if (c == 'π')
                {
                    if (oprBuf.Length != 0)
                    {
                        throw new Exception(String.Format("计算错误：未知运算符 “{0}”，请确认您输入计算式的正确性！", oprBuf));
                    }
                    lastIsOpr = false;
                    String ep = Decimal.Round(new Decimal(Math.PI), decimals).ToString();
                    numBuf.Append(ep);
                    mathExps = mathExps.Replace("π", ep);
                    continue;
                }

                // 操作符
                tmpOpr = oprBuf.Append(c).ToString();

                // 左括号
                if (lbtExp(tmpOpr, oprBuf, numBuf))
                {
                    continue;
                }

                // 右括号
                if (rbtExp(tmpOpr, oprBuf, numBuf))
                {
                    continue;
                }

                // 运算符运算
                for (int i = 0, j = OPR_EXP.Length; i < j; i += 1)
                {
                    if (OPR_EXP[i] == tmpOpr.ToLower())
                    {
                        lastIsOpr = ConstUI.OPR_FAC_EXP != tmpOpr;
                        // 清除当前操作符
                        oprBuf.Remove(0, oprBuf.Length);

                        // 左操作数不为空的情况下，左操作数入栈
                        if (numBuf.Length > 0)
                        {
                            numStack.Push(numBuf.ToString());
                            numBuf.Remove(0, numBuf.Length);
                        }

                        K1V2 kvItem = null;
                        // 当前运算符
                        Op newOpr = new Op(tmpOpr, OPR_INT[i]);

                        // 循环处理每一个操作符
                        while (true)
                        {
                            // 操作符级别判断
                            if (newOpr.getL() > ((Op)oprStack.Peek()).getL())
                            {
                                oprStack.Push(newOpr);
                                break;
                            }

                            // 运算结果
                            kvItem = calculate(mathExps, decimals);
                            // 统计运算步骤
                            if (stepList != null)
                            {
                                stepList.Add(kvItem);
                                mathExps = mathExps.Replace(kvItem.V1, kvItem.V2);
                            }
                        }
                        break;
                    }
                }
            }

            if (oprStack.Count > 0)
            {
                throw new Exception("表达式存在错误，系统无法计算！");
            }

            return numStack.Count != 0 ? Decimal.Round(Decimal.Parse((String)numStack.Pop()), decimals).ToString() : "";
        }

        /**
         * 双目运算符运算
         * 
         * @param opr 操作符
         * @param decimals 计算精度
         * @param opds 操作数
         * @return
         */
        private K1V2 calculate(String mathExps, int decimals) //throws Exception
        {
            String lOpd = null;
            String mOpr = ((Op)oprStack.Pop()).getS();
            String rOpd = (String)numStack.Pop();
            String tNum;

            K1V2 kvItem = new K1V2();

            // 加
            if (ConstUI.OPR_ADD_EXP == mOpr)
            {
                lOpd = (String)numStack.Pop();
                tNum = Decimal.Add(Decimal.Parse(lOpd), Decimal.Parse(rOpd)).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = lOpd + mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 减
            if (ConstUI.OPR_SUB_EXP == mOpr)
            {
                lOpd = (String)numStack.Pop();
                tNum = Decimal.Subtract(Decimal.Parse(lOpd), Decimal.Parse(rOpd)).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = lOpd + mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 乘
            if (ConstUI.OPR_MUL_EXP == mOpr)
            {
                lOpd = (String)numStack.Pop();
                tNum = Decimal.Multiply(Decimal.Parse(lOpd), Decimal.Parse(rOpd)).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = lOpd + mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 除
            if (ConstUI.OPR_DIV_EXP == mOpr)
            {
                Decimal t = Decimal.Parse(rOpd);
                if (t.CompareTo(Decimal.Zero) == 0)
                {
                    throw new Exception("除数为0");
                }
                lOpd = (String)numStack.Pop();
                tNum = Decimal.Divide(Decimal.Parse(lOpd), t).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = lOpd + mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 取模
            if (ConstUI.OPR_MOD_EXP == mOpr)
            {
                Decimal t = Decimal.Parse(rOpd);
                if (t.CompareTo(Decimal.Zero) == 0)
                {
                    throw new Exception("除数为0");
                }
                lOpd = (String)numStack.Pop();
                tNum = Decimal.Remainder(Decimal.Parse(lOpd), t).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = lOpd + mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 次幂
            if (ConstUI.OPR_POW_EXP == mOpr)
            {
                try
                {
                    int t = Decimal.ToInt32(Decimal.Parse(rOpd));
                    lOpd = (String)numStack.Pop();
                    tNum = Math.Pow(Decimal.ToDouble(Decimal.Parse(lOpd)), Decimal.ToDouble(t)).ToString();
                    numStack.Push(tNum);
                    kvItem.K = mathExps;
                    kvItem.V1 = lOpd + mOpr + rOpd;
                    kvItem.V2 = tNum;
                    return kvItem;
                }
                catch (ArithmeticException)
                {
                    throw new Exception(String.Format("次幂时，指数{0}应为一个整数！", rOpd));
                }
            }

            // 方根
            if (ConstUI.OPR_ROT_EXP == mOpr)
            {
                lOpd = (String)numStack.Pop();
                Decimal tl = Decimal.Parse(rOpd);
                Decimal tr = Decimal.Divide(Decimal.Zero, Decimal.Parse(lOpd));
                tNum = Math.Pow(Decimal.ToDouble(tl), Decimal.ToDouble(tr)).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = lOpd + mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 正弦
            if (ConstUI.OPR_SIN_EXP == mOpr.ToLower())
            {
                Decimal t = Decimal.Parse(rOpd);
                tNum = Decimal.Round(new Decimal(Math.Sin(Decimal.ToDouble(t))), decimals).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 余弦
            if (ConstUI.OPR_COS_EXP == mOpr.ToLower())
            {
                Decimal t = Decimal.Parse(rOpd);
                tNum = Decimal.Round(new Decimal(Math.Cos(Decimal.ToDouble(t))), decimals).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 正切
            if (ConstUI.OPR_TAN_EXP == mOpr.ToLower())
            {
                Decimal t = Decimal.Parse(rOpd);
                tNum = Decimal.Round(new Decimal(Math.Tan(Decimal.ToDouble(t))), decimals).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 正割
            if (ConstUI.OPR_SEC_EXP == mOpr.ToLower())
            {
                Decimal t = Decimal.Parse(rOpd);
                tNum = Decimal.Round(new Decimal(Math.Asin(Decimal.ToDouble(t))), decimals).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 余割
            if (ConstUI.OPR_CSC_EXP == mOpr.ToLower())
            {
                Decimal t = Decimal.Parse(rOpd);
                tNum = Decimal.Round(new Decimal(Math.Acos(Decimal.ToDouble(t))), decimals).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 反正切
            if (ConstUI.OPR_COT_EXP == mOpr.ToLower())
            {
                Decimal t = Decimal.Parse(rOpd);
                tNum = Decimal.Round(new Decimal(Math.Atan(Decimal.ToDouble(t))), decimals).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 阶乘
            if (ConstUI.OPR_FAC_EXP == mOpr)
            {
                int t = 0;
                try
                {
                    t = Int32.Parse(rOpd);
                }
                catch (Exception)
                {
                    throw new Exception("阶乘数值只能为正整数！");
                }

                if (t <= 0)
                {
                    throw new Exception("阶乘值不能小于1！");
                }
                if (t > 27)
                {
                    throw new Exception("暂时不支持大于27的阶乘值！");
                }

                Decimal d = Decimal.One;
                while (t > 1)
                {
                    d = Decimal.Multiply(d, new Decimal(t--));
                }
                tNum = d.ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = rOpd + mOpr;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // 10的对数
            if (ConstUI.OPR_LOG_EXP == mOpr.ToLower())
            {
                Decimal t = Decimal.Parse(rOpd);
                tNum = Decimal.Round(new Decimal(Math.Log10(Decimal.ToDouble(t))), decimals).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            // e的对数
            if (ConstUI.OPR_LNE_EXP == mOpr.ToLower())
            {
                Decimal t = Decimal.Parse(rOpd);
                tNum = Decimal.Round(new Decimal(Math.Log(Decimal.ToDouble(t))), decimals).ToString();
                numStack.Push(tNum);
                kvItem.K = mathExps;
                kvItem.V1 = mOpr + rOpd;
                kvItem.V2 = tNum;
                return kvItem;
            }

            return null;
        }

        /// <summary>
        /// 左括号
        /// </summary>
        /// <param name="lbt"></param>
        /// <param name="tmpOpr"></param>
        /// <returns></returns>
        private bool lbtExp(String tmpOpr, StringBuilder oprBuf, StringBuilder numBuf)
        {
            for (int i = 0, j = LBT_EXP.Length; i < j; i += 1)
            {
                if (LBT_EXP[i] == tmpOpr)
                {
                    lastIsOpr = true;
                    // 清除当前操作符
                    oprBuf.Remove(0, oprBuf.Length);

                    // 左操作数不为空的情况下，左操作数入栈
                    if (numBuf.Length > 0)
                    {
                        numStack.Push(numBuf.ToString());
                        numBuf.Remove(0, numBuf.Length);
                    }

                    // 操作符入栈
                    oprStack.Push(new Op(tmpOpr, LBT_INT[i]));

                    return true;
                }
            }
            return false;
        }

        private bool rbtExp(String tmpOpr, StringBuilder oprBuf, StringBuilder numBuf)
        {
            for (int i = 0, j = RBT_EXP.Length; i < j; i += 1)
            {
                if (RBT_EXP[i] == tmpOpr)
                {
                    if (lastIsOpr)
                    {
                        throw new Exception("缺少操作数，请确认您输入表达式的是否正确！");
                    }

                    lastIsOpr = false;
                    // 清除当前操作符
                    oprBuf.Remove(0, oprBuf.Length);

                    if (numBuf.Length > 0)
                    {
                        numStack.Push(numBuf.ToString());
                        numBuf.Remove(0, numBuf.Length);
                    }

                    K1V2 kvItem;

                    // 循环处理每一个操作符
                    while (true)
                    {
                        if (lbtInt(tmpOpr, (Op)oprStack.Peek(), i))
                        {
                            break;
                        }

                        // 运算结果
                        kvItem = calculate(mathExps, decimals);
                        // 统计运算步骤
                        if (stepList != null)
                        {
                            stepList.Add(kvItem);
                            mathExps = mathExps.Replace(kvItem.V1, kvItem.V2);
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        private bool lbtInt(String tmpOpr, Op o, int i)
        {
            for (int m = 0, n = LBT_EXP.Length; m < n; m += 1)
            {
                if (LBT_EXP[m] == o.getS())
                {
                    // 操作符级别判断
                    if (LBT_INT[m] + 7 == RBT_INT[i])
                    {
                        oprStack.Pop();
                        if (stepList != null)
                        {
                            String t = (String)numStack.Peek();
                            String p = LBT_EXP[m] + t + RBT_EXP[m];
                            stepList.Add(new K1V2(mathExps, p, t));
                            mathExps = mathExps.Replace(p, t);
                        }
                        return true;
                    }
                    throw new Exception(String.Format("您输入的表达式不正确：{0}与{1}不匹配！", LBT_EXP[m], tmpOpr));
                }
            }
            return false;
        }

        // 左括号
        private static readonly String[] LBT_EXP = {
                ConstUI.OPR_SLB_EXP,//
                ConstUI.OPR_MLB_EXP,//
                ConstUI.OPR_LLB_EXP,//
            };
        private static readonly int[] LBT_INT = {
                ConstUI.OPR_SLB_INT,//
                ConstUI.OPR_MLB_INT,//
                ConstUI.OPR_LLB_INT,//
            };
        // 右括号
        private static readonly String[] RBT_EXP = {
                ConstUI.OPR_SRB_EXP,//
                ConstUI.OPR_MRB_EXP,//
                ConstUI.OPR_LRB_EXP,//
            };
        private static readonly int[] RBT_INT = {
                ConstUI.OPR_SRB_INT,//
                ConstUI.OPR_MRB_INT,//
                ConstUI.OPR_LRB_INT,//
            };

        // 操作符
        private static readonly String[] OPR_EXP = {
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
        private static readonly int[] OPR_INT = {
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
    }
}