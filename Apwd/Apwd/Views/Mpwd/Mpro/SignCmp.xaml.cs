using System.Windows.Controls;
using Me.Amon.Apwd.Comn;
using Me.Amon.Apwd.Model;

namespace Me.Amon.Apwd.Views.Mpwd.Mpro
{
    public partial class SignCmp : UserControl, IPropCmp
    {
        private Att _Att;
        private Mpro _Mpro;
        private SafeModel _SafeModel;

        public SignCmp()
        {
            InitializeComponent();
        }

        public SignCmp(Mpro mpro, SafeModel safeModel)
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

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Save()
        {
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

        private void SignBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
