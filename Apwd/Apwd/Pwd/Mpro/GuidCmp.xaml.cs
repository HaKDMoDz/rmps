using System.Windows.Controls;
using Me.Amon.Apwd.Comn;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Model.Atts;
using Me.Amon.Apwd.Utils;

namespace Me.Amon.Apwd.Views.Mpwd.Mpro
{
    public partial class GuidCmp : UserControl, IPropCmp
    {
        private Mpro _Mpro;
        private GuidAtt _GuidAtt;
        private SafeModel _SafeModel;

        #region 构造函数
        public GuidCmp()
        {
            InitializeComponent();
        }

        public GuidCmp(Mpro mpro, SafeModel safeModel)
        {
            _Mpro = mpro;
            _SafeModel = safeModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        /// <summary>
        /// 视图展示
        /// </summary>
        /// <param name="grid"></param>
        public void InitView(Border border)
        {
            border.Child = this;
        }

        /// <summary>
        /// 数据展示
        /// </summary>
        /// <param name="att"></param>
        /// <returns></returns>
        public bool ShowData(Att att)
        {
            _GuidAtt = (GuidAtt)att;

            cbName.ItemsSource = _SafeModel.LibKey;

            string libId = _GuidAtt.GetSpec(GuidAtt.SPEC_GUID_TPLT);
            LibHeader lib;
            foreach (var item in cbName.Items)
            {
                lib = item as LibHeader;
                if (lib.Id == libId)
                {
                    cbName.SelectedItem = item;
                }
            }
            cbName.Focus();
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
            if (_SafeModel.Key == null)
            {
                return;
            }

            LibHeader lib = cbName.SelectedItem as LibHeader;
            if (lib == null || !CharUtil.isValidateHash(lib.Id))
            {
                BeanUtil.ShowAlert("请选择您要使用的模板！");
                cbName.Focus();
                return;
            }

            _GuidAtt.SetSpec(GuidAtt.SPEC_GUID_TPLT, lib.Id);

            if (!_SafeModel.Key.IsUpdate)
            {
                _SafeModel.InitMeta();
                _SafeModel.InitLogo();
                _SafeModel.InitHint();
                _SafeModel.InitData(lib);
            }
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
