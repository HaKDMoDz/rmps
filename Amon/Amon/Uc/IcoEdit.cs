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

        public void Init(DataModel dataModel)
        {
            DefaultPath = IEnv.DATA_DIR + Path.DirectorySeparatorChar + _UserModel.Code + Path.DirectorySeparatorChar + "key";
            LsDir.Items.Add(new Item { K = "0", V = "默认目录" });

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0500);
            dba.AddColumn(IDat.APWD0503);
            dba.AddColumn(IDat.APWD0504);
            dba.AddColumn(IDat.APWD0505);
            dba.AddColumn(IDat.APWD0507);
            dba.AddWhere(IDat.APWD0502, _UserModel.Code);
            dba.AddSort(IDat.APWD0501, true);

            using (DataTable dt = dba.ExecuteSelect())
            {
                foreach (DataRow row in dt.Rows)
                {
                    LsDir.Items.Add(new Dir { Id = row[IDat.APWD0503] as string, Name = row[IDat.APWD0504] as string, Tips = row[IDat.APWD0505] as string, Memo = row[IDat.APWD0507] as string });
                }
            }

            ShowIcoView();
        }

        private void LsDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Control is DirEdit)
            {
                ShowIcoView();
            }

            Dir item = LsDir.SelectedItem as Dir;
            if (item == null)
            {
                return;
            }

            CurrentPath = DefaultPath;
            if (CharUtil.IsValidate(item.Id))
            {
                CurrentPath += Path.DirectorySeparatorChar + item.Id;
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
            _DirEdit.ShowData(new Dir());
        }

        private void MiUpdate_Click(object sender, EventArgs e)
        {
            Dir item = LsDir.SelectedItem as Dir;
            if (item == null || item.Id == "0")
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
            Dir item = LsDir.SelectedItem as Dir;
            if (item == null || item.Id == "0")
            {
                return;
            }

            if (DialogResult.Yes != MessageBox.Show("确认要删除吗？", "", MessageBoxButtons.YesNo))
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0500);
            dba.AddWhere(IDat.APWD0502, _UserModel.Code);
            dba.AddWhere(IDat.APWD0503, item.Id);
            if (1 != dba.ExecuteDelete())
            {
                return;
            }
            if (Directory.Exists(CurrentPath))
            {
                Directory.Delete(CurrentPath, true);
            }

            LsDir.Items.Remove(item);
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

        public void UpdateDir(Dir item)
        {
            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0500);
            dba.AddParam(IDat.APWD0504, item.Name);
            dba.AddParam(IDat.APWD0505, item.Tips);
            dba.AddParam(IDat.APWD0506, item.Path);
            dba.AddParam(IDat.APWD0507, item.Memo);
            if (CharUtil.IsValidateHash(item.Id))
            {
                dba.AddWhere(IDat.APWD0502, _UserModel.Code);
                dba.AddWhere(IDat.APWD0503, item.Id);
                dba.AddVcs(IDat.APWD0508, IDat.VCS_DEFAULT);
                dba.AddOpt(IDat.APWD0509, 0, IDat.OPT_INSERT);
                dba.ExecuteUpdate();

                LsDir.Items[LsDir.SelectedIndex] = item;
            }
            else
            {
                item.Id = Convert.ToString(DateTime.UtcNow.ToBinary(), 16).ToUpper().PadLeft(16, '0');
                dba.AddParam(IDat.APWD0501, LsDir.Items.Count);
                dba.AddParam(IDat.APWD0502, _UserModel.Code);
                dba.AddParam(IDat.APWD0503, item.Id);
                dba.AddParam(IDat.APWD0508, IDat.VCS_DEFAULT);
                dba.AddParam(IDat.APWD0509, IDat.OPT_INSERT);
                dba.ExecuteInsert();

                Directory.CreateDirectory(DefaultPath + Path.DirectorySeparatorChar + item.Id);
                LsDir.Items.Add(item);
                LsDir.SelectedItem = item;
            }
        }
    }
}
