using System;
using System.Windows.Forms;
using Me.Amon.Pwd;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanHint : UserControl, IAttEdit
    {
        private Att _Att;

        #region 构造函数
        public BeanHint()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            BtName.Image = BeanUtil.NaN16;
        }

        public Control Control { get { return this; } }

        public string Title { get { return "提醒"; } }

        public bool ShowData(Att att)
        {
            _Att = att;

            if (_Att != null)
            {
                //TbName.Text = _Att.Name;
                TbData.Text = _Att.Data;
            }

            TbData.Focus();
            return true;
        }

        public void Copy()
        {
            Clipboard.SetText(TbData.Text);
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (TbData.Text != _Att.Data)
            {
                _Att.Data = TbData.Text;
                _Att.Modified = true;
            }

            return true;
        }
        #endregion

        #region 事件处理
        private void BtName_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
