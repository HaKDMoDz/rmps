using System.Windows.Forms;
using Me.Amon.Pwd.M;
using Me.Amon.Pwd.V.Wiz.Viewer;

namespace Me.Amon.Pwd.V.Wiz
{
    public partial class AWiz : UserControl, IPwd
    {
        #region 全局变量
        private APwd _APwd;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        private IAttView AttView;
        #endregion

        #region 构造函数
        public AWiz()
        {
            InitializeComponent();
        }

        public void Init(APwd aPwd, UserModel userModel, SafeModel safeModel, DataModel dataModel, ViewModel viewModel)
        {
            _APwd = aPwd;
            _UserModel = userModel;
            _SafeModel = safeModel;
            _DataModel = dataModel;
            _ViewModel = viewModel;
        }
        #endregion

        public void FillData()
        {
            _APwd.FillData();
        }

        public void FillData(string data)
        {
            _APwd.FillData(data);
        }

        public void ShowHint(string hints)
        {
            _APwd.ShowHint(hints);
        }

        public void ShowTips(Control control, string caption)
        {
            _APwd.ShowTips(control, caption);
        }

        #region 接口实现
        public ICatTree CatTree { get; set; }
        public IKeyList KeyList { get; set; }
        public IFindBar FindBar { get; set; }

        public void InitView(Panel panel)
        {
            if (CatTree != null)
            {
                CatTree.Control.Dock = DockStyle.Fill;
                //this.catTree1.Location = new System.Drawing.Point(0, 0);
                //this.catTree1.Name = "catTree1";
                //this.catTree1.Size = new System.Drawing.Size(152, 151);
                //this.catTree1.TabIndex = 0;
                HSplit.Panel1.Controls.Add(CatTree.Control);
            }

            if (KeyList != null)
            {
                KeyList.Control.Dock = DockStyle.Fill;
                KeyList.Control.Location = new System.Drawing.Point(0, 29);
                //this.keyList1.Name = "keyList1";
                KeyList.Control.Size = new System.Drawing.Size(320, 74);
                //this.keyList1.TabIndex = 0;
                VSplit.Panel1.Controls.Add(KeyList.Control);
            }

            if (FindBar != null)
            {
                FindBar.Control.Dock = DockStyle.Top;
                FindBar.Control.Location = new System.Drawing.Point(0, 0);
                FindBar.Control.Size = new System.Drawing.Size(320, 29);
                VSplit.Panel1.Controls.Add(FindBar.Control);
            }

            AttViewer viewer = new AttViewer();
            viewer.Dock = DockStyle.Fill;
            viewer.Init(this, _UserModel, _SafeModel, _DataModel, _ViewModel);
            VSplit.Panel2.Controls.Add(viewer);
            AttView = viewer;
            KeyList.AttView = AttView;

            Dock = DockStyle.Fill;
            panel.Controls.Add(this);
        }

        public void HideView(Panel panel)
        {
            panel.Controls.Remove(this);

            HSplit.Panel1.Controls.Remove(CatTree.Control);
            VSplit.Panel1.Controls.Remove(KeyList.Control);
        }

        public void ShowInfo()
        {
            throw new System.NotImplementedException();
        }

        public void ShowData()
        {
            throw new System.NotImplementedException();
        }

        public void AppendKey()
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateKey()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteKey()
        {
            throw new System.NotImplementedException();
        }

        public void AppendAtt(int type)
        {
        }

        public void ChangeAtt(int type)
        {
        }

        public void SelectPrev()
        {
        }

        public void SelectNext()
        {
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void CutAtt()
        {
        }

        public void CopyAtt()
        {
        }

        public void PasteAtt()
        {
        }

        public void ClearAtt()
        {
        }

        public void SaveAtt()
        {
        }

        public void DropAtt()
        {
        }

        public bool NavPaneVisible
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public bool CatTreeVisible
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public bool KeyListVisible
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        #endregion
    }
}
