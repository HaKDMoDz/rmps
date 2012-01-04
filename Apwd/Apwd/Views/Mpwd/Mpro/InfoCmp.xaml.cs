using System.Windows.Controls;
using Me.Amon.Apwd.Comn;
using Me.Amon.Apwd.Model;

namespace Me.Amon.Apwd.Views.Mpwd.Mpro
{
    public partial class InfoCmp : UserControl, IPropCmp
    {
        public InfoCmp()
        {
            InitializeComponent();
        }

        public InfoCmp(Mpro mpro, SafeModel safeModel)
        {
            InitializeComponent();
        }

        #region 接口实现
        public void InitView(Border border)
        {
            border.Child = this;
        }

        public bool ShowData(Att att)
        {
            return true;
        }
        #endregion

        public void Copy()
        {
        }

        public void Save()
        {
        }

        public new void Drop()
        {
        }
    }
}
