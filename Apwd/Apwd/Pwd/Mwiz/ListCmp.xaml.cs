using System.Windows;
using System.Windows.Controls;
using Me.Amon.Apwd.Model;

namespace Me.Amon.Apwd.Views.Mpwd.Mwiz
{
    public partial class ListCmp : UserControl, IEditCtl
    {
        private Att _Att;
        private TextBlock _Label;
        private BodyCmp _BodyCmp;
        private RowDefinition _RowDef = new RowDefinition() { Height = new GridLength(27) };

        #region 构造函数
        public ListCmp()
        {
            InitializeComponent();
        }

        public ListCmp(BodyCmp bodyCmp)
        {
            _BodyCmp = bodyCmp;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitView(Grid grid, int row)
        {
            if (_Label == null)
            {
                _Label = new TextBlock();
            }

            grid.RowDefinitions.Add(_RowDef);

            grid.Children.Add(_Label);
            _Label.SetValue(Grid.RowProperty, row);
            _Label.SetValue(Grid.ColumnProperty, 0);

            grid.Children.Add(this);
            SetValue(Grid.RowProperty, row);
            SetValue(Grid.ColumnProperty, 1);
        }

        public bool ShowData(Att att)
        {
            _Att = att;
            if (_Att != null)
            {
                _Label.Text = _Att.Name;
                //textBox1.Text = att.Data;
            }
            return true;
        }

        public void Copy()
        {
            //Clipboard.SetText(TextBox);
        }

        public void Save()
        {
            if (_Att != null)
            {
            }
        }
        #endregion

        private void comboBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            _BodyCmp.EditCtl = this;
        }
    }
}
