using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Util;
using Me.Amon.Model.Att;
using System.Collections.Generic;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanPass : UserControl, IAttEdit
    {
        private BeanBody _Body;
        private DataModel _DataModel;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;
        private AAtt _Att;

        #region 构造函数
        public BeanPass()
        {
            InitializeComponent();
        }

        public BeanPass(BeanBody body, TableLayoutPanel grid)
        {
            _Body = body;
            _Grid = grid;

            InitializeComponent();

            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            _Style = new RowStyle(SizeType.Absolute, 27F);
            Dock = DockStyle.Fill;
        }
        #endregion

        #region 接口实现
        public void InitView(int row)
        {
            TabIndex = row;

            _Grid.RowStyles.Add(_Style);

            _Grid.Controls.Add(_Label, 0, row);
            _Grid.Controls.Add(this, 1, row);
        }

        public bool ShowData(DataModel dataModel, AAtt att)
        {
            _DataModel = dataModel;
            if ((_DataModel.UcsModified & IEnv.KEY_AWIZ) > 0)
            {
                MuCharSet.DropDownItems.Clear();
                _CharSetDict.Clear();
                ToolStripMenuItem item;
                foreach (Ucs ucs in _DataModel.UcsList)
                {
                    item = new ToolStripMenuItem();
                    item.Click += new EventHandler(MiCharSet_Click);
                    item.Name = ucs.Id;
                    item.Size = new System.Drawing.Size(160, 22);
                    item.Tag = ucs.Data;
                    item.Text = ucs.Name;
                    MuCharSet.DropDownItems.Add(item);
                    _CharSetDict[ucs.Id] = item;
                }
                _DataModel.UcsModified &= IEnv.KEY_AWIZ;
            }

            _Att = att;
            if (_Att != null)
            {
                _Label.Text = _Att.Name;
                TbData.Text = _Att.Data;
            }
            return true;
        }

        public void Copy()
        {
            SafeUtil.Copy(TbData.Text);
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

        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
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
            string key = _Att.GetSpec(PassAtt.SPEC_PWDS_KEY);
            if (CharUtil.IsValidateHash(key))
            {
                if (_CharSetDict.ContainsKey(key))
                {
                    key = _CharSetDict[key].Tag as string;
                }
                else
                {
                    key = _DataModel.UcsDefault.Data;
                }
            }
            else
            {
                key = _DataModel.UcsDefault.Data;
            }

            string len = _Att.GetSpec(PassAtt.SPEC_PWDS_LEN, AAtt.SPEC_VALUE_NONE);
            if (len == "0")
            {
                len = "8";
            }

            string rep = _Att.GetSpec(PassAtt.SPEC_PWDS_REP, AAtt.SPEC_VALUE_FAIL);
            TbData.Text = new string(CharUtil.NextRandomKey(key.ToCharArray(), int.Parse(len), AAtt.SPEC_VALUE_TRUE.Equals(rep)));
        }

        private void BtOpt_Click(object sender, EventArgs e)
        {
            if (_LastCharLen != null)
            {
                _LastCharLen.Checked = false;
            }
            string len = _Att.GetSpec(PassAtt.SPEC_PWDS_LEN, AAtt.SPEC_VALUE_NONE);
            if (_CharLenDict.ContainsKey(len))
            {
                _LastCharLen = _CharLenDict[len];
            }
            else
            {
                _LastCharLen = MiCharLen0;
            }
            _LastCharLen.Checked = true;

            if (_LastCharSet != null)
            {
                _LastCharSet.Checked = false;
            }
            string key = _Att.GetSpec(PassAtt.SPEC_PWDS_KEY, AAtt.SPEC_VALUE_NONE);
            if (_CharSetDict.ContainsKey(key))
            {
                _LastCharSet = _CharSetDict[key];
            }
            else
            {
                _LastCharSet = MiCharSet0;
            }
            _LastCharSet.Checked = true;

            string rep = _Att.GetSpec(PassAtt.SPEC_PWDS_REP, AAtt.SPEC_VALUE_FAIL);
            MiRepeatable.Checked = AAtt.SPEC_VALUE_TRUE.Equals(rep);

            CmMenu.Show(BtOpt, 0, BtOpt.Height);
        }

        #region 菜单事件
        private ToolStripMenuItem _LastCharLen;
        private Dictionary<string, ToolStripMenuItem> _CharLenDict = new Dictionary<string, ToolStripMenuItem>();
        private ToolStripMenuItem _LastCharSet;
        private Dictionary<string, ToolStripMenuItem> _CharSetDict = new Dictionary<string, ToolStripMenuItem>();
        private void MiCharLenDef_Click(object sender, EventArgs e)
        {
            _Att.SetSpec(PassAtt.SPEC_PWDS_LEN, "0");

            _LastCharLen.Checked = false;
            _LastCharLen = MiCharLen0;
            _LastCharLen.Checked = true;
        }

        private void MiCharLen_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            string cmd = item.Tag as string;
            if (cmd == null || !CharUtil.IsValidateLong(cmd))
            {
                return;
            }

            _Att.SetSpec(PassAtt.SPEC_PWDS_LEN, cmd);

            _LastCharLen.Checked = false;
            _LastCharLen = item;
            _LastCharLen.Checked = true;
        }

        private void MiCharLenMore_Click(object sender, EventArgs e)
        {
        }

        private void MiCharSetDef_Click(object sender, EventArgs e)
        {
            _LastCharSet.Checked = false;
            _LastCharSet = MiCharSet0;
            _LastCharSet.Checked = true;

            _Att.SetSpec(PassAtt.SPEC_PWDS_KEY, AAtt.SPEC_VALUE_NONE);
        }

        private void MiCharSet_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            string key = item.Name;
            if (CharUtil.IsValidateHash(key))
            {
                return;
            }
            string cmd = item.Tag as string;
            if (cmd == null || cmd.Length < 2)
            {
                return;
            }

            _Att.SetSpec(PassAtt.SPEC_PWDS_KEY, key);

            _LastCharSet.Checked = false;
            _LastCharSet = item;
            _LastCharSet.Checked = true;
        }

        private void MiRepeatable_Click(object sender, EventArgs e)
        {
            MiRepeatable.Checked = !MiRepeatable.Checked;
            _Att.SetSpec(PassAtt.SPEC_PWDS_REP, MiRepeatable.Checked ? AAtt.SPEC_VALUE_TRUE : AAtt.SPEC_VALUE_FAIL);
        }
        #endregion
    }
}
