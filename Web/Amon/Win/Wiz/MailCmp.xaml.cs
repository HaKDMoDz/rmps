using System;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using Me.Amon.Model;
using Me.Amon.Utils;

namespace Me.Amon.Win.Wiz
{
    public partial class MailCmp : UserControl, IEditCtl
    {
        private Att _Att;
        private TextBlock _Label;
        private BodyCmp _BodyCmp;
        private RowDefinition _RowDef = new RowDefinition() { Height = new GridLength(27) };

        #region 构造函数
        public MailCmp()
        {
            InitializeComponent();
        }

        public MailCmp(BodyCmp bodyCmp)
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
                TbData.Text = _Att.Data;
            }
            return true;
        }

        public void Copy()
        {
            Clipboard.SetText(TbData.Text);
        }

        public void Save()
        {
            if (_Att != null)
            {
                _Att.Data = TbData.Text;
            }
        }
        #endregion

        private void TbData_GotFocus(object sender, RoutedEventArgs e)
        {
            _BodyCmp.EditCtl = this;
            TbData.SelectAll();
        }

        private void MailBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CharUtil.isValidate(TbData.Text))
            {
                HtmlPage.Window.Navigate(new Uri(TbData.Text), "__blank");
            }
        }
    }
}
