using System.Collections.Generic;

namespace Me.Amon.Gtd
{
    public class MWhen : ATime
    {
        /// <summary>
        /// 参照单位
        /// </summary>
        public int ReferUnit { get; set; }

        /// <summary>
        /// 是否反向
        /// </summary>
        public bool Reverse { get; set; }

        /// <summary>
        /// 数值列表
        /// </summary>
        public List<int> Valus { get; private set; }
    }
}
