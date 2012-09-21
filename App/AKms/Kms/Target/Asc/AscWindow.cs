using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Properties;

namespace Me.Amon.Kms.Target.Asc
{
    public partial class AscWindow : Form
    {
        public AscWindow()
        {
            InitializeComponent();
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;

            #region X坐标
            String sx = (TB_LocX.Text ?? "").Trim();
            if (Regex.IsMatch(sx, "^[-]?\\d+$"))
            {
                MessageBox.Show(this, "窗口X坐标应为一个整数！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TB_LocX.Text = sx;
                TB_LocX.Focus();
                return;
            }
            int ix = int.Parse(sx);
            if (ix < 0)
            {
                ix = -1;
            }
            if (ix >= rect.Width)
            {
                MessageBox.Show(this, "窗口X坐标应在屏幕边界内！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TB_LocX.Focus();
                return;
            }
            #endregion

            #region Y坐标
            String sy = (Tb_LocY.Text ?? "").Trim();
            if (Regex.IsMatch(sy, "^[-]?\\d+$"))
            {
                MessageBox.Show(this, "窗口Y坐标应为一个整数！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tb_LocY.Text = sx;
                Tb_LocY.Focus();
                return;
            }
            int iy = int.Parse(sy);
            if (iy < 0)
            {
                iy = -1;
            }
            if (iy >= rect.Height)
            {
                MessageBox.Show(this, "窗口Y坐标应在屏幕边界内！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tb_LocY.Focus();
                return;
            }
            #endregion

            #region 宽度
            String sw = (Tb_LocY.Text ?? "").Trim();
            if (Regex.IsMatch(sw, "^\\d+$"))
            {
                MessageBox.Show(this, "窗口宽度应为一个非负整数！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbWinDimW.Text = sx;
                TbWinDimW.Focus();
                return;
            }
            int iw = int.Parse(sw);
            if (iw < 1)
            {
                MessageBox.Show(this, "窗口宽度应为一个非负整数！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbWinDimW.Focus();
                return;
            }
            if (iw > rect.Width)
            {
                MessageBox.Show(this, "窗口宽度不能大于屏幕宽度！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbWinDimW.Focus();
                return;
            }
            #endregion

            #region 高度
            String sh = (Tb_LocY.Text ?? "").Trim();
            if (Regex.IsMatch(sh, "^\\d+$"))
            {
                MessageBox.Show(this, "窗口高度应为一个非负整数！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbWinDimH.Text = sx;
                TbWinDimH.Focus();
                return;
            }
            int ih = int.Parse(sh);
            if (ih < 1)
            {
                MessageBox.Show(this, "窗口高度应为一个非负整数！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbWinDimH.Focus();
                return;
            }
            if (ih > rect.Height)
            {
                MessageBox.Show(this, "窗口高度不能大于屏幕高度！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbWinDimH.Focus();
                return;
            }
            #endregion

            #region 延时
            String st = (Tb_Time.Text ?? "").Trim();
            if (Regex.IsMatch(st, "^\\d+$"))
            {
                MessageBox.Show(this, "截图延时应为一个非负整数！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tb_Time.Text = st;
                Tb_Time.Focus();
                return;
            }
            int it = int.Parse(st);
            if (ih < 1)
            {
                MessageBox.Show(this, "截图延时应为一个非负整数！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tb_Time.Focus();
                return;
            }
            #endregion

            Settings settings = Settings.Default;
            //settings.screenshot_x = ix;
            //settings.screenshot_y = iy;
            //settings.screenshot_w = iw;
            //settings.screenshot_h = ih;
            //settings.screenshot_s = Ck_Scale.Checked;
            //settings.screenshot_r = Ck_Ratio.Checked;
            //settings.screenshot_t = it;

            Close();
        }
    }
}
