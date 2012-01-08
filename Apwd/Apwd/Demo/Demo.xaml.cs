using System.Windows.Controls;
using Me.Amon.Apwd.Win.Pro;

namespace Me.Amon.Apwd.Views.Demo
{
    public partial class Demo : UserControl, IView
    {
        public Demo()
        {
            InitializeComponent();
        }

        public string ViewName
        {
            get { return "Demo"; }
        }

        public bool InitView(MainPage main)
        {
            main.Show(this);
            return true;
        }

        public void InitData()
        {
        }

        private int last;
        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (last == 0)
            {
                ShowSc2();
                last = 1;
            }
            else
            {
                ShowSc1();
                last = 0;
            }
        }

        private void ShowSc1()
        {
        }

        private void ShowSc2()
        {
        }
    }
}
