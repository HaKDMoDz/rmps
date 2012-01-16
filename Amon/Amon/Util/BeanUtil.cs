using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Util
{
    public class BeanUtil
    {
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

        private static Image _CatNaN;
        public static Image CatNaN
        {
            get
            {
                if (_CatNaN == null)
                {
                    _CatNaN = new Bitmap(16, 16);
                }
                return _CatNaN;
            }
        }

        private static Image _KeyNaN;
        public static Image KeyNaN
        {
            get
            {
                if (_KeyNaN == null)
                {
                    _KeyNaN = new Bitmap(32, 32);
                }
                return _KeyNaN;
            }
        }

        public static void ShowAlert(string alert)
        {
            MessageBox.Show(alert);
        }
    }
}
