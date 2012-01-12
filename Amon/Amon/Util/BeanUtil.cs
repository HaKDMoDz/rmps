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
        private static Image _None;

        public static Image None
        {
            get
            {
                if (_None == null)
                {
                    _None = new Bitmap(16, 16);
                }
                return _None;
            }
        }

        public static void ShowAlert(string alert)
        {
            MessageBox.Show(alert);
        }
    }
}
