using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Util
{
    public class BeanUtil
    {
        public static IApp IApp { get; set; }

        public static void Clear(ComboBox cBox)
        {
            if (cBox.Items.Count < 1)
            {
                return;
            }
            int idx = cBox.SelectedIndex;
            for (int i = cBox.Items.Count - 1; i > 0; i -= 1)
            {
                cBox.Items.RemoveAt(i);
            }
            if (idx != 0)
            {
                cBox.SelectedIndex = 0;
            }
        }

        public static void Clear(ComboBox cBox, Item[] items)
        {
            int idx = cBox.SelectedIndex;
            for (int i = cBox.Items.Count - 1; i > 1; i -= 1)
            {
                cBox.Items.RemoveAt(i);
            }
            cBox.Items.AddRange(items);
            if (idx != 0)
            {
                cBox.SelectedIndex = 0;
            }
        }

        private static Image _NaN16;
        public static Image NaN16
        {
            get
            {
                if (_NaN16 == null)
                {
                    _NaN16 = new Bitmap(16, 16);
                }
                return _NaN16;
            }
        }

        private static Image _NaN32;
        public static Image NaN32
        {
            get
            {
                if (_NaN32 == null)
                {
                    _NaN32 = new Bitmap(32, 32);
                }
                return _NaN32;
            }
        }

        public static void CenterToParent(Form child, Form parent)
        {
            if (parent != null && parent.Visible)
            {
                Point point = parent.Location;
                point.X += (parent.Width - child.Width) >> 1;
                point.Y += (parent.Height - child.Height) >> 1;
                child.Location = point;
            }
            else
            {
                Point point = new Point();
                point.X = (SystemInformation.WorkingArea.Width - child.Width) >> 1;
                point.Y = (SystemInformation.WorkingArea.Height - child.Height) >> 1;
                child.Location = point;
            }
        }

        public static Image ReadImage(string file, Image defImg)
        {
            if (!File.Exists(file))
            {
                return defImg;
            }
            using (Stream stream = File.OpenRead(file))
            {
                return Image.FromStream(stream);
            }
        }
    }
}
