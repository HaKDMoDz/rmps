using System.Windows.Controls;

namespace Me.Amon.Apwd.Views.Mopt
{
    public partial class Mopt : UserControl, IView
    {
        private MainPage _Main;

        public Mopt()
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
            Mpwd.Mpwd view = new Mpwd.Mpwd();
            view.InitView(_Main);
            view.InitData();
        }
    }
}
