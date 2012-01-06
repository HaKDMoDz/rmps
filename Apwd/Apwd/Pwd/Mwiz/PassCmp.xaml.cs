using System.Windows;
using System.Windows.Controls;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Utils;

namespace Me.Amon.Apwd.Views.Mpwd.Mwiz
{
    public partial class PassCmp : UserControl, IEditCtl
    {
        private Att _Att;
        private TextBlock _Label;
        private BodyCmp _BodyCmp;
        private RowDefinition _RowDef = new RowDefinition() { Height = new GridLength(27) };

        #region 构造函数
        public PassCmp()
        {
            InitializeComponent();
        }

        public PassCmp(BodyCmp bodyCmp)
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
                TbData.Password = _Att.Data;
            }
            return true;
        }

        public void Copy()
        {
            Clipboard.SetText(TbData.Password);
        }

        public void Save()
        {
            if (_Att != null)
            {
                _Att.Data = TbData.Password;
            }
        }
        #endregion

        private void TbData_GotFocus(object sender, RoutedEventArgs e)
        {
            _BodyCmp.EditCtl = this;
            TbData.SelectAll();
        }

        private void MaskBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (TbData.PasswordChar == '\0')
            //{
            //    TbData.PasswordChar = '●';
            //MaskImg.Source = new BitmapImage(new System.Uri("/img/pass-view.png"));
            //}
            //else
            //{
            //    TbData.PasswordChar = '\0';
            //MaskImg.Source = new BitmapImage(new System.Uri("/img/pass-mask.png"));
            //}
        }

        private void GenBtn_Click(object sender, RoutedEventArgs e)
        {
            TbData.Password = new string(CharUtil.GenerateUserChar());
        }

        private void OptBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
