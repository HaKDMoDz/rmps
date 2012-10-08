using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Me.Amon.Api.Structures;
using Me.Amon.Api.User32;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Kms.Robot.img
{
    public partial class ImgWindow : UserControl, IHuman<Image>
    {
        private KmsHuman _KmsHuman;

        public ImgWindow()
            : this(null)
        {
        }

        public ImgWindow(KmsHuman human)
        {
            _KmsHuman = human;

            InitializeComponent();

            CbImgDim.Items.Add(new Items { K = "win", V = "适合窗口" });
            CbImgDim.Items.Add(new Items { K = "img", V = "适合图像" });
            CbImgDim.Items.Add(new Items { K = "fix", V = "保持不变" });
            CbImgDim.SelectedIndex = 0;

            CbWinLoc.Items.Add(new Items { K = "none", V = "保持不变" });
            CbWinLoc.Items.Add(new Items { K = "sc", V = "屏幕中央" });
            CbWinLoc.Items.Add(new Items { K = "tl", V = "屏幕左上角" });
            CbWinLoc.Items.Add(new Items { K = "bl", V = "屏幕左下角" });
            CbWinLoc.Items.Add(new Items { K = "tr", V = "屏幕右上角" });
            CbWinLoc.Items.Add(new Items { K = "br", V = "屏幕右下角" });
            CbWinLoc.Items.Add(new Items { K = "user", V = "指定位置" });
            CbWinLoc.SelectedIndex = 0;
        }

        #region ICapture 成员

        public UserControl Control
        {
            get { return this; }
        }

        public bool HideWindow()
        {
            return true;
        }

        public void Init(string key)
        {
        }

        public Image Deal()
        {
            IntPtr handle = User32API.GetForegroundWindow();
            var item = CbImgDim.SelectedItem as Items;
            if (item != null && item.K == "img")
            {
                int imgW = decimal.ToInt32(SpImgDimW.Value);
                int imgH = decimal.ToInt32(SpImgDimH.Value);
                User32.RestoreWindow(handle);
                Thread.Sleep(100);
                BeanUtil.ResizeWindow(handle, imgW, imgH, true, CkRatio.Enabled & CkRatio.Checked);
            }

            item = CbWinLoc.SelectedItem as Items;
            if (item != null)
            {
                switch (item.K)
                {
                    case "sc":
                        BeanUtil.CenterWindow(handle);
                        break;
                    case "tl":
                        BeanUtil.CornerWindow(handle, true, true);
                        break;
                    case "tr":
                        BeanUtil.CornerWindow(handle, true, false);
                        break;
                    case "bl":
                        BeanUtil.CornerWindow(handle, false, true);
                        break;
                    case "br":
                        BeanUtil.CornerWindow(handle, false, false);
                        break;
                    case "user":
                        int x = decimal.ToInt32(SpWinLocX.Value);
                        int y = decimal.ToInt32(SpWinLocY.Value);
                        BeanUtil.MoveWindow(handle, x, y);
                        break;
                }
            }

            Thread.Sleep(decimal.ToInt32(SpWait.Value) * 1000);

            var wp = new WINDOWPLACEMENT();
            User32API.GetWindowPlacement(handle, ref wp);
            if (wp.showCmd == (int)Api.Enums.ShowWindow.SW_SHOWMAXIMIZED)
            {
                return BeanUtil.CaptureImage(new Point(0, 0), Screen.PrimaryScreen.WorkingArea);
            }
            return BeanUtil.CaptureImage(handle);
        }

        #endregion

        private void CbImgDim_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = CbImgDim.SelectedItem as Items;
            if (item == null)
            {
                return;
            }

            bool img = item.K == "img";
            CkRatio.Enabled = img;

            bool fix = item.K == "fix";
            SpImgDimW.Enabled = fix | img;
            SpImgDimH.Enabled = fix | img;
        }

        private void CbWinLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = CbWinLoc.SelectedItem as Items;
            if (item == null)
            {
                return;
            }

            bool fix = item.K == "user";
            SpWinLocX.Enabled = fix;
            SpWinLocY.Enabled = fix;
        }
    }
}
