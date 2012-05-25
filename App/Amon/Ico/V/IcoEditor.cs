using System;
using System.Drawing;
using System.Drawing.IconLib;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Ico
{
    public partial class IcoEditor : UserControl, IIco
    {
        private Image _BgImg;
        private SingleIcon _SIcon;

        public IcoEditor()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void InitOnce()
        {
            _BgImg = DrawBg(EIco.PREVIEW_ICON_DIM, EIco.PREVIEW_BG_GAPS);
        }

        public void OpenFile(string file)
        {
        }
        #endregion

        public SingleIcon SingleIcon
        {
            get
            {
                return _SIcon;
            }
            set
            {
                _SIcon = value;
                LbImg.Items.Clear();
                foreach (IconImage ico in _SIcon)
                {
                    LbImg.Items.Add(ico.Icon.Width);
                }
            }
        }

        #region 事件处理
        private void LbImg_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            DrawImage(e.Graphics, _BgImg, e.Bounds);

            if (SingleIcon == null)
            {
                return;
            }
            Image img = SingleIcon[e.Index].Icon.ToBitmap();
            if (img.Width > EIco.PREVIEW_ICON_DIM)
            {
                img = BeanUtil.ScaleImage(img, EIco.PREVIEW_ICON_DIM, true);
            }
            DrawImage(e.Graphics, img, e.Bounds);
        }

        private void LbImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            IconImage ico = _SIcon[LbImg.SelectedIndex];
            Image img = ico.Icon.ToBitmap();
            Bitmap bmp = DrawBg(img.Width, EIco.PREVIEW_BG_GAPS);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                int x = (bmp.Width - img.Width) >> 1;
                int y = (bmp.Height - img.Height) >> 1;
                g.DrawImage(img, x, y, img.Width, img.Height);
            }
            PbImg.Image = bmp;
        }
        #endregion

        #region 私有函数
        private Bitmap DrawBg(int dim, int gap)
        {
            int td = dim + (gap << 1);
            Pen p1 = new Pen(Color.LightGray);
            Pen p2 = new Pen(Color.FromArgb(228, 228, 228));

            Bitmap bmp = new Bitmap(td, td);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, td, td);

                g.DrawRectangle(p1, 0, 0, td - 1, td - 1);
                int t1 = gap - 1;
                int t2 = dim + 2;
                g.DrawRectangle(p2, t1, t1, t2 - 1, t2 - 1);

                t1 = gap;
                t2 = dim + t1;
                p2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                for (int t = t1 + 8; t < t2; t += 8)
                {
                    g.DrawLine(p2, t1, t, t2, t);
                    g.DrawLine(p2, t, t1, t, t2);
                }
            }
            return bmp;
        }

        private void DrawImage(Graphics g, Image img, Rectangle rect)
        {
            int x = rect.X + ((rect.Width - img.Width) >> 1);
            int y = rect.Y + ((rect.Height - img.Height) >> 1);
            g.DrawImage(img, x, y, img.Width, img.Height);
        }
        #endregion
    }
}
