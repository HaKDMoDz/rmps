using System.Windows.Controls;
using Me.Amon.Win;

namespace Me.Amon.Views.Mopt
{
    public partial class Aopt : UserControl, IView
    {
        private MainPage _Main;

        public Aopt()
        {
            InitializeComponent();
        }

        #region 接口实现
        public string ViewName
        {
            get
            {
                return "Mopt";
            }
        }

        public bool InitView(MainPage main)
        {
            _Main = main;
            _Main.Show(this);
            return true;
        }

        public void InitData()
        {
        }
        #endregion

        private void BtNo_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BtOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Awin view = new Awin();
            view.InitView(_Main);
            view.InitData();
        }
    }
}
