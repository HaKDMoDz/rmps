using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Att;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanPass : UserControl, IAttEdit
    {
        private AAtt _Att;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        private TextBox _Ctl;
        private ToolStripMenuItem _LastCharLen;
        private ToolStripMenuItem _CharLenDef;
        private ToolStripSeparator _CharLenSep;
        private ToolStripMenuItem _CharLenDiy;
        private Dictionary<string, ToolStripMenuItem> _CharLenDict = new Dictionary<string, ToolStripMenuItem>();

        private ToolStripMenuItem _LastCharSet;
        private ToolStripMenuItem _CharSetDef;
        private ToolStripSeparator _CharSetSep;
        private Dictionary<string, ToolStripMenuItem> _CharSetDict = new Dictionary<string, ToolStripMenuItem>();

        #region 构造函数
        public BeanPass()
        {
            InitializeComponent();
        }

        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            TbName.GotFocus += new EventHandler(TbName_GotFocus);
            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            CmMenu.SuspendLayout();
            _CharLenDef = new ToolStripMenuItem();
            _CharLenDef.Size = new Size(160, 22);
            _CharLenDef.Text = "默认(&D)";
            _CharLenDef.Click += new EventHandler(MiCharLenDef_Click);
            MuCharLen.DropDownItems.Add(_CharLenDef);

            _CharLenSep = new ToolStripSeparator();
            MuCharLen.DropDownItems.Add(_CharLenSep);

            InitMenu("6", "6", MuCharLen);
            InitMenu("8", "8", MuCharLen);
            InitMenu("10", "10", MuCharLen);
            InitMenu("12", "12", MuCharLen);
            InitMenu("14", "14", MuCharLen);
            InitMenu("16", "16", MuCharLen);

            _CharLenDiy = new ToolStripMenuItem();
            _CharLenDiy.Size = new Size(160, 22);
            _CharLenDiy.Text = "其它…(&O)";
            _CharLenDiy.Click += new EventHandler(MiCharLenDiy_Click);

            _LastCharLen = _CharLenDef;
            _LastCharLen.Checked = true;

            CmMenu.ResumeLayout(true);

            _CharSetDef = new ToolStripMenuItem();
            _CharSetDef.Size = new Size(160, 22);
            _CharSetDef.Text = "默认(&D)";
            _CharSetDef.Click += new EventHandler(MiCharSetDef_Click);

            _CharSetSep = new ToolStripSeparator();

            _ViewModel = viewModel;
            BtMod.Image = viewModel.GetImage(TbData.UseSystemPasswordChar ? "att-pass-hide" : "att-pass-show");
            BtGen.Image = viewModel.GetImage("att-pass-gen");
            BtOpt.Image = viewModel.GetImage("att-pass-options");
        }

        private void InitMenu(string tag, string text, ToolStripMenuItem menu)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Size = new Size(160, 22);
            item.Text = text;
            item.Tag = tag;
            item.Click += new EventHandler(MiCharLenPre_Click);
            menu.DropDownItems.Add(item);
            _CharLenDict[tag] = item;
        }
        #endregion

        #region 接口实现
        public Control Control { get { return this; } }

        public string Title { get { return "口令"; } }

        public bool ShowData(AAtt att)
        {
            if ((_DataModel.UcsModified & IEnv.KEY_AWIZ) > 0)
            {
                MuCharSet.DropDownItems.Clear();
                MuCharSet.DropDownItems.Add(_CharSetDef);
                MuCharSet.DropDownItems.Add(_CharSetSep);

                _CharSetDict.Clear();
                ToolStripMenuItem item;
                foreach (Udc ucs in _DataModel.UcsList)
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

                _LastCharSet = _CharSetDef;
                _LastCharSet.Checked = true;
            }

            _Att = att;
            if (_Att == null)
            {
                return false;
            }

            TbName.Text = _Att.Name;
            TbData.Text = _Att.Data;
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

        #region 事件处理
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

        #region 按钮事件
        private void BtMod_Click(object sender, EventArgs e)
        {
            TbData.UseSystemPasswordChar = !TbData.UseSystemPasswordChar;
            BtMod.Image = _ViewModel.GetImage(TbData.UseSystemPasswordChar ? "att-pass-hide" : "att-pass-show");
        }

        private void BtGen_Click(object sender, EventArgs e)
        {
            string len = _Att.GetSpec(PassAtt.SPEC_PWDS_LEN);
            if (string.IsNullOrEmpty(len) || len == "0")
            {
                len = "8";
            }

            string key = _Att.GetSpec(PassAtt.SPEC_PWDS_KEY);
            if (CharUtil.IsValidateHash(key) && _CharSetDict.ContainsKey(key))
            {
                key = _CharSetDict[key].Tag as string;
            }
            else
            {
                key = _DataModel.UcsDefault.Data;
            }

            string rep = _Att.GetSpec(PassAtt.SPEC_PWDS_REP, AAtt.SPEC_VALUE_FAIL);
            TbData.Text = new string(CharUtil.NextRandomKey(key.ToCharArray(), int.Parse(len), AAtt.SPEC_VALUE_TRUE.Equals(rep)));
        }

        private void BtOpt_Click(object sender, EventArgs e)
        {
            _LastCharLen.Checked = false;
            string len = _Att.GetSpec(PassAtt.SPEC_PWDS_LEN);
            if (string.IsNullOrEmpty(len))
            {
                _LastCharLen = _CharLenDef;
            }
            else if (_CharLenDict.ContainsKey(len))
            {
                _LastCharLen = _CharLenDict[len];
            }
            else
            {
                _LastCharLen = _CharLenDef;
            }
            _LastCharLen.Checked = true;

            if (_LastCharSet != null)
            {
                _LastCharSet.Checked = false;
            }
            string key = _Att.GetSpec(PassAtt.SPEC_PWDS_KEY, AAtt.SPEC_VALUE_NONE);
            if (string.IsNullOrEmpty(key))
            {
                _LastCharSet = _CharSetDef;
            }
            else if (_CharSetDict.ContainsKey(key))
            {
                _LastCharSet = _CharSetDict[key];
            }
            else
            {
                _LastCharSet = _CharSetDef;
            }
            _LastCharSet.Checked = true;

            string rep = _Att.GetSpec(PassAtt.SPEC_PWDS_REP, AAtt.SPEC_VALUE_FAIL);
            MiRepeatable.Checked = AAtt.SPEC_VALUE_TRUE.Equals(rep);

            CmMenu.Show(BtOpt, 0, BtOpt.Height);
        }
        #endregion

        #region 菜单事件
        private void MiCharLenDef_Click(object sender, EventArgs e)
        {
            _Att.SetSpec(PassAtt.SPEC_PWDS_LEN, PassAtt.SPEC_VALUE_NONE);

            _LastCharLen.Checked = false;
            _LastCharLen = _CharLenDef;
            _LastCharLen.Checked = true;
        }

        private void MiCharLenPre_Click(object sender, EventArgs e)
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

        private void MiCharLenDiy_Click(object sender, EventArgs e)
        {
        }

        private void MiCharSetDef_Click(object sender, EventArgs e)
        {
            _LastCharSet.Checked = false;
            _LastCharSet = _CharSetDef;
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
            if (!CharUtil.IsValidateHash(key))
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
        #endregion
    }
}
