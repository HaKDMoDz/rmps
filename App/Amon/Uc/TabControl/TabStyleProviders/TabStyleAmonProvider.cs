using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
    [System.ComponentModel.ToolboxItem(false)]
    class TabStyleAmonProvider : TabStyleProvider
    {
        public TabStyleAmonProvider(ATabControl tabControl)
            : base(tabControl)
        {
            this._CloserColorActive = Color.Black;
            this._CloserColor = Color.FromArgb(117, 99, 61);
            //this._TextColor = Color.White;
            //this._TextColorDisabled = Color.WhiteSmoke;
            //this._BorderColor = Color.Transparent;
            //this._BorderColorHot = Color.FromArgb(155, 167, 183);

            this._ImageAlign = ContentAlignment.MiddleRight;
            this._Overlap = 7;

            //	Must set after the _Radius as this is used in the calculations of the actual padding
            this.Padding = new Point(14, 3);
        }

        public override void AddTabBorder(System.Drawing.Drawing2D.GraphicsPath path, System.Drawing.Rectangle tabBounds)
        {
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    path.AddLine(tabBounds.X, tabBounds.Bottom, tabBounds.X + tabBounds.Height - 4, tabBounds.Y + 2);
                    path.AddLine(tabBounds.X + tabBounds.Height, tabBounds.Y, tabBounds.Right - 3, tabBounds.Y);
                    path.AddArc(tabBounds.Right - 6, tabBounds.Y, 6, 6, 270, 90);
                    path.AddLine(tabBounds.Right, tabBounds.Y + 3, tabBounds.Right, tabBounds.Bottom);
                    break;
                case TabAlignment.Bottom:
                    path.AddLine(tabBounds.Right, tabBounds.Y, tabBounds.Right, tabBounds.Bottom - 3);
                    path.AddArc(tabBounds.Right - 6, tabBounds.Bottom - 6, 6, 6, 0, 90);
                    path.AddLine(tabBounds.Right - 3, tabBounds.Bottom, tabBounds.X + tabBounds.Height, tabBounds.Bottom);
                    path.AddLine(tabBounds.X + tabBounds.Height - 4, tabBounds.Bottom - 2, tabBounds.X, tabBounds.Y);
                    break;
                case TabAlignment.Left:
                    path.AddLine(tabBounds.Right, tabBounds.Bottom, tabBounds.X + 3, tabBounds.Bottom);
                    path.AddArc(tabBounds.X, tabBounds.Bottom - 6, 6, 6, 90, 90);
                    path.AddLine(tabBounds.X, tabBounds.Bottom - 3, tabBounds.X, tabBounds.Y + tabBounds.Width);
                    path.AddLine(tabBounds.X + 2, tabBounds.Y + tabBounds.Width - 4, tabBounds.Right, tabBounds.Y);
                    break;
                case TabAlignment.Right:
                    path.AddLine(tabBounds.X, tabBounds.Y, tabBounds.Right - 2, tabBounds.Y + tabBounds.Width - 4);
                    path.AddLine(tabBounds.Right, tabBounds.Y + tabBounds.Width, tabBounds.Right, tabBounds.Bottom - 3);
                    path.AddArc(tabBounds.Right - 6, tabBounds.Bottom - 6, 6, 6, 0, 90);
                    path.AddLine(tabBounds.Right - 3, tabBounds.Bottom, tabBounds.X, tabBounds.Bottom);
                    break;
            }
        }
        protected override Brush GetTabBackgroundBrush(int index)
        {
            LinearGradientBrush fillBrush = null;

            //	Capture the colours dependant on selection state of the tab
            Color dark = Color.FromArgb(207, 207, 207);
            Color light = Color.FromArgb(242, 242, 242);

            if (this._TabControl.SelectedIndex == index)
            {
                dark = Color.FromArgb(229, 195, 101);
                light = SystemColors.Window;
            }
            else if (!this._TabControl.TabPages[index].Enabled)
            {
                light = dark;
            }
            else if (this.HotTrack && index == this._TabControl.ActiveIndex)
            {
                //	Enable hot tracking
                dark = Color.FromArgb(108, 116, 118);
                light = dark;
            }

            //	Get the correctly aligned gradient
            Rectangle tabBounds = this.GetTabRect(index);
            tabBounds.Inflate(3, 3);
            tabBounds.X -= 1;
            tabBounds.Y -= 1;
            switch (this._TabControl.Alignment)
            {
                case TabAlignment.Top:
                    fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Vertical);
                    break;
                case TabAlignment.Bottom:
                    fillBrush = new LinearGradientBrush(tabBounds, dark, light, LinearGradientMode.Vertical);
                    break;
                case TabAlignment.Left:
                    fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Horizontal);
                    break;
                case TabAlignment.Right:
                    fillBrush = new LinearGradientBrush(tabBounds, dark, light, LinearGradientMode.Horizontal);
                    break;
            }

            //	Add the blend
            fillBrush.Blend = GetBackgroundBlend();

            return fillBrush;
        }

        private static Blend GetBackgroundBlend()
        {
            float[] relativeIntensities = new float[] { 0f, 0.5f, 1f, 1f };
            float[] relativePositions = new float[] { 0f, 0.5f, 0.51f, 1f };


            Blend blend = new Blend();
            blend.Factors = relativeIntensities;
            blend.Positions = relativePositions;

            return blend;
        }

        public override Brush GetPageBackgroundBrush(int index)
        {

            //	Capture the colours dependant on selection state of the tab
            Color light = Color.Transparent;

            if (this._TabControl.SelectedIndex == index)
            {
                light = Color.FromArgb(229, 195, 101);
            }
            else if (!this._TabControl.TabPages[index].Enabled)
            {
                light = Color.Transparent;
            }
            else if (this._HotTrack && index == this._TabControl.ActiveIndex)
            {
                //	Enable hot tracking
                light = Color.Transparent;
            }

            return new SolidBrush(light);
        }

        protected override void DrawTabCloser(int index, Graphics graphics)
        {
            if (this._ShowTabCloser)
            {
                Rectangle closerRect = this._TabControl.GetTabCloserRect(index);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                if (closerRect.Contains(this._TabControl.MousePosition))
                {
                    using (GraphicsPath closerPath = GetCloserButtonPath(closerRect))
                    {
                        graphics.FillPath(Brushes.White, closerPath);
                        using (Pen closerPen = new Pen(Color.FromArgb(229, 195, 101)))
                        {
                            graphics.DrawPath(closerPen, closerPath);
                        }
                    }
                    using (GraphicsPath closerPath = GetCloserPath(closerRect))
                    {
                        using (Pen closerPen = new Pen(this._CloserColorActive))
                        {
                            closerPen.Width = 2;
                            graphics.DrawPath(closerPen, closerPath);
                        }
                    }
                }
                else
                {
                    if (index == this._TabControl.SelectedIndex)
                    {
                        using (GraphicsPath closerPath = GetCloserPath(closerRect))
                        {
                            using (Pen closerPen = new Pen(this._CloserColor))
                            {
                                closerPen.Width = 2;
                                graphics.DrawPath(closerPen, closerPath);
                            }
                        }
                    }
                    else if (index == this._TabControl.ActiveIndex)
                    {
                        using (GraphicsPath closerPath = GetCloserPath(closerRect))
                        {
                            using (Pen closerPen = new Pen(Color.FromArgb(155, 167, 183)))
                            {
                                closerPen.Width = 2;
                                graphics.DrawPath(closerPen, closerPath);
                            }
                        }
                    }
                }

            }
        }

        private static GraphicsPath GetCloserButtonPath(Rectangle closerRect)
        {
            GraphicsPath closerPath = new GraphicsPath();
            closerPath.AddLine(closerRect.X - 1, closerRect.Y - 2, closerRect.Right + 1, closerRect.Y - 2);
            closerPath.AddLine(closerRect.Right + 2, closerRect.Y - 1, closerRect.Right + 2, closerRect.Bottom + 1);
            closerPath.AddLine(closerRect.Right + 1, closerRect.Bottom + 2, closerRect.X - 1, closerRect.Bottom + 2);
            closerPath.AddLine(closerRect.X - 2, closerRect.Bottom + 1, closerRect.X - 2, closerRect.Y - 1);
            closerPath.CloseFigure();
            return closerPath;
        }
    }
}
