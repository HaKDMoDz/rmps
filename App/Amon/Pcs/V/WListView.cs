using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Me.Amon.Pcs.V
{
    public class WListView : ListView
    {
        private StringFormat _Format;
        private Color _ProgressBackColor;
        private Brush _ProgressBackBrush;
        private Color _ProgressForeColor;
        private Brush _ProgressForeBrush;

        public WListView()
        {
            FullRowSelect = true;
            OwnerDraw = true;
            View = View.Details;

            ProgressBackColor = Color.Green;
            ProgressForeColor = Color.Black;

            _Format = new StringFormat();
            _Format.Alignment = StringAlignment.Center;
            _Format.LineAlignment = StringAlignment.Center;
            _Format.Trimming = StringTrimming.EllipsisCharacter;
        }

        public Color ProgressBackColor
        {
            get
            {
                return _ProgressBackColor;
            }
            set
            {
                _ProgressBackColor = value;
                _ProgressBackBrush = new SolidBrush(value);
            }
        }

        public Color ProgressForeColor
        {
            get
            {
                return _ProgressForeColor;
            }
            set
            {
                _ProgressForeColor = value;
                _ProgressForeBrush = new SolidBrush(value);
            }
        }

        public int ProgressColumnIndex { get; set; }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawColumnHeader(e);
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex != ProgressColumnIndex)
            {
                e.DrawDefault = true;
                base.OnDrawSubItem(e);
                return;
            }

            var item = e.SubItem;
            var rect = item.Bounds;
            if (rect.Height < 2 || rect.Width < 3)
            {
                e.DrawDefault = true;
                base.OnDrawSubItem(e);
                return;
            }

            var text = item.Text;
            double rate = 0;
            if (item.Tag != null && item.Tag is double)
            {
                rate = (double)item.Tag;
            }
            else if (Regex.IsMatch(text, "^\\d{1,2}|100$"))
            {
                rate = int.Parse(text) / 100d;
            }
            else if (Regex.IsMatch(text, "^0?.\\d{1,2}|1(.0{0,2})?$"))
            {
                rate = double.Parse(text);
            }
            else
            {
                return;
            }

            e.DrawBackground();

            int width = (int)(rect.Width * rate);
            rect.X += 1;
            rect.Y += 1;
            rect.Width -= 2;
            rect.Height -= 2;
            e.Graphics.FillRectangle(_ProgressBackBrush, rect.X, rect.Y, width - 2, rect.Height);
            e.Graphics.DrawRectangle(Pens.RoyalBlue, rect);
            e.Graphics.DrawString(rate.ToString("p1"), Font, _ProgressForeBrush, rect, _Format);
        }
    }
}
