using System;

namespace rmp.bean
{
    /// <summary>
    /// K1V2 的摘要说明
    /// </summary>
    public class K1V2
    {
        private String k;
        private String v1;
        private String v2;

        public K1V2()
        {
        }

        public K1V2(String k, String v1, String v2)
        {
            this.k = k;
            this.v1 = v1;
            this.v2 = v2;
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

        public String V1
        {
            get
            {
                return v1;
            }
            set
            {
                v1 = value;
            }
        }

        public String V2
        {
            get
            {
                return v2;
            }
            set
            {
                v2 = value;
            }
        }
    }
}