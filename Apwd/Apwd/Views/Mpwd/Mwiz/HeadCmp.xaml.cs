using System.Windows;
using System.Windows.Controls;
using Me.Amon.Apwd.Comn;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Model.Atts;
using Me.Amon.Apwd.Utils;

namespace Me.Amon.Apwd.Views.Mpwd.Mwiz
{
    public partial class HeadCmp : UserControl, ICardCtl
    {
        private Mwiz _Mwiz;
        private SafeModel _SafeModel;
        private TextBox _TextBox;

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public HeadCmp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mwiz"></param>
        /// <param name="safeModel"></param>
        public HeadCmp(Mwiz mwiz, SafeModel safeModel)
        {
            _Mwiz = mwiz;
            _SafeModel = safeModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        public void InitView(Grid grid)
        {
            //grid.Children.Add(this);
            //SetValue(Grid.RowProperty, 0);
            //SetValue(Grid.ColumnProperty, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        public void HideView(Grid grid)
        {
            //grid.Children.Remove(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowData()
        {
            GuidAtt guid = _SafeModel.Guid;
            if (guid == null)
            {
                return;
            }

            CbLibName.ItemsSource = _SafeModel.LibKey;
            string libId = guid.GetSpec(GuidAtt.SPEC_GUID_TPLT);
            LibHeader lib;
            foreach (var item in CbLibName.Items)
            {
                lib = item as LibHeader;
                if (lib.Id == libId)
                {
                    CbLibName.SelectedItem = item;
                }
            }

            MetaAtt meta = _SafeModel.Meta;
            if (meta == null)
            {
                return;
            }
            TbMetaName.Text = meta.Name;
            TaMetaData.Text = meta.Data;

            LogoAtt logo = _SafeModel.Logo;
            if (logo == null)
            {
                return;
            }
            TbLogoData.Text = logo.Data;

            HintAtt hint = _SafeModel.Hint;
            if (hint == null)
            {
                return;
            }
            TbHintData.Text = hint.Data;

            CbLibName.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SaveData()
        {
            if (_SafeModel.Key == null)
            {
                return false;
            }

            LibHeader lib = CbLibName.SelectedItem as LibHeader;
            if (lib == null || !CharUtil.isValidateHash(lib.Id))
            {
                BeanUtil.ShowAlert("请选择您要使用的模板！");
                CbLibName.Focus();
                return false;
            }

            string name = TbMetaName.Text;
            if (!CharUtil.isValidate(name))
            {
                BeanUtil.ShowAlert("请输入口令标题！");
                TbMetaName.Focus();
                return false;
            }

            GuidAtt guid = _SafeModel.Guid;
            if (lib.Id != guid.GetSpec(GuidAtt.SPEC_GUID_TPLT))
            {
                guid.SetSpec(GuidAtt.SPEC_GUID_TPLT, lib.Id);
                if (!_SafeModel.Key.IsUpdate)
                {
                    _SafeModel.InitData(lib);
                }
            }

            MetaAtt meta = _SafeModel.Meta;
            meta.Name = TbMetaName.Text;
            meta.Data = TaMetaData.Text;

            LogoAtt logo = _SafeModel.Logo;
            logo.Name = "";
            logo.Data = TbLogoData.Text;

            HintAtt hint = _SafeModel.Hint;
            hint.Name = "";
            hint.Data = TbHintData.Text;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CopyData()
        {
            if (_TextBox != null)
            {
                Clipboard.SetText(_TextBox.Text);
            }
        }
        #endregion

        #region 焦点事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbLibName_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            _TextBox = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbMetaName_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            _TextBox = TbMetaName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaMetaData_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            _TextBox = TaMetaData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbLogoData_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            _TextBox = TbLogoData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbHintData_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            _TextBox = TbHintData;
        }
        #endregion
    }
}
