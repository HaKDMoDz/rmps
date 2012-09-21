using System;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Robot.txt
{
    public partial class TxtDefault : UserControl, IHuman<MSentence>
    {
        private KmsHuman _KmsHuman;

        public TxtDefault()
            : this(null)
        {
        }

        public TxtDefault(KmsHuman human)
        {
            _KmsHuman = human;

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
            LsRes.Items.AddRange(DataModel.ListSentence(catId).ToArray());
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
