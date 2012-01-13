using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Pwd._Cat;
using Me.Amon.Pwd._Lib;
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
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        private TreeNode _RootNode;
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

            Cat cat = new Cat { Id = "0", Text = "阿木密码箱", Tips = "阿木密码箱" };
            IlCatList.Images.Add(cat.Id, BeanUtil.None);
            _RootNode = new TreeNode { Name = cat.Id, Text = cat.Text, ToolTipText = cat.Tips, ImageKey = cat.Id };
            _RootNode.Tag = cat;
            TvCatView.Nodes.Add(_RootNode);

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

            LbKeyList.ItemHeight = 30;

            ChangeView(2);
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

                TreeNode node = new TreeNode();
                node.Name = row[IDat.C2010203] as string;
                node.Text = row[IDat.C2010205] as string;
                node.ToolTipText = row[IDat.C2010206] as string;
                tmp = row[IDat.C2010207] as string;
                if (CharUtil.IsValidateHash(tmp))
                {
                    //IlCatList.Images.Add(tmp, Image.FromFile(""));
                    node.ImageIndex = IlCatList.Images.Count;
                }
                node.ImageIndex = 0;

                root.Nodes.Add(node);
                data.Rows.RemoveAt(i);
            }
        }
        #endregion

        #region 事件处理
        #region 界面事件
        private void TvCatView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node == null)
            {
                return;
            }

            string catId = node.Name;
            if (!CharUtil.IsValidateHash(catId))
            {
                catId = "0";
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0100);
            dba.AddWhere(IDat.APWD0104, _UserModel.Code);
            dba.AddWhere(IDat.APWD0106, catId);
            dba.AddSort(IDat.APWD0101, false);
            InitKey(dba.ExecuteSelect());
        }

        private void InitKey(DataTable data)
        {
            foreach (DataRow row in data.Rows)
            {
                Key key = new Key();
                key.Id = row[IDat.APWD0105] as string;
                key.Order = (int)row[IDat.APWD0101];
                key.Label = (int)row[IDat.APWD0102];
                key.Major = (int)row[IDat.APWD0103];
                key.CatId = row[IDat.APWD0106] as string;
                key.RegDate = row[IDat.APWD0107] as string;
                key.LibId = row[IDat.APWD0108] as string;
                key.Title = row[IDat.APWD0109] as string;
                key.MetaKey = row[IDat.APWD010A] as string;
                key.IcoName = row[IDat.APWD010B] as string;
                key.IcoPath = row[IDat.APWD010C] as string;
                key.IcoMemo = row[IDat.APWD010D] as string;
                key.GtdId = row[IDat.APWD010E] as string;
                key.GtdMemo = row[IDat.APWD010F] as string;
                key.Memo = row[IDat.APWD0110] as string;
                key.VisitDate = row[IDat.APWD0111] as string;
                key.CipherVer = row[IDat.APWD0112] as string;
                LbKeyList.Items.Add(key);
            }
            data.Dispose();
        }

        private void LbKeyList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            //if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)//如果选中该选项
            //{
            //Brush b = new TextureBrush(new Bitmap(@"../../../sj.bmp"));//读取背景图片,再转变成画刷
            ////就在背景里画图片
            //e.Graphics.FillRectangle(b, e.Bounds);//参数中,e.Bounds 表示当前选项在整个listbox中的区域
            //}
            //else//不是选中item
            //{
            //    e.Graphics.FillRectangle(Brushes.White, e.Bounds);//在背景上画空白
            //Brush b = new TextureBrush(new Bitmap(@"../../../Listline.bmp"));//底下线的图片
            ////在背景上画线
            //e.Graphics.FillRectangle(b, e.Bounds.X, e.Bounds.Y + 23, e.Bounds.Width, 1);//参数中,23和1是根据图片来的,因为需要在最下面显示线条
            //}

            if (e.Index <= -1 || e.Index >= LbKeyList.Items.Count)
            {
                return;
            }
            Key key = LbKeyList.Items[e.Index] as Key;
            if (key == null)
            {
                return;
            }

            //e.Graphics.DrawImage(null, 0, 0);

            //最后把要显示的文字画在背景图片上
            e.Graphics.DrawString(key.Title, this.Font, Brushes.Black, e.Bounds.X + 36, e.Bounds.Y + 2);

            e.Graphics.DrawString(key.VisitDate, this.Font, Brushes.Gray, e.Bounds.X + 36, e.Bounds.Y + 16);

            //e.Graphics.DrawImage(null, 0, 0);
        }

        private void LbKeyList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_SafeModel.Key != null && _SafeModel.Key.Modified)
            {
                BeanUtil.ShowAlert("编辑中……");
                return;
            }

            Key key = LbKeyList.SelectedItem as Key;
            if (key == null)
            {
                BeanUtil.ShowAlert("系统异常，请稍后重试！");
                return;
            }

            _SafeModel.Key = key;

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0200);
            dba.AddColumn(IDat.APWD0204);
            dba.AddWhere(IDat.APWD0203, key.Id);
            dba.AddSort(IDat.APWD0201);
            DataTable dt = dba.ExecuteSelect();
            StringBuilder buf = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                buf.Append(row[IDat.APWD0204] as string);
            }
            _SafeModel.Decode(buf.ToString());

            _PwdView.ShowData(key);
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
                    _PwdView.DeleteKey();
                    return;
                }
                // 向下移动
                if ((e.KeyCode == Keys.D) || (e.Shift && e.KeyCode == Keys.Down))
                {
                    _PwdView.DeleteKey();
                    return;
                }
                // 向上选择
                if (e.KeyCode == Keys.Up)
                {
                    _PwdView.DeleteKey();
                    return;
                }
                // 向下选择
                if (e.KeyCode == Keys.Down)
                {
                    _PwdView.DeleteKey();
                    return;
                }
                // 查找
                if (e.KeyCode == Keys.F)
                {
                    _PwdView.DeleteKey();
                    return;
                }
                // 查询
                if (e.KeyCode == Keys.Q)
                {
                    _PwdView.DeleteKey();
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
                    SsInfo.Visible = !SsInfo.Visible;
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
                    _PwdView.DeleteKey();
                    return;
                }
                // 更新属性
                if (e.KeyCode == Keys.U)
                {
                    _PwdView.DeleteKey();
                    return;
                }
                // 删除属性
                if (e.KeyCode == Keys.R)
                {
                    _PwdView.DeleteKey();
                    return;
                }
                return;
            }
        }

        private void APwd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_SafeModel.Key.Modified)
            {
                if (DialogResult.OK != MessageBox.Show("", "", MessageBoxButtons.YesNo))
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
        #endregion

        #region 菜单栏事件区域
        #region 系统菜单
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

        }

        private void TmiAppendAttPass_Click(object sender, EventArgs e)
        {

        }

        private void TmiAppendAttLink_Click(object sender, EventArgs e)
        {

        }

        private void TmiAppendAttMail_Click(object sender, EventArgs e)
        {

        }

        private void TmiAppendAttDate_Click(object sender, EventArgs e)
        {

        }

        private void TmiAppendAttData_Click(object sender, EventArgs e)
        {

        }

        private void TmiAppendAttList_Click(object sender, EventArgs e)
        {

        }

        private void TmiAppendAttMemo_Click(object sender, EventArgs e)
        {

        }

        private void TmiAppendAttFile_Click(object sender, EventArgs e)
        {

        }

        private void TmiAppendAttLine_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 转换属性
        private void TmiUpdateAttText_Click(object sender, EventArgs e)
        {

        }

        private void TmiUpdateAttPass_Click(object sender, EventArgs e)
        {

        }

        private void TmiUpdateAttLink_Click(object sender, EventArgs e)
        {

        }

        private void TmiUpdateAttMail_Click(object sender, EventArgs e)
        {

        }

        private void TmiUpdateAttDate_Click(object sender, EventArgs e)
        {

        }

        private void TmiUpdateAttData_Click(object sender, EventArgs e)
        {

        }

        private void TmiUpdateAttList_Click(object sender, EventArgs e)
        {

        }

        private void TmiUpdateAttMemo_Click(object sender, EventArgs e)
        {

        }

        private void TmiUpdateAttFile_Click(object sender, EventArgs e)
        {

        }

        private void TmiUpdateAttLine_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void TmiDeleteAtt_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion

        #region 视图菜单
        private void TmiMenu_Click(object sender, EventArgs e)
        {

        }

        private void TmiTool_Click(object sender, EventArgs e)
        {

        }

        private void TmiInfo_Click(object sender, EventArgs e)
        {

        }

        private void TmiCatView_Click(object sender, EventArgs e)
        {

        }

        private void TmiKeyList_Click(object sender, EventArgs e)
        {

        }

        private void TmiFindBar_Click(object sender, EventArgs e)
        {

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

        }

        private void TmiExportXml_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 数据导入
        private void TmiImportTxt_Click(object sender, EventArgs e)
        {

        }

        private void TmiImportXml_Click(object sender, EventArgs e)
        {

        }
        #endregion
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

        }

        private void TmiIco_Click(object sender, EventArgs e)
        {
            IcoEdit edit = new IcoEdit(_UserModel);
            edit.Init();
            edit.Show(this);
        }
        #endregion
        #endregion

        #region 皮肤菜单
        #endregion

        #region 帮助菜单
        private void TmiHelp_Click(object sender, EventArgs e)
        {

        }

        private void TmiKeys_Click(object sender, EventArgs e)
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

        private void TmiAbout_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion

        #region 工具栏事件区域
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

        }

        private void TsbTool_Click(object sender, EventArgs e)
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

        }

        private void CmiUpdateKey_Click(object sender, EventArgs e)
        {

        }

        private void CmiDeleteKey_Click(object sender, EventArgs e)
        {

        }

        #region 使用状态
        private void CmiLabel0_Click(object sender, EventArgs e)
        {

        }

        private void CmiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void CmiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void CmiLabel3_Click(object sender, EventArgs e)
        {

        }

        private void CmiLabel4_Click(object sender, EventArgs e)
        {

        }

        private void CmiLabel5_Click(object sender, EventArgs e)
        {

        }

        private void CmiLabel6_Click(object sender, EventArgs e)
        {

        }

        private void CmiLabel7_Click(object sender, EventArgs e)
        {

        }

        private void CmiLabel8_Click(object sender, EventArgs e)
        {

        }

        private void CmiLabel9_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 优先级
        private void CmiMajorP2_Click(object sender, EventArgs e)
        {

        }

        private void CmiMajorP1_Click(object sender, EventArgs e)
        {

        }

        private void CmiMajor0_Click(object sender, EventArgs e)
        {

        }

        private void CmiMajorN1_Click(object sender, EventArgs e)
        {

        }

        private void CmiMajorN2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void CmiMoveto_Click(object sender, EventArgs e)
        {

        }

        private void CmiHistory_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 属性弹出菜单
        #region 添加属性
        private void CmiAppendAttText_Click(object sender, EventArgs e)
        {

        }

        private void CmiAppendAttPass_Click(object sender, EventArgs e)
        {

        }

        private void CmiAppendAttLink_Click(object sender, EventArgs e)
        {

        }

        private void CmiAppendAttMail_Click(object sender, EventArgs e)
        {

        }

        private void CmiAppendAttDate_Click(object sender, EventArgs e)
        {

        }

        private void CmiAppendAttData_Click(object sender, EventArgs e)
        {

        }

        private void CmiAppendAttList_Click(object sender, EventArgs e)
        {

        }

        private void CmiAppendAttMemo_Click(object sender, EventArgs e)
        {

        }

        private void CmiAppendAttFile_Click(object sender, EventArgs e)
        {

        }

        private void CmiAppendAttLine_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 转换属性
        private void CmiUpdateAttText_Click(object sender, EventArgs e)
        {

        }

        private void CmiUpdateAttPass_Click(object sender, EventArgs e)
        {

        }

        private void CmiUpdateAttLink_Click(object sender, EventArgs e)
        {

        }

        private void CmiUpdateAttMail_Click(object sender, EventArgs e)
        {

        }

        private void CmiUpdateAttDate_Click(object sender, EventArgs e)
        {

        }

        private void CmiUpdateAttData_Click(object sender, EventArgs e)
        {

        }

        private void CmiUpdateAttList_Click(object sender, EventArgs e)
        {

        }

        private void CmiUpdateAttMemo_Click(object sender, EventArgs e)
        {

        }

        private void CmiUpdateAttFile_Click(object sender, EventArgs e)
        {

        }

        private void CmiUpdateAttLine_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void CmiDeleteAtt_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion
        #endregion

        #region 公共方法
        public void ChangeView(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            uc.Location = new Point(0, 0);
            uc.Size = new Size(460, 398);
            uc.TabIndex = 0;

            HSplit.Panel2.Controls.Clear();
            HSplit.Panel2.Controls.Add(uc);
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
                        _ProView = new APro(_SafeModel, _DataModel);
                    }
                    _PwdView = _ProView;
                    _LastView = view;
                    break;
                case 2:
                    if (_WizView == null)
                    {
                        _WizView = new AWiz(_SafeModel, _DataModel);
                    }
                    _PwdView = _WizView;
                    _LastView = view;
                    break;
                case 3:
                    if (_PadView == null)
                    {
                        _PadView = new APad(_SafeModel, _DataModel);
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

        #region 类别处理
        private void AppendCat()
        {
            CatEdit catEdit = new CatEdit();
            catEdit.CallBackHandler = new AmonHandler<Cat>(AppendCatHandler);
            catEdit.Show(this, new Cat());
        }

        private void AppendCatHandler(Cat cat)
        {
            TreeNode root = TvCatView.SelectedNode;

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.C2010200);
            dba.AddParam(IDat.C2010201, root.Nodes.Count);
            dba.AddParam(IDat.C2010202, _UserModel.Code);
            dba.AddParam(IDat.C2010203, HashUtil.GetCurrTimeHex(false));
            dba.AddParam(IDat.C2010204, root.Name);
            dba.AddParam(IDat.C2010205, cat.Text);
            dba.AddParam(IDat.C2010206, cat.Tips);
            dba.AddParam(IDat.C2010207, cat.Icon);
            dba.AddParam(IDat.C2010208, cat.Value);
            dba.AddParam(IDat.C2010209, "");
            dba.AddParam(IDat.C201020A, IDat.SQL_NOW, false);
            dba.AddParam(IDat.C201020B, IDat.SQL_NOW, false);
            dba.AddParam(IDat.C201020C, IDat.VER_DEFAULT);
            dba.AddParam(IDat.C201020D, IDat.OPT_INSERT);
            dba.ExecuteInsert();

            TreeNode node = new TreeNode();
            node.Name = cat.Id;
            node.Text = cat.Text;
            node.ToolTipText = cat.Tips;
            node.Tag = cat;
            if (CharUtil.IsValidateHash(cat.Icon))
            {
                node.ImageKey = cat.Icon;
            }
            root.Nodes.Add(node);
        }

        private void UpdateCat()
        {
            TreeNode node = TvCatView.SelectedNode;
            if (node == null)
            {
                MessageBox.Show("请选择您要更新的类别！", "");
                TvCatView.Focus();
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
            TreeNode node = TvCatView.SelectedNode;

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.C2010200);
            dba.AddParam(IDat.C2010205, cat.Text);
            dba.AddParam(IDat.C2010206, cat.Tips);
            dba.AddParam(IDat.C2010207, cat.Icon);
            dba.AddParam(IDat.C2010208, cat.Value);
            dba.AddParam(IDat.C2010209, "");
            dba.AddParam(IDat.C201020A, IDat.SQL_NOW, false);
            dba.AddStep(IDat.C201020C, 1);
            dba.AddParam(IDat.C201020D, IDat.OPT_UPDATE);
            dba.AddWhere(IDat.C2010202, _UserModel.Code);
            dba.AddWhere(IDat.C2010203, HashUtil.GetCurrTimeHex(false));
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
            TreeNode node = TvCatView.SelectedNode;
            if (node == null)
            {
                MessageBox.Show("请选择您要更新的类别！", "");
                TvCatView.Focus();
                return;
            }

            Cat cat = node.Tag as Cat;
            if (cat == null || cat.Id == "0")
            {
                return;
            }

            if (node.Nodes.Count > 0)
            {
                MessageBox.Show("子类别不为空，不能删除！", "");
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0100);
            dba.AddColumn("COUNT(0)", "CNT");
            dba.AddWhere(IDat.APWD0104, _UserModel.Code);
            dba.AddWhere(IDat.APWD0106, cat.Id);
            int cnt = (int)dba.ExecuteScalar();
            if (cnt > 0)
            {
                MessageBox.Show("口令记录不为空，不能删除！", "");
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
            else
            {
                if (_SafeModel.Key.Modified)
                {
                    BeanUtil.ShowAlert("数据已修改，请保存！");
                    return;
                }
                _SafeModel.Key.SetDefault();
            }

            _SafeModel.Clear();
            _SafeModel.InitGuid();
            _SafeModel.InitMeta();
            _SafeModel.InitLogo();
            _SafeModel.InitHint();

            _PwdView.AppendKey();
        }

        private void UpdateKey()
        {
            TreeNode node = TvCatView.SelectedNode;
            if (node == null)
            {
                BeanUtil.ShowAlert("请选择类别！");
                TvCatView.Focus();
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

            bool update = CharUtil.IsValidateHash(_SafeModel.Key.Id);
            if (update)
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
            dba.AddParam(IDat.APWD0113, "1");

            if (update)
            {
                dba.AddWhere(IDat.APWD0104, _UserModel.Code);
                dba.AddWhere(IDat.APWD0105, _SafeModel.Key.Id);
                _SafeModel.Key.VisitDate = DateTime.Now.ToString(IEnv.DATEIME_FORMAT);
                dba.AddParam(IDat.APWD0111, _SafeModel.Key.VisitDate);
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
                dba.AddParam(IDat.APWD0111, _SafeModel.Key.RegDate);
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

            if (!update)
            {
                LbKeyList.Items.Add(_SafeModel.Key);
            }
            _SafeModel.Key.Modified = false;
            _PwdView.ShowData();
        }

        private void DeleteKey()
        {
        }
        #endregion
        #endregion
    }
}
