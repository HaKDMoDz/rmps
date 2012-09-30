using System.Windows.Controls;

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

        private void treeView1_Drop(object sender, System.Windows.DragEventArgs e)
        {
        }

        private void treeView1_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
        }
    }
}
