using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public partial class APro : UserControl, IPwd
    {
        private APwd _APwd;
        private AAtt _AAtt;
        private DataModel _DataModel;
        private SafeModel _SafeModel;
        private bool _UserAction;

        public APro()
        {
            InitializeComponent();
        }

        public void Init(APwd apwd, SafeModel safeModel, DataModel dataModel)
        {
            _APwd = apwd;
            _SafeModel = safeModel;
            _DataModel = dataModel;

            GvAttList.AutoGenerateColumns = false;

            AeAttEdit.Init(this);
        }

        #region 接口实现
        public void InitView(TableLayoutPanel grid)
        {
            grid.Controls.Add(this, 0, 1);
            Dock = DockStyle.Fill;
            ValueCol.Width = Width - OrderCol.Width - 3;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
        }

        public void ShowData()
        {
            GvAttList.DataSource = null;
            AeAttEdit.ShowInfo();
        }

        public void ShowData(Key key)
        {
            GvAttList.DataSource = null;

            _UserAction = false;
            _SafeModel.BindTo(GvAttList);
            OrderCol.DataPropertyName = "Order";
            ValueCol.DataPropertyName = "Name";
            _UserAction = true;

            GvAttList.Rows[1].Selected = true;
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

        public void CopyAtt()
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

        public void AppendAtt()
        {
        }

        public void UpdateAtt()
        {
            GvAttList.Refresh();
        }

        public void DeleteAtt()
        {
            _SafeModel.Remove(_AAtt);
        }

        private void GvAttList_SelectionChanged(object sender, System.EventArgs e)
        {
            if (!_UserAction || GvAttList.SelectedRows.Count < 1)
            {
                return;
            }
            _AAtt = GvAttList.SelectedRows[0].DataBoundItem as AAtt;
            if (_AAtt == null)
            {
                return;
            }
            AeAttEdit.ShowView(_AAtt);
        }
    }
}
