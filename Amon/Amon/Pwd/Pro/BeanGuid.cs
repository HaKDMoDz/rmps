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

        public bool ShowData(Model.AAtt att)
        {
            _Att = att;
            return true;
        }

        public void Copy()
        {
        }

        public void Save()
        {
            LibHeader header = comboBox1.SelectedItem as LibHeader;
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
