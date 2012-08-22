using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pwd.Bean;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Wiz
{
    public partial class BeanPass : APass, IAttEdit
    {
        private BeanBody _Body;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;

        #region 构造函数
        public BeanPass()
        {
            InitializeComponent();
        }

        public BeanPass(BeanBody body)
        {
            _Body = body;

            InitializeComponent();
        }

        public void InitOnce(TableLayoutPanel grid, ViewModel viewModel)
        {
            _Grid = grid;
            _ViewModel = viewModel;
            _Style = new RowStyle(SizeType.Absolute, 27F);

            Dock = DockStyle.Fill;

            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtMod.Image = viewModel.GetImage(TbData.UseSystemPasswordChar ? "att-pass-hide" : "att-pass-show");
            _Body.ShowTips(BtMod, TbData.UseSystemPasswordChar ? "显示口令" : "隐藏口令");
            BtGen.Image = viewModel.GetImage("att-pass-gen");
            _Body.ShowTips(BtGen, "生成随机口令");
            BtOpt.Image = viewModel.GetImage("att-pass-options");
            _Body.ShowTips(BtOpt, "选项");

            InitSpec(TbData);
        }
        #endregion

        #region 接口实现
        public int InitView(int row)
        {
            TabIndex = row;

            _Grid.RowStyles.Add(_Style);

            _Grid.Controls.Add(_Label, 0, row);
            _Grid.Controls.Add(this, 1, row);

            return 27;
        }

        public bool ShowData(DataModel dataModel, Att att)
        {
            _DataModel = dataModel;
            _Att = att;
            if (_Att == null)
            {
                return false;
            }

            _Label.Text = _Att.Text;
            TbData.Text = _Att.Data;
            return true;
        }

        public void Cut()
        {
            SafeUtil.Copy(TbData.Text, 60);
            TbData.Clear();
        }

        public void Copy()
        {
            SafeUtil.Copy(TbData.Text, 60);
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
        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
        }

        private void BtMod_Click(object sender, EventArgs e)
        {
            TbData.UseSystemPasswordChar = !TbData.UseSystemPasswordChar;
            BtMod.Image = _ViewModel.GetImage(TbData.UseSystemPasswordChar ? "att-pass-hide" : "att-pass-show");
            _Body.ShowTips(BtMod, TbData.UseSystemPasswordChar ? "显示口令" : "隐藏口令");
        }

        private void BtGen_Click(object sender, EventArgs e)
        {
            GenPass();
        }

        private void BtOpt_Click(object sender, EventArgs e)
        {
            ShowSpec(BtOpt);
        }
        #endregion
    }
}
