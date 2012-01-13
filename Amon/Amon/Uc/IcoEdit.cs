using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Uc.Ico;
using Me.Amon.Util;

namespace Me.Amon.Uc
{
    public partial class IcoEdit : Form
    {
        private UserModel _UserModel;
        private DirEdit _DirEdit;
        private IcoView _IcoView;
        private Control _Control;

        public IcoEdit()
        {
            InitializeComponent();
        }

        public IcoEdit(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

        public string DefaultPath { get; set; }
        public string CurrentPath { get; set; }
        public ListViewItem SelectedItem { get; set; }

        public void Init()
        {
            DefaultPath = IEnv.DATA_DIR + Path.DirectorySeparatorChar + _UserModel.Code + Path.DirectorySeparatorChar + "key";
            LbDir.Items.Add(new Item { K = "0", V = "默认目录" });

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0500);
            dba.AddWhere(IDat.APWD0503, _UserModel.Code);
            dba.AddSort(IDat.APWD0501, true);

            using (DataTable dt = dba.ExecuteSelect())
            {
                foreach (DataRow row in dt.Rows)
                {
                    LbDir.Items.Add(new Item { K = row[IDat.APWD0504] as string, V = row[IDat.APWD0505] as string, D = row[IDat.APWD0506] as string });
                }
            }

            ShowIcoView();
        }

        private void LbDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Control is DirEdit)
            {
                ShowIcoView();
            }

            Item item = LbDir.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            CurrentPath = DefaultPath;
            if (CharUtil.IsValidate(item.K))
            {
                CurrentPath += Path.DirectorySeparatorChar + item.K;
            }
            if (!Directory.Exists(CurrentPath))
            {
                return;
            }
            _IcoView.ShowData(CurrentPath);
        }

        private void MiAppend_Click(object sender, EventArgs e)
        {
            if (_Control is IcoView)
            {
                ShowDirEdit();
            }
            _DirEdit.ShowData(new Item());
        }

        private void MiUpdate_Click(object sender, EventArgs e)
        {
            Item item = LbDir.SelectedItem as Item;
            if (item == null || item.K == "0")
            {
                return;
            }

            if (_Control is IcoView)
            {
                ShowDirEdit();
            }
            _DirEdit.ShowData(item);
        }

        private void MiDelete_Click(object sender, EventArgs e)
        {
            Item item = LbDir.SelectedItem as Item;
            if (item == null || item.K == "0")
            {
                return;
            }

            if (DialogResult.OK != MessageBox.Show("确认要删除吗？", "", MessageBoxButtons.YesNo))
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0500);
            dba.AddWhere(IDat.APWD0503, _UserModel.Code);
            dba.AddWhere(IDat.APWD0504, item.K);
            dba.ExecuteDelete();
            Directory.Delete(CurrentPath, true);

            LbDir.Items.Remove(item);
        }

        private void ShowDirEdit()
        {
            if (_DirEdit == null)
            {
                _DirEdit = new DirEdit(this);
                _DirEdit.Location = new Point(138, 12);
                _DirEdit.Size = new Size(244, 249);
                _DirEdit.TabIndex = 1;
            }
            if (_IcoView != null)
            {
                Controls.Remove(_IcoView);
            }
            Controls.Add(_DirEdit);
            _Control = _DirEdit;
        }

        private void ShowIcoView()
        {
            if (_IcoView == null)
            {
                _IcoView = new IcoView(this);
                _IcoView.Location = new Point(138, 12);
                _IcoView.Size = new Size(244, 249);
                _IcoView.TabIndex = 1;
            }
            if (_DirEdit != null)
            {
                Controls.Remove(_DirEdit);
            }
            Controls.Add(_IcoView);
            _Control = _IcoView;
        }

        public void UpdateDir(Item item)
        {
            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0500);
            dba.AddParam(IDat.APWD0505, item.V);
            dba.AddParam(IDat.APWD0506, item.D);
            dba.AddParam(IDat.APWD0507, "");
            if (CharUtil.IsValidateHash(item.K))
            {
                dba.AddWhere(IDat.APWD0503, _UserModel.Code);
                dba.AddWhere(IDat.APWD0504, item.K);
                dba.ExecuteUpdate();
                LbDir.Items[LbDir.SelectedIndex] = item;
            }
            else
            {
                item.K = HashUtil.GetCurrTimeHex(true);
                dba.AddParam(IDat.APWD0501, LbDir.Items.Count);
                dba.AddParam(IDat.APWD0503, _UserModel.Code);
                dba.AddParam(IDat.APWD0504, item.K);
                dba.ExecuteInsert();

                Directory.CreateDirectory(DefaultPath + Path.DirectorySeparatorChar + item.K);
                LbDir.Items.Add(item);
                LbDir.SelectedItem = item;
            }
        }
    }
}
