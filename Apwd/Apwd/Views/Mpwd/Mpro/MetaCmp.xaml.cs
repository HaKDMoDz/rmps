using System.Windows;
using System.Windows.Controls;
using Me.Amon.Apwd.Comn;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Utils;

namespace Me.Amon.Apwd.Views.Mpwd.Mpro
{
    public partial class MetaCmp : UserControl, IPropCmp
    {
        private Att _Att;
        private Mpro _Mpro;
        private SafeModel _SafeModel;

        public MetaCmp()
        {
            InitializeComponent();
        }

        public MetaCmp(Mpro mpro, SafeModel safeModel)
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
                TbName.SelectAll();
                TbName.Focus();
            }
            else
            {
                TbData.SelectAll();
                TbData.Focus();
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
            string name = TbName.Text;
            if (!CharUtil.isValidate(name))
            {
                BeanUtil.ShowAlert("请输入口令标题！");
                TbName.Focus();
                return;
            }

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
    }
}
