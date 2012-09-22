using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;
using Me.Amon.Uc;

namespace Me.Amon.Kms.Training.Opt
{
    public partial class BaseInfo : UserControl, IOptions
    {
        private Training _target;
        private DataModel _DataModel;

        #region 构造函数
        public BaseInfo()
        {
            InitializeComponent();
        }

        public BaseInfo(Training target, DataModel dataModel)
        {
            _target = target;
            _DataModel = dataModel;

            InitializeComponent();
        }
        #endregion

        #region IOptions 成员

        public void Init()
        {
            CbLanguage.Items.Add(new MLanguage { C1010103 = "0", C1010106 = "全部" });
            CbLanguage.Items.AddRange(_DataModel.ListLanguage().ToArray());
            CbLanguage.SelectedIndex = 0;

            CbStyle.Items.Add(new ListModel<EStyle>(EStyle.Elegant, "高雅"));
            CbStyle.Items.Add(new ListModel<EStyle>(EStyle.Humors, "幽默"));
            CbStyle.Items.Add(new ListModel<EStyle>(EStyle.Normal, "默认"));
            CbStyle.Items.Add(new ListModel<EStyle>(EStyle.Vulgar, "低俗"));
            CbStyle.Items.Add(new ListModel<EStyle>(EStyle.Revile, "脏话"));
            CbStyle.SelectedIndex = 2;
        }

        public void ReInit(MSentence question, MSentence response)
        {
        }

        public UserControl GetControl()
        {
            return this;
        }

        #endregion

        #region 用户事件
        private void CbLanguage_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_target == null)
            {
                return;
            }

            MLanguage lang = CbLanguage.SelectedItem as MLanguage;
            if (lang == null)
            {
                return;
            }

            _target.ChangeLanguage(lang.C1010103);
        }

        private void CbStyle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            ListModel<EStyle> item = CbStyle.SelectedItem as ListModel<EStyle>;
            if (item == null)
            {
                return;
            }

            _target.ChangeStyle(item.K);
        }
        #endregion
    }
}
