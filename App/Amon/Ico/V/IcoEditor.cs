using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.IconLib;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Ico.M;

namespace Me.Amon.Ico.V
{
    public partial class IcoEditor : UserControl, IIco
    {
        private Bitmap _BgImg;
        private SingleIcon _SIcon;
        private AIco _AIco;

        #region 构造函数
        public IcoEditor()
        {
            InitializeComponent();
        }

        public IcoEditor(AIco aico)
        {
            _AIco = aico;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce()
        {
            _BgImg = DrawBg(EIco.PREVIEW_ICON_DIM, EIco.PREVIEW_BG_GAPS);
            PbImg.BackgroundImage = DrawBg(256, 10);
            LbImg.ItemHeight = 80;
        }

        public void AppendImg()
        {
        }

        public void RemoveImg()
        {
            if (LbImg.SelectedItem != null)
            {
                LbImg.Items.Remove(LbImg.SelectedItem);
            }
        }

        public void ToImages(List<Image> images)
        {
            if (_SIcon == null || LbImg.Items.Count < 1)
            {
                return;
            }

            foreach (Abc item in LbImg.Items)
            {
                images.Add(item.Source);
            }
        }

        public void Import(string file)
        {
            if (!File.Exists(file))
            {
                return;
            }

            Abc item = LbImg.SelectedItem as Abc;
            if (item == null)
            {
                return;
            }

            Image img = Image.FromFile(file);
            using (Graphics g = Graphics.FromImage(item.Source))
            {
                int w = item.Source.Width < img.Width ? item.Source.Width : img.Width;
                int h = item.Source.Height < img.Height ? item.Source.Height : img.Height;
                int x = (item.Source.Width - w) >> 1;
                int y = (item.Source.Height - h) >> 1;
                g.DrawImage(img, x, y, w, h);
                g.Save();
            }
            PbImg.Image = item.Source;

            using (Graphics g = Graphics.FromImage(item.Thumbs))
            {
                int w = item.Thumbs.Width < img.Width ? item.Thumbs.Width : img.Width;
                int h = item.Thumbs.Height < img.Height ? item.Thumbs.Height : img.Width;
                int x = (item.Thumbs.Width - w) >> 1;
                int y = (item.Thumbs.Height - h) >> 1;
                g.DrawImage(img, x, y, w, h);
                g.Save();
            }
            LbImg.Items[LbImg.SelectedIndex] = item;
        }

        public void Export(string file)
        {
            Abc item = LbImg.SelectedItem as Abc;
            if (item == null)
            {
                return;
            }

            item.Source.Save(file, ImageFormat.Png);
        }
        #endregion

        public SingleIcon SingleIcon
        {
            get
            {
                _SIcon.Clear();
                foreach (Abc item in LbImg.Items)
                {
                    _SIcon.Add(item.Source);
                }
                return _SIcon;
            }
            set
            {
                _SIcon = value;
                LbImg.Items.Clear();
                Abc item;
                foreach (IconImage ico in _SIcon)
                {
                    item = new Abc();
                    item.Decode(_BgImg, ico);
                    LbImg.Items.Add(item);
                }
            }
        }

        #region 事件处理
        private Brush _Brush = new SolidBrush(Color.Black);
        private void LbImg_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Abc item = LbImg.Items[e.Index] as Abc;
            if (item == null)
            {
                return;
            }

            SizeF size = e.Graphics.MeasureString(item.Text, LbImg.Font);
            Rectangle rect = e.Bounds;

            int x = rect.X + ((rect.Width - item.Thumbs.Width) >> 1);
            int y = rect.Y + ((rect.Height - item.Thumbs.Height - (int)size.Height - 3) >> 1);
            e.Graphics.DrawImage(item.Thumbs, x, y, item.Thumbs.Width, item.Thumbs.Height);

            x = rect.X + ((rect.Width - (int)size.Width) >> 1);
            y = y + item.Thumbs.Height + 3;
            e.Graphics.DrawString(item.Text, LbImg.Font, _Brush, x, y);
        }

        private void LbImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Abc item = LbImg.SelectedItem as Abc;
            if (item == null)
            {
                return;
            }

            //Bitmap bmp = DrawBg(img.Width, EIco.PREVIEW_BG_GAPS);
            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    int x = (bmp.Width - img.Width) >> 1;
            //    int y = (bmp.Height - img.Height) >> 1;
            //    g.DrawImage(img, x, y, img.Width, img.Height);
            //    g.Save();
            //}
            PbImg.Image = item.Source;
        }

        private void LbImg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            LbImg.SelectedIndex = LbImg.IndexFromPoint(e.Location);
            _AIco.IcoMenu.Show(MousePosition);
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
        #endregion
    }
}