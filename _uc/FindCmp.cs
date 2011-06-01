using System;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.magickms.api.Enum;
using com.magickms.api.Gdi32;
using com.magickms.api.User32;

namespace com.magickms._uc
{
    public partial class FindCmp : UserControl
    {
        private IntPtr LastWindow = IntPtr.Zero;

        public FindCmp()
        {
            InitializeComponent();
        }

        public IntPtr SelectWindow
        {
            get
            {
                return LastWindow;
            }
            set
            {
                if (LastWindow != value)
                {
                    LastWindow = value;
                    DisplayWindowInfo(value);
                }
            }
        }

        #region 控件查找事件
        /// <summary>
        /// Paint a rect into the given window
        /// </summary>
        /// <param name="window"></param>
        private static void ShowInvertRectTracker(IntPtr window)
        {
            if (window != IntPtr.Zero)
            {
                // get the coordinates from the window on the screen
                Rectangle WindowRect = api.User32.User32.GetWindowRect(window);
                // get the window's device context
                IntPtr dc = api.User32.User32.GetWindowDC(window);

                // Create an inverse pen that is the size of the window border
                Gdi32.SetROP2(dc, (int)RopMode.R2_NOT);

                Color color = Color.FromArgb(0, 255, 0);
                IntPtr Pen = Gdi32.CreatePen((int)PenStyles.PS_INSIDEFRAME, 3 * api.User32.User32.GetSystemMetrics((int)SystemMetrics.SM_CXBORDER), (uint)color.ToArgb());

                // Draw the rectangle around the window
                IntPtr OldPen = Gdi32.SelectObject(dc, Pen);
                IntPtr OldBrush = Gdi32.SelectObject(dc, Gdi32.GetStockObject((int)StockObjects.NULL_BRUSH));
                Gdi32.Rectangle(dc, 0, 0, WindowRect.Width, WindowRect.Height);

                Gdi32.SelectObject(dc, OldBrush);
                Gdi32.SelectObject(dc, OldPen);

                //release the device context, and destroy the pen
                api.User32.User32.ReleaseDC(window, dc);
                Gdi32.DeleteObject(Pen);
            }
        }

        /// <summary>
        /// return the window from the given point
        /// </summary>
        /// <param name="point"></param>
        /// <returns>if return == IntPtr.Zero no window was found</returns>
        private static IntPtr ChildWindowFromPoint(Point point)
        {
            IntPtr WindowPoint = api.User32.User32.WindowFromPoint(point);
            if (WindowPoint == IntPtr.Zero)
                return IntPtr.Zero;

            if (api.User32.User32.ScreenToClient(WindowPoint, ref point) == false)
                throw new Exception("ScreenToClient failed");

            IntPtr Window = api.User32.User32.ChildWindowFromPointEx(WindowPoint, point, 0);
            if (Window == IntPtr.Zero)
                return WindowPoint;

            if (api.User32.User32.ClientToScreen(WindowPoint, ref point) == false)
                throw new Exception("ClientToScreen failed");

            if (api.User32.User32.IsChild(api.User32.User32.GetParent(Window), Window) == false)
                return Window;

            // create a list to hold all childs under the point
            ArrayList WindowList = new ArrayList();
            while (Window != IntPtr.Zero)
            {
                Rectangle rect = api.User32.User32.GetWindowRect(Window);
                if (rect.Contains(point))
                    WindowList.Add(Window);
                Window = api.User32.User32.GetWindow(Window, (uint)GetWindow.GW_HWNDNEXT);
            }

            // search for the smallest window in the list
            int MinPixel = api.User32.User32.GetSystemMetrics((int)SystemMetrics.SM_CXFULLSCREEN) * api.User32.User32.GetSystemMetrics((int)SystemMetrics.SM_CYFULLSCREEN);
            for (int i = 0; i < WindowList.Count; ++i)
            {
                Rectangle rect = api.User32.User32.GetWindowRect((IntPtr)WindowList[i]);
                int ChildPixel = rect.Width * rect.Height;
                if (ChildPixel < MinPixel)
                {
                    MinPixel = ChildPixel;
                    Window = (IntPtr)WindowList[i];
                }
            }
            return Window;
        }

        /// <summary>
        /// Show informations about the given window
        /// </summary>
        /// <param name="window"></param>
        private void DisplayWindowInfo(IntPtr window)
        {
            if (window == IntPtr.Zero)
            {
                // reset all edit box
                LbCmp.Text = "";
            }
            else
            {
                // Handler
                LbPos.Text = "句柄：" + window;

                // Caption
                /*
                StringBuilder WindowText = new StringBuilder(User32.GetWindowTextLength(window) + 1);
                User32.GetWindowText(window, WindowText, WindowText.Capacity);
                textBoxCaption.Text = WindowText.ToString();
                */
                //textBoxCaption.Text = User32.GetWindowText(window);

                // Class
                StringBuilder ClassName = new StringBuilder(256);
                int ret = api.User32.User32.GetClassName(window, ClassName, ClassName.Capacity);
                LbCmp.Text = "类型：" + ClassName;

                // Rect
                //Rectangle WindowRect = User32.GetWindowRect(window);
                //textBoxRect.Text = WindowRect.ToString();

                // Point
                //Point point = Cursor.Position;
                //User32.ScreenToClient(window, ref point);
                //textBoxPoint.Text = point.ToString();
            }
        }
        #endregion

        #region 鼠标事件处理
        private void PbApp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
#if DEV
                Cursor = new Cursor(@"F:\app\MagicKms\ico\_cur.cur");
#else
                Cursor = new Cursor(@"ico\_cur.png");
#endif
                PbApp.Image = global::com.magickms.Properties.Resources._run;
            }
        }

        private void PbApp_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Default)
            {
                IntPtr FoundWindow = ChildWindowFromPoint(Cursor.Position);

                // not this application
                Control control = Control.FromHandle(FoundWindow);
                if (control == null)
                {
                    if (FoundWindow != LastWindow)
                    {
                        // clear old window
                        ShowInvertRectTracker(LastWindow);
                        // set new window
                        LastWindow = FoundWindow;
                        // paint new window
                        ShowInvertRectTracker(LastWindow);
                    }
                    DisplayWindowInfo(LastWindow);
                }
                // show global mouse cursor
                //Point p = Cursor.Position;
                //LbPos.Text = "位置：[" + p.X + "," + p.Y + "]";
            }
        }

        private void PbApp_MouseUp(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Default)
            {
                // reset all done things from mouse_down and mouse_move ...
                ShowInvertRectTracker(LastWindow);
                // LastWindow = IntPtr.Zero;

                Cursor = Cursors.Default;
                PbApp.Image = global::com.magickms.Properties.Resources._def;
            }
        }
        #endregion
    }
}
