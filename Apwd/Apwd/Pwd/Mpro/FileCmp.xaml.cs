using System.Windows;
using System.Windows.Controls;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Comn;

namespace Me.Amon.Apwd.Views.Mpwd.Mpro
{
    public partial class FileCmp : UserControl, IPropCmp
    {
        private Att _Att;
        private Mpro _Mpro;
        private SafeModel _SafeModel;

        public FileCmp()
        {
            InitializeComponent();
        }

        public FileCmp(Mpro mpro, SafeModel safeModel)
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

        private void SaveasBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UploadBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
