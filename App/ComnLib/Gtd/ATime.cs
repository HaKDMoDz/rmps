using System;
using System.Collections.Generic;

namespace Me.Amon.Gtd
{
    public abstract class ATime
    {
        public int Type { get; set; }

        public int Unit { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public int MaxValue { get; protected set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public int MinValue { get; protected set; }

        public List<int> Values { get; private set; }

        public ATime()
        {
            Values = new List<int>();
        }

        public abstract bool Next(DateTime time, bool restart);
    }
}
