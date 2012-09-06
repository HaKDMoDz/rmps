using System;
using System.Collections.Generic;

namespace Me.Amon.Gtd
{
    public abstract class ADates
    {
        /// <summary>
        /// 重复方式
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 重复单位
        /// </summary>
        public int Unit { get; set; }
        /// <summary>
        /// 数值
        /// </summary>
        public List<int> Values { get; private set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public int MaxValue { get; protected set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public int MinValue { get; protected set; }
        /// <summary>
        /// 是否反向
        /// </summary>
        public bool Reverse { get; set; }

        public ADates()
        {
            Values = new List<int>();
        }

        public abstract DateTime Next(DateTime time, out bool changed);

        protected int NextValue(int key, bool equals)
        {
            foreach (int tmp in Values)
            {
                if (key < tmp)
                {
                    return tmp - key;
                }
                if (key == tmp && equals)
                {
                    return 0;
                }
            }
            return -1;
        }
    }
}
