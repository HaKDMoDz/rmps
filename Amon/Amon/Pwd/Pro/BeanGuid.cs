using System;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Att;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanGuid : UserControl, IAttEdit
    {
        private AAtt _Att;

        public BeanGuid()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public string Title { get { return "向导"; } }

        public bool ShowData(DataModel dataModel, AAtt att)
        {
            if ((dataModel.LibModified & IEnv.KEY_APWD) > 0)
            {
                CbName.DataSource = dataModel.LibList;
                CbName.DisplayMember = "Name";
                CbName.ValueMember = "Id";
                dataModel.LibModified &= IEnv.KEY_APWD;
            }
            _Att = att;
            return true;
        }

        public void Copy()
        {
        }

        public void Save()
        {
            LibHeader header = CbName.SelectedItem as LibHeader;
            if (header == null || header.Id == "0")
            {
                return;
            }

            if (header.Id != _Att.GetSpec(GuidAtt.SPEC_GUID_TPLT))
            {
                _Att.SetSpec(GuidAtt.SPEC_GUID_TPLT, header.Id);
                _Att.Modified = true;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
