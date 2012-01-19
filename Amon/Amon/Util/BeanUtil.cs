﻿using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Uc;
using Me.Amon.Uw;

namespace Me.Amon.Util
{
    public class BeanUtil
    {
        public static Form Form { get; set; }
        private static Alert _Alert;
        private static Input _Input;

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

        public static void ShowAlert(string alert)
        {
            if (_Alert == null)
            {
                _Alert = new Alert();
            }
            _Alert.Show(Form, alert);
        }

        public static void ShowInput(string message, string deftext)
        {
            if (_Input == null)
            {
                _Input = new Input();
            }
            _Input.Show(Form, message, deftext);
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
