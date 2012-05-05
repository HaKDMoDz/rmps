using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.V.Wiz
{
    public partial class BeanInfo : UserControl, IWizView
    {
        private SafeModel _SafeModel;

        public BeanInfo()
        {
            InitializeComponent();
        }

        public BeanInfo(SafeModel safeModel)
        {
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel)
        {
        }

        public void InitView(TableLayoutPanel grid)
        {
            grid.Controls.Add(this, 0, 0);
            Dock = DockStyle.Fill;
            TabIndex = 0;
            grid.RowStyles[1].Height = 0;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
        }

        public void ShowData()
        {
        }

        public bool SaveData()
        {
            return false;
        }

        public void CutData()
        {
        }

        public void CopyData()
        {
        }

        public void PasteData()
        {
        }

        public void ClearData()
        {
        }

        private void BeanInfo_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
    }
}
