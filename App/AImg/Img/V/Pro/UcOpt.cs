using System;
using System.Windows.Forms;

namespace Me.Amon.Img.V.Pro
{
    public partial class UcOpt : UserControl
    {
        private APro _APro;
        private IOpt _IOpt;

        public UcOpt()
        {
            InitializeComponent();
        }

        public UcOpt(APro apro)
        {
            _APro = apro;

            InitializeComponent();
        }

        #region 事件处理
        private void BtApply_Click(object sender, EventArgs e)
        {
            if (_IOpt != null)
            {
                _APro.DstImage = _IOpt.Deal(_APro.SrcImage);
            }
        }

        private void BtReset_Click(object sender, EventArgs e)
        {
            if (_IOpt != null)
            {
                _IOpt.Reset();
            }
        }

        #region 菜单事件
        private OptScale _Scale;
        private void MiScale_Click(object sender, EventArgs e)
        {
            LlText.Text = "缩放";
            GbBody.Text = "缩放";

            if (_Scale == null)
            {
                _Scale = new OptScale();
                _Scale.Init();
                _Scale.Dock = DockStyle.Fill;
            }
            GbBody.Controls.Clear();
            GbBody.Controls.Add(_Scale);
            _IOpt = _Scale;
        }

        private OptRound _Round;
        private void MiRound_Click(object sender, EventArgs e)
        {
            LlText.Text = "圆角";
            GbBody.Text = "圆角";

            if (_Round == null)
            {
                _Round = new OptRound();
                _Round.Init();
                _Round.Dock = DockStyle.Fill;
            }
            GbBody.Controls.Clear();
            GbBody.Controls.Add(_Round);
            _IOpt = _Round;
        }

        private OptWater _Water;
        private void MIWater_Click(object sender, EventArgs e)
        {
            LlText.Text = "水印";
            GbBody.Text = "水印";

            if (_Water == null)
            {
                _Water = new OptWater();
                _Water.Init();
                _Water.Dock = DockStyle.Fill;
            }
            GbBody.Controls.Clear();
            GbBody.Controls.Add(_Water);
            _IOpt = _Water;
        }
        #endregion

        private void LlText_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CmMenu.Show(PlHead, 0, PlHead.Height);
            }
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {

        }

        private void PbHide_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 私有函数
        private void ShowView()
        {
        }
        #endregion
    }
}
