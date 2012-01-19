using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Da;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Pwd._Cat;
using Me.Amon.Pwd._Lib;
using Me.Amon.Pwd._Log;
using Me.Amon.Pwd.Pad;
using Me.Amon.Pwd.Pro;
using Me.Amon.Pwd.Wiz;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Pwd
{
    public partial class APwd : Form
    {
        #region 全局变量
        private FindBar _FindBar;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        private TreeNode _RootNode;
        private TreeNode _LastNode;
        private string _LastHash;
        private string _LastMeta;
        private bool _IsSearch;
        private IPwd _PwdView;
        private APro _ProView;
        private AWiz _WizView;
        private APad _PadView;
        private int _LastView;
        #endregion

        #region 构造函数
        public APwd()
        {
            InitializeComponent();
        }

        public APwd(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

        public void Init()
        {
            _SafeModel = new SafeModel(_UserModel);
            _SafeModel.Init();
            _DataModel = new DataModel(_UserModel);
            _DataModel.Init();
            _ViewModel = new ViewModel(_UserModel);
            _ViewModel.Load();

            Cat cat = new Cat { Id = "0", Text = "阿木密码箱", Tips = "阿木密码箱", Icon = "0" };
            IlCatTree.Images.Add(cat.Icon, BeanUtil.NaN16);
            _RootNode = new TreeNode { Name = cat.Id, Text = cat.Text, ToolTipText = cat.Tips, ImageKey = cat.Id };
            _RootNode.Tag = cat;
            TvCatTree.Nodes.Add(_RootNode);

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.C2010200);
            dba.AddColumn(IDat.C2010201);
            dba.AddColumn(IDat.C2010203);
            dba.AddColumn(IDat.C2010204);
            dba.AddColumn(IDat.C2010205);
            dba.AddColumn(IDat.C2010206);
            dba.AddColumn(IDat.C2010207);
            dba.AddColumn(IDat.C2010208);
            dba.AddColumn(IDat.C2010209);
            dba.AddWhere(IDat.C2010202, _UserModel.Code);
            dba.AddWhere(IDat.C201020D, ">", IDat.OPT_DELETE.ToString(), false);
            DataTable dt = dba.ExecuteSelect();
            InitCat(_RootNode, dt);
            _RootNode.Expand();

            _FindBar = new FindBar(this);
            _FindBar.Dock = DockStyle.Fill;
            _FindBar.Location = new Point(3, 3);
            _FindBar.Name = "FbFind";
            _FindBar.Size = new Size(390, 26);
            _FindBar.TabIndex = 0;
            TpGrid.Controls.Add(_FindBar, 0, 0);

            ChangeView(2);

            UcTime.Start();

            _CmiLabels = new ToolStripMenuItem[] { CmiLabel0, CmiLabel1, CmiLabel2, CmiLabel3, CmiLabel4, CmiLabel5, CmiLabel6, CmiLabel7, CmiLabel8, CmiLabel9 };
            _LastLabel = CmiLabel0;
            _CmiMajors = new ToolStripMenuItem[] { CmiMajorN2, CmiMajorN1, CmiMajor0, CmiMajorP1, CmiMajorP2, };
            _LastMajor = CmiMajor0;
        }

        private void InitCat(TreeNode root, DataTable data)
        {
            int i = 0;
            while (i < data.Rows.Count)
            {
                DataRow row = data.Rows[i];
                string tmp = row[IDat.C2010204] as string;
                if (tmp != root.Name)
                {
                    i += 1;
                    continue;
                }

                Cat cat = new Cat();
                cat.Id = row[IDat.C2010203] as string;
                cat.Text = row[IDat.C2010205] as string;
                cat.Tips = row[IDat.C2010206] as string;
                cat.Icon = row[IDat.C2010207] as string;
                cat.Meta = row[IDat.C2010208] as string;
                cat.Memo = row[IDat.C2010209] as string;

                TreeNode node = new TreeNode();
                node.Name = cat.Id;
                node.Text = cat.Text;
                node.ToolTipText = cat.Tips;
                node.Tag = cat;
                if (CharUtil.IsValidateHash(cat.Icon))
                {
                    IlCatTree.Images.Add(cat.Icon, Image.FromFile(_DataModel.CatDir + cat.Icon + ".png"));
                    node.ImageKey = cat.Icon;
                }
                else
                {
                    node.ImageKey = "0";
                }

                root.Nodes.Add(node);
                data.Rows.RemoveAt(i);
                InitCat(node, data);
            }
        }
        #endregion

        #region 事件处理
        #region 界面事件
        private void TvCatTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node == null)
            {
                return;
            }

            ListKey(node.Name);
            _LastNode = node;
        }

        private void InitKey(DataTable data)
        {
            LbKeyList.Items.Clear();
            foreach (DataRow row in data.Rows)
            {
                Key key = new Key();
                key.Load(row);
                LbKeyList.Items.Add(key);

                if (CharUtil.IsValidateHash(key.IcoName))
                {
                    if (CharUtil.IsValidateHash(key.IcoPath))
                    {
                        key.Icon = Image.FromFile(_DataModel.KeyDir + key.IcoPath + Path.DirectorySeparatorChar + key.IcoName + ".png");
                    }
                    else
                    {
                        key.Icon = Image.FromFile(_DataModel.KeyDir + key.IcoName + ".png");
                    }
                }
                else
                {
                    key.Icon = BeanUtil.NaN32;
                }

                if (CharUtil.IsValidateHash(key.GtdId))
                {
                    key.Hint = _ViewModel.HimtImage;
                }
                else
                {
                    key.Hint = BeanUtil.NaN16;
                }
            }
            data.Dispose();
        }

        private void LbKeyList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index > -1 && e.Index < LbKeyList.Items.Count)
            {
                Key key = LbKeyList.Items[e.Index] as Key;
                if (key != null)
                {
                    e.Graphics.DrawImage(key.Icon, e.Bounds.X, e.Bounds.Y);

                    //最后把要显示的文字画在背景图片上
                    e.Graphics.DrawString(key.Title, this.Font, Brushes.Black, e.Bounds.X + 36, e.Bounds.Y);

                    int y = e.Bounds.Y + e.Bounds.Height;
                    e.Graphics.DrawString(key.VisitDate, this.Font, Brushes.Gray, e.Bounds.X + 36, y - 14);

                    int x = e.Bounds.X + e.Bounds.Width;
                    y -= 16;
                    e.Graphics.DrawImage(key.Hint, x - 48, y);
                    e.Graphics.DrawImage(_ViewModel.LabelImages[key.Label], x - 32, y);
                    e.Graphics.DrawImage(_ViewModel.MajorImages[key.Major + 2], x - 16, y);
                }
            }
        }

        private void LbKeyList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Key key = LbKeyList.SelectedItem as Key;
            if (key == null)
            {
                return;
            }

            if (!CharUtil.IsValidateHash(key.Id))
            {
                BeanUtil.ShowAlert("系统异常，请稍后重试！");
                return;
            }

            if (_SafeModel.Key != null && _SafeModel.Key.Modified)
            {
                BeanUtil.ShowAlert("编辑中……");
                return;
            }

            _SafeModel.Key = key;

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0200);
            dba.AddColumn(IDat.APWD0204);
            dba.AddWhere(IDat.APWD0202, _UserModel.Code);
            dba.AddWhere(IDat.APWD0203, key.Id);
            dba.AddSort(IDat.APWD0201, true);
            using (DataTable dt = dba.ExecuteSelect())
            {
                StringBuilder buffer = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    buffer.Append(row[IDat.APWD0204] as string);
                }
                _SafeModel.Decode(buffer.ToString());
            }

            _PwdView.ShowData();

            _LastLabel.Checked = false;
            _LastLabel = _CmiLabels[key.Label];
            _LastLabel.Checked = true;

            _LastMajor.Checked = false;
            _LastMajor = _CmiMajors[key.Major + 2];
            _LastMajor.Checked = true;
        }

        private void APwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                // 添加记录
                if (e.KeyCode == Keys.N)
                {
                    AppendKey();
                    return;
                }
                // 保存记录
                if (e.KeyCode == Keys.S)
                {
                    UpdateKey();
                    return;
                }
                // 删除记录
                if (e.KeyCode == Keys.R)
                {
                    _PwdView.DeleteKey();
                    return;
                }
                // 隐藏窗口
                if (e.KeyCode == Keys.H || e.KeyCode == Keys.Enter)
                {
                    Visible = false;
                    return;
                }
                // 向上移动
                if ((e.KeyCode == Keys.U) || (e.Shift && e.KeyCode == Keys.Up))
                {
                    return;
                }
                // 向下移动
                if ((e.KeyCode == Keys.D) || (e.Shift && e.KeyCode == Keys.Down))
                {
                    return;
                }
                // 向上选择
                if (e.KeyCode == Keys.Up)
                {
                    return;
                }
                // 向下选择
                if (e.KeyCode == Keys.Down)
                {
                    return;
                }
                // 查找
                if (e.KeyCode == Keys.F)
                {
                    _FindBar.Focus();
                    return;
                }
                // 查询
                if (e.KeyCode == Keys.Q)
                {
                    Close();
                    return;
                }
                #region 切换视图
                if (e.KeyCode == Keys.F1)
                {
                    ChangeView(1);
                    return;
                }
                if (e.KeyCode == Keys.F2)
                {
                    ChangeView(2);
                    return;
                }
                if (e.KeyCode == Keys.F3)
                {
                    ChangeView(3);
                    return;
                }
                #endregion
                #region 添加属性
                if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    _PwdView.AppendAtt(AAtt.TYPE_TEXT);
                    return;
                }
                if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    _PwdView.AppendAtt(AAtt.TYPE_PASS);
                    return;
                }
                if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    _PwdView.AppendAtt(AAtt.TYPE_LINK);
                    return;
                }
                if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                {
                    _PwdView.AppendAtt(AAtt.TYPE_MAIL);
                    return;
                }
                if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                {
                    _PwdView.AppendAtt(AAtt.TYPE_DATE);
                    return;
                }
                if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                {
                    _PwdView.AppendAtt(AAtt.TYPE_DATA);
                    return;
                }
                if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                {
                    _PwdView.AppendAtt(AAtt.TYPE_LIST);
                    return;
                }
                if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                {
                    _PwdView.AppendAtt(AAtt.TYPE_MEMO);
                    return;
                }
                if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                {
                    _PwdView.AppendAtt(AAtt.TYPE_FILE);
                    return;
                }
                if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                {
                    _PwdView.AppendAtt(AAtt.TYPE_LINE);
                    return;
                }
                #endregion
                // 添加类别
                if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
                {
                    AppendCat();
                    return;
                }
                // 更新类别
                if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
                {
                    UpdateCat();
                    return;
                }
                // 删除类别
                if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                {
                    DeleteCat();
                    return;
                }
                // 菜单栏隐现
                if (e.KeyCode == Keys.M)
                {
                    TmMenu.Visible = !TmMenu.Visible;
                    return;
                }
                // 工具栏隐现
                if (e.KeyCode == Keys.T)
                {
                    TsTool.Visible = !TsTool.Visible;
                    return;
                }
                // 状态栏隐现
                if (e.KeyCode == Keys.I)
                {
                    SsEcho.Visible = !SsEcho.Visible;
                    return;
                }
                // 目录隐现
                if (e.KeyCode == Keys.G)
                {
                    VSplit.Panel1Collapsed = !VSplit.Panel1Collapsed;
                    return;
                }
                // 列表隐现
                if (e.KeyCode == Keys.K)
                {
                    VSplit.Panel2Collapsed = !VSplit.Panel2Collapsed;
                    return;
                }
                return;
            }
            if (e.Alt)
            {
                // 复制属性
                if (e.KeyCode == Keys.C)
                {
                    _PwdView.CopyAtt();
                    return;
                }
                // 更新属性
                if (e.KeyCode == Keys.U)
                {
                    _PwdView.SaveAtt();
                    return;
                }
                // 删除属性
                if (e.KeyCode == Keys.R)
                {
                    _PwdView.DropAtt();
                    return;
                }
                #region 修改属性
                if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    _PwdView.UpdateAtt(AAtt.TYPE_TEXT);
                    return;
                }
                if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    _PwdView.UpdateAtt(AAtt.TYPE_PASS);
                    return;
                }
                if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    _PwdView.UpdateAtt(AAtt.TYPE_LINK);
                    return;
                }
                if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                {
                    _PwdView.UpdateAtt(AAtt.TYPE_MAIL);
                    return;
                }
                if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                {
                    _PwdView.UpdateAtt(AAtt.TYPE_DATE);
                    return;
                }
                if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                {
                    _PwdView.UpdateAtt(AAtt.TYPE_DATA);
                    return;
                }
                if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                {
                    _PwdView.UpdateAtt(AAtt.TYPE_LIST);
                    return;
                }
                if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                {
                    _PwdView.UpdateAtt(AAtt.TYPE_MEMO);
                    return;
                }
                if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                {
                    _PwdView.UpdateAtt(AAtt.TYPE_FILE);
                    return;
                }
                if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                {
                    _PwdView.UpdateAtt(AAtt.TYPE_LINE);
                    return;
                }
                #endregion
                return;
            }
            // 帮助
            if (e.KeyCode == Keys.F1)
            {
                ShowHelp();
                return;
            }
            // 快捷键
            if (e.KeyCode == Keys.F5)
            {
                ShowKeys();
                return;
            }
        }

        private void APwd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_SafeModel.Key != null && _SafeModel.Key.Modified)
            {
                if (DialogResult.OK != MessageBox.Show("您有数据尚未保存，确认要退出吗？", "", MessageBoxButtons.YesNo))
                {
                    return;
                }
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }
                if (!Visible)
                {
                    Visible = true;
                }
                e.Cancel = true;
            }
        }

        private void UcTime_Tick(object sender, EventArgs e)
        {
            TssTime.Text = DateTime.Now.ToString(IEnv.DATEIME_FORMAT);
        }
        #endregion

        #region 菜单栏事件区域
        #region 系统菜单
        private void TmiHideWin_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void TmiLockWin_Click(object sender, EventArgs e)
        {

        }

        private void TmiExitApp_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region 编辑菜单
        #region 类别编辑
        private void TmiAppendCat_Click(object sender, EventArgs e)
        {
            AppendCat();
        }

        private void TmiUpdateCat_Click(object sender, EventArgs e)
        {
            UpdateCat();
        }

        private void TmiDeleteCat_Click(object sender, EventArgs e)
        {
            DeleteCat();
        }
        #endregion

        #region 口令编辑
        private void TmiAppendKey_Click(object sender, EventArgs e)
        {
            AppendKey();
        }

        private void TmiUpdateKey_Click(object sender, EventArgs e)
        {
            UpdateKey();
        }

        private void TmiDeleteKey_Click(object sender, EventArgs e)
        {
            DeleteKey();
        }
        #endregion

        #region 属性编辑
        #region 添加属性
        private void TmiAppendAttText_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(AAtt.TYPE_TEXT);
        }

        private void TmiAppendAttPass_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(AAtt.TYPE_PASS);
        }

        private void TmiAppendAttLink_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(AAtt.TYPE_LINK);
        }

        private void TmiAppendAttMail_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(AAtt.TYPE_MAIL);
        }

        private void TmiAppendAttDate_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(AAtt.TYPE_DATE);
        }

        private void TmiAppendAttData_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(AAtt.TYPE_DATA);
        }

        private void TmiAppendAttList_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(AAtt.TYPE_LIST);
        }

        private void TmiAppendAttMemo_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(AAtt.TYPE_MEMO);
        }

        private void TmiAppendAttFile_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(AAtt.TYPE_FILE);
        }

        private void TmiAppendAttLine_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(AAtt.TYPE_LINE);
        }
        #endregion

        #region 转换属性
        private void TmiUpdateAttText_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(AAtt.TYPE_TEXT);
        }

        private void TmiUpdateAttPass_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(AAtt.TYPE_PASS);
        }

        private void TmiUpdateAttLink_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(AAtt.TYPE_LINK);
        }

        private void TmiUpdateAttMail_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(AAtt.TYPE_MAIL);
        }

        private void TmiUpdateAttDate_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(AAtt.TYPE_DATE);
        }

        private void TmiUpdateAttData_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(AAtt.TYPE_DATA);
        }

        private void TmiUpdateAttList_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(AAtt.TYPE_LIST);
        }

        private void TmiUpdateAttMemo_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(AAtt.TYPE_MEMO);
        }

        private void TmiUpdateAttFile_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(AAtt.TYPE_FILE);
        }

        private void TmiUpdateAttLine_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(AAtt.TYPE_LINE);
        }
        #endregion

        private void TmiDeleteAtt_Click(object sender, EventArgs e)
        {
            _PwdView.DropAtt();
        }
        #endregion
        #endregion

        #region 视图菜单
        private void TmiViewPro_Click(object sender, EventArgs e)
        {
            ChangeView(1);
        }

        private void TmiViewWiz_Click(object sender, EventArgs e)
        {
            ChangeView(2);
        }

        private void TmiViewPad_Click(object sender, EventArgs e)
        {
            ChangeView(3);
        }

        private void TmiMenu_Click(object sender, EventArgs e)
        {
            SetMenuVisible(false);
        }

        private void TmiTool_Click(object sender, EventArgs e)
        {
            SetToolVisible(!TsTool.Visible);
        }

        private void TmiEcho_Click(object sender, EventArgs e)
        {
            SetEchoVisible(!SsEcho.Visible);
        }

        private void TmiCatView_Click(object sender, EventArgs e)
        {
            SetCatTreeVisible(!TvCatTree.Visible);
        }

        private void TmiKeyList_Click(object sender, EventArgs e)
        {
            SetKeyListVisible(!LbKeyList.Visible);
        }

        private void TmiFindBar_Click(object sender, EventArgs e)
        {
            SetFindBarVisible(!_FindBar.Visible);
        }
        #endregion

        #region 数据菜单
        private void TmiSync_Click(object sender, EventArgs e)
        {

        }

        private void TmiBackup_Click(object sender, EventArgs e)
        {
        }

        private void TmiResuma_Click(object sender, EventArgs e)
        {

        }

        #region 数据导出
        private void TmiExportTxt_Click(object sender, EventArgs e)
        {
            if (_SafeModel.Key != null && _SafeModel.Key.Modified)
            {
                if (DialogResult.Yes == MessageBox.Show("当前记录已被修改，要保存吗？"))
                {
                    return;
                }
            }

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "文件|*.aptxt";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (string.IsNullOrEmpty(file))
            {
                return;
            }

            using (StreamWriter writer = new StreamWriter(file, false))
            {
                writer.WriteLine("APwd-1");
                StringBuilder buffer = new StringBuilder();
                _SafeModel.ExportAsTxt(buffer);
                writer.WriteLine(buffer.ToString());
            }
        }

        private void TmiExportXml_Click(object sender, EventArgs e)
        {
            if (_SafeModel.Key != null && _SafeModel.Key.Modified)
            {
                if (DialogResult.Yes == MessageBox.Show("当前记录已被修改，要保存吗？"))
                {
                    return;
                }
            }

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "文件|*.apxml";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (string.IsNullOrEmpty(file))
            {
                return;
            }

            using (XmlWriter writer = XmlWriter.Create(new StreamWriter(file, false)))
            {
                writer.WriteStartElement("Amon");
                writer.WriteElementString("App", "APwd");
                writer.WriteElementString("Ver", "1");
                writer.WriteStartElement("Keys");
                _SafeModel.ExportAsXml(writer);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
        #endregion

        #region 数据导入
        private void TmiImportTxt_Click(object sender, EventArgs e)
        {
            if (_SafeModel.Key != null && _SafeModel.Key.Modified)
            {
                if (DialogResult.Yes == MessageBox.Show("当前记录已被修改，要保存吗？"))
                {
                    return;
                }
            }

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "文件|*.aptxt";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                return;
            }

            using (StreamReader reader = File.OpenText(file))
            {
                // 版本判断
                string ver = reader.ReadLine();
                if ("APwd-1" != ver)
                {
                    BeanUtil.ShowAlert("未知的文件版本，无法进行导入处理！");
                    return;
                }

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (_SafeModel.ImportByTxt(line))
                        {
                            ImportKey();
                        }
                    }
                    line = reader.ReadLine();
                }
            }
        }

        private void TmiImportXml_Click(object sender, EventArgs e)
        {
            if (_SafeModel.Key != null && _SafeModel.Key.Modified)
            {
                if (DialogResult.Yes == MessageBox.Show("当前记录已被修改，要保存吗？"))
                {
                    return;
                }
            }

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "文件|*.apxml";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                return;
            }

            using (XmlReader reader = XmlReader.Create(File.OpenText(file)))
            {
                if (!reader.ReadToFollowing("App") || reader.ReadElementContentAsString() != "APwd")
                {
                    BeanUtil.ShowAlert("未知的文件格式，无法进行导入处理！");
                    return;
                }
                if (reader.Name != "Ver" && !reader.ReadToFollowing("Ver") || reader.ReadElementContentAsString() != "1")
                {
                    BeanUtil.ShowAlert("未知的文件版本，无法进行导入处理！");
                    return;
                }
                while (reader.ReadToFollowing("Key"))
                {
                    if (_SafeModel.ImportByXml(reader))
                    {
                        ImportKey();
                    }
                }
            }
        }
        #endregion

        private void TmiImportOld_Click(object sender, EventArgs e)
        {
            if (_SafeModel.Key != null && _SafeModel.Key.Modified)
            {
                if (DialogResult.Yes == MessageBox.Show("当前记录已被修改，要保存吗？"))
                {
                    return;
                }
            }

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "所有文件|*.*";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                return;
            }

            using (StreamReader reader = File.OpenText(file))
            {
                // 版本判断
                string ver = reader.ReadLine();
                if ("2" != ver)
                {
                    BeanUtil.ShowAlert("未知的文件版本，无法进行导入处理！");
                    return;
                }

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        _SafeModel.ImportByTxt(line);
                        UpdateKey();
                    }
                    line = reader.ReadLine();
                }
            }
        }

        #endregion

        #region 用户菜单
        #region 口令安全
        private void TmiPkey_Click(object sender, EventArgs e)
        {

        }

        private void TmiSkey_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 系统管理
        private void TmiLib_Click(object sender, EventArgs e)
        {
            LibEdit edit = new LibEdit(_UserModel);
            edit.Init(_DataModel);
            edit.Show(this);
        }

        private void TmiUcs_Click(object sender, EventArgs e)
        {
            UcsEdit edit = new UcsEdit(_UserModel);
            edit.Init(_DataModel);
            edit.Show(this);
        }

        private void TmiIco_Click(object sender, EventArgs e)
        {
            IcoEdit edit = new IcoEdit(_UserModel);
            edit.Init(_DataModel);
            edit.Show(this);
        }
        #endregion
        #endregion

        #region 皮肤菜单
        #endregion

        #region 帮助菜单
        private void TmiHelp_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        private void TmiKeys_Click(object sender, EventArgs e)
        {
            ShowKeys();
        }

        private void TmiInfo_Click(object sender, EventArgs e)
        {
            ShowInfo();
        }
        #endregion
        #endregion

        #region 工具栏事件区域
        private void TsTool_EndDrag(object sender, EventArgs e)
        {

        }

        private void TsbAppend_Click(object sender, EventArgs e)
        {

        }

        private void TsbUpdate_Click(object sender, EventArgs e)
        {

        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {

        }

        private void TsbMenu_Click(object sender, EventArgs e)
        {
            SetMenuVisible(!TmMenu.Visible);
        }

        private void TsbTool_Click(object sender, EventArgs e)
        {
            SetToolVisible(false);
        }

        private void TsbEcho_Click(object sender, EventArgs e)
        {
            SetEchoVisible(!SsEcho.Visible);
        }

        private void TsbSync_Click(object sender, EventArgs e)
        {

        }

        private void TsbKeys_Click(object sender, EventArgs e)
        {

        }

        private void TsbInfo_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 弹出菜单事件区域
        #region 类别弹出菜单
        private void CmiAppendCat_Click(object sender, EventArgs e)
        {
            AppendCat();
        }

        private void CmiUpdateCat_Click(object sender, EventArgs e)
        {
            UpdateCat();
        }

        private void CmiDeleteCat_Click(object sender, EventArgs e)
        {
            DeleteCat();
        }

        private void CmiEditIcon_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 口令弹出菜单
        private void CmiAppendKey_Click(object sender, EventArgs e)
        {
            AppendKey();
        }

        private void CmiDeleteKey_Click(object sender, EventArgs e)
        {
            DeleteKey();
        }

        #region 使用状态
        private ToolStripMenuItem _LastLabel;
        private ToolStripMenuItem[] _CmiLabels;
        private void CmiLabel0_Click(object sender, EventArgs e)
        {
            ChangeLabel(0);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel0;
            _LastLabel.Checked = true;
        }

        private void CmiLabel1_Click(object sender, EventArgs e)
        {
            ChangeLabel(1);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel1;
            _LastLabel.Checked = true;
        }

        private void CmiLabel2_Click(object sender, EventArgs e)
        {
            ChangeLabel(2);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel2;
            _LastLabel.Checked = true;
        }

        private void CmiLabel3_Click(object sender, EventArgs e)
        {
            ChangeLabel(3);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel3;
            _LastLabel.Checked = true;
        }

        private void CmiLabel4_Click(object sender, EventArgs e)
        {
            ChangeLabel(4);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel4;
            _LastLabel.Checked = true;
        }

        private void CmiLabel5_Click(object sender, EventArgs e)
        {
            ChangeLabel(5);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel5;
            _LastLabel.Checked = true;
        }

        private void CmiLabel6_Click(object sender, EventArgs e)
        {
            ChangeLabel(6);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel6;
            _LastLabel.Checked = true;
        }

        private void CmiLabel7_Click(object sender, EventArgs e)
        {
            ChangeLabel(7);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel7;
            _LastLabel.Checked = true;
        }

        private void CmiLabel8_Click(object sender, EventArgs e)
        {
            ChangeLabel(8);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel8;
            _LastLabel.Checked = true;
        }

        private void CmiLabel9_Click(object sender, EventArgs e)
        {
            ChangeLabel(9);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel9;
            _LastLabel.Checked = true;
        }
        #endregion

        #region 优先级
        private ToolStripMenuItem _LastMajor;
        private ToolStripMenuItem[] _CmiMajors;
        private void CmiMajorP2_Click(object sender, EventArgs e)
        {
            ChangeMajor(2);
            _LastMajor.Checked = false;
            _LastMajor = CmiMajorP2;
            _LastMajor.Checked = true;
        }

        private void CmiMajorP1_Click(object sender, EventArgs e)
        {
            ChangeMajor(1);
            _LastMajor.Checked = false;
            _LastMajor = CmiMajorP1;
            _LastMajor.Checked = true;
        }

        private void CmiMajor0_Click(object sender, EventArgs e)
        {
            ChangeMajor(0);
            _LastMajor.Checked = false;
            _LastMajor = CmiMajor0;
            _LastMajor.Checked = true;
        }

        private void CmiMajorN1_Click(object sender, EventArgs e)
        {
            ChangeMajor(-1);
            _LastMajor.Checked = false;
            _LastMajor = CmiMajorN1;
            _LastMajor.Checked = true;
        }

        private void CmiMajorN2_Click(object sender, EventArgs e)
        {
            ChangeMajor(-2);
            _LastMajor.Checked = false;
            _LastMajor = CmiMajorN2;
            _LastMajor.Checked = true;
        }
        #endregion

        private void CmiMoveto_Click(object sender, EventArgs e)
        {
            CatView view = new CatView(_UserModel);
            view.Init(IlCatTree);
            view.CallBack = new AmonHandler<string>(ChangeCat);
            view.ShowDialog(this);
        }

        private void CmiHistory_Click(object sender, EventArgs e)
        {
            LogEdit edit = new LogEdit(_UserModel);
            edit.Init(_SafeModel.Key);
            edit.Show(this);
        }
        #endregion
        #endregion
        #endregion

        #region 公共方法
        public void ChangeView(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            uc.Location = new Point(3, 35);
            uc.Size = new Size(350, 296);
            uc.TabIndex = 0;

            HSplit.Panel2.Controls.Clear();
            HSplit.Panel2.Controls.Add(uc);
        }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }
        #endregion

        #region 私有方法
        private void ChangeView(int view)
        {
            if (_LastView == view)
            {
                return;
            }
            if (_PwdView != null)
            {
                _PwdView.HideView(TpGrid);
            }

            switch (view)
            {
                case 1:
                    if (_ProView == null)
                    {
                        _ProView = new APro();
                        _ProView.Init(this, _SafeModel, _DataModel);
                    }
                    _PwdView = _ProView;
                    _LastView = view;
                    break;
                case 2:
                    if (_WizView == null)
                    {
                        _WizView = new AWiz();
                        _WizView.Init(this, _SafeModel, _DataModel);
                    }
                    _PwdView = _WizView;
                    _LastView = view;
                    break;
                case 3:
                    if (_PadView == null)
                    {
                        _PadView = new APad();
                        _PadView.Init(this, _SafeModel, _DataModel);
                    }
                    _PwdView = _PadView;
                    _LastView = view;
                    break;
                default:
                    _LastView = 0;
                    return;
            }
            _PwdView.InitView(TpGrid);
        }

        private void ChangeCat(string catId)
        {
            if (string.IsNullOrEmpty(catId))
            {
                catId = "0";
            }
            if (catId == _SafeModel.Key.CatId)
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0100);
            dba.AddParam(IDat.APWD0106, catId);
            dba.AddWhere(IDat.APWD0104, _UserModel.Code);
            dba.AddWhere(IDat.APWD0105, _SafeModel.Key.Id);
            dba.AddVcs(IDat.APWD0113, 1);
            dba.AddOpt(IDat.APWD0114, _SafeModel.Key.Operate, IDat.OPT_PWD_UPDATE_CAT);
            if (1 != dba.ExecuteUpdate())
            {
                return;
            }

            _SafeModel.Key.CatId = catId;
            LastOpt();
        }

        public void ChangeLabel(int label)
        {
            if (label < 0 || label > 9)
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0100);
            dba.AddParam(IDat.APWD0102, label);
            dba.AddWhere(IDat.APWD0104, _UserModel.Code);
            dba.AddWhere(IDat.APWD0105, _SafeModel.Key.Id);
            dba.AddVcs(IDat.APWD0113, 1);
            dba.AddOpt(IDat.APWD0114, _SafeModel.Key.Operate, IDat.OPT_PWD_UPDATE_LABEL);
            if (1 != dba.ExecuteUpdate())
            {
                return;
            }

            _SafeModel.Key.Label = label;
            //LbKeyList.Items[LbKeyList.SelectedIndex] = _SafeModel.Key;
            LbKeyList.Refresh();
        }

        public void ChangeMajor(int major)
        {
            if (major < -2 || major > 2)
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0100);
            dba.AddParam(IDat.APWD0103, major);
            dba.AddWhere(IDat.APWD0104, _UserModel.Code);
            dba.AddWhere(IDat.APWD0105, _SafeModel.Key.Id);
            dba.AddVcs(IDat.APWD0113, 1);
            dba.AddOpt(IDat.APWD0114, _SafeModel.Key.Operate, IDat.OPT_PWD_UPDATE_LABEL);
            if (1 != dba.ExecuteUpdate())
            {
                return;
            }

            _SafeModel.Key.Major = major;
            //LbKeyList.Items[LbKeyList.SelectedIndex] = _SafeModel.Key;
            LbKeyList.Refresh();
        }

        private void SetMenuVisible(bool visible)
        {
            TmMenu.Visible = visible;
            TmiMenu.Checked = visible;
            TsbMenu.Checked = visible;
        }

        private void SetToolVisible(bool visible)
        {
            TsTool.Visible = visible;
            TmiTool.Checked = visible;
            TsbTool.Checked = visible;
        }

        private void SetEchoVisible(bool visible)
        {
            SsEcho.Visible = visible;
            TmiEcho.Checked = visible;
            TsbEcho.Checked = visible;
        }

        private void SetCatTreeVisible(bool visible)
        {
            VSplit.Panel1Collapsed = !visible;
            TmiCatView.Checked = visible;
        }

        private void SetKeyListVisible(bool visible)
        {
            VSplit.Panel2Collapsed = !visible;
            TmiKeyList.Checked = visible;
        }

        private void SetFindBarVisible(bool visible)
        {
            TpGrid.RowStyles[0].Height = visible ? 32 : 0;
            _FindBar.Visible = visible;
            TmiFindBar.Checked = visible;
        }

        #region 类别处理
        private void AppendCat()
        {
            CatEdit catEdit = new CatEdit();
            catEdit.CallBackHandler = new AmonHandler<Cat>(AppendCatHandler);
            catEdit.Show(this, new Cat());
        }

        private void AppendCatHandler(Cat cat)
        {
            if (_LastNode == null)
            {
                return;
            }

            cat.Id = HashUtil.GetCurrTimeHex(false);

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.C2010200);
            dba.AddParam(IDat.C2010201, _LastNode.Nodes.Count);
            dba.AddParam(IDat.C2010202, _UserModel.Code);
            dba.AddParam(IDat.C2010203, cat.Id);
            dba.AddParam(IDat.C2010204, _LastNode.Name);
            dba.AddParam(IDat.C2010205, cat.Text);
            dba.AddParam(IDat.C2010206, cat.Tips);
            dba.AddParam(IDat.C2010207, cat.Icon);
            dba.AddParam(IDat.C2010208, cat.Meta);
            dba.AddParam(IDat.C2010209, cat.Memo);
            dba.AddParam(IDat.C201020A, IDat.SQL_NOW, false);
            dba.AddParam(IDat.C201020B, IDat.SQL_NOW, false);
            dba.AddParam(IDat.C201020C, IDat.VCS_DEFAULT);
            dba.AddParam(IDat.C201020D, IDat.OPT_INSERT);
            if (1 != dba.ExecuteInsert())
            {
                return;
            }

            TreeNode node = new TreeNode();
            node.Name = cat.Id;
            node.Text = cat.Text;
            node.ToolTipText = cat.Tips;
            node.Tag = cat;
            if (CharUtil.IsValidateHash(cat.Icon))
            {
                node.ImageKey = cat.Icon;
            }
            _LastNode.Nodes.Add(node);
            _LastNode.Expand();
        }

        private void UpdateCat()
        {
            TreeNode node = TvCatTree.SelectedNode;
            if (node == null)
            {
                BeanUtil.ShowAlert("请选择您要更新的类别！");
                TvCatTree.Focus();
                return;
            }

            Cat cat = node.Tag as Cat;
            if (cat == null || cat.Id == "0")
            {
                return;
            }

            CatEdit catEdit = new CatEdit();
            catEdit.CallBackHandler = new AmonHandler<Cat>(UpdateCatHandler);
            catEdit.Show(this, cat);
        }

        private void UpdateCatHandler(Cat cat)
        {
            TreeNode node = TvCatTree.SelectedNode;

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.C2010200);
            dba.AddParam(IDat.C2010205, cat.Text);
            dba.AddParam(IDat.C2010206, cat.Tips);
            dba.AddParam(IDat.C2010207, cat.Icon);
            dba.AddParam(IDat.C2010208, cat.Meta);
            dba.AddParam(IDat.C2010209, cat.Memo);
            dba.AddParam(IDat.C201020A, IDat.SQL_NOW, false);
            dba.AddVcs(IDat.C201020C, 1);
            dba.AddOpt(IDat.C201020D, cat.Operate, IDat.OPT_UPDATE);
            dba.AddWhere(IDat.C2010202, _UserModel.Code);
            dba.AddWhere(IDat.C2010203, cat.Id);
            if (1 != dba.ExecuteUpdate())
            {
                return;
            }

            node.Text = cat.Text;
            node.ToolTipText = cat.Tips;
            node.ImageKey = cat.Icon;
        }

        private void DeleteCat()
        {
            TreeNode node = TvCatTree.SelectedNode;
            if (node == null)
            {
                BeanUtil.ShowAlert("请选择您要删除的类别！");
                TvCatTree.Focus();
                return;
            }

            Cat cat = node.Tag as Cat;
            if (cat == null || cat.Id == "0")
            {
                return;
            }

            if (node.Nodes.Count > 0)
            {
                BeanUtil.ShowAlert("子类别不为空，不能删除！");
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0100);
            dba.AddColumn("COUNT(0)", "CNT");
            dba.AddWhere(IDat.APWD0104, _UserModel.Code);
            dba.AddWhere(IDat.APWD0106, cat.Id);
            long cnt = (long)dba.ExecuteScalar();
            if (cnt > 0)
            {
                BeanUtil.ShowAlert("口令记录不为空，不能删除！");
                return;
            }

            dba.ReInit();
            dba.AddTable(IDat.C2010200);
            dba.AddParam(IDat.C201020D, IDat.OPT_DELETE);
            dba.AddWhere(IDat.C2010202, _UserModel.Code);
            dba.AddWhere(IDat.C2010203, cat.Id);
            dba.ExecuteUpdate();

            TreeNode root = node.Parent;
            if (root != null)
            {
                root.Nodes.Remove(node);
            }
        }
        #endregion

        #region 口令处理
        private void AppendKey()
        {
            if (_SafeModel.Key == null)
            {
                _SafeModel.Key = new Key();
            }
            else if (_SafeModel.Key.Modified)
            {
                if (DialogResult.Yes == MessageBox.Show("您的数据已修改，确认不保存吗？"))
                {
                    return;
                }
            }

            _PwdView.AppendKey();
        }

        private void UpdateKey()
        {
            TreeNode node = TvCatTree.SelectedNode;
            if (node == null)
            {
                BeanUtil.ShowAlert("请选择类别！");
                TvCatTree.Focus();
                return;
            }

            Cat cat = node.Tag as Cat;
            if (cat == null)
            {
                BeanUtil.ShowAlert("系统异常，请稍后重试！");
                return;
            }

            if (!_PwdView.UpdateKey())
            {
                return;
            }

            _SafeModel.Encode();

            DBAccess dba = _UserModel.DBAccess;

            bool isUpdate = CharUtil.IsValidateHash(_SafeModel.Key.Id);
            if (isUpdate)
            {
                #region 数据备份
                if (_SafeModel.Key.Backup)
                {
                    long t = DateTime.UtcNow.Millisecond;
                    dba.ReInit();
                    dba.AddParam(IDat.APWD0A01, t);
                    dba.AddParam(IDat.APWD0A02, IDat.APWD0102);
                    dba.AddParam(IDat.APWD0A03, IDat.APWD0103);
                    dba.AddParam(IDat.APWD0A04, IDat.APWD0104);
                    dba.AddParam(IDat.APWD0A05, IDat.APWD0105);
                    dba.AddParam(IDat.APWD0A06, IDat.APWD0106);
                    dba.AddParam(IDat.APWD0A07, IDat.APWD0107);
                    dba.AddParam(IDat.APWD0A08, IDat.APWD0108);
                    dba.AddParam(IDat.APWD0A09, IDat.APWD0109);
                    dba.AddParam(IDat.APWD0A0A, IDat.APWD010A);
                    dba.AddParam(IDat.APWD0A0B, IDat.APWD010B);
                    dba.AddParam(IDat.APWD0A0C, IDat.APWD010C);
                    dba.AddParam(IDat.APWD0A0D, IDat.APWD010D);
                    dba.AddParam(IDat.APWD0A0E, IDat.APWD010E);
                    dba.AddParam(IDat.APWD0A0F, IDat.APWD010F);
                    dba.AddParam(IDat.APWD0A10, IDat.APWD0110);
                    dba.AddParam(IDat.APWD0A11, IDat.APWD0111);
                    dba.AddParam(IDat.APWD0A12, IDat.APWD0112);
                    dba.AddWhere(IDat.APWD0104, _UserModel.Code);
                    dba.AddWhere(IDat.APWD0105, _SafeModel.Key.Id);
                    dba.AddBackupBatch(IDat.APWD0A00, IDat.APWD0100);

                    dba.ReInit();
                    dba.AddParam(IDat.APWD0B01, t);
                    dba.AddParam(IDat.APWD0B02, IDat.APWD0201);
                    dba.AddParam(IDat.APWD0B04, IDat.APWD0203);
                    dba.AddParam(IDat.APWD0B05, IDat.APWD0204);
                    dba.AddWhere(IDat.APWD0203, _SafeModel.Key.Id);
                    dba.AddBackupBatch(IDat.APWD0B00, IDat.APWD0200);
                }
                #endregion

                dba.ReInit();
                dba.AddTable(IDat.APWD0200);
                dba.AddWhere(IDat.APWD0203, _SafeModel.Key.Id);
                dba.AddDeleteBatch();
            }

            #region 口令信息
            dba.ReInit();
            dba.AddTable(IDat.APWD0100);
            dba.AddParam(IDat.APWD0106, cat.Id);
            dba.AddParam(IDat.APWD0107, _SafeModel.Key.RegDate);
            dba.AddParam(IDat.APWD0108, _SafeModel.Key.LibId);
            dba.AddParam(IDat.APWD0109, _SafeModel.Key.Title);
            dba.AddParam(IDat.APWD010A, _SafeModel.Key.MetaKey);
            dba.AddParam(IDat.APWD010B, _SafeModel.Key.IcoName);
            dba.AddParam(IDat.APWD010C, _SafeModel.Key.IcoPath);
            dba.AddParam(IDat.APWD010D, _SafeModel.Key.IcoMemo);
            dba.AddParam(IDat.APWD010E, _SafeModel.Key.GtdId);
            dba.AddParam(IDat.APWD010F, _SafeModel.Key.GtdMemo);
            dba.AddParam(IDat.APWD0110, _SafeModel.Key.Memo);
            dba.AddParam(IDat.APWD0112, "1");

            if (isUpdate)
            {
                dba.AddWhere(IDat.APWD0104, _UserModel.Code);
                dba.AddWhere(IDat.APWD0105, _SafeModel.Key.Id);
                _SafeModel.Key.VisitDate = DateTime.Now.ToString(IEnv.DATEIME_FORMAT);
                dba.AddParam(IDat.APWD0111, _SafeModel.Key.VisitDate);
                dba.AddVcs(IDat.APWD0113, 1);
                dba.AddOpt(IDat.APWD0114, _SafeModel.Key.Operate, IDat.OPT_UPDATE);
                dba.AddUpdateBatch();
            }
            else
            {
                _SafeModel.Key.Id = HashUtil.GetCurrTimeHex(false);
                dba.AddParam(IDat.APWD0101, 0);
                dba.AddParam(IDat.APWD0102, 0);
                dba.AddParam(IDat.APWD0103, 0);
                dba.AddParam(IDat.APWD0104, _UserModel.Code);
                dba.AddParam(IDat.APWD0105, _SafeModel.Key.Id);
                _SafeModel.Key.VisitDate = _SafeModel.Key.RegDate;
                dba.AddParam(IDat.APWD0111, _SafeModel.Key.VisitDate);
                dba.AddParam(IDat.APWD0113, IDat.VCS_DEFAULT);
                dba.AddParam(IDat.APWD0114, IDat.OPT_INSERT);
                dba.AddInsertBatch();
            }
            #endregion

            #region 口令内容
            int i = 0;
            int j = 0;
            while (j < _SafeModel.Key.Password.Length)
            {
                dba.ReInit();
                dba.AddTable(IDat.APWD0200);
                dba.AddParam(IDat.APWD0201, i++);
                dba.AddParam(IDat.APWD0202, _UserModel.Code);
                dba.AddParam(IDat.APWD0203, _SafeModel.Key.Id);
                if (_SafeModel.Key.Password.Length - j > IDat.APWD0204_SIZE)
                {
                    dba.AddParam(IDat.APWD0204, _SafeModel.Key.Password.Substring(j, IDat.APWD0204_SIZE));
                }
                else
                {
                    dba.AddParam(IDat.APWD0204, _SafeModel.Key.Password.Substring(j));
                }
                dba.AddInsertBatch();
                j += IDat.APWD0204_SIZE;
            }
            #endregion

            dba.ExecuteBatch();

            _SafeModel.Key.Modified = false;
            if (isUpdate && !_IsSearch)
            {
                LbKeyList.Items[LbKeyList.SelectedIndex] = _SafeModel.Key;
            }
            else
            {
                LastOpt();
            }
            _PwdView.ShowInfo();
        }

        private void DeleteKey()
        {
            if (_SafeModel.Key == null)
            {
                return;
            }

            if (DialogResult.Yes != MessageBox.Show("确认要删除此记录吗，此操作将不可恢复？", "提示", MessageBoxButtons.YesNoCancel))
            {
                return;
            }

            if (DialogResult.No != MessageBox.Show("再次确认，要返回吗？", "提示", MessageBoxButtons.YesNoCancel))
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0100);
            dba.AddVcs(IDat.APWD0113, 1);
            dba.AddOpt(IDat.APWD0114, _SafeModel.Key.Operate, IDat.OPT_DELETE);
            dba.AddWhere(IDat.APWD0104, _UserModel.Code);
            dba.AddWhere(IDat.APWD0105, _SafeModel.Key.Id);
            if (1 != dba.ExecuteUpdate())
            {
                return;
            }

            LbKeyList.Items.RemoveAt(LbKeyList.SelectedIndex);
        }

        private void ImportKey()
        {
            _SafeModel.Encode();

            _SafeModel.Key.Id = HashUtil.GetCurrTimeHex(false);
            _SafeModel.Key.VisitDate = _SafeModel.Key.RegDate;

            DBAccess dba = _UserModel.DBAccess;

            #region 口令信息
            dba.ReInit();
            dba.AddTable(IDat.APWD0100);
            dba.AddParam(IDat.APWD0101, 0);
            dba.AddParam(IDat.APWD0102, 0);
            dba.AddParam(IDat.APWD0103, 0);
            dba.AddParam(IDat.APWD0104, _UserModel.Code);
            dba.AddParam(IDat.APWD0105, _SafeModel.Key.Id);
            dba.AddParam(IDat.APWD0106, _SafeModel.Key.CatId);
            dba.AddParam(IDat.APWD0107, _SafeModel.Key.RegDate);
            dba.AddParam(IDat.APWD0108, _SafeModel.Key.LibId);
            dba.AddParam(IDat.APWD0109, _SafeModel.Key.Title);
            dba.AddParam(IDat.APWD010A, _SafeModel.Key.MetaKey);
            dba.AddParam(IDat.APWD010B, _SafeModel.Key.IcoName);
            dba.AddParam(IDat.APWD010C, _SafeModel.Key.IcoPath);
            dba.AddParam(IDat.APWD010D, _SafeModel.Key.IcoMemo);
            dba.AddParam(IDat.APWD010E, _SafeModel.Key.GtdId);
            dba.AddParam(IDat.APWD010F, _SafeModel.Key.GtdMemo);
            dba.AddParam(IDat.APWD0110, _SafeModel.Key.Memo);
            dba.AddParam(IDat.APWD0111, _SafeModel.Key.VisitDate);
            dba.AddParam(IDat.APWD0112, "1");
            dba.AddParam(IDat.APWD0113, IDat.VCS_DEFAULT);
            dba.AddParam(IDat.APWD0114, IDat.OPT_INSERT);
            dba.AddInsertBatch();
            #endregion

            #region 口令内容
            int i = 0;
            int j = 0;
            while (j < _SafeModel.Key.Password.Length)
            {
                dba.ReInit();
                dba.AddTable(IDat.APWD0200);
                dba.AddParam(IDat.APWD0201, i++);
                dba.AddParam(IDat.APWD0203, _SafeModel.Key.Id);
                if (_SafeModel.Key.Password.Length - j > IDat.APWD0204_SIZE)
                {
                    dba.AddParam(IDat.APWD0204, _SafeModel.Key.Password.Substring(j, IDat.APWD0204_SIZE));
                }
                else
                {
                    dba.AddParam(IDat.APWD0204, _SafeModel.Key.Password.Substring(j));
                }
                dba.AddInsertBatch();
                j += IDat.APWD0204_SIZE;
            }
            #endregion

            dba.ExecuteBatch();
        }

        public void ListKey(string catId)
        {
            if (!CharUtil.IsValidateHash(catId))
            {
                catId = "0";
            }

            DoListKey(catId);

            _IsSearch = false;
            _LastHash = catId;
        }

        public void DoListKey(string catId)
        {
            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0100);
            dba.AddWhere(IDat.APWD0104, _UserModel.Code);
            dba.AddWhere(IDat.APWD0106, catId);
            dba.AddWhere(IDat.APWD0114, "!=", IDat.OPT_DELETE.ToString(), false);
            dba.AddSort(IDat.APWD0101, false);
            using (DataTable dt = dba.ExecuteSelect())
            {
                InitKey(dt);
            }
        }

        public void FindKey(string meta)
        {
            meta = meta.Trim();
            if (string.IsNullOrEmpty(meta))
            {
                TvCatTree.SelectedNode = _LastNode;
                return;
            }

            meta = meta.Replace('　', ' ').Replace('＋', '+');
            meta = CharUtil.Text2DB(meta.ToLower());
            meta = Regex.Replace(meta, "^[+\\s]*|[+\\s]*$", "%");
            meta = Regex.Replace(meta, "[+%\\s]+", "%");
            if (meta == "%")
            {
                BeanUtil.ShowAlert("您输入的查询条件无效！");
                return;
            }

            TvCatTree.SelectedNode = null;

            DoFindKey(meta);

            _IsSearch = true;
            _LastMeta = meta;
        }

        private void DoFindKey(string meta)
        {
            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0100);
            dba.AddWhere(IDat.APWD0104, _UserModel.Code);
            dba.AddWhere(string.Format("{0} LIKE '{2}' or {1} like '{2}'", IDat.APWD0109, IDat.APWD010A, meta));
            dba.AddWhere(IDat.APWD0114, "!=", IDat.OPT_DELETE.ToString(), false);

            using (DataTable dt = dba.ExecuteSelect())
            {
                InitKey(dt);
            }
        }

        public void LastOpt()
        {
            if (_IsSearch)
            {
                DoFindKey(_LastMeta);
            }
            else
            {
                DoListKey(_LastHash);
            }
        }
        #endregion

        private void ShowHelp()
        {
            try
            {
                Process.Start("http://amon.me/help");
            }
            catch (Exception exp)
            {
                BeanUtil.ShowAlert(exp.Message);
            }
        }

        private void ShowKeys()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("按键");
            dt.Columns.Add("功能");
            dt.Columns.Add("说明");
            dt.Rows.Add("Control N", "添加记录", "");
            dt.Rows.Add("Control S", "保存记录", "");
            dt.Rows.Add("Control D", "删除记录", "");
            dt.Rows.Add("Control +", "添加类别", "");
            dt.Rows.Add("Control -", "删除类别", "");
            dt.Rows.Add("Control H", "隐藏窗口", "");
            dt.Rows.Add("Control Enter", "隐藏窗口", "");
            dt.Rows.Add("Control L", "锁定窗口", "");
            dt.Rows.Add("Control Up", "选择上一个属性", "");
            dt.Rows.Add("Control Down", "选择下一个属性", "");
            dt.Rows.Add("Control Shift Up", "向上移动属性", "");
            dt.Rows.Add("Control Shift Down", "向下移动属性", "");
            dt.Rows.Add("Control M", "切换菜单栏显示状态", "");
            dt.Rows.Add("Control T", "切换工具栏显示状态", "");
            dt.Rows.Add("Control I", "切换状态栏显示状态", "");
            dt.Rows.Add("Control F", "切换查找栏显示状态", "");
            dt.Rows.Add("Control K", "切换类别导航显示状态", "");
            dt.Rows.Add("Control P", "切换记录导航显示状态", "");
            dt.Rows.Add("Control A", "切换属性编辑显示状态", "");
            dt.Rows.Add("Control Q", "快速查找", "");
            dt.Rows.Add("Control 1", "切换到专业模式", "");
            dt.Rows.Add("Control 2", "切换到向导模式", "");
            dt.Rows.Add("Control 3", "切换到记事模式", "");
            dt.Rows.Add("Alt C", "复制属性数据到剪贴板", "");
            dt.Rows.Add("Alt U", "应用当前属性变更", "");
            dt.Rows.Add("Alt D", "移除当前属性", "");

            HotKeys keys = new HotKeys();
            keys.KeyList = dt;
            keys.Show(this);
        }

        private void ShowInfo()
        {
            new Info().ShowDialog(this);
        }
        #endregion
    }
}
