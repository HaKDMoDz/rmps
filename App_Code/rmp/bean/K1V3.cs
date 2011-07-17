using System;

namespace rmp.bean
{
    /// <summary>
    /// K1V2 的摘要说明
    /// </summary>
    public class K1V3
    {
        private String k;
        private String v1;
        private String v2;
        private String v3;

        public K1V3()
        {
        }

        public K1V3(String k, String v1, String v2, String v3)
        {
            this.k = k;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
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

        public String V3
        {
            get
            {
                return v3;
            }
            set
            {
                v3 = value;
            }
        }
    }
}