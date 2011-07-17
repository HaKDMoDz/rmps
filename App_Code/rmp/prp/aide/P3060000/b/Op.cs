using System;

using cons.prp.aide.P3060000;

namespace rmp.prp.aide.P3060000.b
{
    /// <summary>
    /// WOperator 的摘要说明
    /// </summary>
    public class Op
    {
        /** 运算符 */
        private String s;
        /** 运算符级别 */
        private readonly int l;

        /**
         * 
         */
        public Op()
        {
            s = ConstUI.OPR_ADD_EXP;
            l = ConstUI.OPR_ADD_INT;
        }

        /**
         * @param s
         * @param l
         */
        public Op(String s, int l)
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
}