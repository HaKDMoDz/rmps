using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;
using Me.Amon.Kms.V.Uc;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Kms
{
    public partial class AKms : Form
    {
        private UserModel _UserModel;
        private DataModel _DataModel;

        #region 全局变量
        private readonly Main _trayPtn;
        private MSolution _curSln;
        private TabPage _curTab;

        private bool _reload;

        private bool _isPreNew;
        private readonly Dictionary<EAction, IFunction> _preList = new Dictionary<EAction, IFunction>(8);
        private IFunction _preIF;

        private bool _isSufNew;
        private readonly Dictionary<EAction, IFunction> _sufList = new Dictionary<EAction, IFunction>(8);
        private IFunction _sufIF;

        #endregion

        #region 构造函数
        public AKms()
        {
            InitializeComponent();

            InitData();
        }

        public AKms(Main trayPtn, UserModel userModel, DataModel dataModel)
        {
            _trayPtn = trayPtn;
            _UserModel = userModel;
            _DataModel = dataModel;

            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            CbLanguage.Items.Add(new MLanguage { C1010103 = "0", C1010106 = "全部" });
            CbLanguage.Items.AddRange(_DataModel.ListLanguage().ToArray());
            CbLanguage.SelectedIndex = 0;

            LsCategory.Items.AddRange(_DataModel.ListCategory().ToArray());

            CbTarget.Items.Add(new ListItem<ETarget>(ETarget.None, "请选择"));
            CbTarget.Items.Add(new ListItem<ETarget>(ETarget.Man, "人"));
            CbTarget.Items.Add(new ListItem<ETarget>(ETarget.App, "程序"));
            CbTarget.Items.Add(new ListItem<ETarget>(ETarget.Scb, "剪贴板"));
            CbTarget.Items.Add(new ListItem<ETarget>(ETarget.Img, "文件系统"));
            //CbTarget.Items.Add(new ListModel<ETarget>(ETarget.Net, "网络消息"));
            //CbTarget.Items.Add(new ListModel<ETarget>(ETarget.Kms, "其它机器人"));
            CbTarget.SelectedIndex = 0;

            CbMethod.Items.Add(new ListItem<EMethod>(EMethod.None, "请选择"));
            CbMethod.Items.Add(new ListItem<EMethod>(EMethod.Answer, "应答式交互"));
            CbMethod.Items.Add(new ListItem<EMethod>(EMethod.Active, "手控式交互"));
            CbMethod.Items.Add(new ListItem<EMethod>(EMethod.Attack, "攻击式交互"));
            CbMethod.SelectedIndex = 0;

            CbOutput.Items.Add(new ListItem<EOutput>(EOutput.None, "请选择"));
            CbOutput.Items.Add(new ListItem<EOutput>(EOutput.ClipBoard, "粘贴输入"));
            CbOutput.Items.Add(new ListItem<EOutput>(EOutput.SendMessage, "消息输入"));
            CbOutput.Items.Add(new ListItem<EOutput>(EOutput.SimulateInput, "模拟输入"));
            CbOutput.SelectedIndex = 0;

            LsSolution.Items.AddRange(_DataModel.ListSolution().ToArray());
        }
        #endregion

        #region 窗体事件

        private void EditSln_Load(object sender, EventArgs e)
        {
            _curSln = _UserModel.Solution;
            LsSolution.SelectedItem = _curSln;
        }

        private void EditSln_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_reload)
            {
                _UserModel.ReloadData("");
                _trayPtn.ReloadMenu();
            }
        }
        #endregion

        #region 列表事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsSlns_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sln = LsSolution.SelectedItem as MSolution;
            if (sln == null)
            {
                return;
            }
            _curSln = _DataModel.ReadSolution(sln);
            ShowData();
        }
        #endregion

        #region 前置操作
        private void LsPre_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mFun = LsPre.SelectedItem as MFunction;
            if (mFun == null)
            {
                return;
            }

            EAction key = mFun.Action;
            IFunction iFun = _preList.ContainsKey(key) ? _preList[key] : null;
            if (iFun == null)
            {
                iFun = CreateControl(mFun);
                iFun.UserControl.Name = TpPre.Name + key;
                _preList[key] = iFun;
            }

            ShowControlPre(iFun, mFun);
            _isPreNew = false;
        }

        private void PbTop1_Click(object sender, EventArgs e)
        {
            int idx = LsPre.SelectedIndex;
            if (idx <= 0)
            {
                return;
            }
            object obj = LsPre.SelectedItem;
            LsPre.Items.RemoveAt(idx--);
            LsPre.Items.Insert(idx, obj);
            LsPre.SelectedIndex = idx;
        }

        private void PbBot1_Click(object sender, EventArgs e)
        {
            int idx = LsPre.SelectedIndex;
            if (idx < 0 || idx >= LsPre.Items.Count)
            {
                return;
            }
            object obj = LsPre.SelectedItem;
            LsPre.Items.RemoveAt(idx++);
            LsPre.Items.Insert(idx, obj);
            LsPre.SelectedIndex = idx;
        }

        private void PbDel1_Click(object sender, EventArgs e)
        {
            int idx = LsPre.SelectedIndex;
            if (idx < 0)
            {
                return;
            }
            if (DialogResult.Yes != MessageBox.Show(this, "确认要删除此动作吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                return;
            }
            LsPre.Items.RemoveAt(idx);
            if (idx >= LsPre.Items.Count)
            {
                idx = LsPre.Items.Count - 1;
            }
            if (idx < 0)
            {
                return;
            }
            LsPre.SelectedIndex = idx;
        }

        private void PbNew1_Click(object sender, EventArgs e)
        {
            _curTab = TpPre;
            CmMenu.Show(PbNew1, 0, PbNew1.Height);
        }

        private void PbAdd1_Click(object sender, EventArgs e)
        {
            if (_preIF == null)
            {
                return;
            }

            if (!_preIF.SaveFunction())
            {
                return;
            }

            if (_isPreNew)
            {
                LsPre.Items.Add(_preIF.UserFunction);
                LsPre.SelectedItem = _preIF.UserFunction;
            }
            else
            {
                LsPre.DisplayMember = "";
                LsPre.DisplayMember = _preIF.UserFunction.ToString();
            }
        }
        #endregion

        #region 后置操作
        private void LsSuf_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mFun = LsSuf.SelectedItem as MFunction;
            if (mFun == null)
            {
                return;
            }

            EAction key = mFun.Action;
            IFunction iFun = _preList.ContainsKey(key) ? _preList[key] : null;
            if (iFun == null)
            {
                iFun = CreateControl(mFun);
                iFun.UserControl.Name = TpPre.Name + key;
                _preList[key] = iFun;
            }

            ShowControlSuf(iFun, mFun);
            _isSufNew = false;
        }

        private void PbTop3_Click(object sender, EventArgs e)
        {
            int idx = LsSuf.SelectedIndex;
            if (idx <= 0)
            {
                return;
            }
            object obj = LsSuf.SelectedItem;
            LsSuf.Items.RemoveAt(idx--);
            LsSuf.Items.Insert(idx, obj);
            LsSuf.SelectedIndex = idx;
        }

        private void PbBot3_Click(object sender, EventArgs e)
        {
            int idx = LsSuf.SelectedIndex;
            if (idx < 0 || idx >= LsSuf.Items.Count)
            {
                return;
            }
            object obj = LsSuf.SelectedItem;
            LsSuf.Items.RemoveAt(idx++);
            LsSuf.Items.Insert(idx, obj);
            LsSuf.SelectedIndex = idx;
        }

        private void PbDel3_Click(object sender, EventArgs e)
        {
            int idx = LsSuf.SelectedIndex;
            if (idx < 0)
            {
                return;
            }
            if (DialogResult.Yes != MessageBox.Show(this, "确认要删除此动作吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                return;
            }
            LsSuf.Items.RemoveAt(idx);
            if (idx >= LsSuf.Items.Count)
            {
                idx = LsSuf.Items.Count - 1;
            }
            if (idx < 0)
            {
                return;
            }
            LsSuf.SelectedIndex = idx;
        }

        private void PbNew3_Click(object sender, EventArgs e)
        {
            _curTab = TpSuf;
            CmMenu.Show(PbNew3, 0, PbNew3.Height);
        }

        private void PbAdd3_Click(object sender, EventArgs e)
        {
            if (_sufIF == null)
            {
                return;
            }

            if (!_sufIF.SaveFunction())
            {
                return;
            }

            if (_isSufNew)
            {
                LsSuf.Items.Add(_sufIF.UserFunction);
                LsSuf.SelectedItem = _sufIF.UserFunction;
            }
            else
            {
                LsSuf.DisplayMember = "";
                LsSuf.DisplayMember = _sufIF.UserFunction.Action.ToString();
            }
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 添加方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtAppend_Click(object sender, EventArgs e)
        {
            _curSln = new MSolution { Language = "0", PreFunction = new List<MFunction>(), SufFunction = new List<MFunction>(), Category = new List<string>() };
            LsSolution.SelectedItem = null;
            TcSln.SelectedTab = TpSln;
            TbName.Focus();
            ShowData();
        }

        /// <summary>
        /// 保存方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtUpdate_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region 动作菜单事件
        private void MiThreadWait_Click(object sender, EventArgs e)
        {
            const EAction key = EAction.ThreadWait;
            if (_curTab.Name == TpPre.Name)
            {
                IFunction iFun = _preList.ContainsKey(key) ? _preList[key] : null;
                if (iFun == null)
                {
                    iFun = new ThreadWait();
                    iFun.UserControl.Name = TpPre.Name + key;
                    _preList[key] = iFun;
                }

                ShowControlPre(iFun, new MFunction());
                _isPreNew = true;

                return;
            }

            if (_curTab.Name == TpSuf.Name)
            {
                IFunction iFun = _sufList.ContainsKey(key) ? _sufList[key] : null;
                if (iFun == null)
                {
                    iFun = new ThreadWait();
                    iFun.UserControl.Name = TpSuf.Name + key;
                    _sufList[key] = iFun;
                }

                ShowControlSuf(iFun, new MFunction());
                _isSufNew = true;

                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiExecuteApp_Click(object sender, EventArgs e)
        {
            const EAction key = EAction.ExecuteApp;
            if (_curTab.Name == TpPre.Name)
            {
                IFunction iFun = _preList.ContainsKey(key) ? _preList[key] : null;
                if (iFun == null)
                {
                    iFun = new ExecuteApp();
                    iFun.UserControl.Name = TpPre.Name + key;
                    _preList[key] = iFun;
                }

                ShowControlPre(iFun, new MFunction());
                _isPreNew = true;

                return;
            }

            if (_curTab.Name == TpSuf.Name)
            {
                IFunction iFun = _sufList.ContainsKey(key) ? _sufList[key] : null;
                if (iFun == null)
                {
                    iFun = new ExecuteApp();
                    iFun.UserControl.Name = TpSuf.Name + key;
                    _sufList[key] = iFun;
                }

                ShowControlSuf(iFun, new MFunction());
                _isSufNew = true;

                return;
            }
        }

        private void MiShowWindow_Click(object sender, EventArgs e)
        {
            const EAction key = EAction.ShowWindow;
            if (_curTab.Name == TpPre.Name)
            {
                IFunction iFun = _preList.ContainsKey(key) ? _preList[key] : null;
                if (iFun == null)
                {
                    iFun = new ShowWindow();
                    iFun.UserControl.Name = TpPre.Name + key;
                    _preList[key] = iFun;
                }

                ShowControlPre(iFun, new MFunction());
                _isPreNew = true;

                return;
            }

            if (_curTab.Name == TpSuf.Name)
            {
                IFunction iFun = _sufList.ContainsKey(key) ? _sufList[key] : null;
                if (iFun == null)
                {
                    iFun = new ShowWindow();
                    iFun.UserControl.Name = TpSuf.Name + key;
                    _sufList[key] = iFun;
                }

                ShowControlSuf(iFun, new MFunction());
                _isSufNew = true;

                return;
            }
        }

        private void MiHideWindow_Click(object sender, EventArgs e)
        {
            const EAction key = EAction.HideWindow;
            if (_curTab.Name == TpPre.Name)
            {
                IFunction iFun = _preList.ContainsKey(key) ? _preList[key] : null;
                if (iFun == null)
                {
                    iFun = new HideWindow();
                    iFun.UserControl.Name = TpPre.Name + key;
                    _preList[key] = iFun;
                }

                ShowControlPre(iFun, new MFunction());
                _isPreNew = true;

                return;
            }

            if (_curTab.Name == TpSuf.Name)
            {
                IFunction iFun = _sufList.ContainsKey(key) ? _sufList[key] : null;
                if (iFun == null)
                {
                    iFun = new HideWindow();
                    iFun.UserControl.Name = TpSuf.Name + key;
                    _sufList[key] = iFun;
                }

                ShowControlSuf(iFun, new MFunction());
                _isSufNew = true;

                return;
            }
        }

        private void MiGetControl_Click(object sender, EventArgs e)
        {
            const EAction key = EAction.GetControl;
            if (_curTab.Name == TpPre.Name)
            {
                IFunction iFun = _preList.ContainsKey(key) ? _preList[key] : null;
                if (iFun == null)
                {
                    iFun = new GetControl();
                    iFun.UserControl.Name = TpPre.Name + key;
                    _preList[key] = iFun;
                }

                ShowControlPre(iFun, new MFunction());
                _isPreNew = true;

                return;
            }

            if (_curTab.Name == TpSuf.Name)
            {
                IFunction iFun = _sufList.ContainsKey(key) ? _sufList[key] : null;
                if (iFun == null)
                {
                    iFun = new GetControl();
                    iFun.UserControl.Name = TpSuf.Name + key;
                    _sufList[key] = iFun;
                }

                ShowControlSuf(iFun, new MFunction());
                _isSufNew = true;

                return;
            }
        }

        private void MiKeybdInput_Click(object sender, EventArgs e)
        {
            const EAction key = EAction.KeybdInput;
            if (_curTab.Name == TpPre.Name)
            {
                IFunction iFun = _preList.ContainsKey(key) ? _preList[key] : null;
                if (iFun == null)
                {
                    iFun = new KeybdInput();
                    iFun.UserControl.Name = TpPre.Name + key;
                    _preList[key] = iFun;
                }

                ShowControlPre(iFun, new MFunction());
                _isPreNew = true;

                return;
            }

            if (_curTab.Name == TpSuf.Name)
            {
                IFunction iFun = _sufList.ContainsKey(key) ? _sufList[key] : null;
                if (iFun == null)
                {
                    iFun = new KeybdInput();
                    iFun.UserControl.Name = TpSuf.Name + key;
                    _sufList[key] = iFun;
                }

                ShowControlSuf(iFun, new MFunction());
                _isSufNew = true;

                return;
            }
        }

        private void MiMouseInput_Click(object sender, EventArgs e)
        {
            const EAction key = EAction.MouseInput;
            if (_curTab.Name == TpPre.Name)
            {
                IFunction iFun = _preList.ContainsKey(key) ? _preList[key] : null;
                if (iFun == null)
                {
                    iFun = new MouseInput();
                    iFun.UserControl.Name = TpPre.Name + key;
                    _preList[key] = iFun;
                }

                ShowControlPre(iFun, new MFunction());
                _isPreNew = true;

                return;
            }

            if (_curTab.Name == TpSuf.Name)
            {
                IFunction iFun = _sufList.ContainsKey(key) ? _sufList[key] : null;
                if (iFun == null)
                {
                    iFun = new MouseInput();
                    iFun.UserControl.Name = TpSuf.Name + key;
                    _sufList[key] = iFun;
                }

                ShowControlSuf(iFun, new MFunction());
                _isSufNew = true;

                return;
            }
        }

        private static IFunction CreateControl(MFunction mFun)
        {
            switch (mFun.Action)
            {
                case EAction.ThreadWait:
                    return new ThreadWait();
                case EAction.ExecuteApp:
                    return new ExecuteApp();
                case EAction.ShowWindow:
                    return new ShowWindow();
                case EAction.HideWindow:
                    return new HideWindow();
                case EAction.GetControl:
                    return new GetControl();
                case EAction.KeybdInput:
                    return new KeybdInput();
                case EAction.MouseInput:
                    return new MouseInput();
                default:
                    return null;
            }
        }

        private void ShowControlPre(IFunction iFun, MFunction mFun)
        {
            iFun.UserControl.Location = new System.Drawing.Point(0, 0);
            iFun.UserControl.Size = new System.Drawing.Size(262, 27);
            iFun.UserControl.TabIndex = 1;
            iFun.UserFunction = mFun;

            if (_preIF != null)
            {
                PlPre.Controls.Remove(_preIF.UserControl);
            }
            _preIF = iFun;
            PlPre.Controls.Add(_preIF.UserControl);
        }

        private void ShowControlSuf(IFunction iFun, MFunction mFun)
        {
            iFun.UserControl.Location = new System.Drawing.Point(0, 0);
            iFun.UserControl.Size = new System.Drawing.Size(262, 27);
            iFun.UserControl.TabIndex = 1;
            iFun.UserFunction = mFun;

            if (_sufIF != null)
            {
                PlSuf.Controls.Remove(_sufIF.UserControl);
            }
            _sufIF = iFun;
            PlSuf.Controls.Add(_sufIF.UserControl);
        }
        #endregion

        #region 数据交互
        private void ShowData()
        {
            // 会话方案
            TbName.Text = _curSln.Name;
            CbLanguage.SelectedItem = _curSln.Language ?? "0";
            LsCategory.SelectedItems.Clear();
            if (_curSln.Category != null)
            {
                foreach (string cat in _curSln.Category)
                {
                    LsCategory.SelectedItems.Add(new MCategory { C2010203 = cat });
                }
            }

            // 前置动作
            LsPre.Items.Clear();
            LsPre.Items.AddRange(_curSln.PreFunction.ToArray());
            _preIF = null;
            PlPre.Controls.Clear();

            // 响应方式
            CbTarget.SelectedItem = new ListItem<ETarget>(_curSln.Target, "");
            CbMethod.SelectedItem = new ListItem<EMethod>(_curSln.Method, "");
            CbOutput.SelectedItem = new ListItem<EOutput>(_curSln.Output, "");
            CbOutput.Enabled = ETarget.App == _curSln.Target;
            SpIntval.Value = _curSln.Intval < 1 ? 1 : _curSln.Intval;

            // 准备输入
            PaInit.UserAction = _curSln.PostPrepare;

            // 输入确认
            PaPost.UserAction = _curSln.PostConfirm;

            // 后置动作
            LsSuf.Items.Clear();
            LsSuf.Items.AddRange(_curSln.SufFunction.ToArray());
            PlSuf.Controls.Clear();
            _sufIF = null;

            // 快捷键
            HkWork.HotKey = _curSln.WorkKey;
            HkHalt.HotKey = _curSln.HaltKey;
            HkNext.HotKey = _curSln.NextKey;
            HkStop.HotKey = _curSln.StopKey;
        }

        private void SaveData()
        {
            if (_curSln == null)
            {
                _curSln = new MSolution { PreFunction = new List<MFunction>(), SufFunction = new List<MFunction>(), Category = new List<string>() };
            }

            // 会话方案
            string name = (TbName.Text ?? "").Trim();
            if (!CharUtil.IsValidate(name))
            {
                MessageBox.Show(this, "请输入方案名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbName.Focus();
                return;
            }
            _curSln.Name = name;

            // 交互语言
            var lang = CbLanguage.SelectedItem as MLanguage;
            _curSln.Language = lang == null ? "0" : lang.C1010103;

            // 语言资源
            _curSln.Category.Clear();
            ListBox.SelectedObjectCollection cats = LsCategory.SelectedItems;
            foreach (Object obj in cats)
            {
                _curSln.Category.Add(((MCategory)obj).C2010203);
            }

            // 前置动作
            _curSln.PreFunction.Clear();
            ListBox.ObjectCollection preF = LsPre.Items;
            if (preF.Count > 0)
            {
                foreach (Object obj in preF)
                {
                    _curSln.PreFunction.Add(obj as MFunction);
                }
            }

            // 会话目标
            var target = CbTarget.SelectedItem as ListItem<ETarget>;
            if (target == null || target.K == ETarget.None)
            {
                MessageBox.Show(this, "请选择会话目标！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CbLanguage.Focus();
                return;
            }
            _curSln.Target = target.K;

            // 会话模式
            var method = CbMethod.SelectedItem as ListItem<EMethod>;
            if (method == null || method.K == EMethod.None)
            {
                MessageBox.Show(this, "请选择会话模式！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CbOutput.Focus();
                return;
            }
            _curSln.Method = method.K;

            // 输出方式
            if (target.K == ETarget.App)
            {
                var output = CbOutput.SelectedItem as ListItem<EOutput>;
                if (output == null || output.K == EOutput.None)
                {
                    MessageBox.Show(this, "请选择输出方式！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LsCategory.Focus();
                    return;
                }
                _curSln.Output = output.K;
            }

            // 会话间隔
            decimal intval = SpIntval.Value;
            if (intval >= 0)
            {
                _curSln.Intval = decimal.ToInt32(intval);
            }

            // 准备输入
            _curSln.PostPrepare = PaInit.UserAction;

            // 输入确认
            _curSln.PostConfirm = PaPost.UserAction;

            // 后置动作
            _curSln.SufFunction.Clear();
            ListBox.ObjectCollection sufF = LsSuf.Items;
            if (sufF.Count > 0)
            {
                foreach (Object obj in sufF)
                {
                    _curSln.SufFunction.Add(obj as MFunction);
                }
            }

            // 快捷键
            _curSln.WorkKey = HkWork.HotKey;
            _curSln.HaltKey = HkHalt.HotKey;
            _curSln.NextKey = HkNext.HotKey;
            _curSln.StopKey = HkStop.HotKey;

            // 数据保存
            bool isUpdate = CharUtil.IsValidateHash(_curSln.Id);
            _DataModel.SaveSolution(_curSln);
            if (isUpdate)
            {
                LsSolution.DisplayMember = "";
                LsSolution.DisplayMember = _curSln.Name;
            }
            else
            {
                LsSolution.Items.Add(_curSln);
                LsSolution.SelectedItem = _curSln;
            }

            _reload = true;
        }
        #endregion

        private void CbTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            var target = CbTarget.SelectedItem as ListItem<ETarget>;
            if (target == null)
            {
                return;
            }
            CbOutput.Enabled = target.K == ETarget.App;
        }
    }
}
