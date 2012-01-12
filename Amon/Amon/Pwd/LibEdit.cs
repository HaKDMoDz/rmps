using System;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Pwd
{
    public partial class LibEdit : Form
    {
        private TreeNode _Selected;
        private UserModel _UserModel;
        private DataModel _DataModel;
        private Lib.ILibEdit _UcEditer;
        private Lib.LibHeader _UcHeader;
        private Lib.LibDetail _UcDetail;

        public LibEdit()
        {
            InitializeComponent();
        }

        public LibEdit(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel)
        {
            _DataModel = dataModel;

            foreach (LibHeader header in dataModel.LibKey)
            {
                if (header.Id == "0")
                {
                    continue;
                }

                TreeNode root = new TreeNode();
                root.Name = header.Id;
                root.Tag = header;
                root.Text = header.Name;
                root.ToolTipText = header.Memo;
                TvLibView.Nodes.Add(root);

                if (header.Details == null)
                {
                    continue;
                }
                foreach (LibDetail detail in header.Details)
                {
                    TreeNode node = new TreeNode();
                    node.Name = detail.Id;
                    node.Tag = detail;
                    node.Text = AAtt.SP_TPL_LS + detail.Name + AAtt.SP_TPL_RS;
                    node.ToolTipText = detail.Memo;
                    root.Nodes.Add(node);
                }
            }

            _UcHeader = new Lib.LibHeader(this);
            _UcDetail = new Lib.LibDetail(this);

            _UcHeader.Location = new System.Drawing.Point(6, 20);
            _UcHeader.Size = new System.Drawing.Size(231, 183);
            GbGroup.Controls.Add(_UcHeader);
            _UcHeader.Show(new LibHeader());
            _UcEditer = _UcHeader;
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            _UcEditer.Save();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TvLibTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _Selected = e.Node;
            if (_Selected == null)
            {
                return;
            }

            object obj = _Selected.Tag;
            if (obj is LibHeader)
            {
                ShowHeader(obj as LibHeader);
                return;
            }
            if (obj is LibDetail)
            {
                ShowDetail(obj as LibDetail);
                return;
            }
        }

        private void MiAppendLibh_Click(object sender, EventArgs e)
        {
            ShowHeader(new LibHeader());
        }

        private void MiDeleteLibh_Click(object sender, EventArgs e)
        {

        }

        private void MiAppendLibd_Click(object sender, EventArgs e)
        {
            _Selected = TvLibView.SelectedNode;
            if (_Selected == null)
            {
                return;
            }

            while (_Selected.Parent != null)
            {
                _Selected = _Selected.Parent;
            }
            ShowDetail(new LibDetail());
        }

        private void MiDeleteLibd_Click(object sender, EventArgs e)
        {

        }

        private void ShowHeader(LibHeader header)
        {
            if (_UcEditer.Name != "LibHeader")
            {
                GbGroup.Controls.Clear();

                _UcHeader.Location = new System.Drawing.Point(6, 20);
                _UcHeader.Size = new System.Drawing.Size(231, 183);
                _UcHeader.TabIndex = 0;
                GbGroup.Controls.Add(_UcHeader);
                GbGroup.Text = "模板";

                _UcEditer = _UcHeader;
            }
            _UcHeader.Show(header);
        }

        private void ShowDetail(LibDetail detail)
        {
            if (_UcEditer.Name != "LibDetail")
            {
                GbGroup.Controls.Clear();

                _UcDetail.Location = new System.Drawing.Point(6, 20);
                _UcDetail.Size = new System.Drawing.Size(231, 183);
                _UcDetail.TabIndex = 0;
                GbGroup.Controls.Add(_UcDetail);
                GbGroup.Text = "属性";

                _UcEditer = _UcDetail;
            }
            _UcDetail.Show(detail);
        }

        public void SaveHeader(LibHeader header)
        {
            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0300);
            dba.AddParam(IDat.APWD0302, 0);
            dba.AddParam(IDat.APWD0305, "0");
            dba.AddParam(IDat.APWD0306, header.Name);
            dba.AddParam(IDat.APWD0307, "");
            dba.AddParam(IDat.APWD0308, header.Memo);
            dba.AddParam(IDat.APWD0309, IDat.SQL_NOW, false);

            if (CharUtil.IsValidateHash(header.Id))
            {
                dba.AddWhere(IDat.APWD0304, header.Id);
                dba.AddWhere(IDat.APWD0303, _UserModel.Code);
                dba.ExecuteUpdate();

                _Selected.Text = header.Name;
                _Selected.ToolTipText = header.Memo;
            }
            else
            {
                header.Id = HashUtil.GetCurrTimeHex(false);
                dba.AddParam(IDat.APWD0301, TvLibView.Nodes.Count);
                dba.AddParam(IDat.APWD0304, header.Id);
                dba.AddParam(IDat.APWD030A, IDat.SQL_NOW, false);
                dba.AddParam(IDat.APWD0303, _UserModel.Code);
                dba.ExecuteInsert();

                _DataModel.LibKey.Add(header);

                TreeNode node = new TreeNode();
                node.Name = header.Id;
                node.Tag = header;
                node.Text = header.Name;
                node.ToolTipText = header.Memo;
                TvLibView.Nodes.Add(node);

                TvLibView.SelectedNode = null;
            }
        }

        public void SaveDetail(LibDetail detail)
        {
            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(IDat.APWD0300);
            dba.AddParam(IDat.APWD0302, detail.Type);
            dba.AddParam(IDat.APWD0306, detail.Name);
            dba.AddParam(IDat.APWD0307, detail.Data);
            dba.AddParam(IDat.APWD0308, detail.Memo);
            dba.AddParam(IDat.APWD0309, IDat.SQL_NOW, false);

            if (CharUtil.IsValidateHash(detail.Id))
            {
                dba.AddWhere(IDat.APWD0303, _UserModel.Code);
                dba.AddWhere(IDat.APWD0304, detail.Id);
                dba.ExecuteUpdate();

                TreeNode root = TvLibView.SelectedNode;
            }
            else
            {
                LibHeader header = _Selected.Tag as LibHeader;

                detail.Id = HashUtil.GetCurrTimeHex(false);
                dba.AddParam(IDat.APWD0301, _Selected.Nodes.Count);
                dba.AddParam(IDat.APWD0303, _UserModel.Code);
                dba.AddParam(IDat.APWD0304, detail.Id);
                dba.AddParam(IDat.APWD0305, _Selected.Name);
                dba.AddParam(IDat.APWD030A, IDat.SQL_NOW, false);
                dba.ExecuteInsert();

                header.Details.Add(detail);

                TreeNode node = new TreeNode();
                node.Name = detail.Id;
                node.Tag = detail;
                node.Text = AAtt.SP_TPL_LS + detail.Name + AAtt.SP_TPL_RS;
                node.ToolTipText = detail.Memo;
                _Selected.Nodes.Add(node);

                TvLibView.SelectedNode = null;
            }
        }
    }
}
