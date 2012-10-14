using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Pad
{
    public partial class APad : UserControl, IPwd
    {
        private APwd _APwd;
        private SafeModel _SafeModel;

        public APad()
        {
            InitializeComponent();
        }

        public void Init(APwd apwd, SafeModel safeModel, DataModel dataModel)
        {
            _APwd = apwd;
            _SafeModel = safeModel;
        }

        public void Init()
        {
        }

        #region 接口实现
        public ICatTree CatTree { get; set; }
        public IKeyList KeyList { get; set; }

        public void InitView(Panel panel)
        {
            panel.Controls.Add(this);
            Dock = DockStyle.Fill;
        }

        public void HideView(Panel panel)
        {
            panel.Controls.Remove(this);
        }

        public void ShowInfo()
        {
        }

        public void ShowData()
        {
        }

        public void AppendKey()
        {
        }

        public bool UpdateKey()
        {
            return true;
        }

        public void DeleteKey()
        {
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
        #endregion

        public void ShowTips(Control control, string caption)
        {
            _APwd.ShowTips(control, caption);
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
    }
}
