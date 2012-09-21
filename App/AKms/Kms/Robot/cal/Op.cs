using System;

namespace Me.Amon.Kms.Robot.cal
{
    /// <summary>
    /// WOperator 的摘要说明
    /// </summary>
    public class Op
    {
        /**
         * 
         */
        public Op()
        {
            S = ConstUI.OPR_ADD_EXP;
            L = ConstUI.OPR_ADD_INT;
        }

        /**
         * @param s
         * @param l
         */
        public Op(String s, int l)
        {
            S = s;
            L = l;
        }

        /**
         * 运算符
         * 
         * @return the s
         */
        public String S { get; set; }

        /**
         * 运算符级别
         * 
         * @return the l
         */
        public int L { get; set; }
    }
}