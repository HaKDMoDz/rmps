using System;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanPass : UserControl, IAttEdit
    {
        private AAtt _Att;
        private TextBox _Ctl;

        public BeanPass()
        {
            InitializeComponent();

            this.TbName.GotFocus += new EventHandler(TbName_GotFocus);
            this.TbData.GotFocus += new EventHandler(TbData_GotFocus);
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public string Title { get { return "口令"; } }

        public bool ShowData(DataModel dataModel, AAtt att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbName.Text = _Att.Name;
                TbData.Text = _Att.Data;
            }

            if ((dataModel.UcsModified & IEnv.KEY_AWIZ) > 0)
            {
                MuCharSet.DropDownItems.Clear();
                ToolStripMenuItem item;
                foreach (Ucs ucs in dataModel.UcsList)
                {
                    item = new ToolStripMenuItem();
                    item.Click += new EventHandler(MiCharSet_Click);
                    item.Name = ucs.Id;
                    item.Size = new System.Drawing.Size(160, 22);
                    item.Tag = ucs.Data;
                    item.Text = ucs.Name;
                    MuCharSet.DropDownItems.Add(item);
                }
                dataModel.UcsModified &= IEnv.KEY_AWIZ;
            }
            return true;
        }

        public void Copy()
        {
            SafeUtil.Copy(_Ctl.Text);
        }

        public void Save()
        {
            if (_Att == null)
            {
                return;
            }

            if (TbName.Text != _Att.Name)
            {
                _Att.Name = TbName.Text;
                _Att.Modified = true;
            }
            if (TbData.Text != _Att.Data)
            {
                _Att.Data = TbData.Text;
                _Att.Modified = true;
            }
        }
        #endregion

        private void TbName_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbName;
            TbName.SelectAll();
        }

        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbData;
            TbData.SelectAll();
        }

        private void BtMod_Click(object sender, EventArgs e)
        {
            if (TbData.PasswordChar != '*')
            {
                TbData.PasswordChar = '*';
            }
            else
            {
                TbData.PasswordChar = '\0';
            }
        }

        private void BtGen_Click(object sender, EventArgs e)
        {

        }

        private void BtOpt_Click(object sender, EventArgs e)
        {
            CmMenu.Show(BtOpt, 0, BtOpt.Height);
        }

        #region 菜单事件
        private void MiCharLen_Click(object sender, EventArgs e)
        {

        }

        private void MiCharSet_Click(object sender, EventArgs e)
        {

        }

        private void MiRepeatable_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
