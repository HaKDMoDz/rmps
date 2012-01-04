using System;

namespace rmp.bean
{
    /// <summary>
    /// K1SV1S 的摘要说明
    /// </summary>
    public class K1V1
    {
        private String k;
        private String v;

        public K1V1()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        /// <param name="v"></param>
        public K1V1(String k, String v)
        {
            this.k = k;
            this.v = v;
        }

        public String K
        {
            get
            {
                return k;
            }
            set
            {
                k = value;
            }
        }

        public String V
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
            }
        }

        public String toString()
        {
            return v;
        }
    }
}