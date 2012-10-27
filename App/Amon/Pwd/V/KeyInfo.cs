using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V
{
    public partial class KeyInfo : UserControl
    {
        private SafeModel _SafeModel;
        private TableLayoutPanel _TlPanel;

        #region 构造函数
        public KeyInfo()
        {
            InitializeComponent();
        }

        public KeyInfo(SafeModel safeModel)
        {
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(TableLayoutPanel grid, DataModel dataModel)
        {
            _TlPanel = grid;
        }
        #endregion

        #region 接口实现
        public void InitView()
        {
            _TlPanel.Controls.Add(this, 0, 0);
            Dock = DockStyle.Fill;
            TabIndex = 0;
        }

        public void HideView()
        {
            _TlPanel.Controls.Remove(this);
        }

        public void ShowData()
        {
            _TlPanel.RowStyles[1].Height = 0;
        }

        public void CopyData()
        {
        }

        public void FillData()
        {
        }
        #endregion

        #region 事件处理
        private void BeanInfo_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
        #endregion
    }
}
