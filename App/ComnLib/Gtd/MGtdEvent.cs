using System.Collections.Generic;

namespace Me.Amon.Gtd
{
    public class MGtdEvent
    {
        #region 事件信息
        public List<int> Events { get; private set; }
        #endregion

        public MGtdEvent()
        {
            Events = new List<int>();
        }

        public void Init()
        {
        }

        public bool Test()
        {
            return false;
        }
    }
}
