using System;

namespace rmp.bean
{
    /// <summary>
    ///I1S1 的摘要说明
    /// </summary>
    public class I1S1
    {
        private int k;
        private String v;

        public I1S1()
        {
        }

        public I1S1(int k, String v)
        {
            this.k = k;
            this.v = v;
        }

        public int K
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