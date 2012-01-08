using System;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Utils;

namespace Me.Amon.Apwd.Win.Pro
{
    public partial class LinkCmp : UserControl, IPropCmp
    {
        private Att _Att;
        private Apro _Mpro;
        private SafeModel _SafeModel;

        public LinkCmp()
        {
            InitializeComponent();
        }

        public LinkCmp(Apro mpro, SafeModel safeModel)
        {
            _Mpro = mpro;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        #region 接口实现
        public void InitView(Border border)
        {
            border.Child = this;
        }

        public bool ShowData(Att att)
        {
            _Att = att;

            TbName.Text = _Att.Name;
            TbData.Text = _Att.Data;

            if (string.IsNullOrEmpty(_Att.Name))
            {
                TbName.Focus();
                TbName.SelectAll();
            }
            else
            {
                TbData.Focus();
                TbData.SelectAll();
            }
            return true;
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Copy()
        {
            Clipboard.SetText(TbData.Text);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Save()
        {
            _Att.Name = TbName.Text;
            _Att.Data = TbData.Text;

            _Mpro.SelectNext();
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public new void Drop()
        {

        }
        #endregion

        private void LinkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CharUtil.isValidate(TbData.Text))
            {
                HtmlPage.Window.Navigate(new Uri(TbData.Text), "__blank");
            }
        }
    }
}
