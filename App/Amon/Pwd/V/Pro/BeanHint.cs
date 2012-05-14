using System;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanHint : UserControl, IAttEdit
    {
        private APro _APro;
        private Att _Att;

        #region 构造函数
        public BeanHint()
        {
            InitializeComponent();
        }

        public BeanHint(APro apro)
        {
            _APro = apro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            BtHint.Image = BeanUtil.NaN16;
        }

        public Control Control { get { return this; } }

        public string Title { get { return "提醒"; } }

        public bool ShowData(Att att)
        {
            _Att = att;

            if (_Att != null)
            {
                //TbName.Text = _Att.Text;
                TbData.Text = _Att.Data;
            }

            TbData.Focus();
            return true;
        }

        public void Cut()
        {
            TbData.Cut();
        }

        public void Copy()
        {
            TbData.Copy();
        }

        public void Paste()
        {
            TbData.Paste();
        }

        public void Clear()
        {
            TbData.Clear();
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
