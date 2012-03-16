using System.Collections.ObjectModel;
using Me.Amon.Bean;

namespace Me.Amon.Sec
{
    public class DataModel
    {
        #region 字符集
        private ObservableCollection<Udc> _UdcList;
        public ObservableCollection<Udc> UdcList
        {
            get
            {
                return _UdcList;
            }
        }
        public int UdcModified { get; set; }
        private string _UcsKey;
        public Udc UdcDefault { get; set; }
        public int UdcLength { get; set; }
        #endregion
    }
}
