using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V
{
    public partial class KeyInfo : UserControl, IPwd
    {
        private SafeModel _SafeModel;

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

        public void Init(DataModel dataModel)
        {
        }
        #endregion

        #region 接口实现
        public string Model { get; set; }

        public void InitView(Panel panel)
        {
            panel.Controls.Add(this);
            Dock = DockStyle.Fill;
            TabIndex = 0;
        }

        public void HideView(Panel panel)
        {
            panel.Controls.Remove(this);
        }

        public void ShowData()
        {
        }

        public void AppendKey()
        {
        }

        public bool UpdateKey()
        {
            return false;
        }

        public void DeleteKey()
        {
        }

        public void AppendAtt(int type)
        {
        }

        public void ChangeAtt(int type)
        {
        }

        public void SelectPrev()
        {
        }

        public void SelectNext()
        {
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void CutAtt()
        {
        }

        public void CopyAtt(CopyType type)
        {
        }

        public void PasteAtt()
        {
        }

        public void ClearAtt()
        {
        }

        public void SaveAtt()
        {
        }

        public void DropAtt()
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
