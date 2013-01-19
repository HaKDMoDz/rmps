using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.M;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.Bean;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class UcPassAtt : APass, IAttEditer
    {
        private WPro _APro;
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
        public UcPassAtt()
        {
            InitializeComponent();
        }

        public UcPassAtt(WPro aPro, UserModel userModel)
        {
            _APro = aPro;
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;
            _ViewModel = viewModel;

            TbText.GotFocus += new EventHandler(TbText_GotFocus);
            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtMod.Image = viewModel.GetImage(TbData.UseSystemPasswordChar ? "att-pass-hide" : "att-pass-show");
            _APro.ShowTips(BtMod, TbData.UseSystemPasswordChar ? "显示口令" : "隐藏口令");
            BtGen.Image = viewModel.GetImage("att-pass-gen");
            _APro.ShowTips(BtGen, "生成随机口令");
            BtOpt.Image = viewModel.GetImage("att-pass-options");
            _APro.ShowTips(BtOpt, "选项");

            CmMenu.SuspendLayout();
            _CharLenDef = new ToolStripMenuItem();
            _CharLenDef.Size = new System.Drawing.Size(160, 22);
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
            _CharLenDiy.Size = new System.Drawing.Size(160, 22);
            _CharLenDiy.Text = "其它…(&O)";
            _CharLenDiy.Click += new EventHandler(MiCharLenDiy_Click);

            _LastCharLen = _CharLenDef;
            _LastCharLen.Checked = true;

            CmMenu.ResumeLayout(true);

            _CharSetDef = new ToolStripMenuItem();
            _CharSetDef.Size = new System.Drawing.Size(160, 22);
            _CharSetDef.Text = "默认(&D)";
            _CharSetDef.Click += new EventHandler(MiCharSetDef_Click);

            _CharSetSep = new ToolStripSeparator();
        }

        public Control Control { get { return this; } }

        public string Title { get { return "口令"; } }

        public bool ShowData(Att att)
        {
            _Att = att;
            if (_Att != null)
            {
                TbText.Text = _Att.Text;
                TbData.Text = _Att.Data;
            }

            return true;
        }

        public new bool Focus()
        {
            if (string.IsNullOrEmpty(TbText.Text))
            {
                return TbText.Focus();
            }

            return TbData.Focus();
        }

        public void Cut()
        {
            if (_Ctl != null)
            {
                _Ctl.Cut();
            }
        }

        public void Copy()
        {
            if (_Ctl == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(_Ctl.SelectedText))
            {
                _Ctl.Copy();
                return;
            }
            if (!string.IsNullOrEmpty(_Ctl.Text))
            {
                Clipboard.SetText(_Ctl.Text);
            }
        }

        public void Paste()
        {
            if (_Ctl != null)
            {
                _Ctl.Paste();
            }
        }

        public void Clear()
        {
            if (_Ctl != null)
            {
                _Ctl.Clear();
            }
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (TbText.Text != _Att.Text)
            {
                _Att.Text = TbText.Text;
                _Att.Modified = true;
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
        private void TbText_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbText;
            TbText.SelectAll();
        }

        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbData;
            TbData.SelectAll();
        }

        private void BtMod_Click(object sender, EventArgs e)
        {
            TbData.UseSystemPasswordChar = !TbData.UseSystemPasswordChar;
            BtMod.Image = _ViewModel.GetImage(TbData.UseSystemPasswordChar ? "att-pass-hide" : "att-pass-show");
            _APro.ShowTips(BtMod, TbData.UseSystemPasswordChar ? "显示口令" : "隐藏口令");
        }

        private void BtGen_Click(object sender, EventArgs e)
        {
            GenPass();
        }

        private void BtOpt_Click(object sender, EventArgs e)
        {
            ShowSpec(BtOpt);
        }

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

            _Att.SetSpec(PassAtt.SPEC_PWDS_KEY, Att.SPEC_VALUE_NONE);
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
            _Att.SetSpec(PassAtt.SPEC_PWDS_REP, MiRepeatable.Checked ? Att.SPEC_VALUE_TRUE : Att.SPEC_VALUE_FALSE);
        }
        #endregion
        #endregion

        #region 私有函数
        private void InitMenu(string tag, string text, ToolStripMenuItem menu)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Size = new System.Drawing.Size(160, 22);
            item.Text = text;
            item.Tag = tag;
            item.Click += new EventHandler(MiCharLenPre_Click);
            menu.DropDownItems.Add(item);
            _CharLenDict[tag] = item;
        }

        private void ShowSpec(Control ctl)
        {
            //_DataModel = userModel;
            if ((_DataModel.UdcModified & CPwd.KEY_AWIZ) > 0)
            {
                MuCharSet.DropDownItems.Clear();
                MuCharSet.DropDownItems.Add(_CharSetDef);
                MuCharSet.DropDownItems.Add(_CharSetSep);

                _CharSetDict.Clear();
                ToolStripMenuItem item;
                foreach (Udc ucs in _DataModel.UdcList)
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
                _DataModel.UdcModified &= CPwd.KEY_AWIZ;

                _LastCharSet = _CharSetDef;
                _LastCharSet.Checked = true;
            }

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
            string key = _Att.GetSpec(PassAtt.SPEC_PWDS_KEY, Att.SPEC_VALUE_NONE);
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

            string rep = _Att.GetSpec(PassAtt.SPEC_PWDS_REP, Att.SPEC_VALUE_FALSE);
            MiRepeatable.Checked = Att.SPEC_VALUE_TRUE.Equals(rep);

            CmMenu.Show(ctl, 0, ctl.Height);
        }

        private void GenPass()
        {
            int len;
            string tmp = _Att.GetSpec(PassAtt.SPEC_PWDS_LEN);
            if (string.IsNullOrEmpty(tmp) || tmp == "0")
            {
                len = _UserModel.PasswordLength;
            }
            else
            {
                len = int.Parse(tmp);
            }

            string key = _Att.GetSpec(PassAtt.SPEC_PWDS_KEY);
            if (CharUtil.IsValidateHash(key) && _CharSetDict.ContainsKey(key))
            {
                key = _CharSetDict[key].Tag as string;
            }
            else
            {
                key = _DataModel.DefaultUdc.Data;
            }

            string rep = _Att.GetSpec(PassAtt.SPEC_PWDS_REP, Att.SPEC_VALUE_FALSE);
            char[] arr = SafeUtil.NextRandomKey(key.ToCharArray(), len, Att.SPEC_VALUE_TRUE.Equals(rep));
            if (tmp == null)
            {
                Main.ShowAlert(string.Format("无法生成长度为 {0} 且{1}重复的随机口令！", len, MiRepeatable.Checked ? "可" : "不可"));
                return;
            }
            TbData.Text = new string(arr);
        }
        #endregion
    }
}
