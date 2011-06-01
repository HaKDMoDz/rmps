using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace com.magickms
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Paint(object sender, PaintEventArgs e)
        {
            int radius = 20;
            int x = 10;
            int y = 10;
            int Width = 400;
            int Height = 300;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            // 右上角
            path.AddLine(x + radius, y, x + Width - radius, y);
            path.AddArc(x + Width - radius, y, radius, radius, -90, 90);

            // 右下角
            path.AddLine(x + Width, y + radius, x + Width, y + Height - radius);
            path.AddArc(x + Width - radius, y + Height - radius, radius, radius, 0, 90);

            // 左下角
            path.AddLine(x + Width - radius, y + Height, x + radius, y + Height);
            path.AddArc(x, y + Height - radius, radius, radius, 90, 90);

            // 左上角
            path.AddLine(x, y + Height - radius, x, y + radius);
            path.AddArc(x, y, radius, radius, 180, 90);

            path.CloseFigure();

            Pen pen = new Pen(new SolidBrush(Color.Red), 2.0f);
            e.Graphics.DrawPath(pen, path);
        }
    }
}
