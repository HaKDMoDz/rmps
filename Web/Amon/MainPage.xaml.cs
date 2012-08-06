using System.Windows.Controls;
using Me.Amon.Utils;
using Me.Amon.Views.Demo;
using Me.Amon.Views.Mopt;

namespace Me.Amon
{
    public partial class MainPage : UserControl
    {
        private IView _View;

        public MainPage()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _View = new Home.Home();
            _View.InitView(this);
            _View.InitData();
            BeanUtil.Loading = Loading;
        }

        public void Show(UserControl control)
        {
            Body.Children.Clear();
            Body.Children.Add(control);
        }

        public void ShowUser()
        {
            DvUser.Visibility = System.Windows.Visibility.Visible;
            HbUser.Visibility = System.Windows.Visibility.Visible;

            DvOpts.Visibility = System.Windows.Visibility.Visible;
            HbOpts.Visibility = System.Windows.Visibility.Visible;
        }

        public void HideUser()
        {
            DvUser.Visibility = System.Windows.Visibility.Collapsed;
            HbUser.Visibility = System.Windows.Visibility.Collapsed;

            DvOpts.Visibility = System.Windows.Visibility.Collapsed;
            HbOpts.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void HbUser_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _View = new Home.Home();
            _View.InitView(this);
            _View.InitData();
            DvOpts.Visibility = System.Windows.Visibility.Collapsed;
            HbOpts.Visibility = System.Windows.Visibility.Collapsed;
            DvUser.Visibility = System.Windows.Visibility.Collapsed;
            HbUser.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void HbOpts_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_View.ViewName != "Mopt")
            {
                _View = new Aopt();
                _View.InitView(this);
                _View.InitData();
            }
        }

        private void HbDemo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_View.ViewName != "Demo")
            {
                _View = new Demo();
                _View.InitView(this);
                _View.InitData();
            }
            else
            {
                _View = new Home.Home();
                _View.InitView(this);
                _View.InitData();
            }
        }
    }
}
