using System.Windows.Forms;
using Me.Amon.Pwd.V.Wiz.Viewer;

namespace Me.Amon.Pwd.V.Wiz
{
    public partial class AWiz : UserControl, IPwd
    {
        #region 全局变量
        private APwd _APwd;
        private IAttView AttView;
        #endregion

        #region 构造函数
        public AWiz()
        {
            InitializeComponent();
        }
        #endregion

        public void ShowTips(Control control, string caption)
        {
        }

        #region 接口实现
        public ICatTree CatTree { get; set; }
        public IKeyList KeyList { get; set; }

        public void InitView(Panel panel)
        {
            HSplit.Panel1.Controls.Add(CatTree.Control);
            CatTree.Control.Dock = DockStyle.Fill;
            //this.catTree1.Location = new System.Drawing.Point(0, 0);
            //this.catTree1.Name = "catTree1";
            //this.catTree1.Size = new System.Drawing.Size(152, 151);
            //this.catTree1.TabIndex = 0;

            VSplit.Panel1.Controls.Add(KeyList.Control);
            KeyList.Control.Dock = DockStyle.Fill;
            //this.keyList1.Location = new System.Drawing.Point(0, 0);
            //this.keyList1.Name = "keyList1";
            //this.keyList1.Size = new System.Drawing.Size(152, 148);
            //this.keyList1.TabIndex = 0;

            AttView = new AttViewer();
            AttView.Control.Dock = DockStyle.Fill;
            KeyList.AttView = AttView;
            VSplit.Panel2.Controls.Add(AttView.Control);

            Dock = DockStyle.Fill;
            panel.Controls.Add(this);
        }

        public void HideView(Panel panel)
        {
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
            throw new System.NotImplementedException();
        }

        public void ChangeAtt(int type)
        {
            throw new System.NotImplementedException();
        }

        public void SelectPrev()
        {
            throw new System.NotImplementedException();
        }

        public void SelectNext()
        {
            throw new System.NotImplementedException();
        }

        public void MoveUp()
        {
            throw new System.NotImplementedException();
        }

        public void MoveDown()
        {
            throw new System.NotImplementedException();
        }

        public void CutAtt()
        {
            throw new System.NotImplementedException();
        }

        public void CopyAtt()
        {
            throw new System.NotImplementedException();
        }

        public void PasteAtt()
        {
            throw new System.NotImplementedException();
        }

        public void ClearAtt()
        {
            throw new System.NotImplementedException();
        }

        public void SaveAtt()
        {
            throw new System.NotImplementedException();
        }

        public void DropAtt()
        {
            throw new System.NotImplementedException();
        }

        public void FindKey(string meta)
        {
            throw new System.NotImplementedException();
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
