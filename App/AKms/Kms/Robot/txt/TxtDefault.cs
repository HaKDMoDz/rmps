using System;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Robot.txt
{
    public partial class TxtDefault : UserControl, IHuman<MSentence>
    {
        private KmsHuman _KmsHuman;
        private DataModel _DataModel;

        public TxtDefault()
        {
            InitializeComponent();
        }

        public TxtDefault(KmsHuman human, DataModel dataModel)
        {
            _KmsHuman = human;
            _DataModel = dataModel;

            InitializeComponent();
        }

        #region TxtHuman 成员

        public UserControl Control
        {
            get { return this; }
        }

        public bool HideWindow()
        {
            return false;
        }

        public void Init(string catId)
        {
            LsRes.Items.Clear();
            LsRes.Items.AddRange(_DataModel.ListSentence(catId).ToArray());
        }

        public MSentence Deal()
        {
            if (LsRes.Items.Count < 1)
            {
                return null;
            }

            int idx = LsRes.SelectedIndex + 1;
            if (idx >= LsRes.Items.Count)
            {
                idx = 0;
            }
            LsRes.SelectedIndex = idx;
            return LsRes.SelectedItem as MSentence;
        }
        #endregion

        private void LsRes_DoubleClick(object sender, EventArgs e)
        {
            var sen = LsRes.SelectedItem as MSentence;
            if (sen == null)
            {
                return;
            }
            _KmsHuman.Send(sen.P3100105);
        }
    }
}
