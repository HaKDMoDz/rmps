using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Me.Amon.Pcs.V.Task
{
    public class DataGridViewProgressCell : DataGridViewImageCell
    {
        private static Brush _ForeColor;
        private static StringFormat _StringFormat;

        private Bitmap _ContentImage;
        private Bitmap _EmptyImage;
        private Rectangle _Rectangle;

        static DataGridViewProgressCell()
        {
            _ForeColor = Brushes.Navy;

            _StringFormat = new StringFormat();
            _StringFormat.Alignment = StringAlignment.Center;
            _StringFormat.LineAlignment = StringAlignment.Center;
        }

        public DataGridViewProgressCell()
        {
            Value = 0d;
            ValueType = typeof(double);
            base.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            int width = this.OwningColumn.Width - 4;
            int height = this.OwningRow.Height - 4;

            if (value == null || !(value is double))
            {
                if (_EmptyImage == null || width != _EmptyImage.Width || height != _EmptyImage.Height)
                {
                    _EmptyImage = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
                }
                return _EmptyImage;
            }

            RectangleF rect = new RectangleF(0, 0, width, height);
            if (_ContentImage == null || _ContentImage.Width != width || _ContentImage.Height != height)
            {
                _ContentImage = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
            }
            using (Graphics g = Graphics.FromImage(_ContentImage))
            {
                //g.Clear(Color.Transparent);
                double num = (double)value;
                if (num < 0)
                {
                    num = 0;
                }
                if (num > 1)
                {
                    num = 1;
                }

                if (VisualStyleInformation.IsEnabledByUser & VisualStyleInformation.IsSupportedByOS)
                {
                    ProgressBarRenderer.DrawHorizontalBar(g, new Rectangle(2, 2, width - 2, height - 2));
                    if (num != 0)
                    {
                        ProgressBarRenderer.DrawHorizontalChunks(g, new Rectangle(3, 3, (int)((width - 4) * num), height - 4));
                    }
                }
                else
                {
                    g.DrawRectangle(Pens.Black, 2, 2, width - 2, height - 2);
                    if (num != 0)
                    {
                        g.FillRectangle(Brushes.Blue, 3, 3, (int)((width - 4) * num), height - 4);
                    }
                }

                g.DrawString(num.ToString("p1"), base.DataGridView.Font, _ForeColor, rect, _StringFormat);
                return _ContentImage;
            }
        }
    }
}
